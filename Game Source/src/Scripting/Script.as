package Scripting {
	import CollisionSystem.PointX;
	import CollisionSystem.Rect;
	import Debug.Drawer;
	import EngineTiming.Clock;
	import EngineTiming.ICleanUp;
	import flash.utils.ByteArray;
	import Game.Critter.BaseCritter;
	import Game.Critter.CritterHuman;
	import Game.Critter.CritterManager;
	import Game.Effects.EffectInfo;
	import Game.Effects.EffectInstance;
	import Game.Effects.EffectManager;
	import Game.Equipment.EquipmentItem;
	import Game.Tweening.TweenManager;
	import Loaders.BinaryLoader;
	import Game.Map.Objects.ObjectInstance;
	import Game.Map.Objects.ObjectInstanceAnimated;
	import Game.Map.Objects.ObjectTemplate;
	import Game.Map.WorldData;
	import Interfaces.IMapObject;
	import QDMF.Connectors.SocketClient;
	import QDMF.Connectors.SocketHost;
	import QDMF.PacketFactory;
	import SoundSystem.EffectsPlayer;
	import Strings.StringEx;
	import UI.UIElement;
	import UI.UILayer;
	import UI.UILayerLibrary;
	import UI.UILayerText;
	import UI.UIPanel;
	/**
	 * ...
	 * @author Paul
	 */
	public class Script {
		//EVENT TYPES
		public static const Attack:uint = 0;
		public static const Pressed:uint = 0;
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
		public static const AIEvent:uint = 12;
		public static const TOTAL_EVENT_TYPES:uint = 13;
		
		//SCRIPT TYPES
		public static const CRITTER:int = 0xA000;
		public static const ENEMY:int = 0xA001;
		public static const ATTACKABLE:int = 0xA002;
		public static const ALLY:int = 0xA003;
		
		//AI Events
		public static const AIEvent_TargetDied:int = 0x00;
        public static const AIEvent_TargetOutOfRange:int = 0x01;
        public static const AIEvent_TargetUntargetable:int = 0x02;
        public static const AIEvent_AttackedByNonTarget:int = 0x03;
        public static const AIEvent_OwnerChanged:int = 0x04;
        public static const AIEvent_FactionChanged:int = 0x05;
        public static const AIEvent_TargetChanged:int = 0x06;
		
		
		//SCRIPT ARRAYS
		public static const FRONT:int = 0x9000;
		public static const AOE:int = 0x9001;
		public static const MYAREA:int = 0x9003;
		public static const MAP:int = 0x9004;
		public static const FACTIONMAP:int = 0x9004;
		
		//Script information
		internal var EventScripts:Vector.<ByteArray>;
		internal var InitialVariables:Vector.<int>;
		internal var NetSync:int = 0;
		
		public function Script(commandBlock:Vector.<ByteArray>, initalVariables:Vector.<int>) {
			EventScripts = commandBlock;
			InitialVariables = initalVariables.concat();
		}
		
		internal function Run(eventID:uint, info:ScriptInstance, param:Object):void {
			//Reset the reader
			if (eventID >= EventScripts.length) return;
			if (EventScripts[eventID] == null) return;
			
			var EventScript:ByteArray = EventScripts[eventID];
			
			EventScript.position = 0;
			NetSync = 0;
			
			//Main.I.Log("Running: Invoker=" + info.Invoker + " Event=" + eventID + " CurrentTarget=" + info.CurrentTarget);
			ProcessBlock(EventScript, info, eventID, param);
			
			if (EventScript.position != EventScript.length) {
				Main.I.Log("SCRIPT UNFINISHED: [" + info.Invoker + " Event="+eventID+ " ScriptPosition=" + EventScript.position + "/" + EventScript.length);
				if (EventScript.position + 2 <= EventScript.length) {
					Main.I.Log("\t\tEOF: 0x" + MathsEx.ZeroPad(EventScript.readUnsignedShort(), 0, 16));
				}
			}
		}
		
		private function ProcessMathCommand(eventScript:ByteArray, info:ScriptInstance, param:Object):void {
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
					eventScript.position -= 2;
					nextValue = GetNumberFromVariable(eventScript, info, param);
					
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
						case 0xB006: //Binary OR
							runningTally |= nextValue; break;
						case 0xB007: //Binary AND
							runningTally &= nextValue; break;
						case 0xB008: //Binary XOR
							runningTally ^= nextValue; break;
						case 0xB009: //Binary NOT
							runningTally = ~nextValue; break;
						case 0xB00A: //Binary Left Shift
							runningTally = runningTally << nextValue; break;
						case 0xB00B: //Binary Right Shift
							runningTally = runningTally >> nextValue; break;
						default:
							Main.I.Log("Unknown math operation!");
							break;
					}
				} else { //is an operation hopefully
					currentOperation = nextVarType;
				}
			}
			
			if (SaveVarType == 0xBFFD) { //Local variable
				info.Variables[SaveVarID] = runningTally;
			} else if (SaveVarType == 0xBFFE) { //Global variable
				GlobalVariables.Variables[SaveVarID] = runningTally;
			}
		}
		
		/**
		 * Processes the conditionals for an IF block and returns true or false if that IF is processable
		 * @param	eventScript	The current scriptblock we're processing.
		 * @param	invoker	The current object running the script
		 * @param	target	The target of the script if any
		 * @return	How the IF evaluated, true or false.
		 */
		private function CanIf(eventScript:ByteArray, info:ScriptInstance, position:PointX, inputParam:Object):Boolean {
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
			var param1:int;
			var param2:int;
			
			while (!ended) {
				command = eventScript.readUnsignedShort();
				//Main.I.Log("\t0x" + MathsEx.ZeroPad(command, 4, 16) + " IFPARAM");
				currentUnprocessedValue = true;
				
				switch(command) {
					case 0xF0FE:
						ended = true;
						break;
					case 0xF0FD:
						currentUnprocessedValue = CanIf(eventScript, info, position, inputParam);
						Main.I.Log("\nNested IF:" + currentUnprocessedValue);
						break;
					case 0x7000: currentOperation = 0; break; //AND
					case 0x7001: currentOperation = 1; break; //OR
					case 0x7002: isNOTblock = true; break; //NOT
					case 0x7003: //Random chance
						param0 = GetNumberFromVariable(eventScript, info, inputParam);
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
							Main.I.Log("Unknown invoker for if equipped");
						}
						break;
					case 0x7006: //Is an animation playing
						currentUnprocessedValue = (info.Invoker.GetCurrentState() == eventScript.readUnsignedShort()); break;
					case 0x7007: //What direction am I facing
						currentUnprocessedValue = (position.D == eventScript.readUnsignedShort()); break;
					case 0x7008: //What faction do i belong to
						if (info.CurrentTarget is BaseCritter) {
							currentUnprocessedValue = ((info.CurrentTarget as BaseCritter).GetFaction() == eventScript.readShort());
						} else {
							Main.I.Log("Unknown target for 0x7008 Target=" + info.CurrentTarget + " Faction=" + eventScript.readShort());
						} break;
					case 0x7009: //Math comparison function
						param1 = GetNumberFromVariable(eventScript, info, inputParam);
						var comparisonInstruction:int = eventScript.readUnsignedShort();
						param2 = GetNumberFromVariable(eventScript, info, inputParam);
						
						switch(comparisonInstruction) {
							case 0xBE00: currentUnprocessedValue = (param1 == param2); break; // =
							case 0xBE01: currentUnprocessedValue = (param1 < param2); break; // <
							case 0xBE02: currentUnprocessedValue = (param1 > param2); break; // >
							case 0xBE03: currentUnprocessedValue = (param1 <= param2); break; // <=
							case 0xBE04: currentUnprocessedValue = (param1 >= param2); break; // >=
							case 0xBE05: currentUnprocessedValue = (param1 != param2); break; // !=
						}
						
						break;
					case 0x700A: //Spend Variable
						param0 = eventScript.readUnsignedShort();
						param1 = eventScript.readShort();
						param2 = 0;
						
						var cost:int = GetNumberFromVariable(eventScript, info, inputParam);
						
						if (param0 == 0xBFFD) { //Local
							param2 = info.Variables[param1];
						} else if (param0 == 0xBFFE) { //Global
							param2 = GlobalVariables.Variables[param1];
						}
						
						if (param2 >= cost) {
							param2 -= cost;
							
							if (param0 == 0xBFFD) { //Local
								info.Variables[param1] = param2;
							} else if (param0 == 0xBFFE) { //Global
								GlobalVariables.Variables[param1] = param2;
							}
							
							currentUnprocessedValue = true;
						} else {
							currentUnprocessedValue = false;
						}
						
						break;
					case 0x700B: //Has Target
						//TODO: this
						break;
					case 0x700C: //Has Buff
						//TODO: this
						break;
					case 0x700D: //Is In Group
						if (info.CurrentTarget is BaseCritter) {
							currentUnprocessedValue = ((info.CurrentTarget as BaseCritter).HasFaction(eventScript.readShort()));
						} else {
							Main.I.Log("Unknown target for 0x700D Target=" + info.CurrentTarget + " Faction=" + eventScript.readShort());
						} break;
					case 0x7FFF: //AI Event, Trigger Event etc
						var whatAIEvent:int = GetNumberFromVariable(eventScript, info, inputParam);
						if (inputParam is int) {
							currentUnprocessedValue = ((inputParam as int) == whatAIEvent);
						} break;
					default:
						Main.I.Log("@0x" + command.toString(16) + ": Unknown Conditional.");
						break;
				}
				
				if (command != 0xF0FE && command != 0x7000 && command != 0x7001 && command != 0x7002) { //if not operation
					if (isNOTblock) {
						//Main.I.Log("\tNOT " + currentUnprocessedValue);
						currentUnprocessedValue = !currentUnprocessedValue;
						isNOTblock = false;
					}
					
					if (currentOperation == 0) { //AND
						//Main.I.Log("\tAND (" + currentCalculatedValue + " && " + currentUnprocessedValue + ") = " +(currentCalculatedValue && currentUnprocessedValue));
						currentCalculatedValue = (currentCalculatedValue && currentUnprocessedValue);
					} else if (currentOperation == 1) { //OR
						//Main.I.Log("\tOR (" + currentCalculatedValue + " || " + currentUnprocessedValue + ") = " + (currentCalculatedValue || currentUnprocessedValue));
						currentCalculatedValue = (currentCalculatedValue || currentUnprocessedValue);
					}
				}
			}
			
			return currentCalculatedValue;
		}
		
		private function Process_ForEach(eventScript:ByteArray, info:ScriptInstance, position:PointX, eventID:int, param:Object):void {
			var eType:int = eventScript.readUnsignedShort();
			var arrayType:int = eventScript.readUnsignedShort();
			
			var i:int;
			var dim0:int;
			var dim1:int;
			var dim2:int;
			var rect:Rect = new Rect(false, null);
			
			var Objects:Vector.<IScriptTarget> = new Vector.<IScriptTarget>();
			
			while(arrayType != 0xF0FD) {
				switch(arrayType) {
					case FRONT:
						dim0 = GetNumberFromVariable(eventScript, info, param)
						dim1 = GetNumberFromVariable(eventScript, info, param)
						dim2 = GetNumberFromVariable(eventScript, info, param)
						
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
						dim0 = GetNumberFromVariable(eventScript, info, param);
						
						rect.X = position.X - dim0;
						rect.Y = position.Y - dim0*Global.PerspectiveSkew;
						rect.W = dim0*2;
						rect.H = dim0*2*Global.PerspectiveSkew;
						
						WorldData.CurrentMap.GetObjectsInArea(rect, Objects, eType, info.CurrentTarget);
						Drawer.AddDebugRect(rect);
						
						break;
					case MAP:
						if(eType != Script.CRITTER) {
							WorldData.CurrentMap.GetObjectsInArea(null, Objects, eType, info.CurrentTarget);
						} else {
							for (i = 0; i < WorldData.CurrentMap.Critters.length; i++) {
								Objects.push(WorldData.CurrentMap.Critters[i]);
							}
						} break;
					case FACTIONMAP:
						dim0 = GetNumberFromVariable(eventScript, info, param);
						if(eType != Script.CRITTER) {
							//We have a serious problem.
						} else {
							for (i = 0; i < WorldData.CurrentMap.Critters.length; i++) {
								if(WorldData.CurrentMap.Critters[i].GetFaction() == dim0) {
									Objects.push(WorldData.CurrentMap.Critters[i]);
								}
							}
						} break;
					case MYAREA:
						//something :)
						break;
					default:
						Main.I.Log("Unknown ArrayType.");
						break;
				}
				
				arrayType = eventScript.readUnsignedShort();
			}
			
			//Now we're in the loop bit :)
			var startIndex:int = eventScript.position;
			
			//Main.I.Log("LOOP Type=" + info.Invoker + " Objects=" + Objects.length);
			
			var obji:int = Objects.length;
			while (--obji > -1) {
				var target:IScriptTarget = Objects[obji];
				info.AttachTarget(target);
				
				Main.I.Log("MAP LOOP Pos=" + eventScript.position + " LoopAt=" + startIndex + " Invoker=" + info.Invoker + " CurrentTarget=" + info.CurrentTarget);
				
				var _continue:Boolean = (ProcessBlock(eventScript, info, eventID, param) == 0);
				
				info.PopTarget();
				eventScript.position = startIndex;
				
				if(!_continue) {
					break;
				}
			}
			
			ReadUntilBalancedClose(eventScript);
		}
		
		
		private function GetNumberFromVariable(eventScript:ByteArray, info:ScriptInstance, inputParam:Object):Number {
			var varType:int = eventScript.readUnsignedShort();
			var varID:int = eventScript.readShort();
			
			if (varType == 0xBFFC) { //Math function
				return ProcessMathFunction(varID, eventScript, info, inputParam);
			} else if (varType == 0xBFFD) { //Local variable
				return info.Variables[varID];
			} else if (varType == 0xBFFE) { //Global variable
				return GlobalVariables.Variables[varID];
			} else if (varType == 0xBFFF) { //Static value
				return varID;
			} else if (varType == 0xBFFB) { //FLOATING POINT
				eventScript.position -= 2;
				return eventScript.readFloat();
			}
			
			return 0; //No idea what else it should be
		}
		
		private function ProcessMathFunction(functionID:int, eventScript:ByteArray, info:ScriptInstance, inputParam:Object):int {
			var p:int = 0;
			var q:int = 0;
			var r:int = 0;
			
			switch(functionID) {
				case 0x00: //Sin
					p = GetNumberFromVariable(eventScript, info, inputParam);
					return int(10000*Math.sin(p / 180 * Math.PI));
				case 0x01: //Cos
					p = GetNumberFromVariable(eventScript, info, inputParam);
					return int(10000*Math.cos(p / 180 * Math.PI));
				case 0x02: //Tan
					p = GetNumberFromVariable(eventScript, info, inputParam);
					return int(10000*Math.tan(p / 180 * Math.PI));
				case 0x03: //Invoker
					try {
						return int(info.Invoker[GetWonkyString(eventScript)]);
					} catch (e:Error) {
						Main.I.Log("Cannot get param from invoker!" + e.message);
						return 0;
					}
				case 0x04: //Target
					try {
						return int(info.CurrentTarget[GetWonkyString(eventScript)]);
					} catch (e:Error) {
						Main.I.Log("Cannot get param from target!" + e.message);
						return 0;
					}
				case 0x05: //Power
					p = GetNumberFromVariable(eventScript, info, inputParam);
					q = GetNumberFromVariable(eventScript, info, inputParam);
					return int(Math.pow(p, q));
				case 0x06: //Param getting
					p = GetNumberFromVariable(eventScript, info, inputParam);
					if (inputParam is Array) {
						return int(inputParam[p]);
					} else {
						return int(inputParam);
					}
				case 0x07: //Random Between 2 Numbers
					p = GetNumberFromVariable(eventScript, info, inputParam);
					q = GetNumberFromVariable(eventScript, info, inputParam);
					if (p == q) {
						return p;
					} else if (p < q) {
						return Math.random() * (q - p) + p;
					} else {
						return Math.random() * (p - q) + q;
					}
				default:
					Main.I.Log("Unknown Math Command: " + functionID);
					return 0;
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
		
		private function ProcessBlock(EventScript:ByteArray, info:ScriptInstance, eventID:int, inputParam:Object):int {
			var effectInfo:EffectInfo;
			
			//Some required variables
			var command:uint = 0;
			var CallStack:Vector.<Boolean> = new Vector.<Boolean>();
			var bParam:Boolean;
			var objName:String;
			var fParam:Number;
			
			var deep:int = 0;
			
			var Position:PointX = new PointX();
			info.CurrentTarget.UpdatePointX(Position);
			
			//var tX:int = Position.X;
			//var tY:int = Position.Y;
			var p0:PointX = new PointX();
			var p1:PointX = new PointX();
			
			var uiE:UIElement;
			var uiL:UILayer;
			
			while (true) {
				command = EventScript.readUnsignedShort();
				//Main.I.Log("\t0x" + MathsEx.ZeroPad(command, 4, 16) + " Deep=" + deep + " CurrentTarget=" + info.CurrentTarget);
				
				if (command == 0xFFFF) { break; }
				if (command == 0xB000) { ProcessMathCommand(EventScript, info, inputParam); continue; }
				
				switch(command) {
					case 0x1001: //Play sound effect
						EffectsPlayer.Play(EventScript.readUnsignedShort()); break;
					case 0x1002: //Spawn Critter
						p0.D = EventScript.readShort(); p0.X = GetNumberFromVariable(EventScript, info, inputParam); p0.Y = GetNumberFromVariable(EventScript, info, inputParam);
						CalculateOffset(Position, p0, p1);
						
						var critter:BaseCritter = CritterManager.I.CritterInfo[p0.D].CreateCritter(WorldData.CurrentMap, p1.X, p1.Y);
						
						if(EventScript.readShort() == 0 && info.CurrentTarget.GetFaction() >= 0) { // Get owner faction?
							critter.SetFaction(info.CurrentTarget.GetFaction());
						}
						
						critter.SetOwner(info.CurrentTarget);
						
						if (NetSync > 0 && Global.Network != null) PacketFactory.N(Vector.<int>([0x1002, p0.D, 0xBFFF, p1.X, 0xBFFF, p1.Y, 0x1]));
						
						break;
					case 0x1003: //Flat Damage
						if(info.CurrentTarget is IMapObject) {
							(info.CurrentTarget as IMapObject).ScriptAttack(false, GetNumberFromVariable(EventScript, info, inputParam), GetNumberFromVariable(EventScript, info, inputParam), info.Invoker); break;
						} else {
							GetNumberFromVariable(EventScript, info, inputParam);
							GetNumberFromVariable(EventScript, info, inputParam);
						} break;
					case 0x1005: //% Damage
						if(info.CurrentTarget is IMapObject) {
							(info.CurrentTarget as IMapObject).ScriptAttack(true, GetNumberFromVariable(EventScript, info, inputParam), 0, info.Invoker); break;
						} else {
							GetNumberFromVariable(EventScript, info, inputParam);
						} break;
					case 0x1007: //Destroy
						if (info.CurrentTarget is ICleanUp) { Clock.CleanUpList.push(info.CurrentTarget); } break;
					case 0x1008: //EffectSpawn
						p0.D = EventScript.readShort();
						effectInfo = EffectManager.I.Effects[p0.D];
						p0.X = GetNumberFromVariable(EventScript, info, inputParam); p0.Y = GetNumberFromVariable(EventScript, info, inputParam);
						CalculateOffset(Position, p0, p1);
						
						new EffectInstance(effectInfo, p1.X, p1.Y, Position.D);
						
						if (NetSync > 0 && Global.Network != null) PacketFactory.N(Vector.<int>([0x1008, p0.D, 0xBFFF, p1.X, 0xBFFF, p1.Y]));
						
						break;
					case 0x1009: //EffectSpawnDirectional
						effectInfo = EffectManager.I.Effects[EventScript.readShort()];
						p0.X = Position.X + GetNumberFromVariable(EventScript, info, inputParam); p0.Y = Position.Y + GetNumberFromVariable(EventScript, info, inputParam);
						new EffectInstance(effectInfo, p0.X, p0.Y, EventScript.readShort()); break;
					case 0x100A: //EffectSpawnDirectionalRelative
						effectInfo = EffectManager.I.Effects[EventScript.readShort()];
						
						p0.X = Position.X + GetNumberFromVariable(EventScript, info, inputParam); p0.Y = Position.Y + GetNumberFromVariable(EventScript, info, inputParam);
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
								} break;
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
								} break;
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
								} break;
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
								} break;
						}
						
						new EffectInstance(effectInfo, p0.X, p0.Y, tD);
		
						break;
					case 0x100B: //SpawnObject
						var id:int = EventScript.readShort();
						
						p0.X = GetNumberFromVariable(EventScript, info, inputParam); p0.Y = GetNumberFromVariable(EventScript, info, inputParam);
						CalculateOffset(Position, p0, p1);
						
						var o:ObjectInstance;
						
						if (ObjectTemplate.Objects[id].IndividualAnimations) {
							o = new ObjectInstanceAnimated();
						} else {
							o = new ObjectInstance();
						}
						
						o.SetInformation(WorldData.CurrentMap, id, p1.X, p1.Y);
						WorldData.CurrentMap.Objects.push(o);
						
						if (NetSync > 0 && Global.Network != null) PacketFactory.N(Vector.<int>([0x100B, id, 0xBFFF, p1.X, 0xBFFF, p1.Y]));
						
						break;
					case 0x100D: //Fire a trigger
						Script.FireTrigger(GetNumberFromVariable(EventScript, info, inputParam)); break;
					case 0x100E: //Play a sound from an effect group
						EffectsPlayer.PlayFromGroup(EventScript.readShort()); break;
					case 0x100F: //Network sync... somehow?
						NetSync++;
						break;
					case 0x1010: //Change map
						var mapID:int = EventScript.readShort();
						Main.I.Renderer.FadeToBlack(null, WorldData.Maps[mapID]);
						WorldData.CurrentMap.CleanUp();
						WorldData.CurrentMap.LoadMap(WorldData.Maps[mapID]);
						
						if (NetSync > 0 && Global.Network != null) PacketFactory.N(Vector.<int>([0x1010, mapID]));
						break;
					case 0x1011: //NetHost
						p0.X = EventScript.readShort();
						p0.Y = GetNumberFromVariable(EventScript, info, inputParam);
						
						if (p0.X == 0) { //LAN
							Global.Network = new SocketHost();
							Global.Network.Connect("", p0.Y, Main.I);
						} else {
							Main.I.Log("Unknown network type!");
						} break;
					case 0x1012: //NetConnect
						p0.X = EventScript.readShort();
						var s:String = GetWonkyString(EventScript);
						p0.Y = GetNumberFromVariable(EventScript, info, inputParam);
						
						Main.I.Log("Hostname = " + s + ":" + p0.Y);
						
						if(p0.X == 0) { //LAN
							Global.Network = new SocketClient();
							Global.Network.Connect(s, p0.Y, Main.I);
						} else {
							Main.I.Log("Unknown network type!");
						} break;
					case 0x1013: //NetClose
						if (Global.Network != null) {
							Global.Network.Close();
							Global.Network = null;
						}
						break;
					case 0x1014: //Spawn Enabled
						p0.X = EventScript.readShort();
						p0.Y = EventScript.readShort();
						
						if (WorldData.CurrentMap.Spawns.length > p0.X) {
							WorldData.CurrentMap.Spawns[p0.X].SetEnabled(p0.Y == 1);
						} break;
					case 0x1015: //NetSyncVar
						p0.X = EventScript.readUnsignedShort(); //SHOULD BE 0xBFFE
						p0.Y = EventScript.readUnsignedShort(); //SHOULD BE < 1000
						if (p0.X == 0xBFFE && Global.Network != null) PacketFactory.N(Vector.<int>([0xB000, 0xBFFE, p0.Y, 0xBFFF, GlobalVariables.Variables[p0.Y], 0xBF01]));
						break;
					case 0x1017: //Param Set ADVANCED PROGRAMMING COMMAND
						objName = GetWonkyString(EventScript);
						p0.X = GetNumberFromVariable(EventScript, info, inputParam);
						
						if (info.CurrentTarget[objName] is int) {
							info.CurrentTarget[objName] = p0.X;
						} break;
					case 0x1018: //Tween
						objName = GetWonkyString(EventScript);							//Param Name
						p0.X = GetNumberFromVariable(EventScript, info, inputParam); 	//Initial Value
						p0.Y = GetNumberFromVariable(EventScript, info, inputParam); 	//Final Value
						fParam = GetNumberFromVariable(EventScript, info, inputParam);
						TweenManager.StartTweenBetween(info.CurrentTarget, objName, p0.X, p0.Y, fParam);
						break;
					case 0x1019: //TweenTo
						objName = GetWonkyString(EventScript);							//Param Name
						p0.X = GetNumberFromVariable(EventScript, info, inputParam); 	//Final Value
						fParam = GetNumberFromVariable(EventScript, info, inputParam);
						TweenManager.StartTweenTo(info.CurrentTarget, objName, p0.X, fParam);
						break;
					case 0x101A: //Apply Buff
						p0.X = EventScript.readShort();	//Buff ID
						if (info.CurrentTarget is BaseCritter) {
							(info.CurrentTarget as BaseCritter).ApplyBuff(p0.X);
						}
						break;
					case 0x101B: //TweenChild
						objName = GetWonkyString(EventScript);							//Param Name
						var objX:Object = info.CurrentTarget[objName];
						objName = GetWonkyString(EventScript);
						p0.X = GetNumberFromVariable(EventScript, info, inputParam); 	//Initial Value
						p0.Y = GetNumberFromVariable(EventScript, info, inputParam); 	//Final Value
						fParam = GetNumberFromVariable(EventScript, info, inputParam);
						TweenManager.StartTweenBetween(objX, objName, p0.X, p0.Y, fParam);
						break;
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
							(info.CurrentTarget as BaseCritter).MovementSpeed = GetNumberFromVariable(EventScript, info, inputParam);
						} break;
					case 0x5002: //Movement direction absolute
					case 0x5003: //Movement direction relative
						if (info.CurrentTarget is BaseCritter) {
							var angle:Number = Math.PI * (GetNumberFromVariable(EventScript, info, inputParam) / 180.0);
							var move:Boolean = (EventScript.readShort() == 1);
							if (command == 0x5002) {
								(info.CurrentTarget as BaseCritter).RequestMove(Math.cos(angle), Math.sin(angle), move);
							} else if (command == 0x5003) {
								var c:BaseCritter = (info.CurrentTarget as BaseCritter);
								angle += Math.atan2(c.virginMoveSpeedY, c.virginMoveSpeedX);								
								c.RequestMove(Math.cos(angle), Math.sin(angle), move);
							}
						} else {
							Main.I.Log("0x5003 WRONG TARGET! " + info.CurrentTarget + " @" + eventID);
							GetNumberFromVariable(EventScript, info, inputParam); EventScript.readShort(); //Remove the two shorts
						} break;
					case 0x5004: //Set Faction
						if (info.CurrentTarget is BaseCritter) { 
							(info.CurrentTarget as BaseCritter).SetFaction(EventScript.readShort());
						} break;
					case 0x5005: //Movement stop
						if (info.CurrentTarget is BaseCritter) { 
							(info.CurrentTarget as BaseCritter).RequestMove(0, 0);
						} break;
					case 0x5006: //Get Target From Owner
						if (info.CurrentTarget is BaseCritter && ((info.CurrentTarget as BaseCritter).Owner as BaseCritter) != null) {
							(info.CurrentTarget as BaseCritter).CurrentTarget = ((info.CurrentTarget as BaseCritter).Owner as BaseCritter).CurrentTarget;
						} else {
							Main.I.Log("Uh? What target?");
						} break;
					case 0x5007: //Set AIType param
						if (info.CurrentTarget is BaseCritter) {
							var typeChange:int = EventScript.readShort();
							var typeOnOff:Boolean = (EventScript.readShort() == 1?true:false);
							
							if (typeOnOff) { //Make sure is enabled
								(info.CurrentTarget as BaseCritter).MyAIType = ((info.CurrentTarget as BaseCritter).MyAIType | typeChange);
							} else { //Make sure is disabled
								(info.CurrentTarget as BaseCritter).MyAIType = ((info.CurrentTarget as BaseCritter).MyAIType & ~typeChange);
							}
						} else {
							EventScript.readShort(); // pop the type off
							EventScript.readShort(); // pop the boolean off 
						} break;
					case 0x5008: //With(ScriptTarget)
						var x:int = EventScript.readShort();
						if (x == 0x0) { //Invoker
							info.AttachTarget(info.Invoker);
						} else if (x == 0x1) { // AITarget
							if (info.CurrentTarget is BaseCritter && (info.CurrentTarget as BaseCritter).CurrentTarget != null) {
								info.AttachTarget((info.CurrentTarget as BaseCritter).CurrentTarget);
							}
						} else if (x == 0x2) { // Attacker
							if (eventID == Script.Attacked && inputParam != null) {
								if (inputParam is IScriptTarget) {
									info.AttachTarget(inputParam as IScriptTarget);
								} else if (inputParam is Array && (inputParam as Array).length > 0 && (inputParam as Array)[0] is IScriptTarget) {
									info.AttachTarget((inputParam as Array)[0]);
								}
							}
						} else if (x == 0x3) { //Owner
							if (info.CurrentTarget is BaseCritter && (info.CurrentTarget as BaseCritter).Owner != null) {
								info.AttachTarget((info.CurrentTarget as BaseCritter).Owner);
							}
						} info.CurrentTarget.UpdatePointX(Position); break;
					case 0x5009: //PopTarget()
						info.PopTarget(); info.CurrentTarget.UpdatePointX(Position); break;
					case 0x6000: //Play Animation
						info.Invoker.ChangeState(EventScript.readShort(), false); break;
					case 0x6001: //Loop Animation
						info.Invoker.ChangeState(EventScript.readShort(), true); break;
					case 0x6002: //Animation Speed
						info.Invoker.UpdatePlaybackSpeed(GetNumberFromVariable(EventScript, info, inputParam)); break;
					case 0x8000: //IF without ELSE
						bParam = CanIf(EventScript, info, Position, inputParam);
						if (!bParam) {
							EventScript.readUnsignedShort(); //Just pop the 0xF0FD off
							ReadUntilBalancedClose(EventScript);
						} else {
							ProcessBlock(EventScript, info, eventID, inputParam);
						} break;
					case 0x8001: //IF with ELSE
						bParam = CanIf(EventScript, info, Position, inputParam);
						if (bParam) {
							CallStack.push(true);
							ProcessBlock(EventScript, info, eventID, inputParam);
						} else {
							EventScript.readUnsignedShort(); //Just pop the 0xF0FD off
							ReadUntilBalancedClose(EventScript);
							CallStack.push(false);
						} break;
					case 0x8002: //Foreach
						Process_ForEach(EventScript, info, Position, eventID, inputParam);
						break;
					case 0x8003: //ELSE
						bParam = CallStack.pop();
						if (bParam) {
							EventScript.readUnsignedShort(); //Just pop the 0xF0FD off
							ReadUntilBalancedClose(EventScript);
						} else {
							ProcessBlock(EventScript, info, eventID, inputParam);
						} break;
					case 0x8004: //Continue
						ReadUntilBalancedClose(EventScript);
						return 0;
					case 0x8005: //Break
						ReadUntilBalancedClose(EventScript);
						return 2;
					case 0x8006: //Call a global function
						p0.X = EventScript.readShort(); //Function ID
						GlobalVariables.Functions.Run(p0.X, info, inputParam);
						break;
					case 0xC002: //Hide Panel
						p0.D = EventScript.readUnsignedShort();
						p0.X = EventScript.readShort();
						(Main.I.hud.Panels[p0.D] as UIPanel).visible = (p0.X == 1);
						if (NetSync > 0 && Global.Network != null) PacketFactory.N(Vector.<int>([0xC002, p0.D, p0.X]));
						break;
					case 0xC003: //Redraw Panel
						Main.I.hud.Panels[EventScript.readShort()].Elements[EventScript.readShort()].Draw(Main.I.stage.stageWidth, Main.I.stage.stageHeight, Main.I.hud); break;
					case 0xC004: //Update UIText
						uiE = Main.I.hud.Panels[EventScript.readShort()].Elements[EventScript.readShort()];
						uiL = uiE.Layers[EventScript.readShort()];
						
						if (uiL is UILayerText) {
							s = GetWonkyString(EventScript);
							(uiL as UILayerText).Message = StringEx.BuildFromCore(s);
							uiE.Draw(Main.I.stage.stageWidth, Main.I.stage.stageHeight, Main.I.hud);
						} break;
					case 0xC005: //Change offsets for UILayer
						uiE = Main.I.hud.Panels[EventScript.readShort()].Elements[EventScript.readShort()];
						uiL = uiE.Layers[EventScript.readShort()];
						
						uiL.OffsetX = GetNumberFromVariable(EventScript, info, inputParam) + 1;
						uiL.OffsetY = GetNumberFromVariable(EventScript, info, inputParam) + 1;
						uiL.FixPosition();
						
						break;
					case 0xC006: //Change layer database
						uiE = Main.I.hud.Panels[EventScript.readShort()].Elements[EventScript.readShort()];
						uiL = uiE.Layers[EventScript.readShort()];
						
						if (uiL is UILayerLibrary) {
							(uiL as UILayerLibrary).ID = GetNumberFromVariable(EventScript, info, inputParam);
							uiE.Draw(Main.I.stage.stageWidth, Main.I.stage.stageHeight, Main.I.hud);
						} else {
							GetNumberFromVariable(EventScript, info, inputParam);//Just pop it off
						} break;
					case 0xC007: //UI Layer Play
						uiE = Main.I.hud.Panels[EventScript.readShort()].Elements[EventScript.readShort()];
						uiL = uiE.Layers[EventScript.readShort()];
						
						if (uiL is UILayerLibrary) {
							var time:Number = GetNumberFromVariable(EventScript, info, inputParam);
							bParam = (EventScript.readShort() == 1);
							(uiL as UILayerLibrary).Play(time, bParam);
						} else {
							GetNumberFromVariable(EventScript, info, inputParam); //Just pop it off
							EventScript.readShort(); //Pop them off as well
						} break;
					case 0xCFFF: //Main.I.Log
						Main.I.Log("[" + info.Invoker + "] " + StringEx.BuildFromCore(GetWonkyString(EventScript)).GetBuilt()); break;
					case 0xF001: //Up a netsync level
						NetSync--; break;
					default:
						if (command == 0xF0FD) {
							deep++;
						} else if (command == 0xF0FE) {
							if (deep <= 1) {
								return 0;
							}
							deep--;
						} else {
							Main.I.Log("Unknown Command: 0x" + MathsEx.ZeroPad(command, 4, 16) + " ("+command.toString()+") Event="+eventID + " Position="+EventScript.position+" Length="+EventScript.length+" Invoker="+info.Invoker + " CurrentTarget="+info.CurrentTarget);
						}
						
						break;
				}
				
				if (EventScript.position == EventScript.length) return 0;
			}
			
			return 1;
		}
		
		private function GetWonkyString(eventScript:ByteArray):String {
			var stringType:int = eventScript.readShort();
			
			var s:String;
			
			if (stringType == 0) { 
				s = GlobalVariables.Strings[eventScript.readUnsignedShort()];
			} else {
				s = BinaryLoader.GetString(eventScript);
				//Encoded so that everything is always 2 bytes :)
				if(eventScript.position%2 == 1) eventScript.position++;
			}
			
			return s;
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
			Main.I.Log("SCRIPT TRIGGER: " + triggerID);
			
			//TODO: Make this actually work properly! (more details follow)
			//It should be able to support multiple triggers firing at the same time
			//Some kind of stack system would be ideal.
			for (var i:int = 0; i < TriggerListeners.length; i++) {
				TriggerListeners[i].Run(Script.OnTrigger, null, triggerID);
			}
		}
		
		public function HasEvent(eventID:uint):Boolean {
			return (EventScripts[eventID] != null);
		}
		
		public function CleanUp():void {
			var i:int = EventScripts.length;
			
			while(--i > 0) {
				if(EventScripts[i] != null) EventScripts[i].clear();
				EventScripts[i] = null;
			}
			EventScripts = null;
			
			InitialVariables = null;
		}
	}

}