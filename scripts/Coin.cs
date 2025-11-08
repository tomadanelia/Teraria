using Godot;
using System;

public partial class Coin : Area2D
{
	private AnimatedSprite2D sprite;
	public override void _Ready()
	{
		BodyEntered += OnBodyEntered;
		sprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");


	}

	private void OnBodyEntered(Node2D body)
	{

		QueueFree();

	}
}
