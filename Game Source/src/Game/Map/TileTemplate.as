package Game.Map {
	import adobe.utils.CustomActions;
	import flash.geom.Rectangle;
	import flash.utils.ByteArray;
	import Game.General.BinaryLoader;
	import RenderSystem.AnimatedCache;
	import RenderSystem.Renderman;
	/**
	 * ...
	 * @author Paul
	 */
	public class TileTemplate implements AnimatedCache {
		public var Frame:Rectangle = new Rectangle(0, 0, 48, 48);
		public var TotalFrames:int = 0;
		public var StartingFrame:int = 0;
		
		public var isWalkable:Boolean = false;
		public var movementCost:Number = 0;
		
		public var DirectionalAccess:int = ACCESS_ALL;
		public var SlideDirection:int = SLIDING_NONE;
		
		public var DamageElement:int = 0;
		public var DamagePerSecond:int = 0;
		
		private var timeout:Number = 0;
		private var currentFrame:int = 0;
		
		public function UpdateAnimation(dt:Number):void {
			timeout += dt;
			if (timeout > 0.1) {
				timeout -= dt;
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
				tt.isWalkable = e.readByte() == 1;
				tt.movementCost = e.readFloat();
				
				tt.DirectionalAccess = e.readByte();
				tt.SlideDirection = e.readByte();
				
				tt.DamageElement = e.readShort();
				tt.DamagePerSecond = e.readShort();
				
				var j:int = tt.TotalFrames;
				tt.Frame.x = runningTileCount % 21 * 48;
				tt.Frame.y = int(runningTileCount / 21) * 48;
				
				tt.StartingFrame = runningTileCount;
				
				if (tt.TotalFrames > 1) Renderman.AnimatedObjects.push(tt);
				
				Tiles[i] = tt;
				runningTileCount += tt.TotalFrames;
			}
			
			Global.LoadingTotal--;
		}
		
		//The constants
		public static const ACCESS_LEFT:int = 1;
        public static const ACCESS_RIGHT:int = 2;
        public static const ACCESS_TOP:int = 4;
        public static const ACCESS_BOTTOM:int = 8;
        public static const ACCESS_ALL:int = ACCESS_LEFT | ACCESS_RIGHT | ACCESS_TOP | ACCESS_BOTTOM;
        public static const ACCESS_NONE:int = 0;
		
        public static const SLIDING_NONE:int = 0;
        public static const SLIDING_LEFT:int = 1;
        public static const SLIDING_RIGHT:int = 2;
        public static const SLIDING_TOP:int = 3;
        public static const SLIDING_BOTTOM:int = 4;
        public static const SLIDING_DIRECTIONOFTRAVEL:int = 5;
	}

}