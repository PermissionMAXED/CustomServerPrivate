using System;
using System.Collections.Generic;
using BAPBAP.Entities;
using UnityEngine;

public class TestingApplyStatusEffectsHitbox : MonoBehaviour
{
	[NonSerialized]
	public Hitbox hbox;

	[SerializeField]
	public List<StatusEffectInfo> statusEffects;

	[SerializeField]
	public int damage;

	public void Start()
	{
	}
}
