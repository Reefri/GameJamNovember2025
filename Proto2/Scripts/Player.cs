using Com.IsartDigital.GameJam2025;
using Godot;
using System;
using System.Collections.Generic;

public partial class Player
{
    static Player instance;

    public int numberOfSpell = 5;

    public int energie = 0;

    List<GenericSpell> spells = new List<GenericSpell> 
    {
        new TestSpell(), 
        new TestSpell(), 
        new TestSpell(), 
        new TestSpell(), 
        new TestSpell() 
    };



    public Player ()
    {
        if (instance != null)
        {
            instance = null;
            GD.Print(nameof(GameManager) + " Instance already exist, destroying the last added.");
            return;
        }

        instance = this;

    }

    public static Player GetInstance()
    {
        if (instance == null)
            instance = new Player ();
        return instance;
    }


    public List<GenericSpell> GetSpells()
        { return spells; }
}
