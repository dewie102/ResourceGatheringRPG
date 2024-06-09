using Godot;
using System;
using System.Collections.Generic;

public partial class ResourceDisplay : MarginContainer
{
	[Export]
	public PackedScene ItemDisplayTemplate;

	private GridContainer gridContainer;
	private Inventory playerInventory;

	private List<ResourceItemDisplay> displays = new();
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
        gridContainer = GetNode<GridContainer>("GridContainer");
		Player player = (Player)GetTree().GetFirstNodeInGroup("player");
		playerInventory = player.GetNode<Inventory>("Inventory");
		playerInventory.ResourceCountChanged += OnPlayerInventoryResourceCountChanged;
	}

	private void OnPlayerInventoryResourceCountChanged(ResourceItem type, int newCount)
	{
		GD.Print($"New count for {type.DisplayName} is {newCount}");

		// Find existing item display for type
		ResourceItemDisplay currentDisplay = null;

		foreach(ResourceItemDisplay display in displays)
		{
			if(display.ResourceType == type)
			{
				currentDisplay = display;
				currentDisplay.UpdateCount(newCount);
				break;
			}
		}

		// If none exist, create a new one
		if(currentDisplay == null)
		{
            ResourceItemDisplay newDisplay = ItemDisplayTemplate.Instantiate<ResourceItemDisplay>();
            gridContainer.AddChild(newDisplay);
			newDisplay.ResourceType = type;
			newDisplay.UpdateCount(newCount);
			displays.Add(newDisplay);
		}
	}
}
