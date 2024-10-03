using Godot;
using System;

public partial class LevelManager : Node2D
{
	public void load(string str_scene){
		try 
		{
		  GetTree().change_scene_to_file(str_scene);
		}
		catch (Exception e)
		{
		  GD.Print("Level can't be found");
		}
		
	}
}
