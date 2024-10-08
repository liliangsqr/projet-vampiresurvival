using Godot;
using System;

public partial class GameManager : SceneTree
{
	static GameManager game;
	private LevelManager level;
	private SaveManager save;
	
	private GameManager(){}

	public override void _Initialize()
	{
		GD.Print("Initialized:...");
		getInstance();
		level = new LevelManager();
		save = new SaveManager();
		level.load("res://Codes/Menus/MenuPrincipal.tscn");
		GD.Print("Initialization finish !");
	}
	
	public static GameManager getInstance(){
		if (game == null){
			game = new GameManager();
		}
		return game;	
	}
	
	public LevelManager getLevelManager(){
		return level;
	}
	
	
	public SaveManager getSaveManager(){
		return save;
	}
		
}
