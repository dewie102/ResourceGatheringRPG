using Godot;
using System;

public partial class ItemButton : Button
{
	private Item _item;

	[Export]
	public Item item
	{
		get
		{
			return _item;
		}
		set
		{
			_item = value;
			Icon = _item.Texture;
		}
	}

	public HandEquip handEquip;

    public override void _Ready()
    {
		Pressed += OnPressed;
    }

	private void OnPressed()
	{
		if(item is EquipableItem)
		{
			if(handEquip != null)
			{
				handEquip.EquippedItem = (EquipableItem)item;
			}
		}
	}
}
