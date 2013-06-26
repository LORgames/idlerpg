package Game.Critter {
	import CollisionSystem.Rect;
	import Debug.Drawer;
	import EngineTiming.Clock;
	import flash.display.Bitmap;
	import flash.display.BitmapData;
	import flash.display.Graphics;
	import flash.geom.Point;
	import flash.geom.Rectangle;
	import Game.General.Script;
	import Game.Map.MapData;
	import Game.Map.Portal;
	import Game.Map.TileHelper;
	import Game.Map.TileInstance;
	import Game.Map.TileTemplate;
	import Game.Map.WorldData;
	import InputSystems.IInputSystem;
	import RenderSystem.IObjectLayer;
	import EngineTiming.IUpdatable;
	import Interfaces.IMapObject;
	import EngineTiming.ICleanUp;
	import RenderSystem.Renderman;
	/**
	 * ...
	 * @author Paul
	 */
	public class BaseCritter implements IUpdatable, IMapObject, ICleanUp, ICritterOwner {
		public var direction:int = 3;
		public var state:int = 0;
		protected var ControlsLocked:Boolean = false;
		
		public var Persistent:Boolean = false;
		public var Owner:ICritterOwner;
		
		//Current state information
		public var isMoving:Boolean = false;
		public var moveSpeedX:int = 0;
		public var moveSpeedY:int = 0;
		public var MovementSpeed:int = 150;
		public var CurrentMovementCost:Number = 1;
		
		public var CurrentMap:MapData;
		
		public var X:int = 0;
		public var Y:int = 0;
		public var MyRect:Rect;
		
		public var MyScript:Script;
		
		//Critter information
		public var MyAIType:int;
		public var CurrentHP:int = 0;
		
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
			
			this.X = portal.ExitPoint.x;
			this.Y = portal.ExitPoint.y;
			
			Update(0);
			Global.DisablePortals = false;
		}
		
		public function RequestInMapTeleport():void {
			RequestTeleport(CurrentMap, CurrentMap.Portals[Global.MapPortalID]);
			Main.I.Renderer.FadeToWorld();
		}
		
		protected function SpeedToDirection(xSpeed:int, ySpeed:int):int {
			var mx:int = xSpeed < 0 ? -xSpeed : xSpeed;
			var my:int = ySpeed < 0 ? -ySpeed : ySpeed;
			
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
				
				var range:int = dx * dx + dy * dy;
				var effectiveRange:int = range;
				
				if ((MyAIType & AITypes.Hunting) > 0) {
					effectiveRange /= 25; //5x effective range for hunting type monsters
				}
				
				if (effectiveRange < 100000) {
					if (range < 2500) {
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
						trace("WONDAR");
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
							
							//if (collisionPenetration.x != 0 && collisionPenetration.y != 0)
							//	trace(collisionPenetration + ", " + MyRect + ", " + rs[j]);
							
							break;
						}
					}
					
					if (collisionPenetration.x != 0 && collisionPenetration.y != 0) break;
					
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
								
								if (collisionPenetration.x != 0 && collisionPenetration.y != 0) break;
							}
						}
					}
				}
				
				if (collisionPenetration.x != 0 && collisionPenetration.y != 0) {
					//Undo the changes
					if(Math.abs(collisionPenetration.x) < Math.abs(collisionPenetration.y)) {
						X += collisionPenetration.x;
					} else {
						Y += collisionPenetration.y;
					}
					
					MyRect.X = X - MyRect.W / 2;
					MyRect.Y = Y - MyRect.H / 2;
				}
			}
		}
		
		public function RequestMove(xSpeed:Number, ySpeed:Number):void {
			if (xSpeed != 0 || ySpeed != 0) {
				direction = SpeedToDirection(xSpeed, ySpeed);
				
				// normalise speed vector
				xSpeed = xSpeed / Math.sqrt(Math.pow(xSpeed, 2) + Math.pow(ySpeed, 2));
				ySpeed = ySpeed / Math.sqrt(Math.pow(xSpeed, 2) + Math.pow(ySpeed, 2));
				
				moveSpeedX = xSpeed * MovementSpeed;
				
				if(ySpeed < 0) moveSpeedY = ySpeed * MovementSpeed * 0.707;
				if(ySpeed > 0) moveSpeedY = ySpeed * MovementSpeed * 0.900;
				
				isMoving = true;
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
		
		public function ScriptAttack(isPercent:Boolean, isDOT:Boolean, amount:int, attacker:IMapObject):void {
			//TODO: This should do something :)
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
		
		public function Died():void {
			if (Owner != null) {
				Owner.AlertMinionDeath(this);
			}
		}
		
		public function CleanUp():void {
			if (Persistent) return;
			
			if(CurrentMap != null) CurrentMap.CritterPop(this);
			MyRect = null;
			MyScript = null;
			
			Clock.I.Remove(this);
		}
		
		public function AlertMinionDeath(minion:BaseCritter):void {
			MyScript.Run(Script.MinionDied, this, minion);
		}
	}
}