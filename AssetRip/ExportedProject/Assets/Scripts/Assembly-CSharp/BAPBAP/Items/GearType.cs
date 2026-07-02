using System;
using BAPBAP.Local;
using UnityEngine;

namespace BAPBAP.Items
{
	[CreateAssetMenu(fileName = "GearType", menuName = "BAPBAP/Items/GearType")]
	public class GearType : ScriptableObject
	{
		[SerializeField]
		public GearSlot slot;

		[NonSerialized]
		public int id;
	}
}
