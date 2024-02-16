using Godot;
using MonoCustomResourceRegistry;
using MovementTest.resources.resources;

namespace MovementTest.resources.scripts;

[RegisteredType("ScoreComp", "", nameof(Node))]
public partial class ScoreComp : Node {
    [Export] GameStats gameStats;

    [Export] int scoreDelta;

    public void AdjustScore(int? amount = null) {
        gameStats.Score += amount ?? scoreDelta;
    }
}