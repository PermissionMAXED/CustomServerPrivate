using UnityEngine;

namespace BAPBAP.Entities
{
	public class VFXTether : MonoBehaviour
	{
		public Transform sourceTransform;

		public Transform targetTransform;

		public bool destroyOnNullTargets;

		public void Initialize(Transform sourceTr, Transform targetTr, Vector3 initialSourcePos, Vector3 initialTargetPos)
		{
		}

		public void LateUpdate()
		{
		}

		public void SetTetherTransform(Vector3 targetPos)
		{
		}
	}
}
