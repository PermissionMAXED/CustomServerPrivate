using System;
using BAPBAP.Entities.View;
using BAPBAP.Maps;
using UnityEngine;

namespace LevelEditor
{
	public class EntityDataCostumeHelper : MonoBehaviour, IEditorEntityDataPropertyVisualizer
	{
		[NonSerialized]
		public EntityDataCostume edCostume;

		[SerializeField]
		public string costumeIdIntFieldName;

		public void Awake()
		{
		}

		public void DoRefresh(MapEntityData.Property property)
		{
		}
	}
}
