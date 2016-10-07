using System;
using System.Collections.Generic;

namespace GANew
{

	public delegate double GAFunction(List<char> values);

	public static class GA
	{
		public static Random mRandom = new Random();

		public static double CrossoverRate;
		public static double MutationRate;

		public static char GetRandomGene() {
			return (char)mRandom.Next(48, 58);
		}

		public static void Crossover(Genome pFatherGenome, Genome pMotherGenome, out Genome pSon, out Genome pDouther)
		{
			int length = pFatherGenome.Length;

			pSon = new Genome();
			pDouther = new Genome();

			int pos = mRandom.Next(0, length);

			for(int i = 0; i < length; i++) {
				if(i < pos) {
					pSon[i] = pFatherGenome[i];
					pDouther[i] = pMotherGenome[i];
				} else {
					pSon[i] = pMotherGenome[i];
					pDouther[i] = pFatherGenome[i];
				}
			}
		}

		public static List<Genome> GenerateInitialGenomes(int m_populationSize) {
			
			List<Genome> lGenomes = new List<Genome>();

			for(int i = 0; i < m_populationSize; i++) {
				Genome g = new Genome();
				lGenomes.Add(g);
			}

			return lGenomes;
		}

		public static List<Genome> GenerateGenomes(int m_populationSize, Population pPreviousPopulation) {

			List<Genome> m_nextGeneration = new List<Genome>();

			for(int i = 0; i < m_populationSize; i += 2) {
				int pidx1 = RouletteSelection(pPreviousPopulation);
				int pidx2 = RouletteSelection(pPreviousPopulation);
				Genome parent1;
				Genome parent2;
				Genome child1;
				Genome child2;
				parent1 = pPreviousPopulation[pidx1];
				parent2 = pPreviousPopulation[pidx2];

				if(GA.mRandom.NextDouble() < CrossoverRate) {
					GA.Crossover(parent1, parent2, out child1, out child2);
				} else {
					child1 = new Genome(parent1);
					child2 = new Genome(parent2);
				}

				Mutator(child1);
				Mutator(child2);

				m_nextGeneration.Add(new Genome(child1));
				m_nextGeneration.Add(new Genome(child2));
			}

			return m_nextGeneration;
		}
					
		private static int RouletteSelection(Population pPreviousPopulation)
		{
			int min = 0;
			int max = pPreviousPopulation.GetGenomes().Count - 1;


			return GA.mRandom.Next(min, max);

		}

		public static void Mutator(Genome pGenome) {
			for(int pos = 0; pos < Genome.mLength; pos++) {
				if(GA.mRandom.NextDouble() < MutationRate)
					pGenome[pos] = GA.GetRandomGene();
			}
		}

		public static void Output(Genome pGenome)
		{
			for(int i = 0; i < pGenome.Length; i++) {
				System.Console.Write("{0}", pGenome[i]);
			}
			System.Console.Write("\n");
		}
	}
}

