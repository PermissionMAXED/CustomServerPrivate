using System;
using BAPBAP.Entities;
using UnityEngine;

namespace BAPBAP.Local
{
	public class LocalMaterialColorTeam : MonoBehaviour
	{
		[NonSerialized]
		public EntityManager entityManager;

		public Color allyColor;

		public Color enemyColor;

		public Renderer[] renderers;

		public int materialId;

		public void Start()
		{
		}

		public void SetTeamColor(int teamId)
		{
		}
	}
}
