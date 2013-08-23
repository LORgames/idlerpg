package Game.Critter {
	import CollisionSystem.PointX;
	import CollisionSystem.Rect;
	import EngineTiming.Clock;
	import EngineTiming.ICleanUp;
	import EngineTiming.IUpdatable;
	import flash.display.Graphics;
	import flash.geom.Point;
	import Game.Map.MapData;
	import Game.Map.Portals.Portal;
	import Game.Map.Tiles.TileHelper;
	import Game.Map.Tiles.TileInstance;
	import Game.Map.Tiles.TileTemplate;
	import Game.Map.WorldData;
	import Game.Scripting.IScriptTarget;
	import Game.Scripting.Script;
	import Game.Scripting.ScriptInstance;
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
		
		public var teamID:int = 0;
		
		public var MovementSpeed:int = 125;
		public var AlertRange:int = 20000;
		
		public var CurrentMovementCost:Number = 1;
		
		public var CurrentMap:MapData;
		
		public var X:int = 0;
		public var Y:int = 0;
		public var direction:int = 3;
		
		public var MyRect:Rect;
		
		public var MyScript:ScriptInstance;
		
		//Critter information
		public var MyAIType:int;
		public var CurrentHP:int = 1000;
		
		public function BaseCritter() {
			MyRect = new Rect(false, this, 0, 0, 0, 0);
			Clock.I.Updatables.push(this);
		}
		
		public function ShiftMaps(newMap:MapData, location:int = 0):void {
			if (CurrentMap != null) {
				CurrentMap.CritterPop(this);
			}
			
			newMap.CritterPush(this);
			
			this.X = (location % newMap.TileSizeX) * 48;
			this.Y = (location / newMap.TileSizeX) * 48;
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
			
			if (mx > my) {
				if (xSpeed < 0) {
					return 0;
				} else {
					return 1;
				}
			} else {
				if (ySpeed < 0) {
					return 2;
				} else {
					return 3;
				}
			}
		}
		
		public function Update(dt:Number):void {
			if (CurrentMap == null) return;
			
			//Will need these later :)
			var j:int;
			
			//// AI  AI  AI  AI ///////////////////////////////////////////////////////// AI
			
			if (WorldData.ME != this && dt > 0) {
				//AI AGENTS
				var me:BaseCritter = WorldData.ME;
				var dx:Number = (this.X - me.X);
				var dy:Number = (this.Y - me.Y) / 0.85;
				
				var effectiveRange:int = dx * dx + dy * dy;
				
				if (effectiveRange < AlertRange) { //was 100000
					if (effectiveRange < 2500) {
						RequestBasicAttack();
						RequestMove(0, 0);
					} else if ((MyAIType & AITypes.Aggressive)) {
						RequestMove( -dx, -dy);
					} else {
						//Look at the player character
						if (Math.abs(dx) > Math.abs(dy)) {
							if (dx > 0) { // Right
								direction = 0;
							} else { // Left
								direction = 1;
							}
						} else {
							if (dy > 0) { // Up
								direction = 2;
							} else { // Down
								direction = 3;
							}
						}
					}
				} else {
					if ((MyAIType & AITypes.Wonder) > 0) {
						//trace("WONDAR");
					} else {
						if (moveSpeedX != 0 || moveSpeedY != 0) {
							RequestMove(0, 0);
						}
					}
				}
			}
			
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
					if (TileTemplate.Tiles[tiles[i].TileID].movementCost > CurrentMovementCost) {
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
					
					if(ySpeed < 0) moveSpeedY = ySpeed * MovementSpeed * 0.707;
					if(ySpeed > 0) moveSpeedY = ySpeed * MovementSpeed * 0.900;
					
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
			//need to deal with a few things here, incl state management
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
				Main.I.Renderer.FadeToBlack(null, "You are died.");
			}
		}
		
		public function CleanUp():void {
			if (Persistent) return;
			
			if(CurrentMap != null) CurrentMap.CritterPop(this);
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
				
			} else if (isDOT) {
				
			} else {
				//Flat damage
				CurrentHP -= amount;
				
				if (CurrentHP < 1) {
					Died();
					Clock.CleanUpList.push(this);
				}
			}
		}
		
		public function UpdatePointX(position:PointX):void {
			position.X = X;
			position.Y = Y;
			position.D = direction;
		}
		
	}
}