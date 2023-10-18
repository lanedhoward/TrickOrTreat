using Godot;
using System;

public partial class Door : Node3D
{

    public bool doorOpen = false;
    public AnimationPlayer animationPlayer;

    [Signal]
    public delegate void DoorOpenedEventHandler();

    [Signal]
    public delegate void DoorClosedEventHandler();


    public override void _Ready()
    {
        base._Ready();

        animationPlayer = GetNode<AnimationPlayer>("AnimationPlayer");
    }

    public void OpenAndClose()
    {
        if (doorOpen)
        {
            animationPlayer.PlayBackwards("door_open");
        }
        else
        {
            EmitSignal(SignalName.DoorOpened);
            animationPlayer.Play("door_open");
        }
        doorOpen = !doorOpen;
    }

    public void _on_animation_player_animation_finished(string animationName)
    {
        if (doorOpen)
        {
            // door finished opening
        }
        else
        {
            // door finished closing
            EmitSignal(SignalName.DoorClosed);
        }
    }
}
