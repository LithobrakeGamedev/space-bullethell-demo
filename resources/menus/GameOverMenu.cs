using Godot;
using MovementTest.resources.resources;

namespace MovementTest.resources.menus;

public partial class GameOverMenu : Menu
{
    [Export] private Label score;
    [Export] private Label highScore;
    [Export] private GameStats stats;

    public override void _Ready() {
        savePath = OS.HasFeature("standalone") ?
            ProductionSavePath :
            TestSavePath;
        LoadHighScore();
        stats.HighScore = int.Max(stats.HighScore, stats.Score);
        SaveHighScore();
        score.Text = stats.Score.ToString();
        highScore.Text = stats.HighScore.ToString();

        stats.Score = 0;
    }

    private const string ProductionSavePath = "user://save.cfg";
    private const string TestSavePath = "res://save.cfg";

    private string savePath;

    private void LoadHighScore() {
        var config = new ConfigFile();
        var error = config.Load(savePath);
        if (error != Error.Ok) {
            return;
        }
        stats.HighScore = (int)config.GetValue("game", "highscore");
    }

    private void SaveHighScore() {
        var config = new ConfigFile();
        config.SetValue("game", "highscore", stats.HighScore);
        config.Save(savePath);
    }
}