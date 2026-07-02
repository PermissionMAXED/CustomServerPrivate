using System.Collections.Generic;
using Dreamteck.Splines;
using UnityEngine;

[CreateAssetMenu(fileName = "SplineMeshChannelCollection", menuName = "LevelEditor/SplineMeshChannelCollection", order = 1)]
public class SplineMeshChannelCollection : ScriptableObject
{
	public List<SplineMesh.Channel> channels;
}
