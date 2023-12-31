using Godot;
using System;

public partial class Hud : Control
{
    private Label InteractText;
    private TextureRect Crosshair;
    private Dialogue Dialogue;
    public SlingshotHud Slingshot;

    [Export]
    private Texture2D NormalCrosshair;
    [Export]
    private Texture2D InteractCrosshair;

    public override void _Ready()
    {
        base._Ready();
        InteractText = GetNode<Label>("InteractText");
        InteractText.Visible = false;

        Crosshair = GetNode<TextureRect>("Crosshair/TextureRect");
        Crosshair.Texture = NormalCrosshair;

        Dialogue = GetNode<Dialogue>("Dialogue");
        Dialogue.HideDialogue();

        Slingshot = GetNode<SlingshotHud>("Slingshot");
        Slingshot.SetProjectileType(-1);
    }

    public void ShowInteractText(string text)
    {
        InteractText.Visible = true;
        InteractText.Text = "[Right Click] " + text;

        Crosshair.Texture = InteractCrosshair;
    }

    public void HideInteractText()
    {
        InteractText.Visible = false;

        Crosshair.Texture = NormalCrosshair;
    }
}
