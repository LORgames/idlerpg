package Scripting {
	import Game.Critter.BaseCritter;
	import CollisionSystem.PointX;
	import flash.utils.ByteArray;
	import QDMF.IPacketProcessor;
	import QDMF.Packet;
	import QDMF.PacketController;
	/**
	 * ...
	 * @author Paul
	 */
	public class NetworkScriptExec implements IPacketProcessor, IScriptTarget {
		
		private var scriptinstance:ScriptInstance;
		private var tb:ByteArray = new ByteArray();
		private var s:Script;
		
		public static function Launch():void {
			new NetworkScriptExec();
		}
		
		public function NetworkScriptExec() {
			PacketController.RegisterAsListener(this);
			
			s = new Script(Vector.<ByteArray>([tb]), new Vector.<int>());
			scriptinstance = new ScriptInstance(null, this);
			scriptinstance.CurrentTarget = this;
		}
		
		/* INTERFACE QDMF.IPacketProcessor */
		
		public function ProcessPacket(p:Packet):Boolean {
			if (p.type == 7) {
				trace("RECV IMPORTANT PACKET!");
				
				tb.clear();
				p.bytes.readBytes(tb, 0);
				s.Run(0, scriptinstance, null);
				
				return true;
			}
			
			return false;
		}
		
		/* INTERFACE Scripting.IScriptTarget */
		
		public function UpdatePointX(position:PointX):void {
			position.D = 1;
			position.X = 0;
			position.Y = 0;
		}
		
		public function AlertMinionDeath(baseCritter:BaseCritter):void {
			
		}
		
		public function ChangeState(stateID:int, isLooping:Boolean):void {
			
		}
		
		public function UpdatePlaybackSpeed(newAnimationSpeed:Number):void {
			
		}
		
		public function GetCurrentState():int {
			return 0;
		}
		
		public function GetFaction():int {
			return 0;
		}
		
	}

}