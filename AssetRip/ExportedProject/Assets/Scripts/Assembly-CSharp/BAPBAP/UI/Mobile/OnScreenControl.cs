using UnityEngine.InputSystem.OnScreen;

namespace BAPBAP.UI.Mobile
{
	public class OnScreenControl : UnityEngine.InputSystem.OnScreen.OnScreenControl
	{
		public override string controlPathInternal { get; set; }

		public void SendValue<TValue>(TValue value) where TValue : struct
		{
		}
	}
}
