using System;
using System.Collections.Generic;

namespace ClonalAlgo
{

	public class Antibody : Cell
	{
		public Antibody(List<int> pData) : base(pData)
		{
		}
		public Antibody(int size) : base(size)
		{
		}

		public Antibody Copy()
		{
			Antibody c = new Antibody(0);
			foreach (var item in data) {
				c.data.Add(item);
			}
			return c;
		}

		//public double Affinity;
	}
}
