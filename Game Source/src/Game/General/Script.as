package Game.General {
	import adobe.utils.CustomActions;
	import CollisionSystem.Rect;
	import flash.display.Sprite;
	import flash.geom.PerspectiveProjection;
	import flash.utils.ByteArray;
	import Game.Critter.BaseCritter;
	import Game.Critter.CritterManager;
	import Game.Critter.CritterHuman;
	import Game.Equipment.EquipmentItem;
	import Game.Map.ObjectInstance;
	import Game.Map.WorldData;
	import Interfaces.IMapObject;
	import RenderSystem.IObjectLayer;
	import RenderSystem.DebugDrawingHelper;
	import SoundSystem.EffectsPlayer;
	/**
	 * ...
	 * @author Paul
	 */
	public class Script {
		//EVENT TYPES
		public static const Attack:uint = 0;
		public static const Spawn:uint = 1;
		public static const Attacked:uint = 2;
		public static const Use:uint = 3;
		public static const Equip:uint = 4;
		public static const MinionDied:uint = 5;
		public static const AnimationEnded:uint = 6;
		public static const StartMoving:uint = 7;
		public static const EndMoving:uint = 8;
		public static const TOTAL_EVENT_TYPES:uint = 9;
		
		//SCRIPT TYPES
		public static const CRITTER:int = 0xA000;
		public static const ENEMY:int = 0xA001;
		public static const ATTACKABLE:int = 0xA002;
		public static const ALLY:int = 0xA003;
		
		//SCRIPT ARRAYS
		public static const FRONT:int = 0x9000;
		public static const FRONTOFFSET:int = 0x9002;
		public static const AOE:int = 0x9001;
		
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
						
						var spawnX:int = 0;
						var spawnY:int = 0;
						
						if (target is BaseCritter) {
							var bc:BaseCritter = (target as BaseCritter);
							
							var critter:BaseCritter = CritterManager.I.CritterInfo[critterID].CreateCritter(bc.CurrentMap, bc.X, bc.Y);
						
							if(critter == null) {
								trace("Script error: Could not spawn CritterID=" + critterID + ": critter is null.");
							}
						}
						
						break;
					case 0x4001: //Equip item on the target
						if (target is CritterHuman) {
							var person:CritterHuman = (target as CritterHuman);
							person.Equipment.EquipSlot(EventScript.readShort(), EventScript.readShort());
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
					case 0x8002: //Foreach
						Process_ForEach(EventScript, invoker, target);
						break;
					default:
						trace("Unknown Command: 0x" + command.toString(16));
				}
			}
		}
		
		private function Process_ForEach(eventScript:ByteArray, invoker:Object, target:Object):void {
			var eType:int = eventScript.readUnsignedShort();
			var arrayType:int = eventScript.readUnsignedShort();
			
			trace("Looking for: 0x" + eType.toString(16));
			
			var dim0:int;
			var dim1:int;
			var dim2:int;
			var rect:Rect = new Rect(false, null);
			
			var Objects:Vector.<IMapObject> = new Vector.<IMapObject>();
			
			while(arrayType != 0xF0FD) {
				switch(arrayType) {
					case FRONT:
					case FRONTOFFSET:
						dim0 = eventScript.readUnsignedShort() * 24;
						dim1 = eventScript.readUnsignedShort() * 24;
						dim2 = (arrayType == FRONTOFFSET)?eventScript.readShort() : 0;
						
						if (target is BaseCritter) {
							var obj0:BaseCritter = (target as BaseCritter);
							
							if (obj0.direction < 2) { //Left or right
								rect.X = (obj0.direction == 1)? obj0.X : obj0.X - dim0; //if right center else offcenter
								rect.Y = obj0.Y - dim1 / 2;
								rect.W = dim0;
								rect.H = dim1;
								
								//calculate offsets
								/*if (obj0.direction == 0) { //Left
									rect.Y += dim2;
								} else { //right
									rect.Y -= dim2;
								}*/
							} else {
								rect.X = obj0.X - dim1 / 2;
								rect.Y = (obj0.direction == 3)? obj0.Y : obj0.Y - dim0; //if down center else offcenter
								rect.W = dim1;
								rect.H = dim0;
								
								//calculate offsets
								if (obj0.direction == 2) { //Up
									rect.X += dim2;
								} else { //Down
									rect.X -= dim2;
								}
							}
							
							obj0.CurrentMap.GetObjectsInArea(rect, Objects, eType, target);
							
							trace(dim2);
							DebugDrawingHelper.AddDebugRect(rect);
						} else {
							trace("FRONT is not available to non-critter systems.");
						}
						
						break;
					case AOE:
						dim0 = eventScript.readUnsignedShort() * 24;
						dim1 = dim0;
						
						trace("AOE: " + dim0 + "x" + dim1);
						
						break;
					default:
						trace("Unknown ArrayType.");
						break;
				}
				
				arrayType = eventScript.readUnsignedShort();
			}
			
			//Now we're in the loop bit :)
			var startIndex:int = eventScript.position;
			
			var obji:int = Objects.length;
			while(--obji > -1) {
				var obj:IMapObject = Objects[obji];
				
				var command:int = eventScript.readUnsignedShort();
				
				while (command != 0xF0FE) {
					switch(command) {
						case 0x1003: //Damage
							dim0 = eventScript.readUnsignedShort();
							obj.ScriptAttack(false, false, dim0, (target as IMapObject));
							trace("FlatDamage: " + dim0);
							break;
					}
					
					command = eventScript.readUnsignedShort();
				}
				
				eventScript.position = startIndex;
			}
			
			ReadUntilBalancedClose(eventScript);
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
					} else if (command == 0xF0FD) {
						WriteUntilBalancedCloseBlock(b, activeScript);
					}
				}
			}
			
			return new Script(commandBlock);
		}
		
		static private function WriteUntilBalancedCloseBlock(b:ByteArray, activeScript:ByteArray):void {
			//This function should only get called after reading this...
			activeScript.writeShort(0xF0FD);
			
			var i:int = 0;
			var level:int = 1;
			
			while (level != 0) {
				i = b.readUnsignedShort();
				
				if (i == 0xF0FD) { //Open block
					level++;
				} else if (i == 0xF0FE) { //Close block
					level--;
				}
				
				activeScript.writeShort(i);
			}
		}
		
		private function ReadUntilBalancedClose(b:ByteArray):void {
			var i:int = 0;
			var level:int = 1;
			
			while (level != 0) {
				i = b.readUnsignedShort();
				
				if (i == 0xF0FD) { //Open block
					level++;
				} else if (i == 0xF0FE) { //Close block
					level--;
				}
			}
		}
	}

}