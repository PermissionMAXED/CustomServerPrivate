using System;
using BAPBAP.Local;
using UnityEngine;

namespace BAPBAP.Entities
{
	[RequireComponent(typeof(EntityTriggerboxListener))]
	public class ReviveAltarProximity : MonoBehaviour
	{
		[NonSerialized]
		public EntityTriggerboxListener triggerboxListener;

		[SerializeField]
		[Header("VFX")]
		public ParticleSystem ghostParticleSystem;

		[SerializeField]
		[Header("SFX")]
		public AudioSource ghostAudioSource;

		[SerializeField]
		public AudioFade ghostAudioFade;

		[NonSerialized]
		public float sfxVolume;

		[NonSerialized]
		public int playerCount;

		[NonSerialized]
		public bool isEnabled;

		public void Awake()
		{
		}

		public void OnEnter(EntityManager entity)
		{
		}

		public void OnExit(EntityManager entity)
		{
		}

		public void PlayFx()
		{
		}

		public void StopFx()
		{
		}
	}
}
