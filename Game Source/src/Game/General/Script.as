package Game.General {
	import adobe.utils.CustomActions;
	import flash.geom.PerspectiveProjection;
	import flash.utils.ByteArray;
	import Game.Critter.Person;
	import Game.Equipment.EquipmentItem;
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
		public static const AnimationEnded:uint = 8;
		public static const TOTAL_EVENT_TYPES:uint = 9;
		
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
				trace("Event type not on this object. [" + invoker + " => " + event + "]");
				return;
			}
			
			trace(invoker + " => " + target + " @" + event);
			
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
					case 0x1002: //Spawn Critter
						var critterID:int = EventScript.readShort();
						break;
					case 0x4001: //Equip item on the target
						if (target is Person) {
							var person:Person = (target as Person);
							person.equipment.EquipSlot(EventScript.readShort(), EventScript.readShort());
						} break;
					case 0x6000: //Play Animation
						if (invoker is EquipmentItem) {
							(invoker as EquipmentItem).SetState(EventScript.readShort(), false);
						} else {
							trace("Unknown Invoker for 0x6000:PlayAnimation");
							EventScript.readShort();
						} break;
					case 0x6001: //Loop Animation
						if (invoker is EquipmentItem) {
							(invoker as EquipmentItem).SetState(EventScript.readShort(), true);
						} else {
							trace("Unknown Invoker for 0x6001:LoopAnimation");
							EventScript.readShort();
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
				
				if (command < 0x1000) { //All events are in this range
					if (activeScript != null) {
						activeScript.writeShort(0xFFFF);
					}
					
					activeEvent = command;
						
					if (activeEvent < TOTAL_EVENT_TYPES) {
						commandBlock[activeEvent] = new ByteArray();
						activeScript = commandBlock[activeEvent];
					} else {
						activeScript = new ByteArray();
					}
				} else {
					if (command == 0xFFFF) {
						if(activeScript != null) activeScript.writeShort(0xFFFF);
						break; //Exit early if script has ended
					} else { //Must be an action
						activeScript.writeShort(command);
						
						switch(command) {
							
							//1 extra short
							case 0x1001: // Play sound effect
							case 0x1002: // Spawn
							case 0x6000: // Play Animation
							case 0x6001: // Loop animation
								activeScript.writeShort(b.readShort());
								trace(command.toString(16));
								break;
							
							//2 Extra Shorts
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