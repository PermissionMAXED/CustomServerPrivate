using Mirror;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class Tile : NetworkBehaviour
	{
		public LineRenderer[] lineRenderers;

		public virtual void SvTick(float fixedDt)
		{
		}

		public override bool Weaved()
		{
			return false;
		}
	}
}
