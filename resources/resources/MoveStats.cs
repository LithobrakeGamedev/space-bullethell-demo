using Godot;
using MonoCustomResourceRegistry;

namespace MovementTest.resources.resources;

[RegisteredType("MoveStats", "", nameof(Resource))]

public partial class MoveStats : Resource {
    [Export] public float Speed;
}