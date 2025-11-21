using Com.IsartDigital.GameJam2025;
using Godot;
using System;

// Author : Gramatikoff Sacha
namespace Com.IsartDigital.ProjectName {
	
	public partial class Main : Node2D
	{
		static Main instance;

		const string GAMECONTAINER_SCENE_PATH = "res://Scenes/GameContainer.tscn";
		PackedScene gameContainerFactory = (PackedScene)GD.Load(GAMECONTAINER_SCENE_PATH);

		int state = 0;

        static public Main GetInstance()
        {
            if (instance == null) instance = new Main();
            return instance;

        }
        public override void _Ready()
		{
            if (instance != null)
            {
                QueueFree();
                GD.Print(nameof(Main) + " Instance already exist, destroying the last added.");
                return;
            }

            instance = this;

			SwitchGameState();
        }

		public override void _Process(double pDelta)
		{
			float lDelta = (float)pDelta;

		}

		protected override void Dispose(bool pDisposing)
		{

		}



		public void SwitchGameState()
		{
			switch (state)
			{
				case 0:
					CreateGame();
					return;
			}
		}


		public void CreateGame()
		{
			AddChild(gameContainerFactory.Instantiate());
		}

	}
}
