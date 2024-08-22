using Godot;

public partial class Coin : Area2D
{
    private void _OnBodyEntered(Node2D body)
    {
        GD.Print("+1 Coin!");
        QueueFree();
    }
}
