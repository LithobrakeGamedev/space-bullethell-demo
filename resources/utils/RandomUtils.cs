using Godot;

namespace MovementTest.resources.utils;

public static class RandomUtils {

    public static float SingleRange(float low, float high) {
        return GD.Randf() * (high - low) + low;
    }
    
    public static float SingleRange(float high = 1f) {
        return GD.Randf() * high;
    }
    
    public static double DoubleRange(double low, double high) {
        return GD.RandRange(low, high);
    }
    
    public static double DoubleRange(double high = 1f) {
        return GD.RandRange(0, high);
    }
}
