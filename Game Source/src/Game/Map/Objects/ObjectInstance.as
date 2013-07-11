package Game.Map.Objects {
	import CollisionSystem.Rect;
	import EngineTiming.ICleanUp;
	import flash.display.Bitmap;
	import Game.Scripting.Script;
	import Interfaces.IMapObject;
	import RenderSystem.IObjectLayer;
	import Game.Map.MapData;
	import Game.Map.Tiles.TileInstance;
	import Game.Map.Tiles.TileHelper;
	/**
	 * ...
	 * @author Paul
	 */
	public class ObjectInstance extends Bitmap implements IObjectLayer, IMapObject, ICleanUp {
		public var ID:int = -1;
		public var Template:ObjectTemplate;
		public var Map:MapData;
		
		protected var FullBase:Rect
		
		public function ObjectInstance() {
			Main.OrderedLayer.addChild(this);
			FullBase = new Rect(true, this);
		}
		
		public function SetInformation(map:MapData, id:int, _x:int, _y:int):void {
			Map = map;
			ID = id;
			Template = ObjectTemplate.Objects[ID];
			
			this.bitmapData = Template.GetBitmap();
			
			this.x = _x;
			this.y = _y;
			
			AttachToTiles();
			
			Template.MyScript.Run(Script.Spawn, this);
		}
		
		public function AttachToTiles():void {
			if (ID == -1) return;
			
			var totalRects:int = Template.Bases.length;
			var tiles:Vector.<TileInstance>;
			var i:int = 0;
			
			FullBase.X = this.x;
			FullBase.Y = this.y;
			FullBase.W = 0;
			FullBase.H = 0;
			
			if (Template.isSolid) {
				while (--totalRects > -1) {
					var rect:Rect = new Rect(true, this, this.x + Template.Bases[totalRects].x, this.y + Template.Bases[totalRects].y, Template.Bases[totalRects].width, Template.Bases[totalRects].height);
					
					tiles = TileHelper.GetTiles(rect, Map);
					i = tiles.length;
					
					while (--i > -1) {
						tiles[i].SolidRectangles.push(rect);
					}
				}
			}
		}
		
		public function DetachFromTiles():void {
			if (ID == -1) return;
			
			var totalRects:int = Template.Bases.length;
			var tiles:Vector.<TileInstance>;
			var i:int = 0;
			var j:int = 0;
			
			FullBase.X = this.x;
			FullBase.Y = this.y;
			FullBase.W = 0;
			FullBase.H = 0;
			
			if (Template.isSolid) {
				while (--totalRects > -1) {
					var rect:Rect = new Rect(true, this, this.x + Template.Bases[totalRects].x, this.y + Template.Bases[totalRects].y, Template.Bases[totalRects].width, Template.Bases[totalRects].height);
					
					tiles = TileHelper.GetTiles(rect, Map);
					i = tiles.length;
					
					while (--i > -1) {
						j = tiles[i].SolidRectangles.length;
						while (--j > -1) {
							if (tiles[i].SolidRectangles[j].Owner == this) {
								tiles[i].SolidRectangles.splice(j, 1);
							}
						}
					}
				}
			}
		}
		
		public function GetTrueY():int {
			return this.y + Template.OffsetHeight;
		}
		
		public function GetUnion():Rect {
			return FullBase;
		}
		
		public function HasPerfectCollision(other:Rect):Boolean {
			var totalRects:int = Template.Bases.length;
			
			while (--totalRects > -1) {
				var rect:Rect = new Rect(true, null, this.x + Template.Bases[totalRects].x, this.y + Template.Bases[totalRects].y, Template.Bases[totalRects].width, Template.Bases[totalRects].height);
				if (rect.intersects(other)) {
					return true;
				}
			}
			
			return false;
		}
		
		public override function toString():String {
			if (Template == null) {
				return "[OBJ=NULL]";
			}
			return "[OBJ=" + Template.ObjectID + "]";
		}
		
		public function ScriptAttack(isPercent:Boolean, isDOT:Boolean, amount:int, attacker:IMapObject):void {
			Template.MyScript.Run(Script.Attacked, this, attacker);
		}
		
		public function CleanUp():void {
			if (!Map.Dying) {
				Map.RemoveObject(this);
			} else {
				if (parent != null) {
					this.parent.removeChild(this);
				}
				
				Template.OneLessInstance();
				
				Template = null;
				Map = null;
				FullBase = null;
			}
		}
		
	}

}