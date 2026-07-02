using System.Collections.Generic;

namespace BAPBAP.Maps
{
	public struct ModuleTypeList
	{
		public List<string> poiModules;

		public Dictionary<string, List<string>> poiThemedModules;

		public List<string> landmarkModules;

		public List<string> reviveModules;

		public List<string> genericLargeModules;

		public List<string> genericMediumModules;

		public List<string> genericSmallModules;

		public ModuleTypeList(ModuleTypeList moduleTypeList)
		{
			poiModules = null;
			poiThemedModules = null;
			landmarkModules = null;
			reviveModules = null;
			genericLargeModules = null;
			genericMediumModules = null;
			genericSmallModules = null;
		}
	}
}
