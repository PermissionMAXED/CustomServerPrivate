using UnityEngine;

namespace BAPBAP.Game.Dimensions
{
	public class D_Obj_Riptide_SO : D_Obj_SO
	{
		[SerializeField]
		public D_Obj_Riptide.Config configuration;

		public override D_Obj.D_ObjConfiguration config => null;

		public override D_Obj NewInstance(Dimension d)
		{
			return null;
		}
	}
}
