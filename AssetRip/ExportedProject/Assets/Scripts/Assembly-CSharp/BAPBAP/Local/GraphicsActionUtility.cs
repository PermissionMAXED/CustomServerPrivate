using System;
using System.Runtime.CompilerServices;

namespace BAPBAP.Local
{
	public static class GraphicsActionUtility
	{
		public static event Action<string, bool> OnShaderKeywordChanged
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public static event Action<string, float> OnGlobalFloatChanged
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public static event Action<float> OnRenderScaleChanged
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public static void EnableKeywordExt(string keyword)
		{
		}

		public static void DisableKeywordExt(string keyword)
		{
		}

		public static void SetGlobalFloatExt(string keyword, float value)
		{
		}

		public static void SetRenderScale(float renderScale)
		{
		}
	}
}
