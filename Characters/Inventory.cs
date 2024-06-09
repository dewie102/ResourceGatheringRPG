using Godot;
using System;
using Godot.Collections;

public partial class Inventory : Node
{
	[Export]
	public Dictionary<ResourceItem, int> resources;

	[Signal]
	public delegate void ResourceCountChangedEventHandler(ResourceItem type, int newCount);

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		resources = new();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void AddResources(ResourceItem type, int amount)
	{
		if(!resources.ContainsKey(type))
		{
			resources.Add(type, 0);
		}

		resources[type] += amount;
		EmitSignal("ResourceCountChanged", type, resources[type]);
	}
}
