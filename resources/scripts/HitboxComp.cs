using System;
using Godot;
using MonoCustomResourceRegistry;

namespace MovementTest.resources.scripts;

[RegisteredType("HitboxComp", "", nameof(Area2D))]
public partial class HitboxComp : Area2D {
    [Export] private int damage = 1;

    public Action<HurtboxComp> HitHurtbox;

    public override void _Ready() {
        AreaEntered += OnHurtboxEntered;
    }

    private void OnHurtboxEntered(Area2D area) {
        if (area is not HurtboxComp hurtboxComp)
            return;

        if (hurtboxComp.IsInvisible)
            return;
        
        HitHurtbox?.Invoke(hurtboxComp);
        
        hurtboxComp.Hurt?.Invoke(this);
    }
}
