using Godot;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;

public partial class SaveManager : Node2D
{
	private JoueurStatistique _deserializePlayerStats;
	
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
	
	public void LoadSave(string filename)
	{
		GD.Print("->LoadSave() ");
		if (!FileAccess.FileExists(filename))
		{
			GD.Print("Save file does not exist");
			return;
		}

		using var saveFile = FileAccess.Open(filename, FileAccess.ModeFlags.Read);
		if (saveFile != null)
		{
			string jsonString = saveFile.GetAsText();
			_deserializePlayerStats = JsonSerializer.Deserialize<JoueurStatistique>(jsonString);

			if (_deserializePlayerStats != null)
			{
				GD.Print("Player Stats Loaded:");
				GD.Print("PV: " + _deserializePlayerStats.PV);
				GD.Print("Vitesse: " + _deserializePlayerStats.Vitesse);
				GD.Print("Position X: " + _deserializePlayerStats.PositionX);
				GD.Print("Position Y: " + _deserializePlayerStats.PositionY);
				UpdatePlayerStats();
			}
			else
			{
				GD.Print("Player Stats pas Loaded:");
			}
		}
	}
	
	private void UpdatePlayerStats()
	{
		GD.Print("Entre dans la fonction UpdatePlayerStats ");
		var joueur = CustomGameLoop.GetInstance().GetJoueur();
		if (joueur != null)
		{
			var joueurStatistique = joueur.GetNode<JoueurStatistique>("JoueurStatistique");
			if (joueurStatistique != null)
			{
				joueurStatistique.PV = _deserializePlayerStats.PV;
				joueurStatistique.Vitesse = _deserializePlayerStats.Vitesse;
				joueurStatistique.PositionX = _deserializePlayerStats.PositionX;
				joueurStatistique.PositionY = _deserializePlayerStats.PositionY;
				GD.Print("Player stats updated in the scene.");
			}
			else
			{
				GD.Print("JoueurStatistique node not found.");
			}
		}
		else
		{
			GD.Print("Bonjour il y a pas de node gros con ");
		}
	}
}
