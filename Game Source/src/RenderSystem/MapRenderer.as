package RenderSystem {
	import adobe.utils.CustomActions;
	import CollisionSystem.Rect;
	import flash.display.Bitmap;
	import flash.display.BitmapData;
	import flash.display.Sprite;
	import flash.display.Stage;
	import flash.events.Event;
	import flash.geom.Point;
	import flash.geom.Rectangle;
	import flash.utils.ByteArray;
	import Game.Critter.BaseCritter;
	import Game.Map.ObjectInstance;
	import Game.Map.SpawnRegion;
	import Game.Map.TileHelper;
	import Game.Map.TileInstance;
	import Game.Map.TileTemplate;
	import Game.Map.WorldData;
	
	/**
	 * ...
	 * @author Paul
	 */
	public class MapRenderer extends Bitmap {
		
		private var data:BitmapData; // Display thing.
		public var DebugLayer:Sprite = new Sprite();
		public var fullRect:Rectangle = new Rectangle();
		
		public function MapRenderer() {
			this.addEventListener(Event.ADDED_TO_STAGE, StageAdded);
		}
		
		public function StageAdded(e:Event):void {
			this.removeEventListener(Event.ADDED_TO_STAGE, StageAdded);
			this.parent.addChild(DebugLayer);
		}
		
		public function Resized():void {
			data = new BitmapData(Main.I.stage.stageWidth, Main.I.stage.stageHeight, false);
			this.bitmapData = data;
			
			fullRect.width = data.width;
			fullRect.height = data.height;
		}
		
		public function Draw():void {
			var destPoint:Point = new Point();
			
			var xTilePosL:int = -Camera.X / 48;
			var yTilePosL:int = -Camera.Y / 48;
			var xTilePosU:int = (-Camera.X + data.width) / 48;
			var yTilePosU:int = (-Camera.Y + data.height) / 48;
			
			if (xTilePosL < 0) xTilePosL = 0;
			if (yTilePosL < 0) yTilePosL = 0;
			if (xTilePosU >= WorldData.ME.CurrentMap.TileSizeX) xTilePosU = WorldData.ME.CurrentMap.TileSizeX - 1;
			if (yTilePosU >= WorldData.ME.CurrentMap.TileSizeY) yTilePosU = WorldData.ME.CurrentMap.TileSizeY - 1;
			
			var tiles:Vector.<TileInstance> = WorldData.ME.CurrentMap.Tiles;
			var tileArt:BitmapData = WorldData.TileSheet;
			
			var xPos:int = xTilePosU+1;
			var yPos:int = 0;
			var xSize:int = WorldData.ME.CurrentMap.TileSizeX;
			
			data.lock();
			
			data.fillRect(fullRect, 0x0);
			
			while (--xPos >= xTilePosL) {
				yPos = yTilePosU+1;
				
				while (--yPos >= yTilePosL) {
					var tileType:int = tiles[xPos+yPos*xSize].TileID;
					
					destPoint.x = 48 * xPos + Camera.X;
					destPoint.y = 48 * yPos + Camera.Y;
					
					data.copyPixels(tileArt, TileTemplate.Tiles[tileType].Frame, destPoint);
				}
			}
			
			//TODO: Clean up debug draw things if required
			xPos = WorldData.ME.CurrentMap.Critters.length;
			
			DebugLayer.graphics.clear();
			
			//Draw the main character
			DebugLayer.graphics.lineStyle(1, 0xFF00FF);
			
			while (--xPos > -1) {
				WorldData.ME.CurrentMap.Critters[xPos].DrawDebugRect(DebugLayer.graphics);
			}
			
			//Draw all the objects
			DebugLayer.graphics.lineStyle(1, 0x00FFFF);
			xPos = WorldData.ME.CurrentMap.Objects.length;
			
			while (--xPos > -1) {
				var objI:ObjectInstance = WorldData.ME.CurrentMap.Objects[xPos];
				yPos = objI.Template.Bases.length;
				
				while (--yPos > -1) {
					DebugLayer.graphics.drawRect(objI.Template.Bases[yPos].left + objI.x, objI.Template.Bases[yPos].top + objI.y, objI.Template.Bases[yPos].width, objI.Template.Bases[yPos].height);
				}
			}
			
			//Draw all the Critters
			DebugLayer.graphics.lineStyle(1, 0xFF0000);
			xPos = WorldData.ME.CurrentMap.Critters.length;
			trace("Critters: " + xPos);
			
			while (--xPos > -1) {
				if(WorldData.ME.CurrentMap.Critters[xPos] != WorldData.ME) {
					var objC:Rect = WorldData.ME.CurrentMap.Critters[xPos].MyRect;
					DebugLayer.graphics.drawRect(objC.X, objC.Y, objC.W, objC.H);
				}
			}
			
			//Draw all the spawn regions
			DebugLayer.graphics.lineStyle(1, 0x0000FF);
			xPos = WorldData.ME.CurrentMap.Spawns.length;
			
			while (--xPos > -1) {
				var objX:SpawnRegion = WorldData.ME.CurrentMap.Spawns[xPos];
				yPos = objX.Area.length;
				
				while (--yPos > -1) {
					DebugLayer.graphics.drawRect(objX.Area[yPos].X, objX.Area[yPos].Y, objX.Area[yPos].W, objX.Area[yPos].H);
				}
			}
			
			data.unlock();
		}
		
	}
	
}