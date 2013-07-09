package Game.Effects 
{
	import flash.display.BitmapData;
	import Game.General.ImageLoader;
	import Game.General.Script;
	/**
	 * ...
	 * @author Paul
	 */
	public class EffectInfo {
		public var ID:int;
		public var Name:String;
		public var MovementSpeed:int;
		public var Life:int;
		
		public var AnimationFrames:Vector.<int>;
		
		public var X:int;
		public var Y:int;
		public var W:int;
		public var H:int;
		
		public var FrameWidth:int;
		public var FrameHeight:int;
		
		public var CanvasWidth:int;
		public var CanvasHeight:int;
		
		public var MyScript:Script;
		public var SpriteAtlas:BitmapData;
		public var SpriteColumns:int = 1;
		
		public function EffectInfo() { }
		
		public function FinishedLoadingData():void {
			ImageLoader.Load("Data/Effect_" + ID + ".png", LoadedAtlas);
			Global.LoadingTotal++;
		}
		
		private function LoadedAtlas(e:BitmapData):void {
			SpriteAtlas = e.clone();
			Global.LoadingTotal--;
		}
	}
}