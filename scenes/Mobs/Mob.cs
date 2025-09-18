using Godot;

public partial class Mob : CharacterBody3D
{
    [Export]
    public int MinSpeed { get; set; } = 10;
    [Export]
    public int MaxSpeed { get; set; } = 18;

    public override void _PhysicsProcess(double delta)
    {
        MoveAndSlide();
    }

    // Called from the Main Scene.
    public void Initialize(Vector3 startPosition, Vector3 playerPosition)
    {


        // We position the mob by placing it at startPosition
        // and rotate it towards playerPosition, so it looks at the player.
        LookAtFromPosition(startPosition, playerPosition, Vector3.Up);
        // Rotate this mob randomly within range of -45 and +45 degrees,
        // so that it doesn't move directly towards the player.
        RotateY((float)GD.RandRange(-Mathf.Pi / 4.0, Mathf.Pi / 4.0));

        // We calculate a random speed (integer).
        int randomSpeed = GD.RandRange(MinSpeed, MaxSpeed);
        // We calculate a forward velocity that represents the speed.
        Velocity = Vector3.Forward * randomSpeed;
        // We then rotate the velocity vector based on the mob's Y rotation
        // in order to move in the direction the mob is looking.
        Velocity = Velocity.Rotated(Vector3.Up, Rotation.Y);
    }

    private void OnVisibilityNotifierScreenExited()
    {
        QueueFree();
    }
}
