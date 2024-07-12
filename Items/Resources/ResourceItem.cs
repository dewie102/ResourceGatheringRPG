using Godot;
using System;

[Tool]
[GlobalClass]
public partial class ResourceItem : Resource
{
    [Export]
    public string DisplayName { get; set; }
    [Export]
    public Texture2D Texture { get; set; }
}
