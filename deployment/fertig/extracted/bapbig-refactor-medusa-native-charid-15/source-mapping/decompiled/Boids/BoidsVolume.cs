using System;
using System.Runtime.CompilerServices;
using Il2CppInterop.Common.Attributes;
using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.InteropTypes;
using Il2CppInterop.Runtime.InteropTypes.Arrays;
using Il2CppInterop.Runtime.Runtime;
using Il2CppSystem;
using Unity.Collections;
using UnityEngine;

namespace Il2CppBAPBAP.Boids;

public class BoidsVolume : MonoBehaviour
{
	public sealed class BoidsJob : Il2CppSystem.ValueType
	{
		private static readonly System.IntPtr NativeFieldInfoPtr_Positions;

		private static readonly System.IntPtr NativeFieldInfoPtr_Velocities;

		private static readonly System.IntPtr NativeFieldInfoPtr_ReadOnlyPositions;

		private static readonly System.IntPtr NativeFieldInfoPtr_ReadOnlyVelocities;

		private static readonly System.IntPtr NativeFieldInfoPtr_BoundsBuffer;

		private static readonly System.IntPtr NativeFieldInfoPtr_ColliderCount;

		private static readonly System.IntPtr NativeFieldInfoPtr_DeltaTime;

		private static readonly System.IntPtr NativeFieldInfoPtr_Centre;

		private static readonly System.IntPtr NativeFieldInfoPtr_Target;

		private static readonly System.IntPtr NativeFieldInfoPtr_Radius;

		private static readonly System.IntPtr NativeFieldInfoPtr_MaxSpeed;

		private static readonly System.IntPtr NativeFieldInfoPtr_Acceleration;

		private static readonly System.IntPtr NativeFieldInfoPtr_SeparationRadius;

		private static readonly System.IntPtr NativeFieldInfoPtr_SeparationWeight;

		private static readonly System.IntPtr NativeFieldInfoPtr_CohesionRadius;

		private static readonly System.IntPtr NativeFieldInfoPtr_CohesionWeight;

		private static readonly System.IntPtr NativeFieldInfoPtr_AlignmentRadius;

		private static readonly System.IntPtr NativeFieldInfoPtr_AlignmentWeight;

		private static readonly System.IntPtr NativeFieldInfoPtr_RepulsionRadius;

		private static readonly System.IntPtr NativeFieldInfoPtr_RepulsionWeight;

		private static readonly System.IntPtr NativeFieldInfoPtr_TargetWeight;

		private static readonly System.IntPtr NativeFieldInfoPtr_HorizontalWeight;

		private static readonly System.IntPtr NativeFieldInfoPtr_RadiusWeight;

		private static readonly System.IntPtr NativeFieldInfoPtr_ReluctanceWeight;

		private static readonly System.IntPtr NativeFieldInfoPtr_CollisionRadius;

		private static readonly System.IntPtr NativeFieldInfoPtr_CollisionWeight;

		private static readonly System.IntPtr NativeMethodInfoPtr_Execute_Public_Virtual_Final_New_Void_Int32_0;

		public unsafe NativeArray<Vector3> Positions
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_Positions);
				return new NativeArray<Vector3>(IL2CPP.il2cpp_value_box(Il2CppClassPointerStore<NativeArray<Vector3>>.NativeClassPtr, (System.IntPtr)num));
			}
			set
			{
				// IL cpblk instruction
				Unsafe.CopyBlock((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_Positions), IL2CPP.il2cpp_object_unbox(IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)nativeArray)), IL2CPP.il2cpp_class_value_size(Il2CppClassPointerStore<NativeArray<Vector3>>.NativeClassPtr, ref *(uint*)null));
			}
		}

		public unsafe NativeArray<Vector3> Velocities
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_Velocities);
				return new NativeArray<Vector3>(IL2CPP.il2cpp_value_box(Il2CppClassPointerStore<NativeArray<Vector3>>.NativeClassPtr, (System.IntPtr)num));
			}
			set
			{
				// IL cpblk instruction
				Unsafe.CopyBlock((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_Velocities), IL2CPP.il2cpp_object_unbox(IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)nativeArray)), IL2CPP.il2cpp_class_value_size(Il2CppClassPointerStore<NativeArray<Vector3>>.NativeClassPtr, ref *(uint*)null));
			}
		}

		public unsafe NativeArray<Vector3>.ReadOnly ReadOnlyPositions
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_ReadOnlyPositions);
				return new NativeArray<Vector3>.ReadOnly(IL2CPP.il2cpp_value_box(Il2CppClassPointerStore<NativeArray<Vector3>.ReadOnly>.NativeClassPtr, (System.IntPtr)num));
			}
			set
			{
				// IL cpblk instruction
				Unsafe.CopyBlock((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_ReadOnlyPositions), IL2CPP.il2cpp_object_unbox(IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)readOnly)), IL2CPP.il2cpp_class_value_size(Il2CppClassPointerStore<NativeArray<Vector3>.ReadOnly>.NativeClassPtr, ref *(uint*)null));
			}
		}

		public unsafe NativeArray<Vector3>.ReadOnly ReadOnlyVelocities
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_ReadOnlyVelocities);
				return new NativeArray<Vector3>.ReadOnly(IL2CPP.il2cpp_value_box(Il2CppClassPointerStore<NativeArray<Vector3>.ReadOnly>.NativeClassPtr, (System.IntPtr)num));
			}
			set
			{
				// IL cpblk instruction
				Unsafe.CopyBlock((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_ReadOnlyVelocities), IL2CPP.il2cpp_object_unbox(IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)readOnly)), IL2CPP.il2cpp_class_value_size(Il2CppClassPointerStore<NativeArray<Vector3>.ReadOnly>.NativeClassPtr, ref *(uint*)null));
			}
		}

		public unsafe NativeArray<Bounds>.ReadOnly BoundsBuffer
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_BoundsBuffer);
				return new NativeArray<Bounds>.ReadOnly(IL2CPP.il2cpp_value_box(Il2CppClassPointerStore<NativeArray<Bounds>.ReadOnly>.NativeClassPtr, (System.IntPtr)num));
			}
			set
			{
				// IL cpblk instruction
				Unsafe.CopyBlock((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_BoundsBuffer), IL2CPP.il2cpp_object_unbox(IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)readOnly)), IL2CPP.il2cpp_class_value_size(Il2CppClassPointerStore<NativeArray<Bounds>.ReadOnly>.NativeClassPtr, ref *(uint*)null));
			}
		}

		public unsafe int ColliderCount
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_ColliderCount);
				return *(int*)num;
			}
			set
			{
				*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_ColliderCount)) = num;
			}
		}

		public unsafe float DeltaTime
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_DeltaTime);
				return *(float*)num;
			}
			set
			{
				*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_DeltaTime)) = num;
			}
		}

		public unsafe Vector3 Centre
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_Centre);
				return *(Vector3*)num;
			}
			set
			{
				*(Vector3*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_Centre)) = vector;
			}
		}

		public unsafe Vector3 Target
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_Target);
				return *(Vector3*)num;
			}
			set
			{
				*(Vector3*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_Target)) = vector;
			}
		}

		public unsafe float Radius
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_Radius);
				return *(float*)num;
			}
			set
			{
				*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_Radius)) = num;
			}
		}

		public unsafe float MaxSpeed
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_MaxSpeed);
				return *(float*)num;
			}
			set
			{
				*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_MaxSpeed)) = num;
			}
		}

		public unsafe float Acceleration
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_Acceleration);
				return *(float*)num;
			}
			set
			{
				*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_Acceleration)) = num;
			}
		}

		public unsafe float SeparationRadius
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_SeparationRadius);
				return *(float*)num;
			}
			set
			{
				*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_SeparationRadius)) = num;
			}
		}

		public unsafe float SeparationWeight
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_SeparationWeight);
				return *(float*)num;
			}
			set
			{
				*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_SeparationWeight)) = num;
			}
		}

		public unsafe float CohesionRadius
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_CohesionRadius);
				return *(float*)num;
			}
			set
			{
				*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_CohesionRadius)) = num;
			}
		}

		public unsafe float CohesionWeight
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_CohesionWeight);
				return *(float*)num;
			}
			set
			{
				*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_CohesionWeight)) = num;
			}
		}

		public unsafe float AlignmentRadius
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_AlignmentRadius);
				return *(float*)num;
			}
			set
			{
				*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_AlignmentRadius)) = num;
			}
		}

		public unsafe float AlignmentWeight
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_AlignmentWeight);
				return *(float*)num;
			}
			set
			{
				*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_AlignmentWeight)) = num;
			}
		}

		public unsafe float RepulsionRadius
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_RepulsionRadius);
				return *(float*)num;
			}
			set
			{
				*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_RepulsionRadius)) = num;
			}
		}

		public unsafe float RepulsionWeight
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_RepulsionWeight);
				return *(float*)num;
			}
			set
			{
				*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_RepulsionWeight)) = num;
			}
		}

		public unsafe float TargetWeight
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_TargetWeight);
				return *(float*)num;
			}
			set
			{
				*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_TargetWeight)) = num;
			}
		}

		public unsafe float HorizontalWeight
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_HorizontalWeight);
				return *(float*)num;
			}
			set
			{
				*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_HorizontalWeight)) = num;
			}
		}

		public unsafe float RadiusWeight
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_RadiusWeight);
				return *(float*)num;
			}
			set
			{
				*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_RadiusWeight)) = num;
			}
		}

		public unsafe float ReluctanceWeight
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_ReluctanceWeight);
				return *(float*)num;
			}
			set
			{
				*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_ReluctanceWeight)) = num;
			}
		}

		public unsafe float CollisionRadius
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_CollisionRadius);
				return *(float*)num;
			}
			set
			{
				*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_CollisionRadius)) = num;
			}
		}

		public unsafe float CollisionWeight
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_CollisionWeight);
				return *(float*)num;
			}
			set
			{
				*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_CollisionWeight)) = num;
			}
		}

		static BoidsJob()
		{
			Il2CppClassPointerStore<BoidsJob>.NativeClassPtr = IL2CPP.GetIl2CppNestedType(Il2CppClassPointerStore<BoidsVolume>.NativeClassPtr, "BoidsJob");
			IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<BoidsJob>.NativeClassPtr);
			NativeFieldInfoPtr_Positions = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<BoidsJob>.NativeClassPtr, "Positions");
			NativeFieldInfoPtr_Velocities = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<BoidsJob>.NativeClassPtr, "Velocities");
			NativeFieldInfoPtr_ReadOnlyPositions = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<BoidsJob>.NativeClassPtr, "ReadOnlyPositions");
			NativeFieldInfoPtr_ReadOnlyVelocities = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<BoidsJob>.NativeClassPtr, "ReadOnlyVelocities");
			NativeFieldInfoPtr_BoundsBuffer = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<BoidsJob>.NativeClassPtr, "BoundsBuffer");
			NativeFieldInfoPtr_ColliderCount = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<BoidsJob>.NativeClassPtr, "ColliderCount");
			NativeFieldInfoPtr_DeltaTime = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<BoidsJob>.NativeClassPtr, "DeltaTime");
			NativeFieldInfoPtr_Centre = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<BoidsJob>.NativeClassPtr, "Centre");
			NativeFieldInfoPtr_Target = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<BoidsJob>.NativeClassPtr, "Target");
			NativeFieldInfoPtr_Radius = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<BoidsJob>.NativeClassPtr, "Radius");
			NativeFieldInfoPtr_MaxSpeed = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<BoidsJob>.NativeClassPtr, "MaxSpeed");
			NativeFieldInfoPtr_Acceleration = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<BoidsJob>.NativeClassPtr, "Acceleration");
			NativeFieldInfoPtr_SeparationRadius = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<BoidsJob>.NativeClassPtr, "SeparationRadius");
			NativeFieldInfoPtr_SeparationWeight = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<BoidsJob>.NativeClassPtr, "SeparationWeight");
			NativeFieldInfoPtr_CohesionRadius = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<BoidsJob>.NativeClassPtr, "CohesionRadius");
			NativeFieldInfoPtr_CohesionWeight = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<BoidsJob>.NativeClassPtr, "CohesionWeight");
			NativeFieldInfoPtr_AlignmentRadius = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<BoidsJob>.NativeClassPtr, "AlignmentRadius");
			NativeFieldInfoPtr_AlignmentWeight = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<BoidsJob>.NativeClassPtr, "AlignmentWeight");
			NativeFieldInfoPtr_RepulsionRadius = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<BoidsJob>.NativeClassPtr, "RepulsionRadius");
			NativeFieldInfoPtr_RepulsionWeight = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<BoidsJob>.NativeClassPtr, "RepulsionWeight");
			NativeFieldInfoPtr_TargetWeight = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<BoidsJob>.NativeClassPtr, "TargetWeight");
			NativeFieldInfoPtr_HorizontalWeight = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<BoidsJob>.NativeClassPtr, "HorizontalWeight");
			NativeFieldInfoPtr_RadiusWeight = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<BoidsJob>.NativeClassPtr, "RadiusWeight");
			NativeFieldInfoPtr_ReluctanceWeight = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<BoidsJob>.NativeClassPtr, "ReluctanceWeight");
			NativeFieldInfoPtr_CollisionRadius = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<BoidsJob>.NativeClassPtr, "CollisionRadius");
			NativeFieldInfoPtr_CollisionWeight = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<BoidsJob>.NativeClassPtr, "CollisionWeight");
			NativeMethodInfoPtr_Execute_Public_Virtual_Final_New_Void_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<BoidsJob>.NativeClassPtr, 100671826);
		}

		[CallerCount(0)]
		[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 111999, XrefRangeEnd = 112052, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe virtual void Execute(int index)
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = stackalloc System.IntPtr[1];
			*ptr = (nint)(&index);
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_Execute_Public_Virtual_Final_New_Void_Int32_0, IL2CPP.il2cpp_object_unbox(IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this)), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		public BoidsJob(System.IntPtr pointer)
			: base(pointer)
		{
		}

		public BoidsJob()
			: base(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<BoidsJob>.NativeClassPtr))
		{
		}
	}

	public sealed class PreviousVelocityJob : Il2CppSystem.ValueType
	{
		private static readonly System.IntPtr NativeFieldInfoPtr_PreviousVelocities;

		private static readonly System.IntPtr NativeFieldInfoPtr_ReadOnlyPreviousVelocities;

		private static readonly System.IntPtr NativeFieldInfoPtr_ReadOnlyCurrentVelocities;

		private static readonly System.IntPtr NativeFieldInfoPtr_Delay;

		private static readonly System.IntPtr NativeMethodInfoPtr_Execute_Public_Virtual_Final_New_Void_Int32_0;

		public unsafe NativeArray<Vector3> PreviousVelocities
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_PreviousVelocities);
				return new NativeArray<Vector3>(IL2CPP.il2cpp_value_box(Il2CppClassPointerStore<NativeArray<Vector3>>.NativeClassPtr, (System.IntPtr)num));
			}
			set
			{
				// IL cpblk instruction
				Unsafe.CopyBlock((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_PreviousVelocities), IL2CPP.il2cpp_object_unbox(IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)nativeArray)), IL2CPP.il2cpp_class_value_size(Il2CppClassPointerStore<NativeArray<Vector3>>.NativeClassPtr, ref *(uint*)null));
			}
		}

		public unsafe NativeArray<Vector3>.ReadOnly ReadOnlyPreviousVelocities
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_ReadOnlyPreviousVelocities);
				return new NativeArray<Vector3>.ReadOnly(IL2CPP.il2cpp_value_box(Il2CppClassPointerStore<NativeArray<Vector3>.ReadOnly>.NativeClassPtr, (System.IntPtr)num));
			}
			set
			{
				// IL cpblk instruction
				Unsafe.CopyBlock((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_ReadOnlyPreviousVelocities), IL2CPP.il2cpp_object_unbox(IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)readOnly)), IL2CPP.il2cpp_class_value_size(Il2CppClassPointerStore<NativeArray<Vector3>.ReadOnly>.NativeClassPtr, ref *(uint*)null));
			}
		}

		public unsafe NativeArray<Vector3>.ReadOnly ReadOnlyCurrentVelocities
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_ReadOnlyCurrentVelocities);
				return new NativeArray<Vector3>.ReadOnly(IL2CPP.il2cpp_value_box(Il2CppClassPointerStore<NativeArray<Vector3>.ReadOnly>.NativeClassPtr, (System.IntPtr)num));
			}
			set
			{
				// IL cpblk instruction
				Unsafe.CopyBlock((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_ReadOnlyCurrentVelocities), IL2CPP.il2cpp_object_unbox(IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)readOnly)), IL2CPP.il2cpp_class_value_size(Il2CppClassPointerStore<NativeArray<Vector3>.ReadOnly>.NativeClassPtr, ref *(uint*)null));
			}
		}

		public unsafe float Delay
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_Delay);
				return *(float*)num;
			}
			set
			{
				*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_Delay)) = num;
			}
		}

		static PreviousVelocityJob()
		{
			Il2CppClassPointerStore<PreviousVelocityJob>.NativeClassPtr = IL2CPP.GetIl2CppNestedType(Il2CppClassPointerStore<BoidsVolume>.NativeClassPtr, "PreviousVelocityJob");
			IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<PreviousVelocityJob>.NativeClassPtr);
			NativeFieldInfoPtr_PreviousVelocities = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<PreviousVelocityJob>.NativeClassPtr, "PreviousVelocities");
			NativeFieldInfoPtr_ReadOnlyPreviousVelocities = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<PreviousVelocityJob>.NativeClassPtr, "ReadOnlyPreviousVelocities");
			NativeFieldInfoPtr_ReadOnlyCurrentVelocities = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<PreviousVelocityJob>.NativeClassPtr, "ReadOnlyCurrentVelocities");
			NativeFieldInfoPtr_Delay = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<PreviousVelocityJob>.NativeClassPtr, "Delay");
			NativeMethodInfoPtr_Execute_Public_Virtual_Final_New_Void_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<PreviousVelocityJob>.NativeClassPtr, 100671827);
		}

		[CallerCount(0)]
		[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 112052, XrefRangeEnd = 112056, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe virtual void Execute(int index)
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = stackalloc System.IntPtr[1];
			*ptr = (nint)(&index);
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_Execute_Public_Virtual_Final_New_Void_Int32_0, IL2CPP.il2cpp_object_unbox(IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this)), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		public PreviousVelocityJob(System.IntPtr pointer)
			: base(pointer)
		{
		}

		public PreviousVelocityJob()
			: base(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<PreviousVelocityJob>.NativeClassPtr))
		{
		}
	}

	private static readonly System.IntPtr NativeFieldInfoPtr__radius;

	private static readonly System.IntPtr NativeFieldInfoPtr__targetOffset;

	private static readonly System.IntPtr NativeFieldInfoPtr__spawnOffset;

	private static readonly System.IntPtr NativeFieldInfoPtr__count;

	private static readonly System.IntPtr NativeFieldInfoPtr__mesh;

	private static readonly System.IntPtr NativeFieldInfoPtr__material;

	private static readonly System.IntPtr NativeFieldInfoPtr__colorGradient;

	private static readonly System.IntPtr NativeFieldInfoPtr__minGrouping;

	private static readonly System.IntPtr NativeFieldInfoPtr__maxGrouping;

	private static readonly System.IntPtr NativeFieldInfoPtr__groupingRadius;

	private static readonly System.IntPtr NativeFieldInfoPtr__minScale;

	private static readonly System.IntPtr NativeFieldInfoPtr__maxScale;

	private static readonly System.IntPtr NativeFieldInfoPtr__spawnDuration;

	private static readonly System.IntPtr NativeFieldInfoPtr__spawnRate;

	private static readonly System.IntPtr NativeFieldInfoPtr__maxSpeed;

	private static readonly System.IntPtr NativeFieldInfoPtr__acceleration;

	private static readonly System.IntPtr NativeFieldInfoPtr__previousVelocityDelay;

	private static readonly System.IntPtr NativeFieldInfoPtr__separationRadius;

	private static readonly System.IntPtr NativeFieldInfoPtr__separationWeight;

	private static readonly System.IntPtr NativeFieldInfoPtr__cohesionRadius;

	private static readonly System.IntPtr NativeFieldInfoPtr__cohesionWeight;

	private static readonly System.IntPtr NativeFieldInfoPtr__alignmentRadius;

	private static readonly System.IntPtr NativeFieldInfoPtr__alignmentWeight;

	private static readonly System.IntPtr NativeFieldInfoPtr__repulsionRadius;

	private static readonly System.IntPtr NativeFieldInfoPtr__repulsionWeight;

	private static readonly System.IntPtr NativeFieldInfoPtr__targetWeight;

	private static readonly System.IntPtr NativeFieldInfoPtr__horizontalWeight;

	private static readonly System.IntPtr NativeFieldInfoPtr__radiusWeight;

	private static readonly System.IntPtr NativeFieldInfoPtr__reluctanceWeight;

	private static readonly System.IntPtr NativeFieldInfoPtr__collisionRadius;

	private static readonly System.IntPtr NativeFieldInfoPtr__collisionWeight;

	private static readonly System.IntPtr NativeFieldInfoPtr__colliderMask;

	private static readonly System.IntPtr NativeFieldInfoPtr__colliderBufferSize;

	private static readonly System.IntPtr NativeFieldInfoPtr__warnColliderBufferOverflow;

	private static readonly System.IntPtr NativeFieldInfoPtr__cachedCount;

	private static readonly System.IntPtr NativeFieldInfoPtr__positions;

	private static readonly System.IntPtr NativeFieldInfoPtr__velocities;

	private static readonly System.IntPtr NativeFieldInfoPtr__previousVelocities;

	private static readonly System.IntPtr NativeFieldInfoPtr__readOnlyPositions;

	private static readonly System.IntPtr NativeFieldInfoPtr__readOnlyVelocities;

	private static readonly System.IntPtr NativeFieldInfoPtr__readOnlyPreviousVelocities;

	private static readonly System.IntPtr NativeFieldInfoPtr__boundsBuffer;

	private static readonly System.IntPtr NativeFieldInfoPtr__matrices;

	private static readonly System.IntPtr NativeFieldInfoPtr__scales;

	private static readonly System.IntPtr NativeFieldInfoPtr__spawns;

	private static readonly System.IntPtr NativeFieldInfoPtr__propertyBlock;

	private static readonly System.IntPtr NativeFieldInfoPtr__colorPropertyBuffer;

	private static readonly System.IntPtr NativeFieldInfoPtr__velocityCurrentPropertyBuffer;

	private static readonly System.IntPtr NativeFieldInfoPtr__velocityPreviousPropertyBuffer;

	private static readonly System.IntPtr NativeFieldInfoPtr__instanceColorPropertyId;

	private static readonly System.IntPtr NativeFieldInfoPtr__instanceCountPropertyId;

	private static readonly System.IntPtr NativeFieldInfoPtr__velocityCurrentPropertyId;

	private static readonly System.IntPtr NativeFieldInfoPtr__velocityPreviousPropertyId;

	private static readonly System.IntPtr NativeFieldInfoPtr__colliderBuffer;

	private static readonly System.IntPtr NativeFieldInfoPtr__colliderCount;

	private static readonly System.IntPtr NativeMethodInfoPtr_SetCount_Public_Void_Int32_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_Awake_Private_Void_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_Update_Private_Void_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_OnDestroy_Private_Void_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_OnDrawGizmos_Private_Void_0;

	private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

	public unsafe float _radius
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__radius);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__radius)) = num;
		}
	}

	public unsafe Vector3 _targetOffset
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__targetOffset);
			return *(Vector3*)num;
		}
		set
		{
			*(Vector3*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__targetOffset)) = vector;
		}
	}

	public unsafe Vector3 _spawnOffset
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__spawnOffset);
			return *(Vector3*)num;
		}
		set
		{
			*(Vector3*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__spawnOffset)) = vector;
		}
	}

	public unsafe int _count
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__count);
			return *(int*)num;
		}
		set
		{
			*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__count)) = num;
		}
	}

	public unsafe Mesh _mesh
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__mesh);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Mesh>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__mesh)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)mesh));
		}
	}

	public unsafe Material _material
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__material);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Material>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__material)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)material));
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

	public unsafe int _minGrouping
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__minGrouping);
			return *(int*)num;
		}
		set
		{
			*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__minGrouping)) = num;
		}
	}

	public unsafe int _maxGrouping
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__maxGrouping);
			return *(int*)num;
		}
		set
		{
			*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__maxGrouping)) = num;
		}
	}

	public unsafe float _groupingRadius
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__groupingRadius);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__groupingRadius)) = num;
		}
	}

	public unsafe float _minScale
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__minScale);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__minScale)) = num;
		}
	}

	public unsafe float _maxScale
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__maxScale);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__maxScale)) = num;
		}
	}

	public unsafe float _spawnDuration
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__spawnDuration);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__spawnDuration)) = num;
		}
	}

	public unsafe int _spawnRate
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__spawnRate);
			return *(int*)num;
		}
		set
		{
			*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__spawnRate)) = num;
		}
	}

	public unsafe float _maxSpeed
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__maxSpeed);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__maxSpeed)) = num;
		}
	}

	public unsafe float _acceleration
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__acceleration);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__acceleration)) = num;
		}
	}

	public unsafe float _previousVelocityDelay
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__previousVelocityDelay);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__previousVelocityDelay)) = num;
		}
	}

	public unsafe float _separationRadius
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__separationRadius);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__separationRadius)) = num;
		}
	}

	public unsafe float _separationWeight
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__separationWeight);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__separationWeight)) = num;
		}
	}

	public unsafe float _cohesionRadius
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__cohesionRadius);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__cohesionRadius)) = num;
		}
	}

	public unsafe float _cohesionWeight
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__cohesionWeight);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__cohesionWeight)) = num;
		}
	}

	public unsafe float _alignmentRadius
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__alignmentRadius);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__alignmentRadius)) = num;
		}
	}

	public unsafe float _alignmentWeight
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__alignmentWeight);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__alignmentWeight)) = num;
		}
	}

	public unsafe float _repulsionRadius
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__repulsionRadius);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__repulsionRadius)) = num;
		}
	}

	public unsafe float _repulsionWeight
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__repulsionWeight);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__repulsionWeight)) = num;
		}
	}

	public unsafe float _targetWeight
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__targetWeight);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__targetWeight)) = num;
		}
	}

	public unsafe float _horizontalWeight
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__horizontalWeight);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__horizontalWeight)) = num;
		}
	}

	public unsafe float _radiusWeight
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__radiusWeight);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__radiusWeight)) = num;
		}
	}

	public unsafe float _reluctanceWeight
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__reluctanceWeight);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__reluctanceWeight)) = num;
		}
	}

	public unsafe float _collisionRadius
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__collisionRadius);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__collisionRadius)) = num;
		}
	}

	public unsafe float _collisionWeight
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__collisionWeight);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__collisionWeight)) = num;
		}
	}

	public unsafe LayerMask _colliderMask
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__colliderMask);
			return *(LayerMask*)num;
		}
		set
		{
			*(LayerMask*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__colliderMask)) = layerMask;
		}
	}

	public unsafe int _colliderBufferSize
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__colliderBufferSize);
			return *(int*)num;
		}
		set
		{
			*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__colliderBufferSize)) = num;
		}
	}

	public unsafe bool _warnColliderBufferOverflow
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__warnColliderBufferOverflow);
			return *(bool*)num;
		}
		set
		{
			*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__warnColliderBufferOverflow)) = flag;
		}
	}

	public unsafe int _cachedCount
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__cachedCount);
			return *(int*)num;
		}
		set
		{
			*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__cachedCount)) = num;
		}
	}

	public unsafe NativeArray<Vector3> _positions
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__positions);
			return new NativeArray<Vector3>(IL2CPP.il2cpp_value_box(Il2CppClassPointerStore<NativeArray<Vector3>>.NativeClassPtr, (System.IntPtr)num));
		}
		set
		{
			// IL cpblk instruction
			Unsafe.CopyBlock((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__positions), IL2CPP.il2cpp_object_unbox(IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)nativeArray)), IL2CPP.il2cpp_class_value_size(Il2CppClassPointerStore<NativeArray<Vector3>>.NativeClassPtr, ref *(uint*)null));
		}
	}

	public unsafe NativeArray<Vector3> _velocities
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__velocities);
			return new NativeArray<Vector3>(IL2CPP.il2cpp_value_box(Il2CppClassPointerStore<NativeArray<Vector3>>.NativeClassPtr, (System.IntPtr)num));
		}
		set
		{
			// IL cpblk instruction
			Unsafe.CopyBlock((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__velocities), IL2CPP.il2cpp_object_unbox(IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)nativeArray)), IL2CPP.il2cpp_class_value_size(Il2CppClassPointerStore<NativeArray<Vector3>>.NativeClassPtr, ref *(uint*)null));
		}
	}

	public unsafe NativeArray<Vector3> _previousVelocities
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__previousVelocities);
			return new NativeArray<Vector3>(IL2CPP.il2cpp_value_box(Il2CppClassPointerStore<NativeArray<Vector3>>.NativeClassPtr, (System.IntPtr)num));
		}
		set
		{
			// IL cpblk instruction
			Unsafe.CopyBlock((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__previousVelocities), IL2CPP.il2cpp_object_unbox(IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)nativeArray)), IL2CPP.il2cpp_class_value_size(Il2CppClassPointerStore<NativeArray<Vector3>>.NativeClassPtr, ref *(uint*)null));
		}
	}

	public unsafe NativeArray<Vector3> _readOnlyPositions
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__readOnlyPositions);
			return new NativeArray<Vector3>(IL2CPP.il2cpp_value_box(Il2CppClassPointerStore<NativeArray<Vector3>>.NativeClassPtr, (System.IntPtr)num));
		}
		set
		{
			// IL cpblk instruction
			Unsafe.CopyBlock((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__readOnlyPositions), IL2CPP.il2cpp_object_unbox(IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)nativeArray)), IL2CPP.il2cpp_class_value_size(Il2CppClassPointerStore<NativeArray<Vector3>>.NativeClassPtr, ref *(uint*)null));
		}
	}

	public unsafe NativeArray<Vector3> _readOnlyVelocities
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__readOnlyVelocities);
			return new NativeArray<Vector3>(IL2CPP.il2cpp_value_box(Il2CppClassPointerStore<NativeArray<Vector3>>.NativeClassPtr, (System.IntPtr)num));
		}
		set
		{
			// IL cpblk instruction
			Unsafe.CopyBlock((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__readOnlyVelocities), IL2CPP.il2cpp_object_unbox(IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)nativeArray)), IL2CPP.il2cpp_class_value_size(Il2CppClassPointerStore<NativeArray<Vector3>>.NativeClassPtr, ref *(uint*)null));
		}
	}

	public unsafe NativeArray<Vector3> _readOnlyPreviousVelocities
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__readOnlyPreviousVelocities);
			return new NativeArray<Vector3>(IL2CPP.il2cpp_value_box(Il2CppClassPointerStore<NativeArray<Vector3>>.NativeClassPtr, (System.IntPtr)num));
		}
		set
		{
			// IL cpblk instruction
			Unsafe.CopyBlock((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__readOnlyPreviousVelocities), IL2CPP.il2cpp_object_unbox(IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)nativeArray)), IL2CPP.il2cpp_class_value_size(Il2CppClassPointerStore<NativeArray<Vector3>>.NativeClassPtr, ref *(uint*)null));
		}
	}

	public unsafe NativeArray<Bounds> _boundsBuffer
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__boundsBuffer);
			return new NativeArray<Bounds>(IL2CPP.il2cpp_value_box(Il2CppClassPointerStore<NativeArray<Bounds>>.NativeClassPtr, (System.IntPtr)num));
		}
		set
		{
			// IL cpblk instruction
			Unsafe.CopyBlock((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__boundsBuffer), IL2CPP.il2cpp_object_unbox(IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)nativeArray)), IL2CPP.il2cpp_class_value_size(Il2CppClassPointerStore<NativeArray<Bounds>>.NativeClassPtr, ref *(uint*)null));
		}
	}

	public unsafe Il2CppStructArray<Matrix4x4> _matrices
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__matrices);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppStructArray<Matrix4x4>>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__matrices)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)val));
		}
	}

	public unsafe Il2CppStructArray<Vector3> _scales
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__scales);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppStructArray<Vector3>>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__scales)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)val));
		}
	}

	public unsafe Il2CppStructArray<float> _spawns
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__spawns);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppStructArray<float>>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__spawns)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)val));
		}
	}

	public unsafe MaterialPropertyBlock _propertyBlock
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__propertyBlock);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<MaterialPropertyBlock>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__propertyBlock)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)materialPropertyBlock));
		}
	}

	public unsafe Il2CppStructArray<Vector4> _colorPropertyBuffer
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__colorPropertyBuffer);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppStructArray<Vector4>>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__colorPropertyBuffer)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)val));
		}
	}

	public unsafe Il2CppStructArray<Vector4> _velocityCurrentPropertyBuffer
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__velocityCurrentPropertyBuffer);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppStructArray<Vector4>>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__velocityCurrentPropertyBuffer)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)val));
		}
	}

	public unsafe Il2CppStructArray<Vector4> _velocityPreviousPropertyBuffer
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__velocityPreviousPropertyBuffer);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppStructArray<Vector4>>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__velocityPreviousPropertyBuffer)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)val));
		}
	}

	public unsafe int _instanceColorPropertyId
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__instanceColorPropertyId);
			return *(int*)num;
		}
		set
		{
			*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__instanceColorPropertyId)) = num;
		}
	}

	public unsafe int _instanceCountPropertyId
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__instanceCountPropertyId);
			return *(int*)num;
		}
		set
		{
			*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__instanceCountPropertyId)) = num;
		}
	}

	public unsafe int _velocityCurrentPropertyId
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__velocityCurrentPropertyId);
			return *(int*)num;
		}
		set
		{
			*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__velocityCurrentPropertyId)) = num;
		}
	}

	public unsafe int _velocityPreviousPropertyId
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__velocityPreviousPropertyId);
			return *(int*)num;
		}
		set
		{
			*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__velocityPreviousPropertyId)) = num;
		}
	}

	public unsafe Il2CppReferenceArray<Collider> _colliderBuffer
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__colliderBuffer);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppReferenceArray<Collider>>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__colliderBuffer)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)val));
		}
	}

	public unsafe int _colliderCount
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__colliderCount);
			return *(int*)num;
		}
		set
		{
			*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__colliderCount)) = num;
		}
	}

	static BoidsVolume()
	{
		Il2CppClassPointerStore<BoidsVolume>.NativeClassPtr = IL2CPP.GetIl2CppClass("Assembly-CSharp.dll", "BAPBAP.Boids", "BoidsVolume");
		IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<BoidsVolume>.NativeClassPtr);
		NativeFieldInfoPtr__radius = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<BoidsVolume>.NativeClassPtr, "_radius");
		NativeFieldInfoPtr__targetOffset = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<BoidsVolume>.NativeClassPtr, "_targetOffset");
		NativeFieldInfoPtr__spawnOffset = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<BoidsVolume>.NativeClassPtr, "_spawnOffset");
		NativeFieldInfoPtr__count = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<BoidsVolume>.NativeClassPtr, "_count");
		NativeFieldInfoPtr__mesh = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<BoidsVolume>.NativeClassPtr, "_mesh");
		NativeFieldInfoPtr__material = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<BoidsVolume>.NativeClassPtr, "_material");
		NativeFieldInfoPtr__colorGradient = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<BoidsVolume>.NativeClassPtr, "_colorGradient");
		NativeFieldInfoPtr__minGrouping = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<BoidsVolume>.NativeClassPtr, "_minGrouping");
		NativeFieldInfoPtr__maxGrouping = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<BoidsVolume>.NativeClassPtr, "_maxGrouping");
		NativeFieldInfoPtr__groupingRadius = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<BoidsVolume>.NativeClassPtr, "_groupingRadius");
		NativeFieldInfoPtr__minScale = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<BoidsVolume>.NativeClassPtr, "_minScale");
		NativeFieldInfoPtr__maxScale = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<BoidsVolume>.NativeClassPtr, "_maxScale");
		NativeFieldInfoPtr__spawnDuration = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<BoidsVolume>.NativeClassPtr, "_spawnDuration");
		NativeFieldInfoPtr__spawnRate = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<BoidsVolume>.NativeClassPtr, "_spawnRate");
		NativeFieldInfoPtr__maxSpeed = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<BoidsVolume>.NativeClassPtr, "_maxSpeed");
		NativeFieldInfoPtr__acceleration = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<BoidsVolume>.NativeClassPtr, "_acceleration");
		NativeFieldInfoPtr__previousVelocityDelay = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<BoidsVolume>.NativeClassPtr, "_previousVelocityDelay");
		NativeFieldInfoPtr__separationRadius = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<BoidsVolume>.NativeClassPtr, "_separationRadius");
		NativeFieldInfoPtr__separationWeight = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<BoidsVolume>.NativeClassPtr, "_separationWeight");
		NativeFieldInfoPtr__cohesionRadius = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<BoidsVolume>.NativeClassPtr, "_cohesionRadius");
		NativeFieldInfoPtr__cohesionWeight = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<BoidsVolume>.NativeClassPtr, "_cohesionWeight");
		NativeFieldInfoPtr__alignmentRadius = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<BoidsVolume>.NativeClassPtr, "_alignmentRadius");
		NativeFieldInfoPtr__alignmentWeight = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<BoidsVolume>.NativeClassPtr, "_alignmentWeight");
		NativeFieldInfoPtr__repulsionRadius = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<BoidsVolume>.NativeClassPtr, "_repulsionRadius");
		NativeFieldInfoPtr__repulsionWeight = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<BoidsVolume>.NativeClassPtr, "_repulsionWeight");
		NativeFieldInfoPtr__targetWeight = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<BoidsVolume>.NativeClassPtr, "_targetWeight");
		NativeFieldInfoPtr__horizontalWeight = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<BoidsVolume>.NativeClassPtr, "_horizontalWeight");
		NativeFieldInfoPtr__radiusWeight = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<BoidsVolume>.NativeClassPtr, "_radiusWeight");
		NativeFieldInfoPtr__reluctanceWeight = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<BoidsVolume>.NativeClassPtr, "_reluctanceWeight");
		NativeFieldInfoPtr__collisionRadius = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<BoidsVolume>.NativeClassPtr, "_collisionRadius");
		NativeFieldInfoPtr__collisionWeight = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<BoidsVolume>.NativeClassPtr, "_collisionWeight");
		NativeFieldInfoPtr__colliderMask = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<BoidsVolume>.NativeClassPtr, "_colliderMask");
		NativeFieldInfoPtr__colliderBufferSize = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<BoidsVolume>.NativeClassPtr, "_colliderBufferSize");
		NativeFieldInfoPtr__warnColliderBufferOverflow = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<BoidsVolume>.NativeClassPtr, "_warnColliderBufferOverflow");
		NativeFieldInfoPtr__cachedCount = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<BoidsVolume>.NativeClassPtr, "_cachedCount");
		NativeFieldInfoPtr__positions = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<BoidsVolume>.NativeClassPtr, "_positions");
		NativeFieldInfoPtr__velocities = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<BoidsVolume>.NativeClassPtr, "_velocities");
		NativeFieldInfoPtr__previousVelocities = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<BoidsVolume>.NativeClassPtr, "_previousVelocities");
		NativeFieldInfoPtr__readOnlyPositions = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<BoidsVolume>.NativeClassPtr, "_readOnlyPositions");
		NativeFieldInfoPtr__readOnlyVelocities = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<BoidsVolume>.NativeClassPtr, "_readOnlyVelocities");
		NativeFieldInfoPtr__readOnlyPreviousVelocities = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<BoidsVolume>.NativeClassPtr, "_readOnlyPreviousVelocities");
		NativeFieldInfoPtr__boundsBuffer = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<BoidsVolume>.NativeClassPtr, "_boundsBuffer");
		NativeFieldInfoPtr__matrices = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<BoidsVolume>.NativeClassPtr, "_matrices");
		NativeFieldInfoPtr__scales = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<BoidsVolume>.NativeClassPtr, "_scales");
		NativeFieldInfoPtr__spawns = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<BoidsVolume>.NativeClassPtr, "_spawns");
		NativeFieldInfoPtr__propertyBlock = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<BoidsVolume>.NativeClassPtr, "_propertyBlock");
		NativeFieldInfoPtr__colorPropertyBuffer = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<BoidsVolume>.NativeClassPtr, "_colorPropertyBuffer");
		NativeFieldInfoPtr__velocityCurrentPropertyBuffer = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<BoidsVolume>.NativeClassPtr, "_velocityCurrentPropertyBuffer");
		NativeFieldInfoPtr__velocityPreviousPropertyBuffer = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<BoidsVolume>.NativeClassPtr, "_velocityPreviousPropertyBuffer");
		NativeFieldInfoPtr__instanceColorPropertyId = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<BoidsVolume>.NativeClassPtr, "_instanceColorPropertyId");
		NativeFieldInfoPtr__instanceCountPropertyId = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<BoidsVolume>.NativeClassPtr, "_instanceCountPropertyId");
		NativeFieldInfoPtr__velocityCurrentPropertyId = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<BoidsVolume>.NativeClassPtr, "_velocityCurrentPropertyId");
		NativeFieldInfoPtr__velocityPreviousPropertyId = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<BoidsVolume>.NativeClassPtr, "_velocityPreviousPropertyId");
		NativeFieldInfoPtr__colliderBuffer = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<BoidsVolume>.NativeClassPtr, "_colliderBuffer");
		NativeFieldInfoPtr__colliderCount = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<BoidsVolume>.NativeClassPtr, "_colliderCount");
		NativeMethodInfoPtr_SetCount_Public_Void_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<BoidsVolume>.NativeClassPtr, 100671820);
		NativeMethodInfoPtr_Awake_Private_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<BoidsVolume>.NativeClassPtr, 100671821);
		NativeMethodInfoPtr_Update_Private_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<BoidsVolume>.NativeClassPtr, 100671822);
		NativeMethodInfoPtr_OnDestroy_Private_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<BoidsVolume>.NativeClassPtr, 100671823);
		NativeMethodInfoPtr_OnDrawGizmos_Private_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<BoidsVolume>.NativeClassPtr, 100671824);
		NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<BoidsVolume>.NativeClassPtr, 100671825);
	}

	[CallerCount(2)]
	[CachedScanResults(RefRangeStart = 112097, RefRangeEnd = 112099, XrefRangeStart = 112056, XrefRangeEnd = 112097, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void SetCount(int count)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = (nint)(&count);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_SetCount_Public_Void_Int32_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 112099, XrefRangeEnd = 112112, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void Awake()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_Awake_Private_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 112112, XrefRangeEnd = 112161, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void Update()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_Update_Private_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 112161, XrefRangeEnd = 112166, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void OnDestroy()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_OnDestroy_Private_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 112166, XrefRangeEnd = 112172, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void OnDrawGizmos()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_OnDrawGizmos_Private_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 112172, XrefRangeEnd = 112175, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe BoidsVolume()
		: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<BoidsVolume>.NativeClassPtr))
	{
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	public BoidsVolume(System.IntPtr pointer)
		: base(pointer)
	{
	}
}
