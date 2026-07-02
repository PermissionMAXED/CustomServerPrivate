using System;
using BAPBAP.Entities;
using TMPro;
using UnityEngine;

namespace BAPBAP
{
	public class TrainingAreaInputDisplay : MonoBehaviour
	{
		[SerializeField]
		public TMP_Text trainingInputTextPrefab;

		[NonSerialized]
		public string inputStr;

		[NonSerialized]
		public TMP_Text trainingInputText;

		public void Awake()
		{
		}

		public void OnDestroy()
		{
		}

		public void Enable(EntityManager entityManager)
		{
		}

		public void Disable(EntityManager entityManager)
		{
		}

		public void Update()
		{
		}

		public string TrimLines(string input, int maxLines)
		{
			return null;
		}
	}
}
