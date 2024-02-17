using System;
using Godot;
using MonoCustomResourceRegistry;
using MovementTest.resources.utils;

namespace MovementTest.resources.enemies.EnemyGeneration;

[RegisteredType("SimpleEnemyGenerationController", "", nameof(Node))]
public partial class SimpleEnemyGenerationController : Node, IEnemyGenerationController {
    [Export] PackedScene enemy;
    [Export] float timeInterval;
    private Timer timer;

    private int margin = 2;
    int screenWidth = (int)ProjectSettings.GetSetting("display/window/size/viewport_width");
    public override void _Ready() {
        timer = NodeBuilder.Timer(
            timeInterval,
            this,
            false
        );
        timer.Timeout += () => SpawnEnemy?.Invoke(enemy, new Vector2(RandomUtils.SingleRange(margin, screenWidth - margin), -16));
    }

    public event Action<PackedScene, Vector2> SpawnEnemy;
}
