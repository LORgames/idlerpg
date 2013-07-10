package Debug {
	import CollisionSystem.Rect;
	import EngineTiming.Clock;
	import EngineTiming.IUpdatable;
	import flash.display.Sprite;
	/**
	 * ...
	 * @author Paul
	 */
	public class Drawer implements IUpdatable {
		public static var DrawingObjects:Vector.<Sprite> = new Vector.<Sprite>();
		private static var NotReady:Boolean = true;
		private static var Empty:Sprite = new Sprite();
		
		public static function Initialize():void {
			if(Global.DebugRender) {
				Clock.I.Updatables.push(new Drawer());
				NotReady = false;
			}
		}
		
		public static function AddDebugRect(r:Rect):void {
			GetSprite().graphics.drawRect(r.X, r.Y, r.W, r.H);
		}
		
		public static function AddDebugCircle(x:Number, y:Number, r:Number):void {
			GetSprite().graphics.drawEllipse(x-r, y-r*0.85, r*2, r*2*0.85);
		}
		
		public static function GetSprite():Sprite {
			if (!Global.DebugRender) {
				Empty.graphics.clear();
				return Empty;
			}
			
			if (NotReady) Initialize();
			
			var spr:Sprite = new Sprite();
			spr.x = Main.OrderedLayer.x;
			spr.y = Main.OrderedLayer.y;
			
			spr.graphics.clear();
			spr.graphics.lineStyle(1, 0xFF0000);
			Main.I.addChild(spr);
			
			DrawingObjects.splice(0, 0, spr);
			
			return spr;
		}
		
		/* INTERFACE EngineTiming.IOneSecondUpdate */
		
		public function Update(dt:Number):void {
			var i:int = DrawingObjects.length;
			
			while (--i > -1) {
				var spr:Sprite = DrawingObjects[i];
				spr.alpha -= 0.075;
				
				if (spr.alpha <= 0) {
					DrawingObjects.pop();
					
					Main.I.removeChild(spr);
					spr.graphics.clear();
					spr = null;
				}
			}
		}
		
	}

}