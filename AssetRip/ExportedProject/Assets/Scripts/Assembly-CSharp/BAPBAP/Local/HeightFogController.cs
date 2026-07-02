using AtmosphericHeightFog;
using UnityEngine;

namespace BAPBAP.Local
{
	public class HeightFogController : MonoBehaviour
	{
		[SerializeField]
		public HeightFogGlobal heightFog;

		public void OnEnable()
		{
		}

		public void ShaderUtilityOnOnShaderKeywordChanged(string keyword, bool isEnabled)
		{
		}

		public void OnDestroy()
		{
		}
	}
}
