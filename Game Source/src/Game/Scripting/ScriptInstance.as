package Game.Scripting {
	import EngineTiming.ICleanUp;
	import flash.display.Screen;
	import flash.geom.Vector3D;
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
			MyScript = script;
			Variables = script.InitialVariables.concat();
			
			TargetStack = new Vector.<IScriptTarget>(1);
			TargetStack[0] = invoker;
			this.CurrentTarget = invoker;
			if (initialize) {
				MyScript.Run(Script.Initialize, this);
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
		
		public function AttachTarget(target:IScriptTarget):void {
			TargetStack.push(CurrentTarget);
		}
		
		public function PopTarget():void {
			CurrentTarget = TargetStack.pop();
		}
		
		public function Run(event:uint):void {
			//TODO: Set up variables here
			MyScript.Run(event, this);
		}
		
		/* INTERFACE EngineTiming.ICleanUp */
		
		public function CleanUp():void {
			while (TargetStack.length > 0) {
				TargetStack.pop();
			}
			
			if (MyScript.EventScripts[Script.Update] != null) {
				var i:int = Script.UpdateScripts.indexOf(this);
				if (i > -1) { Script.UpdateScripts.splice(i, 1); }
			}
			
			if (MyScript.EventScripts[Script.OnTrigger] != null) {
				var i:int = Script.TriggerListeners.indexOf(this);
				if (i > -1) { Script.TriggerListeners.splice(i, 1); }
			}
			
			MyScript = null;
			CurrentTarget = null;
		}
	}
}