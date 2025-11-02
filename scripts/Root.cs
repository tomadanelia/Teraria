using System;
using Godot; // Make sure you have this

public partial class Root : Node2D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		GD.Print("Root scene script is working!"); // Debug message
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		// Optional: print every frame for testing
		// GD.Print($"_Process called, delta = {delta}");
	}
}
