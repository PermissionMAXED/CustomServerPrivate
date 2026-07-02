using System;
using BAPBAP.Local;

namespace BAPBAP.Entities
{
	public class CmdBufferSystem
	{
		[NonSerialized]
		public Ability[] abilities;

		public CmdBufferSystem(Ability[] _abilities)
		{
		}

		public void TickBuffers(float fixedDt, Command cmd)
		{
		}
	}
}
