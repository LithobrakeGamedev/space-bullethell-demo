using System;
using Godot;
using MonoCustomResourceRegistry;

namespace MovementTest.resources.enemies.EnemyGeneration;
public interface IEnemyGenerationController {
    public event Action<PackedScene, Vector2> SpawnEnemy;
}