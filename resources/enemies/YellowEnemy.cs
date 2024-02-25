using Godot;

namespace MovementTest.resources.enemies;

public partial class YellowEnemy : Enemy
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		base._Ready();
		moveComponent.Velocity.X = ((float[])[20f, -20f])[GD.Randi() % 2];
	}
}