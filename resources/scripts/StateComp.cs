using System;
using Godot;
using MonoCustomResourceRegistry;

namespace MovementTest.resources.scripts;

[RegisteredType("StateComp", "", nameof(Node))]
public partial class StateComp : Node {
    public event Action Enabled;
    public event Action Disabled;
    public event Action StateFinished;
    
    public void StateFinish() {
        StateFinished?.Invoke();
    }

    public void Disable() {
        Disabled?.Invoke();
        ProcessMode = ProcessModeEnum.Disabled;
    }

    public void Enable() {
        Enabled?.Invoke();
        ProcessMode = ProcessModeEnum.Inherit;
    }
}