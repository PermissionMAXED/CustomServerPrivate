using System;
using UnityEngine;

namespace BAPBAP.Local
{
	public class VFXTeamColor : MonoBehaviour
	{
		[NonSerialized]
		public int teamId;

		[SerializeField]
		[Header("Settings")]
		public float allyColorHue;

		[SerializeField]
		public float enemyColorHue;

		[Header("Vfx Elements")]
		[SerializeField]
		public ParticleSystem[] ps;

		[SerializeField]
		public ParticleSystem[] psTrail;

		[SerializeField]
		public TrailRenderer[] tr;

		[SerializeField]
		public MeshRenderer mr;

		[SerializeField]
		public SpriteRenderer sr;

		[SerializeField]
		public ParticleSystemRenderer[] PSRend;

		public void OnStart(int _teamId)
		{
		}

		public void SetTeamColor()
		{
		}
	}
}
