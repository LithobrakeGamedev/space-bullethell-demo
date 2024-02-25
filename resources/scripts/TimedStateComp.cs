using Godot;
using MonoCustomResourceRegistry;
using MovementTest.resources.utils;

namespace MovementTest.resources.scripts;

[RegisteredType("TimedStateComp", "", nameof(StateComp))]
public partial class TimedStateComp : StateComp {
    [Export] private float duration;

    private Timer timer;

    public override void _Ready() {
        timer = NodeBuilder.Timer(duration, this);

        timer.Timeout += () => {
            StateFinish();
            Disable();
        };

        Enabled += () => timer.Start(duration);
    }
}