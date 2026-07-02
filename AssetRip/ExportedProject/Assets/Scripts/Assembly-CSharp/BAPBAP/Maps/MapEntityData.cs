using System.Collections.Generic;
using UnityEngine;

namespace BAPBAP.Maps
{
	public class MapEntityData
	{
		public class Property
		{
			public class Field
			{
				public string name;

				public Field(string name)
				{
				}
			}

			public class ReferenceField : Field
			{
				public List<int> instanceIds;

				public ReferenceField(ReferenceField refField)
					: base(null)
				{
				}

				public ReferenceField(string name, IEnumerable<int> instanceIds = null)
					: base(null)
				{
				}
			}

			public class WorldPosField : Field
			{
				public List<Vector2> worldPos;

				public WorldPosField(WorldPosField wpField)
					: base(null)
				{
				}

				public WorldPosField(string name, IEnumerable<Vector2> worldPos = null)
					: base(null)
				{
				}
			}

			public class IntField : Field
			{
				public int value;

				public IntField(string name, int value = 0)
					: base(null)
				{
				}
			}

			public class FloatField : Field
			{
				public float value;

				public FloatField(string name, float value = 0f)
					: base(null)
				{
				}
			}

			public class BoolField : Field
			{
				public bool value;

				public BoolField(string name, bool value = false)
					: base(null)
				{
				}
			}

			public string propertyId;

			public ReferenceField[] fRefInst;

			public WorldPosField[] fWorldPos;

			public IntField[] fInt;

			public FloatField[] fFloat;

			public BoolField[] fBool;

			public Property(Property source)
			{
			}

			public Property(IEntityDataProperty odp)
			{
			}

			public Property(string _propertyId, ReferenceField[] _fRefInst, WorldPosField[] _fWorldPos, IntField[] _fInt, FloatField[] _fFloat, BoolField[] _fBool)
			{
			}

			public void TryParseFields(Property source)
			{
			}

			public List<int> GetRefInstField(string fieldName)
			{
				return null;
			}

			public List<Vector2> GetWorldPosField(string fieldName)
			{
				return null;
			}

			public int GetIntField(string fieldName)
			{
				return 0;
			}

			public float GetFloatField(string fieldName)
			{
				return 0f;
			}

			public bool GetBoolField(string fieldName)
			{
				return false;
			}
		}

		public Property[] properties;

		public MapEntityData()
		{
		}

		public MapEntityData(MapEntityData source)
		{
		}

		public MapEntityData(Property[] properties)
		{
		}
	}
}
