using Godot;
using MonoCustomResourceRegistry;

namespace MovementTest.resources.scripts;

[RegisteredType("MoveComponent", "", nameof(Node))]
public partial class MoveComponent : Node {
	[Export] public Node2D Actor;
	[Export] public Vector2 Velocity;

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta) {
		Actor.Translate(Velocity * (float)delta);
	}
}
