using System;
using System.Collections.Generic;
using UnityEngine;

namespace BAPBAP.Maps
{
	public class CeilingGroupManager : MonoBehaviour
	{
		public class CeilingGroup
		{
			[NonSerialized]
			public CeilingGroupManager ceilingGroupManager;

			public bool isLerping;

			public List<CeilingGroupController> ceilingControllers;

			public Dictionary<Material, Material> materialInstances;

			public float elapsedTime;

			public bool hidden;

			public CeilingGroup(CeilingGroupManager ceilingGroupManager)
			{
			}

			public void Update()
			{
			}

			public void FadeIn()
			{
			}

			public void FadeOut()
			{
			}

			public void SetGroupAlpha(float alphaValue)
			{
			}
		}

		[SerializeField]
		[Header("Settings")]
		public float fadeDuration;

		public Dictionary<int, CeilingGroup> ceilingGroupsById;

		public void Awake()
		{
		}

		public void RegisterCeilingGroup(int ceilingGroupId, CeilingGroupController ceilingGroupController)
		{
		}

		public void OnCeilingGroupEnter(int groupId)
		{
		}

		public void OnCeilingGroupExit(int groupId)
		{
		}

		public void Update()
		{
		}
	}
}
