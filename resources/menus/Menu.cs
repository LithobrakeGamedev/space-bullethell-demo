using Godot;

namespace MovementTest.resources.menus;

public partial class Menu : Control
{
    [Export] PackedScene gameScene;
    public override void _Process(double delta) {
        if (Input.IsActionPressed("ui_accept")) {
            GetTree().ChangeSceneToPacked(gameScene);
        }
    }
}