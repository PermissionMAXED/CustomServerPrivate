using System;
using System.Collections.Generic;
using UnityEngine;

namespace LevelEditor
{
	public static class MapBookmarks
	{
		public class BookmarkWrapper
		{
			public List<Bookmark> bookmarks;

			public BookmarkWrapper(List<Bookmark> bookmarks)
			{
			}
		}

		[Serializable]
		public class Bookmark
		{
			public Vector3 camPosition;

			public Quaternion camRotation;

			public string bookmarkDescription;

			public Vector2Int bookmarkSize;

			public Vector2Int bookmarkCenter;

			public bool useSelectionToSetView;

			public bool DrawBookmarkGUI()
			{
				return false;
			}
		}

		public static bool showBookmarks;

		public static bool showUtilities;

		public static int saveSlots;

		public static List<Bookmark> bookmarks;

		public static void DrawBookmarkGUI()
		{
		}

		public static void SaveBookmarks(int saveSlot)
		{
		}

		public static void LoadBookmarks(int saveSlot)
		{
		}

		public static void DeleteBookmark(int saveSlot)
		{
		}
	}
}
