package Game.Map.Tiles {
	import adobe.utils.CustomActions;
	import CollisionSystem.Rect;
	import flash.geom.Rectangle;
	import flash.utils.ByteArray;
	import Game.General.BinaryLoader;
	import RenderSystem.IAnimated;
	import RenderSystem.Renderman;
	/**
	 * ...
	 * @author Paul
	 */
	public class TileTemplate implements IAnimated {
		public var Frame:Rectangle = new Rectangle(0, 0, 48, 48);
		
		public var TotalFrames:int = 0;
		public var StartingFrame:int = 0;
		public var PlaybackSpeed:Number = 0;
		
		public var movementCost:Number = 0;
		public var SlideDirection:int = SLIDING_NONE;
		
		public var DamageElement:int = 0;
		public var DamagePerSecond:int = 0;
		
		public var Collisions:Vector.<Rect>;
		
		private var timeout:Number = 0;
		private var currentFrame:int = 0;
		
		public function TileTemplate() {
			
		}
		
		public function UpdateAnimation(dt:Number):void {
			timeout += dt;
			if (timeout > PlaybackSpeed) {
				timeout -= PlaybackSpeed;
				currentFrame++;
				if (currentFrame == StartingFrame+TotalFrames) currentFrame = StartingFrame;
				
				Frame.x = currentFrame % 21 * 48;
				Frame.y = int(currentFrame / 21) * 48;
			}
		}
		
		//The Static Things (Including Loading)
		public static var Tiles:Vector.<TileTemplate>;
		public static var TotalTiles:int;
		
		public static function LoadTileInfo():void {
			BinaryLoader.Load("Data/TileInfo.bin", LoadedTiles);
			Global.LoadingTotal++;
		}
		
		private static function LoadedTiles(e:ByteArray):void {
			TotalTiles = e.readShort();
			Tiles = new Vector.<TileTemplate>(TotalTiles, true);
			
			var runningTileCount:int = 0;
			
			for (var i:int = 0; i < TotalTiles; i++) {
				var tt:TileTemplate = new TileTemplate();
				
				tt.TotalFrames = e.readByte();
				tt.movementCost = e.readFloat();
				
				tt.SlideDirection = e.readByte();
				tt.PlaybackSpeed = e.readFloat();
				
				tt.DamageElement = e.readShort();
				tt.DamagePerSecond = e.readShort();
				
				var __t:int = e.readByte();
				tt.Collisions = new Vector.<Rect>(__t, true);
				
				while (--__t > -1) {
					tt.Collisions[__t] = new Rect(true, null, e.readShort(), e.readShort(), e.readShort(), e.readShort());
				}
				
				var j:int = tt.TotalFrames;
				tt.Frame.x = runningTileCount % 21 * 48;
				tt.Frame.y = int(runningTileCount / 21) * 48;
				
				tt.StartingFrame = runningTileCount;
				tt.currentFrame = tt.StartingFrame;
				
				if (tt.TotalFrames > 1) {
					Renderman.AnimatedObjectsPush(tt);
				}
				
				Tiles[i] = tt;
				runningTileCount += tt.TotalFrames;
			}
			
			Global.LoadingTotal--;
		}
		
		//The constants
        public static const SLIDING_NONE:int = 0;
        public static const SLIDING_LEFT:int = 1;
        public static const SLIDING_RIGHT:int = 2;
        public static const SLIDING_TOP:int = 3;
        public static const SLIDING_BOTTOM:int = 4;
        public static const SLIDING_DIRECTIONOFTRAVEL:int = 5;
	}

}