using System.Threading.Tasks;
using Godot;

namespace MovementTest.resources.utils.extensionMethods;

public static class NodeTimerExtensions {
    public static async Task Async(this Timer timer) {
        TaskCompletionSource tcs = new();
        timer.Timeout += () => tcs.SetResult();
        await tcs.Task;
    }
    
    public static async Task Async(this SceneTreeTimer timer) {
        TaskCompletionSource tcs = new();
        timer.Timeout += () => tcs.SetResult();
        await tcs.Task;
    }
}
