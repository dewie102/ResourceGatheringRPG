using Godot;
using System;

public partial class ResourceItemDisplay : HBoxContainer
{
	private TextureRect textureRect;
	private Label label;
	private ResourceItem _resourceType;

	public ResourceItem ResourceType
	{
		set
		{
			_resourceType = value;
			textureRect.Texture = _resourceType.Texture;
		}
		get
		{
			return _resourceType;
		}
	}
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		textureRect = GetNode<TextureRect>("TextureRect");
		label = GetNode<Label>("Label");
	}

	public void UpdateCount(int count)
	{
		label.Text = count.ToString();
	}
}
