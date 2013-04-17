package Game.Map {
	import flash.display.Bitmap;
	/**
	 * ...
	 * @author Paul
	 */
	public class ObjectInstance extends Bitmap {
		
		public var ID:int;
		public var Template:ObjectTemplate;
		
		public function ObjectInstance() {
			Main.OrderedLayer.addChild(this);
		}
		
		public function SetInformation(id:int, _x:int, _y:int):void {
			ID = id;
			Template = ObjectTemplate.Objects[ID];
			
			this.bitmapData = Template.GetBitmap();
			
			this.x = _x;
			this.y = _y;
		}
		
	}

}