using System;

namespace MovementTest.resources.utils;

public static class RandomUtils {
    static Random _random = new Random();

    public static float SingleRange(float low, float high) {
        return _random.NextSingle() * (high - low) + low;
    }
    
    public static float SingleRange(float high = 1f) {
        return _random.NextSingle() * high;
    }
    
    public static double DoubleRange(double low, double high) {
        return _random.NextDouble() * (high - low) + low;
    }
    
    public static double DoubleRange(double high = 1f) {
        return _random.NextDouble() * high;
    }
}
