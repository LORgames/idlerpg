package Game.Effects {
	import flash.utils.ByteArray;
	import Game.General.BinaryLoader;
	import Game.Scripting.Script;
	/**
	 * ...
	 * @author Paul
	 */
	public class EffectManager {
		public static var I:EffectManager;
		public var Effects:Vector.<EffectInfo>;
		
		public function EffectManager() {
			I = this;
			BinaryLoader.Load("Data/EffectInfo.bin", ParseEffectFile);
			Global.LoadingTotal++;
		}
		
		public function ParseEffectFile(b:ByteArray):void {
			var totalEffects:int = b.readShort();
			Effects = new Vector.<EffectInfo>(totalEffects, true);
			
			for (var i:int = 0; i < totalEffects; i++) {
				var e:EffectInfo = new EffectInfo();
				Effects[i] = e;
				e.ID = i;
				
				e.Name = BinaryLoader.GetString(b);
				e.MovementSpeed = b.readShort();
				e.Life = b.readShort();
				
				var animations:int = b.readByte();
				e.AnimationFrames = new Vector.<int>(animations + 1, true);
				e.AnimationFrames[0] = 0;
				
				for (var j:int = 0; j < animations; j++) {
					e.AnimationFrames[j + 1] = e.AnimationFrames[j] + b.readByte();
				}
				
				e.X = b.readShort();
				e.Y = b.readShort();
				e.W = b.readShort();
				e.H = b.readShort();
				
				e.IsSolid = true;
				
				e.FrameWidth = b.readShort();
				e.FrameHeight = b.readShort();
				e.CanvasWidth = b.readShort();
				e.CanvasHeight = b.readShort();
				
				e.SpriteColumns = (e.CanvasWidth / e.FrameWidth);
				
				e.MyScript = Script.ReadScript(b);
				e.FinishedLoadingData();
			}
			
			Global.LoadingTotal--;
		}
		
	}

}