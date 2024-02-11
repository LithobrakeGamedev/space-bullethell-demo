using Godot;
using MonoCustomResourceRegistry;

namespace MovementTest.resources.scripts;

[RegisteredType("Laser", "", nameof(Node2D))]
public partial class Laser : Node2D {
	// Called when the node enters the scene tree for the first time.
	public override void _Ready() {
		GetNode<VisibleOnScreenNotifier2D>("VisibleOnScreenNotifier2D").ScreenExited += QueueFree;
		GetNode<ScaleOnImpact>("ScaleOnImpact").TweenScale();
	}
}