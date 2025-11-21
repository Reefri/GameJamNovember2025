using Com.IsartDigital.ProjectName;
using Godot;
using System;
using System.Collections.Generic;

// Author : 

namespace Com.IsartDigital.GameJam2025 {
	
	public partial class GameManager : Node2D
	{
        #region Singleton Instanciation
        static private GameManager instance;

		private GameManager() { }

		static public GameManager GetInstance()
		{
			if (instance == null) instance = new GameManager();
			return instance;
		}
		#endregion

		[ExportGroup("Timers")]
		[Export] Timer waveTimer;
		[Export] float waveTimerCooldown = 1f;
		
        const string CAMERA_SCENE_PATH = "res://Scenes/Camera.tscn";
		PackedScene cameraFactory = (PackedScene)GD.Load(CAMERA_SCENE_PATH);

		const string MAP_SCENE_PATH = "res://Scenes/Map.tscn";
		PackedScene mapFactory = (PackedScene)GD.Load(MAP_SCENE_PATH);

		const string ENEMY_SCENE_PATH = "res://Scenes/Enemy.tscn";
		public PackedScene enemyFactory = (PackedScene)GD.Load(ENEMY_SCENE_PATH);

		const string ENEMY_CONTAINER_PATH = "res://Scenes/EnemyContainer.tscn";
		PackedScene enemyContainerFactory = (PackedScene)GD.Load(ENEMY_CONTAINER_PATH);


		public Node2D enemyContainer;
		public Node2D map;

        public override void _Ready()
		{
            #region Instance Management
            if (instance != null)
			{
				QueueFree();
				GD.Print(nameof(GameManager) + " Instance already exist, destroying the last added.");
				return;
			}

			instance = this;
			#endregion

			
            AddChild(cameraFactory.Instantiate());

			map = mapFactory.Instantiate() as Node2D;
            AddChild(map);

			enemyContainer = enemyContainerFactory.Instantiate() as Node2D;
			AddChild(enemyContainer);

			WaveManager.AddSpawnersToList();

			waveTimer.WaitTime = waveTimerCooldown;

			waveTimer.Start();

			waveTimer.Timeout += WaveManager.StartWave;
		}

		public override void _Process(double pDelta)
		{
			float lDelta = (float)pDelta;
		}

        

		protected override void Dispose(bool pDisposing)
		{
			instance = null;
			base.Dispose(pDisposing);
		}
	}
}
