using System;
using BAPBAP.Systems;
using UnityEngine;

namespace BAPBAP.Entities
{
	[DisallowMultipleComponent]
	public class CharHidden : MonoBehaviour
	{
		[NonSerialized]
		public EntityManager entityManager;

		[NonSerialized]
		public CharHideArea charHideArea;

		[NonSerialized]
		public CharMaterial charMaterial;

		[NonSerialized]
		public SystemManager systemManager;

		[Header("Configs")]
		[SerializeField]
		[Tooltip("How much to show the character in a bush if its revealed")]
		public float bushRevealDuration;

		[Tooltip("Should this entity get hidden by visibility from fow obstacles?")]
		[SerializeField]
		public bool hideByFow;

		[Tooltip("Should this entity get hidden when outside the camera view?")]
		[SerializeField]
		public bool hideByCameraView;

		[NonSerialized]
		public HiddenState hiddenState;

		[NonSerialized]
		public bool isInBush;

		[NonSerialized]
		public bool isHiddenByAbility;

		[NonSerialized]
		public bool isHiddenByFoW;

		[NonSerialized]
		public bool isHiddenByCameraView;

		[NonSerialized]
		public bool isBushRevealed;

		[NonSerialized]
		public float bushRevealTimer;

		public HiddenState HiddenState => default(HiddenState);

		public bool IsInBush
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool IsHiddenByAbility => false;

		public bool IsHiddenByFoW => false;

		public bool IsHiddenByCameraView => false;

		public bool IsBushRevealed => false;

		public void PreAwake(EntityManager e)
		{
		}

		public void Start()
		{
		}

		public void OnDestroy()
		{
		}

		public void ManagedUpdate()
		{
		}

		public void SetHiddenByHideArea(bool isHidden)
		{
		}

		public void SetHiddenByAbility(bool isHidden)
		{
		}

		public void SetHiddenByVisibility(bool fowHidden, bool outOfCameraView)
		{
		}

		public void RefreshHiddenState()
		{
		}

		public void TriggerBushReveal()
		{
		}

		public void TriggerBushRevealMaterial()
		{
		}

		public bool IsCharHiddenInBush()
		{
			return false;
		}

		public void SetRendererHiddenState(HiddenState hiddenState)
		{
		}

		public void SetCharRendererPartialHidden()
		{
		}

		public void SetCharRendererHidden(bool isHidden)
		{
		}
	}
}
