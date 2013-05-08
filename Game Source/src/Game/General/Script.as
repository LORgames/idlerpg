package Game.General {
	import flash.geom.PerspectiveProjection;
	import flash.utils.ByteArray;
	import Game.Critter.Person;
	import SoundSystem.EffectsPlayer;
	/**
	 * ...
	 * @author Paul
	 */
	public class Script {
		private var commands:ByteArray
		
		public function Script(commandBlock:ByteArray) {
			commands = commandBlock;
		}
		
		public function Run(invoker:Object = null):void {
			//Reset the reader
			commands.position = 0;
			
			//Some required variables
			var command:uint = 0;
			
			while (true) {
				command = commands.readUnsignedShort();
				
				if (command == 0xF0FF) break;
				
				switch(command) {
					case 0x0001: //Play sound effect
						EffectsPlayer.Play(commands.readShort());
						break;
					case 0x3001: //Equip item on the invoker
						if (invoker is Person) {
							var person:Person = (invoker as Person);
							person.equipment.EquipSlot(commands.readShort(), commands.readShort());
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
			var commandBlock:ByteArray = new ByteArray();
			
			while (command != 0xF0FF) {
				command = b.readUnsignedShort();
				commandBlock.writeShort(command);
				
				if (command == 0xF0FF) break; //Exit early if script has ended
				
				switch(command) {
					case 0x0001: //Play sound effect
						commandBlock.writeShort(b.readShort()); // The sound ID
						break;
					case 0x3001: //Equip item on the invoker
						commandBlock.writeShort(b.readShort());
						commandBlock.writeShort(b.readShort());
						break;
				}
			}
			
			return new Script(commandBlock);
		}
		
	}

}