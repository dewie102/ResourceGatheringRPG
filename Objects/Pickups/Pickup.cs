using Godot;
using System;

[GlobalClass]
public partial class Pickup : Area2D
{
	[Export]
	public ResourceItem resourceType;
	private CollisionShape2D collisionShape;

	private Vector2 launchVelocity = Vector2.Zero;
	private float moveDuration = 0;
	private float timeSinceLaunch = 0;
	private bool _launching;
	private bool Launching {
		get
		{
			return _launching;
		}
		set
		{
            _launching = value;
			collisionShape.SetDeferred("Disabled", _launching);
		}
	}

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		collisionShape = GetNode<CollisionShape2D>("CollisionShape2D");
		Launching = false;
		BodyEntered += OnBodyEntered;
    }

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if(Launching)
		{
			Position += launchVelocity * (float)delta;
			timeSinceLaunch += (float)delta;

			if(timeSinceLaunch >= moveDuration)
			{
				Launching = false;
			}
		}
	}

	public void Launch(Vector2 velocity, float duration)
	{
		launchVelocity = velocity;
		moveDuration = duration;
		timeSinceLaunch = 0;
		Launching = true;
	}

	private void OnBodyEntered(Node2D body)
	{
		Node inventory = body.FindChild("Inventory");

		if(inventory != null)
		{
			((Inventory)inventory).AddResources(resourceType, 1);
			QueueFree();
		}
	}
}
