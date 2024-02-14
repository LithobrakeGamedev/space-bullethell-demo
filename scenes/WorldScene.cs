using System.IO;
using System.Threading;
using Godot;
using MovementTest.resources.scripts;
using MovementTest.resources.utils.extensionMethods;
using Semaphore = System.Threading.Semaphore;

namespace MovementTest.scenes;

public partial class WorldScene : Node2D {
    [Export] Ship playerShip;

    [Export] private float postDeathTime = 1f;

    public override void _Ready() {
        playerShip.PlayerDeath += OnPlayerDeath;
    }

    async void OnPlayerDeath() {
        await GetTree().CreateTimer(postDeathTime).Async();

        GetTree().ChangeSceneToFile("resources/menus/game_over.tscn");
    }
}
