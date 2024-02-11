using Godot;
using MonoCustomResourceRegistry;

namespace MovementTest.resources.scripts;

[RegisteredType("PositionClamp", "", nameof(Node2D))]
public partial class PositionClamp : Node2D {
    [Export] public Node2D Actor;
    [Export] public int Margin = 8;

    private int leftBorder = 0;
    private int rightBorder = (int)ProjectSettings.GetSetting("display/window/size/viewport_width");

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta) {
        Actor.GlobalPosition = Actor.GlobalPosition with {
            X = float.Clamp(Actor.GlobalPosition.X, leftBorder + Margin, rightBorder - Margin)
        };
    }
}
