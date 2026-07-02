using UnityEngine;

namespace BAPBAP.Game.Dimensions
{
	[CreateAssetMenu(fileName = "D_Obj_SO", menuName = "BAPBAP/Game/Dimension/D_Obj_SO")]
	public class D_Obj_SO : ScriptableObject
	{
		public virtual D_Obj.D_ObjConfiguration config => null;

		public virtual D_Obj NewInstance(Dimension dimension)
		{
			return null;
		}
	}
}
