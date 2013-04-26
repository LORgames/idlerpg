package Game.Critter {
	import flash.display.Bitmap;
	import flash.display.BitmapData;
	import flash.geom.Rectangle;
	import Game.Map.MapData;
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
		public var direction:int = 0;
		public var state:int = 0;
		
		public var isMoving:Boolean = false;
		public var moveSpeedX:int = 0;
		public var moveSpeedY:int = 0;
		public var MovementSpeed:int = 100;
		
		public var currentMap:MapData;
		
		public var X:int = 0;
		public var Y:int = 0;
		public var MyRect:Rect = new Rect(0, 0, 0, 0);
		
		public function BaseCritter() {
			
		}
		
		public function ShiftMaps(newMap:MapData, location:int = 0):void {
			currentMap = newMap;
			
			this.X = (location % newMap.TileSizeX) * 48;
			this.Y = (location / newMap.TileSizeX) * 48;
		}
		
		public function RequestMove(xSpeed:Number, ySpeed:Number):void {
			if(xSpeed != 0 || ySpeed != 0) {
				direction = SpeedToDirection(xSpeed, ySpeed);
				
				moveSpeedX = xSpeed * MovementSpeed;
				moveSpeedY = ySpeed * MovementSpeed;
				
				isMoving = true;
			} else {
				moveSpeedX = 0;
				moveSpeedY = 0;
				
				isMoving = false;
			}
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
		
		public function RequestBasicAttack():void {
			//need to deal with a few things here, incl state management
		}
		
		public function RequestTeleport(tileID:int):void {
			
		}
		
		public function Update(dt:Number):void {
			if (currentMap == null) return;
			
			//Store these in case
			var prevX:int = X;
			var prevY:int = Y;
			
			//Process the things
			X += moveSpeedX * dt;
			Y += moveSpeedY * dt;
			
			MyRect.x = X - MyRect.width / 2;
			MyRect.y = Y - MyRect.height / 2;
			
			//Now do a quick tile check to see if we hit anything
			var tiles:Vector.<TileInstance> = TileHelper.GetTiles(MyRect, currentMap);
			var i:int = tiles.length;
			var collision:Boolean = false;
			
			if (MyRect.x < 0 || MyRect.y < 0 || MyRect.x + MyRect.height > currentMap.SizeX || MyRect.y + MyRect.width > currentMap.SizeY) {
				collision = true;
			}
			
			if(!collision) {
				while (--i > -1) {
					var rs:Vector.<Rect> = tiles[i].SolidRectangles;
					var j:int = rs.length;
					
					while (--j > -1) {
						if (rs[j].intersects(MyRect)) {
							collision = true;
							break;
						}
					}
					
					if (collision) break;
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
		
	}

}