using System;
using System.Collections.Generic;

namespace GANew
{
	class MainClass
	{
		
		public static double theActualFunction(List<char> values)
		{	
			char[] test = { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' };//, 'l', 'o', 'w', 'o', 'r', 'l', 'd' };

			double f1 = 0.0;

			for(int i = 0; i < test.Length; i++) {
				if(test[i] == values[i]) {
					f1+=1.0;
				}
			}

			return f1;
		}
					
		public static void Main(string[] args)
		{			
			List<Population> mPopulations = new List<Population>();

			GA.CrossoverRate = 0.5;
			GA.MutationRate = 0.1;

			Genome.mLength = 10;

			int m_populationSize = 10;
			double m_selectionRate = 0.8; //80% kills in population
			int m_generationSize = 2000;


			Population pop = new Population(0, GA.GenerateInitialGenomes(m_populationSize));

			pop.DoMagic(m_selectionRate);
			pop.Info();

			mPopulations.Add(pop);

			for(int i = 0; i < m_generationSize; i++) {
				
				Population pop2 = new Population(i, GA.GenerateGenomes(m_populationSize, mPopulations[i]));

				pop2.DoMagic(m_selectionRate);
				pop2.Info();

				mPopulations.Add(pop2);

				if(pop2.mMaxFitness > 9.8)
					break;



			}

			mPopulations.Sort(delegate(Population x, Population y) {
				if(x.GetFitness() > y.GetFitness())
					return 1;
				else if(x.GetFitness() == y.GetFitness())
					return 0;
				else
					return -1;
			});

			mPopulations[mPopulations.Count - 1].Output();
				
		}
	}
}
