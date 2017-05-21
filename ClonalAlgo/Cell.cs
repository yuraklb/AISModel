using System;
using System.Collections.Generic;
namespace ClonalAlgo
{
	public class Cell
	{

		public static Random mRandom = new Random();

		public List<int> data = new List<int>();

		public Cell(List<int> pData)
		{
			foreach (var item in pData) {
				data.Add(item);
			}
		}

		public Cell(int pSize)
		{
			for (int i = 0; i < pSize; i++) {
				int q = Cell.mRandom.Next() % 2;
				data.Add(q);
			}
		}

		public int Size {
			get {
				return data.Count;
			}
		}

		//public Cell Copy()
		//{
		//	Cell c = new Cell(0);
		//	foreach (var item in data)
		//	{
		//		c.data.Add(item);
		//	}

		//	return c;
		//}

		public void Mutate(double p_mut)
		{
			//if (Cell.mRandom.NextDouble() <= pMut)
			//{
			//	int bit = Cell.mRandom.Next(data.Count);

			//	if (data[bit] == 1)
			//	{
			//		data[bit] = 0;
			//	}
			//	else
			//	{
			//		data[bit] = 1;
			//	}
			//}


			int amount = (int)Math.Ceiling(data.Count * p_mut);
			List<int> idxs = new List<int>(amount);

			for (int k = 0; k < amount; k++) {
				idxs.Add(-1);
			}

			int i = 0;
			while (i != amount) {
				int bit = mRandom.Next() % amount;
				if (idxs.Find((obj) => obj == bit) == -1) {
					continue;
				} else {
					idxs[i++] = bit;
					if (data[bit] == 1) {
						data[bit] = 0;
					} else {
						data[bit] = 1;
					}
				}
			}
		}
	}
}


