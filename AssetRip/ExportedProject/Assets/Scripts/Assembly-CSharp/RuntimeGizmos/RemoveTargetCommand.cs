using UnityEngine;

namespace RuntimeGizmos
{
	public class RemoveTargetCommand : SelectCommand
	{
		public RemoveTargetCommand(TransformGizmo transformGizmo, Transform target)
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
