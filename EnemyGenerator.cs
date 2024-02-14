using Godot;
using MovementTest.resources.scripts;
using MovementTest.resources.utils;

namespace MovementTest;

public partial class EnemyGenerator : Node2D {
    [Export] Spawner spawner;
    [Export] Timer greenEnemyTimer;
    [Export] PackedScene greenEnemy;

    private int margin = 2;
    int screenWidth = (int)ProjectSettings.GetSetting("display/window/size/viewport_width");

    public override void _Ready() {
        greenEnemyTimer.Timeout += () => HandleSpawn(greenEnemy, greenEnemyTimer);
    }
    void HandleSpawn(PackedScene enemyScene, Timer timer) {
        spawner.Scene = enemyScene;
        spawner.Spawn(new Vector2(RandomUtils.SingleRange(margin, screenWidth - margin), -16));
        timer.Start();
    }
}
