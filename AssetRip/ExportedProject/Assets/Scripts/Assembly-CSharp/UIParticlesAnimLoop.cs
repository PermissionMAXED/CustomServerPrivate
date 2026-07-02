using System;
using UnityEngine;
using UnityEngine.UI;

public class UIParticlesAnimLoop : MonoBehaviour
{
	[Serializable]
	public class ParticleLoopAnim
	{
		public Image particleImage;

		public Vector2 starPos;

		public Vector2 endPos;

		public Vector3 startEuler;

		public Vector3 endEuler;

		[NonSerialized]
		public RectTransform particleRect;

		[NonSerialized]
		public float nTimeOffset;

		public void Evaluate(float nTime)
		{
		}
	}

	[SerializeField]
	public ParticleLoopAnim[] particleLoops;

	[Header("Settings")]
	[SerializeField]
	[Min(0.1f)]
	public float loopDuration;

	public void Start()
	{
	}

	public void Update()
	{
	}
}
