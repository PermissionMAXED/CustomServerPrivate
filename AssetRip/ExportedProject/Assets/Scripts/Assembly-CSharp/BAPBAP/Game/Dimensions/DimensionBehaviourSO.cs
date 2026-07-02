using System;
using System.Collections.Generic;
using BAPBAP.Entities;
using BAPBAP.Items;
using BAPBAP.UI;
using BAPBAP.Utilities;
using UnityEngine;

namespace BAPBAP.Game.Dimensions
{
	[CreateAssetMenu(fileName = "DimensionBehaviour", menuName = "BAPBAP/Game/Dimensions/DimensionBehaviour")]
	public class DimensionBehaviourSO : ScriptableObject
	{
		[Serializable]
		public class DimensionMaskColor
		{
			public bool Enabled;

			[ColorUsage(false)]
			public Color MaskColor;

			[ColorUsage(false)]
			public Color MaskTargetColor;

			[Range(0f, 1f)]
			public float MaskRange;

			[Range(0f, 1f)]
			public float MaskFuzziness;

			public float MaskMultiplier;
		}

		public struct DimensionData
		{
			public Vector4 Position;

			public float Radius;

			public float Type;

			public float pad0;

			public float pad1;
		}

		public struct DimensionRenderingData
		{
			public float Type;

			public float ApplyLUT;

			public float EnvironmentLUTIndex;

			public float EntityLUTIndex;

			public float EnvironmentMultiplier;

			public float EntityMultiplier;

			public float LuminanceExponent;

			public float IsHalftoneShading;

			public float HalftoneFrequency;

			public float HalftoneRadius;

			public float HalftoneLowerBound;

			public float HalftoneUpperBound;

			public float IsCrossHatchShading;

			public float CrossHatchTextureIndex;

			public float CrossHatchTiling;

			public float CrossHatchFalloff;

			public float CrossHatchingErosionSoftness;

			public float CrossHatchingErosionAmount;

			public float CrossHatchShadowOffset;

			public float CrossHatchShadowSharpness;

			public float CrossHatchHighlightOffset;

			public float CrossHatchHighlightSharpness;

			public float IsRimlit;

			public float RimPower;

			public float RimIntensity;

			public Vector4 RimColor;

			public float IsCaustics;

			public float CausticsTextureIndex;

			public float CausticsIntensity;

			public Vector4 CausticsSpeed;

			public float CausticsTiling;

			public float CausticsAbsorptionRate;

			public float CausticsPower;

			public float CausticsNormalTextureIndex;

			public float CausticsNormalIntensity;

			public Vector4 CausticsNormalSpeed;

			public float CausticsNormalTiling;

			public float IsOffsetShadingThreshold;

			public float OffsetShadingThreshold;

			public float MaskColor1Enabled;

			public Vector4 MaskColor1;

			public Vector4 MaskTargetColor1;

			public float MaskRange1;

			public float MaskFuzziness1;

			public float MaskMultiplier1;

			public float MaskColor2Enabled;

			public Vector4 MaskColor2;

			public Vector4 MaskTargetColor2;

			public float MaskRange2;

			public float MaskFuzziness2;

			public float MaskMultiplier2;

			public float MaskColor3Enabled;

			public Vector4 MaskColor3;

			public Vector4 MaskTargetColor3;

			public float MaskRange3;

			public float MaskFuzziness3;

			public float MaskMultiplier3;

			public float MaskColor4Enabled;

			public Vector4 MaskColor4;

			public Vector4 MaskTargetColor4;

			public float MaskRange4;

			public float MaskFuzziness4;

			public float MaskMultiplier4;

			public float OverrideOutlineColor;

			public Vector4 OutlineColor;

			public float OverrideOutlineWidth;

			public float OutlineWidthMultiplier;

			public float IsSpecular;

			public float SpecularSize;

			public float SpecularSmoothness;

			public float SpecularFalloff;

			public Vector4 SpecularColor;

