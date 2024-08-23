using Godot;

public partial class Slime : Node2D
{
    public const float Speed = 60.0f;

    int direction = 1;
    RayCast2D rayCastRight;
    RayCast2D rayCastLeft;
    AnimatedSprite2D animatedSprite;

    public override void _Ready()
    {
        rayCastRight = GetNode<RayCast2D>("RayCastRight");
        rayCastLeft = GetNode<RayCast2D>("RayCastLeft");
        animatedSprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
    }

    public override void _Process(double delta)
    {
        if (rayCastLeft.IsColliding())
        {
            direction = 1;
            animatedSprite.FlipH = false;
        }
        if (rayCastRight.IsColliding())
        {
            direction = -1;
            animatedSprite.FlipH = true;
        }

        Vector2 position = Position;
        position.X += direction * Speed * (float)delta;
        Position = position;
    }
}
