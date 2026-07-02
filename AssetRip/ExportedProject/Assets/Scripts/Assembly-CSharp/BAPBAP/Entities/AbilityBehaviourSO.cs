using System;
using UnityEngine;

namespace BAPBAP.Entities
{
	[CreateAssetMenu(fileName = "AbilityBehaviourSO", menuName = "BAPBAP/AbilityBehaviours/AbilityBehaviourSO")]
	public class AbilityBehaviourSO : ScriptableObject
	{
		[NonSerialized]
		public int id;

		public virtual AbilityBehaviour.AbilityBehaviourConfig config => null;

		public virtual AbilityBehaviour NewInstance(EntityManager _entityManager)
		{
			return null;
		}
	}
}
