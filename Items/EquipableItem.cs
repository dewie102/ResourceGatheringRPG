using Godot;
using System;

[Tool]
[GlobalClass]
public partial class EquipableItem : Resource
{
    [Export]
    public string displayName { get; set; }

    [Export]
    public Texture2D Texture { get; set; }
}
