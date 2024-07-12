using Godot;
using System;

public partial class HandEquip : Sprite2D
{
    private EquipableItem _equippedItem;

	[Export]
	public EquipableItem EquippedItem
	{
		set
		{
			_equippedItem = value;
			Texture = _equippedItem.Texture;
		}
		get
		{
			return _equippedItem;
		}
	}

	Area2D equipHitbox;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		equipHitbox = GetNode<Area2D>("Area2D");
		equipHitbox.BodyEntered += OnArea2DBodyEntered;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	private void OnArea2DBodyEntered(Node2D body)
	{
		if(EquippedItem != null && EquippedItem.GetType().GetMethod("InteractWithBody") != null)
		{
			((HarvestingTool)EquippedItem).InteractWithBody(body);
		}
	}
}
