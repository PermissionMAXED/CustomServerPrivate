using System;
using UnityEngine;

namespace LevelEditor
{
	public class PlaceAnimController : MonoBehaviour
	{
		[Serializable]
		public class PlaceAnimObj
		{
			[Serializable]
			public class Configuration
			{
				public int poolSize;

				public float duration;

				public AnimationCurve heightCurve;

				public AnimationCurve widthCurve;
			}

			public Transform target;

			public bool enabled;

			[NonSerialized]
			public float time;

			[NonSerialized]
			public Configuration config;

			public PlaceAnimObj(Configuration _config)
			{
			}

			public void Initialize(Transform _target)
			{
			}

			public void Update()
			{
			}

			public void OnEnd()
			{
			}
		}

		[SerializeField]
		public PlaceAnimObj.Configuration placeAnimObjConfig;

		[NonSerialized]
		public PlaceAnimObj[] placeAnimObjs;

		[NonSerialized]
		public int lastActiveLength;

		public void Start()
		{
		}

		public void PlayAnimOnTarget(Transform target)
		{
		}

		public void Update()
		{
		}
	}
}
