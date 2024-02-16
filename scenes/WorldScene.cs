using System.IO;
using System.Threading;
using Godot;
using MovementTest.resources.resources;
using MovementTest.resources.scripts;
using MovementTest.resources.utils.extensionMethods;
using Semaphore = System.Threading.Semaphore;

namespace MovementTest.scenes;

public partial class WorldScene : Node2D {
    [Export] Ship playerShip;

    [Export] private float postDeathTime = 1f;

    [Export] Label scoreLabel;

    [Export] GameStats gameStats;

    public override void _Ready() {
        playerShip.PlayerDeath += OnPlayerDeath;

        gameStats.ScoreChanged += UpdateScoreLabel;
        UpdateScoreLabel(gameStats.Score);
    }

    async void OnPlayerDeath() {
        await GetTree().CreateTimer(postDeathTime).Async();

        GetTree().ChangeSceneToFile("resources/menus/game_over.tscn");
    }

    void UpdateScoreLabel(int newScore) {
        scoreLabel.Text = $"Score: {newScore}";
    }

    protected override void Dispose(bool disposing) {
        gameStats.ScoreChanged -= UpdateScoreLabel;
    }
}
