using Godot;
using MonoCustomResourceRegistry;

namespace MovementTest.resources.scripts;

enum Priority {
    Timer = 10,
    Default = 0
}

[RegisteredType("StopwatchComp", "", nameof(Node))]
public partial class StopwatchComp : Node {
    public double Time { get; private set; }

    public override void _Ready() {
        ProcessPriority = (int)Priority.Timer;
    }

    public override void _Process(double delta) {
        Time += delta;
    }
}