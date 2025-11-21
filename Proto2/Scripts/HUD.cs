using Com.IsartDigital.ProjectName;
using Godot;
using System;
using System.Collections.Generic;

// Author : 

namespace Com.IsartDigital.GameJam2025 {
	
	public partial class HUD : Node2D
	{

		static private HUD instance;

		const string HUDSPELL_SCENE_PATH = "res://Scenes/HUDSpell.tscn";
		PackedScene hudSpellFactory = (PackedScene)GD.Load(HUDSPELL_SCENE_PATH);


		public Node2D spellsContainer = new Node2D();

		List<Vector2> spellPosition = new List<Vector2>();

		const int SPACE_BETWEEN_SPELLS = 100;


        private HUD() { }

		static public HUD GetInstance()
		{
			if (instance == null) instance = new HUD();
			return instance;

		}

		public override void _Ready()
		{
			if (instance != null)
			{
				QueueFree();
				return;
			}

			instance = this;


            Vector2 viewportSize = GetViewport().GetVisibleRect().Size;

			spellsContainer.Name = "SpellsContainer";
			spellsContainer.Position = new Vector2(0, viewportSize.Y / 2);

            AddChild(spellsContainer);


			for (int i = 0; i < Player.GetInstance().numberOfSpell; i++)
			{
				spellPosition.Add(new Vector2(
					(i - Player.GetInstance().numberOfSpell/2) * SPACE_BETWEEN_SPELLS,
					-100
					));
			}


			for (int i = 0; i < Player.GetInstance().numberOfSpell; i++)
			{

				Node2D lSpellContainer = new Node2D();
				lSpellContainer.Name = "SpellContainer_" + i;
				lSpellContainer.Position = spellPosition[i];
				spellsContainer.AddChild(lSpellContainer);

				HUDSpell lHUDSpell = (HUDSpell)hudSpellFactory.Instantiate();
				lHUDSpell.spell = Player.GetInstance().GetSpells()[i];

				lSpellContainer.AddChild(lHUDSpell);
			}


			ZIndex = 100;


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
