using Godot;
using System;

[GlobalClass]
public partial class CustomGameLoop : SceneTree
{
	private static CustomGameLoop _instance;
	private LevelManager _levelManager;
	private SaveManager _saveManager;
	private CharacterBody2D _joueur;

	public CustomGameLoop(){
		
		_instance = this;
		GD.Print("CustomGameLoop constructor called");	
	}

	public override void _Initialize(){
		GD.Print("------------- debut INITIALISATION -------------");
		
		_levelManager = new LevelManager();
		GetRoot().AddChild(_levelManager);
		GD.Print("LevelManager ready");

		_saveManager = new SaveManager();
		GetRoot().AddChild(_saveManager);
		GD.Print("saveManager ready");
		
		_levelManager.LoadLevel("res://Codes/Menus/MenuPrincipal.tscn");
		GD.Print("------------- Fin INITIALISATION -------------");

	}


	public void CloseGame(){
		
		Root.GetTree().Quit();
	}
	
	public static CustomGameLoop GetInstance(){
		
		return _instance;
	}

	public LevelManager GetLevelManager(){
		
		return _levelManager;
	}

	public SaveManager GetSaveManager(){
		return _saveManager;
	}

	public void SetJoueur()
	{
		Current();
		GD.Print("-> fonction SetJoueur()");
		
		
		_joueur = CurrentScene.GetNode<CharacterBody2D>("World/Joueur");
		
		GD.Print($"je joueur est :" + _joueur);
		
		if (_joueur != null)
		{
			GD.Print("Joueur trouvé et assigné.");
		}
		else
		{
			GD.PrintErr("Erreur: Joueur non trouvé dans la scène.");
		}
		
		GD.Print("-> out fonction SetJoueur()");
	}
	
	public void OnContinueButtonPressed()
	{
		GD.Print("-> fonction OnContinueButtonPressed()");
		
		//On change la scenePrincipale 
		_levelManager.LoadLevel("res://Codes/world.tscn");

		// On verrifie si ca change bien 
		var currentScene = GetRoot().GetTree().CurrentScene;
		if (currentScene != null)
		{
			SetJoueur();
			Current();
			_saveManager.LoadSave("res://save/save.json");
		}
		else
		{
			GD.PrintErr("Erreur: Scène actuelle non trouvée après le chargement.");
		}
	}
	
	public CharacterBody2D GetJoueur() 
	{
		return _joueur;
	}
	
	 public void Current()
	 {
		 var currentScene = GetRoot().GetTree().CurrentScene;
		 if (currentScene != null)
		 {
			 GD.Print("Current scene path: " + currentScene.SceneFilePath);
		 }
		 else
		 {
			 GD.PrintErr("Error: Current scene not found.");
		 }
	 }
}
