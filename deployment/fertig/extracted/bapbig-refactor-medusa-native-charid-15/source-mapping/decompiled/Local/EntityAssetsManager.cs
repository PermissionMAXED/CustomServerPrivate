using System;
using System.Runtime.CompilerServices;
using Il2CppBAPBAP.Maps;
using Il2CppBAPBAP.UI;
using Il2CppInterop.Common.Attributes;
using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.InteropTypes;
using Il2CppInterop.Runtime.InteropTypes.Arrays;
using Il2CppInterop.Runtime.Runtime;
using Il2CppSystem;
using UnityEngine;

namespace Il2CppBAPBAP.Local;

public class EntityAssetsManager : MonoBehaviour
{
	[OriginalName("Assembly-CSharp.dll", "", "EntityTypeEnum")]
	public enum EntityTypeEnum
	{
		Character,
		Item,
		Interactable
	}

	[System.Serializable]
	public class EntityAsset : Il2CppSystem.Object
	{
		[System.Serializable]
		public class Settings : Il2CppSystem.Object
		{
			[System.Serializable]
			public class RandomSpawns : Il2CppSystem.Object
			{
				[System.Serializable]
				public class RandomEntity : Il2CppSystem.Object
				{
					private static readonly System.IntPtr NativeFieldInfoPtr_spawnChance;

					private static readonly System.IntPtr NativeFieldInfoPtr_entityPrefab;

					private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

					public unsafe float spawnChance
					{
						get
						{
							nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_spawnChance);
							return *(float*)num;
						}
						set
						{
							*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_spawnChance)) = num;
						}
					}

