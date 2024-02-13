using Godot;
using MonoCustomResourceRegistry;
using MovementTest.resources.utils;

namespace MovementTest.resources.scripts;

[RegisteredType("ShakeComp", "", nameof(Node))]
public partial class ShakeComp : Node {
    [Export] private Node2D node;
    [Export] float shakeAmount = 2f;
    [Export] float shakeDuration = 0.4f;

    private float shake;

    public void TweenShake() {
        shake = shakeAmount;

        var tween = CreateTween();

        tween.TweenMethod(Callable.From<float>(val => { shake = val; }), tween, 0f, shakeDuration);
    }

    public override void _PhysicsProcess(double delta) {
        node.Position = new Vector2(RandomUtils.SingleRange(-shake, shake), RandomUtils.SingleRange(-shake, shake));
    }
}
