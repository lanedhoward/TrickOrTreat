using Godot;
using System;
using System.Threading.Tasks;

public partial class Dialogue : Control
{
    private RichTextLabel name;
    private RichTextLabel dialogue;

    [Signal]
    public delegate void StartDialogueEventHandler(string message);

    private double timer;

    public override void _Ready()
    {
        base._Ready();
        name = GetNode<RichTextLabel>("NameLabel");
        dialogue = GetNode<RichTextLabel>("DialogueLabel");
    }

    public void ShowDialogue(string speaker, string message)
    {
        this.Visible = true;
        name.Text = speaker;
        //dialogue.Set("messages", new string[1] { message });
        EmitSignal(SignalName.StartDialogue, message);
    }

    public void DelayHideDialogue()
    {
        timer = 2;
    }

    public void HideDialogue()
    {
        this.Visible = false;
    }

    public override void _Process(double delta)
    {
        base._Process(delta);

        if (timer > 0)
        {
            timer -= delta;

            if (timer <= 0)
            {
                HideDialogue();
            }
        }
    }
}
