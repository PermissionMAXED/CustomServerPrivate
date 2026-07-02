using System;
using BAPBAP.Utilities;
using UnityEngine;

namespace BAPBAP.Entities
{
	[Serializable]
	public class AbilityTriggerData
	{
		public Ability ability;

		[Header("Update Rates")]
		[Tooltip("The rate at which the subroutine will try to trigger the ability. Every condition will be checked at this rate per second")]
		public float updateRate;

		[Tooltip("The rate at which the ability will try to trigger based on the random chance condition. The update rate will not affect this timer, but will still affect when this randon chance is checked")]
		public float randomChanceRate;

		[Tooltip("The normalized value to check random chance to trigger the ability. Keeping this at 0 will result in no chance check. The higher this value is, the more likely this ability is to be performed")]
		[Header("Conditions")]
		[Range(0f, 0.99f)]
		public float randomChanceNorm;

		[Tooltip("The rate at which the subroutine will try to trigger the ability")]
		public bool needsLineOfSight;

		[Tooltip("Trigger this attack if distance to target is within this range. Keeping the max at 0 will result in no distance check")]
		public RangeFloat triggerDistRange;

		[Range(0f, 359f)]
		[Tooltip("Min angle difference between this npc's direction to the target to trigger this attack. Keeping this at 0 will result in no angle check")]
		public float minAngleDiff;

		[Header("Settings")]
		[Tooltip("The time from the casting of the ability until the firing of it, used to predict the location of the target by velocity * time. If the time is 0, no prediction will be made")]
		public float futurePredictTime;

		[Tooltip("The amount of random position offset added to the current target location. If 0, no randomness will be added. Spread is added based on world units (value of 1 = random position in a circle with radius of 1 world unit")]
		public float randomSpread;

		[Tooltip("What distance to keep from the target enemy when casting this ability (useful for channeling abilities, for example). If left at 0, it will get this character's default distance to targets")]
		public float keepDistance;

		[Tooltip("Should this ability flip the target direction when triggering it? For example, jumping to the opposite direction from a target")]
		public bool flipDirection;

		[Tooltip("When should this ability set the command position? If false, will set once on enter, if true will set every tick")]
		public bool doOnTick;

		[Tooltip("After casting the ability, have an extra cooldown time before any ability can be triggered again. Useful to making npcs less punishing")]
		[Min(0f)]
		public float extraCd;
	}
}
