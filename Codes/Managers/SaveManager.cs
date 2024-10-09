using Godot;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;

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

	private PlayerStats _deserializePlayerStats;

	public void LoadSave(string filename)
	{
		if (!FileAccess.FileExists(filename))
		{
			GD.Print("Save file does not exist");
			return;
		}

		using var saveFile = FileAccess.Open(filename, FileAccess.ModeFlags.Read);
		if (saveFile != null)
		{
			string jsonString = saveFile.GetAsText();
			_deserializePlayerStats = JsonSerializer.Deserialize<PlayerStats>(jsonString);

			if (_deserializePlayerStats != null)
			{
				GD.Print("Player Stats Loaded:");
				GD.Print("Filename: " + _deserializePlayerStats.Filename);
				GD.Print("Parent: " + _deserializePlayerStats.Parent);
				GD.Print("Position: (" + _deserializePlayerStats.PosX + ", " + _deserializePlayerStats.PosY + ")");
				GD.Print("PV: " + _deserializePlayerStats.PointVie);
			}
			else
			{
				GD.Print("Player Stats pas Loaded:");
			}
		}
	}
}
