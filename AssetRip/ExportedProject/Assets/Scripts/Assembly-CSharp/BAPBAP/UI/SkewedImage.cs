using UnityEngine;
using UnityEngine.UI;

namespace BAPBAP.UI
{
	public class SkewedImage : Image
	{
		[SerializeField]
		public float skewX;

		[SerializeField]
		public float skewY;

		public override void OnPopulateMesh(VertexHelper vh)
		{
		}
	}
}
