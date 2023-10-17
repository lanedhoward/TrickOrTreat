using Godot;
using System;

public partial class SlingshotHud : Control
{
    public int projectileType;

    public AnimatedSprite2D slingshotSprite;
    public AnimatedSprite2D ammoSprite;

    public override void _Ready()
    {
        base._Ready();
        TopLevel = true;
        slingshotSprite = GetNode<AnimatedSprite2D>("SlingshotSprite");
        ammoSprite = GetNode<AnimatedSprite2D>("ProjectileSprite");
    }

    public void SetProjectileType(int i)
    {
        projectileType = i;
        if (i < 0)
        {
            slingshotSprite.Frame = 0;
            ammoSprite.Visible = false;
        }
        else
        {
            slingshotSprite.Frame = 1;
            ammoSprite.Visible = true;
            ammoSprite.Frame = i;
        }
    }
}
