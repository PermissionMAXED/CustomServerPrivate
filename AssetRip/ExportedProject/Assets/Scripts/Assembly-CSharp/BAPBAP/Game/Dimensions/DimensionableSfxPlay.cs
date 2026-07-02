using System;
using BAPBAP.Local;
using UnityEngine;

namespace BAPBAP.Game.Dimensions
{
	public class DimensionableSfxPlay : Dimensionable
	{
		[Serializable]
		public new class DimensionInfo : Dimensionable.DimensionInfo
		{
			[Space(5f)]
			public GameObject originalSourceHide;

			public AudioClipData audioClipData;

			public bool is2DAudio;

			public Mixer mixer;
		}

		[SerializeField]
		public DimensionInfo[] dimensionInfo;

		public override void ClOnDimensionEnter(int dimensionId)
		{
		}

		public override void ClOnDimensionExit(int dimensionId)
		{
		}

		public void PlayDimensionAudio(DimensionInfo info)
		{
		}

		public override void SvOnDimensionEnter(int dimensionId)
		{
		}

		public override void SvOnDimensionExit(int dimensionId)
		{
		}
	}
}
