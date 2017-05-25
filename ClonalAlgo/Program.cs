using System.Collections.Generic;

namespace ClonalAlgo
{
	public static class Algorithm
	{
		public static DataView Compute()
		{
			Antigene Ag = new Antigene(Helper.CellSize);

			int step = 0;

			Antibody bestantibody = null;

			List<Population> populations = new List<Population>();

			populations.Add(new Population());

			populations[0].Init();

			while (step != Helper.NumberOfGeneration) {

				bestantibody = populations[step].FindBestAntibody(Ag);

				populations.Add(populations[step].GenerateNewPopulation());

				step++;

				var aff = Helper.Affinity(bestantibody, Ag);
				if (aff == 0) {
					break;
				} else {
				}
			}


			DataView dv = new DataView {
				mAg = Ag,
				mAb = bestantibody,
				mPopulations = populations
			};

			return dv;
		//}

		//public static void Main(string[] args)
		//{

		//	Antigene Ag = new Antigene(Helper.CellSize);

		//	int step = 0;

		//	Console.WriteLine("Generations: " + Helper.NumberOfGeneration);

		//	Antibody bestantibody = null;

		//	Population population = new Population();

		//	population.Init();

		//	while (step != Helper.NumberOfGeneration) {

		//		bestantibody = population.FindBestAntibody(Ag);

		//		population = population.GenerateNewPopulation();

		//		step++;

		//		var aff = Helper.Affinity(bestantibody, Ag);
		//		if (aff == 0) {
		//			Console.WriteLine(step);
		//			break;
		//		} else {
		//			//Console.WriteLine(step);
		//		}
		//	}

		//	//Console.WriteLine("\nMemory cell:");
		//	//Helper.Print(bestantibody);


		}
	}
}
