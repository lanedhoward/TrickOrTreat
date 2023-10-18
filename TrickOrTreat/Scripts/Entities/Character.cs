using Godot;
using System;

public partial class Character : Area3D
{
    public int correctProjectileType;

    public bool interacted;

    public AnimatedSprite3D sprite;
    public AnimatedSprite3D parentSprite;

    public string DialogueText;
    public string DialogueName;

    [Signal]
    public delegate void CorrectProjectileUsedEventHandler();

    [Signal]
    public delegate void WrongProjectileUsedEventHandler();

    public enum Characters
    {
        ZombieKid,
        KidWithParent,
        Zombie
    }

    public override void _Ready()
    {
        base._Ready();

        sprite = GetNode<AnimatedSprite3D>("Sprite");
        parentSprite = GetNode<AnimatedSprite3D>("ParentSprite");
    }

    public void GetHitWith(int projectileType)
    {
        GD.Print($"get hit with {projectileType}");

        if (projectileType == correctProjectileType)
        {
            EmitSignal(SignalName.CorrectProjectileUsed);
        }
        else
        {
            EmitSignal(SignalName.WrongProjectileUsed);
        }

        sprite.Frame = projectileType + 1; // +1 because 0 is idle frame
        if (parentSprite.Visible)
        {
            parentSprite.Frame = sprite.Frame;
        }

        interacted = true;
    }

    public void SetCharacter(Characters c)
    {
        switch (c)
        {
            case Characters.ZombieKid:
                sprite.Animation = "zombieKid";
                correctProjectileType = 0;
                parentSprite.Visible = false;
                DialogueName = "KID";
                DialogueText = "trick or treat!!!!!!!";
                break;
            case Characters.KidWithParent:
                sprite.Animation = "zombieKid";
                correctProjectileType = 1;
                parentSprite.Visible = true;
                parentSprite.Frame = 0;
                DialogueName = "KID";
                DialogueText = "candy, please !!!!";
                break;
            case Characters.Zombie:
                sprite.Animation = "zombieMonster";
                correctProjectileType = 2;
                parentSprite.Visible = false;
                DialogueName = "ZOMBIE";
                DialogueText = "arrrrrgg groan grrrr Brainnssssss";
                break;

        }
        sprite.Frame = 0;
        interacted = false;
    }
}
