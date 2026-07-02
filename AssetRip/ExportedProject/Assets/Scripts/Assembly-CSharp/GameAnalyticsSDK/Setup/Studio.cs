using System.Collections.Generic;

namespace GameAnalyticsSDK.Setup
{
	public class Studio
	{
		public string Name { get; set; }

		public string ID { get; set; }

		public string OrganizationID { get; set; }

		public List<Game> Games { get; set; }

		public Studio(string name, string id, string orgId, List<Game> games)
		{
		}

		public static string[] GetStudioNames(List<Studio> studios, bool addFirstEmpty = true)
		{
			return null;
		}

		public static string[] GetGameNames(int index, List<Studio> studios)
		{
			return null;
		}
	}
}
