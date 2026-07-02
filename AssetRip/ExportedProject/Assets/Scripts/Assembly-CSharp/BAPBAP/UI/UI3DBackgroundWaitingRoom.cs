using System;
using BAPBAP.Local;
using FMOD;
using FMOD.Studio;
using FMODUnity;
using UnityEngine;
using UnityEngine.Rendering;

namespace BAPBAP.UI
{
	public class UI3DBackgroundWaitingRoom : UI3DBackground
	{
		[SerializeField]
		public ParallaxTargetController _parallaxTargetController;

		[SerializeField]
		public SelectableController _selectableController;

		[SerializeField]
		public RenderObjectsToTextureFeature _backgroundRenderFeature;

		[SerializeField]
		public Camera _camera;

		[SerializeField]
		public Volume _postProcessingVolume;

		[SerializeField]
		public Light _directionalLight;

		[SerializeField]
		public StudioEventEmitter _fmodEmitter;

		[NonSerialized]
		public bool _onPlayPage;

		[NonSerialized]
		public UIManager _uiManager;

		public static readonly int MusicVolume;

		[NonSerialized]
		public GUID _generalBusGuid;

		[NonSerialized]
		public GUID _musicBusGuid;

		[NonSerialized]
		public Bus _generalBus;

		[NonSerialized]
		public Bus _musicBus;

		[NonSerialized]
		public bool _bussesInitialized;

		public override void Build()
		{
		}

		public void InitializeBusses()
		{
		}

		public override void Update()
		{
		}

		public void SetVolumeShaderProperty()
		{
		}

		public override void SetContentActive(bool active)
		{
		}

		public void ToggleCameras(bool active)
		{
		}

		public void SetBackgrounded(bool backgrounded)
		{
		}

		public void OnDestroy()
		{
		}
	}
}
