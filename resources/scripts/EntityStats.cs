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

            EmitSignal(SignalName.HealthChanged);

            if (_health <= 0)
                EmitSignal(SignalName.NoHealth);
        }
    }

    [Signal]
    public delegate void HealthChangedEventHandler();

    [Signal]
    public delegate void NoHealthEventHandler();
}
