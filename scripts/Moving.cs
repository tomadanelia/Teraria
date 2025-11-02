using Godot;
using System;

public partial class Moving : CharacterBody2D
{
	public const float Speed = 100.0f;

	public enum PlayerState { Idle, Walk, Run, Jump, Attack1, Hurt, Death ,Defend}
	private PlayerState state = PlayerState.Idle;

	private AnimatedSprite2D sprite;

	private bool isBusy = false;

	public override void _Ready()
	{
		sprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
	   sprite.AnimationFinished += () => OnAnimationFinished();
	}

	public override void _PhysicsProcess(double delta)
	{
		Vector2 direction = Input.GetVector("ui_left", "ui_right", "ui_up", "ui_down");
		Vector2 velocity = Vector2.Zero;
		float currentSpeed = Speed;

		if (Input.IsActionPressed("run"))
			currentSpeed *= 2;

		velocity = direction * currentSpeed;
		Velocity = velocity;
		MoveAndSlide();

		if (!isBusy)
		{
			if (Input.IsActionJustPressed("jump"))
			{
				state = PlayerState.Jump;
				isBusy = true;
				sprite.Play("jump");
			}
			else if (Input.IsActionJustPressed("attack1"))
			{
				state = PlayerState.Attack1;
				isBusy = true;
				sprite.Play("attack1");
			}
			else if (Input.IsActionJustPressed("defend")){
				state=PlayerState.Defend;
				isBusy=true;
				sprite.Play("defend");
			}
			else if (direction.Length() > 0)
			{
				sprite.FlipH= Velocity.X<0;
				state = Input.IsActionPressed("run") ? PlayerState.Run : PlayerState.Walk;
				sprite.Play(state == PlayerState.Run ? "run" : "walk");
			}
			else
			{
				state = PlayerState.Idle;
				sprite.Play("idle");
			}
		}
	}

	private void OnAnimationFinished()
	{
		
			isBusy = false;
			state = PlayerState.Idle;
			sprite.Play("idle");
		
	}
}
