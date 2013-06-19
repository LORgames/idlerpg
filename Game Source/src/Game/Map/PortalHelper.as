package Game.Map {
	import CollisionSystem.Rect;
	/**
	 * ...
	 * @author Paul
	 */
	public class PortalHelper {
		
		//Seconds to lock controls for
		private static const PORTAL_CONTROL_LOCK_TIME:int = 2;
		private static const CurrentLockoutTime:int = 0;
		private static const IsLocked:int = 0;
		
		public static function CheckForPortalling(CurrentMap:MapData):void {
			var j:int = 0;
			var MyRect:Rect = WorldData.ME.MyRect;
			
			if (MyRect == null) return;
			
			//Check to see if this object can portal
			if (CurrentMap.Portals != null) {
				j = CurrentMap.Portals.length;
				while (--j > -1) {
					if (CurrentMap.Portals[j].Entry.intersects(MyRect)) {
						var exitID:int = CurrentMap.Portals[j].ExitID;
						if (WorldData.ME.CurrentMap.Name == WorldData.PortalDestinations[exitID]) {
							var k:int = CurrentMap.Portals.length;
							while (--k > -1) {
								if (CurrentMap.Portals[j].ExitID == CurrentMap.Portals[k].ID) {
									Global.MapPortalID = k;
									Main.I.Renderer.FadeToBlack(WorldData.ME.RequestInMapTeleport, "zaaaappp!");
								}
							}
							break;
						} else {
							Global.MapPortalID = exitID;
							Main.I.Renderer.FadeToBlack(WorldData.UpdatePlayerPosition, WorldData.PortalDestinations[exitID]);
						}
						break;
					}
				}
			}
		}
		
	}

}