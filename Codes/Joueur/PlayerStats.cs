using Godot;
using System;
using System.Text.Json.Serialization;

public partial class PlayerStats : CharacterBody2D
{
	[JsonPropertyName("pv")]
	public int PointVie { get; set; }

	[JsonPropertyName("pos_x")]
	public float PosX { get; set; }

	[JsonPropertyName("pos_y")]
	public float PosY { get; set; }

	[JsonPropertyName("filename")]
	public string Filename { get; set; }

	[JsonPropertyName("parent")]
	public string Parent { get; set; }
	
}
