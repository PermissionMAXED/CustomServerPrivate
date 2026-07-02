using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace LevelEditor
{
	public static class GUIDock
	{
		public delegate void DockedGUIDelegate(bool onDock);

		public static Vector2 dockScrollviewPos;

		public static bool dockActive;

		public static readonly Texture2D dockIcon;

		public static readonly Texture2D undockIcon;

		public static HashSet<DockedGUIDelegate> dockedDelegates;

		public static bool hidden;

		public static Configuration Config => null;

		public static Rect dockRect => default(Rect);

		public static event DockedGUIDelegate DockedGUIEvent
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

		public static void DockGUIMethod(DockedGUIDelegate dockDelegate)
		{
		}

		public static void UndockGUIMethod(DockedGUIDelegate dockDelegate)
		{
		}

		public static void DrawDockedGUI()
		{
		}

		public static bool ScreenPositionIsOverDock(Vector3 position)
		{
			return false;
		}

		public static void DrawDockingButtons(bool onDock, DockedGUIDelegate dockDelegate)
		{
		}
	}
}
