using Godot;
using System;

[Tool]
public partial class HandEquip : Sprite2D
{
    private EquipableItem _equipedItem;

	[Export]
	EquipableItem EquipedItem
	{
		set
		{
			_equipedItem = value;
			Texture = _equipedItem.Texture;
		}
		get
		{
			return _equipedItem;
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
		if(EquipedItem != null && EquipedItem.GetType().GetMethod("InteractWithBody") != null)
		{
			((HarvestingTool)EquipedItem).InteractWithBody(body);
		}
	}
}
