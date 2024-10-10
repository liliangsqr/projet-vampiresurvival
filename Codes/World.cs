using Godot;
using System;

public partial class World : Node2D
{
	private CharacterBody2D Joueur;
	
	public override void _Ready(){
		Joueur = GetNode<CharacterBody2D>("Joueur");
	}
}
