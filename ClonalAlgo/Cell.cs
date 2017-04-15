using System;
using System.Collections.Generic;
namespace ClonalAlgo
{
	public class Cell
	{

		public static Random mRandom = new Random();

		public List<int> data = new List<int>();
		//public int cell_size;
		public Cell(List<int> pData)
		{
			foreach (var item in pData)
			{
				data.Add(item);
			}

			//cell_size = data.Count;
		}

		public Cell(int pSize)
		{
			for (int i = 0; i < pSize; i++) {
				int q = Cell.mRandom.Next() % 2;
				data.Add(q);
			}
		}

		int size()
		{
			return data.Count;
		}

		public Cell Copy()
		{
			Cell c = new Cell(0);
			foreach (var item in data)
			{
				c.data.Add(item);
			}
			//c.cell_size = this.cell_size;

			return c;
		}

		public void mutate(double p_mut)
		{
			int amount = (int)(data.Count * p_mut);
			List<int> idxs = new List<int>(amount);
			idxs.ForEach((obj) => obj = -1);

			int bit = Cell.mRandom.Next(amount);
			if (data[bit] == 1) {
				data[bit] = 0;
			} else {
				data[bit] = 1;
			}
		}
		public static int affinity(Cell first, Cell seccond)
		{
			// Hamming distance
			int distance = 0;
			for (int i = 0; i < first.size(); i++) {
				if (first.data[i] != seccond.data[i]) {
					distance++;
				}
			}
			return distance;
		}
		public static void print_cell(Cell cell, int size, int width)
		{
			for (int i = 0; i < size; i++) {
				Console.Write(cell.data[i]);
				Console.Write(' ');
			}
			Console.WriteLine();
		}
	}
}


