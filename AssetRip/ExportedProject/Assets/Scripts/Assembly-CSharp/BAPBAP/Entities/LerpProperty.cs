using System;
using UnityEngine;

namespace BAPBAP.Entities
{
	[Serializable]
	public class LerpProperty
	{
		public enum PropertyTypes
		{
			Float = 0,
			Color = 1,
			Vector = 2,
			Texture = 3
		}

		public enum Mode
		{
			LerpToTarget = 0,
			LerpAlongCurve = 1
		}

		public enum PropertyOnAwake
		{
			DoNothing = 0,
			SetToStartMoment = 1,
			SetToEndMoment = 2
		}

		public string Name;

		public bool IsActive;

		public int Finishes;

		public bool OnlyOnce;

		public bool NullBlockOnActivate;

		public bool AllowActivateWhileActive;

		public PropertyOnAwake OnAwake;

		[SerializeField]
		public PropertyTypes _propertyType;

		[SerializeField]
		public Mode _mode;

		[SerializeField]
		[ConditionalEnumHide("_propertyType", 0, true)]
		public AnimationCurve _floatCurve;

		[ConditionalEnumHide("_propertyType", 1, true)]
		[SerializeField]
		public Gradient _colorCurve;

		[ConditionalEnumHide("_propertyType", 2, true)]
		[SerializeField]
		public AnimationCurve _vectorCurveX;

		[ConditionalEnumHide("_propertyType", 2, true)]
		[SerializeField]
		public AnimationCurve _vectorCurveY;

		[ConditionalEnumHide("_propertyType", 2, true)]
		[SerializeField]
		public AnimationCurve _vectorCurveZ;

		[ConditionalEnumHide("_propertyType", 2, true)]
		[SerializeField]
		public AnimationCurve _vectorCurveW;

		[ConditionalEnumHide("_mode", 0, true)]
		[SerializeField]
		public float _floatTarget;

		[ConditionalEnumHide("_mode", 0, true)]
		[SerializeField]
		public Color _colorTarget;

		[ConditionalEnumHide("_mode", 0, true)]
		[SerializeField]
		public Vector4 _vectorTarget;

		[ConditionalEnumHide("_mode", 0, true)]
		[SerializeField]
		public Texture2D _textureTarget;

		[ConditionalEnumHide("_mode", 0, true)]
		[SerializeField]
		public Texture2D _startTexture;

		[Min(0f)]
		public float Duration;

		[NonSerialized]
		public float _elapsedTime;

		[NonSerialized]
		public float _startFloat;

		[NonSerialized]
		public Color _startColor;

		[NonSerialized]
		public Vector4 _startVector;

		[NonSerialized]
		public Action _onFinish;

		public void SetAction(Action action)
		{
		}

		public void InitializeProperty()
		{
		}

		public void Awake(MaterialPropertyBlock block)
		{
		}

		public bool CanActivate()
		{
			return false;
		}

		public void ResetState()
		{
		}

		public bool UpdateProperty(float elapsedTime)
		{
			return false;
		}

		public void ClUpdatePropertyAtMoment(MaterialPropertyBlock block, float moment)
		{
		}

		public void ClFinishProperty(MaterialPropertyBlock block)
		{
		}

		public void UpdatePropertyAtMoment(MaterialPropertyBlock block, float moment)
		{
		}

		public void ResetProperty(MaterialPropertyBlock block)
		{
		}

		public void CopyTo(LerpProperty target)
		{
		}
	}
}
