using System;
using UnityEngine;

namespace BAPBAP.Game.Dimensions
{
	public class D_Obj
	{
		[Serializable]
		public class D_ObjConfiguration
		{
			public GameObject obj;
		}

		[NonSerialized]
		public Dimension dimension;

		[NonSerialized]
		public GameObject singleObject;

		public virtual D_ObjConfiguration dObjConfig => null;

		public D_Obj(Dimension dimension)
		{
		}

		public virtual void SvTick(float fixedDt)
		{
		}

		public virtual void SvOnObjectExit(GameObject g)
		{
		}
	}
}
