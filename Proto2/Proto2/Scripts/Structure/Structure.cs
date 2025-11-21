using Godot;
using System;

// Author : Gramatikoff Sacha
namespace Com.IsartDigital.GameJam2025
{
	public partial class Structure : Node
	{

        [Export] public StructureData resource;

        public override void _Ready()
		{

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
