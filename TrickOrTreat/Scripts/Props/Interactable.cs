using Godot;
using System;

public partial class Interactable : Node
{
	[Export]
	public string InputMapInteraction = "Interact";

	[Export]
    public string InteractionName = "Interact";

    [Export]
    public bool Enabled = true;

	[Signal]
	public delegate void InteractedWithEventHandler();

	public void InteractWith()
	{
        EmitSignal(SignalName.InteractedWith);
	}
}
