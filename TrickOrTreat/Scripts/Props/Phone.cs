using Godot;
using System;

public partial class Phone : MeshInstance3D
{
    private Dialogue dialogue;
    [Export]
    public string DialoguePath;

    [Export]
    public string[] Lines;

    [Export]
    public string[] Names;

    private int index = 0;

    public override void _Ready()
    {
        base._Ready();
        dialogue = GetNode<Dialogue>(DialoguePath);
    }

    public void AnswerPhone()
    {
        dialogue.ShowDialogue(Names[index], Lines[index]);

        index++;
        if (index >= Lines.Length)
        {
            index = 0;
        }

    }
}
