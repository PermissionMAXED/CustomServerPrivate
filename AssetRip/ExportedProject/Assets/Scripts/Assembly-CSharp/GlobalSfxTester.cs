using BAPBAP.Local;
using UnityEngine;

public class GlobalSfxTester : MonoBehaviour
{
	[SerializeField]
	public AudioClipData sfxData;

	[SerializeField]
	[Tooltip("Multiplier for audio source range. It will multiply min and max by this value")]
	public float sfxCastGlobalDistMult;

	[Tooltip("Sets the minimum distance for the audio source to the given value. Its still affected by the multiplier")]
	[SerializeField]
	public float sfxCastGlobalMinDist;

	[InspectorButton("OnPlaySfx")]
	[SerializeField]
	public bool playSfx;

	public void OnPlaySfx()
	{
	}
}
