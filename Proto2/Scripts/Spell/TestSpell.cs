using Godot;
using System;
using System.Runtime.CompilerServices;

// Author : Gramatikoff Sacha
namespace Com.IsartDigital.GameJam2025 {
	
	public partial class TestSpell : GenericSpell
	{


		public TestSpell() :base() 
		{

		}


        public override void CastingSpell(Vector2 pPos)
        {
			Sprite2D sprite = new Sprite2D();
			sprite.Texture = (Texture2D)GD.Load("res://Textures/icon.svg");
			sprite.Position = pPos;



            GameManager.GetInstance().AddChild(sprite);

            base.CastingSpell(pPos);
        }


	}
}
