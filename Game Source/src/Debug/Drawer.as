package Debug {
	import CollisionSystem.Rect;
	import EngineTiming.Clock;
	import EngineTiming.IUpdatable;
	import flash.display.Sprite;
	import flash.text.TextField;
	import UI.Fonts;
	/**
	 * ...
	 * @author Paul
	 */
	public class Drawer implements IUpdatable {
		public static var DrawingObjects:Vector.<Sprite> = new Vector.<Sprite>();
		private static var NotReady:Boolean = true;
		
		public static function Initialize():void {
			if(Global.DebugRender) {
				Clock.I.RegisterUpdatable(new Drawer());
				NotReady = false;
			}
		}
		
		public static function AddDebugRect(r:Rect, c:int = -1):void {
			if (!Global.DebugRender) return;
			
			var s:Sprite = GetSprite();
			
			if (c != -1) {
				s.graphics.lineStyle(1, c);
			}
			
			s.graphics.drawRect(r.X, r.Y, r.W, r.H);
		}
		
		public static function AddDebugCircle(x:Number, y:Number, r:Number, c:int = -1):void {
			if (!Global.DebugRender) return;
			
			GetSprite().graphics.drawEllipse(x-r, y-r*0.85, r*2, r*2*0.85);
		}
		
		public static function AddLine(x1:int, y1:int, x2:int, y2:int, c:int = -1):void {
			if (!Global.DebugRender) return;
			
			var s:Sprite = GetSprite();
			
			if (c != -1) {
				s.graphics.lineStyle(1, c);
			}
			
			s.graphics.moveTo(x1, y1);
			s.graphics.lineTo(x2, y2);
		}
		
		private static function GetSprite():Sprite {
			if (!Global.DebugRender) return null;
			
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
		
		static public function GetTextField():TextField {
			var tf:TextField = Fonts.GetTextField(12, 3, 0x0);
			
			Main.I.addChild(tf);
			
			return tf;
		}
		
		/* INTERFACE EngineTiming.IOneSecondUpdate */
		
		public function Update(dt:Number):void {
			var i:int = DrawingObjects.length;
			
			while (--i > -1) {
				var spr:Sprite = DrawingObjects[i];
				spr.alpha -= 0.15;
				
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