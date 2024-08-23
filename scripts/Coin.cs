using Godot;

public partial class Coin : Area2D
{
    GameManager gameManager;
    AnimationPlayer animationPlayer;

    public override void _Ready()
    {
        gameManager = GetNode<GameManager>("%GameManager");
        animationPlayer = GetNode<AnimationPlayer>("AnimationPlayer");
    }

    private void _OnBodyEntered(Node2D body)
    {
        gameManager.addPoint();
        animationPlayer.Play("pickup");
    }
}
