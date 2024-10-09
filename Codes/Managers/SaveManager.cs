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
		
		
		
		if (!FileAccess.FileExists(filename)) {
			GD.Print("Error opening savefile on loading : the file can't be opened or dont exist");
		}else {
			
			GD.Print("Saved File has been found");
			
			var saveFile = FileAccess.Open(filename, FileAccess.ModeFlags.Read);
			
			while (saveFile.GetPosition() < saveFile.GetLength()){
				
				GD.Print("Line : ", saveFile.GetPosition());
				
				var jsonString = saveFile.GetLine();
				
				var json = new Json();
				var parseResult = json.Parse(jsonString);
				if (parseResult != Error.Ok)
				{
					GD.Print($"JSON Parse Error: {json.GetErrorMessage()} in {jsonString} at line {json.GetErrorLine()}");
					continue;
				}

				// Get the data from the JSON object.
				var nodeData = new Godot.Collections.Dictionary<string, Variant>((Godot.Collections.Dictionary)json.Data);
				var packedLevel = GD.Load<PackedScene>(nodeData["Parent"].ToString());
				
				GD.Print("Packed Level : ", packedLevel);
				
				var level = packedLevel.Instantiate<Node>();
				
				GD.Print("Trying to insert saved pos");
				
				level.GetNode((string)nodeData["Classe"]).Set(Node2D.PropertyName.Position, new Vector2((float)nodeData["Pos_x"], (float)nodeData["Pos_y"]));
				
				foreach (var (key, value) in nodeData)
					{
						if (key == "Filename" || key == "Parent" || key == "PosX" || key == "PosY" || key == "Classe")
						{
							continue;
						}
						level.GetNode((string)nodeData["Classe"]).Set(key, value);
					}
				
				CustomGameLoop.GetInstance().Root.AddChild(level);
				
				//GD.Print("Trying to insert saved pos");
				//GD.Print("Pos x : ",nodeData["Pos_x"], " Pos y : ",nodeData["Pos_y"]);
				//GD.Print("Joueur : ", CustomGameLoop.GetInstance().GetCurrentScene().GetNode("Joueur"));
				//CustomGameLoop.GetInstance().GetCurrentScene().GetNode("Joueur").Set(Node2D.PropertyName.Position, new Vector2((float)nodeData["Pos_x"], (float)nodeData["Pos_y"]));
					
				//GD.Print("Trying to insert saved pv");
			}
		

		}
	}
}
