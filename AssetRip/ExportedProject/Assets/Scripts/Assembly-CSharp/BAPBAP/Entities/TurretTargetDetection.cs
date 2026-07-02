using System;
using BAPBAP.Entities.TargetDetection;
using BAPBAP.UI;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class TurretTargetDetection : BAPBAP.Entities.TargetDetection.TargetDetection
	{
		[Header("Custom Settings")]
		public SpriteRenderer indicatorArea;

		public GameObject indicatorShapeObj;

		[NonSerialized]
		public IShape indicator;

		public Color indicatorBaseColor;

		public Color indicatorTargetingColor;

		public Color indicatorAllyColor;

		public ParticleSystem beamPS;

		public void Awake()
		{
		}

		public override void OnStartServer()
		{
		}

		public override void OnStartClient()
		{
		}

		public override void OnTargetIdChanged(int id)
		{
		}

		public override void OnIsSearchingChanged(bool newValue)
		{
		}

		public override bool Weaved()
		{
			return false;
		}
	}
}
