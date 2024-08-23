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
        Engine.TimeScale = 0.5f;
        body.GetNode<CollisionShape2D>("CollisionShape2D").QueueFree();
        timer.Start();
    }

    private void _OnTimeout()
    {
        Engine.TimeScale = 1.0f;
        GetTree().ReloadCurrentScene();
    }
}
