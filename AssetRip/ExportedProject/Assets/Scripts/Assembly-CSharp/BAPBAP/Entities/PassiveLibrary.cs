using UnityEngine;

namespace BAPBAP.Entities
{
	[CreateAssetMenu(fileName = "PassiveLibrary", menuName = "BAPBAP/Passives/PassiveLibrary")]
	public class PassiveLibrary : ScriptableObject
	{
		public const string LIBRARY_PATH = "Assets/Config/Passives/PassiveLibrary.asset";

		public const string LOCAL_PASSIVES_PATH = "Assets/Config/Passives/Content";

		public const string IGNORE_PREFIX = "_";

		[Expandable]
		[SerializeField]
		public PassiveSO[] passives;
	}
}
