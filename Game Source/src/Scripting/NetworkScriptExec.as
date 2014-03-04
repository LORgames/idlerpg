package Scripting {
	import adobe.utils.CustomActions;
	import Debug.DebugLogger;
	import EngineTiming.Clock;
	import Game.Critter.BaseCritter;
	import CollisionSystem.PointX;
	import flash.utils.ByteArray;
	import Game.Map.Objects.ObjectInstance;
	import Game.Map.Objects.ObjectInstanceAnimated;
	import Game.Map.Objects.ObjectTemplate;
	import Game.Map.WorldData;
	import QDMF.IPacketProcessor;
	import QDMF.Logic.Helper.PingHelper;
	import QDMF.Logic.Syncronizer;
	import QDMF.Logic.TurnStep;
	import QDMF.Packet;
	import QDMF.PacketController;
	import QDMF.PacketTypes;
	import QDMF.SocketTriggers;
	import RenderSystem.Renderman;
	/**
	 * ...
	 * @author Paul
	 */
	public class NetworkScriptExec implements IPacketProcessor {
		public static function Launch():void {
			new NetworkScriptExec();
		}
		
		public function NetworkScriptExec() {
			PacketController.RegisterAsListener(this);
		}
		
		/* INTERFACE QDMF.IPacketProcessor */
		
		public function ProcessPacket(p:Packet):Boolean {
			var pr:Packet;
			
			if(p.type == PacketTypes.TURNSTEP) {
				TurnStep.UnpackAndRegister(p.bytes);
				return true;
			} else if (p.type == PacketTypes.CONTROL) {
				var controlType:int = p.bytes.readShort();
				var controlInfo:int = p.bytes.readShort();
				
				Global.Out.Log("NC:CONTROL TYPE=" + controlType + ", INFO=" + controlInfo);
				
				if (controlType == 0) { // Set Player ID
					Global.CurrentPlayerID = controlInfo;
					if (Global.GV_PlayerID != 0) {
						GlobalVariables.IntegerVariables[Global.GV_PlayerID] = controlInfo;
					}
					PingHelper.Reset();
					Global.Out.Log("RECV New Player ID");
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
				} else if (controlType == 3) { //Change Map
					WorldData.CurrentMap.CleanUp();
					WorldData.CurrentMap.LoadMap(WorldData.Maps[controlInfo]);
				} else if (controlType == 4) { //Change Variable
					GlobalVariables.IntegerVariables[controlInfo] = p.bytes.readInt();
					Global.Out.Log("RECV INTEGR=" + controlInfo + " NEW=" + GlobalVariables.IntegerVariables[controlInfo]);
				} else if (controlType == 5) { //Change String
					GlobalVariables.StringVariables[controlInfo] = p.bytes.readUTF();
					Global.Out.Log("RECV STRING=" + controlInfo + " NEW=" + GlobalVariables.StringVariables[controlInfo]);
				} else if (controlType == 6) { //Spawn Object
					var o:ObjectInstance;
					var x:int = p.bytes.readShort();
					var y:int = p.bytes.readShort();
					
					if (ObjectTemplate.Objects[controlInfo].IndividualAnimations) {
						o = new ObjectInstanceAnimated(WorldData.CurrentMap.Objects.length);
					} else {
						o = new ObjectInstance(WorldData.CurrentMap.Objects.length);
					}
					
					o.SetInformation(WorldData.CurrentMap, controlInfo, x, y);
					WorldData.CurrentMap.Objects.push(o);
					Renderman.DirtyObjects.push(o);
				} else if (controlType == 7) { //Net Trigger
					Global.Out.Log("NC::TRIGGER ID" + controlInfo);
					Script.FireTrigger(controlInfo);
				} else if (controlType == 8) { //Reset Clocks
					Syncronizer.Reset();
					Clock.I.Reset();
				} else {
					Global.Out.Log("NC::CONTROL::UNKNOWN TYPE=" + controlType);
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
			} else if (p.type == PacketTypes.ENDTURN) {
				var playerID:int = p.bytes.readUnsignedShort();
				var turnID:int = p.bytes.readUnsignedShort();
				Syncronizer.MarkTurnEnded(playerID, turnID);
			} else {
				Global.Out.Log("NETWORK PACKET ERROR: Unknown type: " + p.type);
			}
			
			return false;
		}
		
		public function Disconnect():void {
			Script.FireTrigger(SocketTriggers.SOCKET_DISCONNECT);
			Syncronizer.Reset();
		}
	}

}