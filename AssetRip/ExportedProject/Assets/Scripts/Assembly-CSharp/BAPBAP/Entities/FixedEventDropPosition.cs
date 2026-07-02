using Mirror;

namespace BAPBAP.Entities
{
	public class FixedEventDropPosition : NetworkBehaviour
	{
		public void Start()
		{
		}

		public override bool Weaved()
		{
			return false;
		}
	}
}
