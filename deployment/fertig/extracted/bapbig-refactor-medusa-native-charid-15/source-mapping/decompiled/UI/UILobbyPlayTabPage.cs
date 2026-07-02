using System;
using System.Runtime.CompilerServices;
using Il2Cpp;
using Il2CppBAPBAP.Content;
using Il2CppBAPBAP.Local;
using Il2CppBAPBAP.Localisation;
using Il2CppBAPBAP.Steam;
using Il2CppInterop.Common.Attributes;
using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.InteropTypes;
using Il2CppInterop.Runtime.InteropTypes.Arrays;
using Il2CppInterop.Runtime.Runtime;
using Il2CppSystem;
using Il2CppSystem.Collections;
using Il2CppSystem.Collections.Generic;
using Il2CppTMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Il2CppBAPBAP.UI;

public class UILobbyPlayTabPage : UILobbyTabPage
{
	public class Actions : Il2CppSystem.Object
	{
		private static readonly System.IntPtr NativeFieldInfoPtr_gameModeSelectAction;

		private static readonly System.IntPtr NativeFieldInfoPtr_gameModeSelectWithPasswordAction;

		private static readonly System.IntPtr NativeFieldInfoPtr_matchStartSelectCharAction;

		private static readonly System.IntPtr NativeFieldInfoPtr_joinLobbyAction;

		private static readonly System.IntPtr NativeFieldInfoPtr_joinFriendLobbyAction;

		private static readonly System.IntPtr NativeFieldInfoPtr_readyAction;

		private static readonly System.IntPtr NativeFieldInfoPtr_unreadyAction;

		private static readonly System.IntPtr NativeFieldInfoPtr_cancelAction;

		private static readonly System.IntPtr NativeFieldInfoPtr_sendChatMessageAction;

		private static readonly System.IntPtr NativeFieldInfoPtr_sendWhisperAction;

		private static readonly System.IntPtr NativeFieldInfoPtr_inviteLinkAction;

		private static readonly System.IntPtr NativeFieldInfoPtr_copyUsernameIdAction;

		private static readonly System.IntPtr NativeFieldInfoPtr_friendSendInviteLobbyAction;

		private static readonly System.IntPtr NativeFieldInfoPtr_friendInviteSteamAction;

		private static readonly System.IntPtr NativeFieldInfoPtr_friendRequestAcceptAction;

		private static readonly System.IntPtr NativeFieldInfoPtr_friendSendRequestAction;

		private static readonly System.IntPtr NativeFieldInfoPtr_friendRequestRejectAction;

		private static readonly System.IntPtr NativeFieldInfoPtr_friendRemoveAction;

		private static readonly System.IntPtr NativeFieldInfoPtr_kickTeammate;

		private static readonly System.IntPtr NativeFieldInfoPtr_sendOpenFriendRequests;

		private static readonly System.IntPtr NativeFieldInfoPtr_setClosedPartyAction;

		private static readonly System.IntPtr NativeFieldInfoPtr_switchRegionAction;

		private static readonly System.IntPtr NativeFieldInfoPtr_openLoginWindowAction;

		private static readonly System.IntPtr NativeFieldInfoPtr_completeLoginRequestAction;

		private static readonly System.IntPtr NativeFieldInfoPtr_dailyRewardRequestAction;

		private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

		public unsafe Il2CppSystem.Action<int> gameModeSelectAction
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_gameModeSelectAction);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppSystem.Action<int>>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_gameModeSelectAction)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)action));
			}
		}

		public unsafe Il2CppSystem.Action<int, string> gameModeSelectWithPasswordAction
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_gameModeSelectWithPasswordAction);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppSystem.Action<int, string>>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_gameModeSelectWithPasswordAction)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)action));
			}
		}

		public unsafe Il2CppSystem.Action<int> matchStartSelectCharAction
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_matchStartSelectCharAction);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppSystem.Action<int>>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_matchStartSelectCharAction)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)action));
			}
		}

		public unsafe Il2CppSystem.Action<string, bool> joinLobbyAction
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_joinLobbyAction);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppSystem.Action<string, bool>>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_joinLobbyAction)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)action));
			}
		}

		public unsafe Il2CppSystem.Action<string> joinFriendLobbyAction
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_joinFriendLobbyAction);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppSystem.Action<string>>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_joinFriendLobbyAction)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)action));
			}
		}

		public unsafe Il2CppSystem.Action readyAction
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_readyAction);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppSystem.Action>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_readyAction)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)action));
			}
		}

		public unsafe Il2CppSystem.Action unreadyAction
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_unreadyAction);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppSystem.Action>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_unreadyAction)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)action));
			}
		}

		public unsafe Il2CppSystem.Action cancelAction
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_cancelAction);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppSystem.Action>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_cancelAction)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)action));
			}
		}

		public unsafe Il2CppSystem.Action<string> sendChatMessageAction
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_sendChatMessageAction);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppSystem.Action<string>>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_sendChatMessageAction)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)action));
			}
		}

		public unsafe Il2CppSystem.Action<string, string> sendWhisperAction
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_sendWhisperAction);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppSystem.Action<string, string>>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_sendWhisperAction)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)action));
			}
		}

		public unsafe Il2CppSystem.Action inviteLinkAction
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_inviteLinkAction);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppSystem.Action>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_inviteLinkAction)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)action));
			}
		}

		public unsafe Il2CppSystem.Action copyUsernameIdAction
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_copyUsernameIdAction);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppSystem.Action>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_copyUsernameIdAction)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)action));
			}
		}

		public unsafe Il2CppSystem.Action<string, string> friendSendInviteLobbyAction
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_friendSendInviteLobbyAction);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppSystem.Action<string, string>>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_friendSendInviteLobbyAction)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)action));
			}
		}

		public unsafe Il2CppSystem.Action<ulong> friendInviteSteamAction
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_friendInviteSteamAction);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppSystem.Action<ulong>>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_friendInviteSteamAction)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)action));
			}
		}

		public unsafe Il2CppSystem.Action<string> friendRequestAcceptAction
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_friendRequestAcceptAction);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppSystem.Action<string>>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_friendRequestAcceptAction)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)action));
			}
		}

		public unsafe Il2CppSystem.Action<string, int> friendSendRequestAction
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_friendSendRequestAction);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppSystem.Action<string, int>>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_friendSendRequestAction)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)action));
			}
		}

		public unsafe Il2CppSystem.Action<string> friendRequestRejectAction
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_friendRequestRejectAction);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppSystem.Action<string>>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_friendRequestRejectAction)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)action));
			}
		}

		public unsafe Il2CppSystem.Action<string> friendRemoveAction
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_friendRemoveAction);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppSystem.Action<string>>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_friendRemoveAction)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)action));
			}
		}

		public unsafe Il2CppSystem.Action<string> kickTeammate
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_kickTeammate);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppSystem.Action<string>>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_kickTeammate)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)action));
			}
		}

		public unsafe Il2CppSystem.Action<bool> sendOpenFriendRequests
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_sendOpenFriendRequests);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppSystem.Action<bool>>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_sendOpenFriendRequests)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)action));
			}
		}

		public unsafe Il2CppSystem.Action<bool> setClosedPartyAction
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_setClosedPartyAction);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppSystem.Action<bool>>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_setClosedPartyAction)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)action));
			}
		}

		public unsafe Il2CppSystem.Action<int> switchRegionAction
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_switchRegionAction);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppSystem.Action<int>>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_switchRegionAction)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)action));
			}
		}

		public unsafe Il2CppSystem.Action openLoginWindowAction
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_openLoginWindowAction);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppSystem.Action>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_openLoginWindowAction)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)action));
			}
		}

		public unsafe Il2CppSystem.Action<string> completeLoginRequestAction
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_completeLoginRequestAction);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppSystem.Action<string>>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_completeLoginRequestAction)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)action));
			}
		}

		public unsafe Il2CppSystem.Action dailyRewardRequestAction
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_dailyRewardRequestAction);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppSystem.Action>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_dailyRewardRequestAction)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)action));
			}
		}

		static Actions()
		{
			Il2CppClassPointerStore<Actions>.NativeClassPtr = IL2CPP.GetIl2CppNestedType(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "Actions");
			IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<Actions>.NativeClassPtr);
			NativeFieldInfoPtr_gameModeSelectAction = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Actions>.NativeClassPtr, "gameModeSelectAction");
			NativeFieldInfoPtr_gameModeSelectWithPasswordAction = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Actions>.NativeClassPtr, "gameModeSelectWithPasswordAction");
			NativeFieldInfoPtr_matchStartSelectCharAction = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Actions>.NativeClassPtr, "matchStartSelectCharAction");
			NativeFieldInfoPtr_joinLobbyAction = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Actions>.NativeClassPtr, "joinLobbyAction");
			NativeFieldInfoPtr_joinFriendLobbyAction = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Actions>.NativeClassPtr, "joinFriendLobbyAction");
			NativeFieldInfoPtr_readyAction = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Actions>.NativeClassPtr, "readyAction");
			NativeFieldInfoPtr_unreadyAction = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Actions>.NativeClassPtr, "unreadyAction");
			NativeFieldInfoPtr_cancelAction = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Actions>.NativeClassPtr, "cancelAction");
			NativeFieldInfoPtr_sendChatMessageAction = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Actions>.NativeClassPtr, "sendChatMessageAction");
			NativeFieldInfoPtr_sendWhisperAction = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Actions>.NativeClassPtr, "sendWhisperAction");
			NativeFieldInfoPtr_inviteLinkAction = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Actions>.NativeClassPtr, "inviteLinkAction");
			NativeFieldInfoPtr_copyUsernameIdAction = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Actions>.NativeClassPtr, "copyUsernameIdAction");
			NativeFieldInfoPtr_friendSendInviteLobbyAction = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Actions>.NativeClassPtr, "friendSendInviteLobbyAction");
			NativeFieldInfoPtr_friendInviteSteamAction = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Actions>.NativeClassPtr, "friendInviteSteamAction");
			NativeFieldInfoPtr_friendRequestAcceptAction = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Actions>.NativeClassPtr, "friendRequestAcceptAction");
			NativeFieldInfoPtr_friendSendRequestAction = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Actions>.NativeClassPtr, "friendSendRequestAction");
			NativeFieldInfoPtr_friendRequestRejectAction = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Actions>.NativeClassPtr, "friendRequestRejectAction");
			NativeFieldInfoPtr_friendRemoveAction = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Actions>.NativeClassPtr, "friendRemoveAction");
			NativeFieldInfoPtr_kickTeammate = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Actions>.NativeClassPtr, "kickTeammate");
			NativeFieldInfoPtr_sendOpenFriendRequests = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Actions>.NativeClassPtr, "sendOpenFriendRequests");
			NativeFieldInfoPtr_setClosedPartyAction = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Actions>.NativeClassPtr, "setClosedPartyAction");
			NativeFieldInfoPtr_switchRegionAction = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Actions>.NativeClassPtr, "switchRegionAction");
			NativeFieldInfoPtr_openLoginWindowAction = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Actions>.NativeClassPtr, "openLoginWindowAction");
			NativeFieldInfoPtr_completeLoginRequestAction = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Actions>.NativeClassPtr, "completeLoginRequestAction");
			NativeFieldInfoPtr_dailyRewardRequestAction = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Actions>.NativeClassPtr, "dailyRewardRequestAction");
			NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<Actions>.NativeClassPtr, 100669657);
		}

		[CallerCount(5410)]
		[CachedScanResults(RefRangeStart = 11, RefRangeEnd = 5421, XrefRangeStart = 11, XrefRangeEnd = 5421, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe Actions()
			: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<Actions>.NativeClassPtr))
		{
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		public Actions(System.IntPtr pointer)
			: base(pointer)
		{
		}
	}

	[System.Serializable]
	public class PlayerProfile : Il2CppSystem.Object
	{
		private static readonly System.IntPtr NativeFieldInfoPtr_levelText;

		private static readonly System.IntPtr NativeFieldInfoPtr_LevelTextAnim;

		private static readonly System.IntPtr NativeFieldInfoPtr_xpBarFill;

		private static readonly System.IntPtr NativeFieldInfoPtr_BarFillAlpha;

		private static readonly System.IntPtr NativeFieldInfoPtr_xpBarLevelUpAlpha;

		private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

		public unsafe TMP_Text levelText
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_levelText);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<TMP_Text>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_levelText)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)tMP_Text));
			}
		}

		public unsafe TransformScaleSimpleAnimation LevelTextAnim
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_LevelTextAnim);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<TransformScaleSimpleAnimation>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_LevelTextAnim)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)transformScaleSimpleAnimation));
			}
		}

		public unsafe Image xpBarFill
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_xpBarFill);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Image>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_xpBarFill)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)image));
			}
		}

		public unsafe CanvasGroup BarFillAlpha
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_BarFillAlpha);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<CanvasGroup>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_BarFillAlpha)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)canvasGroup));
			}
		}

		public unsafe CanvasGroup xpBarLevelUpAlpha
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_xpBarLevelUpAlpha);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<CanvasGroup>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_xpBarLevelUpAlpha)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)canvasGroup));
			}
		}

		static PlayerProfile()
		{
			Il2CppClassPointerStore<PlayerProfile>.NativeClassPtr = IL2CPP.GetIl2CppNestedType(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "PlayerProfile");
			IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<PlayerProfile>.NativeClassPtr);
			NativeFieldInfoPtr_levelText = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<PlayerProfile>.NativeClassPtr, "levelText");
			NativeFieldInfoPtr_LevelTextAnim = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<PlayerProfile>.NativeClassPtr, "LevelTextAnim");
			NativeFieldInfoPtr_xpBarFill = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<PlayerProfile>.NativeClassPtr, "xpBarFill");
			NativeFieldInfoPtr_BarFillAlpha = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<PlayerProfile>.NativeClassPtr, "BarFillAlpha");
			NativeFieldInfoPtr_xpBarLevelUpAlpha = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<PlayerProfile>.NativeClassPtr, "xpBarLevelUpAlpha");
			NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<PlayerProfile>.NativeClassPtr, 100669658);
		}

		[CallerCount(5410)]
		[CachedScanResults(RefRangeStart = 11, RefRangeEnd = 5421, XrefRangeStart = 11, XrefRangeEnd = 5421, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe PlayerProfile()
			: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<PlayerProfile>.NativeClassPtr))
		{
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		public PlayerProfile(System.IntPtr pointer)
			: base(pointer)
		{
		}
	}

	[System.Serializable]
	public class DailyReward : Il2CppSystem.Object
	{
		private static readonly System.IntPtr NativeFieldInfoPtr_titleText;

		private static readonly System.IntPtr NativeFieldInfoPtr_refreshesText;

		private static readonly System.IntPtr NativeFieldInfoPtr_progressText;

		private static readonly System.IntPtr NativeFieldInfoPtr_dailyCompletedText;

		private static readonly System.IntPtr NativeFieldInfoPtr_progressBarDivider;

		private static readonly System.IntPtr NativeFieldInfoPtr_LevelProgressBar;

		private static readonly System.IntPtr NativeFieldInfoPtr_tooltipHover;

		private static readonly System.IntPtr NativeFieldInfoPtr_tooltipAlphaFade;

		private static readonly System.IntPtr NativeFieldInfoPtr_tooltipDescText;

		private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

		public unsafe TMP_Text titleText
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_titleText);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<TMP_Text>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_titleText)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)tMP_Text));
			}
		}

		public unsafe TMP_Text refreshesText
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_refreshesText);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<TMP_Text>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_refreshesText)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)tMP_Text));
			}
		}

		public unsafe TMP_Text progressText
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_progressText);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<TMP_Text>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_progressText)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)tMP_Text));
			}
		}

		public unsafe TMP_Text dailyCompletedText
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_dailyCompletedText);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<TMP_Text>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_dailyCompletedText)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)tMP_Text));
			}
		}

		public unsafe Image progressBarDivider
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_progressBarDivider);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Image>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_progressBarDivider)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)image));
			}
		}

		public unsafe LayoutFitParentPercentage LevelProgressBar
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_LevelProgressBar);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<LayoutFitParentPercentage>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_LevelProgressBar)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)layoutFitParentPercentage));
			}
		}

		public unsafe UIHoverTooltip tooltipHover
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_tooltipHover);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<UIHoverTooltip>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_tooltipHover)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)uIHoverTooltip));
			}
		}

		public unsafe UIAlphaFade tooltipAlphaFade
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_tooltipAlphaFade);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<UIAlphaFade>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_tooltipAlphaFade)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)uIAlphaFade));
			}
		}

		public unsafe TMP_Text tooltipDescText
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_tooltipDescText);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<TMP_Text>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_tooltipDescText)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)tMP_Text));
			}
		}

		static DailyReward()
		{
			Il2CppClassPointerStore<DailyReward>.NativeClassPtr = IL2CPP.GetIl2CppNestedType(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "DailyReward");
			IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<DailyReward>.NativeClassPtr);
			NativeFieldInfoPtr_titleText = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DailyReward>.NativeClassPtr, "titleText");
			NativeFieldInfoPtr_refreshesText = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DailyReward>.NativeClassPtr, "refreshesText");
			NativeFieldInfoPtr_progressText = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DailyReward>.NativeClassPtr, "progressText");
			NativeFieldInfoPtr_dailyCompletedText = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DailyReward>.NativeClassPtr, "dailyCompletedText");
			NativeFieldInfoPtr_progressBarDivider = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DailyReward>.NativeClassPtr, "progressBarDivider");
			NativeFieldInfoPtr_LevelProgressBar = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DailyReward>.NativeClassPtr, "LevelProgressBar");
			NativeFieldInfoPtr_tooltipHover = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DailyReward>.NativeClassPtr, "tooltipHover");
			NativeFieldInfoPtr_tooltipAlphaFade = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DailyReward>.NativeClassPtr, "tooltipAlphaFade");
			NativeFieldInfoPtr_tooltipDescText = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DailyReward>.NativeClassPtr, "tooltipDescText");
			NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<DailyReward>.NativeClassPtr, 100669659);
		}

		[CallerCount(5410)]
		[CachedScanResults(RefRangeStart = 11, RefRangeEnd = 5421, XrefRangeStart = 11, XrefRangeEnd = 5421, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe DailyReward()
			: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<DailyReward>.NativeClassPtr))
		{
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		public DailyReward(System.IntPtr pointer)
			: base(pointer)
		{
		}
	}

	[System.Serializable]
	public class PlayerDisplay : Il2CppSystem.Object
	{
		private static readonly System.IntPtr NativeFieldInfoPtr_playerContainer;

		private static readonly System.IntPtr NativeFieldInfoPtr_playerDisplayObj;

		private static readonly System.IntPtr NativeFieldInfoPtr_CanvasGroup;

		private static readonly System.IntPtr NativeFieldInfoPtr_ReadyText;

		private static readonly System.IntPtr NativeFieldInfoPtr_InQueueText;

		private static readonly System.IntPtr NativeFieldInfoPtr_hoverButtonPointer;

		private static readonly System.IntPtr NativeFieldInfoPtr_eventTrigger;

		private static readonly System.IntPtr NativeFieldInfoPtr_playerAccountId;

		private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

		public unsafe UILobbyPlayerContainer playerContainer
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_playerContainer);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<UILobbyPlayerContainer>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_playerContainer)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)uILobbyPlayerContainer));
			}
		}

		public unsafe GameObject playerDisplayObj
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_playerDisplayObj);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<GameObject>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_playerDisplayObj)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)gameObject));
			}
		}

		public unsafe CanvasGroup CanvasGroup
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_CanvasGroup);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<CanvasGroup>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_CanvasGroup)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)canvasGroup));
			}
		}

		public unsafe TMP_Text ReadyText
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_ReadyText);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<TMP_Text>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_ReadyText)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)tMP_Text));
			}
		}

		public unsafe TMP_Text InQueueText
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_InQueueText);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<TMP_Text>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_InQueueText)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)tMP_Text));
			}
		}

		public unsafe OnPointerListener hoverButtonPointer
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_hoverButtonPointer);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<OnPointerListener>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_hoverButtonPointer)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)onPointerListener));
			}
		}

		public unsafe EventTrigger eventTrigger
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_eventTrigger);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<EventTrigger>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_eventTrigger)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)eventTrigger));
			}
		}

		public unsafe string playerAccountId
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_playerAccountId);
				return IL2CPP.Il2CppStringToManaged(*(System.IntPtr*)num);
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_playerAccountId)), IL2CPP.ManagedStringToIl2Cpp(text));
			}
		}

		static PlayerDisplay()
		{
			Il2CppClassPointerStore<PlayerDisplay>.NativeClassPtr = IL2CPP.GetIl2CppNestedType(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "PlayerDisplay");
			IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<PlayerDisplay>.NativeClassPtr);
			NativeFieldInfoPtr_playerContainer = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<PlayerDisplay>.NativeClassPtr, "playerContainer");
			NativeFieldInfoPtr_playerDisplayObj = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<PlayerDisplay>.NativeClassPtr, "playerDisplayObj");
			NativeFieldInfoPtr_CanvasGroup = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<PlayerDisplay>.NativeClassPtr, "CanvasGroup");
			NativeFieldInfoPtr_ReadyText = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<PlayerDisplay>.NativeClassPtr, "ReadyText");
			NativeFieldInfoPtr_InQueueText = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<PlayerDisplay>.NativeClassPtr, "InQueueText");
			NativeFieldInfoPtr_hoverButtonPointer = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<PlayerDisplay>.NativeClassPtr, "hoverButtonPointer");
			NativeFieldInfoPtr_eventTrigger = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<PlayerDisplay>.NativeClassPtr, "eventTrigger");
			NativeFieldInfoPtr_playerAccountId = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<PlayerDisplay>.NativeClassPtr, "playerAccountId");
			NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<PlayerDisplay>.NativeClassPtr, 100669660);
		}

		[CallerCount(5410)]
		[CachedScanResults(RefRangeStart = 11, RefRangeEnd = 5421, XrefRangeStart = 11, XrefRangeEnd = 5421, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe PlayerDisplay()
			: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<PlayerDisplay>.NativeClassPtr))
		{
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		public PlayerDisplay(System.IntPtr pointer)
			: base(pointer)
		{
		}
	}

	[System.Serializable]
	public class TeammateDisplay : PlayerDisplay
	{
		private static readonly System.IntPtr NativeFieldInfoPtr_inviteButton;

		private static readonly System.IntPtr NativeFieldInfoPtr_loader;

		private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

		public unsafe InviteButton inviteButton
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_inviteButton);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<InviteButton>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_inviteButton)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)inviteButton));
			}
		}

		public unsafe TeammateLoader loader
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_loader);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<TeammateLoader>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_loader)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)teammateLoader));
			}
		}

		static TeammateDisplay()
		{
			Il2CppClassPointerStore<TeammateDisplay>.NativeClassPtr = IL2CPP.GetIl2CppNestedType(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "TeammateDisplay");
			IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<TeammateDisplay>.NativeClassPtr);
			NativeFieldInfoPtr_inviteButton = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<TeammateDisplay>.NativeClassPtr, "inviteButton");
			NativeFieldInfoPtr_loader = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<TeammateDisplay>.NativeClassPtr, "loader");
			NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<TeammateDisplay>.NativeClassPtr, 100669661);
		}

		[CallerCount(5410)]
		[CachedScanResults(RefRangeStart = 11, RefRangeEnd = 5421, XrefRangeStart = 11, XrefRangeEnd = 5421, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe TeammateDisplay()
			: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<TeammateDisplay>.NativeClassPtr))
		{
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		public TeammateDisplay(System.IntPtr pointer)
			: base(pointer)
		{
		}
	}

	[System.Serializable]
	public class CharacterSelectPanelButton : Il2CppSystem.Object
	{
		private static readonly System.IntPtr NativeFieldInfoPtr_Button;

		private static readonly System.IntPtr NativeFieldInfoPtr_Highlight;

		private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

		public unsafe Button Button
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_Button);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Button>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_Button)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)button));
			}
		}

		public unsafe Image Highlight
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_Highlight);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Image>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_Highlight)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)image));
			}
		}

		static CharacterSelectPanelButton()
		{
			Il2CppClassPointerStore<CharacterSelectPanelButton>.NativeClassPtr = IL2CPP.GetIl2CppNestedType(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "CharacterSelectPanelButton");
			IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<CharacterSelectPanelButton>.NativeClassPtr);
			NativeFieldInfoPtr_Button = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CharacterSelectPanelButton>.NativeClassPtr, "Button");
			NativeFieldInfoPtr_Highlight = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CharacterSelectPanelButton>.NativeClassPtr, "Highlight");
			NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<CharacterSelectPanelButton>.NativeClassPtr, 100669662);
		}

		[CallerCount(5410)]
		[CachedScanResults(RefRangeStart = 11, RefRangeEnd = 5421, XrefRangeStart = 11, XrefRangeEnd = 5421, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe CharacterSelectPanelButton()
			: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<CharacterSelectPanelButton>.NativeClassPtr))
		{
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		public CharacterSelectPanelButton(System.IntPtr pointer)
			: base(pointer)
		{
		}
	}

	[System.Serializable]
	public class CharacterSelectButton : Il2CppSystem.Object
	{
		private static readonly System.IntPtr NativeFieldInfoPtr_Button;

		private static readonly System.IntPtr NativeFieldInfoPtr_Text;

		private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

		public unsafe Button Button
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_Button);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Button>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_Button)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)button));
			}
		}

		public unsafe TMP_Text Text
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_Text);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<TMP_Text>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_Text)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)tMP_Text));
			}
		}

		static CharacterSelectButton()
		{
			Il2CppClassPointerStore<CharacterSelectButton>.NativeClassPtr = IL2CPP.GetIl2CppNestedType(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "CharacterSelectButton");
			IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<CharacterSelectButton>.NativeClassPtr);
			NativeFieldInfoPtr_Button = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CharacterSelectButton>.NativeClassPtr, "Button");
			NativeFieldInfoPtr_Text = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CharacterSelectButton>.NativeClassPtr, "Text");
			NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<CharacterSelectButton>.NativeClassPtr, 100669663);
		}

		[CallerCount(5410)]
		[CachedScanResults(RefRangeStart = 11, RefRangeEnd = 5421, XrefRangeStart = 11, XrefRangeEnd = 5421, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe CharacterSelectButton()
			: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<CharacterSelectButton>.NativeClassPtr))
		{
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		public CharacterSelectButton(System.IntPtr pointer)
			: base(pointer)
		{
		}
	}

	[System.Serializable]
	public class InviteButton : Il2CppSystem.Object
	{
		private static readonly System.IntPtr NativeFieldInfoPtr_transform;

		private static readonly System.IntPtr NativeFieldInfoPtr_CanvasGroup;

		private static readonly System.IntPtr NativeFieldInfoPtr_Button;

		private static readonly System.IntPtr NativeFieldInfoPtr_alphaFadeTimed;

		private static readonly System.IntPtr NativeFieldInfoPtr_Text;

		private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

		public unsafe Transform transform
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_transform);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Transform>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_transform)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)transform));
			}
		}

		public unsafe CanvasGroup CanvasGroup
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_CanvasGroup);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<CanvasGroup>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_CanvasGroup)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)canvasGroup));
			}
		}

		public unsafe Button Button
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_Button);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Button>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_Button)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)button));
			}
		}

		public unsafe UIAlphaFadeTimed alphaFadeTimed
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_alphaFadeTimed);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<UIAlphaFadeTimed>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_alphaFadeTimed)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)uIAlphaFadeTimed));
			}
		}

		public unsafe TMP_Text Text
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_Text);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<TMP_Text>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_Text)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)tMP_Text));
			}
		}

		static InviteButton()
		{
			Il2CppClassPointerStore<InviteButton>.NativeClassPtr = IL2CPP.GetIl2CppNestedType(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "InviteButton");
			IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<InviteButton>.NativeClassPtr);
			NativeFieldInfoPtr_transform = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<InviteButton>.NativeClassPtr, "transform");
			NativeFieldInfoPtr_CanvasGroup = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<InviteButton>.NativeClassPtr, "CanvasGroup");
			NativeFieldInfoPtr_Button = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<InviteButton>.NativeClassPtr, "Button");
			NativeFieldInfoPtr_alphaFadeTimed = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<InviteButton>.NativeClassPtr, "alphaFadeTimed");
			NativeFieldInfoPtr_Text = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<InviteButton>.NativeClassPtr, "Text");
			NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<InviteButton>.NativeClassPtr, 100669664);
		}

		[CallerCount(5410)]
		[CachedScanResults(RefRangeStart = 11, RefRangeEnd = 5421, XrefRangeStart = 11, XrefRangeEnd = 5421, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe InviteButton()
			: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<InviteButton>.NativeClassPtr))
		{
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		public InviteButton(System.IntPtr pointer)
			: base(pointer)
		{
		}
	}

	[System.Serializable]
	public class TeammateLoader : Il2CppSystem.Object
	{
		private static readonly System.IntPtr NativeFieldInfoPtr_canvasGroup;

		private static readonly System.IntPtr NativeFieldInfoPtr_alphaFade;

		private static readonly System.IntPtr NativeFieldInfoPtr_animationScript;

		private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

		public unsafe CanvasGroup canvasGroup
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_canvasGroup);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<CanvasGroup>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_canvasGroup)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)canvasGroup));
			}
		}

		public unsafe UIAlphaFade alphaFade
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_alphaFade);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<UIAlphaFade>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_alphaFade)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)uIAlphaFade));
			}
		}

		public unsafe RotateTransformZLoop animationScript
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_animationScript);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<RotateTransformZLoop>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_animationScript)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)rotateTransformZLoop));
			}
		}

		static TeammateLoader()
		{
			Il2CppClassPointerStore<TeammateLoader>.NativeClassPtr = IL2CPP.GetIl2CppNestedType(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "TeammateLoader");
			IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<TeammateLoader>.NativeClassPtr);
			NativeFieldInfoPtr_canvasGroup = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<TeammateLoader>.NativeClassPtr, "canvasGroup");
			NativeFieldInfoPtr_alphaFade = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<TeammateLoader>.NativeClassPtr, "alphaFade");
			NativeFieldInfoPtr_animationScript = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<TeammateLoader>.NativeClassPtr, "animationScript");
			NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<TeammateLoader>.NativeClassPtr, 100669665);
		}

		[CallerCount(5410)]
		[CachedScanResults(RefRangeStart = 11, RefRangeEnd = 5421, XrefRangeStart = 11, XrefRangeEnd = 5421, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe TeammateLoader()
			: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<TeammateLoader>.NativeClassPtr))
		{
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		public TeammateLoader(System.IntPtr pointer)
			: base(pointer)
		{
		}
	}

	[System.Serializable]
	public class ReadyButton : Il2CppSystem.Object
	{
		private static readonly System.IntPtr NativeFieldInfoPtr_Parent;

		private static readonly System.IntPtr NativeFieldInfoPtr_Button;

		private static readonly System.IntPtr NativeFieldInfoPtr_Text;

		private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

		public unsafe GameObject Parent
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_Parent);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<GameObject>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_Parent)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)gameObject));
			}
		}

		public unsafe Button Button
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_Button);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Button>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_Button)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)button));
			}
		}

		public unsafe TMP_Text Text
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_Text);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<TMP_Text>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_Text)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)tMP_Text));
			}
		}

		static ReadyButton()
		{
			Il2CppClassPointerStore<ReadyButton>.NativeClassPtr = IL2CPP.GetIl2CppNestedType(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "ReadyButton");
			IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<ReadyButton>.NativeClassPtr);
			NativeFieldInfoPtr_Parent = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ReadyButton>.NativeClassPtr, "Parent");
			NativeFieldInfoPtr_Button = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ReadyButton>.NativeClassPtr, "Button");
			NativeFieldInfoPtr_Text = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ReadyButton>.NativeClassPtr, "Text");
			NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ReadyButton>.NativeClassPtr, 100669666);
		}

		[CallerCount(5410)]
		[CachedScanResults(RefRangeStart = 11, RefRangeEnd = 5421, XrefRangeStart = 11, XrefRangeEnd = 5421, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe ReadyButton()
			: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<ReadyButton>.NativeClassPtr))
		{
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		public ReadyButton(System.IntPtr pointer)
			: base(pointer)
		{
		}
	}

	[System.Serializable]
	public class UnreadyButton : Il2CppSystem.Object
	{
		private static readonly System.IntPtr NativeFieldInfoPtr_Parent;

		private static readonly System.IntPtr NativeFieldInfoPtr_Button;

		private static readonly System.IntPtr NativeFieldInfoPtr_Text;

		private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

		public unsafe GameObject Parent
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_Parent);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<GameObject>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_Parent)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)gameObject));
			}
		}

		public unsafe Button Button
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_Button);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Button>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_Button)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)button));
			}
		}

		public unsafe TMP_Text Text
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_Text);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<TMP_Text>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_Text)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)tMP_Text));
			}
		}

		static UnreadyButton()
		{
			Il2CppClassPointerStore<UnreadyButton>.NativeClassPtr = IL2CPP.GetIl2CppNestedType(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "UnreadyButton");
			IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<UnreadyButton>.NativeClassPtr);
			NativeFieldInfoPtr_Parent = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UnreadyButton>.NativeClassPtr, "Parent");
			NativeFieldInfoPtr_Button = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UnreadyButton>.NativeClassPtr, "Button");
			NativeFieldInfoPtr_Text = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UnreadyButton>.NativeClassPtr, "Text");
			NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UnreadyButton>.NativeClassPtr, 100669667);
		}

		[CallerCount(5410)]
		[CachedScanResults(RefRangeStart = 11, RefRangeEnd = 5421, XrefRangeStart = 11, XrefRangeEnd = 5421, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe UnreadyButton()
			: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<UnreadyButton>.NativeClassPtr))
		{
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		public UnreadyButton(System.IntPtr pointer)
			: base(pointer)
		{
		}
	}

	[System.Serializable]
	public class CancelButton : Il2CppSystem.Object
	{
		private static readonly System.IntPtr NativeFieldInfoPtr_Parent;

		private static readonly System.IntPtr NativeFieldInfoPtr_Button;

		private static readonly System.IntPtr NativeFieldInfoPtr_Text;

		private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

		public unsafe GameObject Parent
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_Parent);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<GameObject>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_Parent)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)gameObject));
			}
		}

		public unsafe Button Button
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_Button);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Button>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_Button)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)button));
			}
		}

		public unsafe TMP_Text Text
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_Text);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<TMP_Text>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_Text)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)tMP_Text));
			}
		}

		static CancelButton()
		{
			Il2CppClassPointerStore<CancelButton>.NativeClassPtr = IL2CPP.GetIl2CppNestedType(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "CancelButton");
			IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<CancelButton>.NativeClassPtr);
			NativeFieldInfoPtr_Parent = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CancelButton>.NativeClassPtr, "Parent");
			NativeFieldInfoPtr_Button = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CancelButton>.NativeClassPtr, "Button");
			NativeFieldInfoPtr_Text = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CancelButton>.NativeClassPtr, "Text");
			NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<CancelButton>.NativeClassPtr, 100669668);
		}

		[CallerCount(5410)]
		[CachedScanResults(RefRangeStart = 11, RefRangeEnd = 5421, XrefRangeStart = 11, XrefRangeEnd = 5421, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe CancelButton()
			: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<CancelButton>.NativeClassPtr))
		{
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		public CancelButton(System.IntPtr pointer)
			: base(pointer)
		{
		}
	}

	[System.Serializable]
	public class PlayersOnline : Il2CppSystem.Object
	{
		private static readonly System.IntPtr NativeFieldInfoPtr_canvasGroup;

		private static readonly System.IntPtr NativeFieldInfoPtr_Text;

		private static readonly System.IntPtr NativeFieldInfoPtr_Icon;

		private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

		public unsafe CanvasGroup canvasGroup
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_canvasGroup);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<CanvasGroup>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_canvasGroup)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)canvasGroup));
			}
		}

		public unsafe TMP_Text Text
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_Text);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<TMP_Text>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_Text)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)tMP_Text));
			}
		}

		public unsafe Image Icon
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_Icon);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Image>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_Icon)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)image));
			}
		}

		static PlayersOnline()
		{
			Il2CppClassPointerStore<PlayersOnline>.NativeClassPtr = IL2CPP.GetIl2CppNestedType(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "PlayersOnline");
			IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<PlayersOnline>.NativeClassPtr);
			NativeFieldInfoPtr_canvasGroup = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<PlayersOnline>.NativeClassPtr, "canvasGroup");
			NativeFieldInfoPtr_Text = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<PlayersOnline>.NativeClassPtr, "Text");
			NativeFieldInfoPtr_Icon = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<PlayersOnline>.NativeClassPtr, "Icon");
			NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<PlayersOnline>.NativeClassPtr, 100669669);
		}

		[CallerCount(5410)]
		[CachedScanResults(RefRangeStart = 11, RefRangeEnd = 5421, XrefRangeStart = 11, XrefRangeEnd = 5421, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe PlayersOnline()
			: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<PlayersOnline>.NativeClassPtr))
		{
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		public PlayersOnline(System.IntPtr pointer)
			: base(pointer)
		{
		}
	}

	[System.Serializable]
	public class CurrencyPanel : Il2CppSystem.Object
	{
		private static readonly System.IntPtr NativeFieldInfoPtr_Text;

		private static readonly System.IntPtr NativeFieldInfoPtr_hoverTooltip;

		private static readonly System.IntPtr NativeFieldInfoPtr_tooltipAlphaFade;

		private static readonly System.IntPtr NativeFieldInfoPtr_tooltipTitleText;

		private static readonly System.IntPtr NativeFieldInfoPtr_tooltipDescText;

		private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

		public unsafe TMP_Text Text
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_Text);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<TMP_Text>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_Text)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)tMP_Text));
			}
		}

		public unsafe UIHoverTooltip hoverTooltip
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_hoverTooltip);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<UIHoverTooltip>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_hoverTooltip)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)uIHoverTooltip));
			}
		}

		public unsafe UIAlphaFade tooltipAlphaFade
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_tooltipAlphaFade);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<UIAlphaFade>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_tooltipAlphaFade)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)uIAlphaFade));
			}
		}

		public unsafe TMP_Text tooltipTitleText
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_tooltipTitleText);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<TMP_Text>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_tooltipTitleText)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)tMP_Text));
			}
		}

		public unsafe TMP_Text tooltipDescText
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_tooltipDescText);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<TMP_Text>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_tooltipDescText)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)tMP_Text));
			}
		}

		static CurrencyPanel()
		{
			Il2CppClassPointerStore<CurrencyPanel>.NativeClassPtr = IL2CPP.GetIl2CppNestedType(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "CurrencyPanel");
			IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<CurrencyPanel>.NativeClassPtr);
			NativeFieldInfoPtr_Text = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CurrencyPanel>.NativeClassPtr, "Text");
			NativeFieldInfoPtr_hoverTooltip = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CurrencyPanel>.NativeClassPtr, "hoverTooltip");
			NativeFieldInfoPtr_tooltipAlphaFade = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CurrencyPanel>.NativeClassPtr, "tooltipAlphaFade");
			NativeFieldInfoPtr_tooltipTitleText = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CurrencyPanel>.NativeClassPtr, "tooltipTitleText");
			NativeFieldInfoPtr_tooltipDescText = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CurrencyPanel>.NativeClassPtr, "tooltipDescText");
			NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<CurrencyPanel>.NativeClassPtr, 100669670);
		}

		[CallerCount(5410)]
		[CachedScanResults(RefRangeStart = 11, RefRangeEnd = 5421, XrefRangeStart = 11, XrefRangeEnd = 5421, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe CurrencyPanel()
			: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<CurrencyPanel>.NativeClassPtr))
		{
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		public CurrencyPanel(System.IntPtr pointer)
			: base(pointer)
		{
		}
	}

	[System.Serializable]
	public class FriendsPanel : Il2CppSystem.Object
	{
		[System.Serializable]
		public class FriendsListTab : Il2CppSystem.Object
		{
			private static readonly System.IntPtr NativeFieldInfoPtr_gameObject;

			private static readonly System.IntPtr NativeFieldInfoPtr_requestsParent;

			private static readonly System.IntPtr NativeFieldInfoPtr_friendsParent;

			private static readonly System.IntPtr NativeFieldInfoPtr_friendsScrollRect;

			private static readonly System.IntPtr NativeFieldInfoPtr_noFriendsText;

			private static readonly System.IntPtr NativeFieldInfoPtr_onlineHolder;

			private static readonly System.IntPtr NativeFieldInfoPtr_offlineHolder;

			private static readonly System.IntPtr NativeFieldInfoPtr_steamOnlineHolder;

			private static readonly System.IntPtr NativeFieldInfoPtr_steamOfflineHolder;

			private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

			public unsafe GameObject gameObject
			{
				get
				{
					nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_gameObject);
					System.IntPtr intPtr = *(System.IntPtr*)num;
					return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<GameObject>(intPtr) : null;
				}
				set
				{
					System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
					IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_gameObject)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)gameObject));
				}
			}

			public unsafe Transform requestsParent
			{
				get
				{
					nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_requestsParent);
					System.IntPtr intPtr = *(System.IntPtr*)num;
					return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Transform>(intPtr) : null;
				}
				set
				{
					System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
					IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_requestsParent)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)transform));
				}
			}

			public unsafe Transform friendsParent
			{
				get
				{
					nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_friendsParent);
					System.IntPtr intPtr = *(System.IntPtr*)num;
					return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Transform>(intPtr) : null;
				}
				set
				{
					System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
					IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_friendsParent)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)transform));
				}
			}

			public unsafe CustomScrollRect friendsScrollRect
			{
				get
				{
					nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_friendsScrollRect);
					System.IntPtr intPtr = *(System.IntPtr*)num;
					return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<CustomScrollRect>(intPtr) : null;
				}
				set
				{
					System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
					IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_friendsScrollRect)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)customScrollRect));
				}
			}

			public unsafe TMP_Text noFriendsText
			{
				get
				{
					nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_noFriendsText);
					System.IntPtr intPtr = *(System.IntPtr*)num;
					return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<TMP_Text>(intPtr) : null;
				}
				set
				{
					System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
					IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_noFriendsText)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)tMP_Text));
				}
			}

			public unsafe UILobbyFriendHolderEntry onlineHolder
			{
				get
				{
					nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_onlineHolder);
					System.IntPtr intPtr = *(System.IntPtr*)num;
					return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<UILobbyFriendHolderEntry>(intPtr) : null;
				}
				set
				{
					System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
					IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_onlineHolder)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)uILobbyFriendHolderEntry));
				}
			}

			public unsafe UILobbyFriendHolderEntry offlineHolder
			{
				get
				{
					nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_offlineHolder);
					System.IntPtr intPtr = *(System.IntPtr*)num;
					return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<UILobbyFriendHolderEntry>(intPtr) : null;
				}
				set
				{
					System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
					IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_offlineHolder)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)uILobbyFriendHolderEntry));
				}
			}

			public unsafe UILobbyFriendHolderEntry steamOnlineHolder
			{
				get
				{
					nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_steamOnlineHolder);
					System.IntPtr intPtr = *(System.IntPtr*)num;
					return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<UILobbyFriendHolderEntry>(intPtr) : null;
				}
				set
				{
					System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
					IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_steamOnlineHolder)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)uILobbyFriendHolderEntry));
				}
			}

			public unsafe UILobbyFriendHolderEntry steamOfflineHolder
			{
				get
				{
					nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_steamOfflineHolder);
					System.IntPtr intPtr = *(System.IntPtr*)num;
					return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<UILobbyFriendHolderEntry>(intPtr) : null;
				}
				set
				{
					System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
					IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_steamOfflineHolder)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)uILobbyFriendHolderEntry));
				}
			}

			static FriendsListTab()
			{
				Il2CppClassPointerStore<FriendsListTab>.NativeClassPtr = IL2CPP.GetIl2CppNestedType(Il2CppClassPointerStore<FriendsPanel>.NativeClassPtr, "FriendsListTab");
				IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<FriendsListTab>.NativeClassPtr);
				NativeFieldInfoPtr_gameObject = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<FriendsListTab>.NativeClassPtr, "gameObject");
				NativeFieldInfoPtr_requestsParent = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<FriendsListTab>.NativeClassPtr, "requestsParent");
				NativeFieldInfoPtr_friendsParent = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<FriendsListTab>.NativeClassPtr, "friendsParent");
				NativeFieldInfoPtr_friendsScrollRect = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<FriendsListTab>.NativeClassPtr, "friendsScrollRect");
				NativeFieldInfoPtr_noFriendsText = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<FriendsListTab>.NativeClassPtr, "noFriendsText");
				NativeFieldInfoPtr_onlineHolder = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<FriendsListTab>.NativeClassPtr, "onlineHolder");
				NativeFieldInfoPtr_offlineHolder = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<FriendsListTab>.NativeClassPtr, "offlineHolder");
				NativeFieldInfoPtr_steamOnlineHolder = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<FriendsListTab>.NativeClassPtr, "steamOnlineHolder");
				NativeFieldInfoPtr_steamOfflineHolder = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<FriendsListTab>.NativeClassPtr, "steamOfflineHolder");
				NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<FriendsListTab>.NativeClassPtr, 100669672);
			}

			[CallerCount(5410)]
			[CachedScanResults(RefRangeStart = 11, RefRangeEnd = 5421, XrefRangeStart = 11, XrefRangeEnd = 5421, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
			public unsafe FriendsListTab()
				: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<FriendsListTab>.NativeClassPtr))
			{
				System.IntPtr* ptr = null;
				Unsafe.SkipInit(out System.IntPtr intPtr2);
				System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
				Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			}

			public FriendsListTab(System.IntPtr pointer)
				: base(pointer)
			{
			}
		}

		[System.Serializable]
		public class AddFriendPanel : Il2CppSystem.Object
		{
			private static readonly System.IntPtr NativeFieldInfoPtr_canvasGroup;

			private static readonly System.IntPtr NativeFieldInfoPtr_alphaFade;

			private static readonly System.IntPtr NativeFieldInfoPtr_posLerpFade;

			private static readonly System.IntPtr NativeFieldInfoPtr_addFriendText;

			private static readonly System.IntPtr NativeFieldInfoPtr_playerIdField;

			private static readonly System.IntPtr NativeFieldInfoPtr_sendRequestButton;

			private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

			public unsafe CanvasGroup canvasGroup
			{
				get
				{
					nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_canvasGroup);
					System.IntPtr intPtr = *(System.IntPtr*)num;
					return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<CanvasGroup>(intPtr) : null;
				}
				set
				{
					System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
					IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_canvasGroup)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)canvasGroup));
				}
			}

			public unsafe UIAlphaFade alphaFade
			{
				get
				{
					nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_alphaFade);
					System.IntPtr intPtr = *(System.IntPtr*)num;
					return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<UIAlphaFade>(intPtr) : null;
				}
				set
				{
					System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
					IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_alphaFade)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)uIAlphaFade));
				}
			}

			public unsafe UIPosLerpFade posLerpFade
			{
				get
				{
					nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_posLerpFade);
					System.IntPtr intPtr = *(System.IntPtr*)num;
					return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<UIPosLerpFade>(intPtr) : null;
				}
				set
				{
					System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
					IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_posLerpFade)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)uIPosLerpFade));
				}
			}

			public unsafe TMP_Text addFriendText
			{
				get
				{
					nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_addFriendText);
					System.IntPtr intPtr = *(System.IntPtr*)num;
					return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<TMP_Text>(intPtr) : null;
				}
				set
				{
					System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
					IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_addFriendText)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)tMP_Text));
				}
			}

			public unsafe TMP_InputField playerIdField
			{
				get
				{
					nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_playerIdField);
					System.IntPtr intPtr = *(System.IntPtr*)num;
					return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<TMP_InputField>(intPtr) : null;
				}
				set
				{
					System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
					IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_playerIdField)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)tMP_InputField));
				}
			}

			public unsafe Button sendRequestButton
			{
				get
				{
					nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_sendRequestButton);
					System.IntPtr intPtr = *(System.IntPtr*)num;
					return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Button>(intPtr) : null;
				}
				set
				{
					System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
					IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_sendRequestButton)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)button));
				}
			}

			static AddFriendPanel()
			{
				Il2CppClassPointerStore<AddFriendPanel>.NativeClassPtr = IL2CPP.GetIl2CppNestedType(Il2CppClassPointerStore<FriendsPanel>.NativeClassPtr, "AddFriendPanel");
				IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<AddFriendPanel>.NativeClassPtr);
				NativeFieldInfoPtr_canvasGroup = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<AddFriendPanel>.NativeClassPtr, "canvasGroup");
				NativeFieldInfoPtr_alphaFade = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<AddFriendPanel>.NativeClassPtr, "alphaFade");
				NativeFieldInfoPtr_posLerpFade = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<AddFriendPanel>.NativeClassPtr, "posLerpFade");
				NativeFieldInfoPtr_addFriendText = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<AddFriendPanel>.NativeClassPtr, "addFriendText");
				NativeFieldInfoPtr_playerIdField = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<AddFriendPanel>.NativeClassPtr, "playerIdField");
				NativeFieldInfoPtr_sendRequestButton = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<AddFriendPanel>.NativeClassPtr, "sendRequestButton");
				NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<AddFriendPanel>.NativeClassPtr, 100669673);
			}

			[CallerCount(5410)]
			[CachedScanResults(RefRangeStart = 11, RefRangeEnd = 5421, XrefRangeStart = 11, XrefRangeEnd = 5421, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
			public unsafe AddFriendPanel()
				: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<AddFriendPanel>.NativeClassPtr))
			{
				System.IntPtr* ptr = null;
				Unsafe.SkipInit(out System.IntPtr intPtr2);
				System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
				Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			}

			public AddFriendPanel(System.IntPtr pointer)
				: base(pointer)
			{
			}
		}

		[System.Serializable]
		public class JoinLobbyPanel : Il2CppSystem.Object
		{
			private static readonly System.IntPtr NativeFieldInfoPtr_canvasGroup;

			private static readonly System.IntPtr NativeFieldInfoPtr_alphaFade;

			private static readonly System.IntPtr NativeFieldInfoPtr_posLerpFade;

			private static readonly System.IntPtr NativeFieldInfoPtr_lobbyCodeField;

			private static readonly System.IntPtr NativeFieldInfoPtr_joinButton;

			private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

			public unsafe CanvasGroup canvasGroup
			{
				get
				{
					nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_canvasGroup);
					System.IntPtr intPtr = *(System.IntPtr*)num;
					return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<CanvasGroup>(intPtr) : null;
				}
				set
				{
					System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
					IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_canvasGroup)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)canvasGroup));
				}
			}

			public unsafe UIAlphaFade alphaFade
			{
				get
				{
					nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_alphaFade);
					System.IntPtr intPtr = *(System.IntPtr*)num;
					return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<UIAlphaFade>(intPtr) : null;
				}
				set
				{
					System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
					IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_alphaFade)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)uIAlphaFade));
				}
			}

			public unsafe UIPosLerpFade posLerpFade
			{
				get
				{
					nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_posLerpFade);
					System.IntPtr intPtr = *(System.IntPtr*)num;
					return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<UIPosLerpFade>(intPtr) : null;
				}
				set
				{
					System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
					IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_posLerpFade)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)uIPosLerpFade));
				}
			}

			public unsafe TMP_InputField lobbyCodeField
			{
				get
				{
					nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_lobbyCodeField);
					System.IntPtr intPtr = *(System.IntPtr*)num;
					return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<TMP_InputField>(intPtr) : null;
				}
				set
				{
					System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
					IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_lobbyCodeField)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)tMP_InputField));
				}
			}

			public unsafe Button joinButton
			{
				get
				{
					nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_joinButton);
					System.IntPtr intPtr = *(System.IntPtr*)num;
					return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Button>(intPtr) : null;
				}
				set
				{
					System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
					IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_joinButton)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)button));
				}
			}

			static JoinLobbyPanel()
			{
				Il2CppClassPointerStore<JoinLobbyPanel>.NativeClassPtr = IL2CPP.GetIl2CppNestedType(Il2CppClassPointerStore<FriendsPanel>.NativeClassPtr, "JoinLobbyPanel");
				IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<JoinLobbyPanel>.NativeClassPtr);
				NativeFieldInfoPtr_canvasGroup = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<JoinLobbyPanel>.NativeClassPtr, "canvasGroup");
				NativeFieldInfoPtr_alphaFade = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<JoinLobbyPanel>.NativeClassPtr, "alphaFade");
				NativeFieldInfoPtr_posLerpFade = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<JoinLobbyPanel>.NativeClassPtr, "posLerpFade");
				NativeFieldInfoPtr_lobbyCodeField = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<JoinLobbyPanel>.NativeClassPtr, "lobbyCodeField");
				NativeFieldInfoPtr_joinButton = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<JoinLobbyPanel>.NativeClassPtr, "joinButton");
				NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<JoinLobbyPanel>.NativeClassPtr, 100669674);
			}

			[CallerCount(5410)]
			[CachedScanResults(RefRangeStart = 11, RefRangeEnd = 5421, XrefRangeStart = 11, XrefRangeEnd = 5421, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
			public unsafe JoinLobbyPanel()
				: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<JoinLobbyPanel>.NativeClassPtr))
			{
				System.IntPtr* ptr = null;
				Unsafe.SkipInit(out System.IntPtr intPtr2);
				System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
				Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			}

			public JoinLobbyPanel(System.IntPtr pointer)
				: base(pointer)
			{
			}
		}

		private static readonly System.IntPtr NativeFieldInfoPtr_canvasGroup;

		private static readonly System.IntPtr NativeFieldInfoPtr_alphaFade;

		private static readonly System.IntPtr NativeFieldInfoPtr_posLerpFade;

		private static readonly System.IntPtr NativeFieldInfoPtr_playerUsernameLinkButton;

		private static readonly System.IntPtr NativeFieldInfoPtr_playerUsernameId;

		private static readonly System.IntPtr NativeFieldInfoPtr_playerStateOnlineIcon;

		private static readonly System.IntPtr NativeFieldInfoPtr_playerStateText;

		private static readonly System.IntPtr NativeFieldInfoPtr_playerAvatarIcon;

		private static readonly System.IntPtr NativeFieldInfoPtr_playerAvatarAspectRatio;

		private static readonly System.IntPtr NativeFieldInfoPtr__hideLobbyCodeButton;

		private static readonly System.IntPtr NativeFieldInfoPtr__leaveLobbyButton;

		private static readonly System.IntPtr NativeFieldInfoPtr_closeFillButton;

		private static readonly System.IntPtr NativeFieldInfoPtr_closeButton;

		private static readonly System.IntPtr NativeFieldInfoPtr_friendsListTab;

		private static readonly System.IntPtr NativeFieldInfoPtr_addFriendPopup;

		private static readonly System.IntPtr NativeFieldInfoPtr_joinLobbyPopup;

		private static readonly System.IntPtr NativeFieldInfoPtr_guestLogInContainer;

		private static readonly System.IntPtr NativeFieldInfoPtr_guestLogInText;

		private static readonly System.IntPtr NativeFieldInfoPtr_guestLogInButton;

		private static readonly System.IntPtr NativeFieldInfoPtr_guestLogInButtonText;

		private static readonly System.IntPtr NativeFieldInfoPtr_addFriendButton;

		private static readonly System.IntPtr NativeFieldInfoPtr_joinLobbyButton;

		private static readonly System.IntPtr NativeFieldInfoPtr_addFriendCloseButton;

		private static readonly System.IntPtr NativeFieldInfoPtr_joinLobbyCloseButton;

		private static readonly System.IntPtr NativeFieldInfoPtr_addFriendButtonNormalColors;

		private static readonly System.IntPtr NativeFieldInfoPtr_joinLobbyButtonNormalColors;

		private static readonly System.IntPtr NativeFieldInfoPtr_lobbyIdText;

		private static readonly System.IntPtr NativeFieldInfoPtr_lobbyCodeLinkButton;

		private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

		public unsafe CanvasGroup canvasGroup
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_canvasGroup);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<CanvasGroup>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_canvasGroup)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)canvasGroup));
			}
		}

		public unsafe UIAlphaFade alphaFade
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_alphaFade);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<UIAlphaFade>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_alphaFade)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)uIAlphaFade));
			}
		}

		public unsafe UIPosLerpFade posLerpFade
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_posLerpFade);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<UIPosLerpFade>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_posLerpFade)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)uIPosLerpFade));
			}
		}

		public unsafe Button playerUsernameLinkButton
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_playerUsernameLinkButton);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Button>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_playerUsernameLinkButton)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)button));
			}
		}

		public unsafe TMP_Text playerUsernameId
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_playerUsernameId);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<TMP_Text>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_playerUsernameId)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)tMP_Text));
			}
		}

		public unsafe Image playerStateOnlineIcon
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_playerStateOnlineIcon);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Image>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_playerStateOnlineIcon)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)image));
			}
		}

		public unsafe TMP_Text playerStateText
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_playerStateText);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<TMP_Text>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_playerStateText)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)tMP_Text));
			}
		}

		public unsafe RawImage playerAvatarIcon
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_playerAvatarIcon);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<RawImage>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_playerAvatarIcon)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)rawImage));
			}
		}

		public unsafe AspectRatioFitter playerAvatarAspectRatio
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_playerAvatarAspectRatio);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<AspectRatioFitter>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_playerAvatarAspectRatio)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)aspectRatioFitter));
			}
		}

		public unsafe Button _hideLobbyCodeButton
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__hideLobbyCodeButton);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Button>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__hideLobbyCodeButton)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)button));
			}
		}

		public unsafe Button _leaveLobbyButton
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__leaveLobbyButton);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Button>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__leaveLobbyButton)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)button));
			}
		}

		public unsafe Button closeFillButton
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_closeFillButton);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Button>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_closeFillButton)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)button));
			}
		}

		public unsafe Button closeButton
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_closeButton);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Button>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_closeButton)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)button));
			}
		}

		public unsafe FriendsListTab friendsListTab
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_friendsListTab);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<FriendsListTab>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_friendsListTab)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)friendsListTab));
			}
		}

		public unsafe AddFriendPanel addFriendPopup
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_addFriendPopup);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<AddFriendPanel>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_addFriendPopup)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)addFriendPanel));
			}
		}

		public unsafe JoinLobbyPanel joinLobbyPopup
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_joinLobbyPopup);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<JoinLobbyPanel>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_joinLobbyPopup)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)joinLobbyPanel));
			}
		}

		public unsafe GameObject guestLogInContainer
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_guestLogInContainer);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<GameObject>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_guestLogInContainer)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)gameObject));
			}
		}

		public unsafe TMP_Text guestLogInText
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_guestLogInText);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<TMP_Text>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_guestLogInText)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)tMP_Text));
			}
		}

		public unsafe Button guestLogInButton
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_guestLogInButton);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Button>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_guestLogInButton)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)button));
			}
		}

		public unsafe TMP_Text guestLogInButtonText
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_guestLogInButtonText);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<TMP_Text>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_guestLogInButtonText)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)tMP_Text));
			}
		}

		public unsafe MultiGraphicButton addFriendButton
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_addFriendButton);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<MultiGraphicButton>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_addFriendButton)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)multiGraphicButton));
			}
		}

		public unsafe MultiGraphicButton joinLobbyButton
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_joinLobbyButton);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<MultiGraphicButton>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_joinLobbyButton)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)multiGraphicButton));
			}
		}

		public unsafe Button addFriendCloseButton
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_addFriendCloseButton);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Button>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_addFriendCloseButton)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)button));
			}
		}

		public unsafe Button joinLobbyCloseButton
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_joinLobbyCloseButton);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Button>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_joinLobbyCloseButton)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)button));
			}
		}

		public unsafe Il2CppStructArray<Color> addFriendButtonNormalColors
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_addFriendButtonNormalColors);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppStructArray<Color>>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_addFriendButtonNormalColors)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)val));
			}
		}

		public unsafe Il2CppStructArray<Color> joinLobbyButtonNormalColors
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_joinLobbyButtonNormalColors);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppStructArray<Color>>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_joinLobbyButtonNormalColors)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)val));
			}
		}

		public unsafe TMP_Text lobbyIdText
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_lobbyIdText);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<TMP_Text>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_lobbyIdText)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)tMP_Text));
			}
		}

		public unsafe Button lobbyCodeLinkButton
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_lobbyCodeLinkButton);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Button>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_lobbyCodeLinkButton)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)button));
			}
		}

		static FriendsPanel()
		{
			Il2CppClassPointerStore<FriendsPanel>.NativeClassPtr = IL2CPP.GetIl2CppNestedType(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "FriendsPanel");
			IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<FriendsPanel>.NativeClassPtr);
			NativeFieldInfoPtr_canvasGroup = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<FriendsPanel>.NativeClassPtr, "canvasGroup");
			NativeFieldInfoPtr_alphaFade = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<FriendsPanel>.NativeClassPtr, "alphaFade");
			NativeFieldInfoPtr_posLerpFade = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<FriendsPanel>.NativeClassPtr, "posLerpFade");
			NativeFieldInfoPtr_playerUsernameLinkButton = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<FriendsPanel>.NativeClassPtr, "playerUsernameLinkButton");
			NativeFieldInfoPtr_playerUsernameId = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<FriendsPanel>.NativeClassPtr, "playerUsernameId");
			NativeFieldInfoPtr_playerStateOnlineIcon = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<FriendsPanel>.NativeClassPtr, "playerStateOnlineIcon");
			NativeFieldInfoPtr_playerStateText = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<FriendsPanel>.NativeClassPtr, "playerStateText");
			NativeFieldInfoPtr_playerAvatarIcon = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<FriendsPanel>.NativeClassPtr, "playerAvatarIcon");
			NativeFieldInfoPtr_playerAvatarAspectRatio = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<FriendsPanel>.NativeClassPtr, "playerAvatarAspectRatio");
			NativeFieldInfoPtr__hideLobbyCodeButton = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<FriendsPanel>.NativeClassPtr, "_hideLobbyCodeButton");
			NativeFieldInfoPtr__leaveLobbyButton = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<FriendsPanel>.NativeClassPtr, "_leaveLobbyButton");
			NativeFieldInfoPtr_closeFillButton = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<FriendsPanel>.NativeClassPtr, "closeFillButton");
			NativeFieldInfoPtr_closeButton = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<FriendsPanel>.NativeClassPtr, "closeButton");
			NativeFieldInfoPtr_friendsListTab = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<FriendsPanel>.NativeClassPtr, "friendsListTab");
			NativeFieldInfoPtr_addFriendPopup = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<FriendsPanel>.NativeClassPtr, "addFriendPopup");
			NativeFieldInfoPtr_joinLobbyPopup = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<FriendsPanel>.NativeClassPtr, "joinLobbyPopup");
			NativeFieldInfoPtr_guestLogInContainer = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<FriendsPanel>.NativeClassPtr, "guestLogInContainer");
			NativeFieldInfoPtr_guestLogInText = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<FriendsPanel>.NativeClassPtr, "guestLogInText");
			NativeFieldInfoPtr_guestLogInButton = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<FriendsPanel>.NativeClassPtr, "guestLogInButton");
			NativeFieldInfoPtr_guestLogInButtonText = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<FriendsPanel>.NativeClassPtr, "guestLogInButtonText");
			NativeFieldInfoPtr_addFriendButton = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<FriendsPanel>.NativeClassPtr, "addFriendButton");
			NativeFieldInfoPtr_joinLobbyButton = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<FriendsPanel>.NativeClassPtr, "joinLobbyButton");
			NativeFieldInfoPtr_addFriendCloseButton = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<FriendsPanel>.NativeClassPtr, "addFriendCloseButton");
			NativeFieldInfoPtr_joinLobbyCloseButton = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<FriendsPanel>.NativeClassPtr, "joinLobbyCloseButton");
			NativeFieldInfoPtr_addFriendButtonNormalColors = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<FriendsPanel>.NativeClassPtr, "addFriendButtonNormalColors");
			NativeFieldInfoPtr_joinLobbyButtonNormalColors = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<FriendsPanel>.NativeClassPtr, "joinLobbyButtonNormalColors");
			NativeFieldInfoPtr_lobbyIdText = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<FriendsPanel>.NativeClassPtr, "lobbyIdText");
			NativeFieldInfoPtr_lobbyCodeLinkButton = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<FriendsPanel>.NativeClassPtr, "lobbyCodeLinkButton");
			NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<FriendsPanel>.NativeClassPtr, 100669671);
		}

		[CallerCount(5410)]
		[CachedScanResults(RefRangeStart = 11, RefRangeEnd = 5421, XrefRangeStart = 11, XrefRangeEnd = 5421, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe FriendsPanel()
			: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<FriendsPanel>.NativeClassPtr))
		{
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		public FriendsPanel(System.IntPtr pointer)
			: base(pointer)
		{
		}
	}

	[System.Serializable]
	public class FriendsPreview : Il2CppSystem.Object
	{
		[System.Serializable]
		public class PreviewEntry : Il2CppSystem.Object
		{
			private static readonly System.IntPtr NativeFieldInfoPtr_gameObject;

			private static readonly System.IntPtr NativeFieldInfoPtr_rawImage;

			private static readonly System.IntPtr NativeFieldInfoPtr_aspectRatio;

			private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

			public unsafe GameObject gameObject
			{
				get
				{
					nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_gameObject);
					System.IntPtr intPtr = *(System.IntPtr*)num;
					return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<GameObject>(intPtr) : null;
				}
				set
				{
					System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
					IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_gameObject)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)gameObject));
				}
			}

			public unsafe RawImage rawImage
			{
				get
				{
					nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_rawImage);
					System.IntPtr intPtr = *(System.IntPtr*)num;
					return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<RawImage>(intPtr) : null;
				}
				set
				{
					System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
					IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_rawImage)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)rawImage));
				}
			}

			public unsafe AspectRatioFitter aspectRatio
			{
				get
				{
					nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_aspectRatio);
					System.IntPtr intPtr = *(System.IntPtr*)num;
					return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<AspectRatioFitter>(intPtr) : null;
				}
				set
				{
					System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
					IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_aspectRatio)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)aspectRatioFitter));
				}
			}

			static PreviewEntry()
			{
				Il2CppClassPointerStore<PreviewEntry>.NativeClassPtr = IL2CPP.GetIl2CppNestedType(Il2CppClassPointerStore<FriendsPreview>.NativeClassPtr, "PreviewEntry");
				IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<PreviewEntry>.NativeClassPtr);
				NativeFieldInfoPtr_gameObject = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<PreviewEntry>.NativeClassPtr, "gameObject");
				NativeFieldInfoPtr_rawImage = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<PreviewEntry>.NativeClassPtr, "rawImage");
				NativeFieldInfoPtr_aspectRatio = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<PreviewEntry>.NativeClassPtr, "aspectRatio");
				NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<PreviewEntry>.NativeClassPtr, 100669676);
			}

			[CallerCount(5410)]
			[CachedScanResults(RefRangeStart = 11, RefRangeEnd = 5421, XrefRangeStart = 11, XrefRangeEnd = 5421, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
			public unsafe PreviewEntry()
				: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<PreviewEntry>.NativeClassPtr))
			{
				System.IntPtr* ptr = null;
				Unsafe.SkipInit(out System.IntPtr intPtr2);
				System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
				Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			}

			public PreviewEntry(System.IntPtr pointer)
				: base(pointer)
			{
			}
		}

		private static readonly System.IntPtr NativeFieldInfoPtr_gameObject;

		private static readonly System.IntPtr NativeFieldInfoPtr_containerRect;

		private static readonly System.IntPtr NativeFieldInfoPtr_previewEntries;

		private static readonly System.IntPtr NativeFieldInfoPtr_countText;

		private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

		public unsafe GameObject gameObject
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_gameObject);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<GameObject>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_gameObject)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)gameObject));
			}
		}

		public unsafe RectTransform containerRect
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_containerRect);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<RectTransform>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_containerRect)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)rectTransform));
			}
		}

		public unsafe Il2CppReferenceArray<PreviewEntry> previewEntries
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_previewEntries);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppReferenceArray<PreviewEntry>>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_previewEntries)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)val));
			}
		}

		public unsafe TMP_Text countText
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_countText);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<TMP_Text>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_countText)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)tMP_Text));
			}
		}

		static FriendsPreview()
		{
			Il2CppClassPointerStore<FriendsPreview>.NativeClassPtr = IL2CPP.GetIl2CppNestedType(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "FriendsPreview");
			IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<FriendsPreview>.NativeClassPtr);
			NativeFieldInfoPtr_gameObject = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<FriendsPreview>.NativeClassPtr, "gameObject");
			NativeFieldInfoPtr_containerRect = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<FriendsPreview>.NativeClassPtr, "containerRect");
			NativeFieldInfoPtr_previewEntries = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<FriendsPreview>.NativeClassPtr, "previewEntries");
			NativeFieldInfoPtr_countText = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<FriendsPreview>.NativeClassPtr, "countText");
			NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<FriendsPreview>.NativeClassPtr, 100669675);
		}

		[CallerCount(5410)]
		[CachedScanResults(RefRangeStart = 11, RefRangeEnd = 5421, XrefRangeStart = 11, XrefRangeEnd = 5421, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe FriendsPreview()
			: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<FriendsPreview>.NativeClassPtr))
		{
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		public FriendsPreview(System.IntPtr pointer)
			: base(pointer)
		{
		}
	}

	[System.Serializable]
	public class FriendInviteLobbyPopup : Il2CppSystem.Object
	{
		private static readonly System.IntPtr NativeFieldInfoPtr_canvasGroup;

		private static readonly System.IntPtr NativeFieldInfoPtr_posLerpFade;

		private static readonly System.IntPtr NativeFieldInfoPtr_invitationText;

		private static readonly System.IntPtr NativeFieldInfoPtr_joinButton;

		private static readonly System.IntPtr NativeFieldInfoPtr_dismissButton;

		private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

		public unsafe CanvasGroup canvasGroup
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_canvasGroup);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<CanvasGroup>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_canvasGroup)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)canvasGroup));
			}
		}

		public unsafe UIPosLerpFade posLerpFade
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_posLerpFade);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<UIPosLerpFade>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_posLerpFade)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)uIPosLerpFade));
			}
		}

		public unsafe TMP_Text invitationText
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_invitationText);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<TMP_Text>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_invitationText)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)tMP_Text));
			}
		}

		public unsafe Button joinButton
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_joinButton);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Button>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_joinButton)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)button));
			}
		}

		public unsafe Button dismissButton
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_dismissButton);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Button>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_dismissButton)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)button));
			}
		}

		static FriendInviteLobbyPopup()
		{
			Il2CppClassPointerStore<FriendInviteLobbyPopup>.NativeClassPtr = IL2CPP.GetIl2CppNestedType(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "FriendInviteLobbyPopup");
			IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<FriendInviteLobbyPopup>.NativeClassPtr);
			NativeFieldInfoPtr_canvasGroup = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<FriendInviteLobbyPopup>.NativeClassPtr, "canvasGroup");
			NativeFieldInfoPtr_posLerpFade = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<FriendInviteLobbyPopup>.NativeClassPtr, "posLerpFade");
			NativeFieldInfoPtr_invitationText = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<FriendInviteLobbyPopup>.NativeClassPtr, "invitationText");
			NativeFieldInfoPtr_joinButton = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<FriendInviteLobbyPopup>.NativeClassPtr, "joinButton");
			NativeFieldInfoPtr_dismissButton = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<FriendInviteLobbyPopup>.NativeClassPtr, "dismissButton");
			NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<FriendInviteLobbyPopup>.NativeClassPtr, 100669677);
		}

		[CallerCount(5410)]
		[CachedScanResults(RefRangeStart = 11, RefRangeEnd = 5421, XrefRangeStart = 11, XrefRangeEnd = 5421, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe FriendInviteLobbyPopup()
			: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<FriendInviteLobbyPopup>.NativeClassPtr))
		{
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		public FriendInviteLobbyPopup(System.IntPtr pointer)
			: base(pointer)
		{
		}
	}

	[System.Serializable]
	public class SteamInvitePanel : Il2CppSystem.Object
	{
		private static readonly System.IntPtr NativeFieldInfoPtr_canvasGroup;

		private static readonly System.IntPtr NativeFieldInfoPtr_alphaFade;

		private static readonly System.IntPtr NativeFieldInfoPtr_posLerpFade;

		private static readonly System.IntPtr NativeFieldInfoPtr_transform;

		private static readonly System.IntPtr NativeFieldInfoPtr_lobbyIdText;

		private static readonly System.IntPtr NativeFieldInfoPtr_steamFriendsParent;

		private static readonly System.IntPtr NativeFieldInfoPtr_closeFillButton;

		private static readonly System.IntPtr NativeFieldInfoPtr_closeButton;

		private static readonly System.IntPtr NativeFieldInfoPtr_linkButton;

		private static readonly System.IntPtr NativeFieldInfoPtr_lobbyCodeField;

		private static readonly System.IntPtr NativeFieldInfoPtr_joinButton;

		private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

		public unsafe CanvasGroup canvasGroup
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_canvasGroup);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<CanvasGroup>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_canvasGroup)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)canvasGroup));
			}
		}

		public unsafe UIAlphaFade alphaFade
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_alphaFade);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<UIAlphaFade>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_alphaFade)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)uIAlphaFade));
			}
		}

		public unsafe UIPosLerpFade posLerpFade
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_posLerpFade);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<UIPosLerpFade>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_posLerpFade)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)uIPosLerpFade));
			}
		}

		public unsafe Transform transform
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_transform);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Transform>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_transform)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)transform));
			}
		}

		public unsafe TMP_Text lobbyIdText
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_lobbyIdText);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<TMP_Text>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_lobbyIdText)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)tMP_Text));
			}
		}

		public unsafe Transform steamFriendsParent
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_steamFriendsParent);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Transform>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_steamFriendsParent)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)transform));
			}
		}

		public unsafe Button closeFillButton
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_closeFillButton);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Button>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_closeFillButton)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)button));
			}
		}

		public unsafe Button closeButton
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_closeButton);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Button>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_closeButton)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)button));
			}
		}

		public unsafe Button linkButton
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_linkButton);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Button>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_linkButton)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)button));
			}
		}

		public unsafe TMP_InputField lobbyCodeField
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_lobbyCodeField);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<TMP_InputField>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_lobbyCodeField)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)tMP_InputField));
			}
		}

		public unsafe Button joinButton
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_joinButton);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Button>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_joinButton)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)button));
			}
		}

		static SteamInvitePanel()
		{
			Il2CppClassPointerStore<SteamInvitePanel>.NativeClassPtr = IL2CPP.GetIl2CppNestedType(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "SteamInvitePanel");
			IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<SteamInvitePanel>.NativeClassPtr);
			NativeFieldInfoPtr_canvasGroup = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<SteamInvitePanel>.NativeClassPtr, "canvasGroup");
			NativeFieldInfoPtr_alphaFade = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<SteamInvitePanel>.NativeClassPtr, "alphaFade");
			NativeFieldInfoPtr_posLerpFade = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<SteamInvitePanel>.NativeClassPtr, "posLerpFade");
			NativeFieldInfoPtr_transform = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<SteamInvitePanel>.NativeClassPtr, "transform");
			NativeFieldInfoPtr_lobbyIdText = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<SteamInvitePanel>.NativeClassPtr, "lobbyIdText");
			NativeFieldInfoPtr_steamFriendsParent = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<SteamInvitePanel>.NativeClassPtr, "steamFriendsParent");
			NativeFieldInfoPtr_closeFillButton = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<SteamInvitePanel>.NativeClassPtr, "closeFillButton");
			NativeFieldInfoPtr_closeButton = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<SteamInvitePanel>.NativeClassPtr, "closeButton");
			NativeFieldInfoPtr_linkButton = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<SteamInvitePanel>.NativeClassPtr, "linkButton");
			NativeFieldInfoPtr_lobbyCodeField = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<SteamInvitePanel>.NativeClassPtr, "lobbyCodeField");
			NativeFieldInfoPtr_joinButton = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<SteamInvitePanel>.NativeClassPtr, "joinButton");
			NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<SteamInvitePanel>.NativeClassPtr, 100669678);
		}

		[CallerCount(5410)]
		[CachedScanResults(RefRangeStart = 11, RefRangeEnd = 5421, XrefRangeStart = 11, XrefRangeEnd = 5421, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe SteamInvitePanel()
			: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<SteamInvitePanel>.NativeClassPtr))
		{
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		public SteamInvitePanel(System.IntPtr pointer)
			: base(pointer)
		{
		}
	}

	[System.Serializable]
	public class GameModePlayButton : Il2CppSystem.Object
	{
		private static readonly System.IntPtr NativeFieldInfoPtr_canvasGroup;

		private static readonly System.IntPtr NativeFieldInfoPtr_button;

		private static readonly System.IntPtr NativeFieldInfoPtr_gameModeText;

		private static readonly System.IntPtr NativeFieldInfoPtr_nameText;

		private static readonly System.IntPtr NativeFieldInfoPtr_typeText;

		private static readonly System.IntPtr NativeFieldInfoPtr_illustrationImage;

		private static readonly System.IntPtr NativeFieldInfoPtr_eventHeaderObj;

		private static readonly System.IntPtr NativeFieldInfoPtr_eventText;

		private static readonly System.IntPtr NativeFieldInfoPtr_eventTimeText;

		private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

		public unsafe CanvasGroup canvasGroup
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_canvasGroup);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<CanvasGroup>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_canvasGroup)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)canvasGroup));
			}
		}

		public unsafe Button button
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_button);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Button>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_button)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)button));
			}
		}

		public unsafe TMP_Text gameModeText
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_gameModeText);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<TMP_Text>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_gameModeText)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)tMP_Text));
			}
		}

		public unsafe TMP_Text nameText
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_nameText);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<TMP_Text>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_nameText)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)tMP_Text));
			}
		}

		public unsafe TMP_Text typeText
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_typeText);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<TMP_Text>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_typeText)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)tMP_Text));
			}
		}

		public unsafe Image illustrationImage
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_illustrationImage);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Image>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_illustrationImage)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)image));
			}
		}

		public unsafe GameObject eventHeaderObj
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_eventHeaderObj);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<GameObject>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_eventHeaderObj)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)gameObject));
			}
		}

		public unsafe TMP_Text eventText
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_eventText);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<TMP_Text>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_eventText)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)tMP_Text));
			}
		}

		public unsafe TMP_Text eventTimeText
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_eventTimeText);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<TMP_Text>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_eventTimeText)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)tMP_Text));
			}
		}

		static GameModePlayButton()
		{
			Il2CppClassPointerStore<GameModePlayButton>.NativeClassPtr = IL2CPP.GetIl2CppNestedType(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "GameModePlayButton");
			IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<GameModePlayButton>.NativeClassPtr);
			NativeFieldInfoPtr_canvasGroup = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<GameModePlayButton>.NativeClassPtr, "canvasGroup");
			NativeFieldInfoPtr_button = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<GameModePlayButton>.NativeClassPtr, "button");
			NativeFieldInfoPtr_gameModeText = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<GameModePlayButton>.NativeClassPtr, "gameModeText");
			NativeFieldInfoPtr_nameText = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<GameModePlayButton>.NativeClassPtr, "nameText");
			NativeFieldInfoPtr_typeText = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<GameModePlayButton>.NativeClassPtr, "typeText");
			NativeFieldInfoPtr_illustrationImage = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<GameModePlayButton>.NativeClassPtr, "illustrationImage");
			NativeFieldInfoPtr_eventHeaderObj = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<GameModePlayButton>.NativeClassPtr, "eventHeaderObj");
			NativeFieldInfoPtr_eventText = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<GameModePlayButton>.NativeClassPtr, "eventText");
			NativeFieldInfoPtr_eventTimeText = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<GameModePlayButton>.NativeClassPtr, "eventTimeText");
			NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<GameModePlayButton>.NativeClassPtr, 100669679);
		}

		[CallerCount(5410)]
		[CachedScanResults(RefRangeStart = 11, RefRangeEnd = 5421, XrefRangeStart = 11, XrefRangeEnd = 5421, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe GameModePlayButton()
			: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<GameModePlayButton>.NativeClassPtr))
		{
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		public GameModePlayButton(System.IntPtr pointer)
			: base(pointer)
		{
		}
	}

	[System.Serializable]
	public class OpenBetaChallenge : Il2CppSystem.Object
	{
		[System.Serializable]
		public class ChallengeEventPanel : Il2CppSystem.Object
		{
			private static readonly System.IntPtr NativeFieldInfoPtr_panelObj;

			private static readonly System.IntPtr NativeFieldInfoPtr_prizePoolText;

			private static readonly System.IntPtr NativeFieldInfoPtr_progressBar;

			private static readonly System.IntPtr NativeFieldInfoPtr_XSignUpsOutOfYText;

			private static readonly System.IntPtr NativeFieldInfoPtr_seeMoreButton;

			private static readonly System.IntPtr NativeFieldInfoPtr_seeMoreButtonText;

			private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

			public unsafe GameObject panelObj
			{
				get
				{
					nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_panelObj);
					System.IntPtr intPtr = *(System.IntPtr*)num;
					return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<GameObject>(intPtr) : null;
				}
				set
				{
					System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
					IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_panelObj)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)gameObject));
				}
			}

			public unsafe TMP_Text prizePoolText
			{
				get
				{
					nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_prizePoolText);
					System.IntPtr intPtr = *(System.IntPtr*)num;
					return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<TMP_Text>(intPtr) : null;
				}
				set
				{
					System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
					IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_prizePoolText)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)tMP_Text));
				}
			}

			public unsafe LayoutFitParentPercentage progressBar
			{
				get
				{
					nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_progressBar);
					System.IntPtr intPtr = *(System.IntPtr*)num;
					return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<LayoutFitParentPercentage>(intPtr) : null;
				}
				set
				{
					System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
					IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_progressBar)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)layoutFitParentPercentage));
				}
			}

			public unsafe TMP_Text XSignUpsOutOfYText
			{
				get
				{
					nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_XSignUpsOutOfYText);
					System.IntPtr intPtr = *(System.IntPtr*)num;
					return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<TMP_Text>(intPtr) : null;
				}
				set
				{
					System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
					IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_XSignUpsOutOfYText)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)tMP_Text));
				}
			}

			public unsafe Button seeMoreButton
			{
				get
				{
					nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_seeMoreButton);
					System.IntPtr intPtr = *(System.IntPtr*)num;
					return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Button>(intPtr) : null;
				}
				set
				{
					System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
					IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_seeMoreButton)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)button));
				}
			}

			public unsafe TMP_Text seeMoreButtonText
			{
				get
				{
					nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_seeMoreButtonText);
					System.IntPtr intPtr = *(System.IntPtr*)num;
					return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<TMP_Text>(intPtr) : null;
				}
				set
				{
					System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
					IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_seeMoreButtonText)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)tMP_Text));
				}
			}

			static ChallengeEventPanel()
			{
				Il2CppClassPointerStore<ChallengeEventPanel>.NativeClassPtr = IL2CPP.GetIl2CppNestedType(Il2CppClassPointerStore<OpenBetaChallenge>.NativeClassPtr, "ChallengeEventPanel");
				IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<ChallengeEventPanel>.NativeClassPtr);
				NativeFieldInfoPtr_panelObj = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ChallengeEventPanel>.NativeClassPtr, "panelObj");
				NativeFieldInfoPtr_prizePoolText = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ChallengeEventPanel>.NativeClassPtr, "prizePoolText");
				NativeFieldInfoPtr_progressBar = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ChallengeEventPanel>.NativeClassPtr, "progressBar");
				NativeFieldInfoPtr_XSignUpsOutOfYText = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ChallengeEventPanel>.NativeClassPtr, "XSignUpsOutOfYText");
				NativeFieldInfoPtr_seeMoreButton = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ChallengeEventPanel>.NativeClassPtr, "seeMoreButton");
				NativeFieldInfoPtr_seeMoreButtonText = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ChallengeEventPanel>.NativeClassPtr, "seeMoreButtonText");
				NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ChallengeEventPanel>.NativeClassPtr, 100669681);
			}

			[CallerCount(5410)]
			[CachedScanResults(RefRangeStart = 11, RefRangeEnd = 5421, XrefRangeStart = 11, XrefRangeEnd = 5421, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
			public unsafe ChallengeEventPanel()
				: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<ChallengeEventPanel>.NativeClassPtr))
			{
				System.IntPtr* ptr = null;
				Unsafe.SkipInit(out System.IntPtr intPtr2);
				System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
				Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			}

			public ChallengeEventPanel(System.IntPtr pointer)
				: base(pointer)
			{
			}
		}

		[System.Serializable]
		public class GameModeChallengeEventHeader : Il2CppSystem.Object
		{
			private static readonly System.IntPtr NativeFieldInfoPtr_headerObj;

			private static readonly System.IntPtr NativeFieldInfoPtr_eventTitleText;

			private static readonly System.IntPtr NativeFieldInfoPtr_livesText;

			private static readonly System.IntPtr NativeFieldInfoPtr_livesHeaderText;

			private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

			public unsafe GameObject headerObj
			{
				get
				{
					nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_headerObj);
					System.IntPtr intPtr = *(System.IntPtr*)num;
					return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<GameObject>(intPtr) : null;
				}
				set
				{
					System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
					IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_headerObj)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)gameObject));
				}
			}

			public unsafe TMP_Text eventTitleText
			{
				get
				{
					nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_eventTitleText);
					System.IntPtr intPtr = *(System.IntPtr*)num;
					return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<TMP_Text>(intPtr) : null;
				}
				set
				{
					System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
					IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_eventTitleText)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)tMP_Text));
				}
			}

			public unsafe TMP_Text livesText
			{
				get
				{
					nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_livesText);
					System.IntPtr intPtr = *(System.IntPtr*)num;
					return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<TMP_Text>(intPtr) : null;
				}
				set
				{
					System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
					IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_livesText)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)tMP_Text));
				}
			}

			public unsafe TMP_Text livesHeaderText
			{
				get
				{
					nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_livesHeaderText);
					System.IntPtr intPtr = *(System.IntPtr*)num;
					return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<TMP_Text>(intPtr) : null;
				}
				set
				{
					System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
					IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_livesHeaderText)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)tMP_Text));
				}
			}

			static GameModeChallengeEventHeader()
			{
				Il2CppClassPointerStore<GameModeChallengeEventHeader>.NativeClassPtr = IL2CPP.GetIl2CppNestedType(Il2CppClassPointerStore<OpenBetaChallenge>.NativeClassPtr, "GameModeChallengeEventHeader");
				IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<GameModeChallengeEventHeader>.NativeClassPtr);
				NativeFieldInfoPtr_headerObj = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<GameModeChallengeEventHeader>.NativeClassPtr, "headerObj");
				NativeFieldInfoPtr_eventTitleText = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<GameModeChallengeEventHeader>.NativeClassPtr, "eventTitleText");
				NativeFieldInfoPtr_livesText = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<GameModeChallengeEventHeader>.NativeClassPtr, "livesText");
				NativeFieldInfoPtr_livesHeaderText = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<GameModeChallengeEventHeader>.NativeClassPtr, "livesHeaderText");
				NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<GameModeChallengeEventHeader>.NativeClassPtr, 100669682);
			}

			[CallerCount(5410)]
			[CachedScanResults(RefRangeStart = 11, RefRangeEnd = 5421, XrefRangeStart = 11, XrefRangeEnd = 5421, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
			public unsafe GameModeChallengeEventHeader()
				: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<GameModeChallengeEventHeader>.NativeClassPtr))
			{
				System.IntPtr* ptr = null;
				Unsafe.SkipInit(out System.IntPtr intPtr2);
				System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
				Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			}

			public GameModeChallengeEventHeader(System.IntPtr pointer)
				: base(pointer)
			{
			}
		}

		[System.Serializable]
		public class PlayDisclaimerPopUp : Il2CppSystem.Object
		{
			private static readonly System.IntPtr NativeFieldInfoPtr_canvasGroup;

			private static readonly System.IntPtr NativeFieldInfoPtr_alphaFade;

			private static readonly System.IntPtr NativeFieldInfoPtr_posLerpFade;

			private static readonly System.IntPtr NativeFieldInfoPtr_headerText;

			private static readonly System.IntPtr NativeFieldInfoPtr_disclaimerText;

			private static readonly System.IntPtr NativeFieldInfoPtr_disclaimerNoRefundsText;

			private static readonly System.IntPtr NativeFieldInfoPtr_fillCloseButton;

			private static readonly System.IntPtr NativeFieldInfoPtr_closeButton;

			private static readonly System.IntPtr NativeFieldInfoPtr_readyUpButton;

			private static readonly System.IntPtr NativeFieldInfoPtr_readyUpButtonText;

			private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

			public unsafe CanvasGroup canvasGroup
			{
				get
				{
					nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_canvasGroup);
					System.IntPtr intPtr = *(System.IntPtr*)num;
					return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<CanvasGroup>(intPtr) : null;
				}
				set
				{
					System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
					IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_canvasGroup)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)canvasGroup));
				}
			}

			public unsafe UIAlphaFade alphaFade
			{
				get
				{
					nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_alphaFade);
					System.IntPtr intPtr = *(System.IntPtr*)num;
					return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<UIAlphaFade>(intPtr) : null;
				}
				set
				{
					System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
					IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_alphaFade)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)uIAlphaFade));
				}
			}

			public unsafe UIPosLerpFade posLerpFade
			{
				get
				{
					nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_posLerpFade);
					System.IntPtr intPtr = *(System.IntPtr*)num;
					return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<UIPosLerpFade>(intPtr) : null;
				}
				set
				{
					System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
					IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_posLerpFade)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)uIPosLerpFade));
				}
			}

			public unsafe TMP_Text headerText
			{
				get
				{
					nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_headerText);
					System.IntPtr intPtr = *(System.IntPtr*)num;
					return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<TMP_Text>(intPtr) : null;
				}
				set
				{
					System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
					IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_headerText)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)tMP_Text));
				}
			}

			public unsafe TMP_Text disclaimerText
			{
				get
				{
					nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_disclaimerText);
					System.IntPtr intPtr = *(System.IntPtr*)num;
					return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<TMP_Text>(intPtr) : null;
				}
				set
				{
					System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
					IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_disclaimerText)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)tMP_Text));
				}
			}

			public unsafe TMP_Text disclaimerNoRefundsText
			{
				get
				{
					nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_disclaimerNoRefundsText);
					System.IntPtr intPtr = *(System.IntPtr*)num;
					return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<TMP_Text>(intPtr) : null;
				}
				set
				{
					System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
					IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_disclaimerNoRefundsText)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)tMP_Text));
				}
			}

			public unsafe Button fillCloseButton
			{
				get
				{
					nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_fillCloseButton);
					System.IntPtr intPtr = *(System.IntPtr*)num;
					return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Button>(intPtr) : null;
				}
				set
				{
					System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
					IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_fillCloseButton)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)button));
				}
			}

			public unsafe Button closeButton
			{
				get
				{
					nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_closeButton);
					System.IntPtr intPtr = *(System.IntPtr*)num;
					return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Button>(intPtr) : null;
				}
				set
				{
					System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
					IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_closeButton)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)button));
				}
			}

			public unsafe Button readyUpButton
			{
				get
				{
					nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_readyUpButton);
					System.IntPtr intPtr = *(System.IntPtr*)num;
					return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Button>(intPtr) : null;
				}
				set
				{
					System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
					IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_readyUpButton)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)button));
				}
			}

			public unsafe TMP_Text readyUpButtonText
			{
				get
				{
					nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_readyUpButtonText);
					System.IntPtr intPtr = *(System.IntPtr*)num;
					return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<TMP_Text>(intPtr) : null;
				}
				set
				{
					System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
					IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_readyUpButtonText)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)tMP_Text));
				}
			}

			static PlayDisclaimerPopUp()
			{
				Il2CppClassPointerStore<PlayDisclaimerPopUp>.NativeClassPtr = IL2CPP.GetIl2CppNestedType(Il2CppClassPointerStore<OpenBetaChallenge>.NativeClassPtr, "PlayDisclaimerPopUp");
				IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<PlayDisclaimerPopUp>.NativeClassPtr);
				NativeFieldInfoPtr_canvasGroup = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<PlayDisclaimerPopUp>.NativeClassPtr, "canvasGroup");
				NativeFieldInfoPtr_alphaFade = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<PlayDisclaimerPopUp>.NativeClassPtr, "alphaFade");
				NativeFieldInfoPtr_posLerpFade = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<PlayDisclaimerPopUp>.NativeClassPtr, "posLerpFade");
				NativeFieldInfoPtr_headerText = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<PlayDisclaimerPopUp>.NativeClassPtr, "headerText");
				NativeFieldInfoPtr_disclaimerText = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<PlayDisclaimerPopUp>.NativeClassPtr, "disclaimerText");
				NativeFieldInfoPtr_disclaimerNoRefundsText = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<PlayDisclaimerPopUp>.NativeClassPtr, "disclaimerNoRefundsText");
				NativeFieldInfoPtr_fillCloseButton = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<PlayDisclaimerPopUp>.NativeClassPtr, "fillCloseButton");
				NativeFieldInfoPtr_closeButton = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<PlayDisclaimerPopUp>.NativeClassPtr, "closeButton");
				NativeFieldInfoPtr_readyUpButton = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<PlayDisclaimerPopUp>.NativeClassPtr, "readyUpButton");
				NativeFieldInfoPtr_readyUpButtonText = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<PlayDisclaimerPopUp>.NativeClassPtr, "readyUpButtonText");
				NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<PlayDisclaimerPopUp>.NativeClassPtr, 100669683);
			}

			[CallerCount(5410)]
			[CachedScanResults(RefRangeStart = 11, RefRangeEnd = 5421, XrefRangeStart = 11, XrefRangeEnd = 5421, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
			public unsafe PlayDisclaimerPopUp()
				: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<PlayDisclaimerPopUp>.NativeClassPtr))
			{
				System.IntPtr* ptr = null;
				Unsafe.SkipInit(out System.IntPtr intPtr2);
				System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
				Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			}

			public PlayDisclaimerPopUp(System.IntPtr pointer)
				: base(pointer)
			{
			}
		}

		[System.Serializable]
		public class OutOfLivesPopUp : Il2CppSystem.Object
		{
			private static readonly System.IntPtr NativeFieldInfoPtr_canvasGroup;

			private static readonly System.IntPtr NativeFieldInfoPtr_alphaFade;

			private static readonly System.IntPtr NativeFieldInfoPtr_posLerpFade;

			private static readonly System.IntPtr NativeFieldInfoPtr_headerText;

			private static readonly System.IntPtr NativeFieldInfoPtr_outOfLivesText;

			private static readonly System.IntPtr NativeFieldInfoPtr_obtainMoreLivesText;

			private static readonly System.IntPtr NativeFieldInfoPtr_fillCloseButton;

			private static readonly System.IntPtr NativeFieldInfoPtr_closeButton;

			private static readonly System.IntPtr NativeFieldInfoPtr_getMoreLivesButton;

			private static readonly System.IntPtr NativeFieldInfoPtr_getMoreLivesButtonText;

			private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

			public unsafe CanvasGroup canvasGroup
			{
				get
				{
					nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_canvasGroup);
					System.IntPtr intPtr = *(System.IntPtr*)num;
					return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<CanvasGroup>(intPtr) : null;
				}
				set
				{
					System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
					IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_canvasGroup)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)canvasGroup));
				}
			}

			public unsafe UIAlphaFade alphaFade
			{
				get
				{
					nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_alphaFade);
					System.IntPtr intPtr = *(System.IntPtr*)num;
					return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<UIAlphaFade>(intPtr) : null;
				}
				set
				{
					System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
					IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_alphaFade)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)uIAlphaFade));
				}
			}

			public unsafe UIPosLerpFade posLerpFade
			{
				get
				{
					nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_posLerpFade);
					System.IntPtr intPtr = *(System.IntPtr*)num;
					return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<UIPosLerpFade>(intPtr) : null;
				}
				set
				{
					System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
					IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_posLerpFade)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)uIPosLerpFade));
				}
			}

			public unsafe TMP_Text headerText
			{
				get
				{
					nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_headerText);
					System.IntPtr intPtr = *(System.IntPtr*)num;
					return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<TMP_Text>(intPtr) : null;
				}
				set
				{
					System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
					IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_headerText)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)tMP_Text));
				}
			}

			public unsafe TMP_Text outOfLivesText
			{
				get
				{
					nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_outOfLivesText);
					System.IntPtr intPtr = *(System.IntPtr*)num;
					return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<TMP_Text>(intPtr) : null;
				}
				set
				{
					System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
					IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_outOfLivesText)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)tMP_Text));
				}
			}

			public unsafe TMP_Text obtainMoreLivesText
			{
				get
				{
					nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_obtainMoreLivesText);
					System.IntPtr intPtr = *(System.IntPtr*)num;
					return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<TMP_Text>(intPtr) : null;
				}
				set
				{
					System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
					IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_obtainMoreLivesText)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)tMP_Text));
				}
			}

			public unsafe Button fillCloseButton
			{
				get
				{
					nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_fillCloseButton);
					System.IntPtr intPtr = *(System.IntPtr*)num;
					return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Button>(intPtr) : null;
				}
				set
				{
					System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
					IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_fillCloseButton)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)button));
				}
			}

			public unsafe Button closeButton
			{
				get
				{
					nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_closeButton);
					System.IntPtr intPtr = *(System.IntPtr*)num;
					return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Button>(intPtr) : null;
				}
				set
				{
					System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
					IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_closeButton)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)button));
				}
			}

			public unsafe Button getMoreLivesButton
			{
				get
				{
					nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_getMoreLivesButton);
					System.IntPtr intPtr = *(System.IntPtr*)num;
					return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Button>(intPtr) : null;
				}
				set
				{
					System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
					IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_getMoreLivesButton)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)button));
				}
			}

			public unsafe TMP_Text getMoreLivesButtonText
			{
				get
				{
					nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_getMoreLivesButtonText);
					System.IntPtr intPtr = *(System.IntPtr*)num;
					return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<TMP_Text>(intPtr) : null;
				}
				set
				{
					System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
					IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_getMoreLivesButtonText)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)tMP_Text));
				}
			}

			static OutOfLivesPopUp()
			{
				Il2CppClassPointerStore<OutOfLivesPopUp>.NativeClassPtr = IL2CPP.GetIl2CppNestedType(Il2CppClassPointerStore<OpenBetaChallenge>.NativeClassPtr, "OutOfLivesPopUp");
				IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<OutOfLivesPopUp>.NativeClassPtr);
				NativeFieldInfoPtr_canvasGroup = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<OutOfLivesPopUp>.NativeClassPtr, "canvasGroup");
				NativeFieldInfoPtr_alphaFade = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<OutOfLivesPopUp>.NativeClassPtr, "alphaFade");
				NativeFieldInfoPtr_posLerpFade = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<OutOfLivesPopUp>.NativeClassPtr, "posLerpFade");
				NativeFieldInfoPtr_headerText = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<OutOfLivesPopUp>.NativeClassPtr, "headerText");
				NativeFieldInfoPtr_outOfLivesText = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<OutOfLivesPopUp>.NativeClassPtr, "outOfLivesText");
				NativeFieldInfoPtr_obtainMoreLivesText = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<OutOfLivesPopUp>.NativeClassPtr, "obtainMoreLivesText");
				NativeFieldInfoPtr_fillCloseButton = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<OutOfLivesPopUp>.NativeClassPtr, "fillCloseButton");
				NativeFieldInfoPtr_closeButton = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<OutOfLivesPopUp>.NativeClassPtr, "closeButton");
				NativeFieldInfoPtr_getMoreLivesButton = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<OutOfLivesPopUp>.NativeClassPtr, "getMoreLivesButton");
				NativeFieldInfoPtr_getMoreLivesButtonText = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<OutOfLivesPopUp>.NativeClassPtr, "getMoreLivesButtonText");
				NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<OutOfLivesPopUp>.NativeClassPtr, 100669684);
			}

			[CallerCount(5410)]
			[CachedScanResults(RefRangeStart = 11, RefRangeEnd = 5421, XrefRangeStart = 11, XrefRangeEnd = 5421, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
			public unsafe OutOfLivesPopUp()
				: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<OutOfLivesPopUp>.NativeClassPtr))
			{
				System.IntPtr* ptr = null;
				Unsafe.SkipInit(out System.IntPtr intPtr2);
				System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
				Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			}

			public OutOfLivesPopUp(System.IntPtr pointer)
				: base(pointer)
			{
			}
		}

		private static readonly System.IntPtr NativeFieldInfoPtr_challengePanel;

		private static readonly System.IntPtr NativeFieldInfoPtr_gameModeEventHeader;

		private static readonly System.IntPtr NativeFieldInfoPtr_disclaimerPopUp;

		private static readonly System.IntPtr NativeFieldInfoPtr_outOfLivesPopUp;

		private static readonly System.IntPtr NativeFieldInfoPtr_newsSignUpButton;

		private static readonly System.IntPtr NativeFieldInfoPtr_newsSignUpButtonText;

		private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

		public unsafe ChallengeEventPanel challengePanel
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_challengePanel);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<ChallengeEventPanel>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_challengePanel)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)challengeEventPanel));
			}
		}

		public unsafe GameModeChallengeEventHeader gameModeEventHeader
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_gameModeEventHeader);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<GameModeChallengeEventHeader>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_gameModeEventHeader)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)gameModeChallengeEventHeader));
			}
		}

		public unsafe PlayDisclaimerPopUp disclaimerPopUp
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_disclaimerPopUp);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<PlayDisclaimerPopUp>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_disclaimerPopUp)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)playDisclaimerPopUp));
			}
		}

		public unsafe OutOfLivesPopUp outOfLivesPopUp
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_outOfLivesPopUp);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<OutOfLivesPopUp>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_outOfLivesPopUp)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)outOfLivesPopUp));
			}
		}

		public unsafe Button newsSignUpButton
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_newsSignUpButton);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Button>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_newsSignUpButton)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)button));
			}
		}

		public unsafe TMP_Text newsSignUpButtonText
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_newsSignUpButtonText);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<TMP_Text>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_newsSignUpButtonText)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)tMP_Text));
			}
		}

		static OpenBetaChallenge()
		{
			Il2CppClassPointerStore<OpenBetaChallenge>.NativeClassPtr = IL2CPP.GetIl2CppNestedType(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "OpenBetaChallenge");
			IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<OpenBetaChallenge>.NativeClassPtr);
			NativeFieldInfoPtr_challengePanel = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<OpenBetaChallenge>.NativeClassPtr, "challengePanel");
			NativeFieldInfoPtr_gameModeEventHeader = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<OpenBetaChallenge>.NativeClassPtr, "gameModeEventHeader");
			NativeFieldInfoPtr_disclaimerPopUp = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<OpenBetaChallenge>.NativeClassPtr, "disclaimerPopUp");
			NativeFieldInfoPtr_outOfLivesPopUp = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<OpenBetaChallenge>.NativeClassPtr, "outOfLivesPopUp");
			NativeFieldInfoPtr_newsSignUpButton = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<OpenBetaChallenge>.NativeClassPtr, "newsSignUpButton");
			NativeFieldInfoPtr_newsSignUpButtonText = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<OpenBetaChallenge>.NativeClassPtr, "newsSignUpButtonText");
			NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<OpenBetaChallenge>.NativeClassPtr, 100669680);
		}

		[CallerCount(5410)]
		[CachedScanResults(RefRangeStart = 11, RefRangeEnd = 5421, XrefRangeStart = 11, XrefRangeEnd = 5421, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe OpenBetaChallenge()
			: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<OpenBetaChallenge>.NativeClassPtr))
		{
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		public OpenBetaChallenge(System.IntPtr pointer)
			: base(pointer)
		{
		}
	}

	[System.Serializable]
	public class GameModePanel : Il2CppSystem.Object
	{
		private static readonly System.IntPtr NativeFieldInfoPtr_canvasGroup;

		private static readonly System.IntPtr NativeFieldInfoPtr_alphaFade;

		private static readonly System.IntPtr NativeFieldInfoPtr_posLerpFade;

		private static readonly System.IntPtr NativeFieldInfoPtr_buttonsAlphaFade;

		private static readonly System.IntPtr NativeFieldInfoPtr_buttonsPosLerpFade;

		private static readonly System.IntPtr NativeFieldInfoPtr_closePageFillRaycastButton;

		private static readonly System.IntPtr NativeFieldInfoPtr_closePageButton;

		private static readonly System.IntPtr NativeFieldInfoPtr_gmNormalButton;

		private static readonly System.IntPtr NativeFieldInfoPtr_gmRankedButton;

		private static readonly System.IntPtr NativeFieldInfoPtr_gmWarmupButton;

		private static readonly System.IntPtr NativeFieldInfoPtr_howToPlayButton;

		private static readonly System.IntPtr NativeFieldInfoPtr_selectGameModeText;

		private static readonly System.IntPtr NativeFieldInfoPtr_buttonParentTransform;

		private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

		public unsafe CanvasGroup canvasGroup
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_canvasGroup);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<CanvasGroup>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_canvasGroup)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)canvasGroup));
			}
		}

		public unsafe UIAlphaFade alphaFade
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_alphaFade);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<UIAlphaFade>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_alphaFade)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)uIAlphaFade));
			}
		}

		public unsafe UIPosLerpFade posLerpFade
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_posLerpFade);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<UIPosLerpFade>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_posLerpFade)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)uIPosLerpFade));
			}
		}

		public unsafe UIAlphaFade buttonsAlphaFade
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_buttonsAlphaFade);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<UIAlphaFade>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_buttonsAlphaFade)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)uIAlphaFade));
			}
		}

		public unsafe UIPosLerpFade buttonsPosLerpFade
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_buttonsPosLerpFade);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<UIPosLerpFade>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_buttonsPosLerpFade)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)uIPosLerpFade));
			}
		}

		public unsafe Button closePageFillRaycastButton
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_closePageFillRaycastButton);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Button>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_closePageFillRaycastButton)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)button));
			}
		}

		public unsafe Button closePageButton
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_closePageButton);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Button>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_closePageButton)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)button));
			}
		}

		public unsafe Button gmNormalButton
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_gmNormalButton);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Button>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_gmNormalButton)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)button));
			}
		}

		public unsafe Button gmRankedButton
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_gmRankedButton);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Button>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_gmRankedButton)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)button));
			}
		}

		public unsafe Button gmWarmupButton
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_gmWarmupButton);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Button>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_gmWarmupButton)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)button));
			}
		}

		public unsafe Button howToPlayButton
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_howToPlayButton);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Button>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_howToPlayButton)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)button));
			}
		}

		public unsafe TMP_Text selectGameModeText
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_selectGameModeText);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<TMP_Text>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_selectGameModeText)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)tMP_Text));
			}
		}

		public unsafe Transform buttonParentTransform
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_buttonParentTransform);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Transform>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_buttonParentTransform)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)transform));
			}
		}

		static GameModePanel()
		{
			Il2CppClassPointerStore<GameModePanel>.NativeClassPtr = IL2CPP.GetIl2CppNestedType(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "GameModePanel");
			IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<GameModePanel>.NativeClassPtr);
			NativeFieldInfoPtr_canvasGroup = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<GameModePanel>.NativeClassPtr, "canvasGroup");
			NativeFieldInfoPtr_alphaFade = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<GameModePanel>.NativeClassPtr, "alphaFade");
			NativeFieldInfoPtr_posLerpFade = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<GameModePanel>.NativeClassPtr, "posLerpFade");
			NativeFieldInfoPtr_buttonsAlphaFade = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<GameModePanel>.NativeClassPtr, "buttonsAlphaFade");
			NativeFieldInfoPtr_buttonsPosLerpFade = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<GameModePanel>.NativeClassPtr, "buttonsPosLerpFade");
			NativeFieldInfoPtr_closePageFillRaycastButton = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<GameModePanel>.NativeClassPtr, "closePageFillRaycastButton");
			NativeFieldInfoPtr_closePageButton = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<GameModePanel>.NativeClassPtr, "closePageButton");
			NativeFieldInfoPtr_gmNormalButton = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<GameModePanel>.NativeClassPtr, "gmNormalButton");
			NativeFieldInfoPtr_gmRankedButton = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<GameModePanel>.NativeClassPtr, "gmRankedButton");
			NativeFieldInfoPtr_gmWarmupButton = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<GameModePanel>.NativeClassPtr, "gmWarmupButton");
			NativeFieldInfoPtr_howToPlayButton = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<GameModePanel>.NativeClassPtr, "howToPlayButton");
			NativeFieldInfoPtr_selectGameModeText = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<GameModePanel>.NativeClassPtr, "selectGameModeText");
			NativeFieldInfoPtr_buttonParentTransform = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<GameModePanel>.NativeClassPtr, "buttonParentTransform");
			NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<GameModePanel>.NativeClassPtr, 100669685);
		}

		[CallerCount(5410)]
		[CachedScanResults(RefRangeStart = 11, RefRangeEnd = 5421, XrefRangeStart = 11, XrefRangeEnd = 5421, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe GameModePanel()
			: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<GameModePanel>.NativeClassPtr))
		{
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		public GameModePanel(System.IntPtr pointer)
			: base(pointer)
		{
		}
	}

	[System.Serializable]
	public class GameQueuePanel : Il2CppSystem.Object
	{
		private static readonly System.IntPtr NativeFieldInfoPtr_gameModeText;

		private static readonly System.IntPtr NativeFieldInfoPtr_queueStatusText;

		private static readonly System.IntPtr NativeFieldInfoPtr_playerCountText;

		private static readonly System.IntPtr NativeFieldInfoPtr_elapsedTimeText;

		private static readonly System.IntPtr NativeFieldInfoPtr_canvasGroup;

		private static readonly System.IntPtr NativeFieldInfoPtr_progressIconSpin;

		private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

		public unsafe TMP_Text gameModeText
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_gameModeText);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<TMP_Text>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_gameModeText)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)tMP_Text));
			}
		}

		public unsafe TMP_Text queueStatusText
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_queueStatusText);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<TMP_Text>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_queueStatusText)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)tMP_Text));
			}
		}

		public unsafe TMP_Text playerCountText
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_playerCountText);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<TMP_Text>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_playerCountText)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)tMP_Text));
			}
		}

		public unsafe TMP_Text elapsedTimeText
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_elapsedTimeText);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<TMP_Text>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_elapsedTimeText)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)tMP_Text));
			}
		}

		public unsafe CanvasGroup canvasGroup
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_canvasGroup);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<CanvasGroup>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_canvasGroup)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)canvasGroup));
			}
		}

		public unsafe GameObject progressIconSpin
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_progressIconSpin);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<GameObject>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_progressIconSpin)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)gameObject));
			}
		}

		static GameQueuePanel()
		{
			Il2CppClassPointerStore<GameQueuePanel>.NativeClassPtr = IL2CPP.GetIl2CppNestedType(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "GameQueuePanel");
			IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<GameQueuePanel>.NativeClassPtr);
			NativeFieldInfoPtr_gameModeText = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<GameQueuePanel>.NativeClassPtr, "gameModeText");
			NativeFieldInfoPtr_queueStatusText = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<GameQueuePanel>.NativeClassPtr, "queueStatusText");
			NativeFieldInfoPtr_playerCountText = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<GameQueuePanel>.NativeClassPtr, "playerCountText");
			NativeFieldInfoPtr_elapsedTimeText = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<GameQueuePanel>.NativeClassPtr, "elapsedTimeText");
			NativeFieldInfoPtr_canvasGroup = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<GameQueuePanel>.NativeClassPtr, "canvasGroup");
			NativeFieldInfoPtr_progressIconSpin = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<GameQueuePanel>.NativeClassPtr, "progressIconSpin");
			NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<GameQueuePanel>.NativeClassPtr, 100669686);
		}

		[CallerCount(5410)]
		[CachedScanResults(RefRangeStart = 11, RefRangeEnd = 5421, XrefRangeStart = 11, XrefRangeEnd = 5421, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe GameQueuePanel()
			: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<GameQueuePanel>.NativeClassPtr))
		{
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		public GameQueuePanel(System.IntPtr pointer)
			: base(pointer)
		{
		}
	}

	[System.Serializable]
	public class MatchStartPanel : Il2CppSystem.Object
	{
		[System.Serializable]
		public class MatchPlayer : Il2CppSystem.Object
		{
			private static readonly System.IntPtr NativeFieldInfoPtr_gameObject;

			private static readonly System.IntPtr NativeFieldInfoPtr_nameTextRect;

			private static readonly System.IntPtr NativeFieldInfoPtr_playerNameText;

			private static readonly System.IntPtr NativeFieldInfoPtr_playerContainer;

			private static readonly System.IntPtr NativeFieldInfoPtr_charNameText;

			private static readonly System.IntPtr NativeFieldInfoPtr_charImage;

			private static readonly System.IntPtr NativeFieldInfoPtr_charRectTransform;

			private static readonly System.IntPtr NativeFieldInfoPtr_ChangeAnimObj;

			private static readonly System.IntPtr NativeFieldInfoPtr_ChangeAnimAlphaFade;

			private static readonly System.IntPtr NativeFieldInfoPtr_ChangeAnimTransformScale;

			private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

			public unsafe GameObject gameObject
			{
				get
				{
					nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_gameObject);
					System.IntPtr intPtr = *(System.IntPtr*)num;
					return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<GameObject>(intPtr) : null;
				}
				set
				{
					System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
					IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_gameObject)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)gameObject));
				}
			}

			public unsafe RectTransform nameTextRect
			{
				get
				{
					nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_nameTextRect);
					System.IntPtr intPtr = *(System.IntPtr*)num;
					return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<RectTransform>(intPtr) : null;
				}
				set
				{
					System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
					IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_nameTextRect)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)rectTransform));
				}
			}

			public unsafe TMP_Text playerNameText
			{
				get
				{
					nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_playerNameText);
					System.IntPtr intPtr = *(System.IntPtr*)num;
					return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<TMP_Text>(intPtr) : null;
				}
				set
				{
					System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
					IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_playerNameText)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)tMP_Text));
				}
			}

			public unsafe UILobbyPlayerContainer playerContainer
			{
				get
				{
					nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_playerContainer);
					System.IntPtr intPtr = *(System.IntPtr*)num;
					return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<UILobbyPlayerContainer>(intPtr) : null;
				}
				set
				{
					System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
					IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_playerContainer)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)uILobbyPlayerContainer));
				}
			}

			public unsafe TMP_Text charNameText
			{
				get
				{
					nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_charNameText);
					System.IntPtr intPtr = *(System.IntPtr*)num;
					return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<TMP_Text>(intPtr) : null;
				}
				set
				{
					System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
					IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_charNameText)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)tMP_Text));
				}
			}

			public unsafe Image charImage
			{
				get
				{
					nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_charImage);
					System.IntPtr intPtr = *(System.IntPtr*)num;
					return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Image>(intPtr) : null;
				}
				set
				{
					System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
					IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_charImage)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)image));
				}
			}

			public unsafe RectTransform charRectTransform
			{
				get
				{
					nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_charRectTransform);
					System.IntPtr intPtr = *(System.IntPtr*)num;
					return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<RectTransform>(intPtr) : null;
				}
				set
				{
					System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
					IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_charRectTransform)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)rectTransform));
				}
			}

			public unsafe GameObject ChangeAnimObj
			{
				get
				{
					nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_ChangeAnimObj);
					System.IntPtr intPtr = *(System.IntPtr*)num;
					return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<GameObject>(intPtr) : null;
				}
				set
				{
					System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
					IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_ChangeAnimObj)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)gameObject));
				}
			}

			public unsafe UIAlphaAnim ChangeAnimAlphaFade
			{
				get
				{
					nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_ChangeAnimAlphaFade);
					System.IntPtr intPtr = *(System.IntPtr*)num;
					return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<UIAlphaAnim>(intPtr) : null;
				}
				set
				{
					System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
					IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_ChangeAnimAlphaFade)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)uIAlphaAnim));
				}
			}

			public unsafe TransformScaleAnimation ChangeAnimTransformScale
			{
				get
				{
					nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_ChangeAnimTransformScale);
					System.IntPtr intPtr = *(System.IntPtr*)num;
					return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<TransformScaleAnimation>(intPtr) : null;
				}
				set
				{
					System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
					IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_ChangeAnimTransformScale)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)transformScaleAnimation));
				}
			}

			static MatchPlayer()
			{
				Il2CppClassPointerStore<MatchPlayer>.NativeClassPtr = IL2CPP.GetIl2CppNestedType(Il2CppClassPointerStore<MatchStartPanel>.NativeClassPtr, "MatchPlayer");
				IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<MatchPlayer>.NativeClassPtr);
				NativeFieldInfoPtr_gameObject = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<MatchPlayer>.NativeClassPtr, "gameObject");
				NativeFieldInfoPtr_nameTextRect = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<MatchPlayer>.NativeClassPtr, "nameTextRect");
				NativeFieldInfoPtr_playerNameText = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<MatchPlayer>.NativeClassPtr, "playerNameText");
				NativeFieldInfoPtr_playerContainer = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<MatchPlayer>.NativeClassPtr, "playerContainer");
				NativeFieldInfoPtr_charNameText = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<MatchPlayer>.NativeClassPtr, "charNameText");
				NativeFieldInfoPtr_charImage = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<MatchPlayer>.NativeClassPtr, "charImage");
				NativeFieldInfoPtr_charRectTransform = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<MatchPlayer>.NativeClassPtr, "charRectTransform");
				NativeFieldInfoPtr_ChangeAnimObj = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<MatchPlayer>.NativeClassPtr, "ChangeAnimObj");
				NativeFieldInfoPtr_ChangeAnimAlphaFade = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<MatchPlayer>.NativeClassPtr, "ChangeAnimAlphaFade");
				NativeFieldInfoPtr_ChangeAnimTransformScale = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<MatchPlayer>.NativeClassPtr, "ChangeAnimTransformScale");
				NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<MatchPlayer>.NativeClassPtr, 100669688);
			}

			[CallerCount(5410)]
			[CachedScanResults(RefRangeStart = 11, RefRangeEnd = 5421, XrefRangeStart = 11, XrefRangeEnd = 5421, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
			public unsafe MatchPlayer()
				: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<MatchPlayer>.NativeClassPtr))
			{
				System.IntPtr* ptr = null;
				Unsafe.SkipInit(out System.IntPtr intPtr2);
				System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
				Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			}

			public MatchPlayer(System.IntPtr pointer)
				: base(pointer)
			{
			}
		}

		[System.Serializable]
		public class CharacterSelectPanelAnimation : Il2CppSystem.Object
		{
			private static readonly System.IntPtr NativeFieldInfoPtr_Duration;

			private static readonly System.IntPtr NativeFieldInfoPtr_PanelAlphaCurve;

			private static readonly System.IntPtr NativeFieldInfoPtr_CharacterPositionCurve;

			private static readonly System.IntPtr NativeFieldInfoPtr_CharacterAlphaCurve;

			private static readonly System.IntPtr NativeFieldInfoPtr_CharNameYPosOffset;

			private static readonly System.IntPtr NativeFieldInfoPtr_CharNameTextYPosCurve;

			private static readonly System.IntPtr NativeFieldInfoPtr_CharNameTextAlphaCurve;

			private static readonly System.IntPtr NativeFieldInfoPtr_CharacterPositionOffset;

			private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

			public unsafe float Duration
			{
				get
				{
					nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_Duration);
					return *(float*)num;
				}
				set
				{
					*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_Duration)) = num;
				}
			}

			public unsafe AnimationCurve PanelAlphaCurve
			{
				get
				{
					nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_PanelAlphaCurve);
					System.IntPtr intPtr = *(System.IntPtr*)num;
					return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<AnimationCurve>(intPtr) : null;
				}
				set
				{
					System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
					IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_PanelAlphaCurve)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)animationCurve));
				}
			}

			public unsafe AnimationCurve CharacterPositionCurve
			{
				get
				{
					nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_CharacterPositionCurve);
					System.IntPtr intPtr = *(System.IntPtr*)num;
					return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<AnimationCurve>(intPtr) : null;
				}
				set
				{
					System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
					IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_CharacterPositionCurve)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)animationCurve));
				}
			}

			public unsafe AnimationCurve CharacterAlphaCurve
			{
				get
				{
					nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_CharacterAlphaCurve);
					System.IntPtr intPtr = *(System.IntPtr*)num;
					return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<AnimationCurve>(intPtr) : null;
				}
				set
				{
					System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
					IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_CharacterAlphaCurve)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)animationCurve));
				}
			}

			public unsafe float CharNameYPosOffset
			{
				get
				{
					nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_CharNameYPosOffset);
					return *(float*)num;
				}
				set
				{
					*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_CharNameYPosOffset)) = num;
				}
			}

			public unsafe AnimationCurve CharNameTextYPosCurve
			{
				get
				{
					nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_CharNameTextYPosCurve);
					System.IntPtr intPtr = *(System.IntPtr*)num;
					return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<AnimationCurve>(intPtr) : null;
				}
				set
				{
					System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
					IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_CharNameTextYPosCurve)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)animationCurve));
				}
			}

			public unsafe AnimationCurve CharNameTextAlphaCurve
			{
				get
				{
					nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_CharNameTextAlphaCurve);
					System.IntPtr intPtr = *(System.IntPtr*)num;
					return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<AnimationCurve>(intPtr) : null;
				}
				set
				{
					System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
					IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_CharNameTextAlphaCurve)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)animationCurve));
				}
			}

			public unsafe Vector2 CharacterPositionOffset
			{
				get
				{
					nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_CharacterPositionOffset);
					return *(Vector2*)num;
				}
				set
				{
					*(Vector2*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_CharacterPositionOffset)) = vector;
				}
			}

			static CharacterSelectPanelAnimation()
			{
				Il2CppClassPointerStore<CharacterSelectPanelAnimation>.NativeClassPtr = IL2CPP.GetIl2CppNestedType(Il2CppClassPointerStore<MatchStartPanel>.NativeClassPtr, "CharacterSelectPanelAnimation");
				IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<CharacterSelectPanelAnimation>.NativeClassPtr);
				NativeFieldInfoPtr_Duration = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CharacterSelectPanelAnimation>.NativeClassPtr, "Duration");
				NativeFieldInfoPtr_PanelAlphaCurve = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CharacterSelectPanelAnimation>.NativeClassPtr, "PanelAlphaCurve");
				NativeFieldInfoPtr_CharacterPositionCurve = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CharacterSelectPanelAnimation>.NativeClassPtr, "CharacterPositionCurve");
				NativeFieldInfoPtr_CharacterAlphaCurve = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CharacterSelectPanelAnimation>.NativeClassPtr, "CharacterAlphaCurve");
				NativeFieldInfoPtr_CharNameYPosOffset = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CharacterSelectPanelAnimation>.NativeClassPtr, "CharNameYPosOffset");
				NativeFieldInfoPtr_CharNameTextYPosCurve = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CharacterSelectPanelAnimation>.NativeClassPtr, "CharNameTextYPosCurve");
				NativeFieldInfoPtr_CharNameTextAlphaCurve = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CharacterSelectPanelAnimation>.NativeClassPtr, "CharNameTextAlphaCurve");
				NativeFieldInfoPtr_CharacterPositionOffset = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CharacterSelectPanelAnimation>.NativeClassPtr, "CharacterPositionOffset");
				NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<CharacterSelectPanelAnimation>.NativeClassPtr, 100669689);
			}

			[CallerCount(5410)]
			[CachedScanResults(RefRangeStart = 11, RefRangeEnd = 5421, XrefRangeStart = 11, XrefRangeEnd = 5421, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
			public unsafe CharacterSelectPanelAnimation()
				: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<CharacterSelectPanelAnimation>.NativeClassPtr))
			{
				System.IntPtr* ptr = null;
				Unsafe.SkipInit(out System.IntPtr intPtr2);
				System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
				Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			}

			public CharacterSelectPanelAnimation(System.IntPtr pointer)
				: base(pointer)
			{
			}
		}

		private static readonly System.IntPtr NativeFieldInfoPtr_canvasGroup;

		private static readonly System.IntPtr NativeFieldInfoPtr_uiAlphaFade;

		private static readonly System.IntPtr NativeFieldInfoPtr_charButtonsParent;

		private static readonly System.IntPtr NativeFieldInfoPtr__chatParent;

		private static readonly System.IntPtr NativeFieldInfoPtr_localPlayer;

		private static readonly System.IntPtr NativeFieldInfoPtr_teammatePlayers;

		private static readonly System.IntPtr NativeFieldInfoPtr_matchStartingInText;

		private static readonly System.IntPtr NativeFieldInfoPtr_matchCountdownText;

		private static readonly System.IntPtr NativeFieldInfoPtr_matchCountdownTextTickAnim;

		private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

		public unsafe CanvasGroup canvasGroup
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_canvasGroup);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<CanvasGroup>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_canvasGroup)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)canvasGroup));
			}
		}

		public unsafe UIAlphaFade uiAlphaFade
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_uiAlphaFade);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<UIAlphaFade>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_uiAlphaFade)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)uIAlphaFade));
			}
		}

		public unsafe Transform charButtonsParent
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_charButtonsParent);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Transform>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_charButtonsParent)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)transform));
			}
		}

		public unsafe Transform _chatParent
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__chatParent);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Transform>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__chatParent)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)transform));
			}
		}

		public unsafe MatchPlayer localPlayer
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_localPlayer);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<MatchPlayer>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_localPlayer)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)matchPlayer));
			}
		}

		public unsafe Il2CppReferenceArray<MatchPlayer> teammatePlayers
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_teammatePlayers);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppReferenceArray<MatchPlayer>>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_teammatePlayers)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)val));
			}
		}

		public unsafe TMP_Text matchStartingInText
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_matchStartingInText);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<TMP_Text>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_matchStartingInText)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)tMP_Text));
			}
		}

		public unsafe TMP_Text matchCountdownText
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_matchCountdownText);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<TMP_Text>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_matchCountdownText)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)tMP_Text));
			}
		}

		public unsafe TransformScaleSimpleAnimation matchCountdownTextTickAnim
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_matchCountdownTextTickAnim);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<TransformScaleSimpleAnimation>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_matchCountdownTextTickAnim)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)transformScaleSimpleAnimation));
			}
		}

		static MatchStartPanel()
		{
			Il2CppClassPointerStore<MatchStartPanel>.NativeClassPtr = IL2CPP.GetIl2CppNestedType(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "MatchStartPanel");
			IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<MatchStartPanel>.NativeClassPtr);
			NativeFieldInfoPtr_canvasGroup = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<MatchStartPanel>.NativeClassPtr, "canvasGroup");
			NativeFieldInfoPtr_uiAlphaFade = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<MatchStartPanel>.NativeClassPtr, "uiAlphaFade");
			NativeFieldInfoPtr_charButtonsParent = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<MatchStartPanel>.NativeClassPtr, "charButtonsParent");
			NativeFieldInfoPtr__chatParent = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<MatchStartPanel>.NativeClassPtr, "_chatParent");
			NativeFieldInfoPtr_localPlayer = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<MatchStartPanel>.NativeClassPtr, "localPlayer");
			NativeFieldInfoPtr_teammatePlayers = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<MatchStartPanel>.NativeClassPtr, "teammatePlayers");
			NativeFieldInfoPtr_matchStartingInText = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<MatchStartPanel>.NativeClassPtr, "matchStartingInText");
			NativeFieldInfoPtr_matchCountdownText = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<MatchStartPanel>.NativeClassPtr, "matchCountdownText");
			NativeFieldInfoPtr_matchCountdownTextTickAnim = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<MatchStartPanel>.NativeClassPtr, "matchCountdownTextTickAnim");
			NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<MatchStartPanel>.NativeClassPtr, 100669687);
		}

		[CallerCount(5410)]
		[CachedScanResults(RefRangeStart = 11, RefRangeEnd = 5421, XrefRangeStart = 11, XrefRangeEnd = 5421, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe MatchStartPanel()
			: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<MatchStartPanel>.NativeClassPtr))
		{
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		public MatchStartPanel(System.IntPtr pointer)
			: base(pointer)
		{
		}
	}

	[System.Serializable]
	public class ReferralCode : Il2CppSystem.Object
	{
		private static readonly System.IntPtr NativeFieldInfoPtr_gameObject;

		private static readonly System.IntPtr NativeFieldInfoPtr_codeButton;

		private static readonly System.IntPtr NativeFieldInfoPtr_referalCodeText;

		private static readonly System.IntPtr NativeFieldInfoPtr_codeUsesText;

		private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

		public unsafe GameObject gameObject
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_gameObject);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<GameObject>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_gameObject)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)gameObject));
			}
		}

		public unsafe Button codeButton
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_codeButton);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Button>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_codeButton)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)button));
			}
		}

		public unsafe TMP_Text referalCodeText
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_referalCodeText);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<TMP_Text>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_referalCodeText)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)tMP_Text));
			}
		}

		public unsafe TMP_Text codeUsesText
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_codeUsesText);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<TMP_Text>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_codeUsesText)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)tMP_Text));
			}
		}

		static ReferralCode()
		{
			Il2CppClassPointerStore<ReferralCode>.NativeClassPtr = IL2CPP.GetIl2CppNestedType(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "ReferralCode");
			IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<ReferralCode>.NativeClassPtr);
			NativeFieldInfoPtr_gameObject = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ReferralCode>.NativeClassPtr, "gameObject");
			NativeFieldInfoPtr_codeButton = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ReferralCode>.NativeClassPtr, "codeButton");
			NativeFieldInfoPtr_referalCodeText = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ReferralCode>.NativeClassPtr, "referalCodeText");
			NativeFieldInfoPtr_codeUsesText = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ReferralCode>.NativeClassPtr, "codeUsesText");
			NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ReferralCode>.NativeClassPtr, 100669690);
		}

		[CallerCount(5410)]
		[CachedScanResults(RefRangeStart = 11, RefRangeEnd = 5421, XrefRangeStart = 11, XrefRangeEnd = 5421, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe ReferralCode()
			: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<ReferralCode>.NativeClassPtr))
		{
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		public ReferralCode(System.IntPtr pointer)
			: base(pointer)
		{
		}
	}

	[System.Serializable]
	public class BattlePassPanel : Il2CppSystem.Object
	{
		private static readonly System.IntPtr NativeFieldInfoPtr_root;

		private static readonly System.IntPtr NativeFieldInfoPtr_BattlePassText;

		private static readonly System.IntPtr NativeFieldInfoPtr_EndsInRemainingDaysText;

		private static readonly System.IntPtr NativeFieldInfoPtr_LevelContainer;

		private static readonly System.IntPtr NativeFieldInfoPtr_LevelText;

		private static readonly System.IntPtr NativeFieldInfoPtr_LevelTextAnim;

		private static readonly System.IntPtr NativeFieldInfoPtr_LevelBarExpText;

		private static readonly System.IntPtr NativeFieldInfoPtr_ProgressBarRect;

		private static readonly System.IntPtr NativeFieldInfoPtr_LevelProgressBar;

		private static readonly System.IntPtr NativeFieldInfoPtr_BarFillAlpha;

		private static readonly System.IntPtr NativeFieldInfoPtr_xpBarLevelUpAlpha;

		private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

		public unsafe GameObject root
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_root);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<GameObject>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_root)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)gameObject));
			}
		}

		public unsafe TMP_Text BattlePassText
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_BattlePassText);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<TMP_Text>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_BattlePassText)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)tMP_Text));
			}
		}

		public unsafe TMP_Text EndsInRemainingDaysText
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_EndsInRemainingDaysText);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<TMP_Text>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_EndsInRemainingDaysText)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)tMP_Text));
			}
		}

		public unsafe Image LevelContainer
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_LevelContainer);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Image>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_LevelContainer)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)image));
			}
		}

		public unsafe TMP_Text LevelText
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_LevelText);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<TMP_Text>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_LevelText)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)tMP_Text));
			}
		}

		public unsafe TransformScaleSimpleAnimation LevelTextAnim
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_LevelTextAnim);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<TransformScaleSimpleAnimation>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_LevelTextAnim)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)transformScaleSimpleAnimation));
			}
		}

		public unsafe TMP_Text LevelBarExpText
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_LevelBarExpText);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<TMP_Text>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_LevelBarExpText)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)tMP_Text));
			}
		}

		public unsafe RectTransform ProgressBarRect
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_ProgressBarRect);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<RectTransform>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_ProgressBarRect)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)rectTransform));
			}
		}

		public unsafe LayoutFitParentPercentage LevelProgressBar
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_LevelProgressBar);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<LayoutFitParentPercentage>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_LevelProgressBar)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)layoutFitParentPercentage));
			}
		}

		public unsafe CanvasGroup BarFillAlpha
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_BarFillAlpha);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<CanvasGroup>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_BarFillAlpha)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)canvasGroup));
			}
		}

		public unsafe CanvasGroup xpBarLevelUpAlpha
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_xpBarLevelUpAlpha);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<CanvasGroup>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_xpBarLevelUpAlpha)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)canvasGroup));
			}
		}

		static BattlePassPanel()
		{
			Il2CppClassPointerStore<BattlePassPanel>.NativeClassPtr = IL2CPP.GetIl2CppNestedType(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "BattlePassPanel");
			IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<BattlePassPanel>.NativeClassPtr);
			NativeFieldInfoPtr_root = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<BattlePassPanel>.NativeClassPtr, "root");
			NativeFieldInfoPtr_BattlePassText = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<BattlePassPanel>.NativeClassPtr, "BattlePassText");
			NativeFieldInfoPtr_EndsInRemainingDaysText = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<BattlePassPanel>.NativeClassPtr, "EndsInRemainingDaysText");
			NativeFieldInfoPtr_LevelContainer = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<BattlePassPanel>.NativeClassPtr, "LevelContainer");
			NativeFieldInfoPtr_LevelText = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<BattlePassPanel>.NativeClassPtr, "LevelText");
			NativeFieldInfoPtr_LevelTextAnim = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<BattlePassPanel>.NativeClassPtr, "LevelTextAnim");
			NativeFieldInfoPtr_LevelBarExpText = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<BattlePassPanel>.NativeClassPtr, "LevelBarExpText");
			NativeFieldInfoPtr_ProgressBarRect = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<BattlePassPanel>.NativeClassPtr, "ProgressBarRect");
			NativeFieldInfoPtr_LevelProgressBar = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<BattlePassPanel>.NativeClassPtr, "LevelProgressBar");
			NativeFieldInfoPtr_BarFillAlpha = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<BattlePassPanel>.NativeClassPtr, "BarFillAlpha");
			NativeFieldInfoPtr_xpBarLevelUpAlpha = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<BattlePassPanel>.NativeClassPtr, "xpBarLevelUpAlpha");
			NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<BattlePassPanel>.NativeClassPtr, 100669691);
		}

		[CallerCount(5410)]
		[CachedScanResults(RefRangeStart = 11, RefRangeEnd = 5421, XrefRangeStart = 11, XrefRangeEnd = 5421, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe BattlePassPanel()
			: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<BattlePassPanel>.NativeClassPtr))
		{
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		public BattlePassPanel(System.IntPtr pointer)
			: base(pointer)
		{
		}
	}

	[System.Serializable]
	public class NotificationsPanel : Il2CppSystem.Object
	{
		private static readonly System.IntPtr NativeFieldInfoPtr_EntryParentTransform;

		private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

		public unsafe Transform EntryParentTransform
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_EntryParentTransform);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Transform>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_EntryParentTransform)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)transform));
			}
		}

		static NotificationsPanel()
		{
			Il2CppClassPointerStore<NotificationsPanel>.NativeClassPtr = IL2CPP.GetIl2CppNestedType(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "NotificationsPanel");
			IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<NotificationsPanel>.NativeClassPtr);
			NativeFieldInfoPtr_EntryParentTransform = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<NotificationsPanel>.NativeClassPtr, "EntryParentTransform");
			NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<NotificationsPanel>.NativeClassPtr, 100669692);
		}

		[CallerCount(5410)]
		[CachedScanResults(RefRangeStart = 11, RefRangeEnd = 5421, XrefRangeStart = 11, XrefRangeEnd = 5421, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe NotificationsPanel()
			: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<NotificationsPanel>.NativeClassPtr))
		{
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		public NotificationsPanel(System.IntPtr pointer)
			: base(pointer)
		{
		}
	}

	[System.Serializable]
	public class LiveWinnerFeed : Il2CppSystem.Object
	{
		private static readonly System.IntPtr NativeFieldInfoPtr_EntryParentTransform;

		private static readonly System.IntPtr NativeFieldInfoPtr_LastWinnersText;

		private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

		public unsafe Transform EntryParentTransform
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_EntryParentTransform);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Transform>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_EntryParentTransform)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)transform));
			}
		}

		public unsafe TMP_Text LastWinnersText
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_LastWinnersText);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<TMP_Text>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_LastWinnersText)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)tMP_Text));
			}
		}

		static LiveWinnerFeed()
		{
			Il2CppClassPointerStore<LiveWinnerFeed>.NativeClassPtr = IL2CPP.GetIl2CppNestedType(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "LiveWinnerFeed");
			IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<LiveWinnerFeed>.NativeClassPtr);
			NativeFieldInfoPtr_EntryParentTransform = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LiveWinnerFeed>.NativeClassPtr, "EntryParentTransform");
			NativeFieldInfoPtr_LastWinnersText = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LiveWinnerFeed>.NativeClassPtr, "LastWinnersText");
			NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<LiveWinnerFeed>.NativeClassPtr, 100669693);
		}

		[CallerCount(5410)]
		[CachedScanResults(RefRangeStart = 11, RefRangeEnd = 5421, XrefRangeStart = 11, XrefRangeEnd = 5421, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe LiveWinnerFeed()
			: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<LiveWinnerFeed>.NativeClassPtr))
		{
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		public LiveWinnerFeed(System.IntPtr pointer)
			: base(pointer)
		{
		}
	}

	[System.Serializable]
	public class NewsPreviewButton : Il2CppSystem.Object
	{
		private static readonly System.IntPtr NativeFieldInfoPtr_Button;

		private static readonly System.IntPtr NativeFieldInfoPtr_previewHolderParent;

		private static readonly System.IntPtr NativeFieldInfoPtr_previewIconParent;

		private static readonly System.IntPtr NativeFieldInfoPtr_IconTemplate;

		private static readonly System.IntPtr NativeFieldInfoPtr_notificationObj;

		private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

		public unsafe Button Button
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_Button);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Button>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_Button)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)button));
			}
		}

		public unsafe Transform previewHolderParent
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_previewHolderParent);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Transform>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_previewHolderParent)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)transform));
			}
		}

		public unsafe Transform previewIconParent
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_previewIconParent);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Transform>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_previewIconParent)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)transform));
			}
		}

		public unsafe Image IconTemplate
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_IconTemplate);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Image>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_IconTemplate)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)image));
			}
		}

		public unsafe GameObject notificationObj
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_notificationObj);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<GameObject>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_notificationObj)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)gameObject));
			}
		}

		static NewsPreviewButton()
		{
			Il2CppClassPointerStore<NewsPreviewButton>.NativeClassPtr = IL2CPP.GetIl2CppNestedType(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "NewsPreviewButton");
			IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<NewsPreviewButton>.NativeClassPtr);
			NativeFieldInfoPtr_Button = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<NewsPreviewButton>.NativeClassPtr, "Button");
			NativeFieldInfoPtr_previewHolderParent = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<NewsPreviewButton>.NativeClassPtr, "previewHolderParent");
			NativeFieldInfoPtr_previewIconParent = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<NewsPreviewButton>.NativeClassPtr, "previewIconParent");
			NativeFieldInfoPtr_IconTemplate = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<NewsPreviewButton>.NativeClassPtr, "IconTemplate");
			NativeFieldInfoPtr_notificationObj = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<NewsPreviewButton>.NativeClassPtr, "notificationObj");
			NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<NewsPreviewButton>.NativeClassPtr, 100669694);
		}

		[CallerCount(5410)]
		[CachedScanResults(RefRangeStart = 11, RefRangeEnd = 5421, XrefRangeStart = 11, XrefRangeEnd = 5421, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe NewsPreviewButton()
			: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<NewsPreviewButton>.NativeClassPtr))
		{
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		public NewsPreviewButton(System.IntPtr pointer)
			: base(pointer)
		{
		}
	}

	[System.Serializable]
	public class Configuration : Il2CppSystem.Object
	{
		private static readonly System.IntPtr NativeFieldInfoPtr_GameModesConfiguration;

		private static readonly System.IntPtr NativeFieldInfoPtr_CharacterConfiguration;

		private static readonly System.IntPtr NativeFieldInfoPtr_contentConfig;

		private static readonly System.IntPtr NativeFieldInfoPtr_playerBannerData;

		private static readonly System.IntPtr NativeFieldInfoPtr_readyButtonConfig;

		private static readonly System.IntPtr NativeFieldInfoPtr_ReadyStatusTranslationKey;

		private static readonly System.IntPtr NativeFieldInfoPtr_NotReadyStatusTranslationKey;

		private static readonly System.IntPtr NativeFieldInfoPtr_InQueueStatusTranslationKey;

		private static readonly System.IntPtr NativeFieldInfoPtr_QueueFindingPlayersTranslationKey;

		private static readonly System.IntPtr NativeFieldInfoPtr_QueueGameStartingTranslationKey;

		private static readonly System.IntPtr NativeFieldInfoPtr_InviteButtonTranslationKey;

		private static readonly System.IntPtr NativeFieldInfoPtr_LobbyCodeTranslationKey;

		private static readonly System.IntPtr NativeFieldInfoPtr_ReadyButtonTranslationKey;

		private static readonly System.IntPtr NativeFieldInfoPtr_UnreadyButtonTranslationKey;

		private static readonly System.IntPtr NativeFieldInfoPtr_CancelButtonTranslationKey;

		private static readonly System.IntPtr NativeFieldInfoPtr_CharacterSelectButtonTranslationKey;

		private static readonly System.IntPtr NativeFieldInfoPtr_PlayersOnlineTranslationKey;

		private static readonly System.IntPtr NativeFieldInfoPtr_LinkCopiedPopUpTranslationKey;

		private static readonly System.IntPtr NativeFieldInfoPtr_PlayerDisplayIsOnQueue;

		private static readonly System.IntPtr NativeFieldInfoPtr_GameModeTranslationKey;

		private static readonly System.IntPtr NativeFieldInfoPtr_BapPassNameText;

		private static readonly System.IntPtr NativeFieldInfoPtr_PastWinnersTranslationKey;

		private static readonly System.IntPtr NativeFieldInfoPtr_LevelTranslationKey;

		private static readonly System.IntPtr NativeFieldInfoPtr_MaxLevelTranslationKey;

		private static readonly System.IntPtr NativeFieldInfoPtr_GameModeEventStartsInStrTranslationKey;

		private static readonly System.IntPtr NativeFieldInfoPtr_GameStartingInTranslationKey;

		private static readonly System.IntPtr NativeFieldInfoPtr_ServersAreDownMessage;

		private static readonly System.IntPtr NativeFieldInfoPtr_dailyRewardTranslationKey;

		private static readonly System.IntPtr NativeFieldInfoPtr_dailyRewardTooltipDescTranslationKey;

		private static readonly System.IntPtr NativeFieldInfoPtr_dailyRewardCompletedTranslationKey;

		private static readonly System.IntPtr NativeFieldInfoPtr_dailyRewardRefreshesInTranslationKey;

		private static readonly System.IntPtr NativeFieldInfoPtr_dailyRefreshDateFormatStr;

		private static readonly System.IntPtr NativeFieldInfoPtr_goldCurrencyTooltipTitleTranslationKey;

		private static readonly System.IntPtr NativeFieldInfoPtr_goldCurrencyTooltipDescTranslationKey;

		private static readonly System.IntPtr NativeFieldInfoPtr_fractalCurrencyTooltipTitleTranslationKey;

		private static readonly System.IntPtr NativeFieldInfoPtr_fractalCurrencyTooltipDescTranslationKey;

		private static readonly System.IntPtr NativeFieldInfoPtr_onlineTranslationKey;

		private static readonly System.IntPtr NativeFieldInfoPtr_offlineTranslationKey;

		private static readonly System.IntPtr NativeFieldInfoPtr_steamOnlineTranslationKey;

		private static readonly System.IntPtr NativeFieldInfoPtr_steamOfflineTranslationKey;

		private static readonly System.IntPtr NativeFieldInfoPtr_inviteLobbyNotifTranslationKey;

		private static readonly System.IntPtr NativeFieldInfoPtr_sentAGameInviteToTranslationKey;

		private static readonly System.IntPtr NativeFieldInfoPtr_friendInviteSentToTranslationKey;

		private static readonly System.IntPtr NativeFieldInfoPtr_friendInviteSentErrorTranslationKey;

		private static readonly System.IntPtr NativeFieldInfoPtr_friendRequestAcceptedTranslationKey;

		private static readonly System.IntPtr NativeFieldInfoPtr_usernameIdCopiedTranslationKey;

		private static readonly System.IntPtr NativeFieldInfoPtr_friendJoinLobbyTranslationKey;

		private static readonly System.IntPtr NativeFieldInfoPtr_leaveLobbyTranslationKey;

		private static readonly System.IntPtr NativeFieldInfoPtr_friendInviteToGameTranslationKey;

		private static readonly System.IntPtr NativeFieldInfoPtr_friendMessageFriendTranslationKey;

		private static readonly System.IntPtr NativeFieldInfoPtr_friendViewProfileTranslationKey;

		private static readonly System.IntPtr NativeFieldInfoPtr_friendUnfriendTranslationKey;

		private static readonly System.IntPtr NativeFieldInfoPtr_areYouSureUnfriendTranslationKey;

		private static readonly System.IntPtr NativeFieldInfoPtr_sendFriendRequestTranslationKey;

		private static readonly System.IntPtr NativeFieldInfoPtr_playerKickTranslationKey;

		private static readonly System.IntPtr NativeFieldInfoPtr_guestLogInTextTranslationKey;

		private static readonly System.IntPtr NativeFieldInfoPtr_logInTextTranslationKey;

		private static readonly System.IntPtr NativeFieldInfoPtr_noFriendsTranslationKey;

		private static readonly System.IntPtr NativeFieldInfoPtr_noFriendRequestsTranslationKey;

		private static readonly System.IntPtr NativeFieldInfoPtr_addFriendTranslationKey;

		private static readonly System.IntPtr NativeFieldInfoPtr_closedPartyTranslationKey;

		private static readonly System.IntPtr NativeFieldInfoPtr_lobbyCodeHiddenStr;

		private static readonly System.IntPtr NativeFieldInfoPtr_closeTranslationKey;

		private static readonly System.IntPtr NativeFieldInfoPtr_optionJoinLobbyIcon;

		private static readonly System.IntPtr NativeFieldInfoPtr_optionInviteToGameIcon;

		private static readonly System.IntPtr NativeFieldInfoPtr_optionMessageFriendIcon;

		private static readonly System.IntPtr NativeFieldInfoPtr_optionViewProfileIcon;

		private static readonly System.IntPtr NativeFieldInfoPtr_optionUnfriendIcon;

		private static readonly System.IntPtr NativeFieldInfoPtr_optionSendFriendRequestIcon;

		private static readonly System.IntPtr NativeFieldInfoPtr_optionLeaveLobbyIcon;

		private static readonly System.IntPtr NativeFieldInfoPtr_optionPlayerKickIcon;

		private static readonly System.IntPtr NativeFieldInfoPtr_TabSelectedAlpha;

		private static readonly System.IntPtr NativeFieldInfoPtr_TabUnselectedAlpha;

		private static readonly System.IntPtr NativeFieldInfoPtr_usernameIdDiscriminatorAlphaHex;

		private static readonly System.IntPtr NativeFieldInfoPtr_ReadyColour;

		private static readonly System.IntPtr NativeFieldInfoPtr_NotReadyColour;

		private static readonly System.IntPtr NativeFieldInfoPtr_InQueueColour;

		private static readonly System.IntPtr NativeFieldInfoPtr_LeaderIconColour;

		private static readonly System.IntPtr NativeFieldInfoPtr_PlayersOnlineIconColour;

		private static readonly System.IntPtr NativeFieldInfoPtr_friendOnlineColor;

		private static readonly System.IntPtr NativeFieldInfoPtr_friendOfflineColor;

		private static readonly System.IntPtr NativeFieldInfoPtr_friendInvitePopUp;

		private static readonly System.IntPtr NativeFieldInfoPtr_playerInQueueDisplayAlpha;

		private static readonly System.IntPtr NativeFieldInfoPtr_playButtonCooldownTime;

		private static readonly System.IntPtr NativeFieldInfoPtr_minLevelForDefaultGmWarmup;

		private static readonly System.IntPtr NativeFieldInfoPtr_GmWarmupId;

		private static readonly System.IntPtr NativeFieldInfoPtr_lobbyCodeCharLength;

		private static readonly System.IntPtr NativeFieldInfoPtr_MatchStartCharacterSelectIconConfiguration;

		private static readonly System.IntPtr NativeFieldInfoPtr_MatchStartCharacterSelectAnimation;

		private static readonly System.IntPtr NativeFieldInfoPtr_FriendEntryConfiguration;

		private static readonly System.IntPtr NativeFieldInfoPtr_FriendRequestEntryConfiguration;

		private static readonly System.IntPtr NativeFieldInfoPtr_NotificationEntryConfiguration;

		private static readonly System.IntPtr NativeFieldInfoPtr_LiveWinnerFeedEntryConfiguration;

		private static readonly System.IntPtr NativeFieldInfoPtr_friendEntryPrefab;

		private static readonly System.IntPtr NativeFieldInfoPtr_friendSeparatorEntryPrefab;

		private static readonly System.IntPtr NativeFieldInfoPtr_playerJoinedLobbySfx;

		private static readonly System.IntPtr NativeFieldInfoPtr_playerJoinedLobbySfxVolume;

		private static readonly System.IntPtr NativeFieldInfoPtr_teamJoinedSfx;

		private static readonly System.IntPtr NativeFieldInfoPtr_teamJoinedSfxVolume;

		private static readonly System.IntPtr NativeFieldInfoPtr_matchCountdownTickSfx;

		private static readonly System.IntPtr NativeFieldInfoPtr_matchCountdownLastTickSfx;

		private static readonly System.IntPtr NativeFieldInfoPtr_matchStartCountdownTextColor;

		private static readonly System.IntPtr NativeFieldInfoPtr_matchStartCountdownTextLastTicksColor;

		private static readonly System.IntPtr NativeFieldInfoPtr_matchCountdownTickStartSeconds;

		private static readonly System.IntPtr NativeFieldInfoPtr_matchCountdownLastTickStartSeconds;

		private static readonly System.IntPtr NativeFieldInfoPtr_defaultPlayerBannerIds;

		private static readonly System.IntPtr NativeFieldInfoPtr_rewardSequenceTimeBetweenAnim;

		private static readonly System.IntPtr NativeFieldInfoPtr_expBarLerpDuration;

		private static readonly System.IntPtr NativeFieldInfoPtr_expBarLerpCurve;

		private static readonly System.IntPtr NativeFieldInfoPtr_expBarLevelUpDuration;

		private static readonly System.IntPtr NativeFieldInfoPtr_xpBarLevelUpAlphaCurve;

		private static readonly System.IntPtr NativeFieldInfoPtr_xpBarLevelUpFillAlphaCurve;

		private static readonly System.IntPtr NativeFieldInfoPtr_battlePassLevelUpSfx;

		private static readonly System.IntPtr NativeFieldInfoPtr_battlePassLevelUpSfxVolume;

		private static readonly System.IntPtr NativeFieldInfoPtr_currencyLerpDuration;

		private static readonly System.IntPtr NativeFieldInfoPtr_softCurrencyLerpCurve;

		private static readonly System.IntPtr NativeFieldInfoPtr_dailyRewardLerpDuration;

		private static readonly System.IntPtr NativeFieldInfoPtr_dailyRewardLerpCurve;

		private static readonly System.IntPtr NativeFieldInfoPtr_newsConfig;

		private static readonly System.IntPtr NativeFieldInfoPtr_lobbyStatusConfig;

		private static readonly System.IntPtr NativeFieldInfoPtr_invitePageConfig;

		private static readonly System.IntPtr NativeFieldInfoPtr_challengeSeeMoreButtonTranslationKey;

		private static readonly System.IntPtr NativeFieldInfoPtr_challengeSignUpTranslationKey;

		private static readonly System.IntPtr NativeFieldInfoPtr_challengeXSignUpsOutOfYTranslationKey;

		private static readonly System.IntPtr NativeFieldInfoPtr_challengeEventTitleTranslationKey;

		private static readonly System.IntPtr NativeFieldInfoPtr_challengeEventLivesTranslationKey;

		private static readonly System.IntPtr NativeFieldInfoPtr_challengeDisclaimerHeaderTranslationKey;

		private static readonly System.IntPtr NativeFieldInfoPtr_challengeDisclaimerTranslationKey;

		private static readonly System.IntPtr NativeFieldInfoPtr_challengeDisclaimerNoRefundsTranslationKey;

		private static readonly System.IntPtr NativeFieldInfoPtr_readyUpTranslationKey;

		private static readonly System.IntPtr NativeFieldInfoPtr_outOfLivesHeaderTranslationKey;

		private static readonly System.IntPtr NativeFieldInfoPtr_outOfLivesTranslationKey;

		private static readonly System.IntPtr NativeFieldInfoPtr_outOfLivesObtainMoreTranslationKey;

		private static readonly System.IntPtr NativeFieldInfoPtr_getMoreLivesButtonTranslationKey;

		private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

		public unsafe GameModesConfiguration GameModesConfiguration
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_GameModesConfiguration);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<GameModesConfiguration>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_GameModesConfiguration)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)gameModesConfiguration));
			}
		}

		public unsafe UICharactersConfiguration CharacterConfiguration
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_CharacterConfiguration);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<UICharactersConfiguration>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_CharacterConfiguration)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)uICharactersConfiguration));
			}
		}

		public unsafe ContentConfiguration contentConfig
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_contentConfig);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<ContentConfiguration>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_contentConfig)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)contentConfiguration));
			}
		}

		public unsafe PlayerBannerData playerBannerData
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_playerBannerData);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<PlayerBannerData>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_playerBannerData)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)playerBannerData));
			}
		}

		public unsafe View_Lobby_ReadyButton.Configuration readyButtonConfig
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_readyButtonConfig);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<View_Lobby_ReadyButton.Configuration>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_readyButtonConfig)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)configuration));
			}
		}

		public unsafe string ReadyStatusTranslationKey
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_ReadyStatusTranslationKey);
				return IL2CPP.Il2CppStringToManaged(*(System.IntPtr*)num);
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_ReadyStatusTranslationKey)), IL2CPP.ManagedStringToIl2Cpp(text));
			}
		}

		public unsafe string NotReadyStatusTranslationKey
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_NotReadyStatusTranslationKey);
				return IL2CPP.Il2CppStringToManaged(*(System.IntPtr*)num);
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_NotReadyStatusTranslationKey)), IL2CPP.ManagedStringToIl2Cpp(text));
			}
		}

		public unsafe string InQueueStatusTranslationKey
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_InQueueStatusTranslationKey);
				return IL2CPP.Il2CppStringToManaged(*(System.IntPtr*)num);
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_InQueueStatusTranslationKey)), IL2CPP.ManagedStringToIl2Cpp(text));
			}
		}

		public unsafe string QueueFindingPlayersTranslationKey
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_QueueFindingPlayersTranslationKey);
				return IL2CPP.Il2CppStringToManaged(*(System.IntPtr*)num);
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_QueueFindingPlayersTranslationKey)), IL2CPP.ManagedStringToIl2Cpp(text));
			}
		}

		public unsafe string QueueGameStartingTranslationKey
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_QueueGameStartingTranslationKey);
				return IL2CPP.Il2CppStringToManaged(*(System.IntPtr*)num);
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_QueueGameStartingTranslationKey)), IL2CPP.ManagedStringToIl2Cpp(text));
			}
		}

		public unsafe string InviteButtonTranslationKey
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_InviteButtonTranslationKey);
				return IL2CPP.Il2CppStringToManaged(*(System.IntPtr*)num);
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_InviteButtonTranslationKey)), IL2CPP.ManagedStringToIl2Cpp(text));
			}
		}

		public unsafe string LobbyCodeTranslationKey
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_LobbyCodeTranslationKey);
				return IL2CPP.Il2CppStringToManaged(*(System.IntPtr*)num);
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_LobbyCodeTranslationKey)), IL2CPP.ManagedStringToIl2Cpp(text));
			}
		}

		public unsafe string ReadyButtonTranslationKey
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_ReadyButtonTranslationKey);
				return IL2CPP.Il2CppStringToManaged(*(System.IntPtr*)num);
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_ReadyButtonTranslationKey)), IL2CPP.ManagedStringToIl2Cpp(text));
			}
		}

		public unsafe string UnreadyButtonTranslationKey
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_UnreadyButtonTranslationKey);
				return IL2CPP.Il2CppStringToManaged(*(System.IntPtr*)num);
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_UnreadyButtonTranslationKey)), IL2CPP.ManagedStringToIl2Cpp(text));
			}
		}

		public unsafe string CancelButtonTranslationKey
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_CancelButtonTranslationKey);
				return IL2CPP.Il2CppStringToManaged(*(System.IntPtr*)num);
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_CancelButtonTranslationKey)), IL2CPP.ManagedStringToIl2Cpp(text));
			}
		}

		public unsafe string CharacterSelectButtonTranslationKey
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_CharacterSelectButtonTranslationKey);
				return IL2CPP.Il2CppStringToManaged(*(System.IntPtr*)num);
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_CharacterSelectButtonTranslationKey)), IL2CPP.ManagedStringToIl2Cpp(text));
			}
		}

		public unsafe string PlayersOnlineTranslationKey
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_PlayersOnlineTranslationKey);
				return IL2CPP.Il2CppStringToManaged(*(System.IntPtr*)num);
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_PlayersOnlineTranslationKey)), IL2CPP.ManagedStringToIl2Cpp(text));
			}
		}

		public unsafe string LinkCopiedPopUpTranslationKey
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_LinkCopiedPopUpTranslationKey);
				return IL2CPP.Il2CppStringToManaged(*(System.IntPtr*)num);
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_LinkCopiedPopUpTranslationKey)), IL2CPP.ManagedStringToIl2Cpp(text));
			}
		}

		public unsafe string PlayerDisplayIsOnQueue
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_PlayerDisplayIsOnQueue);
				return IL2CPP.Il2CppStringToManaged(*(System.IntPtr*)num);
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_PlayerDisplayIsOnQueue)), IL2CPP.ManagedStringToIl2Cpp(text));
			}
		}

		public unsafe string GameModeTranslationKey
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_GameModeTranslationKey);
				return IL2CPP.Il2CppStringToManaged(*(System.IntPtr*)num);
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_GameModeTranslationKey)), IL2CPP.ManagedStringToIl2Cpp(text));
			}
		}

		public unsafe string BapPassNameText
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_BapPassNameText);
				return IL2CPP.Il2CppStringToManaged(*(System.IntPtr*)num);
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_BapPassNameText)), IL2CPP.ManagedStringToIl2Cpp(text));
			}
		}

		public unsafe string PastWinnersTranslationKey
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_PastWinnersTranslationKey);
				return IL2CPP.Il2CppStringToManaged(*(System.IntPtr*)num);
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_PastWinnersTranslationKey)), IL2CPP.ManagedStringToIl2Cpp(text));
			}
		}

		public unsafe string LevelTranslationKey
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_LevelTranslationKey);
				return IL2CPP.Il2CppStringToManaged(*(System.IntPtr*)num);
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_LevelTranslationKey)), IL2CPP.ManagedStringToIl2Cpp(text));
			}
		}

		public unsafe string MaxLevelTranslationKey
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_MaxLevelTranslationKey);
				return IL2CPP.Il2CppStringToManaged(*(System.IntPtr*)num);
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_MaxLevelTranslationKey)), IL2CPP.ManagedStringToIl2Cpp(text));
			}
		}

		public unsafe string GameModeEventStartsInStrTranslationKey
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_GameModeEventStartsInStrTranslationKey);
				return IL2CPP.Il2CppStringToManaged(*(System.IntPtr*)num);
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_GameModeEventStartsInStrTranslationKey)), IL2CPP.ManagedStringToIl2Cpp(text));
			}
		}

		public unsafe string GameStartingInTranslationKey
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_GameStartingInTranslationKey);
				return IL2CPP.Il2CppStringToManaged(*(System.IntPtr*)num);
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_GameStartingInTranslationKey)), IL2CPP.ManagedStringToIl2Cpp(text));
			}
		}

		public unsafe string ServersAreDownMessage
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_ServersAreDownMessage);
				return IL2CPP.Il2CppStringToManaged(*(System.IntPtr*)num);
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_ServersAreDownMessage)), IL2CPP.ManagedStringToIl2Cpp(text));
			}
		}

		public unsafe string dailyRewardTranslationKey
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_dailyRewardTranslationKey);
				return IL2CPP.Il2CppStringToManaged(*(System.IntPtr*)num);
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_dailyRewardTranslationKey)), IL2CPP.ManagedStringToIl2Cpp(text));
			}
		}

		public unsafe string dailyRewardTooltipDescTranslationKey
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_dailyRewardTooltipDescTranslationKey);
				return IL2CPP.Il2CppStringToManaged(*(System.IntPtr*)num);
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_dailyRewardTooltipDescTranslationKey)), IL2CPP.ManagedStringToIl2Cpp(text));
			}
		}

		public unsafe string dailyRewardCompletedTranslationKey
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_dailyRewardCompletedTranslationKey);
				return IL2CPP.Il2CppStringToManaged(*(System.IntPtr*)num);
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_dailyRewardCompletedTranslationKey)), IL2CPP.ManagedStringToIl2Cpp(text));
			}
		}

		public unsafe string dailyRewardRefreshesInTranslationKey
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_dailyRewardRefreshesInTranslationKey);
				return IL2CPP.Il2CppStringToManaged(*(System.IntPtr*)num);
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_dailyRewardRefreshesInTranslationKey)), IL2CPP.ManagedStringToIl2Cpp(text));
			}
		}

		public unsafe string dailyRefreshDateFormatStr
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_dailyRefreshDateFormatStr);
				return IL2CPP.Il2CppStringToManaged(*(System.IntPtr*)num);
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_dailyRefreshDateFormatStr)), IL2CPP.ManagedStringToIl2Cpp(text));
			}
		}

		public unsafe string goldCurrencyTooltipTitleTranslationKey
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_goldCurrencyTooltipTitleTranslationKey);
				return IL2CPP.Il2CppStringToManaged(*(System.IntPtr*)num);
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_goldCurrencyTooltipTitleTranslationKey)), IL2CPP.ManagedStringToIl2Cpp(text));
			}
		}

		public unsafe string goldCurrencyTooltipDescTranslationKey
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_goldCurrencyTooltipDescTranslationKey);
				return IL2CPP.Il2CppStringToManaged(*(System.IntPtr*)num);
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_goldCurrencyTooltipDescTranslationKey)), IL2CPP.ManagedStringToIl2Cpp(text));
			}
		}

		public unsafe string fractalCurrencyTooltipTitleTranslationKey
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_fractalCurrencyTooltipTitleTranslationKey);
				return IL2CPP.Il2CppStringToManaged(*(System.IntPtr*)num);
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_fractalCurrencyTooltipTitleTranslationKey)), IL2CPP.ManagedStringToIl2Cpp(text));
			}
		}

		public unsafe string fractalCurrencyTooltipDescTranslationKey
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_fractalCurrencyTooltipDescTranslationKey);
				return IL2CPP.Il2CppStringToManaged(*(System.IntPtr*)num);
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_fractalCurrencyTooltipDescTranslationKey)), IL2CPP.ManagedStringToIl2Cpp(text));
			}
		}

		public unsafe string onlineTranslationKey
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_onlineTranslationKey);
				return IL2CPP.Il2CppStringToManaged(*(System.IntPtr*)num);
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_onlineTranslationKey)), IL2CPP.ManagedStringToIl2Cpp(text));
			}
		}

		public unsafe string offlineTranslationKey
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_offlineTranslationKey);
				return IL2CPP.Il2CppStringToManaged(*(System.IntPtr*)num);
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_offlineTranslationKey)), IL2CPP.ManagedStringToIl2Cpp(text));
			}
		}

		public unsafe string steamOnlineTranslationKey
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_steamOnlineTranslationKey);
				return IL2CPP.Il2CppStringToManaged(*(System.IntPtr*)num);
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_steamOnlineTranslationKey)), IL2CPP.ManagedStringToIl2Cpp(text));
			}
		}

		public unsafe string steamOfflineTranslationKey
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_steamOfflineTranslationKey);
				return IL2CPP.Il2CppStringToManaged(*(System.IntPtr*)num);
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_steamOfflineTranslationKey)), IL2CPP.ManagedStringToIl2Cpp(text));
			}
		}

		public unsafe string inviteLobbyNotifTranslationKey
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_inviteLobbyNotifTranslationKey);
				return IL2CPP.Il2CppStringToManaged(*(System.IntPtr*)num);
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_inviteLobbyNotifTranslationKey)), IL2CPP.ManagedStringToIl2Cpp(text));
			}
		}

		public unsafe string sentAGameInviteToTranslationKey
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_sentAGameInviteToTranslationKey);
				return IL2CPP.Il2CppStringToManaged(*(System.IntPtr*)num);
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_sentAGameInviteToTranslationKey)), IL2CPP.ManagedStringToIl2Cpp(text));
			}
		}

		public unsafe string friendInviteSentToTranslationKey
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_friendInviteSentToTranslationKey);
				return IL2CPP.Il2CppStringToManaged(*(System.IntPtr*)num);
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_friendInviteSentToTranslationKey)), IL2CPP.ManagedStringToIl2Cpp(text));
			}
		}

		public unsafe string friendInviteSentErrorTranslationKey
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_friendInviteSentErrorTranslationKey);
				return IL2CPP.Il2CppStringToManaged(*(System.IntPtr*)num);
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_friendInviteSentErrorTranslationKey)), IL2CPP.ManagedStringToIl2Cpp(text));
			}
		}

		public unsafe string friendRequestAcceptedTranslationKey
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_friendRequestAcceptedTranslationKey);
				return IL2CPP.Il2CppStringToManaged(*(System.IntPtr*)num);
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_friendRequestAcceptedTranslationKey)), IL2CPP.ManagedStringToIl2Cpp(text));
			}
		}

		public unsafe string usernameIdCopiedTranslationKey
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_usernameIdCopiedTranslationKey);
				return IL2CPP.Il2CppStringToManaged(*(System.IntPtr*)num);
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_usernameIdCopiedTranslationKey)), IL2CPP.ManagedStringToIl2Cpp(text));
			}
		}

		public unsafe string friendJoinLobbyTranslationKey
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_friendJoinLobbyTranslationKey);
				return IL2CPP.Il2CppStringToManaged(*(System.IntPtr*)num);
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_friendJoinLobbyTranslationKey)), IL2CPP.ManagedStringToIl2Cpp(text));
			}
		}

		public unsafe string leaveLobbyTranslationKey
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_leaveLobbyTranslationKey);
				return IL2CPP.Il2CppStringToManaged(*(System.IntPtr*)num);
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_leaveLobbyTranslationKey)), IL2CPP.ManagedStringToIl2Cpp(text));
			}
		}

		public unsafe string friendInviteToGameTranslationKey
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_friendInviteToGameTranslationKey);
				return IL2CPP.Il2CppStringToManaged(*(System.IntPtr*)num);
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_friendInviteToGameTranslationKey)), IL2CPP.ManagedStringToIl2Cpp(text));
			}
		}

		public unsafe string friendMessageFriendTranslationKey
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_friendMessageFriendTranslationKey);
				return IL2CPP.Il2CppStringToManaged(*(System.IntPtr*)num);
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_friendMessageFriendTranslationKey)), IL2CPP.ManagedStringToIl2Cpp(text));
			}
		}

		public unsafe string friendViewProfileTranslationKey
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_friendViewProfileTranslationKey);
				return IL2CPP.Il2CppStringToManaged(*(System.IntPtr*)num);
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_friendViewProfileTranslationKey)), IL2CPP.ManagedStringToIl2Cpp(text));
			}
		}

		public unsafe string friendUnfriendTranslationKey
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_friendUnfriendTranslationKey);
				return IL2CPP.Il2CppStringToManaged(*(System.IntPtr*)num);
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_friendUnfriendTranslationKey)), IL2CPP.ManagedStringToIl2Cpp(text));
			}
		}

		public unsafe string areYouSureUnfriendTranslationKey
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_areYouSureUnfriendTranslationKey);
				return IL2CPP.Il2CppStringToManaged(*(System.IntPtr*)num);
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_areYouSureUnfriendTranslationKey)), IL2CPP.ManagedStringToIl2Cpp(text));
			}
		}

		public unsafe string sendFriendRequestTranslationKey
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_sendFriendRequestTranslationKey);
				return IL2CPP.Il2CppStringToManaged(*(System.IntPtr*)num);
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_sendFriendRequestTranslationKey)), IL2CPP.ManagedStringToIl2Cpp(text));
			}
		}

		public unsafe string playerKickTranslationKey
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_playerKickTranslationKey);
				return IL2CPP.Il2CppStringToManaged(*(System.IntPtr*)num);
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_playerKickTranslationKey)), IL2CPP.ManagedStringToIl2Cpp(text));
			}
		}

		public unsafe string guestLogInTextTranslationKey
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_guestLogInTextTranslationKey);
				return IL2CPP.Il2CppStringToManaged(*(System.IntPtr*)num);
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_guestLogInTextTranslationKey)), IL2CPP.ManagedStringToIl2Cpp(text));
			}
		}

		public unsafe string logInTextTranslationKey
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_logInTextTranslationKey);
				return IL2CPP.Il2CppStringToManaged(*(System.IntPtr*)num);
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_logInTextTranslationKey)), IL2CPP.ManagedStringToIl2Cpp(text));
			}
		}

		public unsafe string noFriendsTranslationKey
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_noFriendsTranslationKey);
				return IL2CPP.Il2CppStringToManaged(*(System.IntPtr*)num);
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_noFriendsTranslationKey)), IL2CPP.ManagedStringToIl2Cpp(text));
			}
		}

		public unsafe string noFriendRequestsTranslationKey
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_noFriendRequestsTranslationKey);
				return IL2CPP.Il2CppStringToManaged(*(System.IntPtr*)num);
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_noFriendRequestsTranslationKey)), IL2CPP.ManagedStringToIl2Cpp(text));
			}
		}

		public unsafe string addFriendTranslationKey
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_addFriendTranslationKey);
				return IL2CPP.Il2CppStringToManaged(*(System.IntPtr*)num);
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_addFriendTranslationKey)), IL2CPP.ManagedStringToIl2Cpp(text));
			}
		}

		public unsafe string closedPartyTranslationKey
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_closedPartyTranslationKey);
				return IL2CPP.Il2CppStringToManaged(*(System.IntPtr*)num);
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_closedPartyTranslationKey)), IL2CPP.ManagedStringToIl2Cpp(text));
			}
		}

		public unsafe string lobbyCodeHiddenStr
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_lobbyCodeHiddenStr);
				return IL2CPP.Il2CppStringToManaged(*(System.IntPtr*)num);
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_lobbyCodeHiddenStr)), IL2CPP.ManagedStringToIl2Cpp(text));
			}
		}

		public unsafe string closeTranslationKey
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_closeTranslationKey);
				return IL2CPP.Il2CppStringToManaged(*(System.IntPtr*)num);
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_closeTranslationKey)), IL2CPP.ManagedStringToIl2Cpp(text));
			}
		}

		public unsafe Sprite optionJoinLobbyIcon
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_optionJoinLobbyIcon);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Sprite>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_optionJoinLobbyIcon)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)sprite));
			}
		}

		public unsafe Sprite optionInviteToGameIcon
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_optionInviteToGameIcon);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Sprite>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_optionInviteToGameIcon)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)sprite));
			}
		}

		public unsafe Sprite optionMessageFriendIcon
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_optionMessageFriendIcon);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Sprite>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_optionMessageFriendIcon)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)sprite));
			}
		}

		public unsafe Sprite optionViewProfileIcon
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_optionViewProfileIcon);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Sprite>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_optionViewProfileIcon)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)sprite));
			}
		}

		public unsafe Sprite optionUnfriendIcon
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_optionUnfriendIcon);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Sprite>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_optionUnfriendIcon)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)sprite));
			}
		}

		public unsafe Sprite optionSendFriendRequestIcon
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_optionSendFriendRequestIcon);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Sprite>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_optionSendFriendRequestIcon)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)sprite));
			}
		}

		public unsafe Sprite optionLeaveLobbyIcon
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_optionLeaveLobbyIcon);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Sprite>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_optionLeaveLobbyIcon)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)sprite));
			}
		}

		public unsafe Sprite optionPlayerKickIcon
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_optionPlayerKickIcon);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Sprite>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_optionPlayerKickIcon)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)sprite));
			}
		}

		public unsafe float TabSelectedAlpha
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_TabSelectedAlpha);
				return *(float*)num;
			}
			set
			{
				*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_TabSelectedAlpha)) = num;
			}
		}

		public unsafe float TabUnselectedAlpha
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_TabUnselectedAlpha);
				return *(float*)num;
			}
			set
			{
				*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_TabUnselectedAlpha)) = num;
			}
		}

		public unsafe string usernameIdDiscriminatorAlphaHex
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_usernameIdDiscriminatorAlphaHex);
				return IL2CPP.Il2CppStringToManaged(*(System.IntPtr*)num);
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_usernameIdDiscriminatorAlphaHex)), IL2CPP.ManagedStringToIl2Cpp(text));
			}
		}

		public unsafe Color ReadyColour
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_ReadyColour);
				return *(Color*)num;
			}
			set
			{
				*(Color*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_ReadyColour)) = color;
			}
		}

		public unsafe Color NotReadyColour
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_NotReadyColour);
				return *(Color*)num;
			}
			set
			{
				*(Color*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_NotReadyColour)) = color;
			}
		}

		public unsafe Color InQueueColour
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_InQueueColour);
				return *(Color*)num;
			}
			set
			{
				*(Color*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_InQueueColour)) = color;
			}
		}

		public unsafe Color LeaderIconColour
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_LeaderIconColour);
				return *(Color*)num;
			}
			set
			{
				*(Color*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_LeaderIconColour)) = color;
			}
		}

		public unsafe Color PlayersOnlineIconColour
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_PlayersOnlineIconColour);
				return *(Color*)num;
			}
			set
			{
				*(Color*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_PlayersOnlineIconColour)) = color;
			}
		}

		public unsafe Color friendOnlineColor
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_friendOnlineColor);
				return *(Color*)num;
			}
			set
			{
				*(Color*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_friendOnlineColor)) = color;
			}
		}

		public unsafe Color friendOfflineColor
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_friendOfflineColor);
				return *(Color*)num;
			}
			set
			{
				*(Color*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_friendOfflineColor)) = color;
			}
		}

		public unsafe SFXData friendInvitePopUp
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_friendInvitePopUp);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<SFXData>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_friendInvitePopUp)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)sFXData));
			}
		}

		public unsafe float playerInQueueDisplayAlpha
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_playerInQueueDisplayAlpha);
				return *(float*)num;
			}
			set
			{
				*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_playerInQueueDisplayAlpha)) = num;
			}
		}

		public unsafe float playButtonCooldownTime
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_playButtonCooldownTime);
				return *(float*)num;
			}
			set
			{
				*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_playButtonCooldownTime)) = num;
			}
		}

		public unsafe int minLevelForDefaultGmWarmup
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_minLevelForDefaultGmWarmup);
				return *(int*)num;
			}
			set
			{
				*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_minLevelForDefaultGmWarmup)) = num;
			}
		}

		public unsafe int GmWarmupId
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_GmWarmupId);
				return *(int*)num;
			}
			set
			{
				*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_GmWarmupId)) = num;
			}
		}

		public unsafe int lobbyCodeCharLength
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_lobbyCodeCharLength);
				return *(int*)num;
			}
			set
			{
				*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_lobbyCodeCharLength)) = num;
			}
		}

		public unsafe UILobbyCharacterSelectIcon.Configuration MatchStartCharacterSelectIconConfiguration
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_MatchStartCharacterSelectIconConfiguration);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<UILobbyCharacterSelectIcon.Configuration>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_MatchStartCharacterSelectIconConfiguration)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)configuration));
			}
		}

		public unsafe MatchStartPanel.CharacterSelectPanelAnimation MatchStartCharacterSelectAnimation
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_MatchStartCharacterSelectAnimation);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<MatchStartPanel.CharacterSelectPanelAnimation>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_MatchStartCharacterSelectAnimation)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)characterSelectPanelAnimation));
			}
		}

		public unsafe UILobbyFriendEntry.Configuration FriendEntryConfiguration
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_FriendEntryConfiguration);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<UILobbyFriendEntry.Configuration>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_FriendEntryConfiguration)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)configuration));
			}
		}

		public unsafe UILobbyFriendRequestEntry.Configuration FriendRequestEntryConfiguration
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_FriendRequestEntryConfiguration);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<UILobbyFriendRequestEntry.Configuration>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_FriendRequestEntryConfiguration)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)configuration));
			}
		}

		public unsafe UILobbyNotificationEntry.Configuration NotificationEntryConfiguration
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_NotificationEntryConfiguration);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<UILobbyNotificationEntry.Configuration>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_NotificationEntryConfiguration)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)configuration));
			}
		}

		public unsafe UILobbyLiveWinnerFeedEntry.Configuration LiveWinnerFeedEntryConfiguration
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_LiveWinnerFeedEntryConfiguration);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<UILobbyLiveWinnerFeedEntry.Configuration>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_LiveWinnerFeedEntryConfiguration)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)configuration));
			}
		}

		public unsafe UILobbyFriendEntry friendEntryPrefab
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_friendEntryPrefab);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<UILobbyFriendEntry>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_friendEntryPrefab)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)uILobbyFriendEntry));
			}
		}

		public unsafe UILobbyFriendHolderEntry friendSeparatorEntryPrefab
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_friendSeparatorEntryPrefab);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<UILobbyFriendHolderEntry>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_friendSeparatorEntryPrefab)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)uILobbyFriendHolderEntry));
			}
		}

		public unsafe AudioManager.SFX playerJoinedLobbySfx
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_playerJoinedLobbySfx);
				return *(AudioManager.SFX*)num;
			}
			set
			{
				*(AudioManager.SFX*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_playerJoinedLobbySfx)) = sFX;
			}
		}

		public unsafe float playerJoinedLobbySfxVolume
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_playerJoinedLobbySfxVolume);
				return *(float*)num;
			}
			set
			{
				*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_playerJoinedLobbySfxVolume)) = num;
			}
		}

		public unsafe AudioManager.SFX teamJoinedSfx
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_teamJoinedSfx);
				return *(AudioManager.SFX*)num;
			}
			set
			{
				*(AudioManager.SFX*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_teamJoinedSfx)) = sFX;
			}
		}

		public unsafe float teamJoinedSfxVolume
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_teamJoinedSfxVolume);
				return *(float*)num;
			}
			set
			{
				*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_teamJoinedSfxVolume)) = num;
			}
		}

		public unsafe SFXData matchCountdownTickSfx
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_matchCountdownTickSfx);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<SFXData>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_matchCountdownTickSfx)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)sFXData));
			}
		}

		public unsafe SFXData matchCountdownLastTickSfx
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_matchCountdownLastTickSfx);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<SFXData>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_matchCountdownLastTickSfx)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)sFXData));
			}
		}

		public unsafe Color matchStartCountdownTextColor
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_matchStartCountdownTextColor);
				return *(Color*)num;
			}
			set
			{
				*(Color*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_matchStartCountdownTextColor)) = color;
			}
		}

		public unsafe Color matchStartCountdownTextLastTicksColor
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_matchStartCountdownTextLastTicksColor);
				return *(Color*)num;
			}
			set
			{
				*(Color*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_matchStartCountdownTextLastTicksColor)) = color;
			}
		}

		public unsafe int matchCountdownTickStartSeconds
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_matchCountdownTickStartSeconds);
				return *(int*)num;
			}
			set
			{
				*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_matchCountdownTickStartSeconds)) = num;
			}
		}

		public unsafe int matchCountdownLastTickStartSeconds
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_matchCountdownLastTickStartSeconds);
				return *(int*)num;
			}
			set
			{
				*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_matchCountdownLastTickStartSeconds)) = num;
			}
		}

		public unsafe Il2CppStructArray<int> defaultPlayerBannerIds
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_defaultPlayerBannerIds);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppStructArray<int>>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_defaultPlayerBannerIds)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)val));
			}
		}

		public unsafe float rewardSequenceTimeBetweenAnim
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_rewardSequenceTimeBetweenAnim);
				return *(float*)num;
			}
			set
			{
				*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_rewardSequenceTimeBetweenAnim)) = num;
			}
		}

		public unsafe float expBarLerpDuration
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_expBarLerpDuration);
				return *(float*)num;
			}
			set
			{
				*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_expBarLerpDuration)) = num;
			}
		}

		public unsafe AnimationCurve expBarLerpCurve
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_expBarLerpCurve);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<AnimationCurve>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_expBarLerpCurve)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)animationCurve));
			}
		}

		public unsafe float expBarLevelUpDuration
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_expBarLevelUpDuration);
				return *(float*)num;
			}
			set
			{
				*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_expBarLevelUpDuration)) = num;
			}
		}

		public unsafe AnimationCurve xpBarLevelUpAlphaCurve
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_xpBarLevelUpAlphaCurve);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<AnimationCurve>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_xpBarLevelUpAlphaCurve)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)animationCurve));
			}
		}

		public unsafe AnimationCurve xpBarLevelUpFillAlphaCurve
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_xpBarLevelUpFillAlphaCurve);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<AnimationCurve>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_xpBarLevelUpFillAlphaCurve)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)animationCurve));
			}
		}

		public unsafe AudioManager.SFX battlePassLevelUpSfx
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_battlePassLevelUpSfx);
				return *(AudioManager.SFX*)num;
			}
			set
			{
				*(AudioManager.SFX*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_battlePassLevelUpSfx)) = sFX;
			}
		}

		public unsafe float battlePassLevelUpSfxVolume
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_battlePassLevelUpSfxVolume);
				return *(float*)num;
			}
			set
			{
				*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_battlePassLevelUpSfxVolume)) = num;
			}
		}

		public unsafe float currencyLerpDuration
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_currencyLerpDuration);
				return *(float*)num;
			}
			set
			{
				*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_currencyLerpDuration)) = num;
			}
		}

		public unsafe AnimationCurve softCurrencyLerpCurve
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_softCurrencyLerpCurve);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<AnimationCurve>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_softCurrencyLerpCurve)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)animationCurve));
			}
		}

		public unsafe float dailyRewardLerpDuration
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_dailyRewardLerpDuration);
				return *(float*)num;
			}
			set
			{
				*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_dailyRewardLerpDuration)) = num;
			}
		}

		public unsafe AnimationCurve dailyRewardLerpCurve
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_dailyRewardLerpCurve);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<AnimationCurve>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_dailyRewardLerpCurve)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)animationCurve));
			}
		}

		public unsafe View_Lobby_News.Configuration newsConfig
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_newsConfig);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<View_Lobby_News.Configuration>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_newsConfig)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)configuration));
			}
		}

		public unsafe View_Lobby_OpenLobbyToggle.Configuration lobbyStatusConfig
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_lobbyStatusConfig);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<View_Lobby_OpenLobbyToggle.Configuration>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_lobbyStatusConfig)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)configuration));
			}
		}

		public unsafe View_Lobby_InviteCodePage.Configuration invitePageConfig
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_invitePageConfig);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<View_Lobby_InviteCodePage.Configuration>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_invitePageConfig)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)configuration));
			}
		}

		public unsafe string challengeSeeMoreButtonTranslationKey
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_challengeSeeMoreButtonTranslationKey);
				return IL2CPP.Il2CppStringToManaged(*(System.IntPtr*)num);
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_challengeSeeMoreButtonTranslationKey)), IL2CPP.ManagedStringToIl2Cpp(text));
			}
		}

		public unsafe string challengeSignUpTranslationKey
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_challengeSignUpTranslationKey);
				return IL2CPP.Il2CppStringToManaged(*(System.IntPtr*)num);
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_challengeSignUpTranslationKey)), IL2CPP.ManagedStringToIl2Cpp(text));
			}
		}

		public unsafe string challengeXSignUpsOutOfYTranslationKey
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_challengeXSignUpsOutOfYTranslationKey);
				return IL2CPP.Il2CppStringToManaged(*(System.IntPtr*)num);
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_challengeXSignUpsOutOfYTranslationKey)), IL2CPP.ManagedStringToIl2Cpp(text));
			}
		}

		public unsafe string challengeEventTitleTranslationKey
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_challengeEventTitleTranslationKey);
				return IL2CPP.Il2CppStringToManaged(*(System.IntPtr*)num);
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_challengeEventTitleTranslationKey)), IL2CPP.ManagedStringToIl2Cpp(text));
			}
		}

		public unsafe string challengeEventLivesTranslationKey
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_challengeEventLivesTranslationKey);
				return IL2CPP.Il2CppStringToManaged(*(System.IntPtr*)num);
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_challengeEventLivesTranslationKey)), IL2CPP.ManagedStringToIl2Cpp(text));
			}
		}

		public unsafe string challengeDisclaimerHeaderTranslationKey
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_challengeDisclaimerHeaderTranslationKey);
				return IL2CPP.Il2CppStringToManaged(*(System.IntPtr*)num);
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_challengeDisclaimerHeaderTranslationKey)), IL2CPP.ManagedStringToIl2Cpp(text));
			}
		}

		public unsafe string challengeDisclaimerTranslationKey
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_challengeDisclaimerTranslationKey);
				return IL2CPP.Il2CppStringToManaged(*(System.IntPtr*)num);
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_challengeDisclaimerTranslationKey)), IL2CPP.ManagedStringToIl2Cpp(text));
			}
		}

		public unsafe string challengeDisclaimerNoRefundsTranslationKey
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_challengeDisclaimerNoRefundsTranslationKey);
				return IL2CPP.Il2CppStringToManaged(*(System.IntPtr*)num);
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_challengeDisclaimerNoRefundsTranslationKey)), IL2CPP.ManagedStringToIl2Cpp(text));
			}
		}

		public unsafe string readyUpTranslationKey
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_readyUpTranslationKey);
				return IL2CPP.Il2CppStringToManaged(*(System.IntPtr*)num);
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_readyUpTranslationKey)), IL2CPP.ManagedStringToIl2Cpp(text));
			}
		}

		public unsafe string outOfLivesHeaderTranslationKey
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_outOfLivesHeaderTranslationKey);
				return IL2CPP.Il2CppStringToManaged(*(System.IntPtr*)num);
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_outOfLivesHeaderTranslationKey)), IL2CPP.ManagedStringToIl2Cpp(text));
			}
		}

		public unsafe string outOfLivesTranslationKey
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_outOfLivesTranslationKey);
				return IL2CPP.Il2CppStringToManaged(*(System.IntPtr*)num);
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_outOfLivesTranslationKey)), IL2CPP.ManagedStringToIl2Cpp(text));
			}
		}

		public unsafe string outOfLivesObtainMoreTranslationKey
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_outOfLivesObtainMoreTranslationKey);
				return IL2CPP.Il2CppStringToManaged(*(System.IntPtr*)num);
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_outOfLivesObtainMoreTranslationKey)), IL2CPP.ManagedStringToIl2Cpp(text));
			}
		}

		public unsafe string getMoreLivesButtonTranslationKey
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_getMoreLivesButtonTranslationKey);
				return IL2CPP.Il2CppStringToManaged(*(System.IntPtr*)num);
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_getMoreLivesButtonTranslationKey)), IL2CPP.ManagedStringToIl2Cpp(text));
			}
		}

		static Configuration()
		{
			Il2CppClassPointerStore<Configuration>.NativeClassPtr = IL2CPP.GetIl2CppNestedType(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "Configuration");
			IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<Configuration>.NativeClassPtr);
			NativeFieldInfoPtr_GameModesConfiguration = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Configuration>.NativeClassPtr, "GameModesConfiguration");
			NativeFieldInfoPtr_CharacterConfiguration = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Configuration>.NativeClassPtr, "CharacterConfiguration");
			NativeFieldInfoPtr_contentConfig = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Configuration>.NativeClassPtr, "contentConfig");
			NativeFieldInfoPtr_playerBannerData = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Configuration>.NativeClassPtr, "playerBannerData");
			NativeFieldInfoPtr_readyButtonConfig = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Configuration>.NativeClassPtr, "readyButtonConfig");
			NativeFieldInfoPtr_ReadyStatusTranslationKey = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Configuration>.NativeClassPtr, "ReadyStatusTranslationKey");
			NativeFieldInfoPtr_NotReadyStatusTranslationKey = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Configuration>.NativeClassPtr, "NotReadyStatusTranslationKey");
			NativeFieldInfoPtr_InQueueStatusTranslationKey = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Configuration>.NativeClassPtr, "InQueueStatusTranslationKey");
			NativeFieldInfoPtr_QueueFindingPlayersTranslationKey = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Configuration>.NativeClassPtr, "QueueFindingPlayersTranslationKey");
			NativeFieldInfoPtr_QueueGameStartingTranslationKey = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Configuration>.NativeClassPtr, "QueueGameStartingTranslationKey");
			NativeFieldInfoPtr_InviteButtonTranslationKey = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Configuration>.NativeClassPtr, "InviteButtonTranslationKey");
			NativeFieldInfoPtr_LobbyCodeTranslationKey = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Configuration>.NativeClassPtr, "LobbyCodeTranslationKey");
			NativeFieldInfoPtr_ReadyButtonTranslationKey = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Configuration>.NativeClassPtr, "ReadyButtonTranslationKey");
			NativeFieldInfoPtr_UnreadyButtonTranslationKey = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Configuration>.NativeClassPtr, "UnreadyButtonTranslationKey");
			NativeFieldInfoPtr_CancelButtonTranslationKey = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Configuration>.NativeClassPtr, "CancelButtonTranslationKey");
			NativeFieldInfoPtr_CharacterSelectButtonTranslationKey = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Configuration>.NativeClassPtr, "CharacterSelectButtonTranslationKey");
			NativeFieldInfoPtr_PlayersOnlineTranslationKey = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Configuration>.NativeClassPtr, "PlayersOnlineTranslationKey");
			NativeFieldInfoPtr_LinkCopiedPopUpTranslationKey = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Configuration>.NativeClassPtr, "LinkCopiedPopUpTranslationKey");
			NativeFieldInfoPtr_PlayerDisplayIsOnQueue = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Configuration>.NativeClassPtr, "PlayerDisplayIsOnQueue");
			NativeFieldInfoPtr_GameModeTranslationKey = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Configuration>.NativeClassPtr, "GameModeTranslationKey");
			NativeFieldInfoPtr_BapPassNameText = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Configuration>.NativeClassPtr, "BapPassNameText");
			NativeFieldInfoPtr_PastWinnersTranslationKey = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Configuration>.NativeClassPtr, "PastWinnersTranslationKey");
			NativeFieldInfoPtr_LevelTranslationKey = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Configuration>.NativeClassPtr, "LevelTranslationKey");
			NativeFieldInfoPtr_MaxLevelTranslationKey = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Configuration>.NativeClassPtr, "MaxLevelTranslationKey");
			NativeFieldInfoPtr_GameModeEventStartsInStrTranslationKey = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Configuration>.NativeClassPtr, "GameModeEventStartsInStrTranslationKey");
			NativeFieldInfoPtr_GameStartingInTranslationKey = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Configuration>.NativeClassPtr, "GameStartingInTranslationKey");
			NativeFieldInfoPtr_ServersAreDownMessage = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Configuration>.NativeClassPtr, "ServersAreDownMessage");
			NativeFieldInfoPtr_dailyRewardTranslationKey = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Configuration>.NativeClassPtr, "dailyRewardTranslationKey");
			NativeFieldInfoPtr_dailyRewardTooltipDescTranslationKey = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Configuration>.NativeClassPtr, "dailyRewardTooltipDescTranslationKey");
			NativeFieldInfoPtr_dailyRewardCompletedTranslationKey = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Configuration>.NativeClassPtr, "dailyRewardCompletedTranslationKey");
			NativeFieldInfoPtr_dailyRewardRefreshesInTranslationKey = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Configuration>.NativeClassPtr, "dailyRewardRefreshesInTranslationKey");
			NativeFieldInfoPtr_dailyRefreshDateFormatStr = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Configuration>.NativeClassPtr, "dailyRefreshDateFormatStr");
			NativeFieldInfoPtr_goldCurrencyTooltipTitleTranslationKey = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Configuration>.NativeClassPtr, "goldCurrencyTooltipTitleTranslationKey");
			NativeFieldInfoPtr_goldCurrencyTooltipDescTranslationKey = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Configuration>.NativeClassPtr, "goldCurrencyTooltipDescTranslationKey");
			NativeFieldInfoPtr_fractalCurrencyTooltipTitleTranslationKey = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Configuration>.NativeClassPtr, "fractalCurrencyTooltipTitleTranslationKey");
			NativeFieldInfoPtr_fractalCurrencyTooltipDescTranslationKey = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Configuration>.NativeClassPtr, "fractalCurrencyTooltipDescTranslationKey");
			NativeFieldInfoPtr_onlineTranslationKey = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Configuration>.NativeClassPtr, "onlineTranslationKey");
			NativeFieldInfoPtr_offlineTranslationKey = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Configuration>.NativeClassPtr, "offlineTranslationKey");
			NativeFieldInfoPtr_steamOnlineTranslationKey = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Configuration>.NativeClassPtr, "steamOnlineTranslationKey");
			NativeFieldInfoPtr_steamOfflineTranslationKey = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Configuration>.NativeClassPtr, "steamOfflineTranslationKey");
			NativeFieldInfoPtr_inviteLobbyNotifTranslationKey = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Configuration>.NativeClassPtr, "inviteLobbyNotifTranslationKey");
			NativeFieldInfoPtr_sentAGameInviteToTranslationKey = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Configuration>.NativeClassPtr, "sentAGameInviteToTranslationKey");
			NativeFieldInfoPtr_friendInviteSentToTranslationKey = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Configuration>.NativeClassPtr, "friendInviteSentToTranslationKey");
			NativeFieldInfoPtr_friendInviteSentErrorTranslationKey = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Configuration>.NativeClassPtr, "friendInviteSentErrorTranslationKey");
			NativeFieldInfoPtr_friendRequestAcceptedTranslationKey = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Configuration>.NativeClassPtr, "friendRequestAcceptedTranslationKey");
			NativeFieldInfoPtr_usernameIdCopiedTranslationKey = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Configuration>.NativeClassPtr, "usernameIdCopiedTranslationKey");
			NativeFieldInfoPtr_friendJoinLobbyTranslationKey = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Configuration>.NativeClassPtr, "friendJoinLobbyTranslationKey");
			NativeFieldInfoPtr_leaveLobbyTranslationKey = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Configuration>.NativeClassPtr, "leaveLobbyTranslationKey");
			NativeFieldInfoPtr_friendInviteToGameTranslationKey = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Configuration>.NativeClassPtr, "friendInviteToGameTranslationKey");
			NativeFieldInfoPtr_friendMessageFriendTranslationKey = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Configuration>.NativeClassPtr, "friendMessageFriendTranslationKey");
			NativeFieldInfoPtr_friendViewProfileTranslationKey = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Configuration>.NativeClassPtr, "friendViewProfileTranslationKey");
			NativeFieldInfoPtr_friendUnfriendTranslationKey = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Configuration>.NativeClassPtr, "friendUnfriendTranslationKey");
			NativeFieldInfoPtr_areYouSureUnfriendTranslationKey = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Configuration>.NativeClassPtr, "areYouSureUnfriendTranslationKey");
			NativeFieldInfoPtr_sendFriendRequestTranslationKey = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Configuration>.NativeClassPtr, "sendFriendRequestTranslationKey");
			NativeFieldInfoPtr_playerKickTranslationKey = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Configuration>.NativeClassPtr, "playerKickTranslationKey");
			NativeFieldInfoPtr_guestLogInTextTranslationKey = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Configuration>.NativeClassPtr, "guestLogInTextTranslationKey");
			NativeFieldInfoPtr_logInTextTranslationKey = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Configuration>.NativeClassPtr, "logInTextTranslationKey");
			NativeFieldInfoPtr_noFriendsTranslationKey = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Configuration>.NativeClassPtr, "noFriendsTranslationKey");
			NativeFieldInfoPtr_noFriendRequestsTranslationKey = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Configuration>.NativeClassPtr, "noFriendRequestsTranslationKey");
			NativeFieldInfoPtr_addFriendTranslationKey = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Configuration>.NativeClassPtr, "addFriendTranslationKey");
			NativeFieldInfoPtr_closedPartyTranslationKey = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Configuration>.NativeClassPtr, "closedPartyTranslationKey");
			NativeFieldInfoPtr_lobbyCodeHiddenStr = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Configuration>.NativeClassPtr, "lobbyCodeHiddenStr");
			NativeFieldInfoPtr_closeTranslationKey = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Configuration>.NativeClassPtr, "closeTranslationKey");
			NativeFieldInfoPtr_optionJoinLobbyIcon = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Configuration>.NativeClassPtr, "optionJoinLobbyIcon");
			NativeFieldInfoPtr_optionInviteToGameIcon = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Configuration>.NativeClassPtr, "optionInviteToGameIcon");
			NativeFieldInfoPtr_optionMessageFriendIcon = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Configuration>.NativeClassPtr, "optionMessageFriendIcon");
			NativeFieldInfoPtr_optionViewProfileIcon = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Configuration>.NativeClassPtr, "optionViewProfileIcon");
			NativeFieldInfoPtr_optionUnfriendIcon = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Configuration>.NativeClassPtr, "optionUnfriendIcon");
			NativeFieldInfoPtr_optionSendFriendRequestIcon = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Configuration>.NativeClassPtr, "optionSendFriendRequestIcon");
			NativeFieldInfoPtr_optionLeaveLobbyIcon = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Configuration>.NativeClassPtr, "optionLeaveLobbyIcon");
			NativeFieldInfoPtr_optionPlayerKickIcon = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Configuration>.NativeClassPtr, "optionPlayerKickIcon");
			NativeFieldInfoPtr_TabSelectedAlpha = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Configuration>.NativeClassPtr, "TabSelectedAlpha");
			NativeFieldInfoPtr_TabUnselectedAlpha = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Configuration>.NativeClassPtr, "TabUnselectedAlpha");
			NativeFieldInfoPtr_usernameIdDiscriminatorAlphaHex = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Configuration>.NativeClassPtr, "usernameIdDiscriminatorAlphaHex");
			NativeFieldInfoPtr_ReadyColour = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Configuration>.NativeClassPtr, "ReadyColour");
			NativeFieldInfoPtr_NotReadyColour = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Configuration>.NativeClassPtr, "NotReadyColour");
			NativeFieldInfoPtr_InQueueColour = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Configuration>.NativeClassPtr, "InQueueColour");
			NativeFieldInfoPtr_LeaderIconColour = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Configuration>.NativeClassPtr, "LeaderIconColour");
			NativeFieldInfoPtr_PlayersOnlineIconColour = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Configuration>.NativeClassPtr, "PlayersOnlineIconColour");
			NativeFieldInfoPtr_friendOnlineColor = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Configuration>.NativeClassPtr, "friendOnlineColor");
			NativeFieldInfoPtr_friendOfflineColor = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Configuration>.NativeClassPtr, "friendOfflineColor");
			NativeFieldInfoPtr_friendInvitePopUp = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Configuration>.NativeClassPtr, "friendInvitePopUp");
			NativeFieldInfoPtr_playerInQueueDisplayAlpha = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Configuration>.NativeClassPtr, "playerInQueueDisplayAlpha");
			NativeFieldInfoPtr_playButtonCooldownTime = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Configuration>.NativeClassPtr, "playButtonCooldownTime");
			NativeFieldInfoPtr_minLevelForDefaultGmWarmup = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Configuration>.NativeClassPtr, "minLevelForDefaultGmWarmup");
			NativeFieldInfoPtr_GmWarmupId = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Configuration>.NativeClassPtr, "GmWarmupId");
			NativeFieldInfoPtr_lobbyCodeCharLength = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Configuration>.NativeClassPtr, "lobbyCodeCharLength");
			NativeFieldInfoPtr_MatchStartCharacterSelectIconConfiguration = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Configuration>.NativeClassPtr, "MatchStartCharacterSelectIconConfiguration");
			NativeFieldInfoPtr_MatchStartCharacterSelectAnimation = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Configuration>.NativeClassPtr, "MatchStartCharacterSelectAnimation");
			NativeFieldInfoPtr_FriendEntryConfiguration = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Configuration>.NativeClassPtr, "FriendEntryConfiguration");
			NativeFieldInfoPtr_FriendRequestEntryConfiguration = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Configuration>.NativeClassPtr, "FriendRequestEntryConfiguration");
			NativeFieldInfoPtr_NotificationEntryConfiguration = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Configuration>.NativeClassPtr, "NotificationEntryConfiguration");
			NativeFieldInfoPtr_LiveWinnerFeedEntryConfiguration = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Configuration>.NativeClassPtr, "LiveWinnerFeedEntryConfiguration");
			NativeFieldInfoPtr_friendEntryPrefab = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Configuration>.NativeClassPtr, "friendEntryPrefab");
			NativeFieldInfoPtr_friendSeparatorEntryPrefab = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Configuration>.NativeClassPtr, "friendSeparatorEntryPrefab");
			NativeFieldInfoPtr_playerJoinedLobbySfx = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Configuration>.NativeClassPtr, "playerJoinedLobbySfx");
			NativeFieldInfoPtr_playerJoinedLobbySfxVolume = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Configuration>.NativeClassPtr, "playerJoinedLobbySfxVolume");
			NativeFieldInfoPtr_teamJoinedSfx = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Configuration>.NativeClassPtr, "teamJoinedSfx");
			NativeFieldInfoPtr_teamJoinedSfxVolume = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Configuration>.NativeClassPtr, "teamJoinedSfxVolume");
			NativeFieldInfoPtr_matchCountdownTickSfx = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Configuration>.NativeClassPtr, "matchCountdownTickSfx");
			NativeFieldInfoPtr_matchCountdownLastTickSfx = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Configuration>.NativeClassPtr, "matchCountdownLastTickSfx");
			NativeFieldInfoPtr_matchStartCountdownTextColor = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Configuration>.NativeClassPtr, "matchStartCountdownTextColor");
			NativeFieldInfoPtr_matchStartCountdownTextLastTicksColor = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Configuration>.NativeClassPtr, "matchStartCountdownTextLastTicksColor");
			NativeFieldInfoPtr_matchCountdownTickStartSeconds = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Configuration>.NativeClassPtr, "matchCountdownTickStartSeconds");
			NativeFieldInfoPtr_matchCountdownLastTickStartSeconds = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Configuration>.NativeClassPtr, "matchCountdownLastTickStartSeconds");
			NativeFieldInfoPtr_defaultPlayerBannerIds = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Configuration>.NativeClassPtr, "defaultPlayerBannerIds");
			NativeFieldInfoPtr_rewardSequenceTimeBetweenAnim = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Configuration>.NativeClassPtr, "rewardSequenceTimeBetweenAnim");
			NativeFieldInfoPtr_expBarLerpDuration = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Configuration>.NativeClassPtr, "expBarLerpDuration");
			NativeFieldInfoPtr_expBarLerpCurve = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Configuration>.NativeClassPtr, "expBarLerpCurve");
			NativeFieldInfoPtr_expBarLevelUpDuration = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Configuration>.NativeClassPtr, "expBarLevelUpDuration");
			NativeFieldInfoPtr_xpBarLevelUpAlphaCurve = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Configuration>.NativeClassPtr, "xpBarLevelUpAlphaCurve");
			NativeFieldInfoPtr_xpBarLevelUpFillAlphaCurve = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Configuration>.NativeClassPtr, "xpBarLevelUpFillAlphaCurve");
			NativeFieldInfoPtr_battlePassLevelUpSfx = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Configuration>.NativeClassPtr, "battlePassLevelUpSfx");
			NativeFieldInfoPtr_battlePassLevelUpSfxVolume = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Configuration>.NativeClassPtr, "battlePassLevelUpSfxVolume");
			NativeFieldInfoPtr_currencyLerpDuration = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Configuration>.NativeClassPtr, "currencyLerpDuration");
			NativeFieldInfoPtr_softCurrencyLerpCurve = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Configuration>.NativeClassPtr, "softCurrencyLerpCurve");
			NativeFieldInfoPtr_dailyRewardLerpDuration = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Configuration>.NativeClassPtr, "dailyRewardLerpDuration");
			NativeFieldInfoPtr_dailyRewardLerpCurve = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Configuration>.NativeClassPtr, "dailyRewardLerpCurve");
			NativeFieldInfoPtr_newsConfig = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Configuration>.NativeClassPtr, "newsConfig");
			NativeFieldInfoPtr_lobbyStatusConfig = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Configuration>.NativeClassPtr, "lobbyStatusConfig");
			NativeFieldInfoPtr_invitePageConfig = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Configuration>.NativeClassPtr, "invitePageConfig");
			NativeFieldInfoPtr_challengeSeeMoreButtonTranslationKey = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Configuration>.NativeClassPtr, "challengeSeeMoreButtonTranslationKey");
			NativeFieldInfoPtr_challengeSignUpTranslationKey = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Configuration>.NativeClassPtr, "challengeSignUpTranslationKey");
			NativeFieldInfoPtr_challengeXSignUpsOutOfYTranslationKey = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Configuration>.NativeClassPtr, "challengeXSignUpsOutOfYTranslationKey");
			NativeFieldInfoPtr_challengeEventTitleTranslationKey = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Configuration>.NativeClassPtr, "challengeEventTitleTranslationKey");
			NativeFieldInfoPtr_challengeEventLivesTranslationKey = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Configuration>.NativeClassPtr, "challengeEventLivesTranslationKey");
			NativeFieldInfoPtr_challengeDisclaimerHeaderTranslationKey = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Configuration>.NativeClassPtr, "challengeDisclaimerHeaderTranslationKey");
			NativeFieldInfoPtr_challengeDisclaimerTranslationKey = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Configuration>.NativeClassPtr, "challengeDisclaimerTranslationKey");
			NativeFieldInfoPtr_challengeDisclaimerNoRefundsTranslationKey = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Configuration>.NativeClassPtr, "challengeDisclaimerNoRefundsTranslationKey");
			NativeFieldInfoPtr_readyUpTranslationKey = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Configuration>.NativeClassPtr, "readyUpTranslationKey");
			NativeFieldInfoPtr_outOfLivesHeaderTranslationKey = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Configuration>.NativeClassPtr, "outOfLivesHeaderTranslationKey");
			NativeFieldInfoPtr_outOfLivesTranslationKey = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Configuration>.NativeClassPtr, "outOfLivesTranslationKey");
			NativeFieldInfoPtr_outOfLivesObtainMoreTranslationKey = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Configuration>.NativeClassPtr, "outOfLivesObtainMoreTranslationKey");
			NativeFieldInfoPtr_getMoreLivesButtonTranslationKey = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Configuration>.NativeClassPtr, "getMoreLivesButtonTranslationKey");
			NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<Configuration>.NativeClassPtr, 100669695);
		}

		[CallerCount(0)]
		[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 95067, XrefRangeEnd = 95068, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe Configuration()
			: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<Configuration>.NativeClassPtr))
		{
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		public Configuration(System.IntPtr pointer)
			: base(pointer)
		{
		}
	}

	[System.Serializable]
	[ObfuscatedName("BAPBAP.UI.UILobbyPlayTabPage+<>c")]
	public sealed class __c : Il2CppSystem.Object
	{
		private static readonly System.IntPtr NativeFieldInfoPtr___9;

		private static readonly System.IntPtr NativeFieldInfoPtr___9__207_1;

		private static readonly System.IntPtr NativeFieldInfoPtr___9__363_1;

		private static readonly System.IntPtr NativeFieldInfoPtr___9__403_1;

		private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

		private static readonly System.IntPtr NativeMethodInfoPtr__UpdateFriendStatus_b__207_1_Internal_Boolean_UILobbyFriendEntry_0;

		private static readonly System.IntPtr NativeMethodInfoPtr__OpenPlayerOptionDropdown_b__363_1_Internal_Void_0;

		private static readonly System.IntPtr NativeMethodInfoPtr__PopulateSteamFriendsPanel_b__403_1_Internal_Void_RectTransform_0;

		public unsafe static __c __9
		{
			get
			{
				Unsafe.SkipInit(out System.IntPtr intPtr);
				IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr___9, (void*)(&intPtr));
				System.IntPtr intPtr2 = intPtr;
				return (intPtr2 != (System.IntPtr)0) ? Il2CppObjectPool.Get<__c>(intPtr2) : null;
			}
			set
			{
				IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr___9, (void*)IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)_c));
			}
		}

		public unsafe static Il2CppSystem.Func<UILobbyFriendEntry, bool> __9__207_1
		{
			get
			{
				Unsafe.SkipInit(out System.IntPtr intPtr);
				IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr___9__207_1, (void*)(&intPtr));
				System.IntPtr intPtr2 = intPtr;
				return (intPtr2 != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppSystem.Func<UILobbyFriendEntry, bool>>(intPtr2) : null;
			}
			set
			{
				IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr___9__207_1, (void*)IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)func));
			}
		}

		public unsafe static Il2CppSystem.Action __9__363_1
		{
			get
			{
				Unsafe.SkipInit(out System.IntPtr intPtr);
				IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr___9__363_1, (void*)(&intPtr));
				System.IntPtr intPtr2 = intPtr;
				return (intPtr2 != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppSystem.Action>(intPtr2) : null;
			}
			set
			{
				IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr___9__363_1, (void*)IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)action));
			}
		}

		public unsafe static Il2CppSystem.Action<RectTransform> __9__403_1
		{
			get
			{
				Unsafe.SkipInit(out System.IntPtr intPtr);
				IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr___9__403_1, (void*)(&intPtr));
				System.IntPtr intPtr2 = intPtr;
				return (intPtr2 != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppSystem.Action<RectTransform>>(intPtr2) : null;
			}
			set
			{
				IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr___9__403_1, (void*)IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)action));
			}
		}

		static __c()
		{
			Il2CppClassPointerStore<__c>.NativeClassPtr = IL2CPP.GetIl2CppNestedType(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "<>c");
			IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<__c>.NativeClassPtr);
			NativeFieldInfoPtr___9 = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<__c>.NativeClassPtr, "<>9");
			NativeFieldInfoPtr___9__207_1 = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<__c>.NativeClassPtr, "<>9__207_1");
			NativeFieldInfoPtr___9__363_1 = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<__c>.NativeClassPtr, "<>9__363_1");
			NativeFieldInfoPtr___9__403_1 = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<__c>.NativeClassPtr, "<>9__403_1");
			NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<__c>.NativeClassPtr, 100669697);
			NativeMethodInfoPtr__UpdateFriendStatus_b__207_1_Internal_Boolean_UILobbyFriendEntry_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<__c>.NativeClassPtr, 100669698);
			NativeMethodInfoPtr__OpenPlayerOptionDropdown_b__363_1_Internal_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<__c>.NativeClassPtr, 100669699);
			NativeMethodInfoPtr__PopulateSteamFriendsPanel_b__403_1_Internal_Void_RectTransform_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<__c>.NativeClassPtr, 100669700);
		}

		[CallerCount(5410)]
		[CachedScanResults(RefRangeStart = 11, RefRangeEnd = 5421, XrefRangeStart = 11, XrefRangeEnd = 5421, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe __c()
			: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<__c>.NativeClassPtr))
		{
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		[CallerCount(0)]
		[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 95068, XrefRangeEnd = 95071, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe bool _UpdateFriendStatus_b__207_1(UILobbyFriendEntry entry)
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = stackalloc System.IntPtr[1];
			*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)entry);
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__UpdateFriendStatus_b__207_1_Internal_Boolean_UILobbyFriendEntry_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return *(bool*)IL2CPP.il2cpp_object_unbox(intPtr);
		}

		[CallerCount(0)]
		[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 95071, XrefRangeEnd = 95074, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe void _OpenPlayerOptionDropdown_b__363_1()
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__OpenPlayerOptionDropdown_b__363_1_Internal_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		[CallerCount(17738)]
		[CachedScanResults(RefRangeStart = 5595, RefRangeEnd = 23333, XrefRangeStart = 5595, XrefRangeEnd = 23333, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe void _PopulateSteamFriendsPanel_b__403_1(RectTransform rt)
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = stackalloc System.IntPtr[1];
			*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)rt);
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__PopulateSteamFriendsPanel_b__403_1_Internal_Void_RectTransform_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		public __c(System.IntPtr pointer)
			: base(pointer)
		{
		}
	}

	[ObfuscatedName("BAPBAP.UI.UILobbyPlayTabPage+<>c__DisplayClass192_0")]
	public sealed class __c__DisplayClass192_0 : Il2CppSystem.Object
	{
		private static readonly System.IntPtr NativeFieldInfoPtr___4__this;

		private static readonly System.IntPtr NativeFieldInfoPtr_joinLobbyPopup;

		private static readonly System.IntPtr NativeFieldInfoPtr_addFriendPanel;

		private static readonly System.IntPtr NativeFieldInfoPtr_uiLobby;

		private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

		private static readonly System.IntPtr NativeMethodInfoPtr__Build_b__0_Internal_Void_0;

		private static readonly System.IntPtr NativeMethodInfoPtr__Build_b__1_Internal_Void_BaseEventData_0;

		private static readonly System.IntPtr NativeMethodInfoPtr__Build_b__2_Internal_Void_0;

		private static readonly System.IntPtr NativeMethodInfoPtr__Build_b__3_Internal_Void_0;

		private static readonly System.IntPtr NativeMethodInfoPtr__Build_b__4_Internal_Void_String_0;

		private static readonly System.IntPtr NativeMethodInfoPtr__Build_b__5_Internal_Void_0;

		private static readonly System.IntPtr NativeMethodInfoPtr__Build_b__6_Internal_Void_String_0;

		private static readonly System.IntPtr NativeMethodInfoPtr__Build_b__7_Internal_Void_0;

		private static readonly System.IntPtr NativeMethodInfoPtr__Build_b__8_Internal_Void_String_0;

		private static readonly System.IntPtr NativeMethodInfoPtr__Build_b__9_Internal_Void_String_0;

		private static readonly System.IntPtr NativeMethodInfoPtr__Build_b__10_Internal_Void_0;

		private static readonly System.IntPtr NativeMethodInfoPtr__Build_b__11_Internal_Void_0;

		private static readonly System.IntPtr NativeMethodInfoPtr__Build_b__12_Internal_Void_0;

		private static readonly System.IntPtr NativeMethodInfoPtr__Build_b__13_Internal_Void_0;

		private static readonly System.IntPtr NativeMethodInfoPtr__Build_b__14_Internal_Void_0;

		private static readonly System.IntPtr NativeMethodInfoPtr__Build_b__15_Internal_Void_0;

		private static readonly System.IntPtr NativeMethodInfoPtr__Build_b__16_Internal_Void_0;

		private static readonly System.IntPtr NativeMethodInfoPtr__Build_b__17_Internal_Void_0;

		private static readonly System.IntPtr NativeMethodInfoPtr__Build_b__18_Internal_Void_0;

		private static readonly System.IntPtr NativeMethodInfoPtr__Build_b__19_Internal_Void_0;

		private static readonly System.IntPtr NativeMethodInfoPtr__Build_b__20_Internal_Void_0;

		private static readonly System.IntPtr NativeMethodInfoPtr__Build_b__21_Internal_Void_0;

		private static readonly System.IntPtr NativeMethodInfoPtr__Build_b__22_Internal_Void_0;

		private static readonly System.IntPtr NativeMethodInfoPtr__Build_b__23_Internal_Void_0;

		private static readonly System.IntPtr NativeMethodInfoPtr__Build_b__24_Internal_Void_0;

		public unsafe UILobbyPlayTabPage __4__this
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr___4__this);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<UILobbyPlayTabPage>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr___4__this)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)uILobbyPlayTabPage));
			}
		}

		public unsafe FriendsPanel.JoinLobbyPanel joinLobbyPopup
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_joinLobbyPopup);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<FriendsPanel.JoinLobbyPanel>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_joinLobbyPopup)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)joinLobbyPanel));
			}
		}

		public unsafe FriendsPanel.AddFriendPanel addFriendPanel
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_addFriendPanel);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<FriendsPanel.AddFriendPanel>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_addFriendPanel)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)addFriendPanel));
			}
		}

		public unsafe UILobby uiLobby
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_uiLobby);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<UILobby>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_uiLobby)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)uILobby));
			}
		}

		static __c__DisplayClass192_0()
		{
			Il2CppClassPointerStore<__c__DisplayClass192_0>.NativeClassPtr = IL2CPP.GetIl2CppNestedType(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "<>c__DisplayClass192_0");
			IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<__c__DisplayClass192_0>.NativeClassPtr);
			NativeFieldInfoPtr___4__this = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<__c__DisplayClass192_0>.NativeClassPtr, "<>4__this");
			NativeFieldInfoPtr_joinLobbyPopup = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<__c__DisplayClass192_0>.NativeClassPtr, "joinLobbyPopup");
			NativeFieldInfoPtr_addFriendPanel = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<__c__DisplayClass192_0>.NativeClassPtr, "addFriendPanel");
			NativeFieldInfoPtr_uiLobby = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<__c__DisplayClass192_0>.NativeClassPtr, "uiLobby");
			NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<__c__DisplayClass192_0>.NativeClassPtr, 100669701);
			NativeMethodInfoPtr__Build_b__0_Internal_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<__c__DisplayClass192_0>.NativeClassPtr, 100669702);
			NativeMethodInfoPtr__Build_b__1_Internal_Void_BaseEventData_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<__c__DisplayClass192_0>.NativeClassPtr, 100669703);
			NativeMethodInfoPtr__Build_b__2_Internal_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<__c__DisplayClass192_0>.NativeClassPtr, 100669704);
			NativeMethodInfoPtr__Build_b__3_Internal_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<__c__DisplayClass192_0>.NativeClassPtr, 100669705);
			NativeMethodInfoPtr__Build_b__4_Internal_Void_String_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<__c__DisplayClass192_0>.NativeClassPtr, 100669706);
			NativeMethodInfoPtr__Build_b__5_Internal_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<__c__DisplayClass192_0>.NativeClassPtr, 100669707);
			NativeMethodInfoPtr__Build_b__6_Internal_Void_String_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<__c__DisplayClass192_0>.NativeClassPtr, 100669708);
			NativeMethodInfoPtr__Build_b__7_Internal_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<__c__DisplayClass192_0>.NativeClassPtr, 100669709);
			NativeMethodInfoPtr__Build_b__8_Internal_Void_String_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<__c__DisplayClass192_0>.NativeClassPtr, 100669710);
			NativeMethodInfoPtr__Build_b__9_Internal_Void_String_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<__c__DisplayClass192_0>.NativeClassPtr, 100669711);
			NativeMethodInfoPtr__Build_b__10_Internal_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<__c__DisplayClass192_0>.NativeClassPtr, 100669712);
			NativeMethodInfoPtr__Build_b__11_Internal_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<__c__DisplayClass192_0>.NativeClassPtr, 100669713);
			NativeMethodInfoPtr__Build_b__12_Internal_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<__c__DisplayClass192_0>.NativeClassPtr, 100669714);
			NativeMethodInfoPtr__Build_b__13_Internal_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<__c__DisplayClass192_0>.NativeClassPtr, 100669715);
			NativeMethodInfoPtr__Build_b__14_Internal_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<__c__DisplayClass192_0>.NativeClassPtr, 100669716);
			NativeMethodInfoPtr__Build_b__15_Internal_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<__c__DisplayClass192_0>.NativeClassPtr, 100669717);
			NativeMethodInfoPtr__Build_b__16_Internal_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<__c__DisplayClass192_0>.NativeClassPtr, 100669718);
			NativeMethodInfoPtr__Build_b__17_Internal_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<__c__DisplayClass192_0>.NativeClassPtr, 100669719);
			NativeMethodInfoPtr__Build_b__18_Internal_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<__c__DisplayClass192_0>.NativeClassPtr, 100669720);
			NativeMethodInfoPtr__Build_b__19_Internal_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<__c__DisplayClass192_0>.NativeClassPtr, 100669721);
			NativeMethodInfoPtr__Build_b__20_Internal_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<__c__DisplayClass192_0>.NativeClassPtr, 100669722);
			NativeMethodInfoPtr__Build_b__21_Internal_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<__c__DisplayClass192_0>.NativeClassPtr, 100669723);
			NativeMethodInfoPtr__Build_b__22_Internal_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<__c__DisplayClass192_0>.NativeClassPtr, 100669724);
			NativeMethodInfoPtr__Build_b__23_Internal_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<__c__DisplayClass192_0>.NativeClassPtr, 100669725);
			NativeMethodInfoPtr__Build_b__24_Internal_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<__c__DisplayClass192_0>.NativeClassPtr, 100669726);
		}

		[CallerCount(5410)]
		[CachedScanResults(RefRangeStart = 11, RefRangeEnd = 5421, XrefRangeStart = 11, XrefRangeEnd = 5421, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe __c__DisplayClass192_0()
			: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<__c__DisplayClass192_0>.NativeClassPtr))
		{
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		[CallerCount(0)]
		[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 95074, XrefRangeEnd = 95077, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe void _Build_b__0()
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__Build_b__0_Internal_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		[CallerCount(0)]
		[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 95077, XrefRangeEnd = 95078, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe void _Build_b__1(BaseEventData _)
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = stackalloc System.IntPtr[1];
			*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)_);
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__Build_b__1_Internal_Void_BaseEventData_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		[CallerCount(0)]
		[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 95078, XrefRangeEnd = 95082, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe void _Build_b__2()
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__Build_b__2_Internal_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		[CallerCount(0)]
		[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 95082, XrefRangeEnd = 95086, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe void _Build_b__3()
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__Build_b__3_Internal_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		[CallerCount(0)]
		[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 95086, XrefRangeEnd = 95087, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe void _Build_b__4(string lobbyCode)
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = stackalloc System.IntPtr[1];
			*ptr = IL2CPP.ManagedStringToIl2Cpp(lobbyCode);
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__Build_b__4_Internal_Void_String_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		[CallerCount(0)]
		[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 95087, XrefRangeEnd = 95090, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe void _Build_b__5()
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__Build_b__5_Internal_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		[CallerCount(0)]
		[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 95090, XrefRangeEnd = 95091, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe void _Build_b__6(string _)
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = stackalloc System.IntPtr[1];
			*ptr = IL2CPP.ManagedStringToIl2Cpp(_);
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__Build_b__6_Internal_Void_String_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		[CallerCount(0)]
		[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 95091, XrefRangeEnd = 95096, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe void _Build_b__7()
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__Build_b__7_Internal_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		[CallerCount(0)]
		[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 95096, XrefRangeEnd = 95099, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe void _Build_b__8(string usernameId)
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = stackalloc System.IntPtr[1];
			*ptr = IL2CPP.ManagedStringToIl2Cpp(usernameId);
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__Build_b__8_Internal_Void_String_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		[CallerCount(0)]
		[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 95099, XrefRangeEnd = 95100, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe void _Build_b__9(string v)
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = stackalloc System.IntPtr[1];
			*ptr = IL2CPP.ManagedStringToIl2Cpp(v);
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__Build_b__9_Internal_Void_String_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		[CallerCount(0)]
		[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 95100, XrefRangeEnd = 95103, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe void _Build_b__10()
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__Build_b__10_Internal_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		[CallerCount(0)]
		[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 95103, XrefRangeEnd = 95104, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe void _Build_b__11()
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__Build_b__11_Internal_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		[CallerCount(0)]
		[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 95104, XrefRangeEnd = 95108, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe void _Build_b__12()
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__Build_b__12_Internal_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		[CallerCount(0)]
		[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 95108, XrefRangeEnd = 95112, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe void _Build_b__13()
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__Build_b__13_Internal_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		[CallerCount(0)]
		[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 95112, XrefRangeEnd = 95120, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe void _Build_b__14()
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__Build_b__14_Internal_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		[CallerCount(0)]
		[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 95120, XrefRangeEnd = 95124, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe void _Build_b__15()
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__Build_b__15_Internal_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		[CallerCount(0)]
		[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 95124, XrefRangeEnd = 95128, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe void _Build_b__16()
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__Build_b__16_Internal_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		[CallerCount(0)]
		[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 95128, XrefRangeEnd = 95129, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe void _Build_b__17()
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__Build_b__17_Internal_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		[CallerCount(0)]
		[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 95129, XrefRangeEnd = 95130, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe void _Build_b__18()
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__Build_b__18_Internal_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		[CallerCount(0)]
		[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 95130, XrefRangeEnd = 95131, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe void _Build_b__19()
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__Build_b__19_Internal_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		[CallerCount(0)]
		[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 95131, XrefRangeEnd = 95132, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe void _Build_b__20()
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__Build_b__20_Internal_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		[CallerCount(0)]
		[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 95132, XrefRangeEnd = 95133, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe void _Build_b__21()
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__Build_b__21_Internal_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		[CallerCount(0)]
		[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 95133, XrefRangeEnd = 95134, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe void _Build_b__22()
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__Build_b__22_Internal_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		[CallerCount(0)]
		[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 95134, XrefRangeEnd = 95138, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe void _Build_b__23()
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__Build_b__23_Internal_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		[CallerCount(0)]
		[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 95138, XrefRangeEnd = 95142, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe void _Build_b__24()
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__Build_b__24_Internal_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		public __c__DisplayClass192_0(System.IntPtr pointer)
			: base(pointer)
		{
		}
	}

	[ObfuscatedName("BAPBAP.UI.UILobbyPlayTabPage+<>c__DisplayClass192_1")]
	public sealed class __c__DisplayClass192_1 : Il2CppSystem.Object
	{
		private static readonly System.IntPtr NativeFieldInfoPtr_t;

		private static readonly System.IntPtr NativeFieldInfoPtr_field_Public___c__DisplayClass192_0_0;

		private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

		private static readonly System.IntPtr NativeMethodInfoPtr__Build_b__25_Internal_Void_0;

		private static readonly System.IntPtr NativeMethodInfoPtr__Build_b__26_Internal_Void_0;

		private static readonly System.IntPtr NativeMethodInfoPtr__Build_b__27_Internal_Void_BaseEventData_0;

		public unsafe TeammateDisplay t
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_t);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<TeammateDisplay>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_t)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)teammateDisplay));
			}
		}

		public unsafe __c__DisplayClass192_0 field_Public___c__DisplayClass192_0_0
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_field_Public___c__DisplayClass192_0_0);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<__c__DisplayClass192_0>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_field_Public___c__DisplayClass192_0_0)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)_c__DisplayClass192_));
			}
		}

		static __c__DisplayClass192_1()
		{
			Il2CppClassPointerStore<__c__DisplayClass192_1>.NativeClassPtr = IL2CPP.GetIl2CppNestedType(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "<>c__DisplayClass192_1");
			IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<__c__DisplayClass192_1>.NativeClassPtr);
			NativeFieldInfoPtr_t = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<__c__DisplayClass192_1>.NativeClassPtr, "t");
			NativeFieldInfoPtr_field_Public___c__DisplayClass192_0_0 = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<__c__DisplayClass192_1>.NativeClassPtr, "CS$<>8__locals1");
			NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<__c__DisplayClass192_1>.NativeClassPtr, 100669727);
			NativeMethodInfoPtr__Build_b__25_Internal_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<__c__DisplayClass192_1>.NativeClassPtr, 100669728);
			NativeMethodInfoPtr__Build_b__26_Internal_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<__c__DisplayClass192_1>.NativeClassPtr, 100669729);
			NativeMethodInfoPtr__Build_b__27_Internal_Void_BaseEventData_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<__c__DisplayClass192_1>.NativeClassPtr, 100669730);
		}

		[CallerCount(5410)]
		[CachedScanResults(RefRangeStart = 11, RefRangeEnd = 5421, XrefRangeStart = 11, XrefRangeEnd = 5421, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe __c__DisplayClass192_1()
			: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<__c__DisplayClass192_1>.NativeClassPtr))
		{
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		[CallerCount(0)]
		[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 95142, XrefRangeEnd = 95146, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe void _Build_b__25()
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__Build_b__25_Internal_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		[CallerCount(0)]
		[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 95146, XrefRangeEnd = 95149, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe void _Build_b__26()
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__Build_b__26_Internal_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		[CallerCount(0)]
		[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 95149, XrefRangeEnd = 95150, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe void _Build_b__27(BaseEventData _)
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = stackalloc System.IntPtr[1];
			*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)_);
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__Build_b__27_Internal_Void_BaseEventData_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		public __c__DisplayClass192_1(System.IntPtr pointer)
			: base(pointer)
		{
		}
	}

	[ObfuscatedName("BAPBAP.UI.UILobbyPlayTabPage+<>c__DisplayClass201_0")]
	public sealed class __c__DisplayClass201_0 : Il2CppSystem.Object
	{
		private static readonly System.IntPtr NativeFieldInfoPtr_friend;

		private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

		private static readonly System.IntPtr NativeMethodInfoPtr__UpdateFriendData_b__0_Internal_Boolean_UILobbyFriendEntry_0;

		public unsafe LobbyDataModel.Friend friend
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_friend);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<LobbyDataModel.Friend>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_friend)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)friend));
			}
		}

		static __c__DisplayClass201_0()
		{
			Il2CppClassPointerStore<__c__DisplayClass201_0>.NativeClassPtr = IL2CPP.GetIl2CppNestedType(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "<>c__DisplayClass201_0");
			IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<__c__DisplayClass201_0>.NativeClassPtr);
			NativeFieldInfoPtr_friend = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<__c__DisplayClass201_0>.NativeClassPtr, "friend");
			NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<__c__DisplayClass201_0>.NativeClassPtr, 100669731);
			NativeMethodInfoPtr__UpdateFriendData_b__0_Internal_Boolean_UILobbyFriendEntry_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<__c__DisplayClass201_0>.NativeClassPtr, 100669732);
		}

		[CallerCount(5410)]
		[CachedScanResults(RefRangeStart = 11, RefRangeEnd = 5421, XrefRangeStart = 11, XrefRangeEnd = 5421, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe __c__DisplayClass201_0()
			: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<__c__DisplayClass201_0>.NativeClassPtr))
		{
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		[CallerCount(0)]
		[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 95150, XrefRangeEnd = 95151, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe bool _UpdateFriendData_b__0(UILobbyFriendEntry entry)
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = stackalloc System.IntPtr[1];
			*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)entry);
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__UpdateFriendData_b__0_Internal_Boolean_UILobbyFriendEntry_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return *(bool*)IL2CPP.il2cpp_object_unbox(intPtr);
		}

		public __c__DisplayClass201_0(System.IntPtr pointer)
			: base(pointer)
		{
		}
	}

	[ObfuscatedName("BAPBAP.UI.UILobbyPlayTabPage+<>c__DisplayClass202_0")]
	public sealed class __c__DisplayClass202_0 : Il2CppSystem.Object
	{
		private static readonly System.IntPtr NativeFieldInfoPtr___4__this;

		private static readonly System.IntPtr NativeFieldInfoPtr_friend;

		private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

		private static readonly System.IntPtr NativeMethodInfoPtr__AddNewFriendEntry_b__0_Internal_Void_RectTransform_0;

		public unsafe UILobbyPlayTabPage __4__this
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr___4__this);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<UILobbyPlayTabPage>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr___4__this)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)uILobbyPlayTabPage));
			}
		}

		public unsafe LobbyDataModel.Friend friend
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_friend);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<LobbyDataModel.Friend>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_friend)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)friend));
			}
		}

		static __c__DisplayClass202_0()
		{
			Il2CppClassPointerStore<__c__DisplayClass202_0>.NativeClassPtr = IL2CPP.GetIl2CppNestedType(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "<>c__DisplayClass202_0");
			IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<__c__DisplayClass202_0>.NativeClassPtr);
			NativeFieldInfoPtr___4__this = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<__c__DisplayClass202_0>.NativeClassPtr, "<>4__this");
			NativeFieldInfoPtr_friend = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<__c__DisplayClass202_0>.NativeClassPtr, "friend");
			NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<__c__DisplayClass202_0>.NativeClassPtr, 100669733);
			NativeMethodInfoPtr__AddNewFriendEntry_b__0_Internal_Void_RectTransform_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<__c__DisplayClass202_0>.NativeClassPtr, 100669734);
		}

		[CallerCount(5410)]
		[CachedScanResults(RefRangeStart = 11, RefRangeEnd = 5421, XrefRangeStart = 11, XrefRangeEnd = 5421, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe __c__DisplayClass202_0()
			: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<__c__DisplayClass202_0>.NativeClassPtr))
		{
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		[CallerCount(0)]
		[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 95151, XrefRangeEnd = 95158, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe void _AddNewFriendEntry_b__0(RectTransform rt)
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = stackalloc System.IntPtr[1];
			*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)rt);
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__AddNewFriendEntry_b__0_Internal_Void_RectTransform_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		public __c__DisplayClass202_0(System.IntPtr pointer)
			: base(pointer)
		{
		}
	}

	[ObfuscatedName("BAPBAP.UI.UILobbyPlayTabPage+<>c__DisplayClass206_0")]
	public sealed class __c__DisplayClass206_0 : Il2CppSystem.Object
	{
		private static readonly System.IntPtr NativeFieldInfoPtr_senderAccountId;

		private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

		private static readonly System.IntPtr NativeMethodInfoPtr__UpdateInviteLobbyNotification_b__0_Internal_Boolean_Friend_0;

		public unsafe string senderAccountId
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_senderAccountId);
				return IL2CPP.Il2CppStringToManaged(*(System.IntPtr*)num);
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_senderAccountId)), IL2CPP.ManagedStringToIl2Cpp(text));
			}
		}

		static __c__DisplayClass206_0()
		{
			Il2CppClassPointerStore<__c__DisplayClass206_0>.NativeClassPtr = IL2CPP.GetIl2CppNestedType(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "<>c__DisplayClass206_0");
			IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<__c__DisplayClass206_0>.NativeClassPtr);
			NativeFieldInfoPtr_senderAccountId = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<__c__DisplayClass206_0>.NativeClassPtr, "senderAccountId");
			NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<__c__DisplayClass206_0>.NativeClassPtr, 100669735);
			NativeMethodInfoPtr__UpdateInviteLobbyNotification_b__0_Internal_Boolean_Friend_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<__c__DisplayClass206_0>.NativeClassPtr, 100669736);
		}

		[CallerCount(5410)]
		[CachedScanResults(RefRangeStart = 11, RefRangeEnd = 5421, XrefRangeStart = 11, XrefRangeEnd = 5421, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe __c__DisplayClass206_0()
			: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<__c__DisplayClass206_0>.NativeClassPtr))
		{
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		[CallerCount(0)]
		[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 95158, XrefRangeEnd = 95159, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe bool _UpdateInviteLobbyNotification_b__0(LobbyDataModel.Friend f)
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = stackalloc System.IntPtr[1];
			*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)f);
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__UpdateInviteLobbyNotification_b__0_Internal_Boolean_Friend_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return *(bool*)IL2CPP.il2cpp_object_unbox(intPtr);
		}

		public __c__DisplayClass206_0(System.IntPtr pointer)
			: base(pointer)
		{
		}
	}

	[ObfuscatedName("BAPBAP.UI.UILobbyPlayTabPage+<>c__DisplayClass207_0")]
	public sealed class __c__DisplayClass207_0 : Il2CppSystem.Object
	{
		private static readonly System.IntPtr NativeFieldInfoPtr_accountId;

		private static readonly System.IntPtr NativeFieldInfoPtr___9__2;

		private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

		private static readonly System.IntPtr NativeMethodInfoPtr__UpdateFriendStatus_b__0_Internal_Boolean_Friend_0;

		private static readonly System.IntPtr NativeMethodInfoPtr__UpdateFriendStatus_b__2_Internal_Boolean_UILobbyFriendEntry_0;

		public unsafe string accountId
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_accountId);
				return IL2CPP.Il2CppStringToManaged(*(System.IntPtr*)num);
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_accountId)), IL2CPP.ManagedStringToIl2Cpp(text));
			}
		}

		public unsafe Il2CppSystem.Func<UILobbyFriendEntry, bool> __9__2
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr___9__2);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppSystem.Func<UILobbyFriendEntry, bool>>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr___9__2)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)func));
			}
		}

		static __c__DisplayClass207_0()
		{
			Il2CppClassPointerStore<__c__DisplayClass207_0>.NativeClassPtr = IL2CPP.GetIl2CppNestedType(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "<>c__DisplayClass207_0");
			IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<__c__DisplayClass207_0>.NativeClassPtr);
			NativeFieldInfoPtr_accountId = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<__c__DisplayClass207_0>.NativeClassPtr, "accountId");
			NativeFieldInfoPtr___9__2 = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<__c__DisplayClass207_0>.NativeClassPtr, "<>9__2");
			NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<__c__DisplayClass207_0>.NativeClassPtr, 100669737);
			NativeMethodInfoPtr__UpdateFriendStatus_b__0_Internal_Boolean_Friend_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<__c__DisplayClass207_0>.NativeClassPtr, 100669738);
			NativeMethodInfoPtr__UpdateFriendStatus_b__2_Internal_Boolean_UILobbyFriendEntry_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<__c__DisplayClass207_0>.NativeClassPtr, 100669739);
		}

		[CallerCount(5410)]
		[CachedScanResults(RefRangeStart = 11, RefRangeEnd = 5421, XrefRangeStart = 11, XrefRangeEnd = 5421, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe __c__DisplayClass207_0()
			: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<__c__DisplayClass207_0>.NativeClassPtr))
		{
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		[CallerCount(0)]
		[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 0, XrefRangeEnd = 0, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe bool _UpdateFriendStatus_b__0(LobbyDataModel.Friend f)
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = stackalloc System.IntPtr[1];
			*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)f);
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__UpdateFriendStatus_b__0_Internal_Boolean_Friend_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return *(bool*)IL2CPP.il2cpp_object_unbox(intPtr);
		}

		[CallerCount(0)]
		[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 95159, XrefRangeEnd = 95160, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe bool _UpdateFriendStatus_b__2(UILobbyFriendEntry entry)
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = stackalloc System.IntPtr[1];
			*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)entry);
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__UpdateFriendStatus_b__2_Internal_Boolean_UILobbyFriendEntry_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return *(bool*)IL2CPP.il2cpp_object_unbox(intPtr);
		}

		public __c__DisplayClass207_0(System.IntPtr pointer)
			: base(pointer)
		{
		}
	}

	[ObfuscatedName("BAPBAP.UI.UILobbyPlayTabPage+<>c__DisplayClass208_0")]
	public sealed class __c__DisplayClass208_0 : Il2CppSystem.Object
	{
		private static readonly System.IntPtr NativeFieldInfoPtr_accountId;

		private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

		private static readonly System.IntPtr NativeMethodInfoPtr__UpdateFriendAvatarId_b__0_Internal_Boolean_Friend_0;

		public unsafe string accountId
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_accountId);
				return IL2CPP.Il2CppStringToManaged(*(System.IntPtr*)num);
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_accountId)), IL2CPP.ManagedStringToIl2Cpp(text));
			}
		}

		static __c__DisplayClass208_0()
		{
			Il2CppClassPointerStore<__c__DisplayClass208_0>.NativeClassPtr = IL2CPP.GetIl2CppNestedType(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "<>c__DisplayClass208_0");
			IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<__c__DisplayClass208_0>.NativeClassPtr);
			NativeFieldInfoPtr_accountId = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<__c__DisplayClass208_0>.NativeClassPtr, "accountId");
			NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<__c__DisplayClass208_0>.NativeClassPtr, 100669740);
			NativeMethodInfoPtr__UpdateFriendAvatarId_b__0_Internal_Boolean_Friend_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<__c__DisplayClass208_0>.NativeClassPtr, 100669741);
		}

		[CallerCount(5410)]
		[CachedScanResults(RefRangeStart = 11, RefRangeEnd = 5421, XrefRangeStart = 11, XrefRangeEnd = 5421, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe __c__DisplayClass208_0()
			: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<__c__DisplayClass208_0>.NativeClassPtr))
		{
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		[CallerCount(0)]
		[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 0, XrefRangeEnd = 0, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe bool _UpdateFriendAvatarId_b__0(LobbyDataModel.Friend f)
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = stackalloc System.IntPtr[1];
			*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)f);
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__UpdateFriendAvatarId_b__0_Internal_Boolean_Friend_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return *(bool*)IL2CPP.il2cpp_object_unbox(intPtr);
		}

		public __c__DisplayClass208_0(System.IntPtr pointer)
			: base(pointer)
		{
		}
	}

	[ObfuscatedName("BAPBAP.UI.UILobbyPlayTabPage+<>c__DisplayClass209_0")]
	public sealed class __c__DisplayClass209_0 : Il2CppSystem.Object
	{
		private static readonly System.IntPtr NativeFieldInfoPtr_accountId;

		private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

		private static readonly System.IntPtr NativeMethodInfoPtr__UpdateFriendLobbyOpen_b__0_Internal_Boolean_Friend_0;

		public unsafe string accountId
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_accountId);
				return IL2CPP.Il2CppStringToManaged(*(System.IntPtr*)num);
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_accountId)), IL2CPP.ManagedStringToIl2Cpp(text));
			}
		}

		static __c__DisplayClass209_0()
		{
			Il2CppClassPointerStore<__c__DisplayClass209_0>.NativeClassPtr = IL2CPP.GetIl2CppNestedType(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "<>c__DisplayClass209_0");
			IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<__c__DisplayClass209_0>.NativeClassPtr);
			NativeFieldInfoPtr_accountId = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<__c__DisplayClass209_0>.NativeClassPtr, "accountId");
			NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<__c__DisplayClass209_0>.NativeClassPtr, 100669742);
			NativeMethodInfoPtr__UpdateFriendLobbyOpen_b__0_Internal_Boolean_Friend_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<__c__DisplayClass209_0>.NativeClassPtr, 100669743);
		}

		[CallerCount(5410)]
		[CachedScanResults(RefRangeStart = 11, RefRangeEnd = 5421, XrefRangeStart = 11, XrefRangeEnd = 5421, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe __c__DisplayClass209_0()
			: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<__c__DisplayClass209_0>.NativeClassPtr))
		{
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		[CallerCount(0)]
		[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 0, XrefRangeEnd = 0, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe bool _UpdateFriendLobbyOpen_b__0(LobbyDataModel.Friend f)
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = stackalloc System.IntPtr[1];
			*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)f);
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__UpdateFriendLobbyOpen_b__0_Internal_Boolean_Friend_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return *(bool*)IL2CPP.il2cpp_object_unbox(intPtr);
		}

		public __c__DisplayClass209_0(System.IntPtr pointer)
			: base(pointer)
		{
		}
	}

	[ObfuscatedName("BAPBAP.UI.UILobbyPlayTabPage+<>c__DisplayClass228_0")]
	public sealed class __c__DisplayClass228_0 : Il2CppSystem.Object
	{
		private static readonly System.IntPtr NativeFieldInfoPtr_gmConfigs;

		private static readonly System.IntPtr NativeFieldInfoPtr_warmupGmId;

		private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

		private static readonly System.IntPtr NativeMethodInfoPtr__UpdateGameModes_b__1_Internal_Boolean_GameModeModel_0;

		public unsafe Il2CppReferenceArray<GameModesConfiguration.GameModeConfiguration> gmConfigs
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_gmConfigs);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppReferenceArray<GameModesConfiguration.GameModeConfiguration>>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_gmConfigs)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)val));
			}
		}

		public unsafe int warmupGmId
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_warmupGmId);
				return *(int*)num;
			}
			set
			{
				*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_warmupGmId)) = num;
			}
		}

		static __c__DisplayClass228_0()
		{
			Il2CppClassPointerStore<__c__DisplayClass228_0>.NativeClassPtr = IL2CPP.GetIl2CppNestedType(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "<>c__DisplayClass228_0");
			IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<__c__DisplayClass228_0>.NativeClassPtr);
			NativeFieldInfoPtr_gmConfigs = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<__c__DisplayClass228_0>.NativeClassPtr, "gmConfigs");
			NativeFieldInfoPtr_warmupGmId = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<__c__DisplayClass228_0>.NativeClassPtr, "warmupGmId");
			NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<__c__DisplayClass228_0>.NativeClassPtr, 100669744);
			NativeMethodInfoPtr__UpdateGameModes_b__1_Internal_Boolean_GameModeModel_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<__c__DisplayClass228_0>.NativeClassPtr, 100669745);
		}

		[CallerCount(5410)]
		[CachedScanResults(RefRangeStart = 11, RefRangeEnd = 5421, XrefRangeStart = 11, XrefRangeEnd = 5421, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe __c__DisplayClass228_0()
			: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<__c__DisplayClass228_0>.NativeClassPtr))
		{
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		[CallerCount(0)]
		[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 95160, XrefRangeEnd = 95169, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe bool _UpdateGameModes_b__1(GameModeModel gameModeModel)
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = stackalloc System.IntPtr[1];
			*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)gameModeModel);
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__UpdateGameModes_b__1_Internal_Boolean_GameModeModel_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return *(bool*)IL2CPP.il2cpp_object_unbox(intPtr);
		}

		public __c__DisplayClass228_0(System.IntPtr pointer)
			: base(pointer)
		{
		}
	}

	[ObfuscatedName("BAPBAP.UI.UILobbyPlayTabPage+<>c__DisplayClass228_1")]
	public sealed class __c__DisplayClass228_1 : Il2CppSystem.Object
	{
		private static readonly System.IntPtr NativeFieldInfoPtr_gmModel;

		private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

		private static readonly System.IntPtr NativeMethodInfoPtr__UpdateGameModes_b__0_Internal_Boolean_GameModeConfiguration_0;

		public unsafe GameModeModel gmModel
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_gmModel);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<GameModeModel>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_gmModel)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)gameModeModel));
			}
		}

		static __c__DisplayClass228_1()
		{
			Il2CppClassPointerStore<__c__DisplayClass228_1>.NativeClassPtr = IL2CPP.GetIl2CppNestedType(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "<>c__DisplayClass228_1");
			IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<__c__DisplayClass228_1>.NativeClassPtr);
			NativeFieldInfoPtr_gmModel = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<__c__DisplayClass228_1>.NativeClassPtr, "gmModel");
			NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<__c__DisplayClass228_1>.NativeClassPtr, 100669746);
			NativeMethodInfoPtr__UpdateGameModes_b__0_Internal_Boolean_GameModeConfiguration_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<__c__DisplayClass228_1>.NativeClassPtr, 100669747);
		}

		[CallerCount(5410)]
		[CachedScanResults(RefRangeStart = 11, RefRangeEnd = 5421, XrefRangeStart = 11, XrefRangeEnd = 5421, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe __c__DisplayClass228_1()
			: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<__c__DisplayClass228_1>.NativeClassPtr))
		{
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		[CallerCount(0)]
		public unsafe bool _UpdateGameModes_b__0(GameModesConfiguration.GameModeConfiguration x)
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = stackalloc System.IntPtr[1];
			*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)x);
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__UpdateGameModes_b__0_Internal_Boolean_GameModeConfiguration_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return *(bool*)IL2CPP.il2cpp_object_unbox(intPtr);
		}

		public __c__DisplayClass228_1(System.IntPtr pointer)
			: base(pointer)
		{
		}
	}

	[ObfuscatedName("BAPBAP.UI.UILobbyPlayTabPage+<>c__DisplayClass228_2")]
	public sealed class __c__DisplayClass228_2 : Il2CppSystem.Object
	{
		private static readonly System.IntPtr NativeFieldInfoPtr_gameModeModel;

		private static readonly System.IntPtr NativeFieldInfoPtr_field_Public___c__DisplayClass228_0_0;

		private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

		private static readonly System.IntPtr NativeMethodInfoPtr__UpdateGameModes_b__2_Internal_Boolean_GameModeConfiguration_0;

		public unsafe GameModeModel gameModeModel
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_gameModeModel);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<GameModeModel>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_gameModeModel)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)gameModeModel));
			}
		}

		public unsafe __c__DisplayClass228_0 field_Public___c__DisplayClass228_0_0
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_field_Public___c__DisplayClass228_0_0);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<__c__DisplayClass228_0>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_field_Public___c__DisplayClass228_0_0)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)_c__DisplayClass228_));
			}
		}

		static __c__DisplayClass228_2()
		{
			Il2CppClassPointerStore<__c__DisplayClass228_2>.NativeClassPtr = IL2CPP.GetIl2CppNestedType(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "<>c__DisplayClass228_2");
			IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<__c__DisplayClass228_2>.NativeClassPtr);
			NativeFieldInfoPtr_gameModeModel = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<__c__DisplayClass228_2>.NativeClassPtr, "gameModeModel");
			NativeFieldInfoPtr_field_Public___c__DisplayClass228_0_0 = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<__c__DisplayClass228_2>.NativeClassPtr, "CS$<>8__locals1");
			NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<__c__DisplayClass228_2>.NativeClassPtr, 100669748);
			NativeMethodInfoPtr__UpdateGameModes_b__2_Internal_Boolean_GameModeConfiguration_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<__c__DisplayClass228_2>.NativeClassPtr, 100669749);
		}

		[CallerCount(5410)]
		[CachedScanResults(RefRangeStart = 11, RefRangeEnd = 5421, XrefRangeStart = 11, XrefRangeEnd = 5421, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe __c__DisplayClass228_2()
			: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<__c__DisplayClass228_2>.NativeClassPtr))
		{
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		[CallerCount(0)]
		public unsafe bool _UpdateGameModes_b__2(GameModesConfiguration.GameModeConfiguration gm)
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = stackalloc System.IntPtr[1];
			*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)gm);
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__UpdateGameModes_b__2_Internal_Boolean_GameModeConfiguration_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return *(bool*)IL2CPP.il2cpp_object_unbox(intPtr);
		}

		public __c__DisplayClass228_2(System.IntPtr pointer)
			: base(pointer)
		{
		}
	}

	[ObfuscatedName("BAPBAP.UI.UILobbyPlayTabPage+<>c__DisplayClass249_0")]
	public sealed class __c__DisplayClass249_0 : Il2CppSystem.Object
	{
		private static readonly System.IntPtr NativeFieldInfoPtr_accountId;

		private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

		private static readonly System.IntPtr NativeMethodInfoPtr__PlayerAccountBannerUpdate_b__0_Internal_Boolean_PlayerModel_0;

		public unsafe string accountId
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_accountId);
				return IL2CPP.Il2CppStringToManaged(*(System.IntPtr*)num);
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_accountId)), IL2CPP.ManagedStringToIl2Cpp(text));
			}
		}

		static __c__DisplayClass249_0()
		{
			Il2CppClassPointerStore<__c__DisplayClass249_0>.NativeClassPtr = IL2CPP.GetIl2CppNestedType(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "<>c__DisplayClass249_0");
			IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<__c__DisplayClass249_0>.NativeClassPtr);
			NativeFieldInfoPtr_accountId = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<__c__DisplayClass249_0>.NativeClassPtr, "accountId");
			NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<__c__DisplayClass249_0>.NativeClassPtr, 100669750);
			NativeMethodInfoPtr__PlayerAccountBannerUpdate_b__0_Internal_Boolean_PlayerModel_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<__c__DisplayClass249_0>.NativeClassPtr, 100669751);
		}

		[CallerCount(5410)]
		[CachedScanResults(RefRangeStart = 11, RefRangeEnd = 5421, XrefRangeStart = 11, XrefRangeEnd = 5421, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe __c__DisplayClass249_0()
			: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<__c__DisplayClass249_0>.NativeClassPtr))
		{
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		[CallerCount(0)]
		[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 0, XrefRangeEnd = 0, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe bool _PlayerAccountBannerUpdate_b__0(PlayerModel teammate)
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = stackalloc System.IntPtr[1];
			*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)teammate);
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__PlayerAccountBannerUpdate_b__0_Internal_Boolean_PlayerModel_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return *(bool*)IL2CPP.il2cpp_object_unbox(intPtr);
		}

		public __c__DisplayClass249_0(System.IntPtr pointer)
			: base(pointer)
		{
		}
	}

	[ObfuscatedName("BAPBAP.UI.UILobbyPlayTabPage+<>c__DisplayClass250_0")]
	public sealed class __c__DisplayClass250_0 : Il2CppSystem.Object
	{
		private static readonly System.IntPtr NativeFieldInfoPtr_accountId;

		private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

		private static readonly System.IntPtr NativeMethodInfoPtr__PlayerAccountLevelUpdate_b__0_Internal_Boolean_PlayerModel_0;

		public unsafe string accountId
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_accountId);
				return IL2CPP.Il2CppStringToManaged(*(System.IntPtr*)num);
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_accountId)), IL2CPP.ManagedStringToIl2Cpp(text));
			}
		}

		static __c__DisplayClass250_0()
		{
			Il2CppClassPointerStore<__c__DisplayClass250_0>.NativeClassPtr = IL2CPP.GetIl2CppNestedType(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "<>c__DisplayClass250_0");
			IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<__c__DisplayClass250_0>.NativeClassPtr);
			NativeFieldInfoPtr_accountId = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<__c__DisplayClass250_0>.NativeClassPtr, "accountId");
			NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<__c__DisplayClass250_0>.NativeClassPtr, 100669752);
			NativeMethodInfoPtr__PlayerAccountLevelUpdate_b__0_Internal_Boolean_PlayerModel_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<__c__DisplayClass250_0>.NativeClassPtr, 100669753);
		}

		[CallerCount(5410)]
		[CachedScanResults(RefRangeStart = 11, RefRangeEnd = 5421, XrefRangeStart = 11, XrefRangeEnd = 5421, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe __c__DisplayClass250_0()
			: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<__c__DisplayClass250_0>.NativeClassPtr))
		{
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		[CallerCount(0)]
		[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 0, XrefRangeEnd = 0, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe bool _PlayerAccountLevelUpdate_b__0(PlayerModel teammate)
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = stackalloc System.IntPtr[1];
			*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)teammate);
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__PlayerAccountLevelUpdate_b__0_Internal_Boolean_PlayerModel_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return *(bool*)IL2CPP.il2cpp_object_unbox(intPtr);
		}

		public __c__DisplayClass250_0(System.IntPtr pointer)
			: base(pointer)
		{
		}
	}

	[ObfuscatedName("BAPBAP.UI.UILobbyPlayTabPage+<>c__DisplayClass364_0")]
	public sealed class __c__DisplayClass364_0 : Il2CppSystem.Object
	{
		private static readonly System.IntPtr NativeFieldInfoPtr_accountId;

		private static readonly System.IntPtr NativeFieldInfoPtr___4__this;

		private static readonly System.IntPtr NativeFieldInfoPtr_teammate;

		private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

		private static readonly System.IntPtr NativeMethodInfoPtr__OpenTeammateOptionDropdown_b__0_Internal_Boolean_PlayerModel_0;

		private static readonly System.IntPtr NativeMethodInfoPtr__OpenTeammateOptionDropdown_b__2_Internal_Void_0;

		private static readonly System.IntPtr NativeMethodInfoPtr__OpenTeammateOptionDropdown_b__3_Internal_Void_0;

		private static readonly System.IntPtr NativeMethodInfoPtr__OpenTeammateOptionDropdown_b__1_Internal_Void_0;

		public unsafe string accountId
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_accountId);
				return IL2CPP.Il2CppStringToManaged(*(System.IntPtr*)num);
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_accountId)), IL2CPP.ManagedStringToIl2Cpp(text));
			}
		}

		public unsafe UILobbyPlayTabPage __4__this
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr___4__this);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<UILobbyPlayTabPage>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr___4__this)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)uILobbyPlayTabPage));
			}
		}

		public unsafe PlayerModel teammate
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_teammate);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<PlayerModel>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_teammate)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)playerModel));
			}
		}

		static __c__DisplayClass364_0()
		{
			Il2CppClassPointerStore<__c__DisplayClass364_0>.NativeClassPtr = IL2CPP.GetIl2CppNestedType(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "<>c__DisplayClass364_0");
			IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<__c__DisplayClass364_0>.NativeClassPtr);
			NativeFieldInfoPtr_accountId = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<__c__DisplayClass364_0>.NativeClassPtr, "accountId");
			NativeFieldInfoPtr___4__this = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<__c__DisplayClass364_0>.NativeClassPtr, "<>4__this");
			NativeFieldInfoPtr_teammate = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<__c__DisplayClass364_0>.NativeClassPtr, "teammate");
			NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<__c__DisplayClass364_0>.NativeClassPtr, 100669754);
			NativeMethodInfoPtr__OpenTeammateOptionDropdown_b__0_Internal_Boolean_PlayerModel_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<__c__DisplayClass364_0>.NativeClassPtr, 100669755);
			NativeMethodInfoPtr__OpenTeammateOptionDropdown_b__2_Internal_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<__c__DisplayClass364_0>.NativeClassPtr, 100669756);
			NativeMethodInfoPtr__OpenTeammateOptionDropdown_b__3_Internal_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<__c__DisplayClass364_0>.NativeClassPtr, 100669757);
			NativeMethodInfoPtr__OpenTeammateOptionDropdown_b__1_Internal_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<__c__DisplayClass364_0>.NativeClassPtr, 100669758);
		}

		[CallerCount(5410)]
		[CachedScanResults(RefRangeStart = 11, RefRangeEnd = 5421, XrefRangeStart = 11, XrefRangeEnd = 5421, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe __c__DisplayClass364_0()
			: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<__c__DisplayClass364_0>.NativeClassPtr))
		{
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		[CallerCount(0)]
		[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 0, XrefRangeEnd = 0, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe bool _OpenTeammateOptionDropdown_b__0(PlayerModel f)
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = stackalloc System.IntPtr[1];
			*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)f);
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__OpenTeammateOptionDropdown_b__0_Internal_Boolean_PlayerModel_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return *(bool*)IL2CPP.il2cpp_object_unbox(intPtr);
		}

		[CallerCount(0)]
		[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 95169, XrefRangeEnd = 95172, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe void _OpenTeammateOptionDropdown_b__2()
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__OpenTeammateOptionDropdown_b__2_Internal_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		[CallerCount(0)]
		[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 95172, XrefRangeEnd = 95173, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe void _OpenTeammateOptionDropdown_b__3()
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__OpenTeammateOptionDropdown_b__3_Internal_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		[CallerCount(0)]
		[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 95173, XrefRangeEnd = 95174, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe void _OpenTeammateOptionDropdown_b__1()
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__OpenTeammateOptionDropdown_b__1_Internal_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		public __c__DisplayClass364_0(System.IntPtr pointer)
			: base(pointer)
		{
		}
	}

	[ObfuscatedName("BAPBAP.UI.UILobbyPlayTabPage+<>c__DisplayClass392_0")]
	public sealed class __c__DisplayClass392_0 : Il2CppSystem.Object
	{
		private static readonly System.IntPtr NativeFieldInfoPtr___4__this;

		private static readonly System.IntPtr NativeFieldInfoPtr_lobbyCode;

		private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

		private static readonly System.IntPtr NativeMethodInfoPtr__InitialiseFriendInviteNotification_b__0_Internal_Void_0;

		public unsafe UILobbyPlayTabPage __4__this
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr___4__this);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<UILobbyPlayTabPage>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr___4__this)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)uILobbyPlayTabPage));
			}
		}

		public unsafe string lobbyCode
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_lobbyCode);
				return IL2CPP.Il2CppStringToManaged(*(System.IntPtr*)num);
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_lobbyCode)), IL2CPP.ManagedStringToIl2Cpp(text));
			}
		}

		static __c__DisplayClass392_0()
		{
			Il2CppClassPointerStore<__c__DisplayClass392_0>.NativeClassPtr = IL2CPP.GetIl2CppNestedType(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "<>c__DisplayClass392_0");
			IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<__c__DisplayClass392_0>.NativeClassPtr);
			NativeFieldInfoPtr___4__this = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<__c__DisplayClass392_0>.NativeClassPtr, "<>4__this");
			NativeFieldInfoPtr_lobbyCode = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<__c__DisplayClass392_0>.NativeClassPtr, "lobbyCode");
			NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<__c__DisplayClass392_0>.NativeClassPtr, 100669759);
			NativeMethodInfoPtr__InitialiseFriendInviteNotification_b__0_Internal_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<__c__DisplayClass392_0>.NativeClassPtr, 100669760);
		}

		[CallerCount(5410)]
		[CachedScanResults(RefRangeStart = 11, RefRangeEnd = 5421, XrefRangeStart = 11, XrefRangeEnd = 5421, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe __c__DisplayClass392_0()
			: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<__c__DisplayClass392_0>.NativeClassPtr))
		{
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		[CallerCount(0)]
		[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 95174, XrefRangeEnd = 95175, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe void _InitialiseFriendInviteNotification_b__0()
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__InitialiseFriendInviteNotification_b__0_Internal_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		public __c__DisplayClass392_0(System.IntPtr pointer)
			: base(pointer)
		{
		}
	}

	[ObfuscatedName("BAPBAP.UI.UILobbyPlayTabPage+<>c__DisplayClass398_0")]
	public sealed class __c__DisplayClass398_0 : Il2CppSystem.Object
	{
		private static readonly System.IntPtr NativeFieldInfoPtr_entry;

		private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

		private static readonly System.IntPtr NativeMethodInfoPtr__SendFriendLobbyInvite_b__0_Internal_Boolean_Friend_0;

		public unsafe UILobbyFriendEntry entry
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_entry);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<UILobbyFriendEntry>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_entry)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)uILobbyFriendEntry));
			}
		}

		static __c__DisplayClass398_0()
		{
			Il2CppClassPointerStore<__c__DisplayClass398_0>.NativeClassPtr = IL2CPP.GetIl2CppNestedType(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "<>c__DisplayClass398_0");
			IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<__c__DisplayClass398_0>.NativeClassPtr);
			NativeFieldInfoPtr_entry = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<__c__DisplayClass398_0>.NativeClassPtr, "entry");
			NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<__c__DisplayClass398_0>.NativeClassPtr, 100669761);
			NativeMethodInfoPtr__SendFriendLobbyInvite_b__0_Internal_Boolean_Friend_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<__c__DisplayClass398_0>.NativeClassPtr, 100669762);
		}

		[CallerCount(5410)]
		[CachedScanResults(RefRangeStart = 11, RefRangeEnd = 5421, XrefRangeStart = 11, XrefRangeEnd = 5421, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe __c__DisplayClass398_0()
			: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<__c__DisplayClass398_0>.NativeClassPtr))
		{
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		[CallerCount(0)]
		[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 95175, XrefRangeEnd = 95176, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe bool _SendFriendLobbyInvite_b__0(LobbyDataModel.Friend f)
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = stackalloc System.IntPtr[1];
			*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)f);
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__SendFriendLobbyInvite_b__0_Internal_Boolean_Friend_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return *(bool*)IL2CPP.il2cpp_object_unbox(intPtr);
		}

		public __c__DisplayClass398_0(System.IntPtr pointer)
			: base(pointer)
		{
		}
	}

	[ObfuscatedName("BAPBAP.UI.UILobbyPlayTabPage+<>c__DisplayClass402_0")]
	public sealed class __c__DisplayClass402_0 : Il2CppSystem.Object
	{
		private static readonly System.IntPtr NativeFieldInfoPtr_friend;

		private static readonly System.IntPtr NativeFieldInfoPtr___4__this;

		private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

		private static readonly System.IntPtr NativeMethodInfoPtr__PopulateFriendsPanel_b__0_Internal_Void_RectTransform_0;

		public unsafe LobbyDataModel.Friend friend
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_friend);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<LobbyDataModel.Friend>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_friend)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)friend));
			}
		}

		public unsafe UILobbyPlayTabPage __4__this
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr___4__this);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<UILobbyPlayTabPage>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr___4__this)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)uILobbyPlayTabPage));
			}
		}

		static __c__DisplayClass402_0()
		{
			Il2CppClassPointerStore<__c__DisplayClass402_0>.NativeClassPtr = IL2CPP.GetIl2CppNestedType(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "<>c__DisplayClass402_0");
			IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<__c__DisplayClass402_0>.NativeClassPtr);
			NativeFieldInfoPtr_friend = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<__c__DisplayClass402_0>.NativeClassPtr, "friend");
			NativeFieldInfoPtr___4__this = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<__c__DisplayClass402_0>.NativeClassPtr, "<>4__this");
			NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<__c__DisplayClass402_0>.NativeClassPtr, 100669763);
			NativeMethodInfoPtr__PopulateFriendsPanel_b__0_Internal_Void_RectTransform_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<__c__DisplayClass402_0>.NativeClassPtr, 100669764);
		}

		[CallerCount(5410)]
		[CachedScanResults(RefRangeStart = 11, RefRangeEnd = 5421, XrefRangeStart = 11, XrefRangeEnd = 5421, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe __c__DisplayClass402_0()
			: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<__c__DisplayClass402_0>.NativeClassPtr))
		{
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		[CallerCount(0)]
		[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 95176, XrefRangeEnd = 95177, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe void _PopulateFriendsPanel_b__0(RectTransform rt)
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = stackalloc System.IntPtr[1];
			*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)rt);
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__PopulateFriendsPanel_b__0_Internal_Void_RectTransform_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		public __c__DisplayClass402_0(System.IntPtr pointer)
			: base(pointer)
		{
		}
	}

	[ObfuscatedName("BAPBAP.UI.UILobbyPlayTabPage+<>c__DisplayClass403_0")]
	public sealed class __c__DisplayClass403_0 : Il2CppSystem.Object
	{
		private static readonly System.IntPtr NativeFieldInfoPtr_sFriend;

		private static readonly System.IntPtr NativeFieldInfoPtr___4__this;

		private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

		private static readonly System.IntPtr NativeMethodInfoPtr__PopulateSteamFriendsPanel_b__0_Internal_Void_UILobbyFriendEntry_0;

		public unsafe SteamManager.SteamFriend sFriend
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_sFriend);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<SteamManager.SteamFriend>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_sFriend)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)steamFriend));
			}
		}

		public unsafe UILobbyPlayTabPage __4__this
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr___4__this);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<UILobbyPlayTabPage>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr___4__this)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)uILobbyPlayTabPage));
			}
		}

		static __c__DisplayClass403_0()
		{
			Il2CppClassPointerStore<__c__DisplayClass403_0>.NativeClassPtr = IL2CPP.GetIl2CppNestedType(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "<>c__DisplayClass403_0");
			IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<__c__DisplayClass403_0>.NativeClassPtr);
			NativeFieldInfoPtr_sFriend = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<__c__DisplayClass403_0>.NativeClassPtr, "sFriend");
			NativeFieldInfoPtr___4__this = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<__c__DisplayClass403_0>.NativeClassPtr, "<>4__this");
			NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<__c__DisplayClass403_0>.NativeClassPtr, 100669765);
			NativeMethodInfoPtr__PopulateSteamFriendsPanel_b__0_Internal_Void_UILobbyFriendEntry_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<__c__DisplayClass403_0>.NativeClassPtr, 100669766);
		}

		[CallerCount(5410)]
		[CachedScanResults(RefRangeStart = 11, RefRangeEnd = 5421, XrefRangeStart = 11, XrefRangeEnd = 5421, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe __c__DisplayClass403_0()
			: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<__c__DisplayClass403_0>.NativeClassPtr))
		{
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		[CallerCount(0)]
		[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 95177, XrefRangeEnd = 95178, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe void _PopulateSteamFriendsPanel_b__0(UILobbyFriendEntry entry)
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = stackalloc System.IntPtr[1];
			*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)entry);
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__PopulateSteamFriendsPanel_b__0_Internal_Void_UILobbyFriendEntry_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		public __c__DisplayClass403_0(System.IntPtr pointer)
			: base(pointer)
		{
		}
	}

	[ObfuscatedName("BAPBAP.UI.UILobbyPlayTabPage+<>c__DisplayClass407_0")]
	public sealed class __c__DisplayClass407_0 : Il2CppSystem.Object
	{
		private static readonly System.IntPtr NativeFieldInfoPtr_accountId;

		private static readonly System.IntPtr NativeFieldInfoPtr_friend;

		private static readonly System.IntPtr NativeFieldInfoPtr___4__this;

		private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

		private static readonly System.IntPtr NativeMethodInfoPtr__RefreshFriendOptionsDropdown_b__0_Internal_Boolean_Friend_0;

		private static readonly System.IntPtr NativeMethodInfoPtr__RefreshFriendOptionsDropdown_b__1_Internal_Boolean_UILobbyFriendEntry_0;

		private static readonly System.IntPtr NativeMethodInfoPtr__RefreshFriendOptionsDropdown_b__2_Internal_Boolean_PlayerModel_0;

		private static readonly System.IntPtr NativeMethodInfoPtr__RefreshFriendOptionsDropdown_b__3_Internal_Void_0;

		private static readonly System.IntPtr NativeMethodInfoPtr__RefreshFriendOptionsDropdown_b__4_Internal_Void_0;

		private static readonly System.IntPtr NativeMethodInfoPtr__RefreshFriendOptionsDropdown_b__5_Internal_Void_0;

		private static readonly System.IntPtr NativeMethodInfoPtr__RefreshFriendOptionsDropdown_b__6_Internal_Void_0;

		public unsafe string accountId
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_accountId);
				return IL2CPP.Il2CppStringToManaged(*(System.IntPtr*)num);
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_accountId)), IL2CPP.ManagedStringToIl2Cpp(text));
			}
		}

		public unsafe LobbyDataModel.Friend friend
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_friend);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<LobbyDataModel.Friend>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_friend)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)friend));
			}
		}

		public unsafe UILobbyPlayTabPage __4__this
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr___4__this);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<UILobbyPlayTabPage>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr___4__this)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)uILobbyPlayTabPage));
			}
		}

		static __c__DisplayClass407_0()
		{
			Il2CppClassPointerStore<__c__DisplayClass407_0>.NativeClassPtr = IL2CPP.GetIl2CppNestedType(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "<>c__DisplayClass407_0");
			IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<__c__DisplayClass407_0>.NativeClassPtr);
			NativeFieldInfoPtr_accountId = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<__c__DisplayClass407_0>.NativeClassPtr, "accountId");
			NativeFieldInfoPtr_friend = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<__c__DisplayClass407_0>.NativeClassPtr, "friend");
			NativeFieldInfoPtr___4__this = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<__c__DisplayClass407_0>.NativeClassPtr, "<>4__this");
			NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<__c__DisplayClass407_0>.NativeClassPtr, 100669767);
			NativeMethodInfoPtr__RefreshFriendOptionsDropdown_b__0_Internal_Boolean_Friend_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<__c__DisplayClass407_0>.NativeClassPtr, 100669768);
			NativeMethodInfoPtr__RefreshFriendOptionsDropdown_b__1_Internal_Boolean_UILobbyFriendEntry_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<__c__DisplayClass407_0>.NativeClassPtr, 100669769);
			NativeMethodInfoPtr__RefreshFriendOptionsDropdown_b__2_Internal_Boolean_PlayerModel_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<__c__DisplayClass407_0>.NativeClassPtr, 100669770);
			NativeMethodInfoPtr__RefreshFriendOptionsDropdown_b__3_Internal_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<__c__DisplayClass407_0>.NativeClassPtr, 100669771);
			NativeMethodInfoPtr__RefreshFriendOptionsDropdown_b__4_Internal_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<__c__DisplayClass407_0>.NativeClassPtr, 100669772);
			NativeMethodInfoPtr__RefreshFriendOptionsDropdown_b__5_Internal_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<__c__DisplayClass407_0>.NativeClassPtr, 100669773);
			NativeMethodInfoPtr__RefreshFriendOptionsDropdown_b__6_Internal_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<__c__DisplayClass407_0>.NativeClassPtr, 100669774);
		}

		[CallerCount(5410)]
		[CachedScanResults(RefRangeStart = 11, RefRangeEnd = 5421, XrefRangeStart = 11, XrefRangeEnd = 5421, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe __c__DisplayClass407_0()
			: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<__c__DisplayClass407_0>.NativeClassPtr))
		{
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		[CallerCount(0)]
		[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 0, XrefRangeEnd = 0, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe bool _RefreshFriendOptionsDropdown_b__0(LobbyDataModel.Friend f)
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = stackalloc System.IntPtr[1];
			*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)f);
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__RefreshFriendOptionsDropdown_b__0_Internal_Boolean_Friend_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return *(bool*)IL2CPP.il2cpp_object_unbox(intPtr);
		}

		[CallerCount(0)]
		[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 0, XrefRangeEnd = 0, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe bool _RefreshFriendOptionsDropdown_b__1(UILobbyFriendEntry x)
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = stackalloc System.IntPtr[1];
			*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)x);
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__RefreshFriendOptionsDropdown_b__1_Internal_Boolean_UILobbyFriendEntry_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return *(bool*)IL2CPP.il2cpp_object_unbox(intPtr);
		}

		[CallerCount(0)]
		[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 95178, XrefRangeEnd = 95179, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe bool _RefreshFriendOptionsDropdown_b__2(PlayerModel x)
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = stackalloc System.IntPtr[1];
			*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)x);
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__RefreshFriendOptionsDropdown_b__2_Internal_Boolean_PlayerModel_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return *(bool*)IL2CPP.il2cpp_object_unbox(intPtr);
		}

		[CallerCount(0)]
		[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 95179, XrefRangeEnd = 95180, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe void _RefreshFriendOptionsDropdown_b__3()
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__RefreshFriendOptionsDropdown_b__3_Internal_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		[CallerCount(0)]
		[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 95180, XrefRangeEnd = 95181, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe void _RefreshFriendOptionsDropdown_b__4()
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__RefreshFriendOptionsDropdown_b__4_Internal_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		[CallerCount(0)]
		[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 95181, XrefRangeEnd = 95182, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe void _RefreshFriendOptionsDropdown_b__5()
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__RefreshFriendOptionsDropdown_b__5_Internal_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		[CallerCount(0)]
		[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 95182, XrefRangeEnd = 95183, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe void _RefreshFriendOptionsDropdown_b__6()
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__RefreshFriendOptionsDropdown_b__6_Internal_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		public __c__DisplayClass407_0(System.IntPtr pointer)
			: base(pointer)
		{
		}
	}

	[ObfuscatedName("BAPBAP.UI.UILobbyPlayTabPage+<>c__DisplayClass409_0")]
	public sealed class __c__DisplayClass409_0 : Il2CppSystem.Object
	{
		private static readonly System.IntPtr NativeFieldInfoPtr_accountId;

		private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

		private static readonly System.IntPtr NativeMethodInfoPtr__OnFriendOptionInviteToGame_b__0_Internal_Boolean_UILobbyFriendEntry_0;

		public unsafe string accountId
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_accountId);
				return IL2CPP.Il2CppStringToManaged(*(System.IntPtr*)num);
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_accountId)), IL2CPP.ManagedStringToIl2Cpp(text));
			}
		}

		static __c__DisplayClass409_0()
		{
			Il2CppClassPointerStore<__c__DisplayClass409_0>.NativeClassPtr = IL2CPP.GetIl2CppNestedType(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "<>c__DisplayClass409_0");
			IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<__c__DisplayClass409_0>.NativeClassPtr);
			NativeFieldInfoPtr_accountId = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<__c__DisplayClass409_0>.NativeClassPtr, "accountId");
			NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<__c__DisplayClass409_0>.NativeClassPtr, 100669775);
			NativeMethodInfoPtr__OnFriendOptionInviteToGame_b__0_Internal_Boolean_UILobbyFriendEntry_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<__c__DisplayClass409_0>.NativeClassPtr, 100669776);
		}

		[CallerCount(5410)]
		[CachedScanResults(RefRangeStart = 11, RefRangeEnd = 5421, XrefRangeStart = 11, XrefRangeEnd = 5421, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe __c__DisplayClass409_0()
			: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<__c__DisplayClass409_0>.NativeClassPtr))
		{
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		[CallerCount(0)]
		[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 0, XrefRangeEnd = 0, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe bool _OnFriendOptionInviteToGame_b__0(UILobbyFriendEntry x)
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = stackalloc System.IntPtr[1];
			*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)x);
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__OnFriendOptionInviteToGame_b__0_Internal_Boolean_UILobbyFriendEntry_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return *(bool*)IL2CPP.il2cpp_object_unbox(intPtr);
		}

		public __c__DisplayClass409_0(System.IntPtr pointer)
			: base(pointer)
		{
		}
	}

	[ObfuscatedName("BAPBAP.UI.UILobbyPlayTabPage+<>c__DisplayClass410_0")]
	public sealed class __c__DisplayClass410_0 : Il2CppSystem.Object
	{
		private static readonly System.IntPtr NativeFieldInfoPtr_accountId;

		private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

		private static readonly System.IntPtr NativeMethodInfoPtr__OnFriendOptionDirectMessage_b__0_Internal_Boolean_Friend_0;

		public unsafe string accountId
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_accountId);
				return IL2CPP.Il2CppStringToManaged(*(System.IntPtr*)num);
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_accountId)), IL2CPP.ManagedStringToIl2Cpp(text));
			}
		}

		static __c__DisplayClass410_0()
		{
			Il2CppClassPointerStore<__c__DisplayClass410_0>.NativeClassPtr = IL2CPP.GetIl2CppNestedType(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "<>c__DisplayClass410_0");
			IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<__c__DisplayClass410_0>.NativeClassPtr);
			NativeFieldInfoPtr_accountId = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<__c__DisplayClass410_0>.NativeClassPtr, "accountId");
			NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<__c__DisplayClass410_0>.NativeClassPtr, 100669777);
			NativeMethodInfoPtr__OnFriendOptionDirectMessage_b__0_Internal_Boolean_Friend_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<__c__DisplayClass410_0>.NativeClassPtr, 100669778);
		}

		[CallerCount(5410)]
		[CachedScanResults(RefRangeStart = 11, RefRangeEnd = 5421, XrefRangeStart = 11, XrefRangeEnd = 5421, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe __c__DisplayClass410_0()
			: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<__c__DisplayClass410_0>.NativeClassPtr))
		{
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		[CallerCount(0)]
		[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 0, XrefRangeEnd = 0, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe bool _OnFriendOptionDirectMessage_b__0(LobbyDataModel.Friend x)
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = stackalloc System.IntPtr[1];
			*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)x);
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__OnFriendOptionDirectMessage_b__0_Internal_Boolean_Friend_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return *(bool*)IL2CPP.il2cpp_object_unbox(intPtr);
		}

		public __c__DisplayClass410_0(System.IntPtr pointer)
			: base(pointer)
		{
		}
	}

	[ObfuscatedName("BAPBAP.UI.UILobbyPlayTabPage+<>c__DisplayClass411_0")]
	public sealed class __c__DisplayClass411_0 : Il2CppSystem.Object
	{
		private static readonly System.IntPtr NativeFieldInfoPtr___4__this;

		private static readonly System.IntPtr NativeFieldInfoPtr_accountId;

		private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

		private static readonly System.IntPtr NativeMethodInfoPtr__OnFriendOptionUnfriend_b__0_Internal_Void_0;

		public unsafe UILobbyPlayTabPage __4__this
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr___4__this);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<UILobbyPlayTabPage>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr___4__this)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)uILobbyPlayTabPage));
			}
		}

		public unsafe string accountId
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_accountId);
				return IL2CPP.Il2CppStringToManaged(*(System.IntPtr*)num);
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_accountId)), IL2CPP.ManagedStringToIl2Cpp(text));
			}
		}

		static __c__DisplayClass411_0()
		{
			Il2CppClassPointerStore<__c__DisplayClass411_0>.NativeClassPtr = IL2CPP.GetIl2CppNestedType(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "<>c__DisplayClass411_0");
			IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<__c__DisplayClass411_0>.NativeClassPtr);
			NativeFieldInfoPtr___4__this = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<__c__DisplayClass411_0>.NativeClassPtr, "<>4__this");
			NativeFieldInfoPtr_accountId = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<__c__DisplayClass411_0>.NativeClassPtr, "accountId");
			NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<__c__DisplayClass411_0>.NativeClassPtr, 100669779);
			NativeMethodInfoPtr__OnFriendOptionUnfriend_b__0_Internal_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<__c__DisplayClass411_0>.NativeClassPtr, 100669780);
		}

		[CallerCount(5410)]
		[CachedScanResults(RefRangeStart = 11, RefRangeEnd = 5421, XrefRangeStart = 11, XrefRangeEnd = 5421, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe __c__DisplayClass411_0()
			: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<__c__DisplayClass411_0>.NativeClassPtr))
		{
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		[CallerCount(0)]
		[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 95183, XrefRangeEnd = 95185, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe void _OnFriendOptionUnfriend_b__0()
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__OnFriendOptionUnfriend_b__0_Internal_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		public __c__DisplayClass411_0(System.IntPtr pointer)
			: base(pointer)
		{
		}
	}

	[ObfuscatedName("BAPBAP.UI.UILobbyPlayTabPage+<>c__DisplayClass412_0")]
	public sealed class __c__DisplayClass412_0 : Il2CppSystem.Object
	{
		private static readonly System.IntPtr NativeFieldInfoPtr_request;

		private static readonly System.IntPtr NativeFieldInfoPtr___4__this;

		private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

		private static readonly System.IntPtr NativeMethodInfoPtr__InitializeRequestsPanel_b__0_Internal_Void_0;

		private static readonly System.IntPtr NativeMethodInfoPtr__InitializeRequestsPanel_b__1_Internal_Void_0;

		public unsafe LobbyDataModel.Friend request
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_request);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<LobbyDataModel.Friend>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_request)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)friend));
			}
		}

		public unsafe UILobbyPlayTabPage __4__this
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr___4__this);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<UILobbyPlayTabPage>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr___4__this)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)uILobbyPlayTabPage));
			}
		}

		static __c__DisplayClass412_0()
		{
			Il2CppClassPointerStore<__c__DisplayClass412_0>.NativeClassPtr = IL2CPP.GetIl2CppNestedType(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "<>c__DisplayClass412_0");
			IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<__c__DisplayClass412_0>.NativeClassPtr);
			NativeFieldInfoPtr_request = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<__c__DisplayClass412_0>.NativeClassPtr, "request");
			NativeFieldInfoPtr___4__this = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<__c__DisplayClass412_0>.NativeClassPtr, "<>4__this");
			NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<__c__DisplayClass412_0>.NativeClassPtr, 100669781);
			NativeMethodInfoPtr__InitializeRequestsPanel_b__0_Internal_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<__c__DisplayClass412_0>.NativeClassPtr, 100669782);
			NativeMethodInfoPtr__InitializeRequestsPanel_b__1_Internal_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<__c__DisplayClass412_0>.NativeClassPtr, 100669783);
		}

		[CallerCount(5410)]
		[CachedScanResults(RefRangeStart = 11, RefRangeEnd = 5421, XrefRangeStart = 11, XrefRangeEnd = 5421, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe __c__DisplayClass412_0()
			: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<__c__DisplayClass412_0>.NativeClassPtr))
		{
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		[CallerCount(0)]
		public unsafe void _InitializeRequestsPanel_b__0()
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__InitializeRequestsPanel_b__0_Internal_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		[CallerCount(0)]
		public unsafe void _InitializeRequestsPanel_b__1()
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__InitializeRequestsPanel_b__1_Internal_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		public __c__DisplayClass412_0(System.IntPtr pointer)
			: base(pointer)
		{
		}
	}

	[ObfuscatedName("BAPBAP.UI.UILobbyPlayTabPage+<>c__DisplayClass420_0")]
	public sealed class __c__DisplayClass420_0 : Il2CppSystem.Object
	{
		private static readonly System.IntPtr NativeFieldInfoPtr_accountId;

		private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

		private static readonly System.IntPtr NativeMethodInfoPtr__TryRemoveFriendRequest_b__0_Internal_Boolean_Friend_0;

		public unsafe string accountId
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_accountId);
				return IL2CPP.Il2CppStringToManaged(*(System.IntPtr*)num);
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_accountId)), IL2CPP.ManagedStringToIl2Cpp(text));
			}
		}

		static __c__DisplayClass420_0()
		{
			Il2CppClassPointerStore<__c__DisplayClass420_0>.NativeClassPtr = IL2CPP.GetIl2CppNestedType(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "<>c__DisplayClass420_0");
			IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<__c__DisplayClass420_0>.NativeClassPtr);
			NativeFieldInfoPtr_accountId = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<__c__DisplayClass420_0>.NativeClassPtr, "accountId");
			NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<__c__DisplayClass420_0>.NativeClassPtr, 100669784);
			NativeMethodInfoPtr__TryRemoveFriendRequest_b__0_Internal_Boolean_Friend_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<__c__DisplayClass420_0>.NativeClassPtr, 100669785);
		}

		[CallerCount(5410)]
		[CachedScanResults(RefRangeStart = 11, RefRangeEnd = 5421, XrefRangeStart = 11, XrefRangeEnd = 5421, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe __c__DisplayClass420_0()
			: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<__c__DisplayClass420_0>.NativeClassPtr))
		{
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		[CallerCount(0)]
		[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 0, XrefRangeEnd = 0, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe bool _TryRemoveFriendRequest_b__0(LobbyDataModel.Friend f)
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = stackalloc System.IntPtr[1];
			*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)f);
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__TryRemoveFriendRequest_b__0_Internal_Boolean_Friend_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return *(bool*)IL2CPP.il2cpp_object_unbox(intPtr);
		}

		public __c__DisplayClass420_0(System.IntPtr pointer)
			: base(pointer)
		{
		}
	}

	[ObfuscatedName("BAPBAP.UI.UILobbyPlayTabPage+<>c__DisplayClass425_0")]
	public sealed class __c__DisplayClass425_0 : Il2CppSystem.Object
	{
		private static readonly System.IntPtr NativeFieldInfoPtr_accountId;

		private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

		private static readonly System.IntPtr NativeMethodInfoPtr__PlayerIsFriend_b__0_Internal_Boolean_Friend_0;

		public unsafe string accountId
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_accountId);
				return IL2CPP.Il2CppStringToManaged(*(System.IntPtr*)num);
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_accountId)), IL2CPP.ManagedStringToIl2Cpp(text));
			}
		}

		static __c__DisplayClass425_0()
		{
			Il2CppClassPointerStore<__c__DisplayClass425_0>.NativeClassPtr = IL2CPP.GetIl2CppNestedType(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "<>c__DisplayClass425_0");
			IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<__c__DisplayClass425_0>.NativeClassPtr);
			NativeFieldInfoPtr_accountId = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<__c__DisplayClass425_0>.NativeClassPtr, "accountId");
			NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<__c__DisplayClass425_0>.NativeClassPtr, 100669786);
			NativeMethodInfoPtr__PlayerIsFriend_b__0_Internal_Boolean_Friend_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<__c__DisplayClass425_0>.NativeClassPtr, 100669787);
		}

		[CallerCount(5410)]
		[CachedScanResults(RefRangeStart = 11, RefRangeEnd = 5421, XrefRangeStart = 11, XrefRangeEnd = 5421, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe __c__DisplayClass425_0()
			: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<__c__DisplayClass425_0>.NativeClassPtr))
		{
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		[CallerCount(0)]
		[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 0, XrefRangeEnd = 0, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe bool _PlayerIsFriend_b__0(LobbyDataModel.Friend f)
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = stackalloc System.IntPtr[1];
			*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)f);
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__PlayerIsFriend_b__0_Internal_Boolean_Friend_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return *(bool*)IL2CPP.il2cpp_object_unbox(intPtr);
		}

		public __c__DisplayClass425_0(System.IntPtr pointer)
			: base(pointer)
		{
		}
	}

	[ObfuscatedName("BAPBAP.UI.UILobbyPlayTabPage+<>c__DisplayClass429_0")]
	public sealed class __c__DisplayClass429_0 : Il2CppSystem.Object
	{
		private static readonly System.IntPtr NativeFieldInfoPtr_gameModeId;

		private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

		private static readonly System.IntPtr NativeMethodInfoPtr__SetGameModeSelectButton_b__0_Internal_Boolean_GameModeConfiguration_0;

		public unsafe int gameModeId
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_gameModeId);
				return *(int*)num;
			}
			set
			{
				*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_gameModeId)) = num;
			}
		}

		static __c__DisplayClass429_0()
		{
			Il2CppClassPointerStore<__c__DisplayClass429_0>.NativeClassPtr = IL2CPP.GetIl2CppNestedType(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "<>c__DisplayClass429_0");
			IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<__c__DisplayClass429_0>.NativeClassPtr);
			NativeFieldInfoPtr_gameModeId = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<__c__DisplayClass429_0>.NativeClassPtr, "gameModeId");
			NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<__c__DisplayClass429_0>.NativeClassPtr, 100669788);
			NativeMethodInfoPtr__SetGameModeSelectButton_b__0_Internal_Boolean_GameModeConfiguration_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<__c__DisplayClass429_0>.NativeClassPtr, 100669789);
		}

		[CallerCount(5410)]
		[CachedScanResults(RefRangeStart = 11, RefRangeEnd = 5421, XrefRangeStart = 11, XrefRangeEnd = 5421, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe __c__DisplayClass429_0()
			: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<__c__DisplayClass429_0>.NativeClassPtr))
		{
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		[CallerCount(0)]
		public unsafe bool _SetGameModeSelectButton_b__0(GameModesConfiguration.GameModeConfiguration gameMode)
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = stackalloc System.IntPtr[1];
			*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)gameMode);
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__SetGameModeSelectButton_b__0_Internal_Boolean_GameModeConfiguration_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return *(bool*)IL2CPP.il2cpp_object_unbox(intPtr);
		}

		public __c__DisplayClass429_0(System.IntPtr pointer)
			: base(pointer)
		{
		}
	}

	[ObfuscatedName("BAPBAP.UI.UILobbyPlayTabPage+<RedeemDeltaSequenceCoroutine>d__268")]
	public sealed class _RedeemDeltaSequenceCoroutine_d__268 : Il2CppSystem.Object
	{
		private static readonly System.IntPtr NativeFieldInfoPtr___1__state;

		private static readonly System.IntPtr NativeFieldInfoPtr___2__current;

		private static readonly System.IntPtr NativeFieldInfoPtr___4__this;

		private static readonly System.IntPtr NativeFieldInfoPtr__timeBetweenAnims_5__2;

		private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_Int32_0;

		private static readonly System.IntPtr NativeMethodInfoPtr_System_IDisposable_Dispose_Private_Virtual_Final_New_Void_0;

		private static readonly System.IntPtr NativeMethodInfoPtr_MoveNext_Private_Virtual_Final_New_Boolean_0;

		private static readonly System.IntPtr NativeMethodInfoPtr_System_Collections_Generic_IEnumerator_System_Object__get_Current_Private_Virtual_Final_New_get_Object_0;

		private static readonly System.IntPtr NativeMethodInfoPtr_System_Collections_IEnumerator_Reset_Private_Virtual_Final_New_Void_0;

		private static readonly System.IntPtr NativeMethodInfoPtr_System_Collections_IEnumerator_get_Current_Private_Virtual_Final_New_get_Object_0;

		public unsafe int __1__state
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr___1__state);
				return *(int*)num;
			}
			set
			{
				*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr___1__state)) = num;
			}
		}

		public unsafe Il2CppSystem.Object __2__current
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr___2__current);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppSystem.Object>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr___2__current)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)obj));
			}
		}

		public unsafe UILobbyPlayTabPage __4__this
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr___4__this);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<UILobbyPlayTabPage>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr___4__this)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)uILobbyPlayTabPage));
			}
		}

		public unsafe float _timeBetweenAnims_5__2
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__timeBetweenAnims_5__2);
				return *(float*)num;
			}
			set
			{
				*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__timeBetweenAnims_5__2)) = num;
			}
		}

		public unsafe virtual Il2CppSystem.Object System_002ECollections_002EGeneric_002EIEnumerator_003CSystem_002EObject_003E_002ECurrent
		{
			[CallerCount(140)]
			[CachedScanResults(RefRangeStart = 23558, RefRangeEnd = 23698, XrefRangeStart = 23558, XrefRangeEnd = 23698, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
			get
			{
				IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				System.IntPtr* ptr = null;
				Unsafe.SkipInit(out System.IntPtr intPtr2);
				System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_System_Collections_Generic_IEnumerator_System_Object__get_Current_Private_Virtual_Final_New_get_Object_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
				Il2CppException.RaiseExceptionIfNecessary(intPtr2);
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppSystem.Object>(intPtr) : null;
			}
		}

		public unsafe virtual Il2CppSystem.Object System_002ECollections_002EIEnumerator_002ECurrent
		{
			[CallerCount(140)]
			[CachedScanResults(RefRangeStart = 23558, RefRangeEnd = 23698, XrefRangeStart = 23558, XrefRangeEnd = 23698, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
			get
			{
				IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				System.IntPtr* ptr = null;
				Unsafe.SkipInit(out System.IntPtr intPtr2);
				System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_System_Collections_IEnumerator_get_Current_Private_Virtual_Final_New_get_Object_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
				Il2CppException.RaiseExceptionIfNecessary(intPtr2);
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppSystem.Object>(intPtr) : null;
			}
		}

		static _RedeemDeltaSequenceCoroutine_d__268()
		{
			Il2CppClassPointerStore<_RedeemDeltaSequenceCoroutine_d__268>.NativeClassPtr = IL2CPP.GetIl2CppNestedType(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "<RedeemDeltaSequenceCoroutine>d__268");
			IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<_RedeemDeltaSequenceCoroutine_d__268>.NativeClassPtr);
			NativeFieldInfoPtr___1__state = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<_RedeemDeltaSequenceCoroutine_d__268>.NativeClassPtr, "<>1__state");
			NativeFieldInfoPtr___2__current = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<_RedeemDeltaSequenceCoroutine_d__268>.NativeClassPtr, "<>2__current");
			NativeFieldInfoPtr___4__this = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<_RedeemDeltaSequenceCoroutine_d__268>.NativeClassPtr, "<>4__this");
			NativeFieldInfoPtr__timeBetweenAnims_5__2 = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<_RedeemDeltaSequenceCoroutine_d__268>.NativeClassPtr, "<timeBetweenAnims>5__2");
			NativeMethodInfoPtr__ctor_Public_Void_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<_RedeemDeltaSequenceCoroutine_d__268>.NativeClassPtr, 100669790);
			NativeMethodInfoPtr_System_IDisposable_Dispose_Private_Virtual_Final_New_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<_RedeemDeltaSequenceCoroutine_d__268>.NativeClassPtr, 100669791);
			NativeMethodInfoPtr_MoveNext_Private_Virtual_Final_New_Boolean_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<_RedeemDeltaSequenceCoroutine_d__268>.NativeClassPtr, 100669792);
			NativeMethodInfoPtr_System_Collections_Generic_IEnumerator_System_Object__get_Current_Private_Virtual_Final_New_get_Object_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<_RedeemDeltaSequenceCoroutine_d__268>.NativeClassPtr, 100669793);
			NativeMethodInfoPtr_System_Collections_IEnumerator_Reset_Private_Virtual_Final_New_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<_RedeemDeltaSequenceCoroutine_d__268>.NativeClassPtr, 100669794);
			NativeMethodInfoPtr_System_Collections_IEnumerator_get_Current_Private_Virtual_Final_New_get_Object_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<_RedeemDeltaSequenceCoroutine_d__268>.NativeClassPtr, 100669795);
		}

		[CallerCount(224)]
		[CachedScanResults(RefRangeStart = 23334, RefRangeEnd = 23558, XrefRangeStart = 23334, XrefRangeEnd = 23558, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe _RedeemDeltaSequenceCoroutine_d__268(int _003C_003E1__state)
			: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<_RedeemDeltaSequenceCoroutine_d__268>.NativeClassPtr))
		{
			System.IntPtr* ptr = stackalloc System.IntPtr[1];
			*ptr = (nint)(&_003C_003E1__state);
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_Int32_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		[CallerCount(17738)]
		[CachedScanResults(RefRangeStart = 5595, RefRangeEnd = 23333, XrefRangeStart = 5595, XrefRangeEnd = 23333, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe virtual void System_IDisposable_Dispose()
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_System_IDisposable_Dispose_Private_Virtual_Final_New_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		[CallerCount(0)]
		[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 95185, XrefRangeEnd = 95188, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe virtual bool MoveNext()
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_MoveNext_Private_Virtual_Final_New_Boolean_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return *(bool*)IL2CPP.il2cpp_object_unbox(intPtr);
		}

		[CallerCount(0)]
		[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 95188, XrefRangeEnd = 95193, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe virtual void System_Collections_IEnumerator_Reset()
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_System_Collections_IEnumerator_Reset_Private_Virtual_Final_New_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		public _RedeemDeltaSequenceCoroutine_d__268(System.IntPtr pointer)
			: base(pointer)
		{
		}
	}

	private static readonly System.IntPtr NativeFieldInfoPtr__canvasGroup;

	private static readonly System.IntPtr NativeFieldInfoPtr__canvasGroupSelectable;

	private static readonly System.IntPtr NativeFieldInfoPtr__uiLerpFade;

	private static readonly System.IntPtr NativeFieldInfoPtr__uiAlphaFade;

	private static readonly System.IntPtr NativeFieldInfoPtr__backgroundUIFade;

	private static readonly System.IntPtr NativeFieldInfoPtr_contentsCanvasGroup;

	private static readonly System.IntPtr NativeFieldInfoPtr__playerDisplay;

	private static readonly System.IntPtr NativeFieldInfoPtr__teammate1Display;

	private static readonly System.IntPtr NativeFieldInfoPtr__teammate2Display;

	private static readonly System.IntPtr NativeFieldInfoPtr__playContainer;

	private static readonly System.IntPtr NativeFieldInfoPtr__newReadyButton;

	private static readonly System.IntPtr NativeFieldInfoPtr__readyButton;

	private static readonly System.IntPtr NativeFieldInfoPtr__unreadyButton;

	private static readonly System.IntPtr NativeFieldInfoPtr__cancelButton;

	private static readonly System.IntPtr NativeFieldInfoPtr_playMaintenanceMessageText;

	private static readonly System.IntPtr NativeFieldInfoPtr_betaServiceMessageText;

	private static readonly System.IntPtr NativeFieldInfoPtr__gameQueuePanel;

	private static readonly System.IntPtr NativeFieldInfoPtr__gameModePlayButton;

	private static readonly System.IntPtr NativeFieldInfoPtr__regionDropdown;

	private static readonly System.IntPtr NativeFieldInfoPtr__matchStartPanel;

	private static readonly System.IntPtr NativeFieldInfoPtr__chatParent;

	private static readonly System.IntPtr NativeFieldInfoPtr__dailyReward;

	private static readonly System.IntPtr NativeFieldInfoPtr_profileButton;

	private static readonly System.IntPtr NativeFieldInfoPtr__battlePassPanel;

	private static readonly System.IntPtr NativeFieldInfoPtr__battlePassXpPopUp;

	private static readonly System.IntPtr NativeFieldInfoPtr__playersOnline;

	private static readonly System.IntPtr NativeFieldInfoPtr__liveWinnerFeedPanel;

	private static readonly System.IntPtr NativeFieldInfoPtr__notificationsPanel;

	private static readonly System.IntPtr NativeFieldInfoPtr__lobbyPopUp;

	private static readonly System.IntPtr NativeFieldInfoPtr__lobbyOptionDropdown;

	private static readonly System.IntPtr NativeFieldInfoPtr__friendsPanel;

	private static readonly System.IntPtr NativeFieldInfoPtr__friendInviteLobbyPopup;

	private static readonly System.IntPtr NativeFieldInfoPtr__friendsButton;

	private static readonly System.IntPtr NativeFieldInfoPtr__friendsButtonNotification;

	private static readonly System.IntPtr NativeFieldInfoPtr__friendsButtonNotificationText;

	private static readonly System.IntPtr NativeFieldInfoPtr__friendsPreview;

	private static readonly System.IntPtr NativeFieldInfoPtr__goldCurrencyPanel;

	private static readonly System.IntPtr NativeFieldInfoPtr__fractalCurrencyPanel;

	private static readonly System.IntPtr NativeFieldInfoPtr__fractalPurchaseButton;

	private static readonly System.IntPtr NativeFieldInfoPtr__fractalCurrencyPanelRoot;

	private static readonly System.IntPtr NativeFieldInfoPtr__softCurrencyPopUp;

	private static readonly System.IntPtr NativeFieldInfoPtr__fractalsCurrencyPopUp;

	private static readonly System.IntPtr NativeFieldInfoPtr__charTokenCurrencyPopUp;

	private static readonly System.IntPtr NativeFieldInfoPtr__profileXpPopUp;

	private static readonly System.IntPtr NativeFieldInfoPtr__referralCode;

	private static readonly System.IntPtr NativeFieldInfoPtr_newsPreviewButton;

	private static readonly System.IntPtr NativeFieldInfoPtr_openBetaChallenge;

	private static readonly System.IntPtr NativeFieldInfoPtr__customGameBackground;

	private static readonly System.IntPtr NativeFieldInfoPtr__elementsToDisableOnCustomGame;

	private static readonly System.IntPtr NativeFieldInfoPtr__customGameElementActiveCache;

	private static readonly System.IntPtr NativeFieldInfoPtr_NewsPanel;

	private static readonly System.IntPtr NativeFieldInfoPtr_DeveloperPanel;

	private static readonly System.IntPtr NativeFieldInfoPtr_LobbyOpenTogglePanel;

	private static readonly System.IntPtr NativeFieldInfoPtr_CustomGameLobby;

	private static readonly System.IntPtr NativeFieldInfoPtr_InviteCodePage;

	private static readonly System.IntPtr NativeFieldInfoPtr_gameModePage;

	private static readonly System.IntPtr NativeFieldInfoPtr__configuration;

	private static readonly System.IntPtr NativeFieldInfoPtr__translator;

	private static readonly System.IntPtr NativeFieldInfoPtr__actions;

	private static readonly System.IntPtr NativeFieldInfoPtr__lobbyDataModel;

	private static readonly System.IntPtr NativeFieldInfoPtr__teammateDisplays;

	private static readonly System.IntPtr NativeFieldInfoPtr__characterSelectIconFactory;

	private static readonly System.IntPtr NativeFieldInfoPtr_matchStartCharSelectButtons;

	private static readonly System.IntPtr NativeFieldInfoPtr_matchStartSelectedCharacterIcon;

	private static readonly System.IntPtr NativeFieldInfoPtr_matchStartSelectedCharIndex;

	private static readonly System.IntPtr NativeFieldInfoPtr_matchStartAnimateCharSelect;

	private static readonly System.IntPtr NativeFieldInfoPtr_matchStartAnimTime;

	private static readonly System.IntPtr NativeFieldInfoPtr__notificationEntryPool;

	private static readonly System.IntPtr NativeFieldInfoPtr__liveWinnerFeedEntryPool;

	private static readonly System.IntPtr NativeFieldInfoPtr_friendsPanelTabButtons;

	private static readonly System.IntPtr NativeFieldInfoPtr__friendEntryPool;

	private static readonly System.IntPtr NativeFieldInfoPtr__friendRequestEntryPool;

	private static readonly System.IntPtr NativeFieldInfoPtr_activeFriendEntries;

	private static readonly System.IntPtr NativeFieldInfoPtr_activeFriendRequestEntries;

	private static readonly System.IntPtr NativeFieldInfoPtr_friendInviteLobbyAction;

	private static readonly System.IntPtr NativeFieldInfoPtr_playButtonCooldown;

	private static readonly System.IntPtr NativeFieldInfoPtr_newsPreviewElements;

	private static readonly System.IntPtr NativeFieldInfoPtr_newsPreviewIcons;

	private static readonly System.IntPtr NativeFieldInfoPtr_newsPreviewCycleAnimate;

	private static readonly System.IntPtr NativeFieldInfoPtr_latestNewsButtonCycleTimer;

	private static readonly System.IntPtr NativeFieldInfoPtr_latestNewsButtonCycleId;

	private static readonly System.IntPtr NativeFieldInfoPtr_dailyRewardRefreshDate;

	private static readonly System.IntPtr NativeFieldInfoPtr_dailyRewardCountdownEnabled;

	private static readonly System.IntPtr NativeFieldInfoPtr_dailyRewardCountdownTimer;

	private static readonly System.IntPtr NativeFieldInfoPtr_animateDailyRewardProgress;

	private static readonly System.IntPtr NativeFieldInfoPtr_dailyRewardAnimTime;

	private static readonly System.IntPtr NativeFieldInfoPtr_lerpedDailyRewardProgress;

	private static readonly System.IntPtr NativeFieldInfoPtr_currentDailyRewardProgress;

	private static readonly System.IntPtr NativeFieldInfoPtr_prevCurrentDailyRewardProgress;

	private static readonly System.IntPtr NativeFieldInfoPtr_dailyRewardProgressMax;

	private static readonly System.IntPtr NativeFieldInfoPtr_redeemCoroutine;

	private static readonly System.IntPtr NativeFieldInfoPtr_currentBpLevel;

	private static readonly System.IntPtr NativeFieldInfoPtr_currentBpXp;

	private static readonly System.IntPtr NativeFieldInfoPtr_currentBpXpNeeded;

	private static readonly System.IntPtr NativeFieldInfoPtr_prevCurrentBpLevel;

	private static readonly System.IntPtr NativeFieldInfoPtr_prevCurrentBpXp;

	private static readonly System.IntPtr NativeFieldInfoPtr_maxBpLevel;

	private static readonly System.IntPtr NativeFieldInfoPtr_bpEndDate;

	private static readonly System.IntPtr NativeFieldInfoPtr__animateBpXpBar;

	private static readonly System.IntPtr NativeFieldInfoPtr__animateBpXpBarTime;

	private static readonly System.IntPtr NativeFieldInfoPtr__animCurrentBpLevel;

	private static readonly System.IntPtr NativeFieldInfoPtr__animCurrentBpXp;

	private static readonly System.IntPtr NativeFieldInfoPtr__animCurrentBpXpNeeded;

	private static readonly System.IntPtr NativeFieldInfoPtr__lerpedCurrentBpXp;

	private static readonly System.IntPtr NativeFieldInfoPtr_bpXpObtainedAmount;

	private static readonly System.IntPtr NativeFieldInfoPtr_queueBpXpObtain;

	private static readonly System.IntPtr NativeFieldInfoPtr__animateBpXpBarLevelUp;

	private static readonly System.IntPtr NativeFieldInfoPtr__animateBpXpBarLevelUpTime;

	private static readonly System.IntPtr NativeFieldInfoPtr_currentAccountLevel;

	private static readonly System.IntPtr NativeFieldInfoPtr_currentAccountXp;

	private static readonly System.IntPtr NativeFieldInfoPtr_currentAccountXpNeeded;

	private static readonly System.IntPtr NativeFieldInfoPtr_prevCurrentAccountLevel;

	private static readonly System.IntPtr NativeFieldInfoPtr_prevCurrentAccountXp;

	private static readonly System.IntPtr NativeFieldInfoPtr_maxAccountLevel;

	private static readonly System.IntPtr NativeFieldInfoPtr__animateAccountXpBar;

	private static readonly System.IntPtr NativeFieldInfoPtr__animateAccountXpBarTime;

	private static readonly System.IntPtr NativeFieldInfoPtr__animCurrentAccountLevel;

	private static readonly System.IntPtr NativeFieldInfoPtr__animCurrentAccountXp;

	private static readonly System.IntPtr NativeFieldInfoPtr__animCurrentAccountXpNeeded;

	private static readonly System.IntPtr NativeFieldInfoPtr__lerpedCurrentAccountXp;

	private static readonly System.IntPtr NativeFieldInfoPtr_accountXpObtainedAmount;

	private static readonly System.IntPtr NativeFieldInfoPtr_queueAccountXpObtain;

	private static readonly System.IntPtr NativeFieldInfoPtr__animateAccountXpBarLevelUp;

	private static readonly System.IntPtr NativeFieldInfoPtr__animateAccountXpBarLevelUpTime;

	private static readonly System.IntPtr NativeFieldInfoPtr_softCurrency;

	private static readonly System.IntPtr NativeFieldInfoPtr_animateSoftCurrency;

	private static readonly System.IntPtr NativeFieldInfoPtr_softCurrencyAnimTime;

	private static readonly System.IntPtr NativeFieldInfoPtr_lerpedSoftCurrency;

	private static readonly System.IntPtr NativeFieldInfoPtr_queueGoldObtain;

	private static readonly System.IntPtr NativeFieldInfoPtr_goldObtainedAmount;

	private static readonly System.IntPtr NativeFieldInfoPtr_fractalsCurrency;

	private static readonly System.IntPtr NativeFieldInfoPtr_animateFractalsCurrency;

	private static readonly System.IntPtr NativeFieldInfoPtr_fractalsCurrencyAnimTime;

	private static readonly System.IntPtr NativeFieldInfoPtr_lerpedFractalsCurrency;

	private static readonly System.IntPtr NativeFieldInfoPtr_queueFractalsObtain;

	private static readonly System.IntPtr NativeFieldInfoPtr_fractalsObtainedAmount;

	private static readonly System.IntPtr NativeFieldInfoPtr_charTokenCurrency;

	private static readonly System.IntPtr NativeFieldInfoPtr_animateCharTokenCurrency;

	private static readonly System.IntPtr NativeFieldInfoPtr_charTokenCurrencyAnimTime;

	private static readonly System.IntPtr NativeFieldInfoPtr_lerpedCharTokenCurrency;

	private static readonly System.IntPtr NativeFieldInfoPtr_queueCharTokenObtain;

	private static readonly System.IntPtr NativeFieldInfoPtr_charTokenObtainedAmount;

	private static readonly System.IntPtr NativeFieldInfoPtr__readyStatusString;

	private static readonly System.IntPtr NativeFieldInfoPtr__notReadyStatusString;

	private static readonly System.IntPtr NativeFieldInfoPtr__inQueueStatusString;

	private static readonly System.IntPtr NativeFieldInfoPtr__queueFindingPlayersStr;

	private static readonly System.IntPtr NativeFieldInfoPtr__queueGameStartingStr;

	private static readonly System.IntPtr NativeFieldInfoPtr__playersOnlineString;

	private static readonly System.IntPtr NativeFieldInfoPtr__linkCopiedPopUpString;

	private static readonly System.IntPtr NativeFieldInfoPtr_usernameIdCopiedString;

	private static readonly System.IntPtr NativeFieldInfoPtr_maxLevelStr;

	private static readonly System.IntPtr NativeFieldInfoPtr_dailyRewardRefreshesInStr;

	private static readonly System.IntPtr NativeFieldInfoPtr_gameModeEventStartsInStr;

	private static readonly System.IntPtr NativeFieldInfoPtr_inviteLobbyNotifStr;

	private static readonly System.IntPtr NativeFieldInfoPtr_onlineStr;

	private static readonly System.IntPtr NativeFieldInfoPtr_offlineStr;

	private static readonly System.IntPtr NativeFieldInfoPtr_steamOnlineStr;

	private static readonly System.IntPtr NativeFieldInfoPtr_steamOfflineStr;

	private static readonly System.IntPtr NativeFieldInfoPtr_sentAGameInviteToStr;

	private static readonly System.IntPtr NativeFieldInfoPtr_friendInviteSentToStr;

	private static readonly System.IntPtr NativeFieldInfoPtr_friendInviteSentErrorStr;

	private static readonly System.IntPtr NativeFieldInfoPtr_friendRequestAcceptedStr;

	private static readonly System.IntPtr NativeFieldInfoPtr_joinLobbyStr;

	private static readonly System.IntPtr NativeFieldInfoPtr_leaveLobbyStr;

	private static readonly System.IntPtr NativeFieldInfoPtr_inviteToGameStr;

	private static readonly System.IntPtr NativeFieldInfoPtr_messageFriendStr;

	private static readonly System.IntPtr NativeFieldInfoPtr_playerViewProfileStr;

	private static readonly System.IntPtr NativeFieldInfoPtr_friendUnfriendStr;

	private static readonly System.IntPtr NativeFieldInfoPtr_sendFriendRequestStr;

	private static readonly System.IntPtr NativeFieldInfoPtr_playerLobbyKickStr;

	private static readonly System.IntPtr NativeFieldInfoPtr_challengeXSignUpsOutOfYStr;

	private static readonly System.IntPtr NativeFieldInfoPtr_eventCountdownGmEnabled;

	private static readonly System.IntPtr NativeFieldInfoPtr_eventCountdownGmTimer;

	private static readonly System.IntPtr NativeFieldInfoPtr_eventCountdownGmButton;

	private static readonly System.IntPtr NativeFieldInfoPtr_hideLobbyCode;

	private static readonly System.IntPtr NativeFieldInfoPtr_FirstTimeTutorialPageKey;

	private static readonly System.IntPtr NativeFieldInfoPtr_LatestNewsTimestampKey;

	private static readonly System.IntPtr NativeFieldInfoPtr_HideLobbyCodeKey;

	private static readonly System.IntPtr NativeMethodInfoPtr_get_CanvasGroup_Public_Virtual_get_CanvasGroup_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_get_CanvasGroupSelectable_Public_Virtual_get_Selectable_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_get_UILerpFade_Public_Virtual_get_UIPosLerpFade_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_get_UIAlphaFade_Public_Virtual_get_UIAlphaFade_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_get_backgroundUIFade_Public_Virtual_get_UIAlphaFade_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_get_FractalPurchaseButton_Public_get_Button_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_FixedUpdate_Private_Void_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_Update_Private_Void_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_Build_Public_Void_Configuration_Translator_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_Localise_Public_Virtual_Void_Translator_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_SetActions_Public_Void_Actions_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_Initialise_Public_Void_LobbyDataModel_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_OnPageOpen_Public_Virtual_Void_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_OnPageClose_Public_Virtual_Void_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_OnInputModeChanged_Public_Virtual_Void_InputMode_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_FocusDefaultSelectable_Public_Void_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_UpdateData_Public_Void_LobbyDataModel_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_UpdateFriendData_Public_Void_LobbyDataModel_Friend_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_AddNewFriendEntry_Private_Void_Friend_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_UpdateFriendEntry_Private_Void_UILobbyFriendEntry_Friend_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_RemoveFriendEntry_Private_Void_UILobbyFriendEntry_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_UpdateFriendRequestsData_Public_Void_LobbyDataModel_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_UpdateInviteLobbyNotification_Public_Void_String_String_String_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_UpdateFriendStatus_Public_Void_String_Int32_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_UpdateFriendAvatarId_Public_Void_String_Int32_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_UpdateFriendLobbyOpen_Public_Void_String_Boolean_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_PlayFriendEntryFadeIn_Public_Void_String_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_PlayFriendRequestEntryFadeIn_Public_Void_String_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_SetPlayerCurrentStatus_Public_Void_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_UpdatePlayerFriendStatus_Private_Void_Int32_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_SetOpenFriendRequests_Public_Void_Boolean_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_SetClosedPartyRequests_Public_Void_Boolean_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_SetTimeZoneMaintenanceMessage_Private_Void_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_OnLoginButtonPressed_Public_Void_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_OnExitLobby_Private_Void_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_SwitchRegion_Public_Void_Int32_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_PopulateRegionDropdown_Private_Void_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_OnRegionDropdownChanged_Private_Void_Int32_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_UpdateRegionUI_Public_Void_Int32_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_SetLocalPlayerBanner_Public_Void_Int32_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_UpdateLocalPlayerBanner_Public_Void_Int32_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_PopulateTeammateDisplays_Public_Void_List_1_PlayerModel_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_PlayTeamJoinedSfx_Public_Void_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_UpdateLocalPlayerDisplay_Public_Void_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_UpdateGameModes_Public_Void_Il2CppReferenceArray_1_GameModeModel_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_UpdateReadyStatus_Public_Void_String_Boolean_Boolean_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_UpdateDailyRewardData_Public_Void_DailyReward_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_OnSoftCurrencyChanged_Public_Void_Int32_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_OnFractalsCurrencyChanged_Public_Void_Int32_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_OnCharTokenCurrencyChanged_Public_Void_Int32_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_OnAccountXpChanged_Public_Void_Int32_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_OnBattlePassXpChanged_Public_Void_Int32_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_OnDailyRewardProgressChanged_Public_Void_Int32_Int32_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_QueueCurrencyGoldObtain_Public_Void_Int32_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_QueueCurrencyFractalsObtain_Public_Void_Int32_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_QueueCurrencyCharTokensObtain_Public_Void_Int32_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_QueueAccountXpObtain_Public_Void_Int32_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_QueueBattlePassXpObtain_Public_Void_Int32_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_UpdateAccountPassData_Public_Void_LobbyDataModel_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_UpdateBattlePassData_Public_Void_Int32_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_UpdateGoldCurrency_Public_Void_Int32_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_UpdateFractalsCurrency_Public_Void_Int32_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_UpdateCharTokensCurrency_Public_Void_Int32_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_UpdateAccountPassXp_Public_Void_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_UpdateBapPassXp_Public_Void_BattlePassModel_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_PlayerAccountBannerUpdate_Public_Void_String_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_PlayerAccountLevelUpdate_Public_Void_String_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_UpdatePlayersOnline_Public_Void_Int32_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_ShowLobbyNotification_Public_Void_String_MessageType_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_SpawnLiveWinnerFeedEntry_Public_Void_String_Int32_DateTime_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_ShowLiveWinnerFeed_Public_Void_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_HideLiveWinnerFeed_Public_Void_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_UpdateEventChallengeLives_Public_Void_Int32_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_UpdateEventPanel_Public_Void_Int32_Int32_Int32_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_SetGoldCurrencyPanelUI_Public_Void_Int32_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_SetFractalsCurrencyPanelUI_Public_Void_Int32_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_SetCharTokenCurrencyPanelUI_Public_Void_Int32_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_SetCurrentBattlePassUI_Public_Void_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_SetCurrentBattlePassUIRemainingDays_Public_Void_String_Boolean_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_SetCurrentAccountPassUI_Public_Void_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_SetCurrentDailyRewardUI_Public_Void_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_ShowPopUpLinkCopied_Private_Void_Vector2_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_ShowPopUp_Public_Void_Vector2_String_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_PlayRedeemDeltaSequenceCoroutine_Public_Void_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_RedeemDeltaSequenceCoroutine_Private_IEnumerator_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_CheckForCustomLobby_Public_Void_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_OpenCustomLobbyWindow_Public_Void_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_CloseCustomLobbyWindow_Public_Void_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_GetCustomLobbyGameModeId_Public_Int32_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_GetCurrentSoftCurrency_Public_Int32_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_GetCurrentFractalsCurrency_Public_Int32_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_GetCurrentTokenCurrency_Public_Int32_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_GetCurrencyBalanceFromAssetId_Public_Int32_Int32_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_GetSelectedBannerAssetId_Public_Int32_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_IsPlayerBannerAssetIdEquiped_Public_Boolean_Int32_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_GetSelectedSkinAssetId_Public_Int32_Int32_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_IsSkinAssetIdEquipped_Public_Boolean_Int32_Int32_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_GetAccountLevelXpNeeded_Public_Int32_Int32_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_GetCurrentAccountLevelXpNeeded_Public_Int32_Int32_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_GetAccountXp_Public_Int32_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_GetPrevAccountXp_Public_Int32_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_GetAccountPrevLevel_Public_Int32_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_GetAccountLevel_Public_Int32_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_GetAccountMaxLevel_Public_Int32_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_GetBapPassXp_Public_Int32_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_GetBapPassPrevXp_Public_Int32_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_GetBapPassPreviousLevel_Public_Int32_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_GetBapPassLevel_Public_Int32_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_GetBapPassMaxLevel_Public_Int32_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_GetDailyProgress_Public_Int32_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_GetPrevDailyProgress_Public_Int32_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_GetDailyProgressMax_Public_Int32_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_GetAccountLevelFromXp_Public_Int32_Int32_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_IsUserGuest_Public_Boolean_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_PlayerOwnsAssetId_Public_Boolean_Int32_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_EnableInteractableContents_Public_Void_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_DisableInteractableContents_Public_Void_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_ClickNewReadyButton_Private_Void_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_ClickReadyButton_Private_Void_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_ClickUnreadyButton_Private_Void_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_ClickCancelButton_Private_Void_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_HidePlayButton_Public_Void_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_ShowPlayReadyButton_Public_Void_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_ShowPlayUnreadyButton_Public_Void_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_ShowPlayCancelButton_Public_Void_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_SetPlayButtonCooldown_Private_Void_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_OnPlayButtonCooldownEnded_Private_Void_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_ShowMaintenanceMessage_Private_Void_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_HideMaintenanceMessage_Private_Void_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_OnCommunityChallengeReadyButtonPressed_Private_Void_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_OpenChallengeEventWarningPopUp_Private_Void_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_CloseChallengeEventDisclaimerPopUp_Private_Void_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_OpenChallengeEventNoMoreLivesPopUp_Private_Void_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_CloseChallengeEventOutOfLivesPopUp_Private_Void_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_UpdateDailyRewardResfreshUI_Private_Void_TimeSpan_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_OnDailyRewardRefreshEnded_Private_Void_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_ShowBattlePass_Public_Void_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_HideBattlePass_Public_Void_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_CloseMatchStartPanel_Public_Void_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_AnimateCharacterSelect_Private_Void_Single_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_SetAndShowPlayerDisplay_Private_Void_PlayerDisplay_PlayerModel_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_UpdatePlayerDisplayLevel_Private_Void_PlayerDisplay_PlayerModel_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_UpdatePlayerDisplayBanner_Private_Void_PlayerDisplay_PlayerBanner_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_PlayPlayerCharJoinSfx_Public_Void_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_ShowPlayerReadys_Public_Void_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_HidePlayerReadys_Public_Void_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_SetPlayerCharDisplaySprite_Public_Void_Sprite_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_HideCharacterDisplay_Private_Void_PlayerDisplay_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_GetDefaultPlayerBanner_Public_PlayerBanner_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_GetPlayerBannerFromAcountId_Public_PlayerBanner_String_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_OpenPlayerOptionDropdown_Private_Void_RectTransform_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_OpenTeammateOptionDropdown_Public_Void_String_RectTransform_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_OnTeammateOptionKick_Private_Void_String_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_ShowInviteButton_Private_Void_InviteButton_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_HideInviteButton_Private_Void_InviteButton_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_ShowLoader_Private_Void_TeammateLoader_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_HideLoader_Private_Void_TeammateLoader_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_ShowGmPairingTeamSpinners_Public_Void_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_HideAllPairingTeamSpinners_Public_Void_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_HideAllInviteButton_Public_Void_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_OnInviteButtonPressed_Private_Void_InviteButton_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_OnFriendsButtonPressed_Private_Void_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_OnReferralCodeButtonPressed_Private_Void_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_SetInviteCodesRemainingUses_Public_Void_Int32_Int32_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_OpenOptionDropdown_Private_Void_Vector2_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_CloseOptionDropdown_Private_Void_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_ShowFriendsPanel_Public_Void_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_CloseFriendsPanel_Public_Void_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_FriendsPanelSetGuestMode_Private_Void_Boolean_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_OnAddFriendPopupButton_Private_Void_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_OpenAddFriendPopup_Private_Void_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_CloseAddFriendPopup_Private_Void_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_OnJoinLobbyPopupButton_Private_Void_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_OpenJoinLobbyPopup_Private_Void_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_CloseJoinLobbyPopup_Private_Void_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_SetButtonSelectedState_Private_Void_MultiGraphicButton_Boolean_Il2CppStructArray_1_Color_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_UpdateFriendsPreview_Private_Void_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_OpenFriendInviteNotification_Private_Void_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_CloseFriendInviteNotification_Public_Void_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_InitialiseFriendInviteNotification_Private_Void_String_String_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_OnFriendInviteLobbyNotificationJoin_Private_Void_String_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_SendFriendInvite_Public_Void_String_Int32_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_UpdateFriendLocalPlayerAvatar_Private_Void_Int32_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_SetHideLobbyCodeButton_Private_Void_Boolean_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_SetLobbyIdCode_Private_Void_String_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_SendFriendLobbyInvite_Private_Void_UILobbyFriendEntry_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_SendSteamFriendLobbyInvite_Private_Void_UILobbyFriendEntry_SteamFriend_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_InitializeFriendsPanel_Private_Void_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_ClearFriendsPanel_Public_Void_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_PopulateFriendsPanel_Private_Void_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_PopulateSteamFriendsPanel_Public_Void_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_GetFriendListEntries_Public_List_1_UILobbyFriendEntry_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_OnFriendEntrySelected_Private_Void_UILobbyFriendEntry_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_OpenOptionDropdown_Private_Void_String_RectTransform_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_RefreshFriendOptionsDropdown_Public_Void_String_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_OnFriendOptionJoinLobby_Private_Void_String_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_OnFriendOptionInviteToGame_Private_Void_String_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_OnFriendOptionDirectMessage_Private_Void_String_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_OnFriendOptionUnfriend_Private_Void_String_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_InitializeRequestsPanel_Private_Void_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_UpdateFriendRequestsNotification_Private_Void_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_UpdateFriendEntryHolders_Private_Void_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_OnSendFriendLobbyInvite_Private_Void_String_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_OnSendFriendRequestSuccess_Public_Void_String_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_OnSendFriendRequestFail_Public_Void_String_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_OnFriendRequestAcceptSuccess_Public_Void_String_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_OnFriendRequestDeclineSuccess_Public_Void_String_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_TryRemoveFriendRequest_Private_Void_String_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_GetUsernameId_Public_String_String_Int32_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_GetFriendAvatar_Public_Texture2D_Int32_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_GetFriendAvatarOffset_Public_Vector2_Int32_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_GetFriendAvatarSize_Public_Vector2_Int32_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_PlayerIsFriend_Public_Boolean_String_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_ShowGameModeButton_Public_Void_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_HideGameModeButton_Public_Void_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_SetSelectedGameMode_Public_Void_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_SetGameModeSelectButton_Private_Void_Int32_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_GameModeSelectButtonEventEnable_Public_Void_UILobbyGameModeButton_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_GameModeSelectButtonEventDisable_Public_Void_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_SetGameModeSelectLoader_Public_Void_Boolean_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_ShowQueuePanel_Public_Void_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_HideQueuePanel_Public_Void_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_SetQueuePanelPlayerCount_Public_Void_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_SetQueuePanelElapsedTime_Public_Void_Double_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_SetQueueStateInQueue_Public_Void_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_SetQueueStateQueueMatched_Public_Void_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_SetQueueStateInQueueNoCounts_Public_Void_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_SetGameModePanelName_Public_Void_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_JoinLobbyVoiceChannel_Public_Void_0;

	private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

	private static readonly System.IntPtr NativeMethodInfoPtr__Localise_b__193_0_Private_Boolean_GameModeConfiguration_0;

	private static readonly System.IntPtr NativeMethodInfoPtr__OpenPlayerOptionDropdown_b__363_0_Private_Void_0;

	private static readonly System.IntPtr NativeMethodInfoPtr__ShowGmPairingTeamSpinners_b__370_0_Private_Boolean_GameModeConfiguration_0;

	private static readonly System.IntPtr NativeMethodInfoPtr__SetGameModePanelName_b__440_0_Private_Boolean_GameModeConfiguration_0;

	public unsafe CanvasGroup _canvasGroup
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__canvasGroup);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<CanvasGroup>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__canvasGroup)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)canvasGroup));
		}
	}

	public unsafe Selectable _canvasGroupSelectable
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__canvasGroupSelectable);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Selectable>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__canvasGroupSelectable)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)selectable));
		}
	}

	public unsafe UIPosLerpFade _uiLerpFade
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__uiLerpFade);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<UIPosLerpFade>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__uiLerpFade)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)uIPosLerpFade));
		}
	}

	public unsafe UIAlphaFade _uiAlphaFade
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__uiAlphaFade);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<UIAlphaFade>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__uiAlphaFade)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)uIAlphaFade));
		}
	}

	public unsafe UIAlphaFade _backgroundUIFade
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__backgroundUIFade);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<UIAlphaFade>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__backgroundUIFade)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)uIAlphaFade));
		}
	}

	public unsafe CanvasGroup contentsCanvasGroup
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_contentsCanvasGroup);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<CanvasGroup>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_contentsCanvasGroup)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)canvasGroup));
		}
	}

	public unsafe PlayerDisplay _playerDisplay
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__playerDisplay);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<PlayerDisplay>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__playerDisplay)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)playerDisplay));
		}
	}

	public unsafe TeammateDisplay _teammate1Display
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__teammate1Display);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<TeammateDisplay>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__teammate1Display)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)teammateDisplay));
		}
	}

	public unsafe TeammateDisplay _teammate2Display
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__teammate2Display);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<TeammateDisplay>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__teammate2Display)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)teammateDisplay));
		}
	}

	public unsafe GameObject _playContainer
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__playContainer);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<GameObject>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__playContainer)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)gameObject));
		}
	}

	public unsafe View_Lobby_ReadyButton _newReadyButton
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__newReadyButton);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<View_Lobby_ReadyButton>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__newReadyButton)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)view_Lobby_ReadyButton));
		}
	}

	public unsafe ReadyButton _readyButton
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__readyButton);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<ReadyButton>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__readyButton)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)readyButton));
		}
	}

	public unsafe UnreadyButton _unreadyButton
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__unreadyButton);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<UnreadyButton>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__unreadyButton)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)unreadyButton));
		}
	}

	public unsafe CancelButton _cancelButton
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__cancelButton);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<CancelButton>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__cancelButton)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)cancelButton));
		}
	}

	public unsafe TMP_Text playMaintenanceMessageText
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_playMaintenanceMessageText);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<TMP_Text>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_playMaintenanceMessageText)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)tMP_Text));
		}
	}

	public unsafe TMP_Text betaServiceMessageText
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_betaServiceMessageText);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<TMP_Text>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_betaServiceMessageText)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)tMP_Text));
		}
	}

	public unsafe GameQueuePanel _gameQueuePanel
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__gameQueuePanel);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<GameQueuePanel>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__gameQueuePanel)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)gameQueuePanel));
		}
	}

	public unsafe GameModePlayButton _gameModePlayButton
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__gameModePlayButton);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<GameModePlayButton>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__gameModePlayButton)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)gameModePlayButton));
		}
	}

	public unsafe CustomTMP_Dropdown _regionDropdown
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__regionDropdown);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<CustomTMP_Dropdown>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__regionDropdown)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)customTMP_Dropdown));
		}
	}

	public unsafe MatchStartPanel _matchStartPanel
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__matchStartPanel);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<MatchStartPanel>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__matchStartPanel)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)matchStartPanel));
		}
	}

	public unsafe Transform _chatParent
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__chatParent);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Transform>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__chatParent)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)transform));
		}
	}

	public unsafe DailyReward _dailyReward
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__dailyReward);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<DailyReward>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__dailyReward)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)dailyReward));
		}
	}

	public unsafe Button profileButton
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_profileButton);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Button>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_profileButton)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)button));
		}
	}

	public unsafe BattlePassPanel _battlePassPanel
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__battlePassPanel);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<BattlePassPanel>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__battlePassPanel)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)battlePassPanel));
		}
	}

	public unsafe UILobbyPopUpElement _battlePassXpPopUp
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__battlePassXpPopUp);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<UILobbyPopUpElement>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__battlePassXpPopUp)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)uILobbyPopUpElement));
		}
	}

	public unsafe PlayersOnline _playersOnline
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__playersOnline);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<PlayersOnline>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__playersOnline)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)playersOnline));
		}
	}

	public unsafe LiveWinnerFeed _liveWinnerFeedPanel
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__liveWinnerFeedPanel);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<LiveWinnerFeed>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__liveWinnerFeedPanel)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)liveWinnerFeed));
		}
	}

	public unsafe NotificationsPanel _notificationsPanel
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__notificationsPanel);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<NotificationsPanel>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__notificationsPanel)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)notificationsPanel));
		}
	}

	public unsafe UILobbyPopUpElement _lobbyPopUp
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__lobbyPopUp);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<UILobbyPopUpElement>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__lobbyPopUp)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)uILobbyPopUpElement));
		}
	}

	public unsafe UILobbyOptionDropdown _lobbyOptionDropdown
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__lobbyOptionDropdown);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<UILobbyOptionDropdown>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__lobbyOptionDropdown)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)uILobbyOptionDropdown));
		}
	}

	public unsafe FriendsPanel _friendsPanel
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__friendsPanel);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<FriendsPanel>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__friendsPanel)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)friendsPanel));
		}
	}

	public unsafe FriendInviteLobbyPopup _friendInviteLobbyPopup
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__friendInviteLobbyPopup);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<FriendInviteLobbyPopup>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__friendInviteLobbyPopup)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)friendInviteLobbyPopup));
		}
	}

	public unsafe Button _friendsButton
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__friendsButton);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Button>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__friendsButton)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)button));
		}
	}

	public unsafe GameObject _friendsButtonNotification
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__friendsButtonNotification);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<GameObject>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__friendsButtonNotification)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)gameObject));
		}
	}

	public unsafe TMP_Text _friendsButtonNotificationText
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__friendsButtonNotificationText);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<TMP_Text>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__friendsButtonNotificationText)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)tMP_Text));
		}
	}

	public unsafe FriendsPreview _friendsPreview
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__friendsPreview);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<FriendsPreview>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__friendsPreview)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)friendsPreview));
		}
	}

	public unsafe CurrencyPanel _goldCurrencyPanel
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__goldCurrencyPanel);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<CurrencyPanel>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__goldCurrencyPanel)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)currencyPanel));
		}
	}

	public unsafe CurrencyPanel _fractalCurrencyPanel
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__fractalCurrencyPanel);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<CurrencyPanel>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__fractalCurrencyPanel)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)currencyPanel));
		}
	}

	public unsafe Button _fractalPurchaseButton
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__fractalPurchaseButton);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Button>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__fractalPurchaseButton)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)button));
		}
	}

	public unsafe GameObject _fractalCurrencyPanelRoot
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__fractalCurrencyPanelRoot);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<GameObject>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__fractalCurrencyPanelRoot)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)gameObject));
		}
	}

	public unsafe UILobbyPopUpElement _softCurrencyPopUp
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__softCurrencyPopUp);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<UILobbyPopUpElement>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__softCurrencyPopUp)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)uILobbyPopUpElement));
		}
	}

	public unsafe UILobbyPopUpElement _fractalsCurrencyPopUp
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__fractalsCurrencyPopUp);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<UILobbyPopUpElement>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__fractalsCurrencyPopUp)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)uILobbyPopUpElement));
		}
	}

	public unsafe UILobbyPopUpElement _charTokenCurrencyPopUp
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__charTokenCurrencyPopUp);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<UILobbyPopUpElement>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__charTokenCurrencyPopUp)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)uILobbyPopUpElement));
		}
	}

	public unsafe UILobbyPopUpElement _profileXpPopUp
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__profileXpPopUp);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<UILobbyPopUpElement>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__profileXpPopUp)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)uILobbyPopUpElement));
		}
	}

	public unsafe ReferralCode _referralCode
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__referralCode);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<ReferralCode>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__referralCode)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)referralCode));
		}
	}

	public unsafe NewsPreviewButton newsPreviewButton
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_newsPreviewButton);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<NewsPreviewButton>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_newsPreviewButton)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)newsPreviewButton));
		}
	}

	public unsafe OpenBetaChallenge openBetaChallenge
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_openBetaChallenge);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<OpenBetaChallenge>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_openBetaChallenge)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)openBetaChallenge));
		}
	}

	public unsafe UIAlphaFade _customGameBackground
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__customGameBackground);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<UIAlphaFade>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__customGameBackground)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)uIAlphaFade));
		}
	}

	public unsafe List<GameObject> _elementsToDisableOnCustomGame
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__elementsToDisableOnCustomGame);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<List<GameObject>>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__elementsToDisableOnCustomGame)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)list));
		}
	}

	public unsafe Dictionary<GameObject, bool> _customGameElementActiveCache
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__customGameElementActiveCache);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Dictionary<GameObject, bool>>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__customGameElementActiveCache)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)dictionary));
		}
	}

	public unsafe View_Lobby_News NewsPanel
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_NewsPanel);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<View_Lobby_News>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_NewsPanel)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)view_Lobby_News));
		}
	}

	public unsafe View_Lobby_Developer DeveloperPanel
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_DeveloperPanel);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<View_Lobby_Developer>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_DeveloperPanel)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)view_Lobby_Developer));
		}
	}

	public unsafe View_Lobby_OpenLobbyToggle LobbyOpenTogglePanel
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_LobbyOpenTogglePanel);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<View_Lobby_OpenLobbyToggle>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_LobbyOpenTogglePanel)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)view_Lobby_OpenLobbyToggle));
		}
	}

	public unsafe View_Lobby_CustomGame CustomGameLobby
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_CustomGameLobby);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<View_Lobby_CustomGame>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_CustomGameLobby)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)view_Lobby_CustomGame));
		}
	}

	public unsafe View_Lobby_InviteCodePage InviteCodePage
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_InviteCodePage);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<View_Lobby_InviteCodePage>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_InviteCodePage)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)view_Lobby_InviteCodePage));
		}
	}

	public unsafe UILobbyGameModePage gameModePage
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_gameModePage);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<UILobbyGameModePage>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_gameModePage)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)uILobbyGameModePage));
		}
	}

	public unsafe Configuration _configuration
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__configuration);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Configuration>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__configuration)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)configuration));
		}
	}

	public unsafe Translator _translator
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__translator);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Translator>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__translator)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)translator));
		}
	}

	public unsafe Actions _actions
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__actions);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Actions>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__actions)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)actions));
		}
	}

	public unsafe LobbyDataModel _lobbyDataModel
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__lobbyDataModel);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<LobbyDataModel>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__lobbyDataModel)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)lobbyDataModel));
		}
	}

	public unsafe Il2CppReferenceArray<TeammateDisplay> _teammateDisplays
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__teammateDisplays);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppReferenceArray<TeammateDisplay>>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__teammateDisplays)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)val));
		}
	}

	public unsafe UILobbyCharacterSelectIcon.Factory _characterSelectIconFactory
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__characterSelectIconFactory);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<UILobbyCharacterSelectIcon.Factory>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__characterSelectIconFactory)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)factory));
		}
	}

	public unsafe Il2CppReferenceArray<UILobbyCharacterSelectIcon> matchStartCharSelectButtons
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_matchStartCharSelectButtons);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppReferenceArray<UILobbyCharacterSelectIcon>>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_matchStartCharSelectButtons)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)val));
		}
	}

	public unsafe UILobbyCharacterSelectIcon matchStartSelectedCharacterIcon
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_matchStartSelectedCharacterIcon);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<UILobbyCharacterSelectIcon>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_matchStartSelectedCharacterIcon)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)uILobbyCharacterSelectIcon));
		}
	}

	public unsafe int matchStartSelectedCharIndex
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_matchStartSelectedCharIndex);
			return *(int*)num;
		}
		set
		{
			*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_matchStartSelectedCharIndex)) = num;
		}
	}

	public unsafe bool matchStartAnimateCharSelect
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_matchStartAnimateCharSelect);
			return *(bool*)num;
		}
		set
		{
			*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_matchStartAnimateCharSelect)) = flag;
		}
	}

	public unsafe float matchStartAnimTime
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_matchStartAnimTime);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_matchStartAnimTime)) = num;
		}
	}

	public unsafe UILobbyNotificationEntry.Pool _notificationEntryPool
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__notificationEntryPool);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<UILobbyNotificationEntry.Pool>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__notificationEntryPool)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)pool));
		}
	}

	public unsafe UILobbyLiveWinnerFeedEntry.Pool _liveWinnerFeedEntryPool
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__liveWinnerFeedEntryPool);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<UILobbyLiveWinnerFeedEntry.Pool>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__liveWinnerFeedEntryPool)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)pool));
		}
	}

	public unsafe Il2CppReferenceArray<UILobbyTabButton> friendsPanelTabButtons
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_friendsPanelTabButtons);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppReferenceArray<UILobbyTabButton>>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_friendsPanelTabButtons)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)val));
		}
	}

	public unsafe UILobbyFriendEntry.Pool _friendEntryPool
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__friendEntryPool);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<UILobbyFriendEntry.Pool>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__friendEntryPool)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)pool));
		}
	}

	public unsafe UILobbyFriendRequestEntry.Pool _friendRequestEntryPool
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__friendRequestEntryPool);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<UILobbyFriendRequestEntry.Pool>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__friendRequestEntryPool)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)pool));
		}
	}

	public unsafe List<UILobbyFriendEntry> activeFriendEntries
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_activeFriendEntries);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<List<UILobbyFriendEntry>>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_activeFriendEntries)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)list));
		}
	}

	public unsafe List<UILobbyFriendRequestEntry> activeFriendRequestEntries
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_activeFriendRequestEntries);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<List<UILobbyFriendRequestEntry>>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_activeFriendRequestEntries)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)list));
		}
	}

	public unsafe Il2CppSystem.Action friendInviteLobbyAction
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_friendInviteLobbyAction);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppSystem.Action>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_friendInviteLobbyAction)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)action));
		}
	}

	public unsafe float playButtonCooldown
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_playButtonCooldown);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_playButtonCooldown)) = num;
		}
	}

	public unsafe Il2CppReferenceArray<UIAlphaFade> newsPreviewElements
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_newsPreviewElements);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppReferenceArray<UIAlphaFade>>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_newsPreviewElements)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)val));
		}
	}

	public unsafe Il2CppReferenceArray<Image> newsPreviewIcons
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_newsPreviewIcons);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppReferenceArray<Image>>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_newsPreviewIcons)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)val));
		}
	}

	public unsafe bool newsPreviewCycleAnimate
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_newsPreviewCycleAnimate);
			return *(bool*)num;
		}
		set
		{
			*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_newsPreviewCycleAnimate)) = flag;
		}
	}

	public unsafe float latestNewsButtonCycleTimer
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_latestNewsButtonCycleTimer);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_latestNewsButtonCycleTimer)) = num;
		}
	}

	public unsafe int latestNewsButtonCycleId
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_latestNewsButtonCycleId);
			return *(int*)num;
		}
		set
		{
			*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_latestNewsButtonCycleId)) = num;
		}
	}

	public unsafe Il2CppSystem.DateTime dailyRewardRefreshDate
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_dailyRewardRefreshDate);
			return *(Il2CppSystem.DateTime*)num;
		}
		set
		{
			*(Il2CppSystem.DateTime*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_dailyRewardRefreshDate)) = dateTime;
		}
	}

	public unsafe bool dailyRewardCountdownEnabled
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_dailyRewardCountdownEnabled);
			return *(bool*)num;
		}
		set
		{
			*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_dailyRewardCountdownEnabled)) = flag;
		}
	}

	public unsafe float dailyRewardCountdownTimer
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_dailyRewardCountdownTimer);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_dailyRewardCountdownTimer)) = num;
		}
	}

	public unsafe bool animateDailyRewardProgress
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_animateDailyRewardProgress);
			return *(bool*)num;
		}
		set
		{
			*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_animateDailyRewardProgress)) = flag;
		}
	}

	public unsafe float dailyRewardAnimTime
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_dailyRewardAnimTime);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_dailyRewardAnimTime)) = num;
		}
	}

	public unsafe float lerpedDailyRewardProgress
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_lerpedDailyRewardProgress);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_lerpedDailyRewardProgress)) = num;
		}
	}

	public unsafe int currentDailyRewardProgress
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_currentDailyRewardProgress);
			return *(int*)num;
		}
		set
		{
			*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_currentDailyRewardProgress)) = num;
		}
	}

	public unsafe int prevCurrentDailyRewardProgress
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_prevCurrentDailyRewardProgress);
			return *(int*)num;
		}
		set
		{
			*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_prevCurrentDailyRewardProgress)) = num;
		}
	}

	public unsafe int dailyRewardProgressMax
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_dailyRewardProgressMax);
			return *(int*)num;
		}
		set
		{
			*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_dailyRewardProgressMax)) = num;
		}
	}

	public unsafe Coroutine redeemCoroutine
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_redeemCoroutine);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Coroutine>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_redeemCoroutine)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)coroutine));
		}
	}

	public unsafe int currentBpLevel
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_currentBpLevel);
			return *(int*)num;
		}
		set
		{
			*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_currentBpLevel)) = num;
		}
	}

	public unsafe int currentBpXp
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_currentBpXp);
			return *(int*)num;
		}
		set
		{
			*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_currentBpXp)) = num;
		}
	}

	public unsafe int currentBpXpNeeded
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_currentBpXpNeeded);
			return *(int*)num;
		}
		set
		{
			*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_currentBpXpNeeded)) = num;
		}
	}

	public unsafe int prevCurrentBpLevel
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_prevCurrentBpLevel);
			return *(int*)num;
		}
		set
		{
			*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_prevCurrentBpLevel)) = num;
		}
	}

	public unsafe int prevCurrentBpXp
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_prevCurrentBpXp);
			return *(int*)num;
		}
		set
		{
			*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_prevCurrentBpXp)) = num;
		}
	}

	public unsafe int maxBpLevel
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_maxBpLevel);
			return *(int*)num;
		}
		set
		{
			*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_maxBpLevel)) = num;
		}
	}

	public unsafe Il2CppSystem.DateTime bpEndDate
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_bpEndDate);
			return *(Il2CppSystem.DateTime*)num;
		}
		set
		{
			*(Il2CppSystem.DateTime*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_bpEndDate)) = dateTime;
		}
	}

	public unsafe bool _animateBpXpBar
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__animateBpXpBar);
			return *(bool*)num;
		}
		set
		{
			*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__animateBpXpBar)) = flag;
		}
	}

	public unsafe float _animateBpXpBarTime
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__animateBpXpBarTime);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__animateBpXpBarTime)) = num;
		}
	}

	public unsafe int _animCurrentBpLevel
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__animCurrentBpLevel);
			return *(int*)num;
		}
		set
		{
			*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__animCurrentBpLevel)) = num;
		}
	}

	public unsafe float _animCurrentBpXp
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__animCurrentBpXp);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__animCurrentBpXp)) = num;
		}
	}

	public unsafe float _animCurrentBpXpNeeded
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__animCurrentBpXpNeeded);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__animCurrentBpXpNeeded)) = num;
		}
	}

	public unsafe float _lerpedCurrentBpXp
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__lerpedCurrentBpXp);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__lerpedCurrentBpXp)) = num;
		}
	}

	public unsafe int bpXpObtainedAmount
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_bpXpObtainedAmount);
			return *(int*)num;
		}
		set
		{
			*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_bpXpObtainedAmount)) = num;
		}
	}

	public unsafe bool queueBpXpObtain
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_queueBpXpObtain);
			return *(bool*)num;
		}
		set
		{
			*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_queueBpXpObtain)) = flag;
		}
	}

	public unsafe bool _animateBpXpBarLevelUp
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__animateBpXpBarLevelUp);
			return *(bool*)num;
		}
		set
		{
			*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__animateBpXpBarLevelUp)) = flag;
		}
	}

	public unsafe float _animateBpXpBarLevelUpTime
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__animateBpXpBarLevelUpTime);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__animateBpXpBarLevelUpTime)) = num;
		}
	}

	public unsafe int currentAccountLevel
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_currentAccountLevel);
			return *(int*)num;
		}
		set
		{
			*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_currentAccountLevel)) = num;
		}
	}

	public unsafe int currentAccountXp
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_currentAccountXp);
			return *(int*)num;
		}
		set
		{
			*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_currentAccountXp)) = num;
		}
	}

	public unsafe int currentAccountXpNeeded
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_currentAccountXpNeeded);
			return *(int*)num;
		}
		set
		{
			*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_currentAccountXpNeeded)) = num;
		}
	}

	public unsafe int prevCurrentAccountLevel
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_prevCurrentAccountLevel);
			return *(int*)num;
		}
		set
		{
			*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_prevCurrentAccountLevel)) = num;
		}
	}

	public unsafe int prevCurrentAccountXp
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_prevCurrentAccountXp);
			return *(int*)num;
		}
		set
		{
			*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_prevCurrentAccountXp)) = num;
		}
	}

	public unsafe int maxAccountLevel
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_maxAccountLevel);
			return *(int*)num;
		}
		set
		{
			*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_maxAccountLevel)) = num;
		}
	}

	public unsafe bool _animateAccountXpBar
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__animateAccountXpBar);
			return *(bool*)num;
		}
		set
		{
			*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__animateAccountXpBar)) = flag;
		}
	}

	public unsafe float _animateAccountXpBarTime
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__animateAccountXpBarTime);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__animateAccountXpBarTime)) = num;
		}
	}

	public unsafe int _animCurrentAccountLevel
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__animCurrentAccountLevel);
			return *(int*)num;
		}
		set
		{
			*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__animCurrentAccountLevel)) = num;
		}
	}

	public unsafe float _animCurrentAccountXp
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__animCurrentAccountXp);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__animCurrentAccountXp)) = num;
		}
	}

	public unsafe float _animCurrentAccountXpNeeded
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__animCurrentAccountXpNeeded);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__animCurrentAccountXpNeeded)) = num;
		}
	}

	public unsafe float _lerpedCurrentAccountXp
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__lerpedCurrentAccountXp);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__lerpedCurrentAccountXp)) = num;
		}
	}

	public unsafe int accountXpObtainedAmount
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_accountXpObtainedAmount);
			return *(int*)num;
		}
		set
		{
			*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_accountXpObtainedAmount)) = num;
		}
	}

	public unsafe bool queueAccountXpObtain
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_queueAccountXpObtain);
			return *(bool*)num;
		}
		set
		{
			*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_queueAccountXpObtain)) = flag;
		}
	}

	public unsafe bool _animateAccountXpBarLevelUp
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__animateAccountXpBarLevelUp);
			return *(bool*)num;
		}
		set
		{
			*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__animateAccountXpBarLevelUp)) = flag;
		}
	}

	public unsafe float _animateAccountXpBarLevelUpTime
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__animateAccountXpBarLevelUpTime);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__animateAccountXpBarLevelUpTime)) = num;
		}
	}

	public unsafe int softCurrency
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_softCurrency);
			return *(int*)num;
		}
		set
		{
			*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_softCurrency)) = num;
		}
	}

	public unsafe bool animateSoftCurrency
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_animateSoftCurrency);
			return *(bool*)num;
		}
		set
		{
			*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_animateSoftCurrency)) = flag;
		}
	}

	public unsafe float softCurrencyAnimTime
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_softCurrencyAnimTime);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_softCurrencyAnimTime)) = num;
		}
	}

	public unsafe int lerpedSoftCurrency
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_lerpedSoftCurrency);
			return *(int*)num;
		}
		set
		{
			*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_lerpedSoftCurrency)) = num;
		}
	}

	public unsafe bool queueGoldObtain
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_queueGoldObtain);
			return *(bool*)num;
		}
		set
		{
			*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_queueGoldObtain)) = flag;
		}
	}

	public unsafe int goldObtainedAmount
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_goldObtainedAmount);
			return *(int*)num;
		}
		set
		{
			*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_goldObtainedAmount)) = num;
		}
	}

	public unsafe int fractalsCurrency
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_fractalsCurrency);
			return *(int*)num;
		}
		set
		{
			*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_fractalsCurrency)) = num;
		}
	}

	public unsafe bool animateFractalsCurrency
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_animateFractalsCurrency);
			return *(bool*)num;
		}
		set
		{
			*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_animateFractalsCurrency)) = flag;
		}
	}

	public unsafe float fractalsCurrencyAnimTime
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_fractalsCurrencyAnimTime);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_fractalsCurrencyAnimTime)) = num;
		}
	}

	public unsafe int lerpedFractalsCurrency
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_lerpedFractalsCurrency);
			return *(int*)num;
		}
		set
		{
			*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_lerpedFractalsCurrency)) = num;
		}
	}

	public unsafe bool queueFractalsObtain
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_queueFractalsObtain);
			return *(bool*)num;
		}
		set
		{
			*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_queueFractalsObtain)) = flag;
		}
	}

	public unsafe int fractalsObtainedAmount
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_fractalsObtainedAmount);
			return *(int*)num;
		}
		set
		{
			*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_fractalsObtainedAmount)) = num;
		}
	}

	public unsafe int charTokenCurrency
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_charTokenCurrency);
			return *(int*)num;
		}
		set
		{
			*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_charTokenCurrency)) = num;
		}
	}

	public unsafe bool animateCharTokenCurrency
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_animateCharTokenCurrency);
			return *(bool*)num;
		}
		set
		{
			*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_animateCharTokenCurrency)) = flag;
		}
	}

	public unsafe float charTokenCurrencyAnimTime
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_charTokenCurrencyAnimTime);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_charTokenCurrencyAnimTime)) = num;
		}
	}

	public unsafe int lerpedCharTokenCurrency
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_lerpedCharTokenCurrency);
			return *(int*)num;
		}
		set
		{
			*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_lerpedCharTokenCurrency)) = num;
		}
	}

	public unsafe bool queueCharTokenObtain
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_queueCharTokenObtain);
			return *(bool*)num;
		}
		set
		{
			*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_queueCharTokenObtain)) = flag;
		}
	}

	public unsafe int charTokenObtainedAmount
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_charTokenObtainedAmount);
			return *(int*)num;
		}
		set
		{
			*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_charTokenObtainedAmount)) = num;
		}
	}

	public unsafe string _readyStatusString
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__readyStatusString);
			return IL2CPP.Il2CppStringToManaged(*(System.IntPtr*)num);
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__readyStatusString)), IL2CPP.ManagedStringToIl2Cpp(text));
		}
	}

	public unsafe string _notReadyStatusString
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__notReadyStatusString);
			return IL2CPP.Il2CppStringToManaged(*(System.IntPtr*)num);
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__notReadyStatusString)), IL2CPP.ManagedStringToIl2Cpp(text));
		}
	}

	public unsafe string _inQueueStatusString
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__inQueueStatusString);
			return IL2CPP.Il2CppStringToManaged(*(System.IntPtr*)num);
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__inQueueStatusString)), IL2CPP.ManagedStringToIl2Cpp(text));
		}
	}

	public unsafe string _queueFindingPlayersStr
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__queueFindingPlayersStr);
			return IL2CPP.Il2CppStringToManaged(*(System.IntPtr*)num);
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__queueFindingPlayersStr)), IL2CPP.ManagedStringToIl2Cpp(text));
		}
	}

	public unsafe string _queueGameStartingStr
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__queueGameStartingStr);
			return IL2CPP.Il2CppStringToManaged(*(System.IntPtr*)num);
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__queueGameStartingStr)), IL2CPP.ManagedStringToIl2Cpp(text));
		}
	}

	public unsafe string _playersOnlineString
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__playersOnlineString);
			return IL2CPP.Il2CppStringToManaged(*(System.IntPtr*)num);
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__playersOnlineString)), IL2CPP.ManagedStringToIl2Cpp(text));
		}
	}

	public unsafe string _linkCopiedPopUpString
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__linkCopiedPopUpString);
			return IL2CPP.Il2CppStringToManaged(*(System.IntPtr*)num);
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__linkCopiedPopUpString)), IL2CPP.ManagedStringToIl2Cpp(text));
		}
	}

	public unsafe string usernameIdCopiedString
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_usernameIdCopiedString);
			return IL2CPP.Il2CppStringToManaged(*(System.IntPtr*)num);
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_usernameIdCopiedString)), IL2CPP.ManagedStringToIl2Cpp(text));
		}
	}

	public unsafe string maxLevelStr
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_maxLevelStr);
			return IL2CPP.Il2CppStringToManaged(*(System.IntPtr*)num);
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_maxLevelStr)), IL2CPP.ManagedStringToIl2Cpp(text));
		}
	}

	public unsafe string dailyRewardRefreshesInStr
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_dailyRewardRefreshesInStr);
			return IL2CPP.Il2CppStringToManaged(*(System.IntPtr*)num);
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_dailyRewardRefreshesInStr)), IL2CPP.ManagedStringToIl2Cpp(text));
		}
	}

	public unsafe string gameModeEventStartsInStr
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_gameModeEventStartsInStr);
			return IL2CPP.Il2CppStringToManaged(*(System.IntPtr*)num);
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_gameModeEventStartsInStr)), IL2CPP.ManagedStringToIl2Cpp(text));
		}
	}

	public unsafe string inviteLobbyNotifStr
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_inviteLobbyNotifStr);
			return IL2CPP.Il2CppStringToManaged(*(System.IntPtr*)num);
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_inviteLobbyNotifStr)), IL2CPP.ManagedStringToIl2Cpp(text));
		}
	}

	public unsafe string onlineStr
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_onlineStr);
			return IL2CPP.Il2CppStringToManaged(*(System.IntPtr*)num);
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_onlineStr)), IL2CPP.ManagedStringToIl2Cpp(text));
		}
	}

	public unsafe string offlineStr
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_offlineStr);
			return IL2CPP.Il2CppStringToManaged(*(System.IntPtr*)num);
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_offlineStr)), IL2CPP.ManagedStringToIl2Cpp(text));
		}
	}

	public unsafe string steamOnlineStr
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_steamOnlineStr);
			return IL2CPP.Il2CppStringToManaged(*(System.IntPtr*)num);
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_steamOnlineStr)), IL2CPP.ManagedStringToIl2Cpp(text));
		}
	}

	public unsafe string steamOfflineStr
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_steamOfflineStr);
			return IL2CPP.Il2CppStringToManaged(*(System.IntPtr*)num);
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_steamOfflineStr)), IL2CPP.ManagedStringToIl2Cpp(text));
		}
	}

	public unsafe string sentAGameInviteToStr
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_sentAGameInviteToStr);
			return IL2CPP.Il2CppStringToManaged(*(System.IntPtr*)num);
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_sentAGameInviteToStr)), IL2CPP.ManagedStringToIl2Cpp(text));
		}
	}

	public unsafe string friendInviteSentToStr
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_friendInviteSentToStr);
			return IL2CPP.Il2CppStringToManaged(*(System.IntPtr*)num);
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_friendInviteSentToStr)), IL2CPP.ManagedStringToIl2Cpp(text));
		}
	}

	public unsafe string friendInviteSentErrorStr
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_friendInviteSentErrorStr);
			return IL2CPP.Il2CppStringToManaged(*(System.IntPtr*)num);
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_friendInviteSentErrorStr)), IL2CPP.ManagedStringToIl2Cpp(text));
		}
	}

	public unsafe string friendRequestAcceptedStr
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_friendRequestAcceptedStr);
			return IL2CPP.Il2CppStringToManaged(*(System.IntPtr*)num);
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_friendRequestAcceptedStr)), IL2CPP.ManagedStringToIl2Cpp(text));
		}
	}

	public unsafe string joinLobbyStr
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_joinLobbyStr);
			return IL2CPP.Il2CppStringToManaged(*(System.IntPtr*)num);
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_joinLobbyStr)), IL2CPP.ManagedStringToIl2Cpp(text));
		}
	}

	public unsafe string leaveLobbyStr
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_leaveLobbyStr);
			return IL2CPP.Il2CppStringToManaged(*(System.IntPtr*)num);
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_leaveLobbyStr)), IL2CPP.ManagedStringToIl2Cpp(text));
		}
	}

	public unsafe string inviteToGameStr
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_inviteToGameStr);
			return IL2CPP.Il2CppStringToManaged(*(System.IntPtr*)num);
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_inviteToGameStr)), IL2CPP.ManagedStringToIl2Cpp(text));
		}
	}

	public unsafe string messageFriendStr
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_messageFriendStr);
			return IL2CPP.Il2CppStringToManaged(*(System.IntPtr*)num);
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_messageFriendStr)), IL2CPP.ManagedStringToIl2Cpp(text));
		}
	}

	public unsafe string playerViewProfileStr
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_playerViewProfileStr);
			return IL2CPP.Il2CppStringToManaged(*(System.IntPtr*)num);
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_playerViewProfileStr)), IL2CPP.ManagedStringToIl2Cpp(text));
		}
	}

	public unsafe string friendUnfriendStr
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_friendUnfriendStr);
			return IL2CPP.Il2CppStringToManaged(*(System.IntPtr*)num);
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_friendUnfriendStr)), IL2CPP.ManagedStringToIl2Cpp(text));
		}
	}

	public unsafe string sendFriendRequestStr
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_sendFriendRequestStr);
			return IL2CPP.Il2CppStringToManaged(*(System.IntPtr*)num);
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_sendFriendRequestStr)), IL2CPP.ManagedStringToIl2Cpp(text));
		}
	}

	public unsafe string playerLobbyKickStr
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_playerLobbyKickStr);
			return IL2CPP.Il2CppStringToManaged(*(System.IntPtr*)num);
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_playerLobbyKickStr)), IL2CPP.ManagedStringToIl2Cpp(text));
		}
	}

	public unsafe string challengeXSignUpsOutOfYStr
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_challengeXSignUpsOutOfYStr);
			return IL2CPP.Il2CppStringToManaged(*(System.IntPtr*)num);
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_challengeXSignUpsOutOfYStr)), IL2CPP.ManagedStringToIl2Cpp(text));
		}
	}

	public unsafe bool eventCountdownGmEnabled
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_eventCountdownGmEnabled);
			return *(bool*)num;
		}
		set
		{
			*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_eventCountdownGmEnabled)) = flag;
		}
	}

	public unsafe float eventCountdownGmTimer
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_eventCountdownGmTimer);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_eventCountdownGmTimer)) = num;
		}
	}

	public unsafe UILobbyGameModeButton eventCountdownGmButton
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_eventCountdownGmButton);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<UILobbyGameModeButton>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_eventCountdownGmButton)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)uILobbyGameModeButton));
		}
	}

	public unsafe bool hideLobbyCode
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_hideLobbyCode);
			return *(bool*)num;
		}
		set
		{
			*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_hideLobbyCode)) = flag;
		}
	}

	public unsafe static string FirstTimeTutorialPageKey
	{
		get
		{
			Unsafe.SkipInit(out System.IntPtr intPtr);
			IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr_FirstTimeTutorialPageKey, (void*)(&intPtr));
			return IL2CPP.Il2CppStringToManaged(intPtr);
		}
		set
		{
			IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr_FirstTimeTutorialPageKey, (void*)IL2CPP.ManagedStringToIl2Cpp(text));
		}
	}

	public unsafe static string LatestNewsTimestampKey
	{
		get
		{
			Unsafe.SkipInit(out System.IntPtr intPtr);
			IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr_LatestNewsTimestampKey, (void*)(&intPtr));
			return IL2CPP.Il2CppStringToManaged(intPtr);
		}
		set
		{
			IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr_LatestNewsTimestampKey, (void*)IL2CPP.ManagedStringToIl2Cpp(text));
		}
	}

	public unsafe static string HideLobbyCodeKey
	{
		get
		{
			Unsafe.SkipInit(out System.IntPtr intPtr);
			IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr_HideLobbyCodeKey, (void*)(&intPtr));
			return IL2CPP.Il2CppStringToManaged(intPtr);
		}
		set
		{
			IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr_HideLobbyCodeKey, (void*)IL2CPP.ManagedStringToIl2Cpp(text));
		}
	}

	public unsafe override CanvasGroup CanvasGroup
	{
		[CallerCount(34)]
		[CachedScanResults(RefRangeStart = 64384, RefRangeEnd = 64418, XrefRangeStart = 64384, XrefRangeEnd = 64418, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		get
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(IL2CPP.il2cpp_object_get_virtual_method(IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)this), NativeMethodInfoPtr_get_CanvasGroup_Public_Virtual_get_CanvasGroup_0), IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<CanvasGroup>(intPtr) : null;
		}
	}

	public unsafe override Selectable CanvasGroupSelectable
	{
		[CallerCount(12)]
		[CachedScanResults(RefRangeStart = 64418, RefRangeEnd = 64430, XrefRangeStart = 64418, XrefRangeEnd = 64430, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		get
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(IL2CPP.il2cpp_object_get_virtual_method(IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)this), NativeMethodInfoPtr_get_CanvasGroupSelectable_Public_Virtual_get_Selectable_0), IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Selectable>(intPtr) : null;
		}
	}

	public unsafe override UIPosLerpFade UILerpFade
	{
		[CallerCount(9)]
		[CachedScanResults(RefRangeStart = 89855, RefRangeEnd = 89864, XrefRangeStart = 89855, XrefRangeEnd = 89864, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		get
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(IL2CPP.il2cpp_object_get_virtual_method(IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)this), NativeMethodInfoPtr_get_UILerpFade_Public_Virtual_get_UIPosLerpFade_0), IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<UIPosLerpFade>(intPtr) : null;
		}
	}

	public unsafe override UIAlphaFade UIAlphaFade
	{
		[CallerCount(12)]
		[CachedScanResults(RefRangeStart = 89864, RefRangeEnd = 89876, XrefRangeStart = 89864, XrefRangeEnd = 89876, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		get
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(IL2CPP.il2cpp_object_get_virtual_method(IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)this), NativeMethodInfoPtr_get_UIAlphaFade_Public_Virtual_get_UIAlphaFade_0), IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<UIAlphaFade>(intPtr) : null;
		}
	}

	public unsafe override UIAlphaFade backgroundUIFade
	{
		[CallerCount(12)]
		[CachedScanResults(RefRangeStart = 89876, RefRangeEnd = 89888, XrefRangeStart = 89876, XrefRangeEnd = 89888, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		get
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(IL2CPP.il2cpp_object_get_virtual_method(IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)this), NativeMethodInfoPtr_get_backgroundUIFade_Public_Virtual_get_UIAlphaFade_0), IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<UIAlphaFade>(intPtr) : null;
		}
	}

	public unsafe Button FractalPurchaseButton
	{
		[CallerCount(0)]
		get
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_get_FractalPurchaseButton_Public_get_Button_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Button>(intPtr) : null;
		}
	}

	static UILobbyPlayTabPage()
	{
		Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr = IL2CPP.GetIl2CppClass("Assembly-CSharp.dll", "BAPBAP.UI", "UILobbyPlayTabPage");
		IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr);
		NativeFieldInfoPtr__canvasGroup = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "_canvasGroup");
		NativeFieldInfoPtr__canvasGroupSelectable = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "_canvasGroupSelectable");
		NativeFieldInfoPtr__uiLerpFade = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "_uiLerpFade");
		NativeFieldInfoPtr__uiAlphaFade = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "_uiAlphaFade");
		NativeFieldInfoPtr__backgroundUIFade = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "_backgroundUIFade");
		NativeFieldInfoPtr_contentsCanvasGroup = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "contentsCanvasGroup");
		NativeFieldInfoPtr__playerDisplay = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "_playerDisplay");
		NativeFieldInfoPtr__teammate1Display = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "_teammate1Display");
		NativeFieldInfoPtr__teammate2Display = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "_teammate2Display");
		NativeFieldInfoPtr__playContainer = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "_playContainer");
		NativeFieldInfoPtr__newReadyButton = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "_newReadyButton");
		NativeFieldInfoPtr__readyButton = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "_readyButton");
		NativeFieldInfoPtr__unreadyButton = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "_unreadyButton");
		NativeFieldInfoPtr__cancelButton = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "_cancelButton");
		NativeFieldInfoPtr_playMaintenanceMessageText = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "playMaintenanceMessageText");
		NativeFieldInfoPtr_betaServiceMessageText = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "betaServiceMessageText");
		NativeFieldInfoPtr__gameQueuePanel = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "_gameQueuePanel");
		NativeFieldInfoPtr__gameModePlayButton = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "_gameModePlayButton");
		NativeFieldInfoPtr__regionDropdown = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "_regionDropdown");
		NativeFieldInfoPtr__matchStartPanel = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "_matchStartPanel");
		NativeFieldInfoPtr__chatParent = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "_chatParent");
		NativeFieldInfoPtr__dailyReward = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "_dailyReward");
		NativeFieldInfoPtr_profileButton = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "profileButton");
		NativeFieldInfoPtr__battlePassPanel = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "_battlePassPanel");
		NativeFieldInfoPtr__battlePassXpPopUp = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "_battlePassXpPopUp");
		NativeFieldInfoPtr__playersOnline = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "_playersOnline");
		NativeFieldInfoPtr__liveWinnerFeedPanel = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "_liveWinnerFeedPanel");
		NativeFieldInfoPtr__notificationsPanel = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "_notificationsPanel");
		NativeFieldInfoPtr__lobbyPopUp = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "_lobbyPopUp");
		NativeFieldInfoPtr__lobbyOptionDropdown = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "_lobbyOptionDropdown");
		NativeFieldInfoPtr__friendsPanel = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "_friendsPanel");
		NativeFieldInfoPtr__friendInviteLobbyPopup = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "_friendInviteLobbyPopup");
		NativeFieldInfoPtr__friendsButton = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "_friendsButton");
		NativeFieldInfoPtr__friendsButtonNotification = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "_friendsButtonNotification");
		NativeFieldInfoPtr__friendsButtonNotificationText = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "_friendsButtonNotificationText");
		NativeFieldInfoPtr__friendsPreview = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "_friendsPreview");
		NativeFieldInfoPtr__goldCurrencyPanel = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "_goldCurrencyPanel");
		NativeFieldInfoPtr__fractalCurrencyPanel = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "_fractalCurrencyPanel");
		NativeFieldInfoPtr__fractalPurchaseButton = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "_fractalPurchaseButton");
		NativeFieldInfoPtr__fractalCurrencyPanelRoot = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "_fractalCurrencyPanelRoot");
		NativeFieldInfoPtr__softCurrencyPopUp = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "_softCurrencyPopUp");
		NativeFieldInfoPtr__fractalsCurrencyPopUp = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "_fractalsCurrencyPopUp");
		NativeFieldInfoPtr__charTokenCurrencyPopUp = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "_charTokenCurrencyPopUp");
		NativeFieldInfoPtr__profileXpPopUp = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "_profileXpPopUp");
		NativeFieldInfoPtr__referralCode = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "_referralCode");
		NativeFieldInfoPtr_newsPreviewButton = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "newsPreviewButton");
		NativeFieldInfoPtr_openBetaChallenge = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "openBetaChallenge");
		NativeFieldInfoPtr__customGameBackground = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "_customGameBackground");
		NativeFieldInfoPtr__elementsToDisableOnCustomGame = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "_elementsToDisableOnCustomGame");
		NativeFieldInfoPtr__customGameElementActiveCache = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "_customGameElementActiveCache");
		NativeFieldInfoPtr_NewsPanel = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "NewsPanel");
		NativeFieldInfoPtr_DeveloperPanel = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "DeveloperPanel");
		NativeFieldInfoPtr_LobbyOpenTogglePanel = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "LobbyOpenTogglePanel");
		NativeFieldInfoPtr_CustomGameLobby = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "CustomGameLobby");
		NativeFieldInfoPtr_InviteCodePage = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "InviteCodePage");
		NativeFieldInfoPtr_gameModePage = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "gameModePage");
		NativeFieldInfoPtr__configuration = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "_configuration");
		NativeFieldInfoPtr__translator = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "_translator");
		NativeFieldInfoPtr__actions = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "_actions");
		NativeFieldInfoPtr__lobbyDataModel = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "_lobbyDataModel");
		NativeFieldInfoPtr__teammateDisplays = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "_teammateDisplays");
		NativeFieldInfoPtr__characterSelectIconFactory = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "_characterSelectIconFactory");
		NativeFieldInfoPtr_matchStartCharSelectButtons = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "matchStartCharSelectButtons");
		NativeFieldInfoPtr_matchStartSelectedCharacterIcon = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "matchStartSelectedCharacterIcon");
		NativeFieldInfoPtr_matchStartSelectedCharIndex = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "matchStartSelectedCharIndex");
		NativeFieldInfoPtr_matchStartAnimateCharSelect = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "matchStartAnimateCharSelect");
		NativeFieldInfoPtr_matchStartAnimTime = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "matchStartAnimTime");
		NativeFieldInfoPtr__notificationEntryPool = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "_notificationEntryPool");
		NativeFieldInfoPtr__liveWinnerFeedEntryPool = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "_liveWinnerFeedEntryPool");
		NativeFieldInfoPtr_friendsPanelTabButtons = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "friendsPanelTabButtons");
		NativeFieldInfoPtr__friendEntryPool = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "_friendEntryPool");
		NativeFieldInfoPtr__friendRequestEntryPool = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "_friendRequestEntryPool");
		NativeFieldInfoPtr_activeFriendEntries = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "activeFriendEntries");
		NativeFieldInfoPtr_activeFriendRequestEntries = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "activeFriendRequestEntries");
		NativeFieldInfoPtr_friendInviteLobbyAction = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "friendInviteLobbyAction");
		NativeFieldInfoPtr_playButtonCooldown = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "playButtonCooldown");
		NativeFieldInfoPtr_newsPreviewElements = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "newsPreviewElements");
		NativeFieldInfoPtr_newsPreviewIcons = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "newsPreviewIcons");
		NativeFieldInfoPtr_newsPreviewCycleAnimate = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "newsPreviewCycleAnimate");
		NativeFieldInfoPtr_latestNewsButtonCycleTimer = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "latestNewsButtonCycleTimer");
		NativeFieldInfoPtr_latestNewsButtonCycleId = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "latestNewsButtonCycleId");
		NativeFieldInfoPtr_dailyRewardRefreshDate = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "dailyRewardRefreshDate");
		NativeFieldInfoPtr_dailyRewardCountdownEnabled = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "dailyRewardCountdownEnabled");
		NativeFieldInfoPtr_dailyRewardCountdownTimer = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "dailyRewardCountdownTimer");
		NativeFieldInfoPtr_animateDailyRewardProgress = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "animateDailyRewardProgress");
		NativeFieldInfoPtr_dailyRewardAnimTime = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "dailyRewardAnimTime");
		NativeFieldInfoPtr_lerpedDailyRewardProgress = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "lerpedDailyRewardProgress");
		NativeFieldInfoPtr_currentDailyRewardProgress = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "currentDailyRewardProgress");
		NativeFieldInfoPtr_prevCurrentDailyRewardProgress = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "prevCurrentDailyRewardProgress");
		NativeFieldInfoPtr_dailyRewardProgressMax = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "dailyRewardProgressMax");
		NativeFieldInfoPtr_redeemCoroutine = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "redeemCoroutine");
		NativeFieldInfoPtr_currentBpLevel = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "currentBpLevel");
		NativeFieldInfoPtr_currentBpXp = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "currentBpXp");
		NativeFieldInfoPtr_currentBpXpNeeded = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "currentBpXpNeeded");
		NativeFieldInfoPtr_prevCurrentBpLevel = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "prevCurrentBpLevel");
		NativeFieldInfoPtr_prevCurrentBpXp = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "prevCurrentBpXp");
		NativeFieldInfoPtr_maxBpLevel = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "maxBpLevel");
		NativeFieldInfoPtr_bpEndDate = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "bpEndDate");
		NativeFieldInfoPtr__animateBpXpBar = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "_animateBpXpBar");
		NativeFieldInfoPtr__animateBpXpBarTime = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "_animateBpXpBarTime");
		NativeFieldInfoPtr__animCurrentBpLevel = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "_animCurrentBpLevel");
		NativeFieldInfoPtr__animCurrentBpXp = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "_animCurrentBpXp");
		NativeFieldInfoPtr__animCurrentBpXpNeeded = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "_animCurrentBpXpNeeded");
		NativeFieldInfoPtr__lerpedCurrentBpXp = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "_lerpedCurrentBpXp");
		NativeFieldInfoPtr_bpXpObtainedAmount = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "bpXpObtainedAmount");
		NativeFieldInfoPtr_queueBpXpObtain = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "queueBpXpObtain");
		NativeFieldInfoPtr__animateBpXpBarLevelUp = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "_animateBpXpBarLevelUp");
		NativeFieldInfoPtr__animateBpXpBarLevelUpTime = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "_animateBpXpBarLevelUpTime");
		NativeFieldInfoPtr_currentAccountLevel = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "currentAccountLevel");
		NativeFieldInfoPtr_currentAccountXp = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "currentAccountXp");
		NativeFieldInfoPtr_currentAccountXpNeeded = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "currentAccountXpNeeded");
		NativeFieldInfoPtr_prevCurrentAccountLevel = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "prevCurrentAccountLevel");
		NativeFieldInfoPtr_prevCurrentAccountXp = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "prevCurrentAccountXp");
		NativeFieldInfoPtr_maxAccountLevel = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "maxAccountLevel");
		NativeFieldInfoPtr__animateAccountXpBar = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "_animateAccountXpBar");
		NativeFieldInfoPtr__animateAccountXpBarTime = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "_animateAccountXpBarTime");
		NativeFieldInfoPtr__animCurrentAccountLevel = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "_animCurrentAccountLevel");
		NativeFieldInfoPtr__animCurrentAccountXp = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "_animCurrentAccountXp");
		NativeFieldInfoPtr__animCurrentAccountXpNeeded = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "_animCurrentAccountXpNeeded");
		NativeFieldInfoPtr__lerpedCurrentAccountXp = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "_lerpedCurrentAccountXp");
		NativeFieldInfoPtr_accountXpObtainedAmount = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "accountXpObtainedAmount");
		NativeFieldInfoPtr_queueAccountXpObtain = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "queueAccountXpObtain");
		NativeFieldInfoPtr__animateAccountXpBarLevelUp = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "_animateAccountXpBarLevelUp");
		NativeFieldInfoPtr__animateAccountXpBarLevelUpTime = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "_animateAccountXpBarLevelUpTime");
		NativeFieldInfoPtr_softCurrency = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "softCurrency");
		NativeFieldInfoPtr_animateSoftCurrency = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "animateSoftCurrency");
		NativeFieldInfoPtr_softCurrencyAnimTime = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "softCurrencyAnimTime");
		NativeFieldInfoPtr_lerpedSoftCurrency = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "lerpedSoftCurrency");
		NativeFieldInfoPtr_queueGoldObtain = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "queueGoldObtain");
		NativeFieldInfoPtr_goldObtainedAmount = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "goldObtainedAmount");
		NativeFieldInfoPtr_fractalsCurrency = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "fractalsCurrency");
		NativeFieldInfoPtr_animateFractalsCurrency = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "animateFractalsCurrency");
		NativeFieldInfoPtr_fractalsCurrencyAnimTime = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "fractalsCurrencyAnimTime");
		NativeFieldInfoPtr_lerpedFractalsCurrency = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "lerpedFractalsCurrency");
		NativeFieldInfoPtr_queueFractalsObtain = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "queueFractalsObtain");
		NativeFieldInfoPtr_fractalsObtainedAmount = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "fractalsObtainedAmount");
		NativeFieldInfoPtr_charTokenCurrency = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "charTokenCurrency");
		NativeFieldInfoPtr_animateCharTokenCurrency = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "animateCharTokenCurrency");
		NativeFieldInfoPtr_charTokenCurrencyAnimTime = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "charTokenCurrencyAnimTime");
		NativeFieldInfoPtr_lerpedCharTokenCurrency = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "lerpedCharTokenCurrency");
		NativeFieldInfoPtr_queueCharTokenObtain = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "queueCharTokenObtain");
		NativeFieldInfoPtr_charTokenObtainedAmount = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "charTokenObtainedAmount");
		NativeFieldInfoPtr__readyStatusString = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "_readyStatusString");
		NativeFieldInfoPtr__notReadyStatusString = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "_notReadyStatusString");
		NativeFieldInfoPtr__inQueueStatusString = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "_inQueueStatusString");
		NativeFieldInfoPtr__queueFindingPlayersStr = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "_queueFindingPlayersStr");
		NativeFieldInfoPtr__queueGameStartingStr = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "_queueGameStartingStr");
		NativeFieldInfoPtr__playersOnlineString = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "_playersOnlineString");
		NativeFieldInfoPtr__linkCopiedPopUpString = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "_linkCopiedPopUpString");
		NativeFieldInfoPtr_usernameIdCopiedString = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "usernameIdCopiedString");
		NativeFieldInfoPtr_maxLevelStr = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "maxLevelStr");
		NativeFieldInfoPtr_dailyRewardRefreshesInStr = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "dailyRewardRefreshesInStr");
		NativeFieldInfoPtr_gameModeEventStartsInStr = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "gameModeEventStartsInStr");
		NativeFieldInfoPtr_inviteLobbyNotifStr = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "inviteLobbyNotifStr");
		NativeFieldInfoPtr_onlineStr = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "onlineStr");
		NativeFieldInfoPtr_offlineStr = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "offlineStr");
		NativeFieldInfoPtr_steamOnlineStr = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "steamOnlineStr");
		NativeFieldInfoPtr_steamOfflineStr = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "steamOfflineStr");
		NativeFieldInfoPtr_sentAGameInviteToStr = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "sentAGameInviteToStr");
		NativeFieldInfoPtr_friendInviteSentToStr = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "friendInviteSentToStr");
		NativeFieldInfoPtr_friendInviteSentErrorStr = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "friendInviteSentErrorStr");
		NativeFieldInfoPtr_friendRequestAcceptedStr = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "friendRequestAcceptedStr");
		NativeFieldInfoPtr_joinLobbyStr = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "joinLobbyStr");
		NativeFieldInfoPtr_leaveLobbyStr = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "leaveLobbyStr");
		NativeFieldInfoPtr_inviteToGameStr = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "inviteToGameStr");
		NativeFieldInfoPtr_messageFriendStr = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "messageFriendStr");
		NativeFieldInfoPtr_playerViewProfileStr = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "playerViewProfileStr");
		NativeFieldInfoPtr_friendUnfriendStr = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "friendUnfriendStr");
		NativeFieldInfoPtr_sendFriendRequestStr = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "sendFriendRequestStr");
		NativeFieldInfoPtr_playerLobbyKickStr = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "playerLobbyKickStr");
		NativeFieldInfoPtr_challengeXSignUpsOutOfYStr = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "challengeXSignUpsOutOfYStr");
		NativeFieldInfoPtr_eventCountdownGmEnabled = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "eventCountdownGmEnabled");
		NativeFieldInfoPtr_eventCountdownGmTimer = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "eventCountdownGmTimer");
		NativeFieldInfoPtr_eventCountdownGmButton = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "eventCountdownGmButton");
		NativeFieldInfoPtr_hideLobbyCode = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "hideLobbyCode");
		NativeFieldInfoPtr_FirstTimeTutorialPageKey = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "FirstTimeTutorialPageKey");
		NativeFieldInfoPtr_LatestNewsTimestampKey = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "LatestNewsTimestampKey");
		NativeFieldInfoPtr_HideLobbyCodeKey = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, "HideLobbyCodeKey");
		NativeMethodInfoPtr_get_CanvasGroup_Public_Virtual_get_CanvasGroup_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669423);
		NativeMethodInfoPtr_get_CanvasGroupSelectable_Public_Virtual_get_Selectable_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669424);
		NativeMethodInfoPtr_get_UILerpFade_Public_Virtual_get_UIPosLerpFade_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669425);
		NativeMethodInfoPtr_get_UIAlphaFade_Public_Virtual_get_UIAlphaFade_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669426);
		NativeMethodInfoPtr_get_backgroundUIFade_Public_Virtual_get_UIAlphaFade_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669427);
		NativeMethodInfoPtr_get_FractalPurchaseButton_Public_get_Button_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669428);
		NativeMethodInfoPtr_FixedUpdate_Private_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669429);
		NativeMethodInfoPtr_Update_Private_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669430);
		NativeMethodInfoPtr_Build_Public_Void_Configuration_Translator_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669431);
		NativeMethodInfoPtr_Localise_Public_Virtual_Void_Translator_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669432);
		NativeMethodInfoPtr_SetActions_Public_Void_Actions_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669433);
		NativeMethodInfoPtr_Initialise_Public_Void_LobbyDataModel_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669434);
		NativeMethodInfoPtr_OnPageOpen_Public_Virtual_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669435);
		NativeMethodInfoPtr_OnPageClose_Public_Virtual_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669436);
		NativeMethodInfoPtr_OnInputModeChanged_Public_Virtual_Void_InputMode_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669437);
		NativeMethodInfoPtr_FocusDefaultSelectable_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669438);
		NativeMethodInfoPtr_UpdateData_Public_Void_LobbyDataModel_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669439);
		NativeMethodInfoPtr_UpdateFriendData_Public_Void_LobbyDataModel_Friend_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669440);
		NativeMethodInfoPtr_AddNewFriendEntry_Private_Void_Friend_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669441);
		NativeMethodInfoPtr_UpdateFriendEntry_Private_Void_UILobbyFriendEntry_Friend_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669442);
		NativeMethodInfoPtr_RemoveFriendEntry_Private_Void_UILobbyFriendEntry_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669443);
		NativeMethodInfoPtr_UpdateFriendRequestsData_Public_Void_LobbyDataModel_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669444);
		NativeMethodInfoPtr_UpdateInviteLobbyNotification_Public_Void_String_String_String_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669445);
		NativeMethodInfoPtr_UpdateFriendStatus_Public_Void_String_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669446);
		NativeMethodInfoPtr_UpdateFriendAvatarId_Public_Void_String_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669447);
		NativeMethodInfoPtr_UpdateFriendLobbyOpen_Public_Void_String_Boolean_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669448);
		NativeMethodInfoPtr_PlayFriendEntryFadeIn_Public_Void_String_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669449);
		NativeMethodInfoPtr_PlayFriendRequestEntryFadeIn_Public_Void_String_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669450);
		NativeMethodInfoPtr_SetPlayerCurrentStatus_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669451);
		NativeMethodInfoPtr_UpdatePlayerFriendStatus_Private_Void_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669452);
		NativeMethodInfoPtr_SetOpenFriendRequests_Public_Void_Boolean_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669453);
		NativeMethodInfoPtr_SetClosedPartyRequests_Public_Void_Boolean_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669454);
		NativeMethodInfoPtr_SetTimeZoneMaintenanceMessage_Private_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669455);
		NativeMethodInfoPtr_OnLoginButtonPressed_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669456);
		NativeMethodInfoPtr_OnExitLobby_Private_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669457);
		NativeMethodInfoPtr_SwitchRegion_Public_Void_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669458);
		NativeMethodInfoPtr_PopulateRegionDropdown_Private_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669459);
		NativeMethodInfoPtr_OnRegionDropdownChanged_Private_Void_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669460);
		NativeMethodInfoPtr_UpdateRegionUI_Public_Void_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669461);
		NativeMethodInfoPtr_SetLocalPlayerBanner_Public_Void_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669462);
		NativeMethodInfoPtr_UpdateLocalPlayerBanner_Public_Void_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669463);
		NativeMethodInfoPtr_PopulateTeammateDisplays_Public_Void_List_1_PlayerModel_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669464);
		NativeMethodInfoPtr_PlayTeamJoinedSfx_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669465);
		NativeMethodInfoPtr_UpdateLocalPlayerDisplay_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669466);
		NativeMethodInfoPtr_UpdateGameModes_Public_Void_Il2CppReferenceArray_1_GameModeModel_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669467);
		NativeMethodInfoPtr_UpdateReadyStatus_Public_Void_String_Boolean_Boolean_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669468);
		NativeMethodInfoPtr_UpdateDailyRewardData_Public_Void_DailyReward_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669469);
		NativeMethodInfoPtr_OnSoftCurrencyChanged_Public_Void_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669470);
		NativeMethodInfoPtr_OnFractalsCurrencyChanged_Public_Void_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669471);
		NativeMethodInfoPtr_OnCharTokenCurrencyChanged_Public_Void_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669472);
		NativeMethodInfoPtr_OnAccountXpChanged_Public_Void_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669473);
		NativeMethodInfoPtr_OnBattlePassXpChanged_Public_Void_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669474);
		NativeMethodInfoPtr_OnDailyRewardProgressChanged_Public_Void_Int32_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669475);
		NativeMethodInfoPtr_QueueCurrencyGoldObtain_Public_Void_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669476);
		NativeMethodInfoPtr_QueueCurrencyFractalsObtain_Public_Void_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669477);
		NativeMethodInfoPtr_QueueCurrencyCharTokensObtain_Public_Void_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669478);
		NativeMethodInfoPtr_QueueAccountXpObtain_Public_Void_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669479);
		NativeMethodInfoPtr_QueueBattlePassXpObtain_Public_Void_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669480);
		NativeMethodInfoPtr_UpdateAccountPassData_Public_Void_LobbyDataModel_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669481);
		NativeMethodInfoPtr_UpdateBattlePassData_Public_Void_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669482);
		NativeMethodInfoPtr_UpdateGoldCurrency_Public_Void_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669483);
		NativeMethodInfoPtr_UpdateFractalsCurrency_Public_Void_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669484);
		NativeMethodInfoPtr_UpdateCharTokensCurrency_Public_Void_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669485);
		NativeMethodInfoPtr_UpdateAccountPassXp_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669486);
		NativeMethodInfoPtr_UpdateBapPassXp_Public_Void_BattlePassModel_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669487);
		NativeMethodInfoPtr_PlayerAccountBannerUpdate_Public_Void_String_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669488);
		NativeMethodInfoPtr_PlayerAccountLevelUpdate_Public_Void_String_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669489);
		NativeMethodInfoPtr_UpdatePlayersOnline_Public_Void_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669490);
		NativeMethodInfoPtr_ShowLobbyNotification_Public_Void_String_MessageType_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669491);
		NativeMethodInfoPtr_SpawnLiveWinnerFeedEntry_Public_Void_String_Int32_DateTime_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669492);
		NativeMethodInfoPtr_ShowLiveWinnerFeed_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669493);
		NativeMethodInfoPtr_HideLiveWinnerFeed_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669494);
		NativeMethodInfoPtr_UpdateEventChallengeLives_Public_Void_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669495);
		NativeMethodInfoPtr_UpdateEventPanel_Public_Void_Int32_Int32_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669496);
		NativeMethodInfoPtr_SetGoldCurrencyPanelUI_Public_Void_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669497);
		NativeMethodInfoPtr_SetFractalsCurrencyPanelUI_Public_Void_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669498);
		NativeMethodInfoPtr_SetCharTokenCurrencyPanelUI_Public_Void_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669499);
		NativeMethodInfoPtr_SetCurrentBattlePassUI_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669500);
		NativeMethodInfoPtr_SetCurrentBattlePassUIRemainingDays_Public_Void_String_Boolean_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669501);
		NativeMethodInfoPtr_SetCurrentAccountPassUI_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669502);
		NativeMethodInfoPtr_SetCurrentDailyRewardUI_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669503);
		NativeMethodInfoPtr_ShowPopUpLinkCopied_Private_Void_Vector2_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669504);
		NativeMethodInfoPtr_ShowPopUp_Public_Void_Vector2_String_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669505);
		NativeMethodInfoPtr_PlayRedeemDeltaSequenceCoroutine_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669506);
		NativeMethodInfoPtr_RedeemDeltaSequenceCoroutine_Private_IEnumerator_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669507);
		NativeMethodInfoPtr_CheckForCustomLobby_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669508);
		NativeMethodInfoPtr_OpenCustomLobbyWindow_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669509);
		NativeMethodInfoPtr_CloseCustomLobbyWindow_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669510);
		NativeMethodInfoPtr_GetCustomLobbyGameModeId_Public_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669511);
		NativeMethodInfoPtr_GetCurrentSoftCurrency_Public_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669512);
		NativeMethodInfoPtr_GetCurrentFractalsCurrency_Public_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669513);
		NativeMethodInfoPtr_GetCurrentTokenCurrency_Public_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669514);
		NativeMethodInfoPtr_GetCurrencyBalanceFromAssetId_Public_Int32_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669515);
		NativeMethodInfoPtr_GetSelectedBannerAssetId_Public_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669516);
		NativeMethodInfoPtr_IsPlayerBannerAssetIdEquiped_Public_Boolean_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669517);
		NativeMethodInfoPtr_GetSelectedSkinAssetId_Public_Int32_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669518);
		NativeMethodInfoPtr_IsSkinAssetIdEquipped_Public_Boolean_Int32_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669519);
		NativeMethodInfoPtr_GetAccountLevelXpNeeded_Public_Int32_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669520);
		NativeMethodInfoPtr_GetCurrentAccountLevelXpNeeded_Public_Int32_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669521);
		NativeMethodInfoPtr_GetAccountXp_Public_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669522);
		NativeMethodInfoPtr_GetPrevAccountXp_Public_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669523);
		NativeMethodInfoPtr_GetAccountPrevLevel_Public_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669524);
		NativeMethodInfoPtr_GetAccountLevel_Public_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669525);
		NativeMethodInfoPtr_GetAccountMaxLevel_Public_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669526);
		NativeMethodInfoPtr_GetBapPassXp_Public_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669527);
		NativeMethodInfoPtr_GetBapPassPrevXp_Public_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669528);
		NativeMethodInfoPtr_GetBapPassPreviousLevel_Public_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669529);
		NativeMethodInfoPtr_GetBapPassLevel_Public_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669530);
		NativeMethodInfoPtr_GetBapPassMaxLevel_Public_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669531);
		NativeMethodInfoPtr_GetDailyProgress_Public_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669532);
		NativeMethodInfoPtr_GetPrevDailyProgress_Public_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669533);
		NativeMethodInfoPtr_GetDailyProgressMax_Public_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669534);
		NativeMethodInfoPtr_GetAccountLevelFromXp_Public_Int32_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669535);
		NativeMethodInfoPtr_IsUserGuest_Public_Boolean_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669536);
		NativeMethodInfoPtr_PlayerOwnsAssetId_Public_Boolean_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669537);
		NativeMethodInfoPtr_EnableInteractableContents_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669538);
		NativeMethodInfoPtr_DisableInteractableContents_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669539);
		NativeMethodInfoPtr_ClickNewReadyButton_Private_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669540);
		NativeMethodInfoPtr_ClickReadyButton_Private_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669541);
		NativeMethodInfoPtr_ClickUnreadyButton_Private_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669542);
		NativeMethodInfoPtr_ClickCancelButton_Private_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669543);
		NativeMethodInfoPtr_HidePlayButton_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669544);
		NativeMethodInfoPtr_ShowPlayReadyButton_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669545);
		NativeMethodInfoPtr_ShowPlayUnreadyButton_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669546);
		NativeMethodInfoPtr_ShowPlayCancelButton_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669547);
		NativeMethodInfoPtr_SetPlayButtonCooldown_Private_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669548);
		NativeMethodInfoPtr_OnPlayButtonCooldownEnded_Private_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669549);
		NativeMethodInfoPtr_ShowMaintenanceMessage_Private_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669550);
		NativeMethodInfoPtr_HideMaintenanceMessage_Private_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669551);
		NativeMethodInfoPtr_OnCommunityChallengeReadyButtonPressed_Private_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669552);
		NativeMethodInfoPtr_OpenChallengeEventWarningPopUp_Private_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669553);
		NativeMethodInfoPtr_CloseChallengeEventDisclaimerPopUp_Private_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669554);
		NativeMethodInfoPtr_OpenChallengeEventNoMoreLivesPopUp_Private_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669555);
		NativeMethodInfoPtr_CloseChallengeEventOutOfLivesPopUp_Private_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669556);
		NativeMethodInfoPtr_UpdateDailyRewardResfreshUI_Private_Void_TimeSpan_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669557);
		NativeMethodInfoPtr_OnDailyRewardRefreshEnded_Private_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669558);
		NativeMethodInfoPtr_ShowBattlePass_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669559);
		NativeMethodInfoPtr_HideBattlePass_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669560);
		NativeMethodInfoPtr_CloseMatchStartPanel_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669561);
		NativeMethodInfoPtr_AnimateCharacterSelect_Private_Void_Single_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669562);
		NativeMethodInfoPtr_SetAndShowPlayerDisplay_Private_Void_PlayerDisplay_PlayerModel_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669563);
		NativeMethodInfoPtr_UpdatePlayerDisplayLevel_Private_Void_PlayerDisplay_PlayerModel_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669564);
		NativeMethodInfoPtr_UpdatePlayerDisplayBanner_Private_Void_PlayerDisplay_PlayerBanner_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669565);
		NativeMethodInfoPtr_PlayPlayerCharJoinSfx_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669566);
		NativeMethodInfoPtr_ShowPlayerReadys_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669567);
		NativeMethodInfoPtr_HidePlayerReadys_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669568);
		NativeMethodInfoPtr_SetPlayerCharDisplaySprite_Public_Void_Sprite_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669569);
		NativeMethodInfoPtr_HideCharacterDisplay_Private_Void_PlayerDisplay_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669570);
		NativeMethodInfoPtr_GetDefaultPlayerBanner_Public_PlayerBanner_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669571);
		NativeMethodInfoPtr_GetPlayerBannerFromAcountId_Public_PlayerBanner_String_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669572);
		NativeMethodInfoPtr_OpenPlayerOptionDropdown_Private_Void_RectTransform_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669573);
		NativeMethodInfoPtr_OpenTeammateOptionDropdown_Public_Void_String_RectTransform_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669574);
		NativeMethodInfoPtr_OnTeammateOptionKick_Private_Void_String_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669575);
		NativeMethodInfoPtr_ShowInviteButton_Private_Void_InviteButton_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669576);
		NativeMethodInfoPtr_HideInviteButton_Private_Void_InviteButton_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669577);
		NativeMethodInfoPtr_ShowLoader_Private_Void_TeammateLoader_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669578);
		NativeMethodInfoPtr_HideLoader_Private_Void_TeammateLoader_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669579);
		NativeMethodInfoPtr_ShowGmPairingTeamSpinners_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669580);
		NativeMethodInfoPtr_HideAllPairingTeamSpinners_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669581);
		NativeMethodInfoPtr_HideAllInviteButton_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669582);
		NativeMethodInfoPtr_OnInviteButtonPressed_Private_Void_InviteButton_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669583);
		NativeMethodInfoPtr_OnFriendsButtonPressed_Private_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669584);
		NativeMethodInfoPtr_OnReferralCodeButtonPressed_Private_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669585);
		NativeMethodInfoPtr_SetInviteCodesRemainingUses_Public_Void_Int32_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669586);
		NativeMethodInfoPtr_OpenOptionDropdown_Private_Void_Vector2_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669587);
		NativeMethodInfoPtr_CloseOptionDropdown_Private_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669588);
		NativeMethodInfoPtr_ShowFriendsPanel_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669589);
		NativeMethodInfoPtr_CloseFriendsPanel_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669590);
		NativeMethodInfoPtr_FriendsPanelSetGuestMode_Private_Void_Boolean_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669591);
		NativeMethodInfoPtr_OnAddFriendPopupButton_Private_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669592);
		NativeMethodInfoPtr_OpenAddFriendPopup_Private_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669593);
		NativeMethodInfoPtr_CloseAddFriendPopup_Private_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669594);
		NativeMethodInfoPtr_OnJoinLobbyPopupButton_Private_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669595);
		NativeMethodInfoPtr_OpenJoinLobbyPopup_Private_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669596);
		NativeMethodInfoPtr_CloseJoinLobbyPopup_Private_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669597);
		NativeMethodInfoPtr_SetButtonSelectedState_Private_Void_MultiGraphicButton_Boolean_Il2CppStructArray_1_Color_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669598);
		NativeMethodInfoPtr_UpdateFriendsPreview_Private_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669599);
		NativeMethodInfoPtr_OpenFriendInviteNotification_Private_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669600);
		NativeMethodInfoPtr_CloseFriendInviteNotification_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669601);
		NativeMethodInfoPtr_InitialiseFriendInviteNotification_Private_Void_String_String_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669602);
		NativeMethodInfoPtr_OnFriendInviteLobbyNotificationJoin_Private_Void_String_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669603);
		NativeMethodInfoPtr_SendFriendInvite_Public_Void_String_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669604);
		NativeMethodInfoPtr_UpdateFriendLocalPlayerAvatar_Private_Void_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669605);
		NativeMethodInfoPtr_SetHideLobbyCodeButton_Private_Void_Boolean_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669606);
		NativeMethodInfoPtr_SetLobbyIdCode_Private_Void_String_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669607);
		NativeMethodInfoPtr_SendFriendLobbyInvite_Private_Void_UILobbyFriendEntry_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669608);
		NativeMethodInfoPtr_SendSteamFriendLobbyInvite_Private_Void_UILobbyFriendEntry_SteamFriend_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669609);
		NativeMethodInfoPtr_InitializeFriendsPanel_Private_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669610);
		NativeMethodInfoPtr_ClearFriendsPanel_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669611);
		NativeMethodInfoPtr_PopulateFriendsPanel_Private_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669612);
		NativeMethodInfoPtr_PopulateSteamFriendsPanel_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669613);
		NativeMethodInfoPtr_GetFriendListEntries_Public_List_1_UILobbyFriendEntry_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669614);
		NativeMethodInfoPtr_OnFriendEntrySelected_Private_Void_UILobbyFriendEntry_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669615);
		NativeMethodInfoPtr_OpenOptionDropdown_Private_Void_String_RectTransform_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669616);
		NativeMethodInfoPtr_RefreshFriendOptionsDropdown_Public_Void_String_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669617);
		NativeMethodInfoPtr_OnFriendOptionJoinLobby_Private_Void_String_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669618);
		NativeMethodInfoPtr_OnFriendOptionInviteToGame_Private_Void_String_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669619);
		NativeMethodInfoPtr_OnFriendOptionDirectMessage_Private_Void_String_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669620);
		NativeMethodInfoPtr_OnFriendOptionUnfriend_Private_Void_String_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669621);
		NativeMethodInfoPtr_InitializeRequestsPanel_Private_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669622);
		NativeMethodInfoPtr_UpdateFriendRequestsNotification_Private_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669623);
		NativeMethodInfoPtr_UpdateFriendEntryHolders_Private_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669624);
		NativeMethodInfoPtr_OnSendFriendLobbyInvite_Private_Void_String_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669625);
		NativeMethodInfoPtr_OnSendFriendRequestSuccess_Public_Void_String_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669626);
		NativeMethodInfoPtr_OnSendFriendRequestFail_Public_Void_String_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669627);
		NativeMethodInfoPtr_OnFriendRequestAcceptSuccess_Public_Void_String_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669628);
		NativeMethodInfoPtr_OnFriendRequestDeclineSuccess_Public_Void_String_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669629);
		NativeMethodInfoPtr_TryRemoveFriendRequest_Private_Void_String_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669630);
		NativeMethodInfoPtr_GetUsernameId_Public_String_String_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669631);
		NativeMethodInfoPtr_GetFriendAvatar_Public_Texture2D_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669632);
		NativeMethodInfoPtr_GetFriendAvatarOffset_Public_Vector2_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669633);
		NativeMethodInfoPtr_GetFriendAvatarSize_Public_Vector2_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669634);
		NativeMethodInfoPtr_PlayerIsFriend_Public_Boolean_String_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669635);
		NativeMethodInfoPtr_ShowGameModeButton_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669636);
		NativeMethodInfoPtr_HideGameModeButton_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669637);
		NativeMethodInfoPtr_SetSelectedGameMode_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669638);
		NativeMethodInfoPtr_SetGameModeSelectButton_Private_Void_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669639);
		NativeMethodInfoPtr_GameModeSelectButtonEventEnable_Public_Void_UILobbyGameModeButton_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669640);
		NativeMethodInfoPtr_GameModeSelectButtonEventDisable_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669641);
		NativeMethodInfoPtr_SetGameModeSelectLoader_Public_Void_Boolean_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669642);
		NativeMethodInfoPtr_ShowQueuePanel_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669643);
		NativeMethodInfoPtr_HideQueuePanel_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669644);
		NativeMethodInfoPtr_SetQueuePanelPlayerCount_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669645);
		NativeMethodInfoPtr_SetQueuePanelElapsedTime_Public_Void_Double_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669646);
		NativeMethodInfoPtr_SetQueueStateInQueue_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669647);
		NativeMethodInfoPtr_SetQueueStateQueueMatched_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669648);
		NativeMethodInfoPtr_SetQueueStateInQueueNoCounts_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669649);
		NativeMethodInfoPtr_SetGameModePanelName_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669650);
		NativeMethodInfoPtr_JoinLobbyVoiceChannel_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669651);
		NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669652);
		NativeMethodInfoPtr__Localise_b__193_0_Private_Boolean_GameModeConfiguration_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669653);
		NativeMethodInfoPtr__OpenPlayerOptionDropdown_b__363_0_Private_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669654);
		NativeMethodInfoPtr__ShowGmPairingTeamSpinners_b__370_0_Private_Boolean_GameModeConfiguration_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669655);
		NativeMethodInfoPtr__SetGameModePanelName_b__440_0_Private_Boolean_GameModeConfiguration_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr, 100669656);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 95193, XrefRangeEnd = 95223, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void FixedUpdate()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_FixedUpdate_Private_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 95223, XrefRangeEnd = 95283, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void Update()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_Update_Private_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 95550, RefRangeEnd = 95551, XrefRangeStart = 95283, XrefRangeEnd = 95550, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void Build(Configuration configuration, Translator translator)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[2];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)configuration);
		*(System.IntPtr*)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)translator);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_Build_Public_Void_Configuration_Translator_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 95551, XrefRangeEnd = 95639, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe override void Localise(Translator translator)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)translator);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(IL2CPP.il2cpp_object_get_virtual_method(IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)this), NativeMethodInfoPtr_Localise_Public_Virtual_Void_Translator_0), IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	public unsafe void SetActions(Actions actions)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)actions);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_SetActions_Public_Void_Actions_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 95665, RefRangeEnd = 95666, XrefRangeStart = 95639, XrefRangeEnd = 95665, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void Initialise(LobbyDataModel data)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)data);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_Initialise_Public_Void_LobbyDataModel_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 95666, XrefRangeEnd = 95671, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe override void OnPageOpen()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(IL2CPP.il2cpp_object_get_virtual_method(IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)this), NativeMethodInfoPtr_OnPageOpen_Public_Virtual_Void_0), IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 95671, XrefRangeEnd = 95676, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe override void OnPageClose()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(IL2CPP.il2cpp_object_get_virtual_method(IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)this), NativeMethodInfoPtr_OnPageClose_Public_Virtual_Void_0), IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 95676, XrefRangeEnd = 95688, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe override void OnInputModeChanged(InputMode inputMode)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = (nint)(&inputMode);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(IL2CPP.il2cpp_object_get_virtual_method(IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)this), NativeMethodInfoPtr_OnInputModeChanged_Public_Virtual_Void_InputMode_0), IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 95688, XrefRangeEnd = 95689, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void FocusDefaultSelectable()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_FocusDefaultSelectable_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(10)]
	[CachedScanResults(RefRangeStart = 95732, RefRangeEnd = 95742, XrefRangeStart = 95689, XrefRangeEnd = 95732, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void UpdateData(LobbyDataModel data)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)data);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_UpdateData_Public_Void_LobbyDataModel_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(2)]
	[CachedScanResults(RefRangeStart = 95757, RefRangeEnd = 95759, XrefRangeStart = 95742, XrefRangeEnd = 95757, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void UpdateFriendData(LobbyDataModel data, LobbyDataModel.Friend friend)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[2];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)data);
		*(System.IntPtr*)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)friend);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_UpdateFriendData_Public_Void_LobbyDataModel_Friend_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 95790, RefRangeEnd = 95791, XrefRangeStart = 95759, XrefRangeEnd = 95790, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void AddNewFriendEntry(LobbyDataModel.Friend friend)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)friend);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_AddNewFriendEntry_Private_Void_Friend_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 95791, XrefRangeEnd = 95801, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void UpdateFriendEntry(UILobbyFriendEntry entry, LobbyDataModel.Friend friend)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[2];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)entry);
		*(System.IntPtr*)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)friend);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_UpdateFriendEntry_Private_Void_UILobbyFriendEntry_Friend_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 95801, XrefRangeEnd = 95803, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void RemoveFriendEntry(UILobbyFriendEntry friendEntry)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)friendEntry);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_RemoveFriendEntry_Private_Void_UILobbyFriendEntry_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(3)]
	[CachedScanResults(RefRangeStart = 95805, RefRangeEnd = 95808, XrefRangeStart = 95803, XrefRangeEnd = 95805, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void UpdateFriendRequestsData(LobbyDataModel data)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)data);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_UpdateFriendRequestsData_Public_Void_LobbyDataModel_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 95834, RefRangeEnd = 95835, XrefRangeStart = 95808, XrefRangeEnd = 95834, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void UpdateInviteLobbyNotification(string receiverAccountId, string senderAccountId, string lobbyId)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[3];
		*ptr = IL2CPP.ManagedStringToIl2Cpp(receiverAccountId);
		*(System.IntPtr*)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.ManagedStringToIl2Cpp(senderAccountId);
		*(System.IntPtr*)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.ManagedStringToIl2Cpp(lobbyId);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_UpdateInviteLobbyNotification_Public_Void_String_String_String_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(2)]
	[CachedScanResults(RefRangeStart = 95882, RefRangeEnd = 95884, XrefRangeStart = 95835, XrefRangeEnd = 95882, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void UpdateFriendStatus(string accountId, int status)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[2];
		*ptr = IL2CPP.ManagedStringToIl2Cpp(accountId);
		*(int**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = &status;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_UpdateFriendStatus_Public_Void_String_Int32_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 95906, RefRangeEnd = 95907, XrefRangeStart = 95884, XrefRangeEnd = 95906, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void UpdateFriendAvatarId(string accountId, int avatarId)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[2];
		*ptr = IL2CPP.ManagedStringToIl2Cpp(accountId);
		*(int**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = &avatarId;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_UpdateFriendAvatarId_Public_Void_String_Int32_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 95919, RefRangeEnd = 95920, XrefRangeStart = 95907, XrefRangeEnd = 95919, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void UpdateFriendLobbyOpen(string accountId, bool lobbyOpen)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[2];
		*ptr = IL2CPP.ManagedStringToIl2Cpp(accountId);
		*(bool**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = &lobbyOpen;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_UpdateFriendLobbyOpen_Public_Void_String_Boolean_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 95920, XrefRangeEnd = 95929, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void PlayFriendEntryFadeIn(string accountId)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.ManagedStringToIl2Cpp(accountId);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_PlayFriendEntryFadeIn_Public_Void_String_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 95938, RefRangeEnd = 95939, XrefRangeStart = 95929, XrefRangeEnd = 95938, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void PlayFriendRequestEntryFadeIn(string accountId)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.ManagedStringToIl2Cpp(accountId);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_PlayFriendRequestEntryFadeIn_Public_Void_String_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(8)]
	[CachedScanResults(RefRangeStart = 95942, RefRangeEnd = 95950, XrefRangeStart = 95939, XrefRangeEnd = 95942, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void SetPlayerCurrentStatus()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_SetPlayerCurrentStatus_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 95950, XrefRangeEnd = 95951, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void UpdatePlayerFriendStatus(int statusId)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = (nint)(&statusId);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_UpdatePlayerFriendStatus_Private_Void_Int32_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 95951, RefRangeEnd = 95952, XrefRangeStart = 95951, XrefRangeEnd = 95951, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void SetOpenFriendRequests(bool isEnabled)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = (nint)(&isEnabled);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_SetOpenFriendRequests_Public_Void_Boolean_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	public unsafe void SetClosedPartyRequests(bool isEnabled)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = (nint)(&isEnabled);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_SetClosedPartyRequests_Public_Void_Boolean_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 95976, RefRangeEnd = 95977, XrefRangeStart = 95952, XrefRangeEnd = 95976, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void SetTimeZoneMaintenanceMessage()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_SetTimeZoneMaintenanceMessage_Private_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 95977, RefRangeEnd = 95978, XrefRangeStart = 95977, XrefRangeEnd = 95977, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void OnLoginButtonPressed()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_OnLoginButtonPressed_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 95978, XrefRangeEnd = 95979, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void OnExitLobby()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_OnExitLobby_Private_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 95980, RefRangeEnd = 95981, XrefRangeStart = 95979, XrefRangeEnd = 95980, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void SwitchRegion(int index)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = (nint)(&index);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_SwitchRegion_Public_Void_Int32_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 95981, XrefRangeEnd = 95999, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void PopulateRegionDropdown()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_PopulateRegionDropdown_Private_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 95999, XrefRangeEnd = 96003, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void OnRegionDropdownChanged(int value)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = (nint)(&value);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_OnRegionDropdownChanged_Private_Void_Int32_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 96005, RefRangeEnd = 96006, XrefRangeStart = 96003, XrefRangeEnd = 96005, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void UpdateRegionUI(int regionId)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = (nint)(&regionId);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_UpdateRegionUI_Public_Void_Int32_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 96006, RefRangeEnd = 96007, XrefRangeStart = 96006, XrefRangeEnd = 96006, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void SetLocalPlayerBanner(int bannerAssetId)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = (nint)(&bannerAssetId);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_SetLocalPlayerBanner_Public_Void_Int32_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 96015, RefRangeEnd = 96016, XrefRangeStart = 96007, XrefRangeEnd = 96015, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void UpdateLocalPlayerBanner(int bannerAssetId)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = (nint)(&bannerAssetId);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_UpdateLocalPlayerBanner_Public_Void_Int32_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(2)]
	[CachedScanResults(RefRangeStart = 96027, RefRangeEnd = 96029, XrefRangeStart = 96016, XrefRangeEnd = 96027, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void PopulateTeammateDisplays(List<PlayerModel> teammates)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)teammates);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_PopulateTeammateDisplays_Public_Void_List_1_PlayerModel_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 96029, XrefRangeEnd = 96031, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void PlayTeamJoinedSfx()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_PlayTeamJoinedSfx_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 96031, XrefRangeEnd = 96035, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void UpdateLocalPlayerDisplay()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_UpdateLocalPlayerDisplay_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(3)]
	[CachedScanResults(RefRangeStart = 96066, RefRangeEnd = 96069, XrefRangeStart = 96035, XrefRangeEnd = 96066, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void UpdateGameModes(Il2CppReferenceArray<GameModeModel> gameModes)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)gameModes);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_UpdateGameModes_Public_Void_Il2CppReferenceArray_1_GameModeModel_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 96079, RefRangeEnd = 96080, XrefRangeStart = 96069, XrefRangeEnd = 96079, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void UpdateReadyStatus(string accountId, bool isReady, bool isInQueue)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[3];
		*ptr = IL2CPP.ManagedStringToIl2Cpp(accountId);
		*(bool**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = &isReady;
		*(bool**)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(System.IntPtr)))) = &isInQueue;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_UpdateReadyStatus_Public_Void_String_Boolean_Boolean_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(3)]
	[CachedScanResults(RefRangeStart = 96089, RefRangeEnd = 96092, XrefRangeStart = 96080, XrefRangeEnd = 96089, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void UpdateDailyRewardData(LobbyDataModel.DailyReward dailyRewardData)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)dailyRewardData);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_UpdateDailyRewardData_Public_Void_DailyReward_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(4)]
	[CachedScanResults(RefRangeStart = 96096, RefRangeEnd = 96100, XrefRangeStart = 96092, XrefRangeEnd = 96096, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void OnSoftCurrencyChanged(int amount)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = (nint)(&amount);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_OnSoftCurrencyChanged_Public_Void_Int32_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 96100, XrefRangeEnd = 96104, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void OnFractalsCurrencyChanged(int amount)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = (nint)(&amount);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_OnFractalsCurrencyChanged_Public_Void_Int32_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 96104, XrefRangeEnd = 96108, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void OnCharTokenCurrencyChanged(int amount)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = (nint)(&amount);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_OnCharTokenCurrencyChanged_Public_Void_Int32_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 96116, RefRangeEnd = 96117, XrefRangeStart = 96108, XrefRangeEnd = 96116, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void OnAccountXpChanged(int xpAmount)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = (nint)(&xpAmount);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_OnAccountXpChanged_Public_Void_Int32_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(17738)]
	[CachedScanResults(RefRangeStart = 5595, RefRangeEnd = 23333, XrefRangeStart = 5595, XrefRangeEnd = 23333, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void OnBattlePassXpChanged(int xpAmount)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = (nint)(&xpAmount);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_OnBattlePassXpChanged_Public_Void_Int32_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 96117, XrefRangeEnd = 96123, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void OnDailyRewardProgressChanged(int progress, int max)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[2];
		*ptr = (nint)(&progress);
		*(int**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = &max;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_OnDailyRewardProgressChanged_Public_Void_Int32_Int32_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	public unsafe void QueueCurrencyGoldObtain(int amount)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = (nint)(&amount);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_QueueCurrencyGoldObtain_Public_Void_Int32_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	public unsafe void QueueCurrencyFractalsObtain(int amount)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = (nint)(&amount);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_QueueCurrencyFractalsObtain_Public_Void_Int32_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 96123, RefRangeEnd = 96124, XrefRangeStart = 96123, XrefRangeEnd = 96123, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void QueueCurrencyCharTokensObtain(int amount)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = (nint)(&amount);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_QueueCurrencyCharTokensObtain_Public_Void_Int32_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	public unsafe void QueueAccountXpObtain(int xpAmount)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = (nint)(&xpAmount);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_QueueAccountXpObtain_Public_Void_Int32_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	public unsafe void QueueBattlePassXpObtain(int xpAmount)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = (nint)(&xpAmount);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_QueueBattlePassXpObtain_Public_Void_Int32_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 96124, RefRangeEnd = 96125, XrefRangeStart = 96124, XrefRangeEnd = 96124, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void UpdateAccountPassData(LobbyDataModel _playTabData)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)_playTabData);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_UpdateAccountPassData_Public_Void_LobbyDataModel_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	public unsafe void UpdateBattlePassData(int maxLevel)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = (nint)(&maxLevel);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_UpdateBattlePassData_Public_Void_Int32_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(2)]
	[CachedScanResults(RefRangeStart = 96126, RefRangeEnd = 96128, XrefRangeStart = 96125, XrefRangeEnd = 96126, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void UpdateGoldCurrency(int balance)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = (nint)(&balance);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_UpdateGoldCurrency_Public_Void_Int32_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 96128, XrefRangeEnd = 96129, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void UpdateFractalsCurrency(int balance)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = (nint)(&balance);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_UpdateFractalsCurrency_Public_Void_Int32_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 96133, RefRangeEnd = 96134, XrefRangeStart = 96129, XrefRangeEnd = 96133, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void UpdateCharTokensCurrency(int balance)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = (nint)(&balance);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_UpdateCharTokensCurrency_Public_Void_Int32_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 96145, RefRangeEnd = 96146, XrefRangeStart = 96134, XrefRangeEnd = 96145, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void UpdateAccountPassXp()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_UpdateAccountPassXp_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(17738)]
	[CachedScanResults(RefRangeStart = 5595, RefRangeEnd = 23333, XrefRangeStart = 5595, XrefRangeEnd = 23333, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void UpdateBapPassXp(BattlePassModel data)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)data);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_UpdateBapPassXp_Public_Void_BattlePassModel_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 96159, RefRangeEnd = 96160, XrefRangeStart = 96146, XrefRangeEnd = 96159, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void PlayerAccountBannerUpdate(string accountId)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.ManagedStringToIl2Cpp(accountId);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_PlayerAccountBannerUpdate_Public_Void_String_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 96175, RefRangeEnd = 96176, XrefRangeStart = 96160, XrefRangeEnd = 96175, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void PlayerAccountLevelUpdate(string accountId)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.ManagedStringToIl2Cpp(accountId);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_PlayerAccountLevelUpdate_Public_Void_String_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 96181, RefRangeEnd = 96182, XrefRangeStart = 96176, XrefRangeEnd = 96181, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void UpdatePlayersOnline(int players)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = (nint)(&players);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_UpdatePlayersOnline_Public_Void_Int32_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(19)]
	[CachedScanResults(RefRangeStart = 96184, RefRangeEnd = 96203, XrefRangeStart = 96182, XrefRangeEnd = 96184, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void ShowLobbyNotification(string message, UILobbyNotificationEntry.MessageType messageType)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[2];
		*ptr = IL2CPP.ManagedStringToIl2Cpp(message);
		*(UILobbyNotificationEntry.MessageType**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = &messageType;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_ShowLobbyNotification_Public_Void_String_MessageType_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(2)]
	[CachedScanResults(RefRangeStart = 96206, RefRangeEnd = 96208, XrefRangeStart = 96203, XrefRangeEnd = 96206, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void SpawnLiveWinnerFeedEntry(string usernames, int squadKills, Il2CppSystem.DateTime time)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[3];
		*ptr = IL2CPP.ManagedStringToIl2Cpp(usernames);
		*(int**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = &squadKills;
		*(Il2CppSystem.DateTime**)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(System.IntPtr)))) = &time;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_SpawnLiveWinnerFeedEntry_Public_Void_String_Int32_DateTime_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 96208, XrefRangeEnd = 96210, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void ShowLiveWinnerFeed()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_ShowLiveWinnerFeed_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 96210, XrefRangeEnd = 96212, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void HideLiveWinnerFeed()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_HideLiveWinnerFeed_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 96212, XrefRangeEnd = 96213, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void UpdateEventChallengeLives(int balance)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = (nint)(&balance);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_UpdateEventChallengeLives_Public_Void_Int32_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(2)]
	[CachedScanResults(RefRangeStart = 96222, RefRangeEnd = 96224, XrefRangeStart = 96213, XrefRangeEnd = 96222, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void UpdateEventPanel(int prizePool, int signUps, int maxSignUps)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[3];
		*ptr = (nint)(&prizePool);
		*(int**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = &signUps;
		*(int**)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(System.IntPtr)))) = &maxSignUps;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_UpdateEventPanel_Public_Void_Int32_Int32_Int32_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 96224, XrefRangeEnd = 96225, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void SetGoldCurrencyPanelUI(int balance)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = (nint)(&balance);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_SetGoldCurrencyPanelUI_Public_Void_Int32_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 96225, XrefRangeEnd = 96226, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void SetFractalsCurrencyPanelUI(int balance)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = (nint)(&balance);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_SetFractalsCurrencyPanelUI_Public_Void_Int32_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(4)]
	[CachedScanResults(RefRangeStart = 96230, RefRangeEnd = 96234, XrefRangeStart = 96226, XrefRangeEnd = 96230, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void SetCharTokenCurrencyPanelUI(int balance)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = (nint)(&balance);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_SetCharTokenCurrencyPanelUI_Public_Void_Int32_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 96234, XrefRangeEnd = 96242, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void SetCurrentBattlePassUI()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_SetCurrentBattlePassUI_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 96243, RefRangeEnd = 96244, XrefRangeStart = 96242, XrefRangeEnd = 96243, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void SetCurrentBattlePassUIRemainingDays(string textStr, bool isEnabled)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[2];
		*ptr = IL2CPP.ManagedStringToIl2Cpp(textStr);
		*(bool**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = &isEnabled;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_SetCurrentBattlePassUIRemainingDays_Public_Void_String_Boolean_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(2)]
	[CachedScanResults(RefRangeStart = 96248, RefRangeEnd = 96250, XrefRangeStart = 96244, XrefRangeEnd = 96248, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void SetCurrentAccountPassUI()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_SetCurrentAccountPassUI_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 96273, RefRangeEnd = 96274, XrefRangeStart = 96250, XrefRangeEnd = 96273, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void SetCurrentDailyRewardUI()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_SetCurrentDailyRewardUI_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 96274, XrefRangeEnd = 96275, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void ShowPopUpLinkCopied(Vector2 screenPos)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = (nint)(&screenPos);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_ShowPopUpLinkCopied_Private_Void_Vector2_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(5)]
	[CachedScanResults(RefRangeStart = 96280, RefRangeEnd = 96285, XrefRangeStart = 96275, XrefRangeEnd = 96280, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void ShowPopUp(Vector2 screenPos, string str)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[2];
		*ptr = (nint)(&screenPos);
		*(System.IntPtr*)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.ManagedStringToIl2Cpp(str);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_ShowPopUp_Public_Void_Vector2_String_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(6)]
	[CachedScanResults(RefRangeStart = 96299, RefRangeEnd = 96305, XrefRangeStart = 96285, XrefRangeEnd = 96299, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void PlayRedeemDeltaSequenceCoroutine()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_PlayRedeemDeltaSequenceCoroutine_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 96305, XrefRangeEnd = 96308, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe IEnumerator RedeemDeltaSequenceCoroutine()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_RedeemDeltaSequenceCoroutine_Private_IEnumerator_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<IEnumerator>(intPtr) : null;
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 96311, RefRangeEnd = 96312, XrefRangeStart = 96308, XrefRangeEnd = 96311, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void CheckForCustomLobby()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_CheckForCustomLobby_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(4)]
	[CachedScanResults(RefRangeStart = 96332, RefRangeEnd = 96336, XrefRangeStart = 96312, XrefRangeEnd = 96332, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void OpenCustomLobbyWindow()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_OpenCustomLobbyWindow_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(5)]
	[CachedScanResults(RefRangeStart = 96356, RefRangeEnd = 96361, XrefRangeStart = 96336, XrefRangeEnd = 96356, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void CloseCustomLobbyWindow()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_CloseCustomLobbyWindow_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(2)]
	[CachedScanResults(RefRangeStart = 96361, RefRangeEnd = 96363, XrefRangeStart = 96361, XrefRangeEnd = 96361, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe int GetCustomLobbyGameModeId()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetCustomLobbyGameModeId_Public_Int32_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(int*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	[CallerCount(2)]
	[CachedScanResults(RefRangeStart = 96363, RefRangeEnd = 96365, XrefRangeStart = 96363, XrefRangeEnd = 96363, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe int GetCurrentSoftCurrency()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetCurrentSoftCurrency_Public_Int32_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(int*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	[CallerCount(0)]
	public unsafe int GetCurrentFractalsCurrency()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetCurrentFractalsCurrency_Public_Int32_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(int*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	[CallerCount(0)]
	public unsafe int GetCurrentTokenCurrency()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetCurrentTokenCurrency_Public_Int32_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(int*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	[CallerCount(3)]
	[CachedScanResults(RefRangeStart = 96365, RefRangeEnd = 96368, XrefRangeStart = 96365, XrefRangeEnd = 96365, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe int GetCurrencyBalanceFromAssetId(int assetId)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = (nint)(&assetId);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetCurrencyBalanceFromAssetId_Public_Int32_Int32_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(int*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 96368, RefRangeEnd = 96369, XrefRangeStart = 96368, XrefRangeEnd = 96368, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe int GetSelectedBannerAssetId()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetSelectedBannerAssetId_Public_Int32_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(int*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	[CallerCount(2)]
	[CachedScanResults(RefRangeStart = 96369, RefRangeEnd = 96371, XrefRangeStart = 96369, XrefRangeEnd = 96369, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe bool IsPlayerBannerAssetIdEquiped(int bannerAssetId)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = (nint)(&bannerAssetId);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_IsPlayerBannerAssetIdEquiped_Public_Boolean_Int32_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(bool*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	[CallerCount(0)]
	public unsafe int GetSelectedSkinAssetId(int charId)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = (nint)(&charId);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetSelectedSkinAssetId_Public_Int32_Int32_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(int*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	[CallerCount(5)]
	[CachedScanResults(RefRangeStart = 96371, RefRangeEnd = 96376, XrefRangeStart = 96371, XrefRangeEnd = 96371, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe bool IsSkinAssetIdEquipped(int charId, int skinAssetId)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[2];
		*ptr = (nint)(&charId);
		*(int**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = &skinAssetId;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_IsSkinAssetIdEquipped_Public_Boolean_Int32_Int32_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(bool*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	[CallerCount(2)]
	[CachedScanResults(RefRangeStart = 96376, RefRangeEnd = 96378, XrefRangeStart = 96376, XrefRangeEnd = 96376, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe int GetAccountLevelXpNeeded(int level)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = (nint)(&level);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetAccountLevelXpNeeded_Public_Int32_Int32_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(int*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 96378, XrefRangeEnd = 96379, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe int GetCurrentAccountLevelXpNeeded(int level)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = (nint)(&level);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetCurrentAccountLevelXpNeeded_Public_Int32_Int32_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(int*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	[CallerCount(0)]
	public unsafe int GetAccountXp()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetAccountXp_Public_Int32_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(int*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	[CallerCount(0)]
	public unsafe int GetPrevAccountXp()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetPrevAccountXp_Public_Int32_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(int*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	[CallerCount(0)]
	public unsafe int GetAccountPrevLevel()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetAccountPrevLevel_Public_Int32_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(int*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	[CallerCount(0)]
	public unsafe int GetAccountLevel()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetAccountLevel_Public_Int32_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(int*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	[CallerCount(0)]
	public unsafe int GetAccountMaxLevel()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetAccountMaxLevel_Public_Int32_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(int*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	[CallerCount(0)]
	public unsafe int GetBapPassXp()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetBapPassXp_Public_Int32_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(int*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	[CallerCount(0)]
	public unsafe int GetBapPassPrevXp()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetBapPassPrevXp_Public_Int32_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(int*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	[CallerCount(0)]
	public unsafe int GetBapPassPreviousLevel()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetBapPassPreviousLevel_Public_Int32_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(int*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	[CallerCount(0)]
	public unsafe int GetBapPassLevel()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetBapPassLevel_Public_Int32_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(int*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	[CallerCount(0)]
	public unsafe int GetBapPassMaxLevel()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetBapPassMaxLevel_Public_Int32_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(int*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	[CallerCount(0)]
	public unsafe int GetDailyProgress()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetDailyProgress_Public_Int32_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(int*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	[CallerCount(0)]
	public unsafe int GetPrevDailyProgress()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetPrevDailyProgress_Public_Int32_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(int*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	[CallerCount(0)]
	public unsafe int GetDailyProgressMax()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetDailyProgressMax_Public_Int32_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(int*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 96379, XrefRangeEnd = 96384, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe int GetAccountLevelFromXp(int xp)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = (nint)(&xp);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetAccountLevelFromXp_Public_Int32_Int32_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(int*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	[CallerCount(2)]
	[CachedScanResults(RefRangeStart = 96384, RefRangeEnd = 96386, XrefRangeStart = 96384, XrefRangeEnd = 96384, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe bool IsUserGuest()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_IsUserGuest_Public_Boolean_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(bool*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	[CallerCount(3)]
	[CachedScanResults(RefRangeStart = 96388, RefRangeEnd = 96391, XrefRangeStart = 96386, XrefRangeEnd = 96388, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe bool PlayerOwnsAssetId(int assetId)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = (nint)(&assetId);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_PlayerOwnsAssetId_Public_Boolean_Int32_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(bool*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	[CallerCount(7)]
	[CachedScanResults(RefRangeStart = 96397, RefRangeEnd = 96404, XrefRangeStart = 96391, XrefRangeEnd = 96397, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void EnableInteractableContents()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_EnableInteractableContents_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(8)]
	[CachedScanResults(RefRangeStart = 96410, RefRangeEnd = 96418, XrefRangeStart = 96404, XrefRangeEnd = 96410, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void DisableInteractableContents()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_DisableInteractableContents_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 96418, XrefRangeEnd = 96423, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void ClickNewReadyButton()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_ClickNewReadyButton_Private_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 96423, XrefRangeEnd = 96426, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void ClickReadyButton()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_ClickReadyButton_Private_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 96426, XrefRangeEnd = 96427, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void ClickUnreadyButton()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_ClickUnreadyButton_Private_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 96427, XrefRangeEnd = 96428, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void ClickCancelButton()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_ClickCancelButton_Private_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 96428, XrefRangeEnd = 96431, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void HidePlayButton()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_HidePlayButton_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(8)]
	[CachedScanResults(RefRangeStart = 96432, RefRangeEnd = 96440, XrefRangeStart = 96431, XrefRangeEnd = 96432, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void ShowPlayReadyButton()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_ShowPlayReadyButton_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 96440, XrefRangeEnd = 96441, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void ShowPlayUnreadyButton()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_ShowPlayUnreadyButton_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 96442, RefRangeEnd = 96443, XrefRangeStart = 96441, XrefRangeEnd = 96442, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void ShowPlayCancelButton()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_ShowPlayCancelButton_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	public unsafe void SetPlayButtonCooldown()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_SetPlayButtonCooldown_Private_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 96443, XrefRangeEnd = 96451, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void OnPlayButtonCooldownEnded()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_OnPlayButtonCooldownEnded_Private_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 96451, XrefRangeEnd = 96453, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void ShowMaintenanceMessage()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_ShowMaintenanceMessage_Private_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 96453, XrefRangeEnd = 96455, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void HideMaintenanceMessage()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_HideMaintenanceMessage_Private_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 96455, XrefRangeEnd = 96464, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void OnCommunityChallengeReadyButtonPressed()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_OnCommunityChallengeReadyButtonPressed_Private_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 96464, XrefRangeEnd = 96469, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void OpenChallengeEventWarningPopUp()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_OpenChallengeEventWarningPopUp_Private_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(2)]
	[CachedScanResults(RefRangeStart = 96474, RefRangeEnd = 96476, XrefRangeStart = 96469, XrefRangeEnd = 96474, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void CloseChallengeEventDisclaimerPopUp()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_CloseChallengeEventDisclaimerPopUp_Private_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 96476, XrefRangeEnd = 96481, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void OpenChallengeEventNoMoreLivesPopUp()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_OpenChallengeEventNoMoreLivesPopUp_Private_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(2)]
	[CachedScanResults(RefRangeStart = 96486, RefRangeEnd = 96488, XrefRangeStart = 96481, XrefRangeEnd = 96486, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void CloseChallengeEventOutOfLivesPopUp()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_CloseChallengeEventOutOfLivesPopUp_Private_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 96488, XrefRangeEnd = 96491, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void UpdateDailyRewardResfreshUI(Il2CppSystem.TimeSpan timeSpan)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = (nint)(&timeSpan);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_UpdateDailyRewardResfreshUI_Private_Void_TimeSpan_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 96491, XrefRangeEnd = 96492, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void OnDailyRewardRefreshEnded()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_OnDailyRewardRefreshEnded_Private_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 96492, XrefRangeEnd = 96493, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void ShowBattlePass()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_ShowBattlePass_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 96493, XrefRangeEnd = 96494, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void HideBattlePass()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_HideBattlePass_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 96494, XrefRangeEnd = 96497, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void CloseMatchStartPanel()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_CloseMatchStartPanel_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 96506, RefRangeEnd = 96507, XrefRangeStart = 96497, XrefRangeEnd = 96506, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void AnimateCharacterSelect(float t)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = (nint)(&t);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_AnimateCharacterSelect_Private_Void_Single_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(4)]
	[CachedScanResults(RefRangeStart = 96522, RefRangeEnd = 96526, XrefRangeStart = 96507, XrefRangeEnd = 96522, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void SetAndShowPlayerDisplay(PlayerDisplay display, PlayerModel player)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[2];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)display);
		*(System.IntPtr*)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)player);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_SetAndShowPlayerDisplay_Private_Void_PlayerDisplay_PlayerModel_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 96526, XrefRangeEnd = 96530, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void UpdatePlayerDisplayLevel(PlayerDisplay display, PlayerModel player)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[2];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)display);
		*(System.IntPtr*)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)player);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_UpdatePlayerDisplayLevel_Private_Void_PlayerDisplay_PlayerModel_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 96530, XrefRangeEnd = 96531, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void UpdatePlayerDisplayBanner(PlayerDisplay display, PlayerBanner banner)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[2];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)display);
		*(System.IntPtr*)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)banner);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_UpdatePlayerDisplayBanner_Private_Void_PlayerDisplay_PlayerBanner_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 96533, RefRangeEnd = 96534, XrefRangeStart = 96531, XrefRangeEnd = 96533, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void PlayPlayerCharJoinSfx()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_PlayPlayerCharJoinSfx_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(2)]
	[CachedScanResults(RefRangeStart = 96537, RefRangeEnd = 96539, XrefRangeStart = 96534, XrefRangeEnd = 96537, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void ShowPlayerReadys()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_ShowPlayerReadys_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 96542, RefRangeEnd = 96543, XrefRangeStart = 96539, XrefRangeEnd = 96542, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void HidePlayerReadys()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_HidePlayerReadys_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(17738)]
	[CachedScanResults(RefRangeStart = 5595, RefRangeEnd = 23333, XrefRangeStart = 5595, XrefRangeEnd = 23333, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void SetPlayerCharDisplaySprite(Sprite charSprite)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)charSprite);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_SetPlayerCharDisplaySprite_Public_Void_Sprite_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(2)]
	[CachedScanResults(RefRangeStart = 94986, RefRangeEnd = 94988, XrefRangeStart = 94986, XrefRangeEnd = 94988, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void HideCharacterDisplay(PlayerDisplay display)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)display);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_HideCharacterDisplay_Private_Void_PlayerDisplay_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 96543, XrefRangeEnd = 96547, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe PlayerBanner GetDefaultPlayerBanner()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetDefaultPlayerBanner_Public_PlayerBanner_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<PlayerBanner>(intPtr) : null;
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 96547, XrefRangeEnd = 96549, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe PlayerBanner GetPlayerBannerFromAcountId(string accountId)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.ManagedStringToIl2Cpp(accountId);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetPlayerBannerFromAcountId_Public_PlayerBanner_String_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<PlayerBanner>(intPtr) : null;
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 96584, RefRangeEnd = 96585, XrefRangeStart = 96549, XrefRangeEnd = 96584, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void OpenPlayerOptionDropdown(RectTransform rectTransform)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)rectTransform);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_OpenPlayerOptionDropdown_Private_Void_RectTransform_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(2)]
	[CachedScanResults(RefRangeStart = 96629, RefRangeEnd = 96631, XrefRangeStart = 96585, XrefRangeEnd = 96629, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void OpenTeammateOptionDropdown(string accountId, RectTransform rectTransform)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[2];
		*ptr = IL2CPP.ManagedStringToIl2Cpp(accountId);
		*(System.IntPtr*)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)rectTransform);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_OpenTeammateOptionDropdown_Public_Void_String_RectTransform_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 96633, RefRangeEnd = 96634, XrefRangeStart = 96631, XrefRangeEnd = 96633, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void OnTeammateOptionKick(string accountId)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.ManagedStringToIl2Cpp(accountId);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_OnTeammateOptionKick_Private_Void_String_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(2)]
	[CachedScanResults(RefRangeStart = 96637, RefRangeEnd = 96639, XrefRangeStart = 96634, XrefRangeEnd = 96637, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void ShowInviteButton(InviteButton invite)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)invite);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_ShowInviteButton_Private_Void_InviteButton_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(2)]
	[CachedScanResults(RefRangeStart = 96642, RefRangeEnd = 96644, XrefRangeStart = 96639, XrefRangeEnd = 96642, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void HideInviteButton(InviteButton invite)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)invite);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_HideInviteButton_Private_Void_InviteButton_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 96647, RefRangeEnd = 96648, XrefRangeStart = 96644, XrefRangeEnd = 96647, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void ShowLoader(TeammateLoader loader)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)loader);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_ShowLoader_Private_Void_TeammateLoader_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(5)]
	[CachedScanResults(RefRangeStart = 96651, RefRangeEnd = 96656, XrefRangeStart = 96648, XrefRangeEnd = 96651, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void HideLoader(TeammateLoader loader)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)loader);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_HideLoader_Private_Void_TeammateLoader_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(2)]
	[CachedScanResults(RefRangeStart = 96667, RefRangeEnd = 96669, XrefRangeStart = 96656, XrefRangeEnd = 96667, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void ShowGmPairingTeamSpinners()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_ShowGmPairingTeamSpinners_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(2)]
	[CachedScanResults(RefRangeStart = 96672, RefRangeEnd = 96674, XrefRangeStart = 96669, XrefRangeEnd = 96672, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void HideAllPairingTeamSpinners()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_HideAllPairingTeamSpinners_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 96677, RefRangeEnd = 96678, XrefRangeStart = 96674, XrefRangeEnd = 96677, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void HideAllInviteButton()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_HideAllInviteButton_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 96690, RefRangeEnd = 96691, XrefRangeStart = 96678, XrefRangeEnd = 96690, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void OnInviteButtonPressed(InviteButton invite)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)invite);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_OnInviteButtonPressed_Private_Void_InviteButton_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 96701, RefRangeEnd = 96702, XrefRangeStart = 96691, XrefRangeEnd = 96701, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void OnFriendsButtonPressed()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_OnFriendsButtonPressed_Private_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 96702, XrefRangeEnd = 96705, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void OnReferralCodeButtonPressed()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_OnReferralCodeButtonPressed_Private_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 96705, XrefRangeEnd = 96712, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void SetInviteCodesRemainingUses(int usesLeft, int usesTotal)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[2];
		*ptr = (nint)(&usesLeft);
		*(int**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = &usesTotal;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_SetInviteCodesRemainingUses_Public_Void_Int32_Int32_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(4)]
	[CachedScanResults(RefRangeStart = 96715, RefRangeEnd = 96719, XrefRangeStart = 96712, XrefRangeEnd = 96715, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void OpenOptionDropdown(Vector2 screenPos)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = (nint)(&screenPos);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_OpenOptionDropdown_Private_Void_Vector2_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(2)]
	[CachedScanResults(RefRangeStart = 96721, RefRangeEnd = 96723, XrefRangeStart = 96719, XrefRangeEnd = 96721, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void CloseOptionDropdown()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_CloseOptionDropdown_Private_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 96701, RefRangeEnd = 96702, XrefRangeStart = 96701, XrefRangeEnd = 96702, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void ShowFriendsPanel()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_ShowFriendsPanel_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(4)]
	[CachedScanResults(RefRangeStart = 96735, RefRangeEnd = 96739, XrefRangeStart = 96723, XrefRangeEnd = 96735, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void CloseFriendsPanel()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_CloseFriendsPanel_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 96739, XrefRangeEnd = 96743, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void FriendsPanelSetGuestMode(bool isGuest)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = (nint)(&isGuest);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_FriendsPanelSetGuestMode_Private_Void_Boolean_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 96743, XrefRangeEnd = 96745, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void OnAddFriendPopupButton()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_OnAddFriendPopupButton_Private_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 96745, XrefRangeEnd = 96753, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void OpenAddFriendPopup()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_OpenAddFriendPopup_Private_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(3)]
	[CachedScanResults(RefRangeStart = 96758, RefRangeEnd = 96761, XrefRangeStart = 96753, XrefRangeEnd = 96758, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void CloseAddFriendPopup()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_CloseAddFriendPopup_Private_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 96761, XrefRangeEnd = 96763, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void OnJoinLobbyPopupButton()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_OnJoinLobbyPopupButton_Private_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 96763, XrefRangeEnd = 96771, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void OpenJoinLobbyPopup()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_OpenJoinLobbyPopup_Private_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(4)]
	[CachedScanResults(RefRangeStart = 96776, RefRangeEnd = 96780, XrefRangeStart = 96771, XrefRangeEnd = 96776, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void CloseJoinLobbyPopup()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_CloseJoinLobbyPopup_Private_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(4)]
	[CachedScanResults(RefRangeStart = 96784, RefRangeEnd = 96788, XrefRangeStart = 96780, XrefRangeEnd = 96784, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void SetButtonSelectedState(MultiGraphicButton button, bool isSelected, Il2CppStructArray<Color> normalColors)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[3];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)button);
		*(bool**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = &isSelected;
		*(System.IntPtr*)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)normalColors);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_SetButtonSelectedState_Private_Void_MultiGraphicButton_Boolean_Il2CppStructArray_1_Color_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(5)]
	[CachedScanResults(RefRangeStart = 96835, RefRangeEnd = 96840, XrefRangeStart = 96788, XrefRangeEnd = 96835, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void UpdateFriendsPreview()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_UpdateFriendsPreview_Private_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 96840, XrefRangeEnd = 96845, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void OpenFriendInviteNotification()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_OpenFriendInviteNotification_Private_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 96849, RefRangeEnd = 96850, XrefRangeStart = 96845, XrefRangeEnd = 96849, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void CloseFriendInviteNotification()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_CloseFriendInviteNotification_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 96850, XrefRangeEnd = 96860, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void InitialiseFriendInviteNotification(string username, string lobbyCode)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[2];
		*ptr = IL2CPP.ManagedStringToIl2Cpp(username);
		*(System.IntPtr*)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.ManagedStringToIl2Cpp(lobbyCode);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_InitialiseFriendInviteNotification_Private_Void_String_String_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 96861, RefRangeEnd = 96862, XrefRangeStart = 96860, XrefRangeEnd = 96861, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void OnFriendInviteLobbyNotificationJoin(string lobbyCode)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.ManagedStringToIl2Cpp(lobbyCode);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_OnFriendInviteLobbyNotificationJoin_Private_Void_String_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(2)]
	[CachedScanResults(RefRangeStart = 96862, RefRangeEnd = 96864, XrefRangeStart = 96862, XrefRangeEnd = 96862, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void SendFriendInvite(string username, int discriminator)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[2];
		*ptr = IL2CPP.ManagedStringToIl2Cpp(username);
		*(int**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = &discriminator;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_SendFriendInvite_Public_Void_String_Int32_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(2)]
	[CachedScanResults(RefRangeStart = 96875, RefRangeEnd = 96877, XrefRangeStart = 96864, XrefRangeEnd = 96875, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void UpdateFriendLocalPlayerAvatar(int avatarId)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = (nint)(&avatarId);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_UpdateFriendLocalPlayerAvatar_Private_Void_Int32_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(2)]
	[CachedScanResults(RefRangeStart = 96884, RefRangeEnd = 96886, XrefRangeStart = 96877, XrefRangeEnd = 96884, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void SetHideLobbyCodeButton(bool _hideLobbyCode)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = (nint)(&_hideLobbyCode);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_SetHideLobbyCodeButton_Private_Void_Boolean_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(2)]
	[CachedScanResults(RefRangeStart = 96887, RefRangeEnd = 96889, XrefRangeStart = 96886, XrefRangeEnd = 96887, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void SetLobbyIdCode(string lobbyId)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.ManagedStringToIl2Cpp(lobbyId);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_SetLobbyIdCode_Private_Void_String_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 96889, XrefRangeEnd = 96903, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void SendFriendLobbyInvite(UILobbyFriendEntry entry)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)entry);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_SendFriendLobbyInvite_Private_Void_UILobbyFriendEntry_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 96904, RefRangeEnd = 96905, XrefRangeStart = 96903, XrefRangeEnd = 96904, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void SendSteamFriendLobbyInvite(UILobbyFriendEntry entry, SteamManager.SteamFriend steamFriend)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[2];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)entry);
		*(System.IntPtr*)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)steamFriend);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_SendSteamFriendLobbyInvite_Private_Void_UILobbyFriendEntry_SteamFriend_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 96905, XrefRangeEnd = 96913, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void InitializeFriendsPanel()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_InitializeFriendsPanel_Private_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(3)]
	[CachedScanResults(RefRangeStart = 96925, RefRangeEnd = 96928, XrefRangeStart = 96913, XrefRangeEnd = 96925, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void ClearFriendsPanel()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_ClearFriendsPanel_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 96928, XrefRangeEnd = 96964, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void PopulateFriendsPanel()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_PopulateFriendsPanel_Private_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(3)]
	[CachedScanResults(RefRangeStart = 97006, RefRangeEnd = 97009, XrefRangeStart = 96964, XrefRangeEnd = 97006, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void PopulateSteamFriendsPanel()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_PopulateSteamFriendsPanel_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	public unsafe List<UILobbyFriendEntry> GetFriendListEntries()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetFriendListEntries_Public_List_1_UILobbyFriendEntry_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<List<UILobbyFriendEntry>>(intPtr) : null;
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 97009, XrefRangeEnd = 97014, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void OnFriendEntrySelected(UILobbyFriendEntry friendEntry)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)friendEntry);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_OnFriendEntrySelected_Private_Void_UILobbyFriendEntry_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 97021, RefRangeEnd = 97022, XrefRangeStart = 97014, XrefRangeEnd = 97021, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void OpenOptionDropdown(string accountId, RectTransform rectTransform)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[2];
		*ptr = IL2CPP.ManagedStringToIl2Cpp(accountId);
		*(System.IntPtr*)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)rectTransform);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_OpenOptionDropdown_Private_Void_String_RectTransform_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(3)]
	[CachedScanResults(RefRangeStart = 97086, RefRangeEnd = 97089, XrefRangeStart = 97022, XrefRangeEnd = 97086, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void RefreshFriendOptionsDropdown(string accountId)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.ManagedStringToIl2Cpp(accountId);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_RefreshFriendOptionsDropdown_Public_Void_String_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 97091, RefRangeEnd = 97092, XrefRangeStart = 97089, XrefRangeEnd = 97091, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void OnFriendOptionJoinLobby(string accountId)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.ManagedStringToIl2Cpp(accountId);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_OnFriendOptionJoinLobby_Private_Void_String_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 97120, RefRangeEnd = 97121, XrefRangeStart = 97092, XrefRangeEnd = 97120, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void OnFriendOptionInviteToGame(string accountId)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.ManagedStringToIl2Cpp(accountId);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_OnFriendOptionInviteToGame_Private_Void_String_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(2)]
	[CachedScanResults(RefRangeStart = 97144, RefRangeEnd = 97146, XrefRangeStart = 97121, XrefRangeEnd = 97144, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void OnFriendOptionDirectMessage(string accountId)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.ManagedStringToIl2Cpp(accountId);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_OnFriendOptionDirectMessage_Private_Void_String_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 97157, RefRangeEnd = 97158, XrefRangeStart = 97146, XrefRangeEnd = 97157, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void OnFriendOptionUnfriend(string accountId)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.ManagedStringToIl2Cpp(accountId);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_OnFriendOptionUnfriend_Private_Void_String_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 97191, RefRangeEnd = 97192, XrefRangeStart = 97158, XrefRangeEnd = 97191, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void InitializeRequestsPanel()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_InitializeRequestsPanel_Private_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(2)]
	[CachedScanResults(RefRangeStart = 97196, RefRangeEnd = 97198, XrefRangeStart = 97192, XrefRangeEnd = 97196, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void UpdateFriendRequestsNotification()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_UpdateFriendRequestsNotification_Private_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(5)]
	[CachedScanResults(RefRangeStart = 97205, RefRangeEnd = 97210, XrefRangeStart = 97198, XrefRangeEnd = 97205, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void UpdateFriendEntryHolders()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_UpdateFriendEntryHolders_Private_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 97210, XrefRangeEnd = 97214, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void OnSendFriendLobbyInvite(string username)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.ManagedStringToIl2Cpp(username);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_OnSendFriendLobbyInvite_Private_Void_String_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 97220, RefRangeEnd = 97221, XrefRangeStart = 97214, XrefRangeEnd = 97220, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void OnSendFriendRequestSuccess(string usernameId)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.ManagedStringToIl2Cpp(usernameId);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_OnSendFriendRequestSuccess_Public_Void_String_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 97223, RefRangeEnd = 97224, XrefRangeStart = 97221, XrefRangeEnd = 97223, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void OnSendFriendRequestFail(string errorStr)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.ManagedStringToIl2Cpp(errorStr);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_OnSendFriendRequestFail_Public_Void_String_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 97226, RefRangeEnd = 97227, XrefRangeStart = 97224, XrefRangeEnd = 97226, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void OnFriendRequestAcceptSuccess(string accountId)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.ManagedStringToIl2Cpp(accountId);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_OnFriendRequestAcceptSuccess_Public_Void_String_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 97228, RefRangeEnd = 97229, XrefRangeStart = 97227, XrefRangeEnd = 97228, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void OnFriendRequestDeclineSuccess(string accountId)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.ManagedStringToIl2Cpp(accountId);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_OnFriendRequestDeclineSuccess_Public_Void_String_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(4)]
	[CachedScanResults(RefRangeStart = 97248, RefRangeEnd = 97252, XrefRangeStart = 97229, XrefRangeEnd = 97248, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void TryRemoveFriendRequest(string accountId)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.ManagedStringToIl2Cpp(accountId);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_TryRemoveFriendRequest_Private_Void_String_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(10)]
	[CachedScanResults(RefRangeStart = 97267, RefRangeEnd = 97277, XrefRangeStart = 97252, XrefRangeEnd = 97267, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe string GetUsernameId(string username, int discriminator)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[2];
		*ptr = IL2CPP.ManagedStringToIl2Cpp(username);
		*(int**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = &discriminator;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetUsernameId_Public_String_String_Int32_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return IL2CPP.Il2CppStringToManaged(intPtr);
	}

	[CallerCount(4)]
	[CachedScanResults(RefRangeStart = 97279, RefRangeEnd = 97283, XrefRangeStart = 97277, XrefRangeEnd = 97279, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe Texture2D GetFriendAvatar(int avatarId)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = (nint)(&avatarId);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetFriendAvatar_Public_Texture2D_Int32_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Texture2D>(intPtr) : null;
	}

	[CallerCount(6)]
	[CachedScanResults(RefRangeStart = 97284, RefRangeEnd = 97290, XrefRangeStart = 97283, XrefRangeEnd = 97284, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe Vector2 GetFriendAvatarOffset(int avatarId)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = (nint)(&avatarId);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetFriendAvatarOffset_Public_Vector2_Int32_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(Vector2*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	[CallerCount(6)]
	[CachedScanResults(RefRangeStart = 97291, RefRangeEnd = 97297, XrefRangeStart = 97290, XrefRangeEnd = 97291, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe Vector2 GetFriendAvatarSize(int avatarId)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = (nint)(&avatarId);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetFriendAvatarSize_Public_Vector2_Int32_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(Vector2*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	[CallerCount(4)]
	[CachedScanResults(RefRangeStart = 97306, RefRangeEnd = 97310, XrefRangeStart = 97297, XrefRangeEnd = 97306, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe bool PlayerIsFriend(string accountId)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.ManagedStringToIl2Cpp(accountId);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_PlayerIsFriend_Public_Boolean_String_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(bool*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 97313, RefRangeEnd = 97314, XrefRangeStart = 97310, XrefRangeEnd = 97313, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void ShowGameModeButton()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_ShowGameModeButton_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 97317, RefRangeEnd = 97318, XrefRangeStart = 97314, XrefRangeEnd = 97317, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void HideGameModeButton()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_HideGameModeButton_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 97321, RefRangeEnd = 97322, XrefRangeStart = 97318, XrefRangeEnd = 97321, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void SetSelectedGameMode()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_SetSelectedGameMode_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(2)]
	[CachedScanResults(RefRangeStart = 97338, RefRangeEnd = 97340, XrefRangeStart = 97322, XrefRangeEnd = 97338, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void SetGameModeSelectButton(int gameModeId)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = (nint)(&gameModeId);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_SetGameModeSelectButton_Private_Void_Int32_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 97344, RefRangeEnd = 97345, XrefRangeStart = 97340, XrefRangeEnd = 97344, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void GameModeSelectButtonEventEnable(UILobbyGameModeButton eventGmButton)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)eventGmButton);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GameModeSelectButtonEventEnable_Public_Void_UILobbyGameModeButton_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 97346, RefRangeEnd = 97347, XrefRangeStart = 97345, XrefRangeEnd = 97346, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void GameModeSelectButtonEventDisable()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GameModeSelectButtonEventDisable_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(4)]
	[CachedScanResults(RefRangeStart = 97349, RefRangeEnd = 97353, XrefRangeStart = 97347, XrefRangeEnd = 97349, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void SetGameModeSelectLoader(bool loaderEnabled)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = (nint)(&loaderEnabled);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_SetGameModeSelectLoader_Public_Void_Boolean_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 97357, RefRangeEnd = 97358, XrefRangeStart = 97353, XrefRangeEnd = 97357, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void ShowQueuePanel()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_ShowQueuePanel_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(2)]
	[CachedScanResults(RefRangeStart = 97362, RefRangeEnd = 97364, XrefRangeStart = 97358, XrefRangeEnd = 97362, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void HideQueuePanel()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_HideQueuePanel_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 97370, RefRangeEnd = 97371, XrefRangeStart = 97364, XrefRangeEnd = 97370, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void SetQueuePanelPlayerCount()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_SetQueuePanelPlayerCount_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(2)]
	[CachedScanResults(RefRangeStart = 97380, RefRangeEnd = 97382, XrefRangeStart = 97371, XrefRangeEnd = 97380, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void SetQueuePanelElapsedTime(double elapsedTime)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = (nint)(&elapsedTime);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_SetQueuePanelElapsedTime_Public_Void_Double_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 97385, RefRangeEnd = 97386, XrefRangeStart = 97382, XrefRangeEnd = 97385, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void SetQueueStateInQueue()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_SetQueueStateInQueue_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 97386, XrefRangeEnd = 97389, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void SetQueueStateQueueMatched()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_SetQueueStateQueueMatched_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(2)]
	[CachedScanResults(RefRangeStart = 97392, RefRangeEnd = 97394, XrefRangeStart = 97389, XrefRangeEnd = 97392, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void SetQueueStateInQueueNoCounts()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_SetQueueStateInQueueNoCounts_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 97401, RefRangeEnd = 97402, XrefRangeStart = 97394, XrefRangeEnd = 97401, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void SetGameModePanelName()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_SetGameModePanelName_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(2)]
	[CachedScanResults(RefRangeStart = 97406, RefRangeEnd = 97408, XrefRangeStart = 97402, XrefRangeEnd = 97406, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void JoinLobbyVoiceChannel()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_JoinLobbyVoiceChannel_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 97408, XrefRangeEnd = 97417, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe UILobbyPlayTabPage()
		: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<UILobbyPlayTabPage>.NativeClassPtr))
	{
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	public unsafe bool _Localise_b__193_0(GameModesConfiguration.GameModeConfiguration gameMode)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)gameMode);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__Localise_b__193_0_Private_Boolean_GameModeConfiguration_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(bool*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 97417, XrefRangeEnd = 97420, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void _OpenPlayerOptionDropdown_b__363_0()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__OpenPlayerOptionDropdown_b__363_0_Private_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	public unsafe bool _ShowGmPairingTeamSpinners_b__370_0(GameModesConfiguration.GameModeConfiguration gameMode)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)gameMode);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ShowGmPairingTeamSpinners_b__370_0_Private_Boolean_GameModeConfiguration_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(bool*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	[CallerCount(0)]
	public unsafe bool _SetGameModePanelName_b__440_0(GameModesConfiguration.GameModeConfiguration gameMode)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)gameMode);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__SetGameModePanelName_b__440_0_Private_Boolean_GameModeConfiguration_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(bool*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	public UILobbyPlayTabPage(System.IntPtr pointer)
		: base(pointer)
	{
	}
}
