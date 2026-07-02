using System;
using UnityEngine;
using UnityEngine.Rendering;

namespace BAPBAP.Local
{
	public class CameraManager : MonoBehaviour
	{
		[NonSerialized]
		public Camera mainCamera;

		[NonSerialized]
		public CameraController camController;

		[NonSerialized]
		public CameraShake camShake;

		[NonSerialized]
		public CameraDepthTextureMode camDepthTextureMode;

		[NonSerialized]
		public Volume postProcessingVolume;

		[NonSerialized]
		public DynamicChunkLoader dynamicChunkLoader;

		[NonSerialized]
		public Ambience2DController ambience2DController;

		[NonSerialized]
		public ProximityMusicController proximityMusicController;

		[SerializeField]
		public FogOfWarController fowController;

		[SerializeField]
		public EntityVisibility entityVisibility;

		[SerializeField]
		public AudioListener audioListener;

		[SerializeField]
		public GameObject focusPoint;

		public static CameraManager Instance;

		public void PreAwake()
		{
		}
	}
}
