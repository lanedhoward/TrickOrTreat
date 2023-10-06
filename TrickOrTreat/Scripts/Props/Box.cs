using Godot;
using System;

public partial class Box : MeshInstance3D
{
	Random random;

	public override void _Ready()
	{
		base._Ready();
		random = new();
	}

	public void RandomizeColor()
	{
        //GD.Print("randomziing color");

		((StandardMaterial3D)GetActiveMaterial(0)).AlbedoColor = new Color((float)random.NextDouble(), (float)random.NextDouble(), (float)random.NextDouble());

	}
}
