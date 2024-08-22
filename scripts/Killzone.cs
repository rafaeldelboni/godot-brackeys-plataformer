using Godot;

public partial class Killzone : Area2D
{
    public Timer timer;

    public override void _Ready()
    {
        timer = GetNode<Timer>("Timer");
    }

    private void _OnBodyEntered(Node2D body)
    {
        GD.Print("Dead!");
        timer.Start();
    }

    private void _OnTimeout()
    {
        GetTree().ReloadCurrentScene();
    }
}
