using System;
using BAPBAP.Utilities;
using UnityEngine;
using UnityEngine.UI;

public class UIParticlesSystemPooled : MonoBehaviour
{
	public class UIParticle
	{
		[Serializable]
		public class Configuration
		{
			public Image particlePrefab;

			[Min(0f)]
			public float ttl;

			public bool prewarm;

			public RangeFloat scaleRange;

			public RangeFloat speedRange;

			[Range(0f, 1f)]
			public float randomDirection;

			public Vector3 eulerVelocityMin;

			public Vector3 eulerVelocityMax;

			public Color color;

			public bool useColorGradient;

			[ConditionalHide("useColorGradient", true)]
			public Gradient colorGradient;
		}

		public class Pool
		{
			[NonSerialized]
			public UIParticlesSystemPooled.Configuration configuration;

			public UIParticle[] particles;

			public Pool(UIParticlesSystemPooled.Configuration _config)
			{
			}

			public bool TrySpawn(out UIParticle entry)
			{
				entry = null;
				return false;
			}

			public void Despawn(UIParticle entry)
			{
			}

			public void Prewarm()
			{
			}

			public Vector2 GetEmitPosition()
			{
				return default(Vector2);
			}

			public Vector2 GetEmitDirection()
			{
				return default(Vector2);
			}
		}

		public GameObject gameObject;

		public Image image;

		public RectTransform rect;

		public float ttl;

		public bool prewarm;

		public Vector2 velocity;

		public Vector3 eulerVelocity;

		public Color color;

		[NonSerialized]
		public Pool pool;

		[NonSerialized]
		public Configuration config;

		[NonSerialized]
		public float time;

		public UIParticle(Image particle, Pool _pool, Configuration _config)
		{
		}

		public void Initialize()
		{
		}

		public void Prewarm(float advanceDT)
		{
		}

		public void Update(float dt)
		{
		}

		public void SetValues(float dt)
		{
		}

		public void Despawn()
		{
		}
	}

	[Serializable]
	public class Configuration
	{
		public int poolSize;

		public Transform parent;

		public RectTransform emitterArea;

		[Min(0f)]
		public float emitRatePerSecond;

		[Space(10f)]
		public UIParticle.Configuration particleConfig;
	}

	[SerializeField]
	[Header("Settings")]
	public Configuration particleSystemConfig;

	[NonSerialized]
	public UIParticle.Pool particlePool;

	[NonSerialized]
	public float emitRateTime;

	public void Awake()
	{
	}

	public void Start()
	{
	}

	public void Update()
	{
	}
}
