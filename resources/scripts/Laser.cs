using Godot;
using MonoCustomResourceRegistry;

namespace MovementTest.resources.scripts;

[RegisteredType("Laser", "", nameof(Node2D))]
public partial class Laser : Node2D {
	[Export] HitboxComp hitbox;
	public override void _Ready() {
		GetNode<VisibleOnScreenNotifier2D>("VisibleOnScreenNotifier2D").ScreenExited += QueueFree;
		GetNode<ScaleOnImpact>("ScaleOnImpact").TweenScale();
		GetNode<Flash>("Flash").ApplyFlash();
		hitbox.HitHurtbox += _ => QueueFree();
	}
}