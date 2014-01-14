package Scripting {
	import adobe.utils.CustomActions;
	import EngineTiming.Clock;
	import Game.Critter.BaseCritter;
	import CollisionSystem.PointX;
	import flash.utils.ByteArray;
	import QDMF.IPacketProcessor;
	import QDMF.Logic.Helper.PingHelper;
	import QDMF.Logic.Syncronizer;
	import QDMF.Logic.TurnStep;
	import QDMF.Packet;
	import QDMF.PacketController;
	import QDMF.PacketTypes;
	import QDMF.SocketTriggers;
	/**
	 * ...
	 * @author Paul
	 */
	public class NetworkScriptExec implements IPacketProcessor, IScriptTarget {
		private var scriptinstance:ScriptInstance;
		private var tb:ByteArray = new ByteArray();
		private var s:Script;
		
		public static var _vectorInt:Vector.<int> = new Vector.<int>(0, true);
		public static var _vectorFlp:Vector.<Number> = new Vector.<Number>(0, true);
		
		public static function Launch():void {
			new NetworkScriptExec();
		}
		
		public function NetworkScriptExec() {
			PacketController.RegisterAsListener(this);
			
			s = new Script(Vector.<ByteArray>([tb]), _vectorInt, _vectorFlp);
			scriptinstance = new ScriptInstance(null, this);
			scriptinstance.CurrentTarget = this;
		}
		
		/* INTERFACE QDMF.IPacketProcessor */
		
		public function ProcessPacket(p:Packet):Boolean {
			var pr:Packet;
			
			if (p.type == PacketTypes.SCRIPT) {
				Main.I.Log("Executing Network Script");
				tb.clear(); p.bytes.readBytes(tb, 0);
				s.Run(0, scriptinstance, null);
				return true;
			} else if(p.type == PacketTypes.TURNSTEP) {
				TurnStep.UnpackAndRegister(p.bytes);
				return true;
			} else if (p.type == PacketTypes.CONTROL) {
				var controlType:int = p.bytes.readShort();
				var controlInfo:int = p.bytes.readShort();
				
				if (controlType == 0) { // Set Player ID
					Global.CurrentPlayerID = controlInfo;
					if (Global.GV_PlayerID != 0) {
						GlobalVariables.IntegerVariables[Global.GV_PlayerID] = controlInfo;
					}
					PingHelper.Reset();
					Main.I.Log("RECV New Player ID");
				} else if (controlType == 1) { // Matching controls
					if (controlInfo == 1) { // Match Joined
						Syncronizer.Reset();
						Clock.I.Reset();
						Script.FireTrigger(SocketTriggers.SOCKET_CONNECT);
					}
				} else if (controlType == 2) { // Device Information
					if (controlInfo == 0) { // Current Time
						if (Global.Network) {
							pr = new Packet(PacketTypes.SERVER);
							pr.bytes.writeShort(0);
							pr.bytes.writeFloat(new Date().time);
							
							Global.Network.SendPacket(pr);
						}
					} else if (controlInfo == 1) {
						Syncronizer.Reset();
						Clock.I.Reset();
					}
				}
				
				return true;
			} else if (p.type == PacketTypes.PING_REPLY || p.type == PacketTypes.PING) {
				var plrID:int = p.bytes.readByte();
				var pingID:int = p.bytes.readInt();
				
				if (p.type == PacketTypes.PING) {
					pr = new Packet(PacketTypes.PING_REPLY); // Ping Reply
					pr.bytes.writeByte(plrID);
					pr.bytes.writeInt(pingID);
					Global.Network.SendPacketImmediate(pr);
				} else {
					if(plrID == Global.CurrentPlayerID) {
						PingHelper.PingReply(pingID);
					}
				}
				return true;
			}
			
			return false;
		}
		
		/* INTERFACE Scripting.IScriptTarget */
		public function GetScript():ScriptInstance { return scriptinstance; }
		public function UpdatePointX(position:PointX):void { position.D = 1; position.X = 0; position.Y = 0; }
		public function AlertMinionDeath(baseCritter:BaseCritter):void {}
		public function ChangeState(stateID:int, isLooping:Boolean):void {}
		public function UpdatePlaybackSpeed(newAnimationSpeed:Number):void { }
		public function GetAnimationSpeed():Number { return 0; }
		public function GetCurrentState():int { return 0; }
		public function GetFaction():int { return 0; }
	}

}