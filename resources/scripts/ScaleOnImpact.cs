using Godot;
using MonoCustomResourceRegistry;

namespace MovementTest.resources.scripts;

[RegisteredType("ScaleOnImpact", "", nameof(Node))]
public partial class ScaleOnImpact : Node {
	[Export] public Node2D Sprite;
	[Export] public Vector2 ScaleAmount = new(1.2f, 1.2f);
	[Export] public float ScaleDuration = 0.4f;

	public void TweenScale() {
		var tween = CreateTween().SetTrans(Tween.TransitionType.Expo).SetEase(Tween.EaseType.Out);

		tween.TweenProperty(Sprite, "scale", ScaleAmount, ScaleDuration * 0.1).FromCurrent();

		tween.TweenProperty(Sprite, "scale", Vector2.One, ScaleDuration * 0.9).From(ScaleAmount);
	}
}