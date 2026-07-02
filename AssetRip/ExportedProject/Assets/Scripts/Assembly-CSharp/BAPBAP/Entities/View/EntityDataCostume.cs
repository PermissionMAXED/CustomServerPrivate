using System;
using System.Runtime.InteropServices;
using BAPBAP.Maps;
using Mirror;
using UnityEngine;

namespace BAPBAP.Entities.View
{
	public class EntityDataCostume : NetworkBehaviour, IEntityDataProperty
	{
		[Serializable]
		public class CostumeSet
		{
			[ObjectReferencesToString("costumePieces", true, true)]
			public string name;

			public Renderer[] costumePieces;
		}

		[NonSerialized]
		public CharMaterial charMaterial;

		[SerializeField]
		public CostumeSet[] costumes;

		[SyncVar]
		[SerializeField]
		public short costumeIndex;

		public short NetworkcostumeIndex
		{
			get
			{
				return 0;
			}
			[param: In]
			set
			{
			}
		}

		public override void OnValidate()
		{
		}

		public void Awake()
		{
		}

		public override void OnStartClient()
		{
		}

		public void WearCostume(int costumeIndex)
		{
		}

		public virtual string PropertyName()
		{
			return null;
		}

		public MapEntityData.Property.Field[] GetPropertyFields()
		{
			return null;
		}

		public void CopyProperties(IEntityDataProperty _source)
		{
		}

		public override bool Weaved()
		{
			return false;
		}

		public override void SerializeSyncVars(NetworkWriter writer, bool forceAll)
		{
		}

		public override void DeserializeSyncVars(NetworkReader reader, bool initialState)
		{
		}
	}
}
