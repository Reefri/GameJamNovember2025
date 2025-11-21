using Godot;
using System;

// Author : Alexiane Bossis

namespace Com.IsartDigital.GameJam2025
{
	
	public partial class Enemy : Area2D
	{
		[ExportGroup("Navigation")] 
		[Export] private NavigationAgent2D nav2D;

		private Vector2 spawnPoint;
		private Vector2 nextPathPos;
		private Vector2 targetPos;
		private Vector2 nextVelocity;

		float speed;

		public override void _Ready()
		{
			spawnPoint = GlobalPosition;

			GlobalPosition = spawnPoint;

			nav2D.TargetPosition = GlobalPosition;
        }

        public override void _Process(double pDelta)
		{
			float lDelta = (float)pDelta;

			Move(lDelta);
        }

        private void Move(float pDelta)
		{
            if (nav2D.IsNavigationFinished()) return;

            nextPathPos = nav2D.GetNextPathPosition();
            nextVelocity = GlobalPosition.DirectionTo(nextPathPos) * speed;

            GlobalPosition += nextVelocity * pDelta;
            Rotation = nextVelocity.Angle();
        }

		protected override void Dispose(bool pDisposing)
		{

		}
	}
}
