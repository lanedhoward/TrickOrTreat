using Godot;
using System;

public partial class GameManager : Node3D
{
    [Export]
    public Dialogue dialogue;

    public Character character;

    public override void _Ready()
    {
        base._Ready();

        character = GetNode<Character>("Character");

    }


    public void OnDoorOpened()
    {
        dialogue.ShowDialogue("KID", "trick or treat !!!!!!!!!!!!!!!");
    }

    public void OnDoorClosed()
    {
        character.sprite.Frame = 0;
    }
}
