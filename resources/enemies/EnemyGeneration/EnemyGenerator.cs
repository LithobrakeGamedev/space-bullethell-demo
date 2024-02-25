using Godot;
using MovementTest.resources.scripts;
using MovementTest.resources.utils;

namespace MovementTest.resources.enemies.EnemyGeneration;

public partial class EnemyGenerator : Node2D {
    [Export] Spawner spawner;
    [Export] Node generationControllers;
    [Export] Node2D enemyContainer;

    public override void _Ready() {
        foreach(var child in generationControllers.GetChildren()) {
            if (child is IEnemyGenerationController controller) {
                controller.SpawnEnemy += HandleSpawn;
            }
        }
        generationControllers.ChildEnteredTree += (child) => {
            if (child is IEnemyGenerationController controller) {
                controller.SpawnEnemy += HandleSpawn;
            }
        };
    }
    void HandleSpawn(PackedScene enemyScene, Vector2 location) {
        spawner.Scene = enemyScene;
        spawner.Spawn(location, enemyContainer);
    }
}
