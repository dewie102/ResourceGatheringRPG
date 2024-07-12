using Godot;
using System;

public partial class Item : Resource
{
    [Export]
    public string displayName { get; set; }

    [Export]
    public Texture2D Texture { get; set; }
}
