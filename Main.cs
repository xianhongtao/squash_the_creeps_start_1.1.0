using Godot;
using System;

public partial class Main : Node
{
	[Export]
	public PackedScene  MobScence{ get; set; }
	private void OnMobTimerTimeout()
	{
		Mob mob = MobScence.Instantiate<Mob>();
		var mobSpawnLocation = GetNode<PathFollow3D>("SpawnPath/SpawnLocation");
		mobSpawnLocation.ProgressRatio = GD.Randf();
		Vector3 playerPosition = GetNode<Player>("Player").Position;
		mob.Initialize(mobSpawnLocation.Position, playerPosition);
		AddChild(mob);
    }
}