using Godot;
using System;

public partial class Summary : Label
{
    [Export]
    Label resultsLabel;
    public override void _Ready()
    {
        base._Ready();

        Input.MouseMode = Input.MouseModeEnum.Visible;

        Text = $@"GAME OVER!!!!!!!
SCORE: {Score.value}";

        resultsLabel.Text = $@"You got:
{Score.results}
Better luck next time!";
    }
}
