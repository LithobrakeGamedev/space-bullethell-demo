using System;
using Godot;
using MonoCustomResourceRegistry;
using MovementTest.resources.resources;
using MovementTest.resources.scripts;
using MovementTest.resources.utils;

namespace MovementTest.resources.enemies.EnemyGeneration;

[RegisteredType("TimedEnemyGenerationController", "", nameof(Node))]
public partial class TimedEnemyGenerationController : Node, IEnemyGenerationController {
    [Export] private PackedScene enemy;
    [Export] private GameStats gameStats;
    [Export] private StopwatchComp stopwatch;
    private Timer timer;

    [ExportGroup("Time Configuration")] 
    
    [Export] private float initialTimeInterval;
    [Export] private float minTimeInterval;
    [Export] private float timeMultiplier = 0.01f;
    [Export] private float scoreMultiplier = 0.01f;

    [Export] private float minTime;
    [Export] private float minScore;

    private int margin = 2;
    private int screenWidth = (int)ProjectSettings.GetSetting("display/window/size/viewport_width");
    public override void _Ready() {
        timer = NodeBuilder.Timer(
            initialTimeInterval,
            this,
            false,
            false
        );
        timer.Timeout += () => SpawnEnemy?.Invoke(enemy, new Vector2(RandomUtils.SingleRange(margin, screenWidth - margin), -16));
    }

    public override void _Process(double delta) {
        if (timer.IsStopped() && stopwatch.Time >= minTime && gameStats.Score >= minScore)
            timer.Start();

        if (!timer.IsStopped()) {
            timer.WaitTime = minTimeInterval +
                (initialTimeInterval - minTimeInterval) / 
                (1 + timeMultiplier * (stopwatch.Time - minTime) + scoreMultiplier * (gameStats.Score - minScore) );
        }

    }

    public event Action<PackedScene, Vector2> SpawnEnemy;
}
