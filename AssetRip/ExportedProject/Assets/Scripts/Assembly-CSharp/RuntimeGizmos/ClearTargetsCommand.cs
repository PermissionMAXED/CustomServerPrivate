using System;
using System.Collections.Generic;
using UnityEngine;

namespace RuntimeGizmos
{
	public class ClearTargetsCommand : SelectCommand
	{
		[NonSerialized]
		public List<Transform> targetRoots;

		public ClearTargetsCommand(TransformGizmo transformGizmo, List<Transform> targetRoots)
			: base(null, null)
		{
		}

		public override void Execute()
		{
		}

		public override void UnExecute()
		{
		}
	}
}
