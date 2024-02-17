using Godot;
using MonoCustomResourceRegistry;

namespace MovementTest.resources.resources;

[RegisteredType("ResourceStash", "", nameof(Node))]
public partial class ResourceStash : Node {
    [Export] public GameStats GameStats = GD.Load<GameStats>("res://resources/resources/GameStats.tres");
}
