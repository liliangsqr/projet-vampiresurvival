using Godot;
using System;

public partial class LevelManager : Node
{

	public SceneTree game_manager =  CustomGameLoop.GetInstance();
	private Control PauseMenu;
	
	public void LoadLevel(string _chemin)
	{
		PackedScene niveau;
		try
		{ 
			niveau = GD.Load<PackedScene>(_chemin);
			game_manager.ChangeSceneToPacked(niveau);
		}
		catch (Exception e)
		{
			GD.PrintErr($"Scene not found: {"_chemin"}");
			Console.WriteLine(e);
			throw;
		}
		
		GD.Print($"Loaded scene: {niveau}");
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
