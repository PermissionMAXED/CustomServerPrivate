using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

[ExecuteAlways]
public sealed class VolumeComponentUpdater : MonoBehaviour
{
	[NonSerialized]
	public VolumeStack previousStack;

	[NonSerialized]
	public Dictionary<Type, VolumeComponent> cachedVolumeStackComponents;

	public void LateUpdate()
	{
	}
}
