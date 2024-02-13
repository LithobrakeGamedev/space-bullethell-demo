using System;
using Godot;
using MonoCustomResourceRegistry;

namespace MovementTest.resources.scripts;

[RegisteredType("EntityStats", "", nameof(Node))]
public partial class EntityStats : Node {
    private int _health = 1;
    [Export]
    public int Health {
        get => _health;
        set {
            _health = value;

            HealthChanged?.Invoke();

            if (_health <= 0)
                NoHealth?.Invoke();
        }
    }
    
    public event Action HealthChanged;
    
    public event Action NoHealth;
}
