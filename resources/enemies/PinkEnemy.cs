using Godot;
using MovementTest.resources.scripts;

namespace MovementTest.resources.enemies;

public partial class PinkEnemy : Enemy
{
    [Export] private MoveComponent sideMove;
    [Export] private Spawner projectileSpawner;
    [Export] private StateComp fireState;
    public override void _Ready() {
        base._Ready();
        sideMove.Velocity.X = ((int[])[-20, 20])[GD.Randi() % 2];

        fireState.Enabled += () => {
            scaleOnImpact.TweenScale();
            projectileSpawner.Spawn(GlobalPosition);
            fireState.Disable();
            fireState.StateFinish();
        };
    }
}