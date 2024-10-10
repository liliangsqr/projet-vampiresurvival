using Godot;
using System;
using System.Text.Json.Serialization;

public partial class JoueurStatistique : Node
{
	[JsonPropertyName("pv")]
	public int PV { get; set; } = 100;

	[JsonPropertyName("vitesse")]
	public int Vitesse { get; set; } = 120;

	[JsonPropertyName("pos_x")]
	public double SpawnX { get; set; } = 586;

	[JsonPropertyName("pos_y")]
	public double SpawnY { get; set; } = 332;
}
