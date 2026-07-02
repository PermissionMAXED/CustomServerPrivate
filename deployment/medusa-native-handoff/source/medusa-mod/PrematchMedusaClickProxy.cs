using System;
using Il2CppInterop.Runtime.Injection;
using UnityEngine;
using Object = UnityEngine.Object;

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
		EnsureRegistered();
		try
		{
			if ((Object)(object)go == (Object)null)
			{
				return;
			}
			PrematchMedusaClickProxy proxy = go.GetComponent<PrematchMedusaClickProxy>();
			if ((Object)(object)proxy == (Object)null)
			{
				proxy = go.AddComponent<PrematchMedusaClickProxy>();
			}
			proxy._callback = onClick;
			proxy._rect = go.GetComponent<RectTransform>() ?? go.transform as RectTransform;
			proxy.enabled = true;
			Debug.Log("[Medusa] prematch Medusa click proxy attached via " + source + ".");
		}
		catch (Exception ex)
		{
			Debug.LogWarning("[Medusa] prematch Medusa click proxy attach failed: " + ex.Message);
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
			Debug.LogWarning("[Medusa] prematch Medusa click proxy registration failed: " + ex.Message);
		}
	}

	public void Update()
	{
		try
		{
			if (_callback != null &&
			    (Object)(object)_rect != (Object)null &&
			    Input.GetMouseButtonDown(0) &&
			    RectTransformUtility.RectangleContainsScreenPoint(_rect, Input.mousePosition, null))
			{
				Debug.Log("[Medusa] prematch Medusa click proxy fired.");
				_callback();
			}
		}
		catch (Exception ex)
		{
			Debug.LogWarning("[Medusa] prematch Medusa click proxy update failed: " + ex.Message);
		}
	}
}
