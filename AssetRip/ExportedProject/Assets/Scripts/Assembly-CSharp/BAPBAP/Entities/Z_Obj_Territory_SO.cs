using UnityEngine;

namespace BAPBAP.Entities
{
	public class Z_Obj_Territory_SO : Z_Obj_SO
	{
		[SerializeField]
		public Z_Obj_Territory.Config configuration;

		public override Z_Obj.Z_ObjConfiguration config => null;

		public override Z_Obj NewInstance()
		{
			return null;
		}
	}
}
