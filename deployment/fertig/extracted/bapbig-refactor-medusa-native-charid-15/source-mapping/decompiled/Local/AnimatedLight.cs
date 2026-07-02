using System;
using System.Runtime.CompilerServices;
using Il2CppInterop.Common.Attributes;
using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.InteropTypes;
using Il2CppInterop.Runtime.Runtime;
using Il2CppSystem;
using UnityEngine;

namespace Il2CppBAPBAP.Local;

public class AnimatedLight : MonoBehaviour
{
	public class LightBaseInfo : Il2CppSystem.Object
	{
		private static readonly System.IntPtr NativeFieldInfoPtr_Intensity;

		private static readonly System.IntPtr NativeFieldInfoPtr_LocalPosition;

		private static readonly System.IntPtr NativeFieldInfoPtr_LocalRotation;

		private static readonly System.IntPtr NativeFieldInfoPtr_Color;

		private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

		public unsafe float Intensity
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_Intensity);
				return *(float*)num;
			}
			set
			{
				*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_Intensity)) = num;
			}
		}

		public unsafe Vector3 LocalPosition
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_LocalPosition);
				return *(Vector3*)num;
			}
			set
			{
				*(Vector3*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_LocalPosition)) = vector;
			}
		}

		public unsafe Quaternion LocalRotation
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_LocalRotation);
				return *(Quaternion*)num;
			}
			set
			{
				*(Quaternion*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_LocalRotation)) = quaternion;
			}
		}

		public unsafe Color Color
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_Color);
				return *(Color*)num;
			}
			set
			{
				*(Color*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_Color)) = color;
			}
		}

		static LightBaseInfo()
		{
			Il2CppClassPointerStore<LightBaseInfo>.NativeClassPtr = IL2CPP.GetIl2CppNestedType(Il2CppClassPointerStore<AnimatedLight>.NativeClassPtr, "LightBaseInfo");
			IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<LightBaseInfo>.NativeClassPtr);
			NativeFieldInfoPtr_Intensity = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LightBaseInfo>.NativeClassPtr, "Intensity");
			NativeFieldInfoPtr_LocalPosition = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LightBaseInfo>.NativeClassPtr, "LocalPosition");
			NativeFieldInfoPtr_LocalRotation = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LightBaseInfo>.NativeClassPtr, "LocalRotation");
			NativeFieldInfoPtr_Color = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LightBaseInfo>.NativeClassPtr, "Color");
			NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<LightBaseInfo>.NativeClassPtr, 100683569);
		}

		[CallerCount(5410)]
		[CachedScanResults(RefRangeStart = 11, RefRangeEnd = 5421, XrefRangeStart = 11, XrefRangeEnd = 5421, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe LightBaseInfo()
			: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<LightBaseInfo>.NativeClassPtr))
		{
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		public LightBaseInfo(System.IntPtr pointer)
			: base(pointer)
		{
		}
	}

	private static readonly System.IntPtr NativeFieldInfoPtr__light;

	private static readonly System.IntPtr NativeFieldInfoPtr__flicker;

	private static readonly System.IntPtr NativeFieldInfoPtr__flickerIntensity;

	private static readonly System.IntPtr NativeFieldInfoPtr__flickerMinTime;

	private static readonly System.IntPtr NativeFieldInfoPtr__flickerMaxTime;

	private static readonly System.IntPtr NativeFieldInfoPtr__flickerDuration;

	private static readonly System.IntPtr NativeFieldInfoPtr__animateColor;

	private static readonly System.IntPtr NativeFieldInfoPtr__randomSampleGradient;

	private static readonly System.IntPtr NativeFieldInfoPtr__colorGradient;

	private static readonly System.IntPtr NativeFieldInfoPtr__colorMinTime;

	private static readonly System.IntPtr NativeFieldInfoPtr__colorMaxTime;

	private static readonly System.IntPtr NativeFieldInfoPtr__colorPingPongTime;

	private static readonly System.IntPtr NativeFieldInfoPtr__lightBaseInfo;

	private static readonly System.IntPtr NativeFieldInfoPtr__isFlickering;

	private static readonly System.IntPtr NativeFieldInfoPtr__lastFlickerTime;

	private static readonly System.IntPtr NativeFieldInfoPtr__nextFlickerTime;

	private static readonly System.IntPtr NativeFieldInfoPtr__flickerTime;

	private static readonly System.IntPtr NativeFieldInfoPtr__isAnimatingColor;

	private static readonly System.IntPtr NativeFieldInfoPtr__lastColorTime;

	private static readonly System.IntPtr NativeFieldInfoPtr__nextColorTime;

	private static readonly System.IntPtr NativeFieldInfoPtr__colorTime;

	private static readonly System.IntPtr NativeFieldInfoPtr__targetIntensity;

	private static readonly System.IntPtr NativeFieldInfoPtr__targetColor;

	private static readonly System.IntPtr NativeFieldInfoPtr__isDimmed;

	private static readonly System.IntPtr NativeFieldInfoPtr__dimTime;

	private static readonly System.IntPtr NativeFieldInfoPtr__undimTime;

	private static readonly System.IntPtr NativeFieldInfoPtr__dimDuration;

	private static readonly System.IntPtr NativeFieldInfoPtr__intensityMultiplier;

	private static readonly System.IntPtr NativeFieldInfoPtr__colorMultiplier;

	private static readonly System.IntPtr NativeMethodInfoPtr_OnEnable_Private_Void_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_Update_Private_Void_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_Dim_Public_Void_Single_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_Undim_Public_Void_Single_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_OnDisable_Private_Void_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_Restore_Public_Void_0;

	private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

	public unsafe Light _light
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__light);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Light>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__light)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)light));
		}
	}

	public unsafe bool _flicker
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__flicker);
			return *(bool*)num;
		}
		set
		{
			*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__flicker)) = flag;
		}
	}

	public unsafe float _flickerIntensity
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__flickerIntensity);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__flickerIntensity)) = num;
		}
	}

	public unsafe float _flickerMinTime
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__flickerMinTime);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__flickerMinTime)) = num;
		}
	}

	public unsafe float _flickerMaxTime
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__flickerMaxTime);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__flickerMaxTime)) = num;
		}
	}

	public unsafe float _flickerDuration
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__flickerDuration);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__flickerDuration)) = num;
		}
	}

	public unsafe bool _animateColor
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__animateColor);
			return *(bool*)num;
		}
		set
		{
			*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__animateColor)) = flag;
		}
	}

	public unsafe bool _randomSampleGradient
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__randomSampleGradient);
			return *(bool*)num;
		}
		set
		{
			*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__randomSampleGradient)) = flag;
		}
	}

	public unsafe Gradient _colorGradient
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__colorGradient);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Gradient>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__colorGradient)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)gradient));
		}
	}

	public unsafe float _colorMinTime
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__colorMinTime);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__colorMinTime)) = num;
		}
	}

	public unsafe float _colorMaxTime
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__colorMaxTime);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__colorMaxTime)) = num;
		}
	}

	public unsafe float _colorPingPongTime
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__colorPingPongTime);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__colorPingPongTime)) = num;
		}
	}

	public unsafe LightBaseInfo _lightBaseInfo
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__lightBaseInfo);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<LightBaseInfo>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__lightBaseInfo)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)lightBaseInfo));
		}
	}

	public unsafe bool _isFlickering
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__isFlickering);
			return *(bool*)num;
		}
		set
		{
			*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__isFlickering)) = flag;
		}
	}

	public unsafe float _lastFlickerTime
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__lastFlickerTime);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__lastFlickerTime)) = num;
		}
	}

	public unsafe float _nextFlickerTime
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__nextFlickerTime);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__nextFlickerTime)) = num;
		}
	}

	public unsafe float _flickerTime
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__flickerTime);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__flickerTime)) = num;
		}
	}

	public unsafe bool _isAnimatingColor
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__isAnimatingColor);
			return *(bool*)num;
		}
		set
		{
			*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__isAnimatingColor)) = flag;
		}
	}

	public unsafe float _lastColorTime
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__lastColorTime);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__lastColorTime)) = num;
		}
	}

	public unsafe float _nextColorTime
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__nextColorTime);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__nextColorTime)) = num;
		}
	}

	public unsafe float _colorTime
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__colorTime);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__colorTime)) = num;
		}
	}

	public unsafe float _targetIntensity
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__targetIntensity);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__targetIntensity)) = num;
		}
	}

	public unsafe Color _targetColor
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__targetColor);
			return *(Color*)num;
		}
		set
		{
			*(Color*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__targetColor)) = color;
		}
	}

	public unsafe bool _isDimmed
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__isDimmed);
			return *(bool*)num;
		}
		set
		{
			*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__isDimmed)) = flag;
		}
	}

	public unsafe float _dimTime
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__dimTime);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__dimTime)) = num;
		}
	}

	public unsafe float _undimTime
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__undimTime);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__undimTime)) = num;
		}
	}

	public unsafe float _dimDuration
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__dimDuration);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__dimDuration)) = num;
		}
	}

	public unsafe float _intensityMultiplier
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__intensityMultiplier);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__intensityMultiplier)) = num;
		}
	}

	public unsafe float _colorMultiplier
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__colorMultiplier);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__colorMultiplier)) = num;
		}
	}

	static AnimatedLight()
	{
		Il2CppClassPointerStore<AnimatedLight>.NativeClassPtr = IL2CPP.GetIl2CppClass("Assembly-CSharp.dll", "BAPBAP.Local", "AnimatedLight");
		IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<AnimatedLight>.NativeClassPtr);
		NativeFieldInfoPtr__light = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<AnimatedLight>.NativeClassPtr, "_light");
		NativeFieldInfoPtr__flicker = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<AnimatedLight>.NativeClassPtr, "_flicker");
		NativeFieldInfoPtr__flickerIntensity = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<AnimatedLight>.NativeClassPtr, "_flickerIntensity");
		NativeFieldInfoPtr__flickerMinTime = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<AnimatedLight>.NativeClassPtr, "_flickerMinTime");
		NativeFieldInfoPtr__flickerMaxTime = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<AnimatedLight>.NativeClassPtr, "_flickerMaxTime");
		NativeFieldInfoPtr__flickerDuration = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<AnimatedLight>.NativeClassPtr, "_flickerDuration");
		NativeFieldInfoPtr__animateColor = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<AnimatedLight>.NativeClassPtr, "_animateColor");
		NativeFieldInfoPtr__randomSampleGradient = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<AnimatedLight>.NativeClassPtr, "_randomSampleGradient");
		NativeFieldInfoPtr__colorGradient = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<AnimatedLight>.NativeClassPtr, "_colorGradient");
		NativeFieldInfoPtr__colorMinTime = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<AnimatedLight>.NativeClassPtr, "_colorMinTime");
		NativeFieldInfoPtr__colorMaxTime = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<AnimatedLight>.NativeClassPtr, "_colorMaxTime");
		NativeFieldInfoPtr__colorPingPongTime = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<AnimatedLight>.NativeClassPtr, "_colorPingPongTime");
		NativeFieldInfoPtr__lightBaseInfo = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<AnimatedLight>.NativeClassPtr, "_lightBaseInfo");
		NativeFieldInfoPtr__isFlickering = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<AnimatedLight>.NativeClassPtr, "_isFlickering");
		NativeFieldInfoPtr__lastFlickerTime = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<AnimatedLight>.NativeClassPtr, "_lastFlickerTime");
		NativeFieldInfoPtr__nextFlickerTime = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<AnimatedLight>.NativeClassPtr, "_nextFlickerTime");
		NativeFieldInfoPtr__flickerTime = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<AnimatedLight>.NativeClassPtr, "_flickerTime");
		NativeFieldInfoPtr__isAnimatingColor = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<AnimatedLight>.NativeClassPtr, "_isAnimatingColor");
		NativeFieldInfoPtr__lastColorTime = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<AnimatedLight>.NativeClassPtr, "_lastColorTime");
		NativeFieldInfoPtr__nextColorTime = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<AnimatedLight>.NativeClassPtr, "_nextColorTime");
		NativeFieldInfoPtr__colorTime = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<AnimatedLight>.NativeClassPtr, "_colorTime");
		NativeFieldInfoPtr__targetIntensity = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<AnimatedLight>.NativeClassPtr, "_targetIntensity");
		NativeFieldInfoPtr__targetColor = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<AnimatedLight>.NativeClassPtr, "_targetColor");
		NativeFieldInfoPtr__isDimmed = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<AnimatedLight>.NativeClassPtr, "_isDimmed");
		NativeFieldInfoPtr__dimTime = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<AnimatedLight>.NativeClassPtr, "_dimTime");
		NativeFieldInfoPtr__undimTime = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<AnimatedLight>.NativeClassPtr, "_undimTime");
		NativeFieldInfoPtr__dimDuration = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<AnimatedLight>.NativeClassPtr, "_dimDuration");
		NativeFieldInfoPtr__intensityMultiplier = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<AnimatedLight>.NativeClassPtr, "_intensityMultiplier");
		NativeFieldInfoPtr__colorMultiplier = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<AnimatedLight>.NativeClassPtr, "_colorMultiplier");
		NativeMethodInfoPtr_OnEnable_Private_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<AnimatedLight>.NativeClassPtr, 100683562);
		NativeMethodInfoPtr_Update_Private_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<AnimatedLight>.NativeClassPtr, 100683563);
		NativeMethodInfoPtr_Dim_Public_Void_Single_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<AnimatedLight>.NativeClassPtr, 100683564);
		NativeMethodInfoPtr_Undim_Public_Void_Single_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<AnimatedLight>.NativeClassPtr, 100683565);
		NativeMethodInfoPtr_OnDisable_Private_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<AnimatedLight>.NativeClassPtr, 100683566);
		NativeMethodInfoPtr_Restore_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<AnimatedLight>.NativeClassPtr, 100683567);
		NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<AnimatedLight>.NativeClassPtr, 100683568);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 221381, XrefRangeEnd = 221390, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void OnEnable()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_OnEnable_Private_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 221390, XrefRangeEnd = 221430, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void Update()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_Update_Private_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	public unsafe void Dim(float duration)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = (nint)(&duration);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_Dim_Public_Void_Single_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	public unsafe void Undim(float duration)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = (nint)(&duration);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_Undim_Public_Void_Single_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 221430, XrefRangeEnd = 221436, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void OnDisable()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_OnDisable_Private_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 0, XrefRangeEnd = 0, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void Restore()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_Restore_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 221436, XrefRangeEnd = 221437, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe AnimatedLight()
		: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<AnimatedLight>.NativeClassPtr))
	{
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	public AnimatedLight(System.IntPtr pointer)
		: base(pointer)
	{
	}
}
