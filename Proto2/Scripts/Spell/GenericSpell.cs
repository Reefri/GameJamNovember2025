using Godot;
using System;

// Author : Gramatikoff Sacha
namespace Com.IsartDigital.GameJam2025 {
	
	public partial class GenericSpell 
	{
		int cost = 0;
		int charge = 1;

		string name = "Generic Spell";

        public string texturePath = "res://Textures/icon.svg";

        public GenericSpell()
		{

		}

		public virtual void CastingSpell(Vector2 pPos)
		{
			GD.Print(name + " called its effect !");

			charge--;

			if (charge <= 0)
			{
				Destroy();
			}
		}

		public virtual void Destroy()
		{
			GD.Print(name + " destroyed itself !");
		}

	}
}
