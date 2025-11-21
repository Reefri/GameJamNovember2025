using Godot;
using System;


namespace Com.IsartDigital.GameJam2025
{
    [GlobalClass]

    public partial class EnemyData : Resource
    {
        [Export] float hp = 100f;
        [Export] float speed = 50f;
        [Export] Texture2D texture;
        [Export] Type type;

        enum Type
        {
            TYPE_A,
            TYPE_B,
            TYPE_C
        }
    }
}
