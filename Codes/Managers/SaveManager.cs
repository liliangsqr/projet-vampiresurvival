using Godot;
using System;


public partial class SaveManager : Node2D
{
	public void save(string filename){
			
		
		using var saveFile = FileAccess.Open(filename, FileAccess.ModeFlags.Write);
		
		if (saveFile!=null) {
			
			var saveNodes = GetTree().GetNodesInGroup("Persist");
			foreach (Node saveNode in saveNodes)
			{
				var data = saveNode.Call("save");
							
				var jsonString = Json.Stringify(data);
						
				saveFile.StoreLine(jsonString);		
			}
			
			
		}else {
			GD.Print("Error opening savefile on saving : the file can't be opened or dont exist");
		}
		
	}
	
	public void load(string filename){
		
		
		
		if (FileAccess.FileExists(filename)) {
			GD.Print("Error opening savefile on loading : the file can't be opened or dont exist");
		}else {
			using var saveFile = FileAccess.Open(filename, FileAccess.ModeFlags.Read);
		}
	}
}
