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
		GD.Print("┌-------------------------------------------- LoadSave()-------------------------------------------┐");
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
				GD.Print("| Contenu du JSON:");
				GD.Print("|		PV: " + _deserializePlayerStats.PV);
				GD.Print("|		Vitesse: " + _deserializePlayerStats.Vitesse);
				GD.Print("|		Position X: " + _deserializePlayerStats.SpawnX);
				GD.Print("|		Position Y: " + _deserializePlayerStats.SpawnY);
				UpdatePlayerStats();
			}
			else
			{
				GD.Print("Player Stats pas Loaded:");
			}
		}
		GD.Print("└---------------------------------------------------------------------------------------------------┘");

	}
	
	private void UpdatePlayerStats()
	{
		GD.Print("| -> Entre dans la fonction UpdatePlayerStats ");
		CharacterBody2D joueur = CustomGameLoop.GetInstance().GetJoueur();
		
		GD.Print($"|		Le joueur est :"+joueur.Name +" "+ joueur);

		if (joueur != null)
		{
			var joueurStatistique = joueur.GetNode<JoueurStatistique>("JoueurStatistique");
			GD.Print($"|		La Node cible est :" +joueurStatistique.Name +" "+ joueurStatistique );

			if (joueurStatistique != null)
			{
				joueurStatistique.PV = _deserializePlayerStats.PV;
				joueurStatistique.Vitesse = _deserializePlayerStats.Vitesse;
				joueurStatistique.SpawnX = _deserializePlayerStats.SpawnX;
				joueurStatistique.SpawnY = _deserializePlayerStats.SpawnY;
				GD.Print("Player stats updated in the scene.");
				joueur.Position = new Vector2((float)_deserializePlayerStats.SpawnX, (float)_deserializePlayerStats.SpawnY);
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
