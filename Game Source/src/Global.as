package {
	import CollisionSystem.Rect;
	import flash.display.Bitmap;
	import flash.geom.Point;
	import QDMF.IHLNetwork;
	/**
	 * ...
	 * @author Paul
	 */
	public class Global {
		//Loading information
		public static var LoadingTotal:int = 0;				//Is anything loading currently?
		public static var PrevLoadingTotal:int = 0;			//Was anything loading recently?
		public static var FadeOnLoad:Boolean = true;		//Have we faded?
		
		//Portaling Information
		public static var MapPortalID:int = -1;				//OUTDATED: DO NOT USE
		public static var DisablePortals:Boolean = true;	//OUTDATED: DO NOT USE
		
		public static const ZeroPoint:Point = new Point();	//Static const for what a 0,0 point is
		
		//Debug information
		public static var DebugRender:Boolean = false;		//Should we draw debug rectangles for AI and positioning?
		static public var DebugFPS:Boolean = true;			//Should I display the FPS on screen?
		static public var IsEditor:Boolean = true;			//Are we running in the editor?
		
		//Settings
		public static var GameName:String = "";				//Whats the name of the game
		public static var FPS:int = 20;						//What FPS are we aiming for?
		public static var HasTiles:Boolean = false;			//Do we need to load, display and update the tile system?
		public static var TileSize:int = 48;				//The size of the tiles, used as both a physical size and for physics
		public static var PerspectiveSkew:Number = 0.85;	//The multiplayer for up and down position 1 for top down, 0 for side scroller?
		
		public static var GV_WX:int = 0;					//Variable ID for World X position
		public static var GV_WY:int = 0;					//Variable ID for World Y position
		public static var GV_LX:int = 0;					//Variable ID for Local X position
		public static var GV_LY:int = 0;					//Variable ID for Local Y position
		
		static public var GV_MusicVolume:int;				//Variable ID for Music Volume
		static public var GV_SoundVolume:int;				//Variable ID for Sound Volume
		
		public static var DefaultMap:String = "";			//The name of the default map
		
		public static var HasLeftRight:Boolean = true;		//Can critters and effects have left and right states?
		public static var HasUpDown:Boolean = false;		//Can critters and effects have an up and down state
		
		public static var TotalPlayers:int = 1;				//Maximum support players in multiplayer
		public static var CrittersPerPlayer:int = 32;		//How many critters each player can spawn/control
		public static var EffectsPerPlayer:int = 32;		//How many effects each player can spawn/control
		public static var SIMULATION_LIMIT_CRITTER:int = 0;	//Index at which the simulation indices loop back to 0
		public static var SIMULATION_LIMIT_EFFECTS:int = 0; //Index at which the simulation indices loop back to 0
		public static var MatchmakingAddress:String = "";	//How many effects each player can spawn/control
		
		//Networking?
		public static var Network:IHLNetwork;				//The current network connection
		public static var TurnLength:int = 250; 			//Millisecond delay between turns
		public static var CurrentPlayerID:int = 1;			//The current player ID for spawning units.
	}
}