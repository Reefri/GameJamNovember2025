using Godot;
using System;
using System.Collections.Generic;

// Author : Alexiane Bossis

namespace Com.IsartDigital.GameJam2025 {
	
	public partial class WaveManager
	{
		public const int WAVE_AMOUNT = 3;

		public static bool isActive = false;

		public static List<Enemy> waveList = new List<Enemy>();
		private static List<EnemySpawner> spawnersList = new List<EnemySpawner>();

		private static GameManager gameManager = GameManager.GetInstance();

		public static Enemy CreateEnemy(PackedScene pPackedScene, Node2D pContainer)
		{
			Enemy lEnemy;
			lEnemy = pPackedScene.Instantiate() as Enemy;
			pContainer.AddChild(lEnemy);

			return lEnemy;
		}

		public static void StartWave()
		{
			isActive = true;
		}

		public static void StopWave()
		{
			isActive = false;
		}

		public static void AddSpawnersToList()
		{
			foreach (Node2D lRoom in gameManager.map.GetChildren())
			{
				foreach (Node2D lNode in lRoom.GetChildren())
				{
					if (lNode is EnemySpawner) spawnersList.Add(lNode as EnemySpawner);
				}
			}
		}
    }
}