			public float EntityIsPerRendererColor;

			public float EnvironmentIsPerRendererColor;

			public Vector4 EnvironmentPerRendererColor;

			public float DimensionSkipEntity;

			public float DimensionSkipCharacter;

			public float DimensionSkipGradientHeight;
		}

		[SerializeField]
		public Dimension.DimensionType dimensionId;

		[ExHeader("Visuals", 1f, 1f, 0f)]
		[Header("Rendering")]
		public bool DimensionSkipEntity;

		public bool DimensionSkipCharacter;

		public float DimensionSkipGradientHeight;

		public bool ApplyLUT;

		[ConditionalHide("ApplyLUT", true)]
		[Min(0f)]
		public int EnvironmentLUTIndex;

		[Min(0f)]
		[ConditionalHide("ApplyLUT", true)]
		public int EntityLUTIndex;

		[ConditionalHide("ApplyLUT", true)]
		[Range(0f, 2f)]
		public float EnvironmentMultiplier;

		[ConditionalHide("ApplyLUT", true)]
		[Range(0f, 2f)]
		public float EntityMultiplier;

		public bool EntityIsPerRendererColor;

		public bool EnvironmentIsPerRendererColor;

		[ConditionalHide("EnvironmentIsPerRendererColor", true)]
		public Color EnvironmentPerRendererColor;

		public float LuminanceExponent;

		public bool IsHalftoneShading;

		[ConditionalHide("IsHalftoneShading", true)]
		[Min(0f)]
		public float HalftoneFrequency;

		[Min(0f)]
		[ConditionalHide("IsHalftoneShading", true)]
		public float HalftoneRadius;

		[Range(0f, 1f)]
		[ConditionalHide("IsHalftoneShading", true)]
		public float HalftoneLowerBound;

		[Range(0f, 1f)]
		[ConditionalHide("IsHalftoneShading", true)]
		public float HalftoneUpperBound;

		public bool IsCrossHatchShading;

		[Min(0f)]
		[ConditionalHide("IsCrossHatchShading", true)]
		public int CrossHatchTextureIndex;

		[ConditionalHide("IsCrossHatchShading", true)]
		public float CrossHatchTiling;

		[ConditionalHide("IsCrossHatchShading", true)]
		public float CrossHatchFalloff;

		[Range(0f, 1f)]
		[ConditionalHide("IsCrossHatchShading", true)]
		public float CrossHatchingErosionSoftness;

		[Range(0f, 1f)]
		[ConditionalHide("IsCrossHatchShading", true)]
		public float CrossHatchingErosionAmount;

		[ConditionalHide("IsCrossHatchShading", true)]
		[Range(0f, 1f)]
		public float CrossHatchShadowOffset;

		[Range(0f, 1f)]
		[ConditionalHide("IsCrossHatchShading", true)]
		public float CrossHatchShadowSharpness;

		[ConditionalHide("IsCrossHatchShading", true)]
		[Range(0f, 1f)]
		public float CrossHatchHighlightOffset;

		[ConditionalHide("IsCrossHatchShading", true)]
		[Range(0f, 1f)]
		public float CrossHatchHighlightSharpness;

		public bool IsRimlit;

		[ConditionalHide("IsRimlit", true)]
		public float RimIntensity;

		[ConditionalHide("IsRimlit", true)]
		public float RimPower;

		[ConditionalHide("IsRimlit", true)]
		public Color RimColor;

		public bool IsSpecular;

		[Range(0f, 1f)]
		[ConditionalHide("IsSpecular", true)]
		public float SpecularSize;

		[Range(0f, 1f)]
		[ConditionalHide("IsSpecular", true)]
		public float SpecularSmoothness;

		[Range(0f, 1f)]
		[ConditionalHide("IsSpecular", true)]
		public float SpecularFalloff;

		[ConditionalHide("IsSpecular", true)]
		public Color SpecularColor;

		public bool IsCaustics;

