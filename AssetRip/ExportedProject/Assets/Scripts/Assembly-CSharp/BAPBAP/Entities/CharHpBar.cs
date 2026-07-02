using System;
using System.Text;
using BAPBAP.Local;
using BAPBAP.Network;
using BAPBAP.UI;
using Mirror;
using UnityEngine;

namespace BAPBAP.Entities
{
	[DisallowMultipleComponent]
	public class CharHpBar : NetworkBehaviour, INetworkPredicted
	{
		[NonSerialized]
		public EntityManager entityManager;

		[NonSerialized]
		public CharHurtbox charHurtbox;

		[NonSerialized]
		public CharMaterial charMaterial;

		[NonSerialized]
		public UIManager uiManager;

		[SerializeField]
		[Tooltip("Set a custom hp bar prefab for this character to use. If null, will get the default hp bar from UIManager")]
		public UIManager.HpBarType hpBarType;

		[SerializeField]
		public float worldHeight;

		[SerializeField]
		[Tooltip("Should the ui hp bar name text display this character's hp instead?")]
		public bool displayHpAsName;

		[SerializeField]
		[Tooltip("If the character is invincible, should the hp bar get hidden?")]
		public bool hideOnInvincible;

		[SerializeField]
		[Tooltip("If provided, the hp bar will be following this transform instead of the root of the entity")]
		public Transform customFollowTarget;

		[NonSerialized]
		public UIHpBar currentHpBar;

		[NonSerialized]
		public bool isDestroyed;

		[NonSerialized]
		public byte hideLocks;

		public bool HideOnInvincible => false;

		public byte HideLocks => 0;

		public UIHpBar CurrentHpBar => null;

		public void PreAwake(EntityManager e)
		{
		}

		public override void OnStartClient()
		{
		}

		public void OnTick(float fixedDt, Command cmd, bool isResim)
		{
		}

		public void OnDestroy()
		{
		}

		public void AddHideBarLock()
		{
		}

		public void RemoveHideBarLock()
		{
		}

		public void ClUpdateHpBarHiddenState()
		{
		}

		public void OnHideHpBarChanged()
		{
		}

		public void OnHpShieldChanged(int hp, int maxHp, int shield, int maxShield)
		{
		}

		public void OnNetDeserialize(NetworkReader netReader)
		{
		}

		public void OnNetSerialize(NetworkWriter netWriter)
		{
		}

		public bool OnNetDebugCompare(NetworkReader netReader)
		{
			return false;
		}

		public void OnNetDebugLog(StringBuilder sb)
		{
		}

		public override bool Weaved()
		{
			return false;
		}
	}
}
