using Godot;
using System;


[GlobalClass]
public partial class StructureData : Resource
{
    [Export] public string name = "Structure";
    [Export] public int hp = 100;
    [Export] public PackedScene texture = null;

}
