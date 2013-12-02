package Game.Critter {
	import adobe.utils.CustomActions;
	import CollisionSystem.PointX;
	import CollisionSystem.Rect;
	import Debug.Drawer;
	import EngineTiming.Clock;
	import EngineTiming.ICleanUp;
	import EngineTiming.IUpdatable;
	import flash.display.Graphics;
	import flash.geom.Point;
	import flash.text.TextField;
	import Game.Map.MapData;
	import Game.Map.Portals.Portal;
	import Game.Map.ScriptRegion;
	import Game.Map.Spawns.SpawnRegion;
	import Game.Map.Tiles.TileHelper;
	import Game.Map.Tiles.TileInstance;
	import Game.Map.Tiles.TileTemplate;
	import Game.Map.WorldData;
	import Scripting.GlobalVariables;
	import Scripting.IScriptTarget;
	import Scripting.Script;
	import Scripting.ScriptInstance;
	import Scripting.ScriptTypes;
	import Interfaces.IMapObject;
	import RenderSystem.Camera;
	/**
	 * ...
	 * @author Paul
	 */
	public class BaseCritter implements IUpdatable, IMapObject, ICleanUp, IScriptTarget {
		public var state:int = 0;
		protected var ControlsLocked:Boolean = false;
		
		public var Persistent:Boolean = false;
		
		private var ReportedDeath:Boolean = false;
		public var Owner:IScriptTarget;
		
		public var tf:TextField;
		
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
		
		public var X:Number = 0; public var Y:Number = 0;
		public var prevX:Number = 0; public var prevY:Number = 0;
		public var direction:int = 3;
		
		public var MyRect:Rect;
		
		public var MyScript:ScriptInstance;
		private var ActiveScriptRegions:Vector.<ScriptRegion> = new Vector.<ScriptRegion>();
		public var ActiveBuffs:Vector.<CritterBuff> = new Vector.<CritterBuff>();
		
		//Critter information
		public var MyAIType:int;
		
		public var CurrentHP:int = 1000;
		public var MaximumHP:int = 1000;
		public var CurrentDefence:int = 0;
		
		public function BaseCritter() {
			MyRect = new Rect(false, this, 0, 0, 0, 0);
			Clock.I.Updatables.push(this);
			tf = Drawer.GetTextField();
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
			prevX = X; prevY = Y;
			
			CONFIG::debug {
				tf.text = CurrentHP + " / " + MaximumHP;
				tf.x = (X + Camera.X) * Camera.Z - tf.width/2;
				tf.y = (Y + Camera.Y) * Camera.Z - 60;
			}
			
			//Process the things
			X += moveSpeedX * dt / CurrentMovementCost;
			Y += moveSpeedY * dt / CurrentMovementCost;
			CurrentMovementCost = 1; //reset to 1 and then update the other things when possible
			
			MyRect.X = X - MyRect.W / 2;
			MyRect.Y = Y - MyRect.H / 2;
			
			CheckCollisions();
			CheckScriptRegions();
		}
		
		public function PostUpdate():void {
			if (CurrentHP < 1) {
				Died();
			} else if (CurrentHP > MaximumHP) {
				CurrentHP = MaximumHP;
			}
		}
		
		private function ProcessAI(dt:Number = 0):void {
			var procTarget:Boolean = false;
			var _OldTarget:IScriptTarget = CurrentTarget;
			
			if (dt > 0) {
				//Check to see if the current target is still an enemy
				if (CurrentTarget != null) {
					if ((MyAIType & AITypes.Supportive) == 0 && !Factions.IsEnemies(PrimaryFaction, CurrentTarget.GetFaction())) {
						CurrentTarget = null;
					} else if ((MyAIType & AITypes.Supportive) > 0 && !Factions.IsFriends(PrimaryFaction, CurrentTarget.GetFaction())) {
						CurrentTarget = null;
					}
				}
				
				//AI AGENTS
				if (CurrentTarget == null || ((MyAIType & AITypes.Aggressive) > 0 && ((MyAIType & AITypes.ClosestTarget) > 0 || (MyAIType & AITypes.TargetLowestHealth) > 0))) {
					//Scan for a new target
					var r:Rect = new Rect(false, null, X - AlertRangeSqrt, Y - AlertRangeSqrt * Global.PerspectiveSkew, AlertRangeSqrt * 2, AlertRangeSqrt * 2 * Global.PerspectiveSkew);
					
					if ((MyAIType & AITypes.BlindBehind) > 0) {
						if (direction < 2) { //Left or right
							r.W /= 2;
							if (direction == 1) r.X += r.W; //Shift the area Right
						} else { // Up or Down
							r.H /= 2;
							if (direction == 3) r.Y += r.H; //Shift the area Down
						}
					}
					
					// Draw the targetting area
					Drawer.AddDebugRect(r, Factions.GetFactionColour(PrimaryFaction));
					
					
					var objs:Vector.<IScriptTarget> = new Vector.<IScriptTarget>();
					CurrentMap.GetObjectsInArea(r, objs, ((MyAIType & AITypes.Supportive) > 0)?ScriptTypes.Ally:ScriptTypes.Enemy, this);
					
					var best_target_index:int = 0;
					var this_target_index:int = 0;
					
					var i:int = objs.length;
					
					while (--i > -1) {
						if ((MyAIType & AITypes.Supportive) > 0) {
							if (objs[i] == this) continue;
						}
						
						if (objs[i] is BaseCritter) {
							var x:BaseCritter = (objs[i] as BaseCritter);
							
							//If I'm a support unit and the unit is unsupportable, continue looking for something else
							if ((MyAIType & AITypes.Supportive) > 0 && (x.MyAIType & AITypes.Unsupportable) > 0) { continue; }
							
							if ((MyAIType & AITypes.ClosestTarget) > 0) {
								this_target_index = (x.X - X) * (x.X - X) + (x.Y - Y) * (x.Y - Y);
								
								if (this_target_index < best_target_index || CurrentTarget == null) {
									CurrentTarget = x;
									best_target_index = this_target_index;
								}
							} else if ((MyAIType & AITypes.TargetLowestHealth) > 0) {
								this_target_index = x.CurrentHP - x.MaximumHP;
								
								if (this_target_index >= 0) continue;
								
								if (this_target_index < best_target_index || CurrentTarget == null) {
									CurrentTarget = x;
									best_target_index = this_target_index;
								}
							} else {
								CurrentTarget = x;
								break;
							}
						}
					}
				}
				
				if (CurrentTarget != null) {
					if (CurrentTarget is BaseCritter) {
						if ((CurrentTarget as BaseCritter).CurrentHP <= 0 || (CurrentTarget as BaseCritter).MyRect == null) {
							CurrentTarget = null;
							RequestMove(0, 0);
							MyScript.Run(Script.AIEvent, null, Script.AIEvent_TargetDied);
							return;
						}
						
						if (((CurrentTarget as BaseCritter).MyAIType & AITypes.Untargetable) > 0) {
							CurrentTarget = null;
							RequestMove(0, 0);
							MyScript.Run(Script.AIEvent, null, Script.AIEvent_TargetUntargetable);
							return;
						}
					}
					
					var p:PointX = new PointX();;
					CurrentTarget.UpdatePointX(p);
					
					if (CurrentTarget is BaseCritter) {
						p = MathsEx.ClosestPointToAABB(this.X, this.Y, (CurrentTarget as BaseCritter).MyRect);
					}
					
					var dx:Number = (this.X - p.X);
					var dy:Number = (this.Y - p.Y) / Global.PerspectiveSkew;
					
					Drawer.AddLine(X, Y, p.X, p.Y, Factions.GetFactionColour(PrimaryFaction));
					
					var AttackRangeSqrt:int = Math.sqrt(AttackRange) + 1;
					
					var rAtk:Rect = new Rect(false, null, X - AttackRangeSqrt, Y - AttackRangeSqrt*Global.PerspectiveSkew, AttackRangeSqrt * 2, AttackRangeSqrt * 2*Global.PerspectiveSkew);
					Drawer.AddDebugRect(rAtk, Factions.GetFactionColour(PrimaryFaction));
					
					if ((CurrentTarget is IMapObject) && (CurrentTarget as IMapObject).HasPerfectCollision(rAtk)) {
						RequestBasicAttack();
						procTarget = true;
					} else if (dx * dx + dy * dy > AlertRange) {
						procTarget = false;
						CurrentTarget = null;
						MyScript.Run(Script.AIEvent, null, Script.AIEvent_TargetOutOfRange);
					} else {
						RequestMove(-dx, -dy);
						procTarget = true;
					}
				}
				
				if(CurrentTarget != _OldTarget) MyScript.Run(Script.AIEvent, null, Script.AIEvent_TargetChanged);
			}
		}
		
		private function CheckCollisions():void {
			//Now do a quick tile check to see if we hit anything
			var tiles:Vector.<TileInstance> = TileHelper.GetTiles(MyRect, CurrentMap);
			var i:int = tiles.length; var j:int;
			
			//Collision measures how far into something else we've penetrated
			var collisionPenetration:Point = new Point();
			var collisionTotal:int = 0;
			
			//Make sure this object can actually move... then do collision detection magic.
			if(MovementSpeed > 0) {
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
							if (critter == null) continue;
							
							if (critter != this) {
								if (critter.MyRect == null) continue;
								if ((MyAIType & AITypes.Untargetable) > 1 && (critter.MyAIType & AITypes.Untargetable) > 1) continue;
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
			
			if (Owner != null && !ReportedDeath) {
				ReportedDeath = true;
				Owner.AlertMinionDeath(this);
			}
		}
		
		public function CleanUp():void {
			if (Persistent) return;
			
			if (Owner != null && !ReportedDeath) {
				ReportedDeath = true;
				Owner.AlertMinionDeath(this);
			}
			
			if (CurrentMap != null) CurrentMap.CritterPop(this);
			MyRect = null;
			
			if(MyScript != null) {
				MyScript.CleanUp();
				MyScript = null;
			}
			
			tf.text = "";
			tf.parent.removeChild(tf);
			tf = null;
			
			for (var i:int = 0 ; i < ActiveBuffs.length; i++) {
				ActiveBuffs[i].CleanUp(false);
			}
			ActiveBuffs.length = 0;
			ActiveBuffs = null;
			
			Clock.I.Remove(this);
		}
		
		/* INTERFACE Scripting.IScriptTarget */
		
		public function AlertMinionDeath(minion:BaseCritter):void {
			if (CurrentHP > 0) {
				MyScript.Run(Script.MinionDied);
			}
		}
		
		public function ChangeState(stateID:int, isLooping:Boolean):void { /* Possibly needs to be handed on to children. */ }
		public function UpdatePlaybackSpeed(newAnimationSpeed:Number):void { /* Definately needs to be handed down to children. */ }
		public function GetCurrentState():int { /* Needs to be handed down */ return 0; }
		
		public function ScriptAttack(isPercent:Boolean, amount:int, pierce:int, attacker:IScriptTarget):void {
			if (MyScript != null) {
				if(amount > 0) MyScript.Run(Script.Attacked, null, [attacker, amount]);
				
				if (CurrentTarget != attacker) {
					MyScript.Run(Script.AIEvent, null, Script.AIEvent_AttackedByNonTarget);
				}
			}
			
			//TODO: This should do something else :)
			if (isPercent) {
				CurrentHP -= CurrentHP * (amount / 100);
			} else if(amount < 0) { //HEAL!
				//Flat damage
				CurrentHP -= amount;
			} else { //ATTACK
				var preCalc:int = amount - CurrentDefence;
				if (preCalc < 0) preCalc = 1;
				preCalc += pierce;
				
				//Flat damage
				CurrentHP -= preCalc;
			}
		}
		
		public function UpdatePointX(position:PointX):void {
			position.X = X;
			position.Y = Y;
			position.D = direction;
		}
		
		/* INTERFACE Scripting.IScriptTarget */
		
		public function GetFaction():int {
			return PrimaryFaction;
		}
		
		public function HasFaction(factionID:int):Boolean {
			if (factionID == PrimaryFaction) return true;
			
			return false;
		}
		
		public function SetFaction(newFaction:int):void {
			PrimaryFaction = newFaction;
			MyScript.Run(Script.AIEvent, null, Script.AIEvent_FactionChanged);
		}
		
		public function SetOwner(newOwner:IScriptTarget):void {
			Owner = newOwner;
			MyScript.Run(Script.AIEvent, null, Script.AIEvent_OwnerChanged);
		}
		
		public function ApplyBuff(buffID:int):void {
			if (CritterManager.I.CritterBuffs[buffID].isStackable) {
				var b:CritterBuff = CritterManager.I.GetBuff();
				b.ApplyToCritter(buffID, this);
				ActiveBuffs.push(b);
			}
		}
		
		public function HasBuff(buffID:int):Boolean {
			if (ActiveBuffs.length == 0) return false;
			
			for (var i:int = 0; i < ActiveBuffs.length; i++) {
				if (ActiveBuffs[i].info.ID == buffID) {
					return true;
				}
			}
			
			return false;
		}
		
		public function RemoveBuff(buff:CritterBuff):void {
			var i:int = ActiveBuffs.indexOf(buff);
			
			if (i > -1) {
				ActiveBuffs.splice(i, 1);
			}
		}
		
		public function RemoveBuffByID(buffID:int):void {
			for (var i:int = ActiveBuffs.length; i > -1; --i) {
				if (ActiveBuffs[i].info.ID == buffID) {
					ActiveBuffs.splice(i, 1);
				}
			}
		}
	}
}