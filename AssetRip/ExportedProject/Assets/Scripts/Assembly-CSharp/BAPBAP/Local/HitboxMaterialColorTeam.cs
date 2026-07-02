using System;
using BAPBAP.Entities;
using UnityEngine;

namespace BAPBAP.Local
{
	public class HitboxMaterialColorTeam : MonoBehaviour
	{
		public Color startingColor;

		public float allyColorHue;

		public float enemyColorHue;

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
