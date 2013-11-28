package Scripting {
	import EngineTiming.ICleanUp;
	import flash.display.Screen;
	import flash.geom.Vector3D;
	import Game.Equipment.EquipmentItem;
	/**
	 * ...
	 * @author Paul
	 */
	public class ScriptInstance implements ICleanUp {
		public var Variables:Vector.<int>;
		private var TargetStack:Vector.<IScriptTarget>
		
		public var Invoker:IScriptTarget;
		public var CurrentTarget:IScriptTarget;
		
		public var MyScript:Script;
		
		public function ScriptInstance(script:Script, invoker:IScriptTarget, initialize:Boolean = true) {
			if (script == null) return;
			
			MyScript = script;
			Variables = script.InitialVariables.concat();
			
			this.Invoker = invoker;
			this.CurrentTarget = Invoker;
			TargetStack = new Vector.<IScriptTarget>();
			
			if (Invoker is EquipmentItem) {
				AttachTarget((Invoker as EquipmentItem).Owner.Owner);
			}
			
			if (initialize) {
				MyScript.Run(Script.Initialize, this, null);
			}
			
			//Add this to the update scripts thing
			if (MyScript.EventScripts[Script.Update] != null) {
				Script.UpdateScripts.push(this);
			}
			
			//Add this to the trigger scripts thing
			if (MyScript.EventScripts[Script.OnTrigger] != null) {
				Script.TriggerListeners.push(this);
			}
		}
		
		internal function AttachTarget(target:IScriptTarget):void {
			TargetStack.push(CurrentTarget);
			CurrentTarget = target;
		}
		
		internal function PopTarget():void {
			if(TargetStack.length > 0) {
				CurrentTarget = TargetStack.pop();
			} else {
				CurrentTarget = Invoker;
			}
		}
		
		public function Run(event:uint, target:IScriptTarget = null, param:Object = null):void {
			//TODO: Set up variables here
			
			//TODO: Should make invoker the current target if the current target is not invoker.
			if (target != null) {
				AttachTarget(target);
			}
			
			MyScript.Run(event, this, param);
			
			TargetStack.length = 0;
			CurrentTarget = Invoker;
		}
		
		/* INTERFACE EngineTiming.ICleanUp */
		
		public function CleanUp():void {
			var i:int;
			
			while (TargetStack.length > 0) {
				TargetStack.pop();
			}
			
			if (MyScript.EventScripts[Script.Update] != null) {
				i = Script.UpdateScripts.indexOf(this);
				if (i > -1) { Script.UpdateScripts.splice(i, 1); } else { Main.I.Log("FAILED TO SPLICE! UPDATE SCRIPT!"); }
			}
			
			if (MyScript.EventScripts[Script.OnTrigger] != null) {
				i = Script.TriggerListeners.indexOf(this);
				if (i > -1) { Script.TriggerListeners.splice(i, 1); } else { Main.I.Log("FAILED TO SPLICE! TRIGGER SCRIPT!"); }
			}
			
			MyScript = null;
			CurrentTarget = null;
		}
	}
}