using Godot;
using MonoCustomResourceRegistry;

namespace MovementTest.resources.scripts;

[RegisteredType("MoveComponent", "", nameof(Node))]
public partial class MoveComponent : Node {
	[Export] public NodePath ActorPath = new("..");
	[Export] public Vector2 Velocity;
	private Node2D actor;

	public override void _Ready() {
		actor = GetNode<Node2D>(ActorPath);
	}
	public override void _Process(double delta) {
		actor.Translate(Velocity * (float)delta);
	}
}
