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
			GD.Print("Fichier de sauvegarde introuvable");
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
				GD.Print("Ca a pas load:");
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
				//!\\ si on change les valeurs dans la save on peut cheater //!\\
				// il faudrai crypter parceque si la persone change à chaque fois les valeurs dans la save il quitte en sauvegardant puis change les valeurs
				if(_deserializePlayerStats.PV > 100 || _deserializePlayerStats.PV <=0) // on limite la casse sinon on va pouvoir mettre des milliards de pv
				{
					_deserializePlayerStats.PV = 100;
				}
				joueurStatistique.PV = _deserializePlayerStats.PV;
				joueurStatistique.Vitesse = _deserializePlayerStats.Vitesse; // je l'ai mis mais elle sert a rien on la sérialise pas pour le moment
				joueurStatistique.SpawnX = _deserializePlayerStats.SpawnX;
				joueurStatistique.SpawnY = _deserializePlayerStats.SpawnY;
				GD.Print("Player stats updated in the scene.");
				joueur.Position = new Vector2((float)_deserializePlayerStats.SpawnX, (float)_deserializePlayerStats.SpawnY);
			}
			else
			{
				GD.Print("si toi tu te montre c'est une folie, je comprendrai pas");
			}
		}
		else
		{
			GD.Print("Ca me rend fou ca détecte pas le joueur");
		}
	}
}
