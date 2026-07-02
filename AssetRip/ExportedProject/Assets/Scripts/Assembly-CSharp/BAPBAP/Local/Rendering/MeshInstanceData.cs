using System.Collections.Generic;
using UnityEngine;

namespace BAPBAP.Local.Rendering
{
	[CreateAssetMenu(fileName = "MeshInstanceData", menuName = "Rendering/InstancingSystem/Mesh Instance Data", order = 0)]
	public class MeshInstanceData : ScriptableObject
	{
		public List<MeshInstanceRenderer.DefinitionPositions> definitionDatas;

		public void AddDefinitionData(MeshInstanceRenderer.DefinitionPositions definitionPositions)
		{
		}
	}
}
