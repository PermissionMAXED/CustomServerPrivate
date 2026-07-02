using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace Gamekit3D
{
	[RequireComponent(typeof(Slider))]
	public class MixerSliderLink : MonoBehaviour
	{
		public AudioMixer mixer;

		public string mixerParameter;

		public float maxAttenuation;

		public float minAttenuation;

		[NonSerialized]
		public Slider m_Slider;

		public void Awake()
		{
		}

		public void SliderValueChange(float value)
		{
		}
	}
}
