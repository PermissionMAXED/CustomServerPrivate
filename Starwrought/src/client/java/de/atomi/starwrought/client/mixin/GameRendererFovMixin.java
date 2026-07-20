package de.atomi.starwrought.client.mixin;

import de.atomi.starwrought.client.fx.TraumaCamera;
import net.minecraft.client.render.Camera;
import net.minecraft.client.render.GameRenderer;
import org.spongepowered.asm.mixin.Mixin;
import org.spongepowered.asm.mixin.injection.At;
import org.spongepowered.asm.mixin.injection.Inject;
import org.spongepowered.asm.mixin.injection.callback.CallbackInfoReturnable;

@Mixin(GameRenderer.class)
public abstract class GameRendererFovMixin {
	@Inject(method = "getFov", at = @At("RETURN"), cancellable = true)
	private void starwrought$applyFovKick(
			Camera camera,
			float tickProgress,
			boolean changingFov,
			CallbackInfoReturnable<Float> callback
	) {
		callback.setReturnValue(callback.getReturnValueF() * TraumaCamera.fovMultiplier());
	}
}
