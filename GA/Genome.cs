using System;
using System.Collections.Generic;

namespace GANew
{
	public class Genome 
	{
		public static int mLength;

		public int Length {
			get {
				return mLength;
			}
		}

		private List<char> mGenes;

		public List<char> GetGenes() {
			return mGenes;
		}

		public Genome(Genome pGenome) {
			List<char> l = pGenome.GetGenes(); 
			mGenes = new List<char>();
			foreach(var item in l) {
				mGenes.Add(item);
			}
		}

		public Genome()
		{			
			mGenes = new List<char>(mLength);
			CreateGenes();
		}

		private void CreateGenes()
		{
			for(int i = 0; i < mLength; i++)
				mGenes.Add(GA.GetRandomGene());
		}



		public char this[int pIdx] {
			get {
				return mGenes[pIdx];
			}
			set {
				mGenes[pIdx] = value;
			}
		}

		private double m_fitness;

		public double Fitness {
			get {
				return m_fitness;
			}
			set {
				m_fitness = value;
			}
		}

		public string GetString() {
			return new string(mGenes.ToArray());
		}
	}
}

