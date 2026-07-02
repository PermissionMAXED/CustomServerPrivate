using System;
using CommandUndoRedo;
using UnityEngine;

namespace RuntimeGizmos
{
	public class TransformCommand : ICommand
	{
		public struct TransformValues
		{
			public Vector3 position;

			public Quaternion rotation;

			public Vector3 scale;
		}

		[NonSerialized]
		public TransformValues newValues;

		[NonSerialized]
		public TransformValues oldValues;

		[NonSerialized]
		public Transform transform;

		[NonSerialized]
		public TransformGizmo transformGizmo;

		public TransformCommand(TransformGizmo transformGizmo, Transform transform)
		{
		}

		public void StoreNewTransformValues()
		{
		}

		public void Execute()
		{
		}

		public void UnExecute()
		{
		}
	}
}
