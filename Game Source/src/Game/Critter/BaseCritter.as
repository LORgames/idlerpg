package Game.Critter {
	import CollisionSystem.PointX;
	import CollisionSystem.Rect;
	import Debug.Drawer;
	import EngineTiming.Clock;
	import EngineTiming.ICleanUp;
	import EngineTiming.IUpdatable;
	import flash.display.Graphics;
	import flash.geom.Point;
	import Game.Map.MapData;
	import Game.Map.Portals.Portal;
	import Game.Map.ScriptRegion;
	import Game.Map.Tiles.TileHelper;
	import Game.Map.Tiles.TileInstance;
	import Game.Map.Tiles.TileTemplate;
	import Game.Map.WorldData;
	import Game.Scripting.GlobalVariables;
	import Game.Scripting.IScriptTarget;
	import Game.Scripting.Script;
	import Game.Scripting.ScriptInstance;
	import Game.Scripting.ScriptTypes;
	import Interfaces.IMapObject;
	/**
	 * ...
	 * @author Paul
	 */
	public class BaseCritter implements IUpdatable, IMapObject, ICleanUp, IScriptTarget {
		public var state:int = 0;
		protected var ControlsLocked:Boolean = false;
		
		public var Persistent:Boolean = false;
		public var Owner:IScriptTarget;
		
		//Current state information
		public var isMoving:Boolean = false;
		public var virginMoveSpeedX:Number = 0;
		public var virginMoveSpeedY:Number = 0;
		public var moveSpeedX:int = 0;
		public var moveSpeedY:int = 0;
		public var PrimaryFaction:int = 0;
		
		public var teamID:int = 0;
		
		public var MovementSpeed:int = 125;
		private var AlertRange:int = 20000; private var AlertRangeSqrt:int = 0; public function SetAlertRangeSqrd(ar:int):void { AlertRange = ar; AlertRangeSqrt = Math.sqrt(ar) + 1; }
		public var AttackRange:int = 600;
		public var CurrentTarget:IScriptTarget;
		
		public var CurrentMovementCost:Number = 1;
		
		public var CurrentMap:MapData;
		
		public var X:Number = 0;
		public var Y:Number = 0;
		public var direction:int = 3;
		
		public var MyRect:Rect;
		
		public var MyScript:ScriptInstance;
		private var ActiveScriptRegions:Vector.<ScriptRegion> = new Vector.<ScriptRegion>();
		
		//Critter information
		public var MyAIType:int;
		public var CurrentHP:int = 1000;
		
		public function BaseCritter() {
			MyRect = new Rect(false, this, 0, 0, 0, 0);
			Clock.I.Updatables.push(this);
		}
		
		protected function CheckScriptRegions():void {
			var sci:int = CurrentMap.ScriptRegions.length;
			var sai:int;
			var sr:ScriptRegion;
			var hasCollision:Boolean;
			var activeRegions:Vector.<ScriptRegion> = new Vector.<ScriptRegion>();
			
			while (--sci > -1) {
				hasCollision = false;
				sr = CurrentMap.ScriptRegions[sci];
				sai = sr.Area.length;
				
				while (--sai > -1) {
					if (sr.Area[sai].intersects(MyRect)) {
						hasCollision = true;
						break;
					}
				}
				
				if (hasCollision) {
					activeRegions.push(sr);
					break;
				}
			}
			
			sci = ActiveScriptRegions.length;
			while (--sci > -1) {
				sai = activeRegions.indexOf(ActiveScriptRegions[sci]);
				
				if (sai == -1) {
					//We stepped off a script region
					ActiveScriptRegions[sci].MyScript.Run(Script.OnExit, this);
					ActiveScriptRegions.splice(sci, 1);
				} else {
					//We were on it last update
					activeRegions.splice(sai, 1);
				}
			}
			
			sci = activeRegions.length;
			while (--sci > -1) {
				activeRegions[sci].MyScript.Run(Script.OnEnter, this);
				ActiveScriptRegions.push(activeRegions[sci]);
			}
		}
		
		public function ShiftMaps(newMap:MapData, location:int = 0):void {
			if (CurrentMap != null) {
				CurrentMap.CritterPop(this);
			}
			
			newMap.CritterPush(this);
			
			this.X = (location % newMap.TileSizeX) * Global.TileSize;
			this.Y = (location / newMap.TileSizeX) * Global.TileSize;
		}
		
		public function RequestTeleport(newMap:MapData, portal:Portal):void {
			if (CurrentMap != null) {
				CurrentMap.CritterPop(this);
			}
			
			newMap.CritterPush(this);
			
			this.X = portal.Entry.X;
			this.Y = portal.Entry.Y;
			
			Update(0);
			
			//TODO: Portals need to get disabled when you step off one
			//Global.DisablePortals = false;
		}
		
		public function RequestInMapTeleport():void {
			RequestTeleport(CurrentMap, CurrentMap.Portals[Global.MapPortalID]);
			Main.I.Renderer.FadeToWorld();
		}
		
		protected function SpeedToDirection(xSpeed:Number, ySpeed:Number):int {
			var mx:Number = xSpeed < 0 ? -xSpeed : xSpeed;
			var my:Number = ySpeed < 0 ? -ySpeed : ySpeed;
			
			//if (mx > my) {
				if (xSpeed < 0) {
					return 0;
				} else {
					return 1;
				}
			//} else {
			//	if (ySpeed < 0) {
			//		return 2;
			//	} else {
			//		return 3;
			//	}
			//}
		}
		
		public function Update(dt:Number):void {
			if (CurrentMap == null) return;
			
			//Will need these later :)
			var j:int;
			
			//// AI  AI  AI  AI ///////////////////////////////////////////////////////// AI
			ProcessAI(dt);
			
			////////////////////////////////////////////////////////////////////////////////
			
			//Store these in case
			var prevX:int = X;
			var prevY:int = Y;
			
			//Process the things
			X += moveSpeedX * dt / CurrentMovementCost;
			Y += moveSpeedY * dt / CurrentMovementCost;
			CurrentMovementCost = 1; //reset to 1 and then update the other things when possible
			
			MyRect.X = X - MyRect.W / 2;
			MyRect.Y = Y - MyRect.H / 2;
			
			//Now do a quick tile check to see if we hit anything
			var tiles:Vector.<TileInstance> = TileHelper.GetTiles(MyRect, CurrentMap);
			var i:int = tiles.length;
			
			//Collision measures how far into something else we've penetrated
			var collisionPenetration:Point = new Point();
			var collisionTotal:int = 0;
			
			//Check if the critter tried to leave the map boundaries
			if (MyRect.X < 0 || MyRect.Y < 0 || MyRect.X + MyRect.H > CurrentMap.SizeX || MyRect.Y + MyRect.W > CurrentMap.SizeY) {
				//Undo the changes: no leaving the map
				X = prevX;
				Y = prevY;
				
				MyRect.X = X - MyRect.W / 2;
				MyRect.Y = Y - MyRect.H / 2;
			} else {
				//They didn't leave the map? Lets try solid objects
				while (--i > -1) {
					//Look for collision in the tile.
					var rs:Vector.<Rect> = tiles[i].SolidRectangles;
					j = rs.length;
					
					while (--j > -1) {
						if (rs[j].intersects(MyRect)) {
							MyRect.CalculatePenetration(rs[j], collisionPenetration);
							collisionTotal++;
						}
					}
					
					//No collision so lets update the movement speed
					if (Global.HasTiles && TileTemplate.Tiles[tiles[i].TileID].movementCost > CurrentMovementCost) {
						CurrentMovementCost = TileTemplate.Tiles[tiles[i].TileID].movementCost;
					}
				}
				
				//Scan against critters
				if (collisionPenetration.x == 0 || collisionPenetration.y == 0) {
					var totalCritters:int = CurrentMap.Critters.length;
					var critter:BaseCritter;
					
					while (--totalCritters > -1) {
						critter = CurrentMap.Critters[totalCritters];
						
						if (critter != this) {
							if (critter.MyRect == null) continue;
							if (MyRect.intersects(critter.MyRect)) {
								MyRect.CalculatePenetration(critter.MyRect, collisionPenetration);
								collisionTotal++;
							}
						}
					}
				}
				
				if (collisionPenetration.x != 0 || collisionPenetration.y != 0) {
					//Undo the changes
					if((Math.abs(collisionPenetration.x) < Math.abs(collisionPenetration.y)  && collisionPenetration.x != 0) || collisionPenetration.y == 0) {
						X += collisionPenetration.x;
					} else {
						Y += collisionPenetration.y;
					}
					
					MyRect.X = X - MyRect.W / 2;
					MyRect.Y = Y - MyRect.H / 2;
				}
				
				CheckScriptRegions();
			}
		}
		
		private function ProcessAI(dt:Number = 0):void {
			var procTarget:Boolean = false;
			
			if (WorldData.ME != this && dt > 0) {
				//AI AGENTS
				if ((MyAIType | AITypes.Aggressive) > 0 && (CurrentTarget == null && (MyAIType | AITypes.ClosestTarget) > 0)) {
					//Scan for a new target
					var r:Rect = new Rect(false, null, X - AlertRangeSqrt, Y - AlertRangeSqrt * Global.PerspectiveSkew, AlertRangeSqrt * 2, AlertRangeSqrt * 2 * Global.PerspectiveSkew);
					Drawer.AddDebugRect(r, PrimaryFaction==1?0xFFFFFF:0x0);
					
					var objs:Vector.<IScriptTarget> = new Vector.<IScriptTarget>();
					CurrentMap.GetObjectsInArea(r, objs, ((MyAIType & AITypes.Supportive) > 0)?ScriptTypes.Ally:ScriptTypes.Enemy, this);
					
					var i:int = objs.length;
					while (--i > -1) {
						if (objs[i] is BaseCritter) {
							var x:BaseCritter = (objs[i] as BaseCritter);
							CurrentTarget = x;
							break;
						}
					}
				}
				
				if (CurrentTarget != null) {
					if (CurrentTarget is BaseCritter) {
						if ((CurrentTarget as BaseCritter).CurrentHP <= 0) {
							CurrentTarget = null;
							RequestMove(0, 0);
							return;
						}
					}
					
					var p:PointX = new PointX();;
					CurrentTarget.UpdatePointX(p);
					
					var dx:Number = (this.X - p.X);
					var dy:Number = (this.Y - p.Y) / Global.PerspectiveSkew;
					
					Drawer.AddLine(X, Y, p.X, p.Y, PrimaryFaction==1?0xFFFFFF:0x0);
					
					var AttackRangeSqrt:int = Math.sqrt(AttackRange) + 1;
					
					var rAtk:Rect = new Rect(false, null, X - AttackRangeSqrt, Y - AttackRangeSqrt*Global.PerspectiveSkew, AttackRangeSqrt * 2, AttackRangeSqrt * 2*Global.PerspectiveSkew);
					Drawer.AddDebugRect(rAtk, PrimaryFaction==1?0xFFFFFF:0x0);
					
					if ((CurrentTarget is IMapObject) && (CurrentTarget as IMapObject).HasPerfectCollision(rAtk)) {
						RequestBasicAttack();
						procTarget = true;
					} else if ((MyAIType & AITypes.Aggressive)) {
						RequestMove( -dx, -dy);
						procTarget = true;
					} else if (dx * dx + dy * dy > AlertRange*1.25) {
						procTarget = false;
						CurrentTarget = null;
					}
				}
				
				if (!procTarget) {
					if ((MyAIType & AITypes.Wonder) > 0) {
						//This should call an AI event probably :)
					} else {
						if (moveSpeedX != 0 || moveSpeedY != 0) {
							RequestMove(0, 0);
						}
					}
				}
			}
		}
		
		public function RequestMove(xSpeed:Number, ySpeed:Number, move:Boolean = true):void {
			virginMoveSpeedX = xSpeed;
			virginMoveSpeedY = ySpeed;
			
			if (xSpeed != 0 || ySpeed != 0) {
				direction = SpeedToDirection(xSpeed, ySpeed);
				
				if (move) {
					// normalise speed vector
					var mSpeed:Number = Math.sqrt((xSpeed * xSpeed) + (ySpeed * ySpeed));
					xSpeed = xSpeed / mSpeed;
					ySpeed = ySpeed / mSpeed;
					
					moveSpeedX = xSpeed * MovementSpeed;
					
					if(ySpeed < 0) moveSpeedY = ySpeed * MovementSpeed * Global.PerspectiveSkew;
					if(ySpeed > 0) moveSpeedY = ySpeed * MovementSpeed * Global.PerspectiveSkew;
					
					isMoving = true;
				} else {
					moveSpeedX = 0;
					moveSpeedY = 0;
					isMoving = false;
				}
			}
			
			if (xSpeed == 0) moveSpeedX = 0;
			if (ySpeed == 0) moveSpeedY = 0;
			
			if ((moveSpeedX == 0) && (moveSpeedY == 0)) {
				isMoving = false;
			}
		}
		
		public function RequestBasicAttack():void {
			//Gets handed down to the child classes.
		}
		
		public function DrawDebugRect(gfx:Graphics):void {
			if (MyRect == null) return;
			gfx.drawRect(MyRect.X, MyRect.Y, MyRect.W, MyRect.H);
		}
		
		public function GetUnion():Rect {
			return MyRect;
		}
		
		public function HasPerfectCollision(other:Rect):Boolean {
			return MyRect.intersects(other);
		}
		
		public function Died():void {
			if (MyScript != null) {
				MyScript.Run(Script.Died);
			}
			
			if (Owner != null) {
				Owner.AlertMinionDeath(this);
			}
			
			if (this == WorldData.ME) {
				Main.I.Renderer.FadeToBlack(null, GlobalVariables.Strings[0]);
			}
		}
		
		public function CleanUp():void {
			if (Persistent) return;
			
			if (CurrentMap != null) CurrentMap.CritterPop(this);
			MyRect = null;
			
			if(MyScript != null) {
				MyScript.CleanUp();
				MyScript = null;
			}
			
			Clock.I.Remove(this);
		}
		
		/* INTERFACE Game.Scripting.IScriptTarget */
		
		public function AlertMinionDeath(minion:BaseCritter):void {
			if (CurrentHP > 0) {
				MyScript.Run(Script.MinionDied);
			}
		}
		
		public function ChangeState(stateID:int, isLooping:Boolean):void { /* Possibly needs to be handed on to children. */ }
		public function UpdatePlaybackSpeed(newAnimationSpeed:Number):void { /* Definately needs to be handed down to children. */ }
		public function GetCurrentState():int { /* Needs to be handed down */ return 0; }
		
		public function ScriptAttack(isPercent:Boolean, isDOT:Boolean, amount:int, attacker:IScriptTarget):void {
			if(MyScript != null) {
				MyScript.Run(Script.Attacked);
			}
			
			//TODO: This should do something else :)
			if (isDOT && isPercent) {
				
			} else if (isPercent) {
				CurrentHP -= CurrentHP * (amount / 100);
			} else if (isDOT) {
				
			} else {
				//Flat damage
				CurrentHP -= amount;
			}
			
			if (CurrentHP < 1) {
				Died();
				Clock.CleanUpList.push(this);
			}
		}
		
		public function UpdatePointX(position:PointX):void {
			position.X = X;
			position.Y = Y;
			position.D = direction;
		}
		
		/* INTERFACE Game.Scripting.IScriptTarget */
		
		public function GetFaction():int {
			return PrimaryFaction;
		}
		
	}
}