package SoundSystem {
	import adobe.utils.CustomActions;
	import flash.media.Sound;
	import flash.media.SoundChannel;
	import flash.media.SoundTransform;
	import flash.net.URLRequest;
	import flash.utils.ByteArray;
	import Loaders.BinaryLoader;
	import Scripting.GlobalVariables;
	/**
	 * ...
	 * @author Paul
	 */
	public class EffectsPlayer {
		private static const MAX_SOUNDS:int = 32;
		private static var effects:Vector.<SoundChannel> = new Vector.<SoundChannel>(MAX_SOUNDS, true);
		
		private static var groups:Vector.<int> = new Vector.<int>();
		private static var numbers:Vector.<int> = new Vector.<int>();
		
		public static function Initialize():void {
			BinaryLoader.Load("Data/EffectGroups.bin", ParseGroupsFile);
		}
		
		public static function ParseGroupsFile(b:ByteArray):void {
			var totalGroups:int = b.readShort();
			var totalSounds:int = 0;
			
			groups = new Vector.<int>(totalGroups + 1, true);
			groups[0] = 0;
			
			numbers = new Vector.<int>();
			
			for (var i:int = 0; i < totalGroups; i++) {
				totalSounds = b.readShort();
				groups[i + 1] = totalSounds + groups[i];
				
				while (--totalSounds > -1) {
					numbers.push(b.readShort());
				}
			}
		}
		
		public static function PlayFromGroup(gid:int = 0):int {
			return Play((Rndm.random() * (groups[gid + 1] - groups[gid])) + groups[gid]);
		}
		
		public static function Play(id:int = 0):int {
			var rid:int = GetEmptySoundSlot();
			
			if(rid != -1) {
				var req:URLRequest = new URLRequest("Data/Effects_" + id + ".mp3");
				
				var sound:Sound = new Sound(req);
				effects[rid] = sound.play(80);
				
				var st:SoundTransform = effects[rid].soundTransform;
				st.volume = GlobalVariables.IntegerVariables[Global.GV_Mute] == 1 ? 0 : GlobalVariables[Global.GV_SoundVolume] / 100.0;
				effects[rid].soundTransform = st;
			}
			
			return rid;
		}
		
		private static function GetEmptySoundSlot():int {
			for (var i:int = 0; i < MAX_SOUNDS; i++) {
				if (effects[i] == null) return i;
			}
			
			return -1;
		}
		
		public static function UpdateVolume():void {
			//TODO: All the sounds need to be stored.
			// Make sure mute is included!
			for (var i:int = 0; i < MAX_SOUNDS; i++) {
				if (effects[i] == null) continue;
				
				var st:SoundTransform = effects[i].soundTransform;
				st.volume = GlobalVariables.IntegerVariables[Global.GV_Mute] == 1 ? 0 : GlobalVariables[Global.GV_SoundVolume] / 100.0;
				effects[i].soundTransform = st;
			}
		}
	}
}