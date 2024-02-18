using Godot;
using MonoCustomResourceRegistry;

namespace MovementTest.resources.scripts;

[RegisteredType("BorderBounceComp", "", nameof(Node))]
public partial class BorderBounceComp : Node {
    [Export] int margin = 8;
    [Export] Node2D actor;
    [Export] MoveComponent moveComponent;

    private int leftBorder = 0;
    private int rightBorder = (int)ProjectSettings.GetSetting("display/window/size/viewport_width");

    public override void _Process(double delta) {
        if (actor.GlobalPosition.X < leftBorder + margin) {
            actor.GlobalPosition = actor.GlobalPosition with { X = 2 * (leftBorder + margin) - actor.GlobalPosition.X };
            moveComponent.Velocity = moveComponent.Velocity.Bounce(Vector2.Right);
        } else if (actor.GlobalPosition.X > rightBorder - margin) {
            actor.GlobalPosition = actor.GlobalPosition with { X = 2 * (rightBorder - margin) - actor.GlobalPosition.X };
            moveComponent.Velocity = moveComponent.Velocity.Bounce(Vector2.Left);
        }
    }
}