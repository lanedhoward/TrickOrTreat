using Godot;
using System;
using System.Runtime.CompilerServices;

public partial class Projectile : RigidBody3D
{
    public Vector3 direction;
    public float speed = 10f;

    public bool shoot;

    public override void _Ready()
    {
        base._Ready();
        TopLevel = true;
    }

    public override void _PhysicsProcess(double delta)
    {
        base._PhysicsProcess(delta);

        if (shoot)
        {
            ApplyImpulse(-Transform.Basis.Z * speed);//, -Transform.Basis.Z);
            shoot = false;
        }
    }

    public void Collide(Node3D body)
    {
        // do collision sh*t

        //QueueFree();
    }

    public void OnTimerTimeout()
    {
        QueueFree();
    }
}
