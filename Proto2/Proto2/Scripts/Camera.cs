using Godot;
using System;

// Author : 

namespace Com.IsartDigital.GameJam2025 {
	
	public partial class Camera : Camera2D
	{

		static private Camera instance;

		Vector2 maxZoomIn = new Vector2(2f, 2f);
		Vector2 maxZoomOut = new Vector2(1f, 1f);

        const string ZOOM_IN = "Zoom In";
        const string ZOOM_OUT = "Zoom Out";

        const string HUD_SCENES_PATH = "res://Scenes/HUD.tscn";
		PackedScene HUDFactory = GD.Load<PackedScene>(HUD_SCENES_PATH);

		float margin = 120;
		float baseCameraSpeed = 1000;

        private float cameraZoomFactor = 0.1f;

        float outOfWindowMargin = 10;

		private Camera() { }

		static public Camera GetInstance()
		{
			if (instance == null) instance = new Camera();
			return instance;

		}

		public override void _Ready()
		{
			if (instance != null)
			{
				QueueFree();
				GD.Print(nameof(Camera) + " Instance already exist, destroying the last added.");
				return;
			}

			instance = this;

			AddChild(HUDFactory.Instantiate());
		}

		private float SpecialCos(float x)
		{
			return (-MathF.Cos(x * MathF.PI / 2) + 1);
		}

		public override void _Process(double pDelta)
		{
			float lDelta = (float)pDelta;

			float XComposor = 0;
			float YComposor = 0;

			
			Vector2 lMousePosition = ToLocal(GetGlobalMousePosition());
			Vector2 lViewportSize = GetViewport().GetVisibleRect().Size;



            if (lMousePosition.X < -lViewportSize.X / 2 +  margin && lMousePosition.X > -lViewportSize.X / 2 - outOfWindowMargin) 
			{ XComposor = 1;  }

			else if (lMousePosition.X > lViewportSize.X / 2 -  margin && lMousePosition.X < lViewportSize.X / 2 + outOfWindowMargin)
            { XComposor = -1; }

            if (lMousePosition.Y < - lViewportSize.Y / 2 +  margin && lMousePosition.Y > -lViewportSize.Y / 2 - outOfWindowMargin)
            { YComposor = 1; }

            else if (lMousePosition.Y >   lViewportSize.Y / 2 -  margin && lMousePosition.Y < lViewportSize.Y / 2 + outOfWindowMargin)
			{ YComposor = -1;  }

            Position -= new Vector2(
				XComposor * SpecialCos((lViewportSize.X / 2 - MathF.Abs(lMousePosition.X) - margin) / margin),
				YComposor * SpecialCos((lViewportSize.Y / 2 - MathF.Abs(lMousePosition.Y) - margin) / margin)
			) * baseCameraSpeed * lDelta;
        }

        public override void _Input(InputEvent @event)
        {
            if (Input.IsActionPressed(ZOOM_IN) && Zoom < maxZoomIn)
            {
                Zoom += new Vector2(cameraZoomFactor, cameraZoomFactor);
				GD.Print(Zoom);
            }
            if (Input.IsActionPressed(ZOOM_OUT) && Zoom > maxZoomOut)
            {
                Zoom  -= new Vector2(cameraZoomFactor, cameraZoomFactor);
				GD.Print(Zoom);
            }
        }
        protected override void Dispose(bool pDisposing)
		{
			instance = null;
			base.Dispose(pDisposing);
		}

	}
}
