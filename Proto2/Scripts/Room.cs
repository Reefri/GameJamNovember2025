using Godot;
using System;
using System.Collections.Generic;
using Godot.Collections;
using System.Linq;

// Author : Gramatikoff Sacha
namespace Com.IsartDigital.GameJam2025
{
	
	public partial class Room : Node2D
	{
		[Export] private Array<StructureData> structure;

		const string STRUCTURECONTAINER_PATH = "StructuresContainer";
		Node2D structureContainer;

		const string STRUCTURE_SCENE_PATH = "res://Scenes/Structure.tscn";
		PackedScene structureFactory = (PackedScene)GD.Load(STRUCTURE_SCENE_PATH);
		public override void _Ready()
		{
            structureContainer = (Node2D)GetNode(STRUCTURECONTAINER_PATH);

			List<Marker2D> lMarkerList = new List<Marker2D>();
			foreach (Marker2D marker in structureContainer.GetChildren()) 
			{ lMarkerList.Add(marker); structureContainer.RemoveChild(marker); }	

			
			for (int i = 0; i < structure.Count; i++)
			{
				if (lMarkerList.Count == i) { GD.Print("Vous n'avez pas mis assez de Marker2D, les structures n'ont pas spawn !"); }
				GD.Print(ToGlobal(lMarkerList[i].Position));

				Structure lStructure = (Structure)structureFactory.Instantiate();
				lStructure.Position = lMarkerList[i].Position;

				lStructure.data = structure[i];

                structureContainer.AddChild(lStructure);
			}
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
