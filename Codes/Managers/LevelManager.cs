using Godot;
using System;

public partial class LevelManager : Node
{
	public SceneTree game_manager =  CustomGameLoop.GetInstance();
	private Control PauseMenu;
	
	public void LoadLevel(string _chemin)
	{
		GD.Print("┌-------------------------------------------- LoadLevel()-------------------------------------------┐");

		PackedScene niveau;
		try
		{
			niveau = GD.Load<PackedScene>(_chemin);
			if (niveau != null)
			{
				Node newSceneInstance = niveau.Instantiate();
				game_manager.GetRoot().AddChild(newSceneInstance);

				GD.Print("| Nouvelle scène ajoutée : " + newSceneInstance.SceneFilePath);
				Node currentScene = game_manager.CurrentScene;
				
				if (currentScene != null)
				{
					currentScene.CallDeferred("free");
					GD.Print("| Ancienne scène sera supprimée.");
				}

				game_manager.CurrentScene = newSceneInstance;
				GD.Print("| Nouvelle scène courante : " + game_manager.CurrentScene.SceneFilePath);
			}
			else
			{
				GD.PrintErr("| Erreur : Impossible de charger la nouvelle scène.");
			}
		}
		catch (Exception e)
		{
			GD.PrintErr($"Scene not found: {"_chemin"}");
			Console.WriteLine(e);
			throw;
		}
		GD.Print($"| Loaded scene: {niveau} chemin:{_chemin} ");
		GD.Print("└---------------------------------------------------------------------------------------------------┘");

	}
	

	public void SwitchPauseLevel(){
		if (GetTree().Paused)
		{
			GetTree().Paused = false;
		}
		else
		{
			GetTree().Paused = true;
		}
	}
	
}
