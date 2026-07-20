package de.atomi.starwrought.client.mixin;

import de.atomi.starwrought.client.fx.TraumaCamera;
import net.minecraft.client.render.Camera;
import org.spongepowered.asm.mixin.Mixin;
import org.spongepowered.asm.mixin.injection.At;
import org.spongepowered.asm.mixin.injection.ModifyVariable;

@Mixin(Camera.class)
public abstract class CameraTraumaMixin {
	@ModifyVariable(method = "setRotation", at = @At("HEAD"), argsOnly = true, ordinal = 0)
	private float starwrought$offsetYaw(float yaw) {
		return yaw + TraumaCamera.yawOffset();
	}

	@ModifyVariable(method = "setRotation", at = @At("HEAD"), argsOnly = true, ordinal = 1)
	private float starwrought$offsetPitch(float pitch) {
		return pitch + TraumaCamera.pitchOffset();
	}
}
