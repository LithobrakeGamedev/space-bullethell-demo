using System.Collections.Generic;
using System.Linq;
using Godot;
using MonoCustomResourceRegistry;

namespace MovementTest.resources.scripts;

[RegisteredType("SimpleStateMachineComp", "", nameof(Node))]
public partial class SimpleStateMachineComp : Node {
    [Export] private StateComp[] stateOrder;

    public override void _Ready() {
        if (stateOrder is null || stateOrder.Length == 0)
            stateOrder = GetChildren().OfType<StateComp>().ToArray();
        
        for (int i = 0; i < stateOrder.Length; i++) {
            stateOrder[i].Disable();
            stateOrder[i].StateFinished += stateOrder[(i + 1) % stateOrder.Length].Enable;
        }

        if (stateOrder.Length > 0)
            stateOrder[0].Enable();
    }
}
