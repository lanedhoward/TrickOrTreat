using Godot;
using System;

public partial class GameManager : Node3D
{
    [Export]
    public Dialogue dialogue;

    public Character character;

    [Export]
    public Label scoreLabel;

    [Export]
    public PackedScene summaryScene;

    public int score;
    public int strikes;

    public override void _Ready()
    {
        base._Ready();

        character = GetNode<Character>("Character");
        OnDoorClosed();

        UpdateScoreLabel();
    }


    public void OnDoorOpened()
    {
        if (!character.interacted)
        {

            dialogue.ShowDialogue(character.DialogueName, character.DialogueText);
        }
    }

    public void OnDoorClosed()
    {
        var c = LaneLibrary.RandomMethods.Choose(Enum.GetValues<Character.Characters>());
        character.SetCharacter(c);
        //character.sprite.Frame = 0;
    }

    public void OnCorrectProjectile()
    {
        score += 100;
        UpdateScoreLabel();
    }

    public void OnWrongProjectile()
    {
        strikes += 1;
        UpdateScoreLabel();
    }

    public void UpdateScoreLabel()
    {
        Score.value = score;   

        string strikesText = "";

        for (int i = 0; i < strikes; i++)
        {
            strikesText += "X";
        }

        scoreLabel.Text = $@"SCORE: {score}
STRIKES: {strikesText}";

        if (strikes >= 3)
        {
            GetTree().ChangeSceneToPacked(summaryScene);        
        }
    }
}
