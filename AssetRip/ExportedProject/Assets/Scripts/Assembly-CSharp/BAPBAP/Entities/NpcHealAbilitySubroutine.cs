using BAPBAP.Local;

namespace BAPBAP.Entities
{
	public class NpcHealAbilitySubroutine : NpcCastAbilitySubroutine
	{
		public NpcHealAbilitySubroutine(NpcBehaviour _npcBehaviour, AbilityTriggerData abilityData, byte _trigger, float _aimRotationSpeed = -2f)
			: base((NpcBehaviour)null, (AbilityTriggerData)null, (byte)0, 0f)
		{
		}

		public override void OnEnter(float fixedDt, Command cmd, bool isResim)
		{
		}
	}
}
