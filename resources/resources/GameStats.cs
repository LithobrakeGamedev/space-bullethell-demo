using System;
using Godot;

namespace MovementTest.resources.resources;

public partial class GameStats : Resource {
    private int _score = 0;
    [Export] public int Score { get => _score; set { _score = value; ScoreChanged?.Invoke(_score); } }

    [Export] int highScore = 0;

    public event Action<int> ScoreChanged;
}