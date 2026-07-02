using System;
using BAPBAP.Utilities;
using Mirror;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class AudioPlayRandomIntervalsSynced : NetworkBehaviour
	{
		[SerializeField]
		[Header("References")]
		public AudioSource audioSource;

		[SerializeField]
		[Header("Clips")]
		public AudioClip[] clips;

		[SerializeField]
		[Header("Settings")]
		public bool playOnEnable;

		[SerializeField]
		[Tooltip("Only allow to play one clip at a time. If enabled, wont play until the current clip has finished playing.")]
		public bool onlyPlayAtOnce;

		[SerializeField]
		[Tooltip("Play the clips in sequential order, with a random start point")]
		public bool randomSequentialClips;

		[SerializeField]
		public RangeFloat randomIntervals;

		[SerializeField]
		public float pitchSpread;

		[NonSerialized]
		public int randomClipId;

		[NonSerialized]
		public float currentInterval;

		[NonSerialized]
		public float timer;

		[NonSerialized]
		public float originalPitch;

		public void Awake()
		{
		}

		public void Start()
		{
		}

		public void OnEnable()
		{
		}

		[ServerCallback]
		public void Update()
		{
		}

		[ClientRpc]
		public void RpcPlay(int clipId)
		{
		}

		public float GetRandomIntervalDuration()
		{
			return 0f;
		}

		public override bool Weaved()
		{
			return false;
		}

		public void UserCode_RpcPlay__Int32(int clipId)
		{
		}

		public static void InvokeUserCode_RpcPlay__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		static AudioPlayRandomIntervalsSynced()
		{
		}
	}
}
