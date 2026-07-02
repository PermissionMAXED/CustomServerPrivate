using System;
using UnityEngine;

namespace BAPBAP.Systems
{
	public class SystemManager : MonoBehaviour
	{
		[NonSerialized]
		public PlayerSystem playerSystem;

		[NonSerialized]
		public HpBarSystem hpBarSystem;

		[NonSerialized]
		public EntityNetworkSystem entityNetworkSystem;

		[NonSerialized]
		public EntityMaterialSystem entityMaterialSystem;

		[NonSerialized]
		public EntityAnimatorSystem entityAnimatorSystem;

		[NonSerialized]
		public EntityBushInteractSystem entityBushInteractSystem;

		[NonSerialized]
		public EntityFootstepsSystem entityFootstepsSystem;

		[NonSerialized]
		public EntityHiddenSystem entityHiddenSystem;

		[NonSerialized]
		public EntityInterpolatorSystem entityInterpolatorSystem;

		[NonSerialized]
		public EntityMinimapSystem entityMinimapSystem;

		[NonSerialized]
		public EntityWorldPositionSystem entityWorldPositionSystem;

		[NonSerialized]
		public EntityStatusEffectSystem entityStatusEffectSystem;

		public static SystemManager Instance;

		public void PreAwake()
		{
		}
	}
}
