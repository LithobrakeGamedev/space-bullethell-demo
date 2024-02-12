using Godot;

namespace MovementTest.resources.effects;

public partial class SpaceBackground : ParallaxBackground {
    private ParallaxLayer closeStarsLayer;
    private ParallaxLayer farStarsLayer;
    private ParallaxLayer spaceLayer;

    public override void _Ready() {
        spaceLayer = GetNode<ParallaxLayer>("SpaceLayer");
        farStarsLayer = GetNode<ParallaxLayer>("FarStarsLayer");
        closeStarsLayer = GetNode<ParallaxLayer>("CloseStarsLayer");
    }
    
    public override void _Process(double delta) {
        closeStarsLayer.MotionOffset -= Vector2.Up * 20 * (float)delta;
        farStarsLayer.MotionOffset -= Vector2.Up * 10 * (float)delta;
        spaceLayer.MotionOffset -= Vector2.Up * 5 * (float)delta;
    }
}
