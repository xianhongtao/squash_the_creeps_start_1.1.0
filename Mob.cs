using Godot;

public partial class Mob : CharacterBody3D
{
    public int MinSpeed { get; set; } = 10;
    public int MaxSpeed { get; set; } = 18;
    public override void _PhysicsProcess(double delta)
    {
        MoveAndSlide();
    }
    public void Initialize(Vector3 startedPosition, Vector3 playerPosition)
    {
        LookAtFromPosition(startedPosition, playerPosition, Vector3.Up);
        RotateY((float)GD.RandRange(-Mathf.Pi / 4.0, Mathf.Pi / 4.0));
        int randomSpeed = GD.RandRange(MinSpeed, MaxSpeed);
        Velocity = Vector3.Forward * randomSpeed;
        Velocity = Velocity.Rotated(Vector3.Up, Rotation.Y);
    }
    private void OnVisibilityNotifierScreenExited()
    {
        QueueFree();
    }
}