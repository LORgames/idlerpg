package SoundSystem {
	import flash.media.Sound;
	import flash.net.URLRequest;
	/**
	 * ...
	 * @author Paul
	 */
	public class EffectsPlayer {
		
		public static function Play(id:int = 0):void {
			var req:URLRequest = new URLRequest("Data/Effects_" + id + ".mp3");
			
			var sound:Sound = new Sound(req);
			sound.play(80);
		}
		
	}

}