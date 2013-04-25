package Game.Map {
	import flash.display.Bitmap;
	import flash.geom.Rectangle;
	import Interfaces.IObjectLayer;
	/**
	 * ...
	 * @author Paul
	 */
	public class ObjectInstance extends Bitmap implements IObjectLayer {
		
		public var ID:int = -1;
		public var Template:ObjectTemplate;
		public var Map:MapData;
		
		public function ObjectInstance() {
			Main.OrderedLayer.addChild(this);
		}
		
		public function SetInformation(map:MapData, id:int, _x:int, _y:int):void {
			Map = map;
			ID = id;
			Template = ObjectTemplate.Objects[ID];
			
			this.bitmapData = Template.GetBitmap();
			
			this.x = _x;
			this.y = _y;
			
			AttachToTiles();
		}
		
		public function AttachToTiles():void {
			if (ID == -1) return;
			
			var totalRects:int = Template.Bases.length;
			var tiles:Vector.<TileInstance>;
			var i:int = 0;
			
			if (Template.isSolid) {
				while (--totalRects > -1) {
					var rect:Rect = new Rect(this.x + Template.Bases[totalRects].x, this.y + Template.Bases[totalRects].y, Template.Bases[totalRects].width, Template.Bases[totalRects].height);
					
					tiles = TileHelper.GetTiles(rect, Map);
					i = tiles.length;
					
					while (--i > -1) {
						tiles[i].SolidRectangles.push(rect);
					}
				}
			}
		}
		
		public function GetTrueY():int {
			return this.y + Template.OffsetHeight;
		}
		
	}

}