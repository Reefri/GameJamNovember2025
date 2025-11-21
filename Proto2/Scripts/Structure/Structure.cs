using Godot;
using System;

// Author : Gramatikoff Sacha
namespace Com.IsartDigital.GameJam2025
{
	public partial class Structure : Node2D
	{

		public StructureData data;

		const string SPRITE_PATH = "Sprite";

		int hp = 0;
		string name = "";
        public override void _Ready()
		{
			GlobalRotation = 0;

			hp = data.hp;
			name = data.name;
			//((Sprite2D)GetNode(SPRITE_PATH)).Texture = data.texture;

		}



		public override void _Process(double pDelta)
		{
			float lDelta = (float)pDelta;

		}

		protected override void Dispose(bool pDisposing)
		{

		}
	}
}
