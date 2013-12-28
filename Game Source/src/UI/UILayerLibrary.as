package UI {
	import CollisionSystem.Rect;
	import EngineTiming.Clock;
	import EngineTiming.IUpdatable;
	import flash.display.Bitmap;
	import flash.display.BitmapData;
	import flash.display.Sprite;
	import flash.geom.Matrix;
	import flash.geom.Rectangle;
	import Game.Critter.CritterAnimationSet;
	import Scripting.GlobalVariables;
	/**
	 * ...
	 * @author Paul
	 */
	public class UILayerLibrary extends UILayer implements IUpdatable {
		///VARIABLES
        public var Library:UILibrary;
		private var ID:int = 0;
		
		private var _playUp:Boolean = true;
		private var _playTick:Number = 0;
		private var _currTick:Number = 0;
		private var isPlaying:Boolean = false;
		private var _currPar:UIElement = null;
		
		public function UILayerLibrary(par:UIElement) {
			_currPar = par;
		}
		
		public override function Draw(w:int, h:int, ui:UIManager):void {
			///////////////////////////////////////////// Update the position
			var thisArea:Rect = new Rect(false, null, 0, 0, SizeX, SizeY);
			
			FixPosition();
			
			///////////////////////////////////////////// Redraw if required
			//if (!RequiresRedraw) return;
			
			var bmpd:BitmapData = Library.ImageCutouts[ID];
			var m:Matrix = new Matrix();
			
			if (LayerType == Stretch || LayerType == StretchToValueX || 
				LayerType == StretchToValueY || LayerType == StretchToValueXNeg ||
				LayerType == StretchToValueYNeg) {
					if (this.bitmapData == null) {
						this.bitmapData = new BitmapData(SizeX, SizeY, true, 0x0);
						RedrawRect = new Rectangle(0, 0, SizeX, SizeY);
					}
					
					this.bitmapData.fillRect(RedrawRect, 0x0);
					
					m.scale(thisArea.W / bmpd.width, thisArea.H / bmpd.height);
					this.bitmapData.draw(bmpd, m);
					
					if (LayerType == Stretch) {
						RequiresRedraw = false;
					}
			} else if (LayerType == Static || LayerType == PanX || LayerType == PanY || LayerType == PanXNeg || LayerType == PanYNeg) {
				this.bitmapData = new BitmapData(Math.min(bmpd.width, thisArea.W), Math.min(bmpd.height, thisArea.H), true, 0x0);
				this.bitmapData.draw(bmpd, m);
				RequiresRedraw = false;
			} else if (LayerType == Tile) {
				//TODO: Cannot draw 'tile' types easily?
				RequiresRedraw = false;
			}
		}
		
		public function SetID(newID:Number):void {
			if (isPlaying) StopPlaying();
			ID = newID;
		}
		
		public function Play(time:Number, playReverse:Boolean):void {
			if (!isPlaying) {
				Clock.I.RegisterUpdatable(this);
				isPlaying = true;
			}
			
			_playTick = (time / Library.TotalFrames);
			_currTick = 0;
			
			if (playReverse) {
				ID = Library.TotalFrames - 1;
				_playUp = false;
			} else {
				ID = 0;
				_playUp = true;
			}
			
			RequiresRedraw = true;
			Update(0);
		}
		
		private function StopPlaying():void {
			isPlaying = false;
			Clock.I.Remove(this);
		}
		
		/* INTERFACE EngineTiming.IUpdatable */
		
		public function Update(dt:Number):void {
			_currTick += dt;
			
			while (_currTick > _playTick) {
				if (_playUp) {
					ID++;
				} else {
					ID--;
				}
				
				_currTick -= _playTick;
				
				RequiresRedraw = true;
			}
			
			if (ID >= Library.TotalFrames) {
				ID = Library.TotalFrames - 1;
				StopPlaying();
			} else if (ID < 0) {
				ID = 0;
				StopPlaying();
			}
			
			if (RequiresRedraw) {
				_currPar.Draw(Main.I.stage.stageWidth, Main.I.stage.stageHeight, Main.I.hud);
			}
		}
	}

}