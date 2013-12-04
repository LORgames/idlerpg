package Game.Map.Objects {
	import CollisionSystem.PointX;
	import CollisionSystem.Rect;
	import EngineTiming.ICleanUp;
	import flash.display.Bitmap;
	import Game.Critter.BaseCritter;
	import Game.Map.MapData;
	import Game.Map.Tiles.TileHelper;
	import Game.Map.Tiles.TileInstance;
	import Scripting.IScriptTarget;
	import Scripting.Script;
	import Scripting.ScriptInstance;
	import Interfaces.IMapObject;
	import RenderSystem.IObjectLayer;
	/**
	 * ...
	 * @author Paul
	 */
	public class ObjectInstance extends Bitmap implements IObjectLayer, IMapObject, ICleanUp, IScriptTarget {
		public var ID:int = -1;
		public var Template:ObjectTemplate;
		public var Map:MapData;
		public var MyScript:ScriptInstance;
		
		protected var FullBase:Rect;
		protected var REFID:int;
		
		public function ObjectInstance(_REFID:int) {
			Main.OrderedLayer.addChild(this);
			FullBase = new Rect(true, this);
			REFID = _REFID;
		}
		
		public function SetInformation(map:MapData, id:int, _x:int, _y:int):void {
			Map = map;
			ID = id;
			Template = ObjectTemplate.Objects[ID];
			MyScript = new ScriptInstance(Template.MyScript, this);
			
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
			
			FullBase.X = this.x;
			FullBase.Y = this.y;
			FullBase.W = 0;
			FullBase.H = 0;
			
			var rect:Rect = new Rect(true, this);
			
			if (Template.isSolid) {
				while (--totalRects > -1) {
					rect.X = this.x + Template.Bases[totalRects].x;
					rect.Y = this.y + Template.Bases[totalRects].y;
					rect.W = Template.Bases[totalRects].width;
					rect.H = Template.Bases[totalRects].height;
					
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
		
		public function ScriptAttack(isPercent:Boolean, amount:int, pierce:int, attacker:IScriptTarget):void {
			MyScript.Run(Script.Attacked, attacker);
		}
		
		public function UpdatePointX(position:PointX):void {
			position.X = this.x;
			position.Y = this.y;
			position.D = 3; //Set to DOWN so the scripts kinda work :)
		}
		
		public function CleanUp():void {
			if (Map != null && !Map.Dying) {
				Map.RemoveObject(this);
			} else {
				if (parent != null) {
					this.parent.removeChild(this);
				}
				
				if(Template != null) Template.OneLessInstance();
				
				Template = null;
				Map = null;
				FullBase = null;
			}
		}
		
		/* INTERFACE Scripting.IScriptTarget */
		public function ChangeState(stateID:int, isLooping:Boolean):void {
			if(isLooping) {
				Template.ChangeState(stateID);
			}
		}
		
		public function AlertMinionDeath(baseCritter:BaseCritter):void {
			MyScript.Run(Script.MinionDied);
		}
		
		public function UpdatePlaybackSpeed(newAnimationSpeed:Number):void {
			//TODO: fix this so that playback speed isn't modifying the global speed
			Template.PlaybackSpeed[0] = newAnimationSpeed;
		}
		
		public function GetCurrentState():int {
			//TODO: maybe this?
			return 0;// Template.CurrentAnimation;
		}
		
		/* INTERFACE Scripting.IScriptTarget */
		
		public function GetFaction():int {
			return 0;
		}
		
		public function GetID():int {
			return REFID;
		}
	}
}