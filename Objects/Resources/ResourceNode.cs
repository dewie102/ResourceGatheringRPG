using Godot;
using System;

public partial class ResourceNode : StaticBody2D
{
    private int currentResources;

    [Export]
    public ResourceNodeType[] NodeTypes { get; set; }
	[Export]
	public int startingResources = 1;
	int CurrentResources
    {
        set
        {
            if(value <= 0)
            {
                QueueFree();
            }
        }
        get
        {
            return currentResources;
        }
    }

    public override void _Ready()
    {
        CurrentResources = startingResources;
    }

    public void Harvest(int amount)
    {
        CurrentResources -= amount;
    }
}
