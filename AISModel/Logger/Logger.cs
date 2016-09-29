using System;

namespace AISModel
{
	public static class Logger
	{
		private static Gtk.ListStore mListStore;

		public static void SetLogger(Gtk.ListStore pListStore) {
			mListStore = pListStore;
		}

		public static void AddLine(string p1, string p2, string p3) {
			mListStore.AppendValues(p1, p2, p3);
		}
	}
}

