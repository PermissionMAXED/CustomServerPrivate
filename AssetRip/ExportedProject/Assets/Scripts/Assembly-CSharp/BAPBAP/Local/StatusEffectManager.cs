using BAPBAP.Entities;
using BAPBAP.Localisation;
using UnityEngine;

namespace BAPBAP.Local
{
	public class StatusEffectManager : MonoBehaviour
	{
		[Header("Status Effects by Priority")]
		[Expandable]
		[SerializeField]
		public StatusEffectSO[] statusEffects;

		public void PreAwake()
		{
		}

		public void Localise(Translator translator)
		{
		}

		public StatusEffect NewStatusEffectInstance(int statusEffectId, EntityManager entityManager)
		{
			return null;
		}

		public int GetStatusEffectId(StatusEffectSO statusEffect)
		{
			return 0;
		}

		public StatusEffect.StatusEffectConfiguration GetStatusEffectConfig(int statusEffectId)
		{
			return null;
		}
	}
}
