using Godot;
using System;

public partial class Interact : RayCast3D
{
    private Interactable lastInteractable;

    [Signal]
    public delegate void StartLookingAtInteractableEventHandler(string text);

    [Signal]
    public delegate void EndLookingAtInteractableEventHandler();

    public override void _Ready()
    {
        base._Ready();
        lastInteractable = null;
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
                    if (interactable != lastInteractable)
                    {
                        lastInteractable = interactable;
                        EmitSignal(SignalName.StartLookingAtInteractable, interactable.InteractionName);
                    }

                    // interact
                    if (Input.IsActionJustPressed(interactable.InputMapInteraction))
                    {
                        interactable.InteractWith();
                    }
                    return;
                }
            }
        }
        if (lastInteractable != null)
        {
            lastInteractable = null;
            EmitSignal(SignalName.EndLookingAtInteractable);
        }
    }
}
