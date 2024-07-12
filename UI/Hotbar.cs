using Godot;
using System;
using System.Linq;

public partial class Hotbar : Control
{
	public Player player;
	public HandEquip handEquip;
	public GridContainer gridContainer;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		player = (Player)GetTree().GetFirstNodeInGroup("player");
		if(player != null)
		{
			handEquip = (HandEquip)player.FindChild("HandEquip");
		}

		gridContainer = (GridContainer)FindChild("GridContainer");
		foreach(Button button in gridContainer.GetChildren().Cast<Button>())
		{
			if(button is ItemButton)
			{
				(button as ItemButton).handEquip = handEquip;
			}
		}
	}
}
