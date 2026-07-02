using System;

namespace BAPBAP.Entities
{
	public class Z_Obj
	{
		[Serializable]
		public class Z_ObjConfiguration
		{
		}

		public virtual Z_ObjConfiguration dObjConfig => null;

		public virtual void RoundStart()
		{
		}

		public virtual void SvTick(float fixedDt)
		{
		}

		public virtual void EndObjective()
		{
		}
	}
}
