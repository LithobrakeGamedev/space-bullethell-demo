using System;
using Godot;
using MonoCustomResourceRegistry;

namespace MovementTest.resources.scripts;

[RegisteredType("HurtboxComp", "", nameof(Area2D))]
public partial class HurtboxComp : Area2D {
    private bool _isInvisible;
    public bool IsInvisible {
        get => _isInvisible;
        set {
            _isInvisible = value;

            foreach(var child in GetChildren()) {
                if (child is not CollisionShape2D && child is not CollisionPolygon2D)
                    continue;

                child.SetDeferred("disabled", _isInvisible);
            }
        }
    }
    
    public Action<HitboxComp> Hurt;
}
