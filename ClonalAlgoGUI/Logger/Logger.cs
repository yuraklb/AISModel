using System;

namespace ClonalAlgoGUI
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

		public static void Clear()
		{
			mListStore.Clear();
		}

		public static void AddDataView(ClonalAlgo.DataView pDv)
		{
			mListStore.AppendValues("", pDv.mAg.ToString(),  "ANTIGENE");

			int number_of_population = 0;

			foreach (var item in pDv.mPopulations) {

				mListStore.AppendValues(number_of_population.ToString(), item.GetBestAntibody().ToString(), "");
				number_of_population++;
			}

			mListStore.AppendValues("", pDv.mAg.ToString(), "ANTIGENE");

		}
	}
}

