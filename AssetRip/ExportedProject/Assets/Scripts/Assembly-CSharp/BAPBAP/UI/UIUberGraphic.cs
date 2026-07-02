using System;
using UnityEngine;
using UnityEngine.UI;

namespace BAPBAP.UI
{
	public class UIUberGraphic : Image
	{
		public struct Matrix2x3
		{
			[NonSerialized]
			public float m00;

			[NonSerialized]
			public float m01;

			[NonSerialized]
			public float m02;

			[NonSerialized]
			public float m10;

			[NonSerialized]
			public float m11;

			[NonSerialized]
			public float m12;

			public Matrix2x3(float m00, float m01, float m02, float m10, float m11, float m12)
			{
				this.m00 = 0f;
				this.m01 = 0f;
				this.m02 = 0f;
				this.m10 = 0f;
				this.m11 = 0f;
				this.m12 = 0f;
			}

			public static Vector2 operator *(Matrix2x3 m, Vector2 v)
			{
				return default(Vector2);
			}
		}

		[SerializeField]
		public UIUberGraphicEventHandler eventHandler;

		[Min(0f)]
		[SerializeField]
		public float transitionDuration;

		[SerializeField]
		public AnimationCurve transitionCurve;

		[SerializeField]
		public UberSDF[] sdfs;

		[SerializeField]
		public bool sampleSoft;

		[SerializeField]
		public float softness;

		[SerializeField]
		public float outlineSize;

		[SerializeField]
		public Color32 outlineColor;

		[SerializeField]
		public bool outlineKnockout;

		[SerializeField]
		public bool sampleOutlineSoft;

		[SerializeField]
		public float outlineSoftness;

		[SerializeField]
		public Vector2 shadowOffset;

		[SerializeField]
		public Color color1;

		[SerializeField]
		public Color color2;

		[SerializeField]
		public float gradientAngle;

		[SerializeField]
		public float margin;

		[SerializeField]
		public Vector2 uvOffset;

		[SerializeField]
		public Vector2 uvScale;

		[SerializeField]
		public Vector2 sdfUVScale;

		[NonSerialized]
		public Material instanceMaterial;

		public static readonly int MainTex;

		[NonSerialized]
		public UIUberGraphicSO targetGraphic;

		[NonSerialized]
		public float transitionTime;

		public static readonly Vector4[] EmptyPolygons;

		public override Material defaultMaterial => null;

		public override Material GetModifiedMaterial(Material baseMaterial)
		{
			return null;
		}

		public override void OnEnable()
		{
		}

		public override void OnDisable()
		{
		}

		public void SubscribeToDescriptors()
		{
		}

		public void UnsubscribeFromDescriptors()
		{
		}

		public void SubscribeToEventHandlers()
		{
		}

		public void UnsubscribeFromEventHandlers()
		{
		}

		public void HandlerRefresh()
		{
		}

		public void SetFromSO(UIUberGraphicSO graphicSO)
		{
		}

		public void OnDescriptorChanged()
		{
		}

		public override void Start()
		{
		}

		public override void OnDestroy()
		{
		}

		public void Update()
		{
		}

		public override void OnPopulateMesh(VertexHelper vh)
		{
		}

		public override void OnAfterDeserialize()
		{
		}

		public override void SetVerticesDirty()
		{
		}

		public override void SetMaterialDirty()
		{
		}

		public void SetBaseData(ref Material currentMat, UberSDF[] descriptors)
		{
		}

		public void SetSDFData(ref Material baseMaterial, UberSDF[] descriptors)
		{
		}

		public void SetAnimatedSDFMatrix(ref Material baseMaterial, int i, UberSDF[] descriptors)
		{
		}

		public new Vector4 GetDrawingDimensions(bool shouldPreserveAspect)
		{
			return default(Vector4);
		}

		public new void PreserveSpriteAspectRatio(ref Rect rect, Vector2 spriteSize)
		{
		}

		public Matrix2x3 LocalPositionMatrix(Rect rect, Vector2 dir)
		{
			return default(Matrix2x3);
		}

		public Vector2 RotationDir(float angle)
		{
			return default(Vector2);
		}
	}
}
