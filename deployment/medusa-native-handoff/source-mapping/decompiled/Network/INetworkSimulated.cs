using System;
using System.Runtime.CompilerServices;
using Il2CppInterop.Common.Attributes;
using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.InteropTypes;
using Il2CppMirror;
using Il2CppSystem.Text;

namespace Il2CppBAPBAP.Network;

public class INetworkSimulated : Il2CppObjectBase
{
	private static readonly IntPtr NativeMethodInfoPtr_Tick_Public_Abstract_Virtual_New_Void_Single_0;

	private static readonly IntPtr NativeMethodInfoPtr_OnNetDeserialize_Public_Abstract_Virtual_New_Void_NetworkReader_0;

	private static readonly IntPtr NativeMethodInfoPtr_OnNetSerialize_Public_Abstract_Virtual_New_Void_NetworkWriter_0;

	private static readonly IntPtr NativeMethodInfoPtr_OnNetDebugLog_Public_Abstract_Virtual_New_Void_StringBuilder_0;

	static INetworkSimulated()
	{
		Il2CppClassPointerStore<INetworkSimulated>.NativeClassPtr = IL2CPP.GetIl2CppClass("Assembly-CSharp.dll", "BAPBAP.Network", "INetworkSimulated");
		NativeMethodInfoPtr_Tick_Public_Abstract_Virtual_New_Void_Single_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<INetworkSimulated>.NativeClassPtr, 100666646);
		NativeMethodInfoPtr_OnNetDeserialize_Public_Abstract_Virtual_New_Void_NetworkReader_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<INetworkSimulated>.NativeClassPtr, 100666647);
		NativeMethodInfoPtr_OnNetSerialize_Public_Abstract_Virtual_New_Void_NetworkWriter_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<INetworkSimulated>.NativeClassPtr, 100666648);
		NativeMethodInfoPtr_OnNetDebugLog_Public_Abstract_Virtual_New_Void_StringBuilder_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<INetworkSimulated>.NativeClassPtr, 100666649);
	}

	[CallerCount(0)]
	public unsafe virtual void Tick(float fixedDt)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = stackalloc IntPtr[1];
		*ptr = (nint)(&fixedDt);
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(IL2CPP.il2cpp_object_get_virtual_method(IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)this), NativeMethodInfoPtr_Tick_Public_Abstract_Virtual_New_Void_Single_0), IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	public unsafe virtual void OnNetDeserialize(NetworkReader netReader)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = stackalloc IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)netReader);
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(IL2CPP.il2cpp_object_get_virtual_method(IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)this), NativeMethodInfoPtr_OnNetDeserialize_Public_Abstract_Virtual_New_Void_NetworkReader_0), IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	public unsafe virtual void OnNetSerialize(NetworkWriter networkWriter)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = stackalloc IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)networkWriter);
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(IL2CPP.il2cpp_object_get_virtual_method(IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)this), NativeMethodInfoPtr_OnNetSerialize_Public_Abstract_Virtual_New_Void_NetworkWriter_0), IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	public unsafe virtual void OnNetDebugLog(StringBuilder sb)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = stackalloc IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)sb);
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(IL2CPP.il2cpp_object_get_virtual_method(IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)this), NativeMethodInfoPtr_OnNetDebugLog_Public_Abstract_Virtual_New_Void_StringBuilder_0), IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	public INetworkSimulated(IntPtr pointer)
		: base(pointer)
	{
	}
}
