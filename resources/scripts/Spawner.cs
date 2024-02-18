using System;
using Godot;
using MonoCustomResourceRegistry;

namespace MovementTest.resources.scripts;

[RegisteredType("Spawner", "", nameof(Node2D))]
public partial class Spawner : Node2D {
    [Export(hintString: "The scene we want to spawn")]
    public PackedScene Scene;

    public Node Spawn(Vector2? globalSpawnPosition = null, Node parent = null) {
        if (Scene is null)
            throw new Exception("Spawned scene has not been set");

        var instance = Scene.Instantiate();

        // Assign parent
        (parent ?? GetTree().CurrentScene).AddChild(instance, forceReadableName: true);

        // Set position
        if (instance is Node2D node2D) {
            node2D.GlobalPosition = globalSpawnPosition ?? GlobalPosition;
        }
        
        return instance;
    }
}
