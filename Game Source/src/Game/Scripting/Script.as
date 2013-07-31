package Game.Scripting {
	import adobe.utils.CustomActions;
	import CollisionSystem.PointX;
	import CollisionSystem.Rect;
	import Debug.Drawer;
	import EngineTiming.Clock;
	import EngineTiming.ICleanUp;
	import flash.display.Sprite;
	import flash.geom.PerspectiveProjection;
	import flash.geom.Point;
	import flash.geom.Vector3D;
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
		public static const Initialize:uint = 1;
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
		
		//Script information
		internal var EventScripts:Vector.<ByteArray>;
		internal var InitialVariables:Vector.<int>;
		
		public function Script(commandBlock:Vector.<ByteArray>, initalVariables:Vector.<int>) {
			EventScripts = commandBlock;
			InitialVariables = initalVariables.concat();
		}
		
		internal function Run(event:uint, info:ScriptInstance):void {
			//Reset the reader
			if (event >= TOTAL_EVENT_TYPES) {
				trace("Event Type Unsupported!");
				return;
			}
			
			if (EventScripts[event] == null) {
				//trace("Event type not on this object. [" + invoker + " => " + event + "]");
				return;
			}
			
			var EventScript:ByteArray = EventScripts[event];
			EventScript.position = 0;
			
			//Some required variables
			var command:uint = 0;
			var CallStack:Vector.<Boolean> = new Vector.<Boolean>();
			var bParam:Boolean;
			
			var Position:PointX = new PointX();
			info.CurrentTarget.UpdatePointX(Position);
			
			var tX:int = Position.X;
			var tY:int = Position.Y;
			
			while (true) {
				command = EventScript.readUnsignedShort();
				
				if (command == 0xFFFF) break;
				if (command == 0xB000) { ProcessMathCommand(EventScript, info); continue; }
				
				switch(command) {
					case 0x1001: //Play sound effect
						EffectsPlayer.Play(EventScript.readShort());
						break;
					case 0x1002: //Spawn Critter
						var critter:BaseCritter = CritterManager.I.CritterInfo[EventScript.readShort()].CreateCritter(WorldData.CurrentMap, Position.X, Position.Y);
						if (critter != null) { critter.Owner = info.CurrentTarget; } break;
					case 0x1007: //Destroy
						if (info.CurrentTarget is ICleanUp) { Clock.CleanUpList.push(info.CurrentTarget); } break;
					case 0x1008: //SpawnEffect
						var effectInfo:EffectInfo = EffectManager.I.Effects[EventScript.readShort()];
						
						if (Position.D == 0) {
							tX = Position.X - EventScript.readShort();
							tY = Position.Y + EventScript.readShort();
						} else if (Position.D == 1) {
							tX = Position.X + EventScript.readShort();
							tY = Position.Y + EventScript.readShort();
						} else if (Position.D == 2) {
							tY = Position.Y - EventScript.readShort();
							tX = Position.X + EventScript.readShort();
						} else if (Position.D == 3) {
							tY = Position.Y + EventScript.readShort();
							tX = Position.X - EventScript.readShort();
						}
						
						new EffectInstance(effectInfo, tX, tY, Position.D);
						
						break;
					case 0x100B: //SpawnObject
						var id:int = EventScript.readShort();
						
						if (Position.D == 0) {
							tX = Position.X - EventScript.readShort();
							tY = Position.Y + EventScript.readShort();
						} else if (Position.D == 1) {
							tX = Position.X + EventScript.readShort();
							tY = Position.Y + EventScript.readShort();
						} else if (Position.D == 2) {
							tY = Position.Y - EventScript.readShort();
							tX = Position.X + EventScript.readShort();
						} else if (Position.D == 3) {
							tY = Position.Y + EventScript.readShort();
							tX = Position.X - EventScript.readShort();
						}
						
						var o:ObjectInstance;
						
						if (ObjectTemplate.Objects[id].IndividualAnimations) {
							o = new ObjectInstanceAnimated();
						} else {
							o = new ObjectInstance();
						}
						
						o.SetInformation(WorldData.CurrentMap, id, tX, tY);
						WorldData.CurrentMap.Objects.push(o);
						
						break;
					case 0x4001: //Equip item on the target
						if (info.CurrentTarget is CritterHuman) {
							(info.CurrentTarget as CritterHuman).Equipment.EquipSlot(EventScript.readShort(), EventScript.readShort());
						} else if (info.CurrentTarget is EquipmentItem) {
							(info.CurrentTarget as EquipmentItem).Owner.EquipSlot(EventScript.readShort(), EventScript.readShort());
						} else {
							EventScript.readShort(); EventScript.readShort();
						} break;
					case 0x6000: //Play Animation
						info.CurrentTarget.ChangeState(EventScript.readShort(), false); break;
					case 0x6001: //Loop Animation
						info.CurrentTarget.ChangeState(EventScript.readShort(), true); break;
					case 0x6002: //Animation Speed
						info.CurrentTarget.UpdatePlaybackSpeed((EventScript.readUnsignedShort() * 0.05)); break;
					case 0x8000: //IF without ELSE
						bParam = CanIf(EventScript, info, Position);
						if (!bParam) {
							EventScript.readUnsignedShort(); //Just pop the 0xF0FD off
							ReadUntilBalancedClose(EventScript);
						} break;
					case 0x8001: //IF with ELSE
						bParam = CanIf(EventScript, info, Position);
						if (bParam) {
							CallStack.push(true);
						} else {
							EventScript.readUnsignedShort(); //Just pop the 0xF0FD off
							ReadUntilBalancedClose(EventScript);
							CallStack.push(false);
						} break;
					case 0x8002: //Foreach
						Process_ForEach(EventScript, info, Position);
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
		
		private function ProcessMathCommand(eventScript:ByteArray, info:ScriptInstance):void {
			var SaveVarType:int = eventScript.readUnsignedShort();
			var SaveVarID:int = eventScript.readShort();
			
			var runningTally:int = 0;
			var nextValue:int = 0;
			var currentOperation:int = 0xB001; //Set operation to ADDITION
			
			var nextVarType:int;
			
			while (true) {
				nextVarType = eventScript.readUnsignedShort();
				
				if (nextVarType == 0xBF01) break;
				
				if (nextVarType > 0xBFF0) { //is a variable
					switch (nextVarType) {
						case 0xBFFF: //Static value
							nextValue = eventScript.readShort(); break;
						case 0xBFFD: //Local variable
							nextValue = info.Variables[eventScript.readShort()]; break;
						case 0xBFFE: //Global variable
							//TODO: Update this when global variables are implemented.
							break;
						default:
							trace("Unknown variable type");
							break;
					}
					
					//apply the operation :)
					switch (currentOperation) {
						case 0xB001: //Addition
							runningTally += nextValue; break;
						case 0xB002: //Subtraction
							runningTally -= nextValue; break;
						case 0xB003: //Multiplation
							runningTally *= nextValue; break;
						case 0xB004: //Division
							runningTally /= nextValue; break;
						case 0xB005: //Modulus
							runningTally %= nextValue; break;
						default:
							trace("Unknown math operation!");
							break;
					}
				} else { //is an operation hopefully
					currentOperation = nextVarType;
				}
			}
			
			if (SaveVarType == 0xBFFD) { //Local variable
				info.Variables[SaveVarID] = runningTally;
			} else if (SaveVarType == 0xBFFE) {
				//TODO: Implement this when global variables are added
			}
		}
		
		/**
		 * Processes the conditionals for an IF block and returns true or false if that IF is processable
		 * @param	eventScript	The current scriptblock we're processing.
		 * @param	invoker	The current object running the script
		 * @param	target	The target of the script if any
		 * @return	How the IF evaluated, true or false.
		 */
		private function CanIf(eventScript:ByteArray, info:ScriptInstance, position:PointX):Boolean {
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
						currentUnprocessedValue = CanIf(eventScript, info, position);
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
						if (info.CurrentTarget is BaseCritter) {
							currentUnprocessedValue = (info.CurrentTarget as BaseCritter).CurrentHP > 0;
						} else {
							currentUnprocessedValue = true;
						} break;
					case 0x7005: //Is an item equipped
						if (info.CurrentTarget is CritterHuman) {
							currentUnprocessedValue = (info.CurrentTarget as CritterHuman).Equipment.IsEquipped(eventScript.readUnsignedShort(), eventScript.readUnsignedShort());
						} else {
							trace("Unknown invoker for if equipped");
						}
						break;
					case 0x7006: //Is an animation playing
						currentUnprocessedValue = (info.CurrentTarget.GetCurrentState() == eventScript.readUnsignedShort()); break;
					case 0x7007: //What direction am I facing
						currentUnprocessedValue = (position.D == eventScript.readUnsignedShort()); break;
					case 0x7009: //Math comparison function
						var value1:int = GetNumberFromVariable(eventScript, info);
						var comparisonInstruction:int = eventScript.readUnsignedShort();
						var value2:int = GetNumberFromVariable(eventScript, info);
						
						switch(comparisonInstruction) {
							case 0xBE00: currentUnprocessedValue = (value1 == value2); break; // =
							case 0xBE01: currentUnprocessedValue = (value1 < value2); break; // <
							case 0xBE02: currentUnprocessedValue = (value1 > value2); break; // >
							case 0xBE03: currentUnprocessedValue = (value1 <= value2); break; // <=
							case 0xBE04: currentUnprocessedValue = (value1 >= value2); break; // >=
							case 0xBE05: currentUnprocessedValue = (value1 != value2); break; // !=
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
		
		private function Process_ForEach(eventScript:ByteArray, info:ScriptInstance, position:PointX):void {
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
						
						if (position.D < 2) { //Left or right
							rect.X = (position.D == 1)? position.X : position.X - dim0; //if right center else offcenter
							rect.Y = position.Y - dim1 / 2;
							rect.W = dim0;
							rect.H = dim1;
						} else {
							rect.X = position.X - dim1 / 2;
							rect.Y = (position.D == 3)? position.Y : position.Y - dim0; //if down center else offcenter
							rect.W = dim1;
							rect.H = dim0;
							
							//calculate offsets
							if (position.D == 2) { //Up
								rect.X += dim2;
							} else { //Down
								rect.X -= dim2;
							}
						}
							
						WorldData.CurrentMap.GetObjectsInArea(rect, Objects, eType, info.CurrentTarget);
						Drawer.AddDebugRect(rect);
						
						break;
					case AOE:
						dim0 = eventScript.readUnsignedShort() * 24; dim1 = dim0; break;
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
							obj.ScriptAttack(false, false, dim0, info.CurrentTarget);
							break;
					}
					
					command = eventScript.readUnsignedShort();
				}
				
				eventScript.position = startIndex;
			}
			
			ReadUntilBalancedClose(eventScript);
		}
		
		
		private function GetNumberFromVariable(eventScript:ByteArray, info:ScriptInstance):int {
			var varType:int = eventScript.readUnsignedShort();
			var varID:int = eventScript.readShort();
			
			if (varType == 0xBFFD) {
				return info.Variables[varID];
			} else if (varType == 0xBFFE) {
				//TODO: Implement this when global variables are implemented
			}
			
			return varID; //Hopefully is a static number
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
			
			var totalVariables:int = b.readShort();
			var initialVariables:Vector.<int> = new Vector.<int>(totalVariables, true);
			
			while (--totalVariables > -1) {
				initialVariables[totalVariables] = b.readShort();
			}
			
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
			
			return new Script(commandBlock, initialVariables);
			initialVariables = null;
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
		
		//This updates the scripts if they have Update OR Clock methods
		internal static var UpdateScripts:Vector.<ScriptInstance> = new Vector.<ScriptInstance>();
		public static function ProcessUpdate():void {
			for (var i:int = 0; i < UpdateScripts.length; i++) {
				UpdateScripts[i].Run(Script.Update);
			}
		}
	}

}