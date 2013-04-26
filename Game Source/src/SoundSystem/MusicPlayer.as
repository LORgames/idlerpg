package SoundSystem 
{
	import flash.events.Event;
	import flash.media.Sound;
	import flash.media.SoundChannel;
	import flash.net.URLRequest;
	/**
	 * ...
	 * @author Paul
	 */
	public class MusicPlayer {
		
		private static var snd:Sound = new Sound();
		private static var channel:SoundChannel;
		
		public static function PlaySong(id:int = 0):void {
			if (channel) {
				channel.removeEventListener(Event.SOUND_COMPLETE, FinishedPlaying);
				channel.stop();
				channel = null;
			}
			
			var req:URLRequest = new URLRequest("Data/Music_" + id + ".mp3");
			snd.load(req);
			
			FinishedPlaying();
		}
		
		private static function FinishedPlaying(e:Event=null):void {
			if(channel) channel.removeEventListener(Event.SOUND_COMPLETE, FinishedPlaying);
			
			channel = snd.play(80);
			channel.addEventListener(Event.SOUND_COMPLETE, FinishedPlaying);
		}
		
	}

}