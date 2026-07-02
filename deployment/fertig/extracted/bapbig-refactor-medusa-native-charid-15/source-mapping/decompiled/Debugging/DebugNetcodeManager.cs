using System;
using System.Runtime.CompilerServices;
using Il2CppBAPBAP.Network;
using Il2CppBAPBAP.Systems;
using Il2CppBAPBAP.Utilities;
using Il2CppInterop.Common.Attributes;
using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.InteropTypes;
using Il2CppInterop.Runtime.InteropTypes.Arrays;
using Il2CppInterop.Runtime.Runtime;
using Il2CppMirror;
using Il2CppSystem.Collections.Generic;
using Il2CppSystem.Text;
using UnityEngine;
using UnityEngine.UI;

namespace Il2CppBAPBAP.Debugging;

public class DebugNetcodeManager : MonoBehaviour
{
	private static readonly IntPtr NativeFieldInfoPtr_debugManager;

	private static readonly IntPtr NativeFieldInfoPtr_systemManager;

	private static readonly IntPtr NativeFieldInfoPtr_pingGraph;

	private static readonly IntPtr NativeFieldInfoPtr_perceivedPingGraph;

	private static readonly IntPtr NativeFieldInfoPtr_lerpGraph;

	private static readonly IntPtr NativeFieldInfoPtr_predGraph;

	private static readonly IntPtr NativeFieldInfoPtr_bandwidthGraph;

	private static readonly IntPtr NativeFieldInfoPtr_pingText;

	private static readonly IntPtr NativeFieldInfoPtr_jitterText;

	private static readonly IntPtr NativeFieldInfoPtr_netcodeBlock;

	private static readonly IntPtr NativeFieldInfoPtr_perceivedPingEMA;

	private static readonly IntPtr NativeFieldInfoPtr_packetSizeEMA;

	private static readonly IntPtr NativeFieldInfoPtr_cshim;

	private static readonly IntPtr NativeFieldInfoPtr_cgrid;

	private static readonly IntPtr NativeFieldInfoPtr_pingDecimalPrecisionString;

	private static readonly IntPtr NativeFieldInfoPtr_jitterDecimalPrecisionString;

	private static readonly IntPtr NativeFieldInfoPtr_addedCmds;

	private static readonly IntPtr NativeFieldInfoPtr_gatherPacketSize;

	private static readonly IntPtr NativeFieldInfoPtr_gatherNetStats;

	private static readonly IntPtr NativeFieldInfoPtr_debugNetSync;

	private static readonly IntPtr NativeFieldInfoPtr_debugNetSyncServer;

	private static readonly IntPtr NativeFieldInfoPtr_debugNetErrorCorrection;

	private static readonly IntPtr NativeFieldInfoPtr_debugDeltaCompression;

	private static readonly IntPtr NativeFieldInfoPtr_debugAoI;

	private static readonly IntPtr NativeFieldInfoPtr_debugPrintNetSyncsPerFrame;

	private static readonly IntPtr NativeFieldInfoPtr_lastUpdateRecvFrame;

	private static readonly IntPtr NativeFieldInfoPtr_printNetSyncsCounter;

	private static readonly IntPtr NativeFieldInfoPtr_printNetSyncsInterval;

	private static readonly IntPtr NativeFieldInfoPtr_netStateSyncsPerFrame;

	private static readonly IntPtr NativeMethodInfoPtr_Awake_Private_Void_0;

	private static readonly IntPtr NativeMethodInfoPtr_Start_Private_Void_0;

	private static readonly IntPtr NativeMethodInfoPtr_ManagedUpdate_Public_Void_0;

	private static readonly IntPtr NativeMethodInfoPtr_ManagedLateUpdate_Public_Void_0;

	private static readonly IntPtr NativeMethodInfoPtr_AddPingData_Public_Void_Single_Single_0;

	private static readonly IntPtr NativeMethodInfoPtr_AddPerceivedPing_Public_Void_Single_0;

	private static readonly IntPtr NativeMethodInfoPtr_AddLerpData_Public_Void_Single_Single_0;

	private static readonly IntPtr NativeMethodInfoPtr_AddPredData_Public_Void_Single_Single_0;

	private static readonly IntPtr NativeMethodInfoPtr_AddBufferData_Public_Void_Single_Single_0;

	private static readonly IntPtr NativeMethodInfoPtr_UpdatePing_Public_Void_Single_0;

	private static readonly IntPtr NativeMethodInfoPtr_UpdateJitter_Public_Void_Single_0;

	private static readonly IntPtr NativeMethodInfoPtr_AddSyncData_Public_Void_Int32_0;

	private static readonly IntPtr NativeMethodInfoPtr_ToggleTimeDilation_Private_Void_0;

	private static readonly IntPtr NativeMethodInfoPtr_ToggleNetSyncServer_Private_Void_0;

	private static readonly IntPtr NativeMethodInfoPtr_ToggleNetSyncClients_Private_Void_0;

	private static readonly IntPtr NativeMethodInfoPtr_ToggleNetPredictionClients_Private_Void_0;

	private static readonly IntPtr NativeMethodInfoPtr_ToggleNetPredictionPhysicsResimClients_Private_Void_0;

	private static readonly IntPtr NativeMethodInfoPtr_ToggleNetErrorSmoothing_Private_Void_0;

	private static readonly IntPtr NativeMethodInfoPtr_ToggleNetDeltaCompression_Private_Void_0;

	private static readonly IntPtr NativeMethodInfoPtr_TogglePrintNetSyncs_Private_Void_0;

	private static readonly IntPtr NativeMethodInfoPtr_ToggleAoI_Private_Void_0;

	private static readonly IntPtr NativeMethodInfoPtr_TransformIntoAoIGrid_Private_Vector3_Vector3_Boolean_Boolean_0;

	private static readonly IntPtr NativeMethodInfoPtr_SpawnAoIFill_Private_Void_0;

	private static readonly IntPtr NativeMethodInfoPtr_PrintNetWriters_Private_Void_0;

	private static readonly IntPtr NativeMethodInfoPtr_OnDebugWindowOpen_Public_Void_0;

	private static readonly IntPtr NativeMethodInfoPtr_OnDebugWindowClosed_Public_Void_0;

	private static readonly IntPtr NativeMethodInfoPtr_FormatNetWriters_Public_String_0;

	private static readonly IntPtr NativeMethodInfoPtr_FormatNetWriterSizes_Private_Void_StringBuilder_Il2CppReferenceArray_1_NetworkWriter_0;

	private static readonly IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

