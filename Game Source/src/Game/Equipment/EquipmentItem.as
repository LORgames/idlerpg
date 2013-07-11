package Game.Equipment {
	import flash.display.Bitmap;
	import flash.display.BitmapData;
	import flash.geom.Point;
	import flash.geom.Rectangle;
	import Game.Scripting.Script;
	import RenderSystem.IAnimated;
	import RenderSystem.Renderman;
	/**
	 * ...
	 * @author Paul
	 */
	public class EquipmentItem {
		public var Info:EquipmentInfo;
		public var Owner:EquipmentSet;
		
		public var Layer:EquipmentItemLayer;
		public var Layer2:EquipmentItemLayer;
		
		public var DestPoint:Point = new Point();
		
		public var currentState:int = 0;
		
		public function EquipmentItem(owner:EquipmentSet, requiresSecondLayer:Boolean = false) {
			Owner = owner;
			
			Layer = new EquipmentItemLayer(this);
			
			if(requiresSecondLayer) {
				Layer2 = new EquipmentItemLayer(this, 1);
			}
		}
		
		public function SetInformation(equipment:EquipmentInfo):void {
			Info = equipment;
			Info.LoadIfRequired();
			
			Layer.SetInformation(equipment);
			if (Layer2 != null) Layer2.SetInformation(equipment);
		}
		
		public function SetState(newState:int, loop:Boolean = true):void {
			currentState = newState;
			Layer.SetState(newState, loop);
			if (Layer2 != null) Layer2.SetState(newState, loop);
		}
		
		public function SetDirection(newDirection:int):void {
			Layer.SetDirection(newDirection);
			if (Layer2 != null) Layer2.SetDirection(newDirection);
		}
		
		public function Offset(direction:int = 0):Point {
			if(Info != null) {
				if (direction == 1) return Info.Offset_1;
				if (direction == 2) return Info.Offset_2;
				if (direction == 3) return Info.Offset_3;
				return Info.Offset;
			} else {
				return DestPoint;
			}
		}
		
		public function GetCenter():Point {
			return Info.Center;
		}
		
		public function CleanUp():void {
			Info = null;
			Owner = null;
			
			Layer.CleanUp();
			if (Layer2 != null) Layer2.CleanUp();
			
			Layer = null;
			Layer2 = null;
		}
	}

}