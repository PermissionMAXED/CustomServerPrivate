using System;
using System.Runtime.CompilerServices;
using Il2CppInterop.Common.Attributes;
using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.InteropTypes;
using Il2CppInterop.Runtime.Runtime;
using Il2CppSystem;
using UnityEngine;

namespace Il2CppBAPBAP.Entities;

[System.Serializable]
public class LerpProperty : Il2CppSystem.Object
{
	[OriginalName("Assembly-CSharp.dll", "", "PropertyTypes")]
	public enum PropertyTypes
	{
		Float,
		Color,
		Vector,
		Texture
	}

	[OriginalName("Assembly-CSharp.dll", "", "Mode")]
	public enum Mode
	{
		LerpToTarget,
		LerpAlongCurve
	}

	[OriginalName("Assembly-CSharp.dll", "", "PropertyOnAwake")]
	public enum PropertyOnAwake
	{
		DoNothing,
		SetToStartMoment,
		SetToEndMoment
	}

	private static readonly System.IntPtr NativeFieldInfoPtr_Name;

	private static readonly System.IntPtr NativeFieldInfoPtr_IsActive;

	private static readonly System.IntPtr NativeFieldInfoPtr_Finishes;

	private static readonly System.IntPtr NativeFieldInfoPtr_OnlyOnce;

	private static readonly System.IntPtr NativeFieldInfoPtr_NullBlockOnActivate;

	private static readonly System.IntPtr NativeFieldInfoPtr_AllowActivateWhileActive;

	private static readonly System.IntPtr NativeFieldInfoPtr_OnAwake;

	private static readonly System.IntPtr NativeFieldInfoPtr__propertyType;

	private static readonly System.IntPtr NativeFieldInfoPtr__mode;

	private static readonly System.IntPtr NativeFieldInfoPtr__floatCurve;

	private static readonly System.IntPtr NativeFieldInfoPtr__colorCurve;

	private static readonly System.IntPtr NativeFieldInfoPtr__vectorCurveX;

	private static readonly System.IntPtr NativeFieldInfoPtr__vectorCurveY;

	private static readonly System.IntPtr NativeFieldInfoPtr__vectorCurveZ;

	private static readonly System.IntPtr NativeFieldInfoPtr__vectorCurveW;

	private static readonly System.IntPtr NativeFieldInfoPtr__floatTarget;

	private static readonly System.IntPtr NativeFieldInfoPtr__colorTarget;

	private static readonly System.IntPtr NativeFieldInfoPtr__vectorTarget;

	private static readonly System.IntPtr NativeFieldInfoPtr__textureTarget;

	private static readonly System.IntPtr NativeFieldInfoPtr__startTexture;

	private static readonly System.IntPtr NativeFieldInfoPtr_Duration;

	private static readonly System.IntPtr NativeFieldInfoPtr__elapsedTime;

	private static readonly System.IntPtr NativeFieldInfoPtr__startFloat;

	private static readonly System.IntPtr NativeFieldInfoPtr__startColor;

	private static readonly System.IntPtr NativeFieldInfoPtr__startVector;

	private static readonly System.IntPtr NativeFieldInfoPtr__onFinish;

	private static readonly System.IntPtr NativeMethodInfoPtr_SetAction_Public_Void_Action_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_InitializeProperty_Public_Void_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_Awake_Public_Void_MaterialPropertyBlock_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_CanActivate_Public_Boolean_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_ResetState_Public_Void_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_UpdateProperty_Public_Boolean_Single_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_ClUpdatePropertyAtMoment_Public_Void_MaterialPropertyBlock_Single_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_ClFinishProperty_Public_Void_MaterialPropertyBlock_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_UpdatePropertyAtMoment_Private_Void_MaterialPropertyBlock_Single_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_ResetProperty_Public_Void_MaterialPropertyBlock_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_CopyTo_Public_Void_LerpProperty_0;

	private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

