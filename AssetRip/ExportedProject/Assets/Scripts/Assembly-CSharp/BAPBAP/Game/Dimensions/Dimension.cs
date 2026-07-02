using System;
using System.Collections.Generic;
using BAPBAP.Entities;
using BAPBAP.Local;
using BAPBAP.Localisation;
using BAPBAP.UI;
using FMOD.Studio;
using FMODUnity;
using UnityEngine;

namespace BAPBAP.Game.Dimensions
{
	[Serializable]
	public class Dimension
	{
		[Serializable]
		public class DimensionParticleSystem
		{
			[Flags]
			public enum BehaviourSettings
			{
				None = 0,
				SetDimensionRadius = 1,
				SetDimensionScale = 2,
				PlayOnEntityEnter = 4,
				PlayOnEntityExit = 8,
				SetPositionToCollisionPoint = 0x10,
				SetForwardToCollisionDirection = 0x20
			}

			public bool enabled;

			public ParticleSystem particleSystem;

			public BehaviourSettings behaviourSettings;

			[Range(0f, 1f)]
			[Tooltip("How much of the dimension radius is valid for collision detection. 0 = no collision, 1 = full radius coverage.")]
			public float collisionRadiusCoverage;

			[NonSerialized]
			public float _startEmmisionRate;

			public void ScaleEmissionRate(float scale)
			{
			}
		}

		public enum DimensionType
		{
			None = 0,
			SinCity = 1,
			Atlantis = 2,
			Untitled = 3
		}

		public class DimensionCollisionDataHolder
		{
			public EntityManager Entity;

			public DimensionCollisionData Data;

			public bool UpdateData(float deltaTime, float followSpeed, float duration)
			{
				return false;
			}
		}

		public struct DimensionCollisionData
		{
			public Vector4 Position;

			public Vector4 Direction;

			public float Time;

			public float Progress;

			public float pad0;

			public float pad1;

			public float pad2;

			public float pad3;

			public float pad4;

			public float pad5;
		}

		[Header("Shared")]
		[Space]
		public Transform PositionTransform;

		public DimensionBehaviourSO Behaviour;

		public DimensionRendererFeature DimensionsRendererFeature;

		[Header("Visual")]
		[Space]
		public Transform VfxTransform;

		[Tooltip("Used for particles that should not scale with the dimension transform but modify their shape modules by dimension radius or scale")]
		public Transform UnscaledVfxTransform;

		public MeshFilter MeshFilter;

		public MeshRenderer MeshRenderer;

		public Material MaskMaterial;

		public DimensionParticleSystem[] ParticleSystems;

		public float CollisionDuration;

		public float CollisionFollowSpeed;

		public RenderObjectsToTextureFeature GlitchTextureFeature;

		public int FrameCount;

		[Space]
		[Header("Audio")]
		public AudioProximityMusicPlay proximityMusicPlay;

		public AudioProximityMusicPlay proximityMusicPlayCombat;

		public AudioClipData musicIntroAudio;

		public float inCombatMusicTimerDuration;

		public EventReference audioSnapshotEvent;

		[NonSerialized]
		public bool localPlayerIsInCombat;

		[NonSerialized]
		public float localPlayerInCombatTimer;

		[Header("Server / Client")]
		[Space]
		public float ClProcessCharsRate;

		public DimensionDetectCollider triggerCollider;

		[NonSerialized]
		public string displayNameStr;

		public MaterialPropertyBlock DimensionPropertyBlock;

		[NonSerialized]
		public bool movingTransitionDelay;

		[NonSerialized]
		public bool movingStartDelay;

		public List<DimensionCollisionDataHolder> _collisionData;

		[NonSerialized]
		public Vector3 _lastPosition;

		[NonSerialized]
		public Vector3 _positionDelta;

		[NonSerialized]
		public float _positionDeltaSpeed;

		[NonSerialized]
		public float _clProcessCharsTime;

		[NonSerialized]
		public EntityManager _clLocalCharInDimension;

		[NonSerialized]
		public EventInstance _clLocalSnapshotInstance;

		[NonSerialized]
		public UICanvasEffect _uiCanvasEffect;

		[NonSerialized]
		public UIZoneTitle _uiZoneTitle;

		[NonSerialized]
		public bool _hasEntered;

		[NonSerialized]
		public List<EntityManager> _svCharsInDimension;

		[NonSerialized]
		public GameManager _gameManager;

		public DimensionType Id => default(DimensionType);

		public Vector3 Position
		{
			get
			{
				return default(Vector3);
			}
			set
			{
			}
		}

		public float Radius
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public Vector3 Scale
		{
			get
			{
				return default(Vector3);
			}
			set
			{
			}
		}

		public UICanvasEffect UICanvasEffect => null;

		public UIZoneTitle UIZoneTitle => null;

		public GameManager GameManager => null;

		public void UpdatePropertyBlock(Camera cam)
		{
		}

		public bool IsInDimension(Transform transform)
		{
			return false;
		}

		public bool IsInDimension(Vector3 position)
		{
			return false;
		}

		public bool IsNearEdge(Vector3 position, float distFromEdge)
		{
			return false;
		}

		public void Localise(Translator translator)
		{
		}

		public void ClDimensionStart()
		{
		}

		public void ClDimensionEnd()
		{
		}

		public void ClTick(float deltaTime)
		{
		}

		public void UpdateCollisionData(float deltaTime)
		{
		}

		public void ClProcessLocalCharacter()
		{
		}

		public void ClOnLocalCharDimensionEnter(EntityManager entityManager)
		{
		}

		public void ClOnLocalCharDimensionExit(EntityManager entityManager)
		{
		}

		public void ClOnEntityEnter(EntityManager entity)
		{
		}

		public void ClOnEntityExit(EntityManager entity)
		{
		}

		public void HandleEntityParticleEvent(EntityManager entity, DimensionParticleSystem.BehaviourSettings eventSetting)
		{
		}

		public void HandleEntityRendererEvent(EntityManager entity)
		{
		}

		public void AddCollisionData(EntityManager entity)
		{
		}

		public static void SetParticleSystemToEntity(EntityManager entity, ParticleSystem ps)
		{
		}

		public void SetParticleSystemForwardToEntity(EntityManager entity, ParticleSystem ps)
		{
		}

		public bool ValidTriggerDistance(EntityManager entity, DimensionParticleSystem dps)
		{
			return false;
		}

		public bool IsEntityVisible(EntityManager entity, Camera cam)
		{
			return false;
		}

		public void SvDimensionStart()
		{
		}

		public void SvTick(float deltaTime)
		{
		}

		public void SvProcessCharacterZone(DimensionZone zone, EntityManager entityManager)
		{
		}

		public void SvOnEntityEnter(EntityManager entity)
		{
		}

		public void SvOnEntityExit(EntityManager entity)
		{
		}

		public void DrawGizmos()
		{
		}
	}
}
