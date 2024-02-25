using Godot;

namespace MovementTest.resources.utils;

public static class NodeBuilder {
    public static Timer Timer(
        float time = 1f,
        Node parent = null,
        bool oneShot = true,
        bool autoStart = true,
        Timer.TimerProcessCallback processCallback = Godot.Timer.TimerProcessCallback.Idle,
        bool destroyOnTimeout = false
    ) {
        Timer timer = new();
        timer.WaitTime = time;
        timer.OneShot = oneShot;
        timer.Autostart = autoStart;
        timer.ProcessCallback = processCallback;
        parent?.AddChild(timer);
        if (destroyOnTimeout)
            timer.Timeout += timer.QueueFree;
        return timer;
    }
}
