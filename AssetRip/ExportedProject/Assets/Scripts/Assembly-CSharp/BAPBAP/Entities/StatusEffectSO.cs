using System;
using UnityEngine;

namespace BAPBAP.Entities
{
	[CreateAssetMenu(fileName = "StatusEffectSO", menuName = "BAPBAP/StatusEffects/StatusEffectSO")]
	public class StatusEffectSO : ScriptableObject
	{
		[NonSerialized]
		public int id;

		public virtual StatusEffect.StatusEffectConfiguration config => null;

		public virtual StatusEffect NewInstance(EntityManager em)
		{
			return null;
		}
	}
}
