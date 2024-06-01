using Godot;
using System;

[Tool]
[GlobalClass]
public partial class ResourceNodeType : Resource
{
    [Export]
    public string DisplayName { get; set; }
}
