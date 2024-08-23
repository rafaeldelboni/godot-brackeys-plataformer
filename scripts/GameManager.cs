using Godot;

public partial class GameManager : Node
{
    public int score;

    Label scoreLabel;

    public override void _Ready()
    {
        scoreLabel = GetNode<Label>("ScoreLabel");
    }

    public void addPoint()
    {
        score++;
        scoreLabel.Text = $"You collected { score } coins.";
        GD.Print(score);
    }
}
