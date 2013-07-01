package Game.Map.Objects {
	import flash.display.BitmapData;
	import flash.display3D.textures.RectangleTexture;
	import flash.geom.Rectangle;
	import Game.Map.MapData;
	import RenderSystem.IAnimated;
	import RenderSystem.Renderman;
	/**
	 * ...
	 * @author Paul
	 */
	public class ObjectInstanceAnimated extends ObjectInstance implements IAnimated {
		
		public var StartFrame:int = 0;
		public var EndFrame:int = 0;
		private var CurrentFrame:int = 0;
		private var FrameTimeout:Number = 0;
		public var PlaybackSpeed:Number = 0;
		public var CopyRect:Rectangle = new Rectangle();
		
		public function ObjectInstanceAnimated() {
			super();
			Renderman.AnimatedObjectsPush(this);
		}
		
		override public function SetInformation(map:MapData, id:int, _x:int, _y:int):void {
			Map = map;
			ID = id;
			Template = ObjectTemplate.Objects[ID];
			
			CopyRect.x = 0;
			CopyRect.y = 0;
			CopyRect.width = Template.FrameSize.width;
			CopyRect.height = Template.FrameSize.height;
			
			PlaybackSpeed = Template.PlaybackSpeed;
			StartFrame = 0;
			EndFrame = Template.TotalFrames;
			FrameTimeout = Math.random();
			
			super.SetInformation(map, id, _x, _y);
			
			this.bitmapData = new BitmapData(CopyRect.width, CopyRect.height, true, 0x40FFFF00);
		}
		
		override public function CleanUp():void {
			super.CleanUp();
			this.bitmapData.dispose();
			Renderman.AnimatedObjectsRemove(this);
		}
		
		public function UpdateAnimation(dt:Number):void {
			FrameTimeout += dt;
			
			if (FrameTimeout > PlaybackSpeed) {
				while(FrameTimeout > PlaybackSpeed) {
					FrameTimeout -= PlaybackSpeed;
					CurrentFrame++;
					if (CurrentFrame == EndFrame) CurrentFrame = StartFrame;
				}
				
				CopyRect.x = CurrentFrame * CopyRect.width;
				
				if(Template.SpriteAtlas != null) {
					this.bitmapData.copyPixels(Template.SpriteAtlas, CopyRect, Global.ZeroPoint);
				}
			}
		}
	}
}