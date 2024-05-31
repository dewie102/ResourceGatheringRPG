using Godot;
using System;

public partial class Player : CharacterBody2D
{
	[Export]
	public float Speed = 100.0f;
	private AnimationTree animationTree;
	private Vector2 direction = Vector2.Zero;

    public override void _Ready()
    {
        animationTree = GetNode<AnimationTree>("AnimationTree");
		animationTree.Active = true;
    }

    public override void _Process(double delta)
    {
        UpdateAnimationParameters();
    }

    public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;

		// Move in all 4 directions
		direction = Input.GetVector("left", "right", "up", "down").Normalized();
		if (direction != Vector2.Zero)
		{
			velocity = direction * Speed;
		}
		else
		{
			velocity = Vector2.Zero;
		}

		Velocity = velocity;
		MoveAndSlide();
	}

	private void UpdateAnimationParameters() {
		if(Velocity == Vector2.Zero) {
			animationTree.Set("parameters/conditions/Idle", true);
			animationTree.Set("parameters/conditions/IsMoving", false);
		} else {
			animationTree.Set("parameters/conditions/Idle", false);
			animationTree.Set("parameters/conditions/IsMoving", true);
		}

		if(Input.IsActionJustPressed("use")) {
			animationTree.Set("parameters/conditions/Swing", true);
		} else {
			animationTree.Set("parameters/conditions/Swing", false);
		}

		if(direction != Vector2.Zero) {
			animationTree.Set("parameters/Idle/blend_position", direction);
			animationTree.Set("parameters/Walk/blend_position", direction);
			animationTree.Set("parameters/Swing/blend_position", direction);
		}
	}
}
