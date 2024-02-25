using Godot;
using MonoCustomResourceRegistry;
using MovementTest.resources.utils;

namespace MovementTest.resources.scripts;

[RegisteredType("VariablePitchAudioStreamPlayerComp", "", nameof(AudioStreamPlayer))]
public partial class VariablePitchAudioStreamPlayerComp : AudioStreamPlayer {
    [Export] private float pitchMin = 0.6f;
    [Export] private float pitchMax = 1.2f;

    [Export] private bool autoPlayWithVariance = false;

    public override void _Ready() {
        if (autoPlayWithVariance)
            PlayWithVariance(0);
    }

    public void PlayWithVariance(float fromPosition) {
        PitchScale = RandomUtils.SingleRange(pitchMin, pitchMax);
        Play(fromPosition);
    }
}