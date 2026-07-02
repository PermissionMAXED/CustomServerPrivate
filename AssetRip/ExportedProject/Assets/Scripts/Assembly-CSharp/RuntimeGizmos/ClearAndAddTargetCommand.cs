using System;
using System.Collections.Generic;
using UnityEngine;

namespace RuntimeGizmos
{
	public class ClearAndAddTargetCommand : SelectCommand
	{
		[NonSerialized]
		public List<Transform> targetRoots;

		public ClearAndAddTargetCommand(TransformGizmo transformGizmo, Transform target, List<Transform> targetRoots)
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
