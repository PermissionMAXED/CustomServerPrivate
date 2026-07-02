using System;
using System.Collections.Generic;
using BAPBAP.Entities;
using UnityEngine;

namespace BAPBAP.Local
{
	public class AimAssistDetection : MonoBehaviour
	{
		public class Target
		{
			public enum Type
			{
				Char = 0,
				Npc = 1,
				Loot = 2,
				Obj = 3
			}

			public readonly int id;

			public readonly Type type;

			public readonly EntityManager @char;

			public bool hidden;

			public bool invincible;

			public bool downed;

			[NonSerialized]
			public Vector3 position;

			public Vector3 Position => default(Vector3);

			public Target(int id, Type type, EntityManager @char)
			{
			}
		}

		[NonSerialized]
		public SphereCollider sphereCollider;

		[NonSerialized]
		public Dictionary<int, Target> lookup;

		[NonSerialized]
		public List<Target> list;

		[NonSerialized]
		public List<Target> disposed;

		public List<Target> Targets => null;

		public void SetRange(float range)
		{
		}

		public void Awake()
		{
		}

		public void Update()
		{
		}

		public bool TryGetPlayerPosition(out Vector3 position)
		{
			position = default(Vector3);
			return false;
		}

		public void OnTriggerEnter(Collider other)
		{
		}

		public void OnTriggerExit(Collider other)
		{
		}

		public bool IsValidTarget(EntityManager @char)
		{
			return false;
		}

		public Target.Type GetTargetType(EntityManager @char)
		{
			return default(Target.Type);
		}
	}
}
