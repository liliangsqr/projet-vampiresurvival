using Godot;
using System;
using System.Security.Cryptography;

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
		GD.Print("┌-------------------------------- SetJoueur()-------------------------------┐");
		
		_joueur = CurrentScene.GetNode<CharacterBody2D>("Joueur");
		
		if (_joueur != null)
		{
			GD.Print($"| je joueur est : " +_joueur.Name+" "+ _joueur);
		}
		else
		{
			GD.PrintErr("| Erreur: Joueur non trouvé dans la scène.");
		}
		GD.Print("└---------------------------------------------------------------------------┘");
	}
	
	public void OnContinueButtonPressed()
	{
		GD.Print("Scène actuelle avant ajout : " + GetRoot().GetTree().CurrentScene.SceneFilePath);
		_levelManager.LoadLevel("res://Codes/world.tscn");
		GD.Print("Scène actuelle apres ajout : " + GetRoot().GetTree().CurrentScene.SceneFilePath);
		SetJoueur();
		_saveManager.LoadSave("res://save/save.json");
	}
	
	public CharacterBody2D GetJoueur() 
	{
		return _joueur;
	}
}
