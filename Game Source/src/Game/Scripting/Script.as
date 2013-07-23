package Game.Scripting {
	import adobe.utils.CustomActions;
	import CollisionSystem.Rect;
	import Debug.Drawer;
	import EngineTiming.Clock;
	import flash.display.Sprite;
	import flash.geom.PerspectiveProjection;
	import flash.utils.ByteArray;
	import Game.Critter.BaseCritter;
	import Game.Critter.CritterAnimationSet;
	import Game.Critter.CritterManager;
	import Game.Critter.CritterHuman;
	import Game.Effects.EffectInfo;
	import Game.Effects.EffectInstance;
	import Game.Effects.EffectManager;
	import Game.Equipment.EquipmentItem;
	import Game.Map.Objects.ObjectInstance;
	import Game.Map.Objects.ObjectInstanceAnimated;
	import Game.Map.Objects.ObjectTemplate;
	import Game.Map.WorldData;
	import Interfaces.IMapObject;
	import RenderSystem.IObjectLayer;
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
		public static const Died:uint = 9;
		public static const Update:uint = 10;
		public static const TOTAL_EVENT_TYPES:uint = 11;
		
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
		
		
		private static var UpdateScripts:Vector.<Object> = new Vector.<Object>();
		public static function ProcessUpdate():void {
			for (var i:int = 0; i < UpdateScripts.length; i += 3) {
				var script:Script = Script(UpdateScripts[i]);
				script.Run(Update, UpdateScripts[i + 1], UpdateScripts[i + 2]);
			}
		}
		
		public function Script(commandBlock:Vector.<ByteArray>) {
			EventScripts = commandBlock;
		}
		
		public function Run(event:uint, invoker:Object = null, target:Object = null):void {
			//Reset the reader
			if (event >= TOTAL_EVENT_TYPES) {
				trace("Event Type Unsupported!");
				return;
			}
			
			if (event == Spawn && EventScripts[Update] != null) {
				UpdateScripts.push(this);
				UpdateScripts.push(invoker);
				UpdateScripts.push(target);
			}
			
			if (EventScripts[event] == null) {
				//trace("Event type not on this object. [" + invoker + " => " + event + "]");
				return;
			}
			
			if (target == null && invoker != null) {
				target = invoker;
			}
			
			var EventScript:ByteArray = EventScripts[event];
			EventScript.position = 0;
			
			//Some required variables
			var command:uint = 0;
			var CallStack:Vector.<Boolean> = new Vector.<Boolean>();
			var bParam:Boolean;
			var xPos:int = 0;
			var yPos:int = 0;
			var dir:int = 0;
			
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
						
						if (invoker is BaseCritter) {
							var bc:BaseCritter = (invoker as BaseCritter);
							
							var critter:BaseCritter = CritterManager.I.CritterInfo[critterID].CreateCritter(bc.CurrentMap, bc.X, bc.Y);
							
							if(critter == null) {
								trace("Script error: Could not spawn CritterID=" + critterID + ": critter is null.");
							} else {
								critter.Owner = bc;
							}
						}
						
						break;
					case 0x1007: //Destroy
						if (invoker is ObjectInstance || invoker is BaseCritter || invoker is EffectInstance) {
							Clock.CleanUpList.push(invoker);
						} else {
							trace("Unknown Type for Destroy!");
						}
						break;
					case 0x1008: //SpawnEffect
						var effectInfo:EffectInfo = EffectManager.I.Effects[EventScript.readShort()];
						
						if (invoker is BaseCritter) {
							xPos = (invoker as BaseCritter).X;
							yPos = (invoker as BaseCritter).Y;
							dir = (invoker as BaseCritter).direction;
						} else if (invoker is EffectInstance) {
							xPos = (invoker as EffectInstance).X;
							yPos = (invoker as EffectInstance).Y;
							dir = (invoker as EffectInstance).Direction;
						}
							
						if (dir == 0) {
							xPos -= EventScript.readShort();
							yPos += EventScript.readShort();
						} else if (dir == 1) {
							xPos += EventScript.readShort();
							yPos += EventScript.readShort();
						} else if (dir == 2) {
							yPos -= EventScript.readShort();
							xPos += EventScript.readShort();
						} else if (dir == 3) {
							yPos += EventScript.readShort();
							xPos -= EventScript.readShort();
						}
						
						new EffectInstance(effectInfo, xPos, yPos, dir);
						
						break;
					case 0x100B: //SpawnObject
						var id:int = EventScript.readShort();
						
						if (invoker is BaseCritter) {
							xPos = (invoker as BaseCritter).X;
							yPos = (invoker as BaseCritter).Y;
							dir = (invoker as BaseCritter).direction;
						} else if (invoker is EffectInstance) {
							xPos = (invoker as EffectInstance).X;
							yPos = (invoker as EffectInstance).Y;
							dir = (invoker as EffectInstance).Direction;
						}
							
						if (dir == 0) {
							xPos -= EventScript.readShort();
							yPos += EventScript.readShort();
						} else if (dir == 1) {
							xPos += EventScript.readShort();
							yPos += EventScript.readShort();
						} else if (dir == 2) {
							yPos -= EventScript.readShort();
							xPos += EventScript.readShort();
						} else if (dir == 3) {
							yPos += EventScript.readShort();
							xPos -= EventScript.readShort();
						}
						
						var o:ObjectInstance;
						
						if (ObjectTemplate.Objects[id].IndividualAnimations) {
							o = new ObjectInstanceAnimated();
						} else {
							o = new ObjectInstance();
						}
						
						o.SetInformation(WorldData.CurrentMap, id, xPos, yPos);
						WorldData.CurrentMap.Objects.push(o);
						
						break;
					case 0x4001: //Equip item on the target
						if (invoker is CritterHuman) {
							var person:CritterHuman = (invoker as CritterHuman);
							person.Equipment.EquipSlot(EventScript.readShort(), EventScript.readShort());
						} break;
					case 0x6000: //Play Animation
						if (target is EquipmentItem) {
							(target as EquipmentItem).SetState(EventScript.readShort(), false);
						} else if (target is CritterAnimationSet) { 
							(target as CritterAnimationSet).ChangeState(EventScript.readShort(), false);
						} else if (invoker is EffectInstance) { 
							(target as EffectInstance).ChangeState(EventScript.readShort(), false);
						} else {
							trace("Unknown Invoker for 0x6000:PlayAnimation");
							EventScript.readShort();
						} break;
					case 0x6001: //Loop Animation
						if (target is EquipmentItem) {
							(target as EquipmentItem).SetState(EventScript.readShort(), true);
						} else if (target is CritterAnimationSet) { 
							(target as CritterAnimationSet).ChangeState(EventScript.readShort(), true);
						} else if (invoker is EffectInstance) { 
							(target as EffectInstance).ChangeState(EventScript.readShort(), true);
						} else {
							trace("Unknown Invoker for 0x6001:LoopAnimation @" + event);
							EventScript.readShort();
						} break;
					case 0x6002: //Animation Speed
						var speedUI:uint = EventScript.readUnsignedShort();
						var speedNU:Number = (speedUI * 0.05);
						
						if (invoker is ObjectInstanceAnimated) {
							(target as ObjectInstanceAnimated).PlaybackSpeed = speedNU;
						} else if (invoker is ObjectInstance) {
							(invoker as ObjectInstance).Template.PlaybackSpeed = speedNU;
						} else if (invoker is EffectInstance) { 
							(target as EffectInstance).PlaybackSpeed = speedNU;
						} else {
							trace("Unknown invoker for AnimationSpeed");
						} break;
					case 0x6003: //Animation Range Play
					case 0x6004: //Animation Range Loop
						var startFrame:int = EventScript.readUnsignedShort();
						var totalFrames:int = EventScript.readUnsignedShort();
						
						if (invoker is ObjectInstanceAnimated) {
							(invoker as ObjectInstanceAnimated).StartFrame = startFrame;
							(invoker as ObjectInstanceAnimated).EndFrame = totalFrames+startFrame;
							(invoker as ObjectInstanceAnimated).CurrentFrame = startFrame;
							
							if (command == 0x6003) {
								(invoker as ObjectInstanceAnimated).IsLooping = false;
							} else {
								(invoker as ObjectInstanceAnimated).IsLooping = true;
							}
						} else {
							trace("Unknown invoker for AnimationRnage[Play/Loop]");
						} break;
					case 0x8000: //IF without ELSE
						bParam = CanIf(EventScript, invoker, target);
						if (!bParam) {
							EventScript.readUnsignedShort(); //Just pop the 0xF0FD off
							ReadUntilBalancedClose(EventScript);
						} break;
					case 0x8001: //IF with ELSE
						bParam = CanIf(EventScript, invoker, target);
						if (bParam) {
							CallStack.push(true);
						} else {
							EventScript.readUnsignedShort(); //Just pop the 0xF0FD off
							ReadUntilBalancedClose(EventScript);
							CallStack.push(false);
						} break;
					case 0x8002: //Foreach
						Process_ForEach(EventScript, invoker, target);
						break;
					case 0x8003: //ELSE
						bParam = CallStack.pop();
						if (bParam) {
							EventScript.readUnsignedShort(); //Just pop the 0xF0FD off
							ReadUntilBalancedClose(EventScript);
						} break;
					default:
						if(command != 0xF0FD && command != 0xF0FE) {
							trace("Unknown Command: 0x" + command.toString(16));
						} break;
						break;
				}
			}
		}
		
		/**
		 * Processes the conditionals for an IF block and returns true or false if that IF is processable
		 * @param	eventScript	The current scriptblock we're processing.
		 * @param	invoker	The current object running the script
		 * @param	target	The target of the script if any
		 * @return	How the IF evaluated, true or false.
		 */
		private function CanIf(eventScript:ByteArray, invoker:Object, target:Object):Boolean {
			//Running values
			var currentCalculatedValue:Boolean = true;
			var currentUnprocessedValue:Boolean = true;
			
			//Which operation to perform: 0 for AND, 1 for OR
			var currentOperation:int = 0;
			var isNOTblock:Boolean = false;
			
			//The current command, need to remove the top of the stack here because its 0xFF0D
			var command:int = eventScript.readUnsignedShort();
			var ended:Boolean = false;
			var param0:int;
			
			while (!ended) {
				command = eventScript.readUnsignedShort();
				currentUnprocessedValue = true;
				
				switch(command) {
					case 0xF0FE:
						ended = true;
						break;
					case 0xF0FD:
						currentUnprocessedValue = CanIf(eventScript, invoker, target);
						trace("\nNested IF:" + currentUnprocessedValue);
						break;
					case 0x7000: currentOperation = 0; break; //AND
					case 0x7001: currentOperation = 1; break; //OR
					case 0x7002: isNOTblock = true; break; //NOT
					case 0x7003: //Random chance
						param0 = eventScript.readUnsignedShort();
						currentUnprocessedValue = Math.random() * 100 < param0;
						break;
					case 0x7004: //Is the script owner alive
						if (invoker is BaseCritter) {
							currentUnprocessedValue = (invoker as BaseCritter).CurrentHP > 0;
						} else {
							trace("Unknown Invoker for 'Alive'");
						} break;
					case 0x7005: //Is an item equipped
						if (invoker is CritterHuman) {
							currentUnprocessedValue = (invoker as CritterHuman).Equipment.IsEquipped(eventScript.readUnsignedShort(), eventScript.readUnsignedShort());
						} else {
							trace("Unknown invoker for if equipped");
						}
						break;
					case 0x7006: //Is an animation playing
						param0 = eventScript.readUnsignedShort();
						if (target is CritterAnimationSet) {
							currentUnprocessedValue = (target as CritterAnimationSet).CurrentAnim() == param0;
						} else if (target is EquipmentItem) {
							currentUnprocessedValue = (target as EquipmentItem).currentState == param0;
						} else {
							trace("\t@0x7006: Unknown target for Animation(playing)");
						} break;
					case 0x7007: //What direction am I facing
						param0 = eventScript.readUnsignedShort();
						if (invoker is BaseCritter) {
							currentUnprocessedValue = ((invoker as BaseCritter).direction == param0);
						} else if (invoker is EffectInstance) {
							currentUnprocessedValue = ((invoker as EffectInstance).Direction == param0);
						} else {
							trace("\t@0x7007: Unknown invoker for Direction(facing)");
						} break;
					case 0x7008: //What is the current frame
						param0 = eventScript.readUnsignedShort();
						if (invoker is ObjectInstanceAnimated) {
							currentUnprocessedValue = ((invoker as ObjectInstanceAnimated).CurrentFrame == param0);
						} else if (invoker is ObjectInstance) {
							currentUnprocessedValue = ((invoker as ObjectInstance).Template.CurrentFrame == param0);
						} else {
							trace("Unknown invoker for 0x7008:CurrentFrame invoker=" + invoker);
						} break;
					default:
						trace("@0x" + command.toString(16) + ": Unknown Conditional.");
						break;
				}
				
				if (command != 0xF0FE && command != 0x7000 && command != 0x7001 && command != 0x7002) { //if not operation
					if (isNOTblock) {
						//trace("\tNOT " + currentUnprocessedValue);
						currentUnprocessedValue = !currentUnprocessedValue;
						isNOTblock = false;
					}
					
					if (currentOperation == 0) { //AND
						//trace("\tAND (" + currentCalculatedValue + " && " + currentUnprocessedValue + ") = " +(currentCalculatedValue && currentUnprocessedValue));
						currentCalculatedValue = (currentCalculatedValue && currentUnprocessedValue);
					} else if (currentOperation == 1) { //OR
						//trace("\tOR (" + currentCalculatedValue + " || " + currentUnprocessedValue + ") = " + (currentCalculatedValue || currentUnprocessedValue));
						currentCalculatedValue = (currentCalculatedValue || currentUnprocessedValue);
					}
				}
			}
			
			return currentCalculatedValue;
		}
		
		private function Process_ForEach(eventScript:ByteArray, invoker:Object, target:Object):void {
			var eType:int = eventScript.readUnsignedShort();
			var arrayType:int = eventScript.readUnsignedShort();
			
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
						
						var direction:int = 0;
						var xPos:int = 0;
						var yPos:int = 0;
						
						if (invoker is BaseCritter) {
							var obj0:BaseCritter = (invoker as BaseCritter);
							xPos = obj0.X;
							yPos = obj0.Y;
							direction = obj0.direction;
						} else if (invoker is EffectInstance) {
							var obj1:EffectInstance = (invoker as EffectInstance);
							xPos = obj1.X;
							yPos = obj1.Y;
							direction = obj1.Direction;
						} else {
 							trace("FRONT is not available to this system [" + invoker + "].");
							break;
						}
							
						if (direction < 2) { //Left or right
							rect.X = (direction == 1)? xPos : xPos - dim0; //if right center else offcenter
							rect.Y = yPos - dim1 / 2;
							rect.W = dim0;
							rect.H = dim1;
						} else {
							rect.X = xPos - dim1 / 2;
							rect.Y = (direction == 3)? yPos : yPos - dim0; //if down center else offcenter
							rect.W = dim1;
							rect.H = dim0;
							
							//calculate offsets
							if (direction == 2) { //Up
								rect.X += dim2;
							} else { //Down
								rect.X -= dim2;
							}
						}
							
						WorldData.CurrentMap.GetObjectsInArea(rect, Objects, eType, invoker);
						Drawer.AddDebugRect(rect);
						
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
							obj.ScriptAttack(false, false, dim0, (invoker as IMapObject));
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