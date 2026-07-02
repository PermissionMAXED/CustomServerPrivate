using System.Collections.Generic;

namespace GameAnalyticsSDK.Setup
{
	public class Organization
	{
		public string Name { get; set; }

		public string ID { get; set; }

		public List<Studio> Studios { get; set; }

		public Organization(string name, string id)
		{
		}

		public static string[] GetOrganizationNames(List<Organization> organizations, bool addFirstEmpty = true)
		{
			return null;
		}
	}
}
