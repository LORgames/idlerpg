package QDMF {
	import adobe.utils.CustomActions;
	import flash.geom.Vector3D;
	import flash.html.script.Package;
	/**
	 * Quick and Dirty Multiplayer Framework High-Level Network Interface
	 * @author Paul
	 */
	public class PacketController {
		private static var Listeners:Vector.<IPacketProcessor> = new Vector.<IPacketProcessor>();
		
		public static function RegisterAsListener(me:IPacketProcessor):void {
			Listeners.push(me);
		}
		
		internal static function ProcessPacket(p:Packet):void {
			for (var i:int = 0; i < Listeners.length; i++) {
				if (Listeners[i].ProcessPacket(p)) {
					return;
				}
			}
		}
	}
}