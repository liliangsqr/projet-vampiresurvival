using Godot;
using System;

[GlobalClass]
public partial class CustomGameLoop : SceneTree
{
	private static CustomGameLoop _instance;
	private LevelManager _levelManager;
	private SaveManager _saveManager;

	public CustomGameLoop()
	{
		_instance = this;
		GD.Print("CustomGameLoop constructor called");	
	}

	public override void _Initialize()
	{
		GD.Print("CustomGameLoop ready");
		
		_levelManager = new LevelManager();
		GetRoot().AddChild(_levelManager);
		GD.Print("LevelManager ready");

		_saveManager = new SaveManager();
		GetRoot().AddChild(_saveManager);
		GD.Print("saveManager ready");
		
		_levelManager.LoadLevel("res://Codes/Menus/MenuPrincipal.tscn");
	}

	public void CloseGame()
	{
		Root.GetTree().Quit();
	}
	
	public static CustomGameLoop GetInstance()
	{
		return _instance;
	}

	public LevelManager GetLevelManager()
	{
		return _levelManager;
	}

	public SaveManager GetSaveManager()
	{
		return _saveManager;
	}
}
