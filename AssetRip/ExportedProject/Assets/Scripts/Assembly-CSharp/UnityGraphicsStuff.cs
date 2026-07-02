using System.Reflection;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public static class UnityGraphicsStuff
{
	public static FieldInfo MainLightCastShadows_FieldInfo;

	public static FieldInfo AdditionalLightCastShadows_FieldInfo;

	public static FieldInfo MainLightShadowmapResolution_FieldInfo;

	public static FieldInfo AdditionalLightShadowmapResolution_FieldInfo;

	public static FieldInfo Cascade2Split_FieldInfo;

	public static FieldInfo Cascade4Split_FieldInfo;

	public static FieldInfo SoftShadowsEnabled_FieldInfo;

	public static bool MainLightCastShadows
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public static bool AdditionalLightCastShadows
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public static ShadowResolution MainLightShadowResolution
	{
		get
		{
			return default(ShadowResolution);
		}
		set
		{
		}
	}

	public static ShadowResolution AdditionalLightShadowResolution
	{
		get
		{
			return default(ShadowResolution);
		}
		set
		{
		}
	}

	public static float Cascade2Split
	{
		get
		{
			return 0f;
		}
		set
		{
		}
	}

	public static Vector3 Cascade4Split
	{
		get
		{
			return default(Vector3);
		}
		set
		{
		}
	}

	public static bool SoftShadowsEnabled
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	static UnityGraphicsStuff()
	{
	}
}
