using Godot;
using System;

public partial class Slingshot : Node3D
{

    Node3D muzzle;
    public PackedScene projectile = ResourceLoader.Load<PackedScene>("res://Scenes/Entities/Projectile.tscn");

    public int loadedProjectileType = -1;

    public override void _Ready()
    {
        base._Ready();

        //projectile = ResourceLoader.Load<PackedScene>("res://Scenes/Entities/Projectile.tscn");
        muzzle = GetNode<Node3D>("Muzzle");
    }

    public override void _Process(double delta)
    {
        base._Process(delta);

        if (Input.IsActionJustPressed("Shoot") && loadedProjectileType >= 0)
        {
            var b = projectile.Instantiate<Node3D>();
            b.LookAtFromPosition(Position, muzzle.Position, Vector3.Up);
            muzzle.AddChild(b);
            //b.Rotation = this.Rotation;
            //b.GlobalPosition = GlobalPosition;
            Projectile p = (Projectile)b;
            p.shoot = true;
            p.SetProjectileType(loadedProjectileType);

            loadedProjectileType = -1;

        }
    }

    public void SetProjectileType(int i)
    {
        loadedProjectileType = i;
    }
}
