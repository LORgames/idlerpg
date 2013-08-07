package Storage {
	/**
	 * ...
	 * @author Paul
	 */
	public class SaveInfo {
		//GENERAL
        public var key:String = "";
        public var name:String = "Adventurer";
        public var title:String = "Farmhand";
        public var experienceAmount:uint = 0;

        //EQUIPMENT
        public var shadow:String = "Shadow";
        public var legs:String = "Loincloth";
        public var body:String = "Rags";
        public var face:String = "_UNKNOWN";
        public var headgear:String = "";
        public var weapon:String = "";
		public var PlayerDisabled:Boolean = false;
		
		public function SaveInfo(key:String) {
			this.key = key;
			
			if (key == "") {
				trace("Cannot have a blank key!");
			}
		}
		
		public function DecodeFromString(raw:String):void {
			var lines:Array = raw.split("\r").join("").split("\n");
			
            for each (var line:String in lines) {
				if (line.length < 3) continue;
				
				var variableName:String = line.split('=')[0];
                var variableInfo:String = line.substring(line.indexOf('=')+1);
				
                switch (variableName) {
                    case "Name": name = variableInfo; break;
                    case "Title": title = variableInfo; break;
                    case "Experience": experienceAmount = uint(variableInfo); break;
                    case "Shadow": shadow = variableInfo; break;
                    case "Legs": legs = variableInfo; break;
                    case "Body": body = variableInfo; break;
                    case "Face": face = variableInfo; break;
                    case "Headgear": headgear = variableInfo; break;
                    case "Weapon": weapon = variableInfo; break;
					case "DisablePlayer": PlayerDisabled = uint(variableInfo) == 1; break;
                    default:
                        break;
                }
            }
		}
	}
}