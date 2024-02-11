using Godot;
using MonoCustomResourceRegistry;
using MovementTest.resources.resources;

namespace MovementTest.resources.scripts;

[RegisteredType("MoveInputComponent", "", nameof(Node))]
public partial class MoveInputComponent : Node {
    [Export] public MoveComponent MoveComponent;
    [Export] public MoveStats MoveStats;
    public override void _Input(InputEvent @event) {
        var inputAxis = Input.GetAxis("ui_left", "ui_right");
        MoveComponent.Velocity = new Vector2(inputAxis * MoveStats.Speed, 0);
    }
}
