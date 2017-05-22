using System;
using System.Collections.Generic;
/*
 input   : S = set of patterns to be recognised, n the number of worst elements to select for removal
 output  : M = set of memory detectors capable of classifying unseen patterns

begin


   Create an initial random set of antibodies, A

   forall  patterns in S   do         
      Determine the affinity with each antibody in A
	  Generate clones of a subset of the antibodies in A with the highest affinity.
		The number of clones for an antibody is proportional to its affinity

	  Mutate attributes of these clones to the set A , and place a copy of the highest
		 affinity antibodies in A into the memory set, M
	 Replace the n lowest affinity antibodies in A with new randomly generated antibodies
  end


end
*/

namespace ClonalAlgo
{

	class MainClass
	{

		public static void Main(string[] args)
		{

			Antigene Ag = new Antigene(Helper.CellSize);
			/*new List<int> {
			0,1,0,
			0,1,0,
			0,1,0,
			0,1,0,
			0,1,0,
			0,1,0,
			0,1,0,
			0,1,0,
			0,1,0,
			0,1,0 });
*/
			int step = 0;

			Console.WriteLine("Generations: " + Helper.NumberOfGeneration);

			Antibody bestantibody = null;

			Population population = new Population();

			population.Init();

			while (step != Helper.NumberOfGeneration) {

				bestantibody = population.FindBestAntibody(Ag);

				population = population.GenerateNewPopulation();

				step++;

				var aff = Helper.Affinity(bestantibody, Ag);
				if (aff == 0) {
					Console.WriteLine(step);
					break;
				} else {
					//Console.WriteLine(step);
				}
			}

			//Console.WriteLine("\nMemory cell:");
			//Helper.Print(bestantibody);


		}

		/*

public static void Main(string[] args)
		{

			double beta = 1.0;
			double p_mutmax = 0.6; // 60% of the cell will mutate
			int Abr_begin = 1; // range in set of antibodies, it shows where is a remaining cells (from Arm_begin to Arm_end)
			int Abr_end = Helper.NumberOfAntibody;


			Antigene Ag;
			List<Antibody> Ab = new List<Antibody>();

			Ag = new Antigene(new List<int> {
			0,1,0,
			0,1,0,
			0,1,0,
			0,1,0,
			0,1,0,
			0,1,0,
			0,1,0,
			0,1,0,
			0,1,0,
			0,1,0 });
			
			for (int i = 0; i < Helper.NumberOfAntibody; i++) {
				Ab.Add(new Antibody(Helper.CellSize));
			}

			int step = 0;

			Console.WriteLine("Generations: " + Helper.NumberOfGeneration);
			while (step != Helper.NumberOfGeneration) {
				// Affinity between antibody and antigene
				List<KeyValuePair<int, int>> aff = new List<KeyValuePair<int, int>>();
				for (int i = 0; i < Helper.NumberOfAntibody; i++) {
					aff.Add(new KeyValuePair<int, int>(Helper.Affinity(Ab[i], Ag), i));
				}

				aff.Sort((x, y) => {
					return x.Key.CompareTo(y.Key);
				});

				int amount = 6; // how many antibodies need to select with the lowest affinity

				aff = aff.GetRange(0, amount);



				//std::multimap<int, int> abn = aff;

				// Clonning
				List<int> c_amount = new List<int>();
				//std::vector<int> c_amount(aff.size());
				for (int _i = 0; _i < aff.Count; _i++) {

					double qwe = (int)((beta * Helper.NumberOfAntibody) / (aff[_i].Value + 1));

					c_amount.Add((int)qwe);
				}

				int Nc = 0; // sum of the all clones
				for (int i = 0; i < c_amount.Count; i++) {
					Nc += c_amount[i];
				}

				List<Antibody> C = new List<Antibody>(Nc);
				List<int> C_indexes = new List<int>(Nc);
				//it = aff.begin();
				for (int i = 0; i < aff.Count; i++) {
					while (c_amount[i] != 0) {
						C.Add(Ab[aff[i].Value].Copy());
						C_indexes.Add(aff[i].Value + 1);
						c_amount[i]--;
					}
				}

				// Mutation of all clones
				for (int i = 0; i < Nc; i++) {
					double p_mut = p_mutmax * ((beta * C_indexes[i]) / Helper.NumberOfAntibody);
					C[i].Mutate(p_mut);
				}

				// Affinity between antibody and antigene
				List<KeyValuePair<int, int>> aff_star = new List<KeyValuePair<int, int>>();
				for (int i = 0; i < Nc; i++) {
					aff_star.Add(new KeyValuePair<int, int>(Helper.Affinity(C[i], Ag), i));
				}

				// Replacing antibody with its best clone
				if (aff_star[0].Key < Helper.Affinity(Ab[0], Ag)) {
					Ab[0] = C[aff_star[0].Value].Copy();
				}

				// Editing of remaining population
				for (int i = Abr_begin; i < Abr_end; i++) {
					Ab[i] = new Antibody(Helper.CellSize);
				}
				//		}
				step++;
			}

			Console.WriteLine(Helper.Affinity(Ab[0], Ag));

			Console.WriteLine("\nMemory cell #1:");
			Helper.Print(Ab[0]);

		}

		*/
	}
}
