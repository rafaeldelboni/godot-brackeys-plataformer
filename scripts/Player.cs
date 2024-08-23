using Godot;

public partial class Player : CharacterBody2D
{
    public const float Speed = 130.0f;
    public const float JumpVelocity = -300.0f;

    AnimatedSprite2D animatedSprite;

    public override void _Ready()
    {
        animatedSprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
    }

    public override void _PhysicsProcess(double delta)
    {
        Vector2 velocity = Velocity;

        // Add the gravity.
        if (!IsOnFloor())
        {
            velocity += GetGravity() * (float)delta;
        }

        // Handle Jump.
        if (Input.IsActionJustPressed("jump") && IsOnFloor())
        {
            velocity.Y = JumpVelocity;
        }

        // Get input direction: 1, 0 , -1
        float direction = Input.GetAxis("move_left", "move_right");

        // Flip the sprite
        if (direction > 0)
        {
            animatedSprite.FlipH = false;
        }
        else if (direction < 0)
        {
            animatedSprite.FlipH = true;
        }

        // Play animations
        if (IsOnFloor())
        {
            if (direction == 0)
            {
                animatedSprite.Play("idle");
            }
            else
            {
                animatedSprite.Play("run");
            }
        }
        else
        {
            animatedSprite.Play("jump");
        }

        // Apply Movement
        if (direction != 0)
        {
            velocity.X = direction * Speed;
        }
        else
        {
            velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
        }

        Velocity = velocity;
        MoveAndSlide();
    }
}
