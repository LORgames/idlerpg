package Game.Scripting {
	import CollisionSystem.PointX;
	import CollisionSystem.Rect;
	import Debug.Drawer;
	import EngineTiming.Clock;
	import EngineTiming.ICleanUp;
	import flash.geom.Point;
	import flash.utils.ByteArray;
	import Game.Critter.BaseCritter;
	import Game.Critter.CritterHuman;
	import Game.Critter.CritterManager;
	import Game.Effects.EffectInfo;
	import Game.Effects.EffectInstance;
	import Game.Effects.EffectManager;
	import Game.Equipment.EquipmentItem;
	import Game.Map.Objects.ObjectInstance;
	import Game.Map.Objects.ObjectInstanceAnimated;
	import Game.Map.Objects.ObjectTemplate;
	import Game.Map.WorldData;
	import Interfaces.IMapObject;
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
		public static const OnEnter:uint = 4;
		public static const MinionDied:uint = 5;
		public static const AnimationEnded:uint = 6;
		public static const OnExit:uint = 6;
		public static const StartMoving:uint = 7;
		public static const EndMoving:uint = 8;
		public static const Died:uint = 9;
		public static const Update:uint = 10;
		public static const OnTrigger:uint = 11;
		public static const TOTAL_EVENT_TYPES:uint = 12;
		
		//SCRIPT TYPES
		public static const CRITTER:int = 0xA000;
		public static const ENEMY:int = 0xA001;
		public static const ATTACKABLE:int = 0xA002;
		public static const ALLY:int = 0xA003;
		
		//SCRIPT ARRAYS
		public static const FRONT:int = 0x9000;
		public static const FRONTOFFSET:int = 0x9002;
		public static const AOE:int = 0x9001;
		public static const MYAREA:int = 0x9003;
		
		//Script information
		internal var EventScripts:Vector.<ByteArray>;
		internal var InitialVariables:Vector.<int>;
		
		public function Script(commandBlock:Vector.<ByteArray>, initalVariables:Vector.<int>) {
			EventScripts = commandBlock;
			InitialVariables = initalVariables.concat();
		}
		
		internal function Run(eventID:uint, info:ScriptInstance):void {
			//Reset the reader
			if (eventID >= TOTAL_EVENT_TYPES) return;
			if (EventScripts[eventID] == null) return;
			
			var EventScript:ByteArray = EventScripts[eventID];
			EventScript.position = 0;
			
			//trace("Running: Invoker=" + info.Invoker + " Event=" + eventID);
			ProcessBlock(EventScript, info, eventID);
			
			if (EventScript.position != EventScript.length) {
				trace("SCRIPT UNFINISHED: [" + info.Invoker + " Event="+eventID+ " ScriptPosition=" + EventScript.position + "/" + EventScript.length);
				if (EventScript.position + 2 <= EventScript.length) {
					trace("\t\tEOF: 0x" + MathsEx.ZeroPad(EventScript.readUnsignedShort(), 0, 16));
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
							nextValue = GlobalVariables.Variables[eventScript.readShort()]; break;
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
			} else if (SaveVarType == 0xBFFE) { //Global variable
				info.Variables[SaveVarID] = runningTally;
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
				//trace("\t0x" + MathsEx.ZeroPad(command, 4, 16) + " IFPARAM");
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
						currentUnprocessedValue = (info.Invoker.GetCurrentState() == eventScript.readUnsignedShort()); break;
					case 0x7007: //What direction am I facing
						currentUnprocessedValue = (position.D == eventScript.readUnsignedShort()); break;
					case 0x7008: //What faction do i belong to
						if (info.CurrentTarget is BaseCritter) {
							currentUnprocessedValue =  ((info.CurrentTarget as BaseCritter).PrimaryFaction == eventScript.readShort());
						} else {
							trace("Unknown target for 0x7008 Target=" + info.CurrentTarget + " Faction=" + eventScript.readShort());
						} break;
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
						}
						
						break;
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
		
		private function Process_ForEach(eventScript:ByteArray, info:ScriptInstance, position:PointX, eventID:int):void {
			var eType:int = eventScript.readUnsignedShort();
			var arrayType:int = eventScript.readUnsignedShort();
			
			var dim0:int;
			var dim1:int;
			var dim2:int;
			var rect:Rect = new Rect(false, null);
			
			var Objects:Vector.<IScriptTarget> = new Vector.<IScriptTarget>();
			
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
					case MYAREA:
						//something :)
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
				var target:IScriptTarget = Objects[obji];
				info.AttachTarget(target);
				
				ProcessBlock(eventScript, info, eventID);
				
				info.PopTarget();
				eventScript.position = startIndex;
			}
			
			ReadUntilBalancedClose(eventScript);
		}
		
		
		private function GetNumberFromVariable(eventScript:ByteArray, info:ScriptInstance):int {
			var varType:int = eventScript.readUnsignedShort();
			var varID:int = eventScript.readShort();
			
			if (varType == 0xBFFD) { //Local variable
				return info.Variables[varID];
			} else if (varType == 0xBFFE) { //Global variable
				return GlobalVariables.Variables[varID];
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
						//activeScript.writeShort(0xFFFF);
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
		
		private function CalculateOffset(myPos:PointX, myOffset:PointX, retVal:PointX):void {
			if (myPos.D == 0) {
				retVal.X = myPos.X - myOffset.X;
				retVal.Y = myPos.Y + myOffset.Y;
			} else if (myPos.D == 1) {
				retVal.X = myPos.X + myOffset.X;
				retVal.Y = myPos.Y + myOffset.Y;
			} else if (myPos.D == 2) {
				retVal.Y = myPos.Y - myOffset.X;
				retVal.X = myPos.X + myOffset.Y;
			} else if (myPos.D == 3) {
				retVal.Y = myPos.Y + myOffset.X;
				retVal.X = myPos.X - myOffset.Y;
			}
		}
		
		private function ProcessBlock(EventScript:ByteArray, info:ScriptInstance, eventID:int):void {
			var effectInfo:EffectInfo;
			
			//Some required variables
			var command:uint = 0;
			var CallStack:Vector.<Boolean> = new Vector.<Boolean>();
			var bParam:Boolean;
			
			var deep:int = 0;
			
			var Position:PointX = new PointX();
			info.CurrentTarget.UpdatePointX(Position);
			
			//var tX:int = Position.X;
			//var tY:int = Position.Y;
			var p0:PointX = new PointX();
			var p1:PointX = new PointX();
			
			while (true) {
				command = EventScript.readUnsignedShort();
				//trace("\t0x" + MathsEx.ZeroPad(command, 4, 16) + " Deep=" + deep + " CurrentTarget=" + info.CurrentTarget);
				
				if (command == 0xFFFF) { break; }
				if (command == 0xB000) { ProcessMathCommand(EventScript, info); continue; }
				
				switch(command) {
					case 0x1001: //Play sound effect
						EffectsPlayer.Play(EventScript.readShort()); break;
					case 0x1002: //Spawn Critter
						p0.D = EventScript.readShort(); p0.X = EventScript.readShort(); p0.Y = EventScript.readShort();
						CalculateOffset(Position, p0, p1);
						
						var critter:BaseCritter = CritterManager.I.CritterInfo[p0.D].CreateCritter(WorldData.CurrentMap, p1.X, p1.Y);
						
						if(info.CurrentTarget is BaseCritter) critter.PrimaryFaction = (info.CurrentTarget as BaseCritter).PrimaryFaction;
						if (critter != null) { critter.Owner = info.CurrentTarget; } break;
					case 0x1003: //Flat Damage
					case 0x1005: //% Damage
					case 0x1006: //Flat DOT
					case 0x100C: //% DOT
						if(info.CurrentTarget is IMapObject) {
							(info.CurrentTarget as IMapObject).ScriptAttack((command==0x1005||command==0x100C), (command==0x1006||command==0x100C), EventScript.readUnsignedShort(), info.Invoker); break;
						} break;
					case 0x1007: //Destroy
						if (info.CurrentTarget is ICleanUp) { Clock.CleanUpList.push(info.CurrentTarget); } break;
					case 0x1008: //EffectSpawn
						effectInfo = EffectManager.I.Effects[EventScript.readShort()];
						p0.X = EventScript.readShort(); p0.Y = EventScript.readShort();
						CalculateOffset(Position, p0, p1);
						
						new EffectInstance(effectInfo, p1.X, p1.Y, Position.D);
						
						break;
					case 0x1009: //EffectSpawnDirectional
						effectInfo = EffectManager.I.Effects[EventScript.readShort()];
						p0.X = Position.X + EventScript.readShort(); p0.Y = Position.Y + EventScript.readShort();
						new EffectInstance(effectInfo, p0.X, p0.Y, EventScript.readShort()); break;
					case 0x100A: //EffectSpawnDirectionalRelative
						effectInfo = EffectManager.I.Effects[EventScript.readShort()];
						
						p0.X = Position.X + EventScript.readShort(); p0.X = Position.Y + EventScript.readShort();
						var direction:int = EventScript.readShort(); var tD:int = 0;
						
						switch (Position.D) {
							case 0: //critter left
								switch (direction) {
									case 0: //relative left
										tD = 3; //down
										break;
									case 1: //relative right
										tD = 2; //up
										break;
									case 2: //relative up
										tD = 0; //left
										break;
									case 3: //relative down
										tD = 1; //right
										break;
								}
								break;
							case 1: //critter right
								switch (direction) {
									case 0: //relative left
										tD = 2; //up
										break;
									case 1: //relative right
										tD = 3; //down
										break;
									case 2: //relative up
										tD = 1; //right
										break;
									case 3: //relative down
										tD = 0; //left
										break;
								}
								break;
							case 2: //critter up
								switch (direction) {
									case 0: //relative left
										tD = 0; //left
										break;
									case 1: //relative right
										tD = 1; //right
										break;
									case 2: //relative up
										tD = 2; //up
										break;
									case 3: //relative down
										tD = 3; //down
										break;
								}
								break;
							case 3: //critter down
								switch (direction) {
									case 0: //relative left
										tD = 1; //right
										break;
									case 1: //relative right
										tD = 0; //left
										break;
									case 2: //relative up
										tD = 3; //down
										break;
									case 3: //relative down
										tD = 2; //up
										break;
								}
								break;
						}
						
						new EffectInstance(effectInfo, p0.X, p0.Y, tD);
		
						break;
					case 0x100B: //SpawnObject
						var id:int = EventScript.readShort();
						
						p0.X = EventScript.readShort(); p0.Y = EventScript.readShort();
						CalculateOffset(Position, p0, p1);
						
						var o:ObjectInstance;
						
						if (ObjectTemplate.Objects[id].IndividualAnimations) {
							o = new ObjectInstanceAnimated();
						} else {
							o = new ObjectInstance();
						}
						
						o.SetInformation(WorldData.CurrentMap, id, p1.X, p1.Y);
						WorldData.CurrentMap.Objects.push(o);
						
						break;
					case 0x100D: //Fire a trigger
						Script.FireTrigger(EventScript.readShort()); break;
					case 0x100E: //Play a sound from an effect group
						EffectsPlayer.PlayFromGroup(EventScript.readShort()); break;
					case 0x4001: //Equip item on the target
						if (info.CurrentTarget is CritterHuman) {
							(info.CurrentTarget as CritterHuman).Equipment.EquipSlot(EventScript.readShort(), EventScript.readShort());
						} else if (info.CurrentTarget is EquipmentItem) {
							(info.CurrentTarget as EquipmentItem).Owner.EquipSlot(EventScript.readShort(), EventScript.readShort());
						} else {
							EventScript.readShort(); EventScript.readShort();
						} break;
					case 0x5001: //Movement speed
						if (info.CurrentTarget is BaseCritter) { 
							(info.CurrentTarget as BaseCritter).MovementSpeed = EventScript.readShort();
						} break;
					case 0x5002: //Movement direction absolute
					case 0x5003: //Movement direction relative
						if (info.CurrentTarget is BaseCritter) {
							var angle:Number = Math.PI * (EventScript.readShort() / 180.0);
							var move:Boolean = (EventScript.readShort() == 1);
							if (command == 0x5002) {
								(info.CurrentTarget as BaseCritter).RequestMove(Math.cos(angle), Math.sin(angle), move);
							} else if (command == 0x5003) {
								var c:BaseCritter = (info.CurrentTarget as BaseCritter);
								angle += Math.atan2(c.virginMoveSpeedY, c.virginMoveSpeedX);								
								c.RequestMove(Math.cos(angle), Math.sin(angle), move);
							}
						} else {
							trace("0x5003 WRONG TARGET! " + info.CurrentTarget + " @" + eventID);
							EventScript.readShort(); EventScript.readShort(); //Remove the two shorts
						} break;
					case 0x5004: //Set Faction
						if (info.CurrentTarget is BaseCritter) { 
							(info.CurrentTarget as BaseCritter).PrimaryFaction = EventScript.readShort();
						} break;
					case 0x5005: //Movement stop
						if (info.CurrentTarget is BaseCritter) { 
							(info.CurrentTarget as BaseCritter).RequestMove(0, 0);
						} break;
					case 0x5006: //Get Target From Owner
						if (info.CurrentTarget is BaseCritter && ((info.CurrentTarget as BaseCritter).Owner as BaseCritter) != null) {
							(info.CurrentTarget as BaseCritter).CurrentTarget = ((info.CurrentTarget as BaseCritter).Owner as BaseCritter).CurrentTarget;
						} break;
					case 0x6000: //Play Animation
						info.Invoker.ChangeState(EventScript.readShort(), false); break;
					case 0x6001: //Loop Animation
						info.Invoker.ChangeState(EventScript.readShort(), true); break;
					case 0x6002: //Animation Speed
						info.Invoker.UpdatePlaybackSpeed((EventScript.readUnsignedShort() * 0.01)); break;
					case 0x8000: //IF without ELSE
						bParam = CanIf(EventScript, info, Position);
						if (!bParam) {
							EventScript.readUnsignedShort(); //Just pop the 0xF0FD off
							ReadUntilBalancedClose(EventScript);
						} else {
							ProcessBlock(EventScript, info, eventID);
						} break;
					case 0x8001: //IF with ELSE
						bParam = CanIf(EventScript, info, Position);
						if (bParam) {
							CallStack.push(true);
							ProcessBlock(EventScript, info, eventID);
						} else {
							EventScript.readUnsignedShort(); //Just pop the 0xF0FD off
							ReadUntilBalancedClose(EventScript);
							CallStack.push(false);
						} break;
					case 0x8002: //Foreach
						Process_ForEach(EventScript, info, Position, eventID);
						break;
					case 0x8003: //ELSE
						bParam = CallStack.pop();
						if (bParam) {
							EventScript.readUnsignedShort(); //Just pop the 0xF0FD off
							ReadUntilBalancedClose(EventScript);
						} else {
							ProcessBlock(EventScript, info, eventID);
						} break;
					default:
						if (command == 0xF0FD) {
							deep++;
						} else if (command == 0xF0FE) {
							if (deep <= 1) {
								return;
							}
							deep--;
						} else {
							trace("Unknown Command: 0x" + command.toString(16) + " Event="+eventID + " Position="+EventScript.position+" Length="+EventScript.length+" Invoker="+info.Invoker);
						}
						
						break;
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
		
		//This updates all the triggers when a trigger is fired
		internal static var TriggerListeners:Vector.<ScriptInstance> = new Vector.<ScriptInstance>();
		public static function FireTrigger(triggerID:int):void {
			//TODO: Make this actually work properly! (more details follow)
			//It should be able to support multiple triggers firing at the same time
			//Some kind of stack system would be ideal.
			for (var i:int = 0; i < UpdateScripts.length; i++) {
				TriggerListeners[i].Run(Script.OnTrigger);
			}
		}
	}

}