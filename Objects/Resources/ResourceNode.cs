using Godot;
using System;

[Tool]
[GlobalClass]
public partial class ResourceNode : StaticBody2D
{
    private int _currentResources;

    [Export]
    public ResourceNodeType[] NodeTypes { get; set; }
	[Export]
	public int startingResources = 1;
    [Export]
    public PackedScene pickupType;
    [Export]
    public float launchSpeed = 100;
    [Export]
    public float launchDuration = 0.25f;

    private Node levelParent;
    private Random rand;

	int CurrentResources
    {
        set
        {
            _currentResources = value;

            if(value <= 0)
            {
                QueueFree();
            }
        }
        get
        {
            return _currentResources;
        }
    }

    public override void _Ready()
    {
        CurrentResources = startingResources;
        levelParent = GetParent();
        rand = new Random();
    }

    public void Harvest(int amount)
    {
        for(int count = 0; count < amount; count++)
        {
            SpawnResource();
        }
        CurrentResources -= amount;
    }

    private void SpawnResource()
    {
        Pickup pickupInstance = pickupType.Instantiate<Pickup>();
        levelParent.CallDeferred("add_child", pickupInstance);
        pickupInstance.Position = Position;

        Vector2 direction = new Vector2(
            rand.NextSingle() * 2 - 1,
            rand.NextSingle() * 2 - 1
            ).Normalized();

        pickupInstance.CallDeferred("Launch", new Variant[] { direction * launchSpeed, launchDuration });
    }
}
