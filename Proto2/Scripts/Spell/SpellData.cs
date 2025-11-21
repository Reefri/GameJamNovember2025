using Godot;
using System;

[GlobalClass]
public partial class SpellData : Resource
{

    [Export] int manaCost = 0;
    [Export] int charge = 0;
    [Export] SpellType type = SpellType.SPELL1;

    private enum SpellType
    {
        SPELL1,
        SPELL2,
        SPELL3
    };




}
