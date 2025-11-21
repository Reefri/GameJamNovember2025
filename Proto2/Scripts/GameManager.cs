using Godot;
using System;

// Author : 

namespace Com.IsartDigital.GameJam2025 {
	
	public partial class GameManager : Node2D
	{

		static private GameManager instance;

		const string CAMERA_SCENE_PATH = "res://Scenes/Camera.tscn";
		PackedScene cameraFactory = (PackedScene)GD.Load(CAMERA_SCENE_PATH);

		const string MAP_SCENE_PATH = "res://Scenes/Map.tscn";
		PackedScene mapFactory = (PackedScene)GD.Load(MAP_SCENE_PATH);

		private GameManager() { }

		static public GameManager GetInstance()
		{
			if (instance == null) instance = new GameManager();
			return instance;
		}


		public override void _Ready()
		{
			if (instance != null)
			{
				QueueFree();
				GD.Print(nameof(GameManager) + " Instance already exist, destroying the last added.");
				return;
			}

			instance = this;

			AddChild(cameraFactory.Instantiate());

			AddChild(mapFactory.Instantiate());
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

        public override void _Input(InputEvent pEvent)
        {
            if (Input.IsActionJustPressed("Pause")) 
			{
				GetTree().Paused = true;
			}
        }
    }
}