	public unsafe DebugManager debugManager
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_debugManager);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<DebugManager>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_debugManager)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)debugManager));
		}
	}

	public unsafe SystemManager systemManager
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_systemManager);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<SystemManager>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_systemManager)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)systemManager));
		}
	}

	public unsafe DebugGraph pingGraph
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_pingGraph);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<DebugGraph>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_pingGraph)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)debugGraph));
		}
	}

	public unsafe DebugGraph perceivedPingGraph
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_perceivedPingGraph);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<DebugGraph>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_perceivedPingGraph)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)debugGraph));
		}
	}

	public unsafe DebugGraph lerpGraph
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_lerpGraph);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<DebugGraph>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_lerpGraph)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)debugGraph));
		}
	}

	public unsafe DebugGraph predGraph
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_predGraph);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<DebugGraph>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_predGraph)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)debugGraph));
		}
	}

	public unsafe DebugGraph bandwidthGraph
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_bandwidthGraph);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<DebugGraph>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_bandwidthGraph)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)debugGraph));
		}
	}

	public unsafe Text pingText
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_pingText);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<Text>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_pingText)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)text));
		}
	}

	public unsafe Text jitterText
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_jitterText);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<Text>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_jitterText)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)text));
		}
	}

	public unsafe GameObject netcodeBlock
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_netcodeBlock);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<GameObject>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_netcodeBlock)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)gameObject));
		}
	}

	public unsafe ExpMovingAverage perceivedPingEMA
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_perceivedPingEMA);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<ExpMovingAverage>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_perceivedPingEMA)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)expMovingAverage));
		}
	}

	public unsafe ExpMovingAverage packetSizeEMA
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_packetSizeEMA);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<ExpMovingAverage>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_packetSizeEMA)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)expMovingAverage));
		}
	}

	public unsafe CustomSpatialHashInterestManagement cshim
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_cshim);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<CustomSpatialHashInterestManagement>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_cshim)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)customSpatialHashInterestManagement));
		}
	}

	public unsafe CustomGrid2D<NetworkConnectionToClient> cgrid
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_cgrid);
			return new CustomGrid2D<NetworkConnectionToClient>(IL2CPP.il2cpp_value_box(Il2CppClassPointerStore<CustomGrid2D<NetworkConnectionToClient>>.NativeClassPtr, (IntPtr)num));
		}
		set
		{
			// IL cpblk instruction
			Unsafe.CopyBlock((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_cgrid), IL2CPP.il2cpp_object_unbox(IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)customGrid2D)), IL2CPP.il2cpp_class_value_size(Il2CppClassPointerStore<CustomGrid2D<NetworkConnectionToClient>>.NativeClassPtr, ref *(uint*)null));
		}
	}

	public unsafe string pingDecimalPrecisionString
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_pingDecimalPrecisionString);
			return IL2CPP.Il2CppStringToManaged(*(IntPtr*)num);
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_pingDecimalPrecisionString)), IL2CPP.ManagedStringToIl2Cpp(text));
		}
	}

	public unsafe string jitterDecimalPrecisionString
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_jitterDecimalPrecisionString);
			return IL2CPP.Il2CppStringToManaged(*(IntPtr*)num);
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_jitterDecimalPrecisionString)), IL2CPP.ManagedStringToIl2Cpp(text));
		}
	}

	public unsafe bool addedCmds
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_addedCmds);
			return *(bool*)num;
		}
		set
		{
			*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_addedCmds)) = flag;
		}
	}

	public unsafe bool gatherPacketSize
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_gatherPacketSize);
			return *(bool*)num;
		}
		set
		{
			*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_gatherPacketSize)) = flag;
		}
	}

	public unsafe bool gatherNetStats
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_gatherNetStats);
			return *(bool*)num;
		}
		set
		{
			*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_gatherNetStats)) = flag;
		}
	}

	public unsafe bool debugNetSync
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_debugNetSync);
			return *(bool*)num;
		}
		set
		{
			*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_debugNetSync)) = flag;
		}
	}

	public unsafe bool debugNetSyncServer
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_debugNetSyncServer);
			return *(bool*)num;
		}
		set
		{
			*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_debugNetSyncServer)) = flag;
		}
	}

	public unsafe bool debugNetErrorCorrection
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_debugNetErrorCorrection);
			return *(bool*)num;
		}
		set
		{
			*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_debugNetErrorCorrection)) = flag;
		}
	}

	public unsafe bool debugDeltaCompression
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_debugDeltaCompression);
			return *(bool*)num;
		}
		set
		{
			*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_debugDeltaCompression)) = flag;
		}
	}

	public unsafe bool debugAoI
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_debugAoI);
			return *(bool*)num;
		}
		set
		{
			*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_debugAoI)) = flag;
		}
	}

	public unsafe bool debugPrintNetSyncsPerFrame
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_debugPrintNetSyncsPerFrame);
			return *(bool*)num;
		}
		set
		{
			*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_debugPrintNetSyncsPerFrame)) = flag;
		}
	}

	public unsafe int lastUpdateRecvFrame
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_lastUpdateRecvFrame);
			return *(int*)num;
		}
		set
		{
			*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_lastUpdateRecvFrame)) = num;
		}
	}

	public unsafe float printNetSyncsCounter
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_printNetSyncsCounter);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_printNetSyncsCounter)) = num;
		}
	}

	public unsafe float printNetSyncsInterval
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_printNetSyncsInterval);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_printNetSyncsInterval)) = num;
		}
	}

	public unsafe Dictionary<int, int> netStateSyncsPerFrame
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_netStateSyncsPerFrame);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<Dictionary<int, int>>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_netStateSyncsPerFrame)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)dictionary));
		}
	}

	static DebugNetcodeManager()
	{
		Il2CppClassPointerStore<DebugNetcodeManager>.NativeClassPtr = IL2CPP.GetIl2CppClass("Assembly-CSharp.dll", "BAPBAP.Debugging", "DebugNetcodeManager");
		IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<DebugNetcodeManager>.NativeClassPtr);
		NativeFieldInfoPtr_debugManager = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DebugNetcodeManager>.NativeClassPtr, "debugManager");
		NativeFieldInfoPtr_systemManager = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DebugNetcodeManager>.NativeClassPtr, "systemManager");
		NativeFieldInfoPtr_pingGraph = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DebugNetcodeManager>.NativeClassPtr, "pingGraph");
		NativeFieldInfoPtr_perceivedPingGraph = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DebugNetcodeManager>.NativeClassPtr, "perceivedPingGraph");
		NativeFieldInfoPtr_lerpGraph = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DebugNetcodeManager>.NativeClassPtr, "lerpGraph");
		NativeFieldInfoPtr_predGraph = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DebugNetcodeManager>.NativeClassPtr, "predGraph");
		NativeFieldInfoPtr_bandwidthGraph = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DebugNetcodeManager>.NativeClassPtr, "bandwidthGraph");
		NativeFieldInfoPtr_pingText = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DebugNetcodeManager>.NativeClassPtr, "pingText");
		NativeFieldInfoPtr_jitterText = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DebugNetcodeManager>.NativeClassPtr, "jitterText");
		NativeFieldInfoPtr_netcodeBlock = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DebugNetcodeManager>.NativeClassPtr, "netcodeBlock");
		NativeFieldInfoPtr_perceivedPingEMA = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DebugNetcodeManager>.NativeClassPtr, "perceivedPingEMA");
		NativeFieldInfoPtr_packetSizeEMA = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DebugNetcodeManager>.NativeClassPtr, "packetSizeEMA");
		NativeFieldInfoPtr_cshim = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DebugNetcodeManager>.NativeClassPtr, "cshim");
		NativeFieldInfoPtr_cgrid = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DebugNetcodeManager>.NativeClassPtr, "cgrid");
		NativeFieldInfoPtr_pingDecimalPrecisionString = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DebugNetcodeManager>.NativeClassPtr, "pingDecimalPrecisionString");
		NativeFieldInfoPtr_jitterDecimalPrecisionString = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DebugNetcodeManager>.NativeClassPtr, "jitterDecimalPrecisionString");
		NativeFieldInfoPtr_addedCmds = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DebugNetcodeManager>.NativeClassPtr, "addedCmds");
		NativeFieldInfoPtr_gatherPacketSize = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DebugNetcodeManager>.NativeClassPtr, "gatherPacketSize");
		NativeFieldInfoPtr_gatherNetStats = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DebugNetcodeManager>.NativeClassPtr, "gatherNetStats");
		NativeFieldInfoPtr_debugNetSync = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DebugNetcodeManager>.NativeClassPtr, "debugNetSync");
		NativeFieldInfoPtr_debugNetSyncServer = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DebugNetcodeManager>.NativeClassPtr, "debugNetSyncServer");
		NativeFieldInfoPtr_debugNetErrorCorrection = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DebugNetcodeManager>.NativeClassPtr, "debugNetErrorCorrection");
		NativeFieldInfoPtr_debugDeltaCompression = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DebugNetcodeManager>.NativeClassPtr, "debugDeltaCompression");
		NativeFieldInfoPtr_debugAoI = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DebugNetcodeManager>.NativeClassPtr, "debugAoI");
		NativeFieldInfoPtr_debugPrintNetSyncsPerFrame = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DebugNetcodeManager>.NativeClassPtr, "debugPrintNetSyncsPerFrame");
		NativeFieldInfoPtr_lastUpdateRecvFrame = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DebugNetcodeManager>.NativeClassPtr, "lastUpdateRecvFrame");
		NativeFieldInfoPtr_printNetSyncsCounter = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DebugNetcodeManager>.NativeClassPtr, "printNetSyncsCounter");
		NativeFieldInfoPtr_printNetSyncsInterval = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DebugNetcodeManager>.NativeClassPtr, "printNetSyncsInterval");
		NativeFieldInfoPtr_netStateSyncsPerFrame = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DebugNetcodeManager>.NativeClassPtr, "netStateSyncsPerFrame");
		NativeMethodInfoPtr_Awake_Private_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<DebugNetcodeManager>.NativeClassPtr, 100682803);
		NativeMethodInfoPtr_Start_Private_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<DebugNetcodeManager>.NativeClassPtr, 100682804);
		NativeMethodInfoPtr_ManagedUpdate_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<DebugNetcodeManager>.NativeClassPtr, 100682805);
		NativeMethodInfoPtr_ManagedLateUpdate_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<DebugNetcodeManager>.NativeClassPtr, 100682806);
		NativeMethodInfoPtr_AddPingData_Public_Void_Single_Single_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<DebugNetcodeManager>.NativeClassPtr, 100682807);
		NativeMethodInfoPtr_AddPerceivedPing_Public_Void_Single_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<DebugNetcodeManager>.NativeClassPtr, 100682808);
		NativeMethodInfoPtr_AddLerpData_Public_Void_Single_Single_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<DebugNetcodeManager>.NativeClassPtr, 100682809);
		NativeMethodInfoPtr_AddPredData_Public_Void_Single_Single_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<DebugNetcodeManager>.NativeClassPtr, 100682810);
		NativeMethodInfoPtr_AddBufferData_Public_Void_Single_Single_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<DebugNetcodeManager>.NativeClassPtr, 100682811);
		NativeMethodInfoPtr_UpdatePing_Public_Void_Single_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<DebugNetcodeManager>.NativeClassPtr, 100682812);
		NativeMethodInfoPtr_UpdateJitter_Public_Void_Single_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<DebugNetcodeManager>.NativeClassPtr, 100682813);
		NativeMethodInfoPtr_AddSyncData_Public_Void_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<DebugNetcodeManager>.NativeClassPtr, 100682814);
		NativeMethodInfoPtr_ToggleTimeDilation_Private_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<DebugNetcodeManager>.NativeClassPtr, 100682815);
		NativeMethodInfoPtr_ToggleNetSyncServer_Private_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<DebugNetcodeManager>.NativeClassPtr, 100682816);
		NativeMethodInfoPtr_ToggleNetSyncClients_Private_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<DebugNetcodeManager>.NativeClassPtr, 100682817);
		NativeMethodInfoPtr_ToggleNetPredictionClients_Private_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<DebugNetcodeManager>.NativeClassPtr, 100682818);
		NativeMethodInfoPtr_ToggleNetPredictionPhysicsResimClients_Private_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<DebugNetcodeManager>.NativeClassPtr, 100682819);
		NativeMethodInfoPtr_ToggleNetErrorSmoothing_Private_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<DebugNetcodeManager>.NativeClassPtr, 100682820);
		NativeMethodInfoPtr_ToggleNetDeltaCompression_Private_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<DebugNetcodeManager>.NativeClassPtr, 100682821);
		NativeMethodInfoPtr_TogglePrintNetSyncs_Private_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<DebugNetcodeManager>.NativeClassPtr, 100682822);
		NativeMethodInfoPtr_ToggleAoI_Private_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<DebugNetcodeManager>.NativeClassPtr, 100682823);
		NativeMethodInfoPtr_TransformIntoAoIGrid_Private_Vector3_Vector3_Boolean_Boolean_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<DebugNetcodeManager>.NativeClassPtr, 100682824);
		NativeMethodInfoPtr_SpawnAoIFill_Private_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<DebugNetcodeManager>.NativeClassPtr, 100682825);
		NativeMethodInfoPtr_PrintNetWriters_Private_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<DebugNetcodeManager>.NativeClassPtr, 100682826);
		NativeMethodInfoPtr_OnDebugWindowOpen_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<DebugNetcodeManager>.NativeClassPtr, 100682827);
		NativeMethodInfoPtr_OnDebugWindowClosed_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<DebugNetcodeManager>.NativeClassPtr, 100682828);
		NativeMethodInfoPtr_FormatNetWriters_Public_String_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<DebugNetcodeManager>.NativeClassPtr, 100682829);
		NativeMethodInfoPtr_FormatNetWriterSizes_Private_Void_StringBuilder_Il2CppReferenceArray_1_NetworkWriter_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<DebugNetcodeManager>.NativeClassPtr, 100682830);
		NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<DebugNetcodeManager>.NativeClassPtr, 100682831);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 216170, XrefRangeEnd = 216184, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void Awake()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = null;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_Awake_Private_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 216184, XrefRangeEnd = 216253, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void Start()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = null;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_Start_Private_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 216296, RefRangeEnd = 216297, XrefRangeStart = 216253, XrefRangeEnd = 216296, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void ManagedUpdate()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = null;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_ManagedUpdate_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 216381, RefRangeEnd = 216382, XrefRangeStart = 216297, XrefRangeEnd = 216381, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void ManagedLateUpdate()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = null;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_ManagedLateUpdate_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(2)]
	[CachedScanResults(RefRangeStart = 216385, RefRangeEnd = 216387, XrefRangeStart = 216382, XrefRangeEnd = 216385, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void AddPingData(float rtt, float rttEMA)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = stackalloc IntPtr[2];
		*ptr = (nint)(&rtt);
		*(float**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(IntPtr)))) = &rttEMA;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_AddPingData_Public_Void_Single_Single_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 216387, XrefRangeEnd = 216391, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void AddPerceivedPing(float percPing)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = stackalloc IntPtr[1];
		*ptr = (nint)(&percPing);
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_AddPerceivedPing_Public_Void_Single_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 216391, XrefRangeEnd = 216394, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void AddLerpData(float lerpDelay, float lerpDelayEMA)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = stackalloc IntPtr[2];
		*ptr = (nint)(&lerpDelay);
		*(float**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(IntPtr)))) = &lerpDelayEMA;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_AddLerpData_Public_Void_Single_Single_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 216397, RefRangeEnd = 216398, XrefRangeStart = 216394, XrefRangeEnd = 216397, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void AddPredData(float predTickAhead, float resim)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = stackalloc IntPtr[2];
		*ptr = (nint)(&predTickAhead);
		*(float**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(IntPtr)))) = &resim;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_AddPredData_Public_Void_Single_Single_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 216398, XrefRangeEnd = 216401, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void AddBufferData(float offset, float calcServerBuffer)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = stackalloc IntPtr[2];
		*ptr = (nint)(&offset);
		*(float**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(IntPtr)))) = &calcServerBuffer;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_AddBufferData_Public_Void_Single_Single_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(2)]
	[CachedScanResults(RefRangeStart = 216402, RefRangeEnd = 216404, XrefRangeStart = 216401, XrefRangeEnd = 216402, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void UpdatePing(float rttEMA)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = stackalloc IntPtr[1];
		*ptr = (nint)(&rttEMA);
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_UpdatePing_Public_Void_Single_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 216404, XrefRangeEnd = 216405, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void UpdateJitter(float data)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = stackalloc IntPtr[1];
		*ptr = (nint)(&data);
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_UpdateJitter_Public_Void_Single_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(2)]
	[CachedScanResults(RefRangeStart = 216412, RefRangeEnd = 216414, XrefRangeStart = 216405, XrefRangeEnd = 216412, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void AddSyncData(int num)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = stackalloc IntPtr[1];
		*ptr = (nint)(&num);
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_AddSyncData_Public_Void_Int32_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 216414, XrefRangeEnd = 216425, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void ToggleTimeDilation()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = null;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_ToggleTimeDilation_Private_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 216425, XrefRangeEnd = 216436, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void ToggleNetSyncServer()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = null;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_ToggleNetSyncServer_Private_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 216436, XrefRangeEnd = 216444, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void ToggleNetSyncClients()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = null;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_ToggleNetSyncClients_Private_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 216444, XrefRangeEnd = 216465, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void ToggleNetPredictionClients()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = null;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_ToggleNetPredictionClients_Private_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 216465, XrefRangeEnd = 216486, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void ToggleNetPredictionPhysicsResimClients()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = null;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_ToggleNetPredictionPhysicsResimClients_Private_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 216486, XrefRangeEnd = 216494, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void ToggleNetErrorSmoothing()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = null;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_ToggleNetErrorSmoothing_Private_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 216494, XrefRangeEnd = 216499, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void ToggleNetDeltaCompression()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = null;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_ToggleNetDeltaCompression_Private_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 216499, XrefRangeEnd = 216506, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void TogglePrintNetSyncs()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = null;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_TogglePrintNetSyncs_Private_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 216506, XrefRangeEnd = 216514, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void ToggleAoI()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = null;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_ToggleAoI_Private_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(4)]
	[CachedScanResults(RefRangeStart = 216527, RefRangeEnd = 216531, XrefRangeStart = 216514, XrefRangeEnd = 216527, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe Vector3 TransformIntoAoIGrid(Vector3 vec3, bool passThruCenter = false, bool isLog = false)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = stackalloc IntPtr[3];
		*ptr = (nint)(&vec3);
		*(bool**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(IntPtr)))) = &passThruCenter;
		*(bool**)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(IntPtr)))) = &isLog;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_TransformIntoAoIGrid_Private_Vector3_Vector3_Boolean_Boolean_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(Vector3*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 216531, XrefRangeEnd = 216536, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void SpawnAoIFill()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = null;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_SpawnAoIFill_Private_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 216536, XrefRangeEnd = 216553, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void PrintNetWriters()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = null;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_PrintNetWriters_Private_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 216553, XrefRangeEnd = 216558, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void OnDebugWindowOpen()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = null;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_OnDebugWindowOpen_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 216574, RefRangeEnd = 216575, XrefRangeStart = 216558, XrefRangeEnd = 216574, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void OnDebugWindowClosed()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = null;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_OnDebugWindowClosed_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 216614, RefRangeEnd = 216615, XrefRangeStart = 216575, XrefRangeEnd = 216614, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe string FormatNetWriters()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = null;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_FormatNetWriters_Public_String_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return IL2CPP.Il2CppStringToManaged(intPtr);
	}

	[CallerCount(3)]
	[CachedScanResults(RefRangeStart = 216646, RefRangeEnd = 216649, XrefRangeStart = 216615, XrefRangeEnd = 216646, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void FormatNetWriterSizes(StringBuilder sb, Il2CppReferenceArray<NetworkWriter> writers)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = stackalloc IntPtr[2];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)sb);
		*(IntPtr*)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)writers);
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_FormatNetWriterSizes_Private_Void_StringBuilder_Il2CppReferenceArray_1_NetworkWriter_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 216649, XrefRangeEnd = 216654, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe DebugNetcodeManager()
		: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<DebugNetcodeManager>.NativeClassPtr))
	{
		IntPtr* ptr = null;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	public DebugNetcodeManager(IntPtr pointer)
		: base(pointer)
	{
	}
}
