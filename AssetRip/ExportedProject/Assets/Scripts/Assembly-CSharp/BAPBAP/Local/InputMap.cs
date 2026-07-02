using System;
using UnityEngine;

namespace BAPBAP.Local
{
	[Serializable]
	public class InputMap
	{
		public enum RebindInputResult
		{
			Available = 0,
			AlreadyInUse = 1,
			Invalid = 2
		}

		[NamedArray(typeof(InputTarget), 0)]
		public InputBinding[] inputs;

		public InputBinding GetInputByTarget(InputTarget target)
		{
			return null;
		}

		public InputBinding GetInputByKey(KeyCode key)
		{
			return null;
		}

		public RebindInputResult GetRebindResult(InputBinding toRebind, KeyCode newKey)
		{
			return default(RebindInputResult);
		}

		public void RebindAction(InputBinding toRebind, KeyCode newKey)
		{
		}

		public void SaveAllBinds()
		{
		}

		public void SaveBind(InputBinding inputBind, bool save = true)
		{
		}

		public void LoadAllBinds()
		{
		}

		public void LoadBind(InputBinding inputBind)
		{
		}
	}
}