	public unsafe string Name
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_Name);
			return IL2CPP.Il2CppStringToManaged(*(System.IntPtr*)num);
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_Name)), IL2CPP.ManagedStringToIl2Cpp(text));
		}
	}

	public unsafe bool IsActive
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_IsActive);
			return *(bool*)num;
		}
		set
		{
			*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_IsActive)) = flag;
		}
	}

	public unsafe int Finishes
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_Finishes);
			return *(int*)num;
		}
		set
		{
			*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_Finishes)) = num;
		}
	}

	public unsafe bool OnlyOnce
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_OnlyOnce);
			return *(bool*)num;
		}
		set
		{
			*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_OnlyOnce)) = flag;
		}
	}

	public unsafe bool NullBlockOnActivate
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_NullBlockOnActivate);
			return *(bool*)num;
		}
		set
		{
			*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_NullBlockOnActivate)) = flag;
		}
	}

	public unsafe bool AllowActivateWhileActive
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_AllowActivateWhileActive);
			return *(bool*)num;
		}
		set
		{
			*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_AllowActivateWhileActive)) = flag;
		}
	}

	public unsafe PropertyOnAwake OnAwake
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_OnAwake);
			return *(PropertyOnAwake*)num;
		}
		set
		{
			*(PropertyOnAwake*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_OnAwake)) = propertyOnAwake;
		}
	}

	public unsafe PropertyTypes _propertyType
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__propertyType);
			return *(PropertyTypes*)num;
		}
		set
		{
			*(PropertyTypes*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__propertyType)) = propertyTypes;
		}
	}

	public unsafe Mode _mode
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__mode);
			return *(Mode*)num;
		}
		set
		{
			*(Mode*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__mode)) = mode;
		}
	}

	public unsafe AnimationCurve _floatCurve
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__floatCurve);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<AnimationCurve>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__floatCurve)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)animationCurve));
		}
	}

	public unsafe Gradient _colorCurve
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__colorCurve);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Gradient>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__colorCurve)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)gradient));
		}
	}

	public unsafe AnimationCurve _vectorCurveX
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__vectorCurveX);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<AnimationCurve>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__vectorCurveX)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)animationCurve));
		}
	}

	public unsafe AnimationCurve _vectorCurveY
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__vectorCurveY);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<AnimationCurve>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__vectorCurveY)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)animationCurve));
		}
	}

	public unsafe AnimationCurve _vectorCurveZ
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__vectorCurveZ);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<AnimationCurve>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__vectorCurveZ)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)animationCurve));
		}
	}

	public unsafe AnimationCurve _vectorCurveW
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__vectorCurveW);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<AnimationCurve>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__vectorCurveW)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)animationCurve));
		}
	}

	public unsafe float _floatTarget
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__floatTarget);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__floatTarget)) = num;
		}
	}

	public unsafe Color _colorTarget
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__colorTarget);
			return *(Color*)num;
		}
		set
		{
			*(Color*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__colorTarget)) = color;
		}
	}

	public unsafe Vector4 _vectorTarget
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__vectorTarget);
			return *(Vector4*)num;
		}
		set
		{
			*(Vector4*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__vectorTarget)) = vector;
		}
	}

	public unsafe Texture2D _textureTarget
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__textureTarget);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Texture2D>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__textureTarget)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)texture2D));
		}
	}

	public unsafe Texture2D _startTexture
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__startTexture);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Texture2D>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__startTexture)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)texture2D));
		}
	}

	public unsafe float Duration
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_Duration);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_Duration)) = num;
		}
	}

	public unsafe float _elapsedTime
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__elapsedTime);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__elapsedTime)) = num;
		}
	}

	public unsafe float _startFloat
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__startFloat);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__startFloat)) = num;
		}
	}

	public unsafe Color _startColor
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__startColor);
			return *(Color*)num;
		}
		set
		{
			*(Color*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__startColor)) = color;
		}
	}

	public unsafe Vector4 _startVector
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__startVector);
			return *(Vector4*)num;
		}
		set
		{
			*(Vector4*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__startVector)) = vector;
		}
	}

	public unsafe Il2CppSystem.Action _onFinish
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__onFinish);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppSystem.Action>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__onFinish)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)action));
		}
	}

	static LerpProperty()
	{
		Il2CppClassPointerStore<LerpProperty>.NativeClassPtr = IL2CPP.GetIl2CppClass("Assembly-CSharp.dll", "BAPBAP.Entities", "LerpProperty");
		IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<LerpProperty>.NativeClassPtr);
		NativeFieldInfoPtr_Name = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LerpProperty>.NativeClassPtr, "Name");
		NativeFieldInfoPtr_IsActive = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LerpProperty>.NativeClassPtr, "IsActive");
		NativeFieldInfoPtr_Finishes = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LerpProperty>.NativeClassPtr, "Finishes");
		NativeFieldInfoPtr_OnlyOnce = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LerpProperty>.NativeClassPtr, "OnlyOnce");
		NativeFieldInfoPtr_NullBlockOnActivate = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LerpProperty>.NativeClassPtr, "NullBlockOnActivate");
		NativeFieldInfoPtr_AllowActivateWhileActive = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LerpProperty>.NativeClassPtr, "AllowActivateWhileActive");
		NativeFieldInfoPtr_OnAwake = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LerpProperty>.NativeClassPtr, "OnAwake");
		NativeFieldInfoPtr__propertyType = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LerpProperty>.NativeClassPtr, "_propertyType");
		NativeFieldInfoPtr__mode = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LerpProperty>.NativeClassPtr, "_mode");
		NativeFieldInfoPtr__floatCurve = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LerpProperty>.NativeClassPtr, "_floatCurve");
		NativeFieldInfoPtr__colorCurve = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LerpProperty>.NativeClassPtr, "_colorCurve");
		NativeFieldInfoPtr__vectorCurveX = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LerpProperty>.NativeClassPtr, "_vectorCurveX");
		NativeFieldInfoPtr__vectorCurveY = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LerpProperty>.NativeClassPtr, "_vectorCurveY");
		NativeFieldInfoPtr__vectorCurveZ = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LerpProperty>.NativeClassPtr, "_vectorCurveZ");
		NativeFieldInfoPtr__vectorCurveW = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LerpProperty>.NativeClassPtr, "_vectorCurveW");
		NativeFieldInfoPtr__floatTarget = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LerpProperty>.NativeClassPtr, "_floatTarget");
		NativeFieldInfoPtr__colorTarget = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LerpProperty>.NativeClassPtr, "_colorTarget");
		NativeFieldInfoPtr__vectorTarget = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LerpProperty>.NativeClassPtr, "_vectorTarget");
		NativeFieldInfoPtr__textureTarget = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LerpProperty>.NativeClassPtr, "_textureTarget");
		NativeFieldInfoPtr__startTexture = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LerpProperty>.NativeClassPtr, "_startTexture");
		NativeFieldInfoPtr_Duration = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LerpProperty>.NativeClassPtr, "Duration");
		NativeFieldInfoPtr__elapsedTime = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LerpProperty>.NativeClassPtr, "_elapsedTime");
		NativeFieldInfoPtr__startFloat = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LerpProperty>.NativeClassPtr, "_startFloat");
		NativeFieldInfoPtr__startColor = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LerpProperty>.NativeClassPtr, "_startColor");
		NativeFieldInfoPtr__startVector = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LerpProperty>.NativeClassPtr, "_startVector");
		NativeFieldInfoPtr__onFinish = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LerpProperty>.NativeClassPtr, "_onFinish");
		NativeMethodInfoPtr_SetAction_Public_Void_Action_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<LerpProperty>.NativeClassPtr, 100681756);
		NativeMethodInfoPtr_InitializeProperty_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<LerpProperty>.NativeClassPtr, 100681757);
		NativeMethodInfoPtr_Awake_Public_Void_MaterialPropertyBlock_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<LerpProperty>.NativeClassPtr, 100681758);
		NativeMethodInfoPtr_CanActivate_Public_Boolean_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<LerpProperty>.NativeClassPtr, 100681759);
		NativeMethodInfoPtr_ResetState_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<LerpProperty>.NativeClassPtr, 100681760);
		NativeMethodInfoPtr_UpdateProperty_Public_Boolean_Single_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<LerpProperty>.NativeClassPtr, 100681761);
		NativeMethodInfoPtr_ClUpdatePropertyAtMoment_Public_Void_MaterialPropertyBlock_Single_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<LerpProperty>.NativeClassPtr, 100681762);
		NativeMethodInfoPtr_ClFinishProperty_Public_Void_MaterialPropertyBlock_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<LerpProperty>.NativeClassPtr, 100681763);
		NativeMethodInfoPtr_UpdatePropertyAtMoment_Private_Void_MaterialPropertyBlock_Single_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<LerpProperty>.NativeClassPtr, 100681764);
		NativeMethodInfoPtr_ResetProperty_Public_Void_MaterialPropertyBlock_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<LerpProperty>.NativeClassPtr, 100681765);
		NativeMethodInfoPtr_CopyTo_Public_Void_LerpProperty_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<LerpProperty>.NativeClassPtr, 100681766);
		NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<LerpProperty>.NativeClassPtr, 100681767);
	}

	[CallerCount(0)]
	public unsafe void SetAction(Il2CppSystem.Action action)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)action);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_SetAction_Public_Void_Action_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(2)]
	[CachedScanResults(RefRangeStart = 206826, RefRangeEnd = 206828, XrefRangeStart = 206826, XrefRangeEnd = 206826, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void InitializeProperty()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_InitializeProperty_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(2)]
	[CachedScanResults(RefRangeStart = 206834, RefRangeEnd = 206836, XrefRangeStart = 206828, XrefRangeEnd = 206834, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void Awake(MaterialPropertyBlock block)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)block);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_Awake_Public_Void_MaterialPropertyBlock_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(2)]
	[CachedScanResults(RefRangeStart = 206836, RefRangeEnd = 206838, XrefRangeStart = 206836, XrefRangeEnd = 206836, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe bool CanActivate()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_CanActivate_Public_Boolean_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(bool*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	[CallerCount(0)]
	public unsafe void ResetState()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_ResetState_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(2)]
	[CachedScanResults(RefRangeStart = 206838, RefRangeEnd = 206840, XrefRangeStart = 206838, XrefRangeEnd = 206838, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe bool UpdateProperty(float elapsedTime)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = (nint)(&elapsedTime);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_UpdateProperty_Public_Boolean_Single_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(bool*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	[CallerCount(4)]
	[CachedScanResults(RefRangeStart = 206841, RefRangeEnd = 206845, XrefRangeStart = 206840, XrefRangeEnd = 206841, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void ClUpdatePropertyAtMoment(MaterialPropertyBlock block, float moment)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[2];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)block);
		*(float**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = &moment;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_ClUpdatePropertyAtMoment_Public_Void_MaterialPropertyBlock_Single_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 206846, RefRangeEnd = 206847, XrefRangeStart = 206845, XrefRangeEnd = 206846, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void ClFinishProperty(MaterialPropertyBlock block)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)block);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_ClFinishProperty_Public_Void_MaterialPropertyBlock_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(3)]
	[CachedScanResults(RefRangeStart = 206851, RefRangeEnd = 206854, XrefRangeStart = 206847, XrefRangeEnd = 206851, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void UpdatePropertyAtMoment(MaterialPropertyBlock block, float moment)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[2];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)block);
		*(float**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = &moment;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_UpdatePropertyAtMoment_Private_Void_MaterialPropertyBlock_Single_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 206854, XrefRangeEnd = 206855, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void ResetProperty(MaterialPropertyBlock block)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)block);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_ResetProperty_Public_Void_MaterialPropertyBlock_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 206855, RefRangeEnd = 206856, XrefRangeStart = 206855, XrefRangeEnd = 206855, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void CopyTo(LerpProperty target)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)target);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_CopyTo_Public_Void_LerpProperty_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 206871, RefRangeEnd = 206872, XrefRangeStart = 206856, XrefRangeEnd = 206871, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe LerpProperty()
		: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<LerpProperty>.NativeClassPtr))
	{
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	public LerpProperty(System.IntPtr pointer)
		: base(pointer)
	{
	}
}
