using Mirror;

namespace BAPBAP.Entities
{
	public class EntityActivateSocketPushable : EntityActivateBase
	{
		[Server]
		public override void Activate()
		{
		}

		public override bool Weaved()
		{
			return false;
		}
	}
}
