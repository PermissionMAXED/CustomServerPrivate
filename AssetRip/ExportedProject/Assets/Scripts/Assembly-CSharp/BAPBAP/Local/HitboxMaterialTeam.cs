using System;
using BAPBAP.Entities;
using UnityEngine;

namespace BAPBAP.Local
{
	public class HitboxMaterialTeam : MonoBehaviour
	{
		public Material matAlly;

		public Material matEnemy;

		public Renderer[] renderers;

		public int materialId;

		[NonSerialized]
		public HitboxBase hitbox;

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
