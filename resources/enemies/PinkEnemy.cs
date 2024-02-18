using Godot;
using MovementTest.resources.scripts;

namespace MovementTest.resources.enemies;

public partial class PinkEnemy : Enemy
{
    [Export] private MoveComponent sideMove;
    public override void _Ready() {
        base._Ready();
        sideMove.Velocity.X = ((int[])[-20, 20])[GD.Randi() % 2];
    }
}