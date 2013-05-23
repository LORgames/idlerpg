package Game.General {
	import adobe.utils.CustomActions;
	import flash.geom.PerspectiveProjection;
	import flash.utils.ByteArray;
	import Game.Critter.Person;
	import SoundSystem.EffectsPlayer;
	/**
	 * ...
	 * @author Paul
	 */
	public class Script {
		public static const Attack:uint = 0;
		public static const ModifyAttack:uint = 1;
		public static const ModifyDamage:uint = 2;
		public static const Spawn:uint = 3;
		public static const Attacked:uint = 4;
		public static const Use:uint = 5;
		public static const Equip:uint = 6;
		public static const MinionDied:uint = 7;
		public static const TOTAL_EVENT_TYPES:uint = 8;
		
		private var EventScripts:Vector.<ByteArray>;
		
		public function Script(commandBlock:Vector.<ByteArray>) {
			EventScripts = commandBlock;
		}
		
		public function Run(event:uint, invoker:Object = null, target:Object = null):void {
			//Reset the reader
			if (event >= TOTAL_EVENT_TYPES) {
				trace("Event Type Unsupported!");
				return;
			}
			
			if (EventScripts[event] == null) {
				trace("Event type not on this object.");
				return;
			}
			
			if (target == null && invoker != null) {
				target = invoker;
			}
			
			var EventScript:ByteArray = EventScripts[event];
			EventScript.position = 0;
			
			//Some required variables
			var command:uint = 0;
			
			while (true) {
				command = EventScript.readUnsignedShort();
				
				if (command == 0xFFFF) break;
				
				switch(command) {
					case 0x1001: //Play sound effect
						EffectsPlayer.Play(EventScript.readShort());
						break;
					case 0x4001: //Equip item on the invoker
						if (target is Person) {
							var person:Person = (target as Person);
							person.equipment.EquipSlot(EventScript.readShort(), EventScript.readShort());
							trace("Trying to equip on item on someone thats not a person.");
						} break;
				}
			}
		}
		
		//This function is responsible for reading scripts in and creating script objects
		//that can be run later :)
		public static function ReadScript(b:ByteArray):Script {
			//Scripts have a short as the command followed (possibly) by parametres.
			//The documentation below describes the parametres available. If you add more remember to add them there as well
			// https://docs.google.com/a/lorgames.com/spreadsheet/ccc?key=0AseSUpYHHmpOdGtycW92djQ3UjhyTlM1QmxvbXp1Rmc#gid=13
			
			var command:uint = 0;
			
			var activeEvent:uint = 0;
			var activeScript:ByteArray;
			
			var commandBlock:Vector.<ByteArray> = new Vector.<ByteArray>(TOTAL_EVENT_TYPES);
			
			while (command != 0xFFFF) { //While not end of file
				command = b.readUnsignedShort();
				
				trace("Processing: 0x" + command.toString(16));
				
				if (command < 0x1000) { //All events are in this range
					if (activeScript != null) {
						activeScript.writeShort(0xFFFF);
					}
					
					activeEvent = command;
						
					if (activeEvent < TOTAL_EVENT_TYPES) {
						commandBlock[activeEvent] = new ByteArray();
						activeScript = commandBlock[activeEvent];
						
						
						trace("\tAdded event (" + activeEvent + ") to queue.");
					} else {
						activeScript = new ByteArray();
						trace("Event type is too high [" + activeEvent + " < " + TOTAL_EVENT_TYPES + " = false]. Created dummy script to discard this event.");
					}
				} else {
					if (command == 0xFFFF) {
						if(activeScript != null) activeScript.writeShort(0xFFFF);
						break; //Exit early if script has ended
					} else { //Must be an action
						activeScript.writeShort(command);
						
						switch(command) {
							case 0x1001: //Play sound effect
								activeScript.writeShort(b.readShort()); // The sound ID
								break;
							case 0x4001: //Equip item on the invoker
								activeScript.writeShort(b.readShort());
								activeScript.writeShort(b.readShort());
								break;
						}
					}
				}
			}
			
			return new Script(commandBlock);
		}
		
	}

}