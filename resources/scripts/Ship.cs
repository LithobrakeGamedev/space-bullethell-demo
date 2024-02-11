using Godot;
using MonoCustomResourceRegistry;

namespace MovementTest.resources.scripts;

[RegisteredType("Ship", "", nameof(Node2D))]
public partial class Ship : Node2D {
	private Spawner leftMuzzle;
	private Spawner rightMuzzle;
	private Timer timer;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready() {
		leftMuzzle = GetNode<Spawner>("Markers/LeftMuzzle/Spawner");
		rightMuzzle = GetNode<Spawner>("Markers/RightMuzzle/Spawner");
		timer = GetNode<Timer>("FireRateTimer");

		timer.Timeout += FireLasers;
	}

	private void FireLasers() {
		leftMuzzle.Spawn();
		rightMuzzle.Spawn();
	}
}