using Godot;
using System;
using System.Runtime.CompilerServices;

public partial class Projectile : RigidBody3D
{
    public Vector3 direction;
    public float speed = 10f;

    public bool shoot;

    public int projectileType;

    public AnimatedSprite3D sprite;

    public override void _Ready()
    {
        base._Ready();
        TopLevel = true;
        sprite = GetNode<AnimatedSprite3D>("Sprite");
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
        GD.Print("collided");
        if (body is Character c)
        {

            GD.Print("hit character");
            c.GetHitWith(projectileType);


            QueueFree();
        }

    }

    public void OnTimerTimeout()
    {
        QueueFree();
    }

    public void SetProjectileType(int i)
    {
        
        projectileType = i;
        sprite.Frame = projectileType;
    }
}
