using System;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace BAPBAP.Local
{
	[Serializable]
	public class Command
	{
		public int predTickNum;

		public float smoothedPing;

		public int keyDowns;

		public int keyHolds;

		public int keyUps;

		public Vector3 directionals;

		public Vector3 worldMousePos;

		public byte inputSource;

		public bool doRandom;

		public bool quickCastAbilities;

		public override string ToString()
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool GetKeyDown(int cmdId)
		{
			return false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool GetKeyHold(int cmdId)
		{
			return false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool GetKeyUp(int cmdId)
		{
			return false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void SetKeyDown(int cmdId)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void SetKeyHold(int cmdId)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void SetKeyUp(int cmdId)
		{
		}

		public static Command Duplicate(int _tickNum, Command cmd)
		{
			return null;
		}
	}
}
