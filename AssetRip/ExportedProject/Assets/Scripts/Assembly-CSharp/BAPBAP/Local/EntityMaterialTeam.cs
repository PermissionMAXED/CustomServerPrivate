using System;
using BAPBAP.Entities;
using UnityEngine;

namespace BAPBAP.Local
{
	public class EntityMaterialTeam : MonoBehaviour
	{
		public Material matAlly;

		public Material matEnemy;

		public Renderer[] renderers;

		public int materialId;

		[NonSerialized]
		public EntityManager entityManager;

		public void Awake()
		{
		}

		public void Start()
		{
		}

		public void SetTeamColor(int teamId)
		{
		}
	}
}
