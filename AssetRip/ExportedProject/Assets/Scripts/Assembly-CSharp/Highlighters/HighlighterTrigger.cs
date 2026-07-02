using System;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Highlighters
{
	public class HighlighterTrigger : MonoBehaviour
	{
		public enum TriggerMode
		{
			ObjectEnterVolume = 0,
			CameraRaycast = 1,
			CustomEvents = 2
		}

		public delegate void TriggeringEnd();

		public delegate void TriggeringStart();

		public delegate void Hit();

		[Tooltip("ObjectEnterVolume: detects the triggering state of the object collider.CameraRaycast: creates a ray from the camera that triggers the highlighter when the ray hits it.CustomEvents: use when you use a custom triggering script.")]
		public TriggerMode TriggeringMode;

		[NonSerialized]
		public Collider myCollider;

		[SerializeField]
		public LayerMask volumeLayerMask;

		[SerializeField]
		public Camera myCamera;

		[SerializeField]
		public float maxDistanceFromCamera;

		[SerializeField]
		public bool drawDebugLine;

		[SerializeField]
		public bool isCurrentlyTriggeredDebug;

		[NonSerialized]
		public bool isCurrentlyTriggered;

		public bool IsCurrentlyTriggered => false;

		public event TriggeringEnd OnTriggeringEnded
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event TriggeringStart OnTriggeringStarted
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Hit OnHitTrigger
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public void TriggeringEnded()
		{
		}

		public void TriggeringStarted()
		{
		}

		public void HitTrigger()
		{
		}

		public void ChangeTriggeringState(bool isTriggered)
		{
		}

		public void TriggerHit()
		{
		}

		public void Update()
		{
		}

		public void OnTriggerEnter(Collider other)
		{
		}

		public void OnTriggerStay(Collider other)
		{
		}

		public void OnTriggerExit(Collider other)
		{
		}

		public void cameraTrigger()
		{
		}

		public void updateTriggeringState(bool currenlyTriggered)
		{
		}

		public void TestTriggeringStarted()
		{
		}

		public void TestTriggeringEnded()
		{
		}
	}
}
