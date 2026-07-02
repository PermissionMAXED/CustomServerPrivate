using System;
using CommandUndoRedo;
using UnityEngine;

namespace RuntimeGizmos
{
	public abstract class SelectCommand : ICommand
	{
		[NonSerialized]
		public Transform target;

		[NonSerialized]
		public TransformGizmo transformGizmo;

		public SelectCommand(TransformGizmo transformGizmo, Transform target)
		{
		}

		public abstract void Execute();

		public abstract void UnExecute();
	}
}
