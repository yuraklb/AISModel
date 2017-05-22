using System;
using System.Collections.Generic;

namespace ClonalAlgo
{
	public static class Helper
	{
		public static int CellSize = 50;

		public static int NumberOfGeneration = 330;

		public static int NumberOfAntibody = 10;

		public static int PercentToInt(int perc100, int cur)
		{
			int perc1 = (int)(perc100 / 100);
			int res = (int)(cur / perc1);

			return res;
		}
		public static void Print(Cell cell)
		{
			for (int i = 0; i < cell.Size; i++) {
				Console.Write(cell.data[i]);
				if ((i+1) % 3 != 0) {
					Console.Write(' ');
				} else {
					Console.WriteLine("");
				}
			}
			Console.WriteLine();
		}
		public static int Affinity(Cell first, Cell seccond)
		{
			int distance = 0;
			for (int i = 0; i < first.Size; i++) {
				if (first.data[i] != seccond.data[i]) {
					distance++;
				}
			}
			return distance;
			//double res = ((double)distance * 100.0) / ((double)first.Size );
			//return res;
		}

		public static double GenerateTreashold(List<KeyValuePair<double, Antibody>> pAff)
		{
			double res = 0.0;

			foreach (var item in pAff) {
				res += item.Key;
			}

			return res / pAff.Count;
		}
	}
}