		[ConditionalHide("IsCaustics", true)]
		[Min(0f)]
		public int CausticsTextureIndex;

		[ConditionalHide("IsCaustics", true)]
		[Range(0f, 1f)]
		public float CausticsIntensity;

		[ConditionalHide("IsCaustics", true)]
		public Vector2 CausticsSpeed;

		[ConditionalHide("IsCaustics", true)]
		public float CausticsTiling;

		[ConditionalHide("IsCaustics", true)]
		public float CausticsAbsorptionRate;

		[ConditionalHide("IsCaustics", true)]
		public float CausticsPower;

		[Min(0f)]
		[ConditionalHide("IsCaustics", true)]
		public int CausticsNormalTextureIndex;

		[ConditionalHide("IsCaustics", true)]
		[Range(0f, 1f)]
		public float CausticsNormalIntensity;

		[ConditionalHide("IsCaustics", true)]
		public Vector2 CausticsNormalSpeed;

		[ConditionalHide("IsCaustics", true)]
		public float CausticsNormalTiling;

		public bool IsOffsetShadingThreshold;

		[ConditionalHide("IsOffsetShadingThreshold", true)]
		public float OffsetShadingThreshold;

		public DimensionMaskColor MaskColor1;

		public DimensionMaskColor MaskColor2;

		public DimensionMaskColor MaskColor3;

		public DimensionMaskColor MaskColor4;

		public bool OverrideOutlineColor;

		[ConditionalHide("OverrideOutlineColor", true)]
		[ColorUsage(false)]
		public Color OutlineColor;

		public bool OverrideOutlineWidth;

		[ConditionalHide("OverrideOutlineWidth", true)]
		public float OutlineWidthMultiplier;

		[ExHeader("Gameplay", 1f, 1f, 0f)]
		[SerializeField]
		public GameObject dimensionPrefab;

		[SerializeField]
		[ExHeader("Trail Gameplay", 1f, 1f, 0f)]
		public D_Obj_SO[] objsToSpawn;

		[SerializeField]
		[Header("Passives")]
		public List<PassiveSO> passives;

		[Header("Item Drops")]
		[SerializeField]
		public LootTable[] customLootTables;

		[Header("Behaviour")]
		[SerializeField]
		[Min(0f)]
		public float behaviourStartDelay;

		[SerializeField]
		public int minTransitions;

		[SerializeField]
		public int maxTransitions;

		[SerializeField]
		public RangeFloat behaviourTransitionTime;

		[SerializeField]
		public RangeFloat behaviourDelayTime;

		[Header("Movement")]
		[SerializeField]
		public bool canMove;

		[SerializeField]
		[ConditionalHide("canMove", true)]
		[Range(0f, 1f)]
		public float chanceToMove;

		[ConditionalHide("canMove", true)]
		[SerializeField]
		public RangeFloat minMaxDistanceMultiplier;

		[SerializeField]
		[Space]
		public bool canResize;

		[ConditionalHide("canResize", true)]
		[Range(0f, 1f)]
		[SerializeField]
		public float chanceToResize;

		[ConditionalHide("canResize", true)]
		[SerializeField]
		public RangeFloat minMaxResize;

		[SerializeField]
		public RangeFloat minMaxSize;

		[Header("UI")]
		[SerializeField]
		public string nameTranslationKey;

		[SerializeField]
		public UIMinimapDimension minimapPrefab;

		[SerializeField]
		public Sprite displayIcon;

		[SerializeField]
		[TextArea]
		public string descTranslationKey;

		public void SetMaskColorValues(DimensionMaskColor mask, ref float enabled, ref Vector4 maskColor, ref Vector4 maskTargetColor, ref float maskRange, ref float maskFuzziness, ref float maskMultiplier)
		{
		}

		public DimensionRenderingData GetRenderingData(ref DimensionRenderingData renderingData)
		{
			return default(DimensionRenderingData);
		}
	}
}
