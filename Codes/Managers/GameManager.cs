using Godot;
using System;

//c'est un singleton

public partial class GameManager : SceneTree
{
	private static GameManager _gameManager;
	private LevelManager _levelManager;
	private SaveManager _saveManager;
	private GameManager(){}

	public static GameManager Instance(){
		
			if(_gameManager==null){
				_gameManager=new GameManager();
			}
			return _gameManager;

	}
	
	public void _Initialize(){
			_levelmanager = new LevelManager();
			_saveManager = new SaveManager();
			AddChild(_levelManager);
			AddChild(_SaveManager);
	}

	public static Get_Instance(){return _gameManager;}
	public LevelManager Get_LevelManager(){ return _levelManager;}
	public SaveManager Get_SaveManager(){ return _saveManager;}

}
