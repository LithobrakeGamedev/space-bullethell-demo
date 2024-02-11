using Godot;
using MonoCustomResourceRegistry;

namespace MovementTest.resources.scripts;

[RegisteredType("Flash", "", nameof(Node))]
public partial class Flash : Node {
	[Export] public Material FlashMaterial;

	[Export] public CanvasItem Sprite;

	[Export] public float FlashDuration = 0.2f;

	private Material originalMaterial;
	private Timer timer = new();
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		AddChild(timer);

		originalMaterial = Sprite.Material;
	}

	public async void ApplyFlash() {
		Sprite.Material = FlashMaterial;
		
		timer.Start(FlashDuration);
		await ToSignal(timer, "timeout");

		Sprite.Material = originalMaterial;
	}
}