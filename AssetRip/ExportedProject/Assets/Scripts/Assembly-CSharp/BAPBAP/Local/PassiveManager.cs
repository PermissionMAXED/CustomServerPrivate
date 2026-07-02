using BAPBAP.Entities;
using UnityEngine;

namespace BAPBAP.Local
{
	public class PassiveManager : MonoBehaviour
	{
		[SerializeField]
		[Expandable]
		public PassiveLibrary library;

		[Header("References")]
		[SerializeField]
		public PassiveSO pagePassive;

		[SerializeField]
		public P_OnUse_ExtraPercentDmg_SO extraPercentDmg;

		[SerializeField]
		[Header("Configs")]
		public string tooltipPassiveHeader;

		public void PreAwake()
		{
		}

		public int GetVfxId(GameObject prefab)
		{
			return 0;
		}

		public Passive NewPassiveInstance(int passiveId, EntityManager entityManager)
		{
			return null;
		}

		public int GetPassiveId(PassiveSO passive)
		{
			return 0;
		}

		public Passive.PassiveConfiguration GetPassiveConfig(int passiveId)
		{
			return null;
		}
	}
}
