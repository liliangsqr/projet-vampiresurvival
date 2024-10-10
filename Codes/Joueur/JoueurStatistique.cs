using Godot;
using System;
using System.Text.Json.Serialization;

public partial class JoueurStatistique : Node
{
	[JsonPropertyName("pv")]
	public int PV { get; set; } = 75;

	[JsonPropertyName("vitesse")]
	public int Vitesse { get; set; } = 120;

	[JsonPropertyName("position_x")]
	public double PositionX { get; set; } = 586;

	[JsonPropertyName("position_y")]
	public double PositionY { get; set; } = 332;
}
