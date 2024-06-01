using Godot;
using System;
using System.Linq;

[Tool]
[GlobalClass]
public partial class HarvestingTool : EquipableItem
{
    [Export]
    ResourceNodeType[] EffectedTypes { get; set; }
    [Export]
    int minAmount = 1;
    [Export]
    int maxAmount = 2;

    Random rand = new();

    public void InteractWithBody(Node2D body)
    {
        if(body is ResourceNode)
        {
            foreach(ResourceNodeType type in EffectedTypes)
            {
                if(((ResourceNode)body).NodeTypes.Contains(type))
                {
                    GD.Print($"Match found at type {type.DisplayName} on {body.Name}");
                    ((ResourceNode)body).Harvest(rand.Next(minAmount, maxAmount));
                }
            }
        }
    }
}
