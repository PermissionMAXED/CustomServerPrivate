using System;
using Il2CppInterop.Runtime.Injection;
using Il2CppSystem;
using UnityEngine;

namespace BAPBAP.Medusa;

public sealed class PrematchMedusaClickProxy : MonoBehaviour
{
	private static bool _registered;

	private Action? _callback;

	private RectTransform? _rect;

	public PrematchMedusaClickProxy(IntPtr ptr)
		: base(ptr)
	{
	}

	public static void Attach(GameObject go, Action onClick, string source)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Expected O, but got Unknown
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Expected O, but got Unknown
		EnsureRegistered();
		try
		{
			if (!((Object)go == (Object)null))
			{
				PrematchMedusaClickProxy prematchMedusaClickProxy = go.GetComponent<PrematchMedusaClickProxy>();
				if ((Object)prematchMedusaClickProxy == (Object)null)
				{
					prematchMedusaClickProxy = go.AddComponent<PrematchMedusaClickProxy>();
				}
				prematchMedusaClickProxy._callback = onClick;
				PrematchMedusaClickProxy prematchMedusaClickProxy2 = prematchMedusaClickProxy;
				object obj = go.GetComponent<RectTransform>();
				if (obj == null)
				{
					Transform transform = go.transform;
					obj = ((transform is RectTransform) ? transform : null);
				}
				prematchMedusaClickProxy2._rect = (RectTransform?)obj;
				((Behaviour)prematchMedusaClickProxy).enabled = true;
				Debug.Log(Object.op_Implicit("[Medusa] prematch Medusa click proxy attached via " + source + "."));
			}
		}
		catch (Exception ex)
		{
			Debug.LogWarning(Object.op_Implicit("[Medusa] prematch Medusa click proxy attach failed: " + ex.Message));
		}
	}

	private static void EnsureRegistered()
	{
		if (_registered)
		{
			return;
		}
		try
		{
			ClassInjector.RegisterTypeInIl2Cpp<PrematchMedusaClickProxy>();
			_registered = true;
		}
		catch (Exception ex)
		{
			Debug.LogWarning(Object.op_Implicit("[Medusa] prematch Medusa click proxy registration failed: " + ex.Message));
		}
	}

	public void Update()
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			if (_callback != null && !((Object)(object)_rect == (Object)null) && Input.GetMouseButtonDown(0) && RectTransformUtility.RectangleContainsScreenPoint(_rect, Vector2.op_Implicit(Input.mousePosition), (Camera)null))
			{
				Debug.Log(Object.op_Implicit("[Medusa] prematch Medusa click proxy fired."));
				_callback();
			}
		}
		catch (Exception ex)
		{
			Debug.LogWarning(Object.op_Implicit("[Medusa] prematch Medusa click proxy update failed: " + ex.Message));
		}
	}
}