					public unsafe GameObject entityPrefab
					{
						get
						{
							nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_entityPrefab);
							System.IntPtr intPtr = *(System.IntPtr*)num;
							return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<GameObject>(intPtr) : null;
						}
						set
						{
							System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
							IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_entityPrefab)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)gameObject));
						}
					}

					static RandomEntity()
					{
						Il2CppClassPointerStore<RandomEntity>.NativeClassPtr = IL2CPP.GetIl2CppNestedType(Il2CppClassPointerStore<RandomSpawns>.NativeClassPtr, "RandomEntity");
						IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<RandomEntity>.NativeClassPtr);
						NativeFieldInfoPtr_spawnChance = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<RandomEntity>.NativeClassPtr, "spawnChance");
						NativeFieldInfoPtr_entityPrefab = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<RandomEntity>.NativeClassPtr, "entityPrefab");
						NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<RandomEntity>.NativeClassPtr, 100684262);
					}

					[CallerCount(5410)]
					[CachedScanResults(RefRangeStart = 11, RefRangeEnd = 5421, XrefRangeStart = 11, XrefRangeEnd = 5421, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
					public unsafe RandomEntity()
						: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<RandomEntity>.NativeClassPtr))
					{
						System.IntPtr* ptr = null;
						Unsafe.SkipInit(out System.IntPtr intPtr2);
						System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
						Il2CppException.RaiseExceptionIfNecessary(intPtr2);
					}

					public RandomEntity(System.IntPtr pointer)
						: base(pointer)
					{
					}
				}

				[System.Serializable]
				[ObfuscatedName("BAPBAP.Local.EntityAssetsManager+EntityAsset+Settings+RandomSpawns+<>c")]
				public sealed class __c : Il2CppSystem.Object
				{
					private static readonly System.IntPtr NativeFieldInfoPtr___9;

					private static readonly System.IntPtr NativeFieldInfoPtr___9__2_0;

					private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

					private static readonly System.IntPtr NativeMethodInfoPtr__GetRandomEntity_b__2_0_Internal_Single_RandomEntity_0;

					public unsafe static __c __9
					{
						get
						{
							Unsafe.SkipInit(out System.IntPtr intPtr);
							IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr___9, (void*)(&intPtr));
							System.IntPtr intPtr2 = intPtr;
							return (intPtr2 != (System.IntPtr)0) ? Il2CppObjectPool.Get<__c>(intPtr2) : null;
						}
						set
						{
							IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr___9, (void*)IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)_c));
						}
					}

					public unsafe static Il2CppSystem.Func<RandomEntity, float> __9__2_0
					{
						get
						{
							Unsafe.SkipInit(out System.IntPtr intPtr);
							IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr___9__2_0, (void*)(&intPtr));
							System.IntPtr intPtr2 = intPtr;
							return (intPtr2 != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppSystem.Func<RandomEntity, float>>(intPtr2) : null;
						}
						set
						{
							IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr___9__2_0, (void*)IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)func));
						}
					}

					static __c()
					{
						Il2CppClassPointerStore<__c>.NativeClassPtr = IL2CPP.GetIl2CppNestedType(Il2CppClassPointerStore<RandomSpawns>.NativeClassPtr, "<>c");
						IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<__c>.NativeClassPtr);
						NativeFieldInfoPtr___9 = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<__c>.NativeClassPtr, "<>9");
						NativeFieldInfoPtr___9__2_0 = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<__c>.NativeClassPtr, "<>9__2_0");
						NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<__c>.NativeClassPtr, 100684264);
						NativeMethodInfoPtr__GetRandomEntity_b__2_0_Internal_Single_RandomEntity_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<__c>.NativeClassPtr, 100684265);
					}

					[CallerCount(5410)]
					[CachedScanResults(RefRangeStart = 11, RefRangeEnd = 5421, XrefRangeStart = 11, XrefRangeEnd = 5421, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
					public unsafe __c()
						: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<__c>.NativeClassPtr))
					{
						System.IntPtr* ptr = null;
						Unsafe.SkipInit(out System.IntPtr intPtr2);
						System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
						Il2CppException.RaiseExceptionIfNecessary(intPtr2);
					}

					[CallerCount(0)]
					public unsafe float _GetRandomEntity_b__2_0(RandomEntity x)
					{
						IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
						System.IntPtr* ptr = stackalloc System.IntPtr[1];
						*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)x);
						Unsafe.SkipInit(out System.IntPtr intPtr2);
						System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__GetRandomEntity_b__2_0_Internal_Single_RandomEntity_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
						Il2CppException.RaiseExceptionIfNecessary(intPtr2);
						return *(float*)IL2CPP.il2cpp_object_unbox(intPtr);
					}

					public __c(System.IntPtr pointer)
						: base(pointer)
					{
					}
				}

				private static readonly System.IntPtr NativeFieldInfoPtr_entities;

				private static readonly System.IntPtr NativeMethodInfoPtr_GetRandomEntity_Public_GameObject_0;

				private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

				public unsafe Il2CppReferenceArray<RandomEntity> entities
				{
					get
					{
						nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_entities);
						System.IntPtr intPtr = *(System.IntPtr*)num;
						return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppReferenceArray<RandomEntity>>(intPtr) : null;
					}
					set
					{
						System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
						IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_entities)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)val));
					}
				}

				static RandomSpawns()
				{
					Il2CppClassPointerStore<RandomSpawns>.NativeClassPtr = IL2CPP.GetIl2CppNestedType(Il2CppClassPointerStore<Settings>.NativeClassPtr, "RandomSpawns");
					IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<RandomSpawns>.NativeClassPtr);
					NativeFieldInfoPtr_entities = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<RandomSpawns>.NativeClassPtr, "entities");
					NativeMethodInfoPtr_GetRandomEntity_Public_GameObject_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<RandomSpawns>.NativeClassPtr, 100684260);
					NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<RandomSpawns>.NativeClassPtr, 100684261);
				}

				[CallerCount(1)]
				[CachedScanResults(RefRangeStart = 226160, RefRangeEnd = 226161, XrefRangeStart = 226149, XrefRangeEnd = 226160, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
				public unsafe GameObject GetRandomEntity()
				{
					IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
					System.IntPtr* ptr = null;
					Unsafe.SkipInit(out System.IntPtr intPtr2);
					System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetRandomEntity_Public_GameObject_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
					Il2CppException.RaiseExceptionIfNecessary(intPtr2);
					return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<GameObject>(intPtr) : null;
				}

				[CallerCount(5410)]
				[CachedScanResults(RefRangeStart = 11, RefRangeEnd = 5421, XrefRangeStart = 11, XrefRangeEnd = 5421, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
				public unsafe RandomSpawns()
					: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<RandomSpawns>.NativeClassPtr))
				{
					System.IntPtr* ptr = null;
					Unsafe.SkipInit(out System.IntPtr intPtr2);
					System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
					Il2CppException.RaiseExceptionIfNecessary(intPtr2);
				}

				public RandomSpawns(System.IntPtr pointer)
					: base(pointer)
				{
				}
			}

			private static readonly System.IntPtr NativeFieldInfoPtr_isVaulted;

			private static readonly System.IntPtr NativeFieldInfoPtr_doSpawnPercentage;

			private static readonly System.IntPtr NativeFieldInfoPtr_spawnPercentage;

			private static readonly System.IntPtr NativeFieldInfoPtr_spawnChance;

			private static readonly System.IntPtr NativeFieldInfoPtr_spawnRandomPrefabs;

			private static readonly System.IntPtr NativeFieldInfoPtr_randomPrefabs;

			private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

			public unsafe bool isVaulted
			{
				get
				{
					nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_isVaulted);
					return *(bool*)num;
				}
				set
				{
					*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_isVaulted)) = flag;
				}
			}

			public unsafe bool doSpawnPercentage
			{
				get
				{
					nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_doSpawnPercentage);
					return *(bool*)num;
				}
				set
				{
					*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_doSpawnPercentage)) = flag;
				}
			}

			public unsafe float spawnPercentage
			{
				get
				{
					nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_spawnPercentage);
					return *(float*)num;
				}
				set
				{
					*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_spawnPercentage)) = num;
				}
			}

			public unsafe float spawnChance
			{
				get
				{
					nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_spawnChance);
					return *(float*)num;
				}
				set
				{
					*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_spawnChance)) = num;
				}
			}

			public unsafe bool spawnRandomPrefabs
			{
				get
				{
					nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_spawnRandomPrefabs);
					return *(bool*)num;
				}
				set
				{
					*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_spawnRandomPrefabs)) = flag;
				}
			}

			public unsafe RandomSpawns randomPrefabs
			{
				get
				{
					nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_randomPrefabs);
					System.IntPtr intPtr = *(System.IntPtr*)num;
					return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<RandomSpawns>(intPtr) : null;
				}
				set
				{
					System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
					IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_randomPrefabs)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)randomSpawns));
				}
			}

			static Settings()
			{
				Il2CppClassPointerStore<Settings>.NativeClassPtr = IL2CPP.GetIl2CppNestedType(Il2CppClassPointerStore<EntityAsset>.NativeClassPtr, "Settings");
				IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<Settings>.NativeClassPtr);
				NativeFieldInfoPtr_isVaulted = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Settings>.NativeClassPtr, "isVaulted");
				NativeFieldInfoPtr_doSpawnPercentage = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Settings>.NativeClassPtr, "doSpawnPercentage");
				NativeFieldInfoPtr_spawnPercentage = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Settings>.NativeClassPtr, "spawnPercentage");
				NativeFieldInfoPtr_spawnChance = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Settings>.NativeClassPtr, "spawnChance");
				NativeFieldInfoPtr_spawnRandomPrefabs = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Settings>.NativeClassPtr, "spawnRandomPrefabs");
				NativeFieldInfoPtr_randomPrefabs = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Settings>.NativeClassPtr, "randomPrefabs");
				NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<Settings>.NativeClassPtr, 100684259);
			}

			[CallerCount(0)]
			[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 0, XrefRangeEnd = 0, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
			public unsafe Settings()
				: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<Settings>.NativeClassPtr))
			{
				System.IntPtr* ptr = null;
				Unsafe.SkipInit(out System.IntPtr intPtr2);
				System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
				Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			}

			public Settings(System.IntPtr pointer)
				: base(pointer)
			{
			}
		}

		[System.Serializable]
		public class Config : Il2CppSystem.Object
		{
			private static readonly System.IntPtr NativeFieldInfoPtr_nameTranslationKey;

			private static readonly System.IntPtr NativeFieldInfoPtr_nameLocalized;

			private static readonly System.IntPtr NativeFieldInfoPtr_uiIcon;

			private static readonly System.IntPtr NativeFieldInfoPtr_iconColor;

			private static readonly System.IntPtr NativeFieldInfoPtr_applyConfigToInstances;

			private static readonly System.IntPtr NativeFieldInfoPtr_createMinimapIcon;

			private static readonly System.IntPtr NativeFieldInfoPtr_minimapIconPrefab;

			private static readonly System.IntPtr NativeFieldInfoPtr_pingWorldPrefab;

			private static readonly System.IntPtr NativeFieldInfoPtr_pingUiPrefab;

			private static readonly System.IntPtr NativeFieldInfoPtr_pingMinimapPrefab;

			private static readonly System.IntPtr NativeMethodInfoPtr_GetMinimapPrefab_Public_GameObject_0;

			private static readonly System.IntPtr NativeMethodInfoPtr_InitializeMinimapInstance_Public_Void_UIMinimapIcon_0;

			private static readonly System.IntPtr NativeMethodInfoPtr_GetPingWorldPrefab_Public_GameObject_0;

			private static readonly System.IntPtr NativeMethodInfoPtr_InitializePingWorldInstance_Public_Void_GameObject_0;

			private static readonly System.IntPtr NativeMethodInfoPtr_GetPingUiPrefab_Public_GameObject_0;

			private static readonly System.IntPtr NativeMethodInfoPtr_InitializePingUIInstance_Public_Void_UIPingElement_0;

			private static readonly System.IntPtr NativeMethodInfoPtr_GetPingMinimapPrefab_Public_GameObject_0;

			private static readonly System.IntPtr NativeMethodInfoPtr_InitializePingMinimapInstance_Public_Void_UIMinimapIcon_0;

			private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

			public unsafe string nameTranslationKey
			{
				get
				{
					nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_nameTranslationKey);
					return IL2CPP.Il2CppStringToManaged(*(System.IntPtr*)num);
				}
				set
				{
					System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
					IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_nameTranslationKey)), IL2CPP.ManagedStringToIl2Cpp(text));
				}
			}

			public unsafe string nameLocalized
			{
				get
				{
					nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_nameLocalized);
					return IL2CPP.Il2CppStringToManaged(*(System.IntPtr*)num);
				}
				set
				{
					System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
					IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_nameLocalized)), IL2CPP.ManagedStringToIl2Cpp(text));
				}
			}

			public unsafe Sprite uiIcon
			{
				get
				{
					nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_uiIcon);
					System.IntPtr intPtr = *(System.IntPtr*)num;
					return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Sprite>(intPtr) : null;
				}
				set
				{
					System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
					IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_uiIcon)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)sprite));
				}
			}

			public unsafe Color iconColor
			{
				get
				{
					nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_iconColor);
					return *(Color*)num;
				}
				set
				{
					*(Color*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_iconColor)) = color;
				}
			}

			public unsafe bool applyConfigToInstances
			{
				get
				{
					nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_applyConfigToInstances);
					return *(bool*)num;
				}
				set
				{
					*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_applyConfigToInstances)) = flag;
				}
			}

			public unsafe bool createMinimapIcon
			{
				get
				{
					nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_createMinimapIcon);
					return *(bool*)num;
				}
				set
				{
					*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_createMinimapIcon)) = flag;
				}
			}

			public unsafe GameObject minimapIconPrefab
			{
				get
				{
					nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_minimapIconPrefab);
					System.IntPtr intPtr = *(System.IntPtr*)num;
					return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<GameObject>(intPtr) : null;
				}
				set
				{
					System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
					IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_minimapIconPrefab)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)gameObject));
				}
			}

			public unsafe GameObject pingWorldPrefab
			{
				get
				{
					nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_pingWorldPrefab);
					System.IntPtr intPtr = *(System.IntPtr*)num;
					return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<GameObject>(intPtr) : null;
				}
				set
				{
					System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
					IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_pingWorldPrefab)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)gameObject));
				}
			}

			public unsafe GameObject pingUiPrefab
			{
				get
				{
					nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_pingUiPrefab);
					System.IntPtr intPtr = *(System.IntPtr*)num;
					return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<GameObject>(intPtr) : null;
				}
				set
				{
					System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
					IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_pingUiPrefab)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)gameObject));
				}
			}

			public unsafe GameObject pingMinimapPrefab
			{
				get
				{
					nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_pingMinimapPrefab);
					System.IntPtr intPtr = *(System.IntPtr*)num;
					return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<GameObject>(intPtr) : null;
				}
				set
				{
					System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
					IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_pingMinimapPrefab)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)gameObject));
				}
			}

			static Config()
			{
				Il2CppClassPointerStore<Config>.NativeClassPtr = IL2CPP.GetIl2CppNestedType(Il2CppClassPointerStore<EntityAsset>.NativeClassPtr, "Config");
				IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<Config>.NativeClassPtr);
				NativeFieldInfoPtr_nameTranslationKey = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Config>.NativeClassPtr, "nameTranslationKey");
				NativeFieldInfoPtr_nameLocalized = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Config>.NativeClassPtr, "nameLocalized");
				NativeFieldInfoPtr_uiIcon = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Config>.NativeClassPtr, "uiIcon");
				NativeFieldInfoPtr_iconColor = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Config>.NativeClassPtr, "iconColor");
				NativeFieldInfoPtr_applyConfigToInstances = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Config>.NativeClassPtr, "applyConfigToInstances");
				NativeFieldInfoPtr_createMinimapIcon = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Config>.NativeClassPtr, "createMinimapIcon");
				NativeFieldInfoPtr_minimapIconPrefab = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Config>.NativeClassPtr, "minimapIconPrefab");
				NativeFieldInfoPtr_pingWorldPrefab = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Config>.NativeClassPtr, "pingWorldPrefab");
				NativeFieldInfoPtr_pingUiPrefab = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Config>.NativeClassPtr, "pingUiPrefab");
				NativeFieldInfoPtr_pingMinimapPrefab = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Config>.NativeClassPtr, "pingMinimapPrefab");
				NativeMethodInfoPtr_GetMinimapPrefab_Public_GameObject_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<Config>.NativeClassPtr, 100684266);
				NativeMethodInfoPtr_InitializeMinimapInstance_Public_Void_UIMinimapIcon_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<Config>.NativeClassPtr, 100684267);
				NativeMethodInfoPtr_GetPingWorldPrefab_Public_GameObject_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<Config>.NativeClassPtr, 100684268);
				NativeMethodInfoPtr_InitializePingWorldInstance_Public_Void_GameObject_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<Config>.NativeClassPtr, 100684269);
				NativeMethodInfoPtr_GetPingUiPrefab_Public_GameObject_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<Config>.NativeClassPtr, 100684270);
				NativeMethodInfoPtr_InitializePingUIInstance_Public_Void_UIPingElement_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<Config>.NativeClassPtr, 100684271);
				NativeMethodInfoPtr_GetPingMinimapPrefab_Public_GameObject_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<Config>.NativeClassPtr, 100684272);
				NativeMethodInfoPtr_InitializePingMinimapInstance_Public_Void_UIMinimapIcon_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<Config>.NativeClassPtr, 100684273);
				NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<Config>.NativeClassPtr, 100684274);
			}

			[CallerCount(1)]
			[CachedScanResults(RefRangeStart = 226165, RefRangeEnd = 226166, XrefRangeStart = 226161, XrefRangeEnd = 226165, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
			public unsafe GameObject GetMinimapPrefab()
			{
				IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				System.IntPtr* ptr = null;
				Unsafe.SkipInit(out System.IntPtr intPtr2);
				System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetMinimapPrefab_Public_GameObject_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
				Il2CppException.RaiseExceptionIfNecessary(intPtr2);
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<GameObject>(intPtr) : null;
			}

			[CallerCount(1)]
			[CachedScanResults(RefRangeStart = 226170, RefRangeEnd = 226171, XrefRangeStart = 226166, XrefRangeEnd = 226170, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
			public unsafe void InitializeMinimapInstance(UIMinimapIcon iconInstance)
			{
				IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				System.IntPtr* ptr = stackalloc System.IntPtr[1];
				*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)iconInstance);
				Unsafe.SkipInit(out System.IntPtr intPtr2);
				System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_InitializeMinimapInstance_Public_Void_UIMinimapIcon_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
				Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			}

			[CallerCount(0)]
			[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 226171, XrefRangeEnd = 226175, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
			public unsafe GameObject GetPingWorldPrefab()
			{
				IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				System.IntPtr* ptr = null;
				Unsafe.SkipInit(out System.IntPtr intPtr2);
				System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetPingWorldPrefab_Public_GameObject_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
				Il2CppException.RaiseExceptionIfNecessary(intPtr2);
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<GameObject>(intPtr) : null;
			}

			[CallerCount(0)]
			[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 226175, XrefRangeEnd = 226181, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
			public unsafe void InitializePingWorldInstance(GameObject worldPingInstance)
			{
				IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				System.IntPtr* ptr = stackalloc System.IntPtr[1];
				*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)worldPingInstance);
				Unsafe.SkipInit(out System.IntPtr intPtr2);
				System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_InitializePingWorldInstance_Public_Void_GameObject_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
				Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			}

			[CallerCount(0)]
			[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 226181, XrefRangeEnd = 226185, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
			public unsafe GameObject GetPingUiPrefab()
			{
				IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				System.IntPtr* ptr = null;
				Unsafe.SkipInit(out System.IntPtr intPtr2);
				System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetPingUiPrefab_Public_GameObject_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
				Il2CppException.RaiseExceptionIfNecessary(intPtr2);
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<GameObject>(intPtr) : null;
			}

			[CallerCount(0)]
			[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 226185, XrefRangeEnd = 226191, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
			public unsafe void InitializePingUIInstance(UIPingElement iconInstance)
			{
				IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				System.IntPtr* ptr = stackalloc System.IntPtr[1];
				*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)iconInstance);
				Unsafe.SkipInit(out System.IntPtr intPtr2);
				System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_InitializePingUIInstance_Public_Void_UIPingElement_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
				Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			}

			[CallerCount(1)]
			[CachedScanResults(RefRangeStart = 226195, RefRangeEnd = 226196, XrefRangeStart = 226191, XrefRangeEnd = 226195, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
			public unsafe GameObject GetPingMinimapPrefab()
			{
				IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				System.IntPtr* ptr = null;
				Unsafe.SkipInit(out System.IntPtr intPtr2);
				System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetPingMinimapPrefab_Public_GameObject_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
				Il2CppException.RaiseExceptionIfNecessary(intPtr2);
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<GameObject>(intPtr) : null;
			}

			[CallerCount(1)]
			[CachedScanResults(RefRangeStart = 226201, RefRangeEnd = 226202, XrefRangeStart = 226196, XrefRangeEnd = 226201, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
			public unsafe void InitializePingMinimapInstance(UIMinimapIcon iconInstance)
			{
				IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				System.IntPtr* ptr = stackalloc System.IntPtr[1];
				*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)iconInstance);
				Unsafe.SkipInit(out System.IntPtr intPtr2);
				System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_InitializePingMinimapInstance_Public_Void_UIMinimapIcon_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
				Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			}

			[CallerCount(0)]
			[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 226202, XrefRangeEnd = 226203, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
			public unsafe Config()
				: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<Config>.NativeClassPtr))
			{
				System.IntPtr* ptr = null;
				Unsafe.SkipInit(out System.IntPtr intPtr2);
				System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
				Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			}

			public Config(System.IntPtr pointer)
				: base(pointer)
			{
			}
		}

		private static readonly System.IntPtr NativeFieldInfoPtr_entityType;

		private static readonly System.IntPtr NativeFieldInfoPtr_config;

		private static readonly System.IntPtr NativeFieldInfoPtr_settings;

		private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

		public unsafe EntityTypeEnum entityType
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_entityType);
				return *(EntityTypeEnum*)num;
			}
			set
			{
				*(EntityTypeEnum*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_entityType)) = entityTypeEnum;
			}
		}

		public unsafe Config config
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_config);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Config>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_config)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)config));
			}
		}

		public unsafe Settings settings
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_settings);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Settings>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_settings)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)settings));
			}
		}

		static EntityAsset()
		{
			Il2CppClassPointerStore<EntityAsset>.NativeClassPtr = IL2CPP.GetIl2CppNestedType(Il2CppClassPointerStore<EntityAssetsManager>.NativeClassPtr, "EntityAsset");
			IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<EntityAsset>.NativeClassPtr);
			NativeFieldInfoPtr_entityType = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<EntityAsset>.NativeClassPtr, "entityType");
			NativeFieldInfoPtr_config = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<EntityAsset>.NativeClassPtr, "config");
			NativeFieldInfoPtr_settings = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<EntityAsset>.NativeClassPtr, "settings");
			NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<EntityAsset>.NativeClassPtr, 100684258);
		}

		[CallerCount(5410)]
		[CachedScanResults(RefRangeStart = 11, RefRangeEnd = 5421, XrefRangeStart = 11, XrefRangeEnd = 5421, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe EntityAsset()
			: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<EntityAsset>.NativeClassPtr))
		{
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		public EntityAsset(System.IntPtr pointer)
			: base(pointer)
		{
		}
	}

	private static readonly System.IntPtr NativeFieldInfoPtr_spawnPointPrefab;

	private static readonly System.IntPtr NativeFieldInfoPtr_dimensionSpawnPointPrefab;

	private static readonly System.IntPtr NativeFieldInfoPtr_tombstonePrefab;

	private static readonly System.IntPtr NativeFieldInfoPtr_supplyDropEntityPrefab;

	private static readonly System.IntPtr NativeFieldInfoPtr_reviveAltarEntityPrefab;

	private static readonly System.IntPtr NativeFieldInfoPtr_reviveAltarDesertEntityPrefab;

	private static readonly System.IntPtr NativeFieldInfoPtr_itemEntityPrefab;

	private static readonly System.IntPtr NativeFieldInfoPtr_shopItemPingEntityPrefab;

	private static readonly System.IntPtr NativeFieldInfoPtr_territoryZonePrefab;

	private static readonly System.IntPtr NativeFieldInfoPtr_slimeBossEntityPrefab;

	private static readonly System.IntPtr NativeFieldInfoPtr_itemEntityPrefabId;

	private static readonly System.IntPtr NativeFieldInfoPtr_shopItemPingEntityPrefabId;

	private static readonly System.IntPtr NativeFieldInfoPtr_supplyDropEntityPrefabId;

	private static readonly System.IntPtr NativeFieldInfoPtr_reviveAltarEntityPrefabId;

	private static readonly System.IntPtr NativeFieldInfoPtr_reviveAltarDesertEntityPrefabId;

	private static readonly System.IntPtr NativeFieldInfoPtr_territoryZonePrefabId;

	private static readonly System.IntPtr NativeMethodInfoPtr_PreAwake_Public_Void_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_GetEntityPrefabFromPrefabId_Public_GameObject_Int32_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_TryGetConfigFromPrefabId_Public_Boolean_Int32_byref_PrefabConfig_0;

	private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

	public unsafe GameObject spawnPointPrefab
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_spawnPointPrefab);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<GameObject>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_spawnPointPrefab)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)gameObject));
		}
	}

	public unsafe GameObject dimensionSpawnPointPrefab
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_dimensionSpawnPointPrefab);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<GameObject>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_dimensionSpawnPointPrefab)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)gameObject));
		}
	}

	public unsafe GameObject tombstonePrefab
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_tombstonePrefab);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<GameObject>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_tombstonePrefab)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)gameObject));
		}
	}

	public unsafe PrefabConfig supplyDropEntityPrefab
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_supplyDropEntityPrefab);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<PrefabConfig>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_supplyDropEntityPrefab)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)prefabConfig));
		}
	}

	public unsafe PrefabConfig reviveAltarEntityPrefab
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_reviveAltarEntityPrefab);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<PrefabConfig>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_reviveAltarEntityPrefab)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)prefabConfig));
		}
	}

	public unsafe PrefabConfig reviveAltarDesertEntityPrefab
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_reviveAltarDesertEntityPrefab);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<PrefabConfig>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_reviveAltarDesertEntityPrefab)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)prefabConfig));
		}
	}

	public unsafe PrefabConfig itemEntityPrefab
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_itemEntityPrefab);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<PrefabConfig>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_itemEntityPrefab)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)prefabConfig));
		}
	}

	public unsafe PrefabConfig shopItemPingEntityPrefab
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_shopItemPingEntityPrefab);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<PrefabConfig>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_shopItemPingEntityPrefab)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)prefabConfig));
		}
	}

	public unsafe PrefabConfig territoryZonePrefab
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_territoryZonePrefab);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<PrefabConfig>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_territoryZonePrefab)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)prefabConfig));
		}
	}

	public unsafe PrefabConfig slimeBossEntityPrefab
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_slimeBossEntityPrefab);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<PrefabConfig>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_slimeBossEntityPrefab)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)prefabConfig));
		}
	}

	public unsafe int itemEntityPrefabId
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_itemEntityPrefabId);
			return *(int*)num;
		}
		set
		{
			*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_itemEntityPrefabId)) = num;
		}
	}

	public unsafe int shopItemPingEntityPrefabId
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_shopItemPingEntityPrefabId);
			return *(int*)num;
		}
		set
		{
			*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_shopItemPingEntityPrefabId)) = num;
		}
	}

	public unsafe int supplyDropEntityPrefabId
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_supplyDropEntityPrefabId);
			return *(int*)num;
		}
		set
		{
			*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_supplyDropEntityPrefabId)) = num;
		}
	}

	public unsafe int reviveAltarEntityPrefabId
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_reviveAltarEntityPrefabId);
			return *(int*)num;
		}
		set
		{
			*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_reviveAltarEntityPrefabId)) = num;
		}
	}

	public unsafe int reviveAltarDesertEntityPrefabId
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_reviveAltarDesertEntityPrefabId);
			return *(int*)num;
		}
		set
		{
			*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_reviveAltarDesertEntityPrefabId)) = num;
		}
	}

	public unsafe int territoryZonePrefabId
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_territoryZonePrefabId);
			return *(int*)num;
		}
		set
		{
			*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_territoryZonePrefabId)) = num;
		}
	}

	static EntityAssetsManager()
	{
		Il2CppClassPointerStore<EntityAssetsManager>.NativeClassPtr = IL2CPP.GetIl2CppClass("Assembly-CSharp.dll", "BAPBAP.Local", "EntityAssetsManager");
		IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<EntityAssetsManager>.NativeClassPtr);
		NativeFieldInfoPtr_spawnPointPrefab = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<EntityAssetsManager>.NativeClassPtr, "spawnPointPrefab");
		NativeFieldInfoPtr_dimensionSpawnPointPrefab = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<EntityAssetsManager>.NativeClassPtr, "dimensionSpawnPointPrefab");
		NativeFieldInfoPtr_tombstonePrefab = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<EntityAssetsManager>.NativeClassPtr, "tombstonePrefab");
		NativeFieldInfoPtr_supplyDropEntityPrefab = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<EntityAssetsManager>.NativeClassPtr, "supplyDropEntityPrefab");
		NativeFieldInfoPtr_reviveAltarEntityPrefab = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<EntityAssetsManager>.NativeClassPtr, "reviveAltarEntityPrefab");
		NativeFieldInfoPtr_reviveAltarDesertEntityPrefab = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<EntityAssetsManager>.NativeClassPtr, "reviveAltarDesertEntityPrefab");
		NativeFieldInfoPtr_itemEntityPrefab = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<EntityAssetsManager>.NativeClassPtr, "itemEntityPrefab");
		NativeFieldInfoPtr_shopItemPingEntityPrefab = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<EntityAssetsManager>.NativeClassPtr, "shopItemPingEntityPrefab");
		NativeFieldInfoPtr_territoryZonePrefab = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<EntityAssetsManager>.NativeClassPtr, "territoryZonePrefab");
		NativeFieldInfoPtr_slimeBossEntityPrefab = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<EntityAssetsManager>.NativeClassPtr, "slimeBossEntityPrefab");
		NativeFieldInfoPtr_itemEntityPrefabId = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<EntityAssetsManager>.NativeClassPtr, "itemEntityPrefabId");
		NativeFieldInfoPtr_shopItemPingEntityPrefabId = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<EntityAssetsManager>.NativeClassPtr, "shopItemPingEntityPrefabId");
		NativeFieldInfoPtr_supplyDropEntityPrefabId = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<EntityAssetsManager>.NativeClassPtr, "supplyDropEntityPrefabId");
		NativeFieldInfoPtr_reviveAltarEntityPrefabId = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<EntityAssetsManager>.NativeClassPtr, "reviveAltarEntityPrefabId");
		NativeFieldInfoPtr_reviveAltarDesertEntityPrefabId = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<EntityAssetsManager>.NativeClassPtr, "reviveAltarDesertEntityPrefabId");
		NativeFieldInfoPtr_territoryZonePrefabId = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<EntityAssetsManager>.NativeClassPtr, "territoryZonePrefabId");
		NativeMethodInfoPtr_PreAwake_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<EntityAssetsManager>.NativeClassPtr, 100684254);
		NativeMethodInfoPtr_GetEntityPrefabFromPrefabId_Public_GameObject_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<EntityAssetsManager>.NativeClassPtr, 100684255);
		NativeMethodInfoPtr_TryGetConfigFromPrefabId_Public_Boolean_Int32_byref_PrefabConfig_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<EntityAssetsManager>.NativeClassPtr, 100684256);
		NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<EntityAssetsManager>.NativeClassPtr, 100684257);
	}

	[CallerCount(0)]
	public unsafe void PreAwake()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_PreAwake_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(3)]
	[CachedScanResults(RefRangeStart = 226208, RefRangeEnd = 226211, XrefRangeStart = 226203, XrefRangeEnd = 226208, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe GameObject GetEntityPrefabFromPrefabId(int prefabId)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = (nint)(&prefabId);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetEntityPrefabFromPrefabId_Public_GameObject_Int32_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<GameObject>(intPtr) : null;
	}

	[CallerCount(4)]
	[CachedScanResults(RefRangeStart = 226221, RefRangeEnd = 226225, XrefRangeStart = 226211, XrefRangeEnd = 226221, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe bool TryGetConfigFromPrefabId(int prefabId, out PrefabConfig config)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[2];
		*ptr = (nint)(&prefabId);
		byte* num = (byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)));
		nint num2 = 0;
		*(nint**)num = &num2;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_TryGetConfigFromPrefabId_Public_Boolean_Int32_byref_PrefabConfig_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		nint num3 = num2;
		config = ((num3 == 0) ? null : new PrefabConfig(num3));
		return *(bool*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	[CallerCount(72)]
	[CachedScanResults(RefRangeStart = 5521, RefRangeEnd = 5593, XrefRangeStart = 5521, XrefRangeEnd = 5593, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe EntityAssetsManager()
		: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<EntityAssetsManager>.NativeClassPtr))
	{
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	public EntityAssetsManager(System.IntPtr pointer)
		: base(pointer)
	{
	}
}
