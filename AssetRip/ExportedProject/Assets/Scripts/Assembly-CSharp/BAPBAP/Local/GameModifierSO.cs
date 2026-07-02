using System;
using UnityEngine;

namespace BAPBAP.Local
{
	[CreateAssetMenu(fileName = "GameModifierSO", menuName = "BAPBAP/GameModifiers/GameModifierSO")]
	public class GameModifierSO : ScriptableObject
	{
		[NonSerialized]
		public int id;

		public virtual GameModifier.GameModifierConfiguration config => null;

		public virtual GameModifier NewInstance()
		{
			return null;
		}
	}
}
