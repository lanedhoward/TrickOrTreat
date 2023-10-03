using Godot;
using System;

public partial class Interact : RayCast3D
{

    public override void _Ready()
    {
        base._Ready();
    }

    public override void _Process(double delta)
    {
        base._Process(delta);

        if (IsColliding())
        {
            var collider = GetCollider();

            if (collider is Interactable interactable)
            { 
                if (interactable.Enabled)
                {
                    // put hud stuff here?

                    // interact
                    if (Input.IsActionJustPressed(interactable.InputMapInteraction))
                    {
                        GD.Print("player interacted");
                        interactable.InteractWith();
                    }
                }
            }
        }
    }
}
