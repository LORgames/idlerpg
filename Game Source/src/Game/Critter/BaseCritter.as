package Game.Critter {
	import flash.display.Bitmap;
	import flash.display.BitmapData;
	import flash.geom.Rectangle;
	import Game.General.Script;
	import Game.Map.MapData;
	import Game.Map.Portal;
	import Game.Map.TileHelper;
	import Game.Map.TileInstance;
	import Game.Map.TileTemplate;
	import Game.Map.WorldData;
	import Interfaces.IObjectLayer;
	import Interfaces.IUpdatable;
	/**
	 * ...
	 * @author Paul
	 */
	public class BaseCritter implements IUpdatable {
		public var direction:int = 3;
		public var state:int = 0;
		
		//Current state information
		public var isMoving:Boolean = false;
		public var moveSpeedX:int = 0;
		public var moveSpeedY:int = 0;
		public var MovementSpeed:int = 150;
		public var CurrentMovementCost:Number = 1;
		
		public var CurrentMap:MapData;
		
		public var X:int = 0;
		public var Y:int = 0;
		public var MyRect:Rect = new Rect(0, 0, 0, 0);
		
		public var MyScript:Script;
		
		public function BaseCritter() {
			
		}
		
		public function ShiftMaps(newMap:MapData, location:int = 0):void {
			CurrentMap = newMap;
			
			this.X = (location % newMap.TileSizeX) * 48;
			this.Y = (location / newMap.TileSizeX) * 48;
		}
		
		public function RequestTeleport(newMap:MapData, portal:Portal):void {
			CurrentMap = newMap;
			
			this.X = portal.ExitPoint.x;
			this.Y = portal.ExitPoint.y;
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
			
			//Store these in case
			var prevX:int = X;
			var prevY:int = Y;
			
			//Process the things
			X += moveSpeedX * dt / CurrentMovementCost;
			Y += moveSpeedY * dt / CurrentMovementCost;
			CurrentMovementCost = 1; //reset to 1 and then update the other things when possible
			
			MyRect.x = X - MyRect.width / 2;
			MyRect.y = Y - MyRect.height / 2;
			
			//Now do a quick tile check to see if we hit anything
			var tiles:Vector.<TileInstance> = TileHelper.GetTiles(MyRect, CurrentMap);
			var i:int = tiles.length;
			var collision:Boolean = false;
			
			//Check if the critter tried to leave the map boundaries
			if (MyRect.x < 0 || MyRect.y < 0 || MyRect.x + MyRect.height > CurrentMap.SizeX || MyRect.y + MyRect.width > CurrentMap.SizeY) {
				collision = true;
			}
			
			//They didn't leave the map? Lets try solid objects
			if(!collision) {
				while (--i > -1) {
					var j:int;
					
					//Look for collision in the tile.
					var rs:Vector.<Rect> = tiles[i].SolidRectangles;
					j = rs.length;
					
					while (--j > -1) {
						if (rs[j].intersects(MyRect)) {
							collision = true;
							break;
						}
					}
					
					if (collision) break;
					
					//No collision so lets update the movement speed
					if (TileTemplate.Tiles[tiles[i].TileID].movementCost > CurrentMovementCost) {
						CurrentMovementCost = TileTemplate.Tiles[tiles[i].TileID].movementCost;
					}
				}
			}
			
			if (collision) {
				//Undo the changes
				X = prevX;
				Y = prevY;
				
				MyRect.x = X - MyRect.width / 2;
				MyRect.y = Y - MyRect.height / 2;
			}
		}
		
		public function RequestMove(xSpeed:Number, ySpeed:Number):void {
			if(xSpeed != 0 || ySpeed != 0) {
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
		
	}

}