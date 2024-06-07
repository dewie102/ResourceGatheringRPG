using Godot;
using System;

[GlobalClass]
public partial class ResourceItem : Resource
{
    [Export]
    string DisplayName { get; set; }
    [Export]
    Texture2D Texture { get; set; }
}
