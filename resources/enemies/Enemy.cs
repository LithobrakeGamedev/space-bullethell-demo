using Godot;
using MovementTest.resources.scripts;

namespace MovementTest.resources.enemies;

public partial class Enemy : Node2D {
    [Export] AnimatedSprite2D animatedSprite2D;

    [Export] private MoveComponent moveComponent;

    [Export] VisibleOnScreenNotifier2D visibleOnScreenNotifier;

    [Export] ScaleOnImpact scaleOnImpact;

    [Export] Flash flash;

    [Export] EntityStats entityStats;

    [Export] ShakeComp shake;

    [Export] HitboxComp hitbox;
    [Export] HurtboxComp hurtbox;

    [Export] Spawner onDeathEffect;

    public override void _Ready() {
        visibleOnScreenNotifier.ScreenExited += QueueFree;
        hurtbox.Hurt += _ => {
            scaleOnImpact.TweenScale();
            flash.ApplyFlash();
            shake.TweenShake();
        };
        entityStats.NoHealth += Death;
        hitbox.HitHurtbox += _ => Death();
    }

    private void Death() {
        onDeathEffect.Spawn();
        QueueFree();
    }
}
