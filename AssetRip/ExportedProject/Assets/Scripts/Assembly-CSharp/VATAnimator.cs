using System;
using UnityEngine;

[ExecuteInEditMode]
public class VATAnimator : MonoBehaviour
{
	[Header("References")]
	[SerializeField]
	public Renderer rend;

	[SerializeField]
	[Header("Settings")]
	public float playbackSpeed;

	[SerializeField]
	public bool doLoop;

	[SerializeField]
	public bool playOnAwake;

	[NonSerialized]
	public float time;

	[NonSerialized]
	public int timeProperty;

	public void Start()
	{
	}

	public void Initialize()
	{
	}

	public void OnEnable()
	{
	}

	public void Play()
	{
	}

	public void Update()
	{
	}

	public void Animate()
	{
	}

	public void SetAnimTime(float t)
	{
	}
}
