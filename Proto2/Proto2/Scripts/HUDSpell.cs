using Com.IsartDigital.GameJam2025;
using Godot;
using System;

// Author : Gramatikoff Sacha
namespace Com.IsartDigital.GameJam2025
{
	
	public partial class HUDSpell : Node2D
	{
		public GenericSpell spell;

		const string SPRITE_PATH = "Sprite2D";

        const string BUTTON_PATH = "SpellButton";

		bool spellFollowMouse = false;

        Vector2 basePosition;


        public override void _Ready()
		{
			((Sprite2D)GetNode(SPRITE_PATH)).Texture = (Texture2D)GD.Load(spell.texturePath);

            ((Button)GetNode(BUTTON_PATH)).ButtonDown += OnTakeSpell;
            ((Button)GetNode(BUTTON_PATH)).ButtonUp   += OnReleaseSpell;


        }

        public override void _Process(double pDelta)
		{
			float lDelta = (float)pDelta;

            if (spellFollowMouse)
            {
                //Position = GetLocalMousePosition();
                //Position = GameManager.GetInstance().ToGlobal(((Node2D)GetParent()).ToLocal(Camera.GetInstance().GetLocalMousePosition()));
                //Position = ((Node2D)GetParent()).ToLocal(HUD.GetInstance().ToLocal(Camera.GetInstance().GetLocalMousePosition()));
                //Position = HUD.GetInstance().ToGlobal(Camera.GetInstance().GetLocalMousePosition());



                //Position = ((Node2D)GetParent()).ToLocal(Camera.GetInstance().GetLocalMousePosition()) + Camera.GetInstance().Position;
                Position = ((Node2D)GetParent()).GetLocalMousePosition();

            }


        }

        protected override void Dispose(bool pDisposing)
		{

		}


        private void OnTakeSpell()
        {
            basePosition = Position;
            spellFollowMouse = true;
		}

        private void OnReleaseSpell()
        {
            spell.CastingSpell(GetGlobalMousePosition());

            Position = basePosition;
            spellFollowMouse = false;
        }
    }
}
