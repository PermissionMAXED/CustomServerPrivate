using System;
using UnityEngine;
using UnityEngine.UI;

namespace BAPBAP.UI
{
	[RequireComponent(typeof(Image))]
	public class UISpriteAnimator : MonoBehaviour
	{
		public float framerate;

		public bool loopAnimation;

		public bool disableObjOnEnd;

		public bool isTimeScaled;

		[SerializeField]
		public Sprite[] sprites;

		[NonSerialized]
		public Image image;

		[NonSerialized]
		public int index;

		[NonSerialized]
		public float timer;

		public void Awake()
		{
		}

		public void OnEnable()
		{
		}

		public void Update()
		{
		}

		public void SetSpriteFrame()
		{
		}
	}
}
