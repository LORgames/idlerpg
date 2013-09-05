package SoundSystem {
	import adobe.utils.CustomActions;
	import flash.media.Sound;
	import flash.net.URLRequest;
	import flash.utils.ByteArray;
	import Game.General.BinaryLoader;
	/**
	 * ...
	 * @author Paul
	 */
	public class EffectsPlayer {
		
		private static var groups:Vector.<int> = new Vector.<int>();
		private static var numbers:Vector.<int> = new Vector.<int>();
		
		public static function Initialize():void {
			BinaryLoader.Load("Data/EffectGroups.bin", ParseGroupsFile);
			Global.LoadingTotal++;
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
			
			Global.LoadingTotal--;
		}
		
		public static function PlayFromGroup(gid:int = 0):void {
			Play((Math.random() * (groups[gid + 1] - groups[gid + 1])) + groups[gid]);
		}
		
		public static function Play(id:int = 0):void {
			var req:URLRequest = new URLRequest("Data/Effects_" + id + ".mp3");
			
			var sound:Sound = new Sound(req);
			sound.play(80);
		}
		
	}

}