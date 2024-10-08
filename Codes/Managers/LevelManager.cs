using Godot;
using System;

public partial class LevelManager : Node2D
{
	public void load(string str_scene){
		try 
		{
			Node scene = ResourceLoader.Load<PackedScene>(str_scene).Instantiate();
			GetTree().Root.AddChild(scene);
		}
		catch (Exception e)
		{
		  GD.Print("Error loading level");
		  GD.Print(e);	
		}
		
	}
}
