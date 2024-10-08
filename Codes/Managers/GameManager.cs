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
	
	public ChangeLevel(string _page){
		try{
			//mieux est de mettre une liste des pages, si c'est pas dedans on charge rien
			if (page==null){return;}
			else{
				getLevelManager.load(_page)
			}
		}
		//ajouter une erreur si page est null
	}
	
	public SaveManager getSaveManager(){
		return save;
	}
		
}
