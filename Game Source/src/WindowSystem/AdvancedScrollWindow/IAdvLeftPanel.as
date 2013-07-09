package WindowSystem.AdvancedScrollWindow {
	import flash.display.DisplayObject;
	import flash.display.Sprite;
	/**
	 * ...
	 * @author Paul
	 */
	public interface IAdvLeftPanel {
		function Resize(width:int, height:int):void;
		function CleanUp():void;
		function GetDisplayObject():DisplayObject;
	}

}