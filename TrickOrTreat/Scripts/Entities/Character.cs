using Godot;
using System;

public partial class Character : Area3D
{
    public AnimatedSprite3D sprite;

    public override void _Ready()
    {
        base._Ready();

        sprite = GetNode<AnimatedSprite3D>("Sprite");
    }

    public void GetHitWith(int projectileType)
    {
        GD.Print($"get hit with {projectileType}");
        sprite.Frame = projectileType + 1; // +1 because 0 is idle frame
    }
}
