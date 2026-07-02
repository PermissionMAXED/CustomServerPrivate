using System;
using BAPBAP.Content;
using BAPBAP.Localisation;
using UnityEngine;

namespace BAPBAP.Local
{
	public class TombstoneManager : MonoBehaviour
	{
		[Header("References")]
		[SerializeField]
		public TombstoneData tombstoneData;

		[Header("Config")]
		[SerializeField]
		public string tombstoneRektByTranslationKey;

		[SerializeField]
		public string tombstoneGotRektTranslationKey;

		[NonSerialized]
		public string tombstoneRektByStr;

		[NonSerialized]
		public string tombstoneGotRektStr;

		public void Localise(Translator translator)
		{
		}

		public string BuildTombstoneMessage(string killedName, string killerName)
		{
			return null;
		}

		public Tombstone GetTombstoneByAssetId(int tombstoneAssetId)
		{
			return null;
		}
	}
}
