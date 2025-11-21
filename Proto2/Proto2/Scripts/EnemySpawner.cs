using Godot;
using Godot.Collections;
using System;

// Author : Alexiane Bossis

namespace Com.IsartDigital.GameJam2025
{
	
	public partial class EnemySpawner : Node2D
	{
		[Export] private Array<EnemyData> enemies;

		[ExportGroup("Timer")]
        [Export] private Timer enemySpawnTimer;
        [Export] float enemySpawnTimerCooldown = 1f;

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
