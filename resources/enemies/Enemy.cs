using Godot;
using MovementTest.resources.scripts;

namespace MovementTest.resources.enemies;

public partial class Enemy : Node2D
{
	[Export] AnimatedSprite2D animatedSprite2D;

	[Export] private MoveComponent moveComponent;

	[Export] VisibleOnScreenNotifier2D visibleOnScreenNotifier;

	[Export] ScaleOnImpact scaleOnImpact;

	[Export] Flash flash;

	[Export] EntityStats entityStats;

	public override void _Ready() {
		visibleOnScreenNotifier.ScreenExited += QueueFree;
	}
}