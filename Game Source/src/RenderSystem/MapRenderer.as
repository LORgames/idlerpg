package RenderSystem {
	import CollisionSystem.Rect;
	import flash.display.Bitmap;
	import flash.display.BitmapData;
	import flash.display.Sprite;
	import flash.geom.Matrix;
	import flash.geom.Point;
	import flash.geom.Rectangle;
	import Game.Critter.Factions;
	import Game.Effects.EffectInstance;
	import Game.Map.Objects.ObjectInstance;
	import Game.Map.ScriptRegion;
	import Game.Map.Spawns.SpawnRegion;
	import Game.Map.Tiles.TileInstance;
	import Game.Map.Tiles.TileTemplate;
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
			
		}
		
		public function Resized():void {
			this.bitmapData = null;
			if(data != null) data.dispose();
			data = new BitmapData(Main.I.stage.stageWidth/Camera.Z, Main.I.stage.stageHeight/Camera.Z, false, 0x0);
			this.bitmapData = data;
			
			fullRect.width = data.width;
			fullRect.height = data.height;
			
			this.scaleX = Camera.Z;
			this.scaleY = Camera.Z;
			
			DebugLayer.scaleX = Camera.Z;
			DebugLayer.scaleY = Camera.Z;
		}
		
		public function Draw():void {
			if(Global.HasTiles) {
				var destPoint:Point = new Point();
				
				var xTilePosL:int = -Camera.X / Global.TileSize;
				var yTilePosL:int = -Camera.Y / Global.TileSize;
				var xTilePosU:int = (-Camera.X + data.width) / Global.TileSize;
				var yTilePosU:int = (-Camera.Y + data.height) / Global.TileSize;
				
				if (xTilePosL < 0) xTilePosL = 0;
				if (yTilePosL < 0) yTilePosL = 0;
				if (xTilePosU >= WorldData.CurrentMap.TileSizeX) xTilePosU = WorldData.CurrentMap.TileSizeX - 1;
				if (yTilePosU >= WorldData.CurrentMap.TileSizeY) yTilePosU = WorldData.CurrentMap.TileSizeY - 1;
				
				var tiles:Vector.<TileInstance> = WorldData.CurrentMap.Tiles;
				var tileArt:BitmapData = WorldData.TileSheet;
				
				var xPos:int = xTilePosU+1;
				var yPos:int = 0;
				var xSize:int = WorldData.CurrentMap.TileSizeX;
				
				data.lock();
				
				data.fillRect(fullRect, 0x0);
				
				while (--xPos >= xTilePosL) {
					yPos = yTilePosU+1;
					
					while (--yPos >= yTilePosL) {
						var tileType:int = tiles[xPos+yPos*xSize].TileID;
						
						destPoint.x = Global.TileSize * xPos + Camera.X;
						destPoint.y = Global.TileSize * yPos + Camera.Y;
						
						data.copyPixels(tileArt, TileTemplate.Tiles[tileType].Frame, destPoint);
					}
				}
				
				data.unlock();
			}
			
			if (Global.DebugRender) {
				xPos = WorldData.CurrentMap.Critters.length;
				
				DebugLayer.graphics.clear();
				
				//Draw the main character
				DebugLayer.graphics.lineStyle(1, 0xFF00FF);
				
				while (--xPos > -1) {
					WorldData.CurrentMap.Critters[xPos].DrawDebugRect(DebugLayer.graphics);
				}
				
				//Draw all the objects
				DebugLayer.graphics.lineStyle(1, 0x00FFFF);
				xPos = WorldData.CurrentMap.Objects.length;
				
				while (--xPos > -1) {
					var objI:ObjectInstance = WorldData.CurrentMap.Objects[xPos];
					yPos = objI.Template.Bases.length;
					
					while (--yPos > -1) {
						DebugLayer.graphics.drawRect(objI.Template.Bases[yPos].left + objI.x, objI.Template.Bases[yPos].top + objI.y, objI.Template.Bases[yPos].width, objI.Template.Bases[yPos].height);
					}
				}
				
				//Draw all the Critters
				DebugLayer.graphics.lineStyle(1, 0xFF0000);
				xPos = WorldData.CurrentMap.Critters.length;
				
				while (--xPos > -1) {
					if(WorldData.CurrentMap.Critters[xPos] != WorldData.ME) {
						var objC:Rect = WorldData.CurrentMap.Critters[xPos].MyRect;
						if (objC == null) continue;
						
						DebugLayer.graphics.lineStyle(1, Factions.GetFactionColour(WorldData.CurrentMap.Critters[xPos].GetFaction()));
						DebugLayer.graphics.drawRect(objC.X, objC.Y, objC.W, objC.H);
					}
				}
				
				//Draw all the spawn regions
				DebugLayer.graphics.lineStyle(1, 0x0000FF);
				xPos = WorldData.CurrentMap.Spawns.length;
				
				while (--xPos > -1) {
					var objX:SpawnRegion = WorldData.CurrentMap.Spawns[xPos];
					yPos = objX.Area.length;
					
					while (--yPos > -1) {
						DebugLayer.graphics.drawRect(objX.Area[yPos].X, objX.Area[yPos].Y, objX.Area[yPos].W, objX.Area[yPos].H);
					}
				}
				
				//Draw all the script regions
				DebugLayer.graphics.lineStyle(1, 0xFF00FF);
				xPos = WorldData.CurrentMap.ScriptRegions.length;
				
				while (--xPos > -1) {
					var objT:ScriptRegion = WorldData.CurrentMap.ScriptRegions[xPos];
					yPos = objT.Area.length;
					
					while (--yPos > -1) {
						DebugLayer.graphics.drawRect(objT.Area[yPos].X, objT.Area[yPos].Y, objT.Area[yPos].W, objT.Area[yPos].H);
					}
				}
				
				//Draw all the effects
				DebugLayer.graphics.lineStyle(1, 0x8080FF);
				xPos = WorldData.CurrentMap.Effects.length;
				
				while (--xPos > -1) {
					var objE:EffectInstance = WorldData.CurrentMap.Effects[xPos];
					DebugLayer.graphics.drawRect(objE.MyRect.X, objE.MyRect.Y, objE.MyRect.W, objE.MyRect.H);
				}
			}
		}
	}
	
}