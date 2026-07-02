using System;
using System.Runtime.CompilerServices;
using Il2CppInterop.Common.Attributes;
using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.InteropTypes;

namespace Il2CppBAPBAP.UI;

public class BattlePassController : ControllerBase
{
	private static readonly IntPtr NativeMethodInfoPtr__ctor_Public_Void_ControllerManager_0;

	private static readonly IntPtr NativeMethodInfoPtr_ClaimBattlePassReward_Public_Void_Int32_0;

	static BattlePassController()
	{
		Il2CppClassPointerStore<BattlePassController>.NativeClassPtr = IL2CPP.GetIl2CppClass("Assembly-CSharp.dll", "BAPBAP.UI", "BattlePassController");
		IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<BattlePassController>.NativeClassPtr);
		NativeMethodInfoPtr__ctor_Public_Void_ControllerManager_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<BattlePassController>.NativeClassPtr, 100670364);
		NativeMethodInfoPtr_ClaimBattlePassReward_Public_Void_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<BattlePassController>.NativeClassPtr, 100670365);
	}

	[CallerCount(4)]
	[CachedScanResults(RefRangeStart = 101291, RefRangeEnd = 101295, XrefRangeStart = 101290, XrefRangeEnd = 101291, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe BattlePassController(ControllerManager controllerManager)
		: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<BattlePassController>.NativeClassPtr))
	{
		IntPtr* ptr = stackalloc IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)controllerManager);
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_ControllerManager_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 101295, XrefRangeEnd = 101305, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void ClaimBattlePassReward(int levelId)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = stackalloc IntPtr[1];
		*ptr = (nint)(&levelId);
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_ClaimBattlePassReward_Public_Void_Int32_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	public BattlePassController(IntPtr pointer)
		: base(pointer)
	{
	}
}
