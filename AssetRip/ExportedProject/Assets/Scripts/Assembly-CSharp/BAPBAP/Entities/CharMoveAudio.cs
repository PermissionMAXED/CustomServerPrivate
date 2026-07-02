using System;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class CharMoveAudio : MonoBehaviour
	{
		[NonSerialized]
		public EntityManager entityManager;

		[SerializeField]
		public CharAnimator charAnimator;

		[SerializeField]
		public AudioSource audioSource;

		[SerializeField]
		public float volume;

		[SerializeField]
		public float volumeLerpSpeed;

		public void PreAwake(EntityManager e)
		{
		}

		public void Start()
		{
		}

		public void Update()
		{
		}
	}
}
