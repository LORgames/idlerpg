package SoundSystem 
{
	import flash.events.Event;
	import flash.media.Sound;
	import flash.media.SoundChannel;
	import flash.media.SoundTransform;
	import flash.net.URLRequest;
	import Scripting.GlobalVariables;
	/**
	 * ...
	 * @author Paul
	 */
	public class MusicPlayer {
		
		private static var snd:Sound;
		private static var channel:SoundChannel;
		public static var MusicEnabled:Boolean = true;
		
		private static var currentlyPlayingID:int = -1;
		
		public static function PlaySong(id:int = 0):void {
			if (!MusicEnabled) return;
			
			if (id == currentlyPlayingID) return;
			
			if (channel) {
				channel.removeEventListener(Event.SOUND_COMPLETE, FinishedPlaying);
				channel.stop();
				channel = null;
			}
			
			var req:URLRequest = new URLRequest("Data/Music_" + id + ".mp3");
			
			snd = new Sound();
			snd.load(req);
			
			currentlyPlayingID = id;
			
			FinishedPlaying();
		}
		
		public static function UpdateVolume():void {
			if (channel) {
				var st:SoundTransform = channel.soundTransform;
				st.volume = GlobalVariables.IntegerVariables[Global.GV_MusicVolume] / 100.0;
				channel.soundTransform = st;
			}
		}
		
		private static function FinishedPlaying(e:Event=null):void {
			if(channel) channel.removeEventListener(Event.SOUND_COMPLETE, FinishedPlaying);
			
			channel = snd.play(80, 0, new SoundTransform(0));
			UpdateVolume();
			
			if(channel != null) channel.addEventListener(Event.SOUND_COMPLETE, FinishedPlaying);
		}
	}

}