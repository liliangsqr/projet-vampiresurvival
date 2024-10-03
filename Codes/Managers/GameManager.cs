using Godot;
using System;

//c'est un singleton

public partial class GameManager : SceneTree
{
	private:
		static GameManager _gameManager;
		LevelManager _levelmanager;
		SaveManager _saveManager;
		GameManager();
		
	public:
		static GameManager Instance(){
			get {	
				if(_gameManager==null)_gameManager=new GameManager();
					return _gameManager;
			}
			//set static
		}
		void _Initialize(){
			_levelmanager = new LevelManager();
			_saveManager = new SaveManager();
			AddChild(_levelmanager);
			AddChild(_SaveManager);
		}

		 static Get_Instance();
		 Get_LevelManager(){ return _levelmanager};
		 Get_SaveManager(){ return _saveManager};

}
