package Game.Equipment {
	import CollisionSystem.PointX;
	import flash.geom.Point;
	import Game.Critter.BaseCritter;
	import Scripting.IScriptTarget;
	import Scripting.ScriptInstance;
	/**
	 * ...
	 * @author Paul
	 */
	public class EquipmentItem implements IScriptTarget {
		public var Info:EquipmentInfo;
		public var Owner:EquipmentSet;
		public var MyScript:ScriptInstance;
		
		public var Layer:EquipmentItemLayer;
		public var Layer2:EquipmentItemLayer;
		
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
			MyScript = new ScriptInstance(equipment.MyScript, this);
			
			Info.LoadIfRequired();
			
			Layer.SetInformation(equipment);
			if (Layer2 != null) Layer2.SetInformation(equipment);
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
				return Global.ZeroPoint;
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
			
			MyScript.CleanUp();
			MyScript = null;
			
			Layer = null;
			Layer2 = null;
		}
		
		/* INTERFACE Scripting.IScriptTarget */
		public function GetScript():ScriptInstance {
			return MyScript;
		}
		
		public function ScriptAttack(isPercent:Boolean, isDOT:Boolean, amount:int, attacker:IScriptTarget):void {
			
		}
		
		public function UpdatePointX(position:PointX):void {
			position.X = Owner.Owner.X;
			position.Y = Owner.Owner.Y;
			position.D = Owner.Owner.direction;
		}
		
		public function AlertMinionDeath(baseCritter:BaseCritter):void {
			
		}
		
		public function UpdatePlaybackSpeed(newAnimationSpeed:Number):void {
			Layer.PlaybackSpeed = newAnimationSpeed;
			if (Layer2) Layer2.PlaybackSpeed = newAnimationSpeed;
		}
		
		public function GetAnimationSpeed():Number { return Layer.PlaybackSpeed; }
		
		public function ChangeState(newState:int, loop:Boolean):void {
			currentState = newState;
			Layer.SetState(newState, loop);
			if (Layer2 != null) Layer2.SetState(newState, loop);
		}
		
		public function GetCurrentState():int {
			return currentState;
		}
		
		public function toString():String {
			return "[Equipment:"+this.Info.Name+"]";
		}
		
		/* INTERFACE Scripting.IScriptTarget */
		public function GetTypeID():int { return Info.ID; }
		
		public function GetFaction():int {
			return Owner.Owner.GetFaction();
		}
	}

}