using Godot;
using MovementTest.resources.resources;

namespace MovementTest.resources.menus;

public partial class GameOverMenu : Menu
{
    [Export] Label score;
    [Export] Label highScore;
    [Export] GameStats stats;

    public override void _Ready() {
        stats.HighScore = int.Max(stats.HighScore, stats.Score);
        score.Text = stats.Score.ToString();
        highScore.Text = stats.HighScore.ToString();

        stats.Score = 0;
    }
}