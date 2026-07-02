using System;
using UnityEngine;

namespace BAPBAP.Entities
{
	[CreateAssetMenu(fileName = "PassiveSO", menuName = "BAPBAP/Passives/PassiveSO")]
	public class PassiveSO : ScriptableObject
	{
		[NonSerialized]
		public int id;

		public virtual Passive.PassiveConfiguration config => null;

		public virtual Passive NewInstance(EntityManager _entityManager)
		{
			return null;
		}
	}
}
