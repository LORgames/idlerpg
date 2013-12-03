package Game.Critter {
	/**
	 * ...
	 * @author Paul
	 */
	public class AITypes {
		public static const Wonder:int = 1;        			// Not Implemented.
        public static const Kite:int = 2;          			// Not Implemented. Runs away to maximize range
        public static const ClosestTarget:int = 4;      	// Actively always ensure the current target is the closest target
        public static const Aggressive:int = 8;    			// Actively looks for new targets
		public static const Supportive:int = 16;			// Chooses ally units as targets instead of enemy units
        public static const Territorial:int = 32; 			// Not Implemented. Defends their spawn zone and returns to it if they get too far away
        public static const RunAway:int = 64;      			// Not Implemented. Runs away on low HP.
		public static const Untargetable:int = 128;			// Can the unit be targetted by other AI entities
		public static const TargetLowestHealth:int = 256;	// Picks the lowest health unit of the units in range to target
		public static const BlindBehind:int = 512;			// Picks the lowest health unit of the units in range to target
		public static const Unsupportable:int = 1024;		// Picks the lowest health unit of the units in range to target
		public static const DisableTurning:int = 2048;		// Unit can't turn around
	}
}