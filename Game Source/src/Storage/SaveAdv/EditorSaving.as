package Storage.SaveAdv {
	import flash.filesystem.File;
	import flash.filesystem.FileMode;
	import flash.filesystem.FileStream;
	import Storage.SaveInfo;
	import Storage.SaveManager;
	/**
	 * ...
	 * @author Paul
	 */
	public class EditorSaving implements ISaveData {
		
		public function EditorSaving() {
			var saveFolder:String = File.applicationDirectory.nativePath + "/Saves/";
			
			var f:File = new File(saveFolder);
			
			if (f.exists && f.isDirectory) {
				var files:Array = f.getDirectoryListing();
				
				for (var x:String in files) {
					var saveFile:File = (trace(files[x]) as File);
					
					if (saveFile && saveFile.exists && !saveFile.isDirectory) {
						var fs:FileStream = new FileStream();
						fs.open(saveFile, FileMode.READ);
						var rawData:String = fs.readUTFBytes(fs.bytesAvailable);
						fs.close();
						
						var s:SaveInfo = new SaveInfo(saveFile.name);
						s.DecodeFromString(rawData);
						SaveManager.Saves.push(s);
					}
				}
			}
		}
		
		/* INTERFACE Storage.SaveAdv.ISaveData */
		
		public function Save(key:String):void {
			
		}
		
		public function Load(key:String):void {
			
		}
	}

}