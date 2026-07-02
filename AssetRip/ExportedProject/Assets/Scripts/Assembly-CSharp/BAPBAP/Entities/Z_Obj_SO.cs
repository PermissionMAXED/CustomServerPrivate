using UnityEngine;

namespace BAPBAP.Entities
{
	[CreateAssetMenu(fileName = "Z_Obj_SO", menuName = "BAPBAP/Game/Z_Obj_SO")]
	public class Z_Obj_SO : ScriptableObject
	{
		public virtual Z_Obj.Z_ObjConfiguration config => null;

		public virtual Z_Obj NewInstance()
		{
			return null;
		}
	}
}
