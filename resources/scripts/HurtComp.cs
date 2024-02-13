using Godot;
using MonoCustomResourceRegistry;

namespace MovementTest.resources.scripts;

[RegisteredType("HurtComp", "", nameof(Node))]
public partial class HurtComp : Node {
    [Export] EntityStats stats;
    [Export] HurtboxComp hurtbox;

    public override void _Ready() {
        hurtbox.Hurt += hitbox => { stats.Health -= hitbox.Damage; };
    }
}
