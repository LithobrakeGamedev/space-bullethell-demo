using System;
using Godot;
using MonoCustomResourceRegistry;

namespace MovementTest.resources.scripts;

[RegisteredType("Ship", "", nameof(Node2D))]
public partial class Ship : Node2D {
    private Spawner leftMuzzle;
    private Spawner rightMuzzle;
    private Timer timer;
    private ScaleOnImpact scaleOnImpact;
    private AnimatedSprite2D shipSprite;
    private AnimatedSprite2D shipFlameSprite;
    private MoveComponent moveComponent;

    [Export] private EntityStats stats;
    [Export] private Spawner explodeOnDeath;
    [Export] private VariablePitchAudioStreamPlayerComp audio;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready() {
        leftMuzzle = GetNode<Spawner>("Markers/LeftMuzzle/Spawner");
        rightMuzzle = GetNode<Spawner>("Markers/RightMuzzle/Spawner");
        timer = GetNode<Timer>("FireRateTimer");
        shipSprite = GetNode<AnimatedSprite2D>("Anchor/ShipAnimatedSprite");
        shipFlameSprite = GetNode<AnimatedSprite2D>("Anchor/FlameAnimatedSprite");
        moveComponent = GetNode<MoveComponent>("MoveComponent");

        timer.Timeout += FireLasers;

        scaleOnImpact = GetNode<ScaleOnImpact>("ScaleOnImpact");

        stats.NoHealth += QueueFree;
        stats.NoHealth += () => explodeOnDeath.Spawn();
        stats.NoHealth += () => PlayerDeath?.Invoke();
    }

    public override void _Process(double delta) {
        AnimateShip();
    }

    private void FireLasers() {
        audio.PlayWithVariance(0);
        leftMuzzle.Spawn();
        rightMuzzle.Spawn();
        scaleOnImpact.TweenScale();
    }

    private void AnimateShip() {
        string dir = moveComponent.Velocity.X switch {
            < 0 => "bank_left",
            > 0 => "bank_right",
            _ => "center"
        };
        shipSprite.Play(dir);
        shipFlameSprite.Play(dir);
    }

    public event Action PlayerDeath;
}
