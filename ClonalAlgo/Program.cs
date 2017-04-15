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
			int CELL_SIZE = 12;
			int gen = 15330; // how many generations algorithm will pass
			const int M = 3; // size of a set of antigenes
			const int N = 6; // size of a set of antibodies
			double beta = 1.0;
			double p_mutmax = 0.6; // 60% of the cell will mutate
			int Abr_begin = M; // range in set of antibodies, it shows where is a remaining cells (from Arm_begin to Arm_end)
			int Abr_end = N;

			List<Antigene> Ag = new List<Antigene>(M);
			List<Antibody> Ab = new List<Antibody>(N);

			Ag.Add(new Antigene(new List<int> { 0, 1, 0, 0, 1, 0, 0, 1, 0, 0, 1, 0 })); // 1
			Ag.Add(new Antigene(new List<int> { 1, 0, 1, 1, 0, 1, 1, 1, 1, 0, 0, 1 })); // 4
			Ag.Add(new Antigene(new List<int> { 1, 1, 1, 0, 0, 1, 0, 0, 1, 0, 0, 1 })); // 7

			for (int i = 0; i < N; i++) {
				Ab.Add(new Antibody(CELL_SIZE));
			}

			Console.WriteLine("Generations: " + gen);
			while (gen != 0) {
				for (int z = 0; z < M; z++) {
					// Affinity between antibody and antigene
					List<KeyValuePair<int, int>> aff = new List<KeyValuePair<int, int>>();
					for (int i = 0; i < N; i++) {
						aff.Add(new KeyValuePair<int, int>(Cell.affinity(Ab[i], Ag[z]), i));
					}

					aff.Sort((x, y) => {
						return x.Key.CompareTo(y.Key);
					});

					//int amount = 6; // how many antibodies need to select with the lowest affinity
					//aff.RemoveRange(amount, aff.Count - amount);

					// Clonning
					List<int> c_amount = new List<int>(aff.Count);
					for (int i = 0; i < aff.Count; i++) {
						c_amount.Add((int)((beta * N) / (aff[i].Value + 1)));
					}

					int Nc = 0; // sum of the all clones
					for (int i = 0; i < c_amount.Count; i++) {
						Nc += c_amount[i];
					}

					List<Antibody> C = new List<Antibody>(Nc);
					List<int> C_indexes = new List<int>(Nc);
					for (int i = 0; i < aff.Count; i++) {
						while (c_amount[i] != 0) {
							C.Add(Ab[aff[i].Value].copy());
							C_indexes.Add(aff[i].Value + 1);
							c_amount[i]--;
						}
					}

					// Mutation of all clones
					for (int i = 0; i < Nc; i++) {
						double p_mut = p_mutmax * ((beta * C_indexes[i]) / N);
						C[i].mutate(p_mut);
					}

					// Affinity between antibody and antigene
					List<KeyValuePair<int, int>> aff_star = new List<KeyValuePair<int, int>>();
					for (int i = 0; i < Nc; i++) {
						aff_star.Add(new KeyValuePair<int, int>(Cell.affinity(C[i], Ag[z]), i));
					}

					// Replacing antibody with its best clone
					if (aff_star[0].Key < Cell.affinity(Ab[z], Ag[z])) {
						Ab[z] = C[aff_star[0].Value].copy();
					}

					// Editing of remaining population
					for (int i = Abr_begin; i < Abr_end; i++) {
						Ab[i] = new Antibody(CELL_SIZE);
					}
				}
				--gen;
			}
			Console.WriteLine("Memory cell #1:");
			Cell.print_cell(Ab[0], CELL_SIZE, 12);
			Console.WriteLine("Memory cell #2:");
			Cell.print_cell(Ab[1], CELL_SIZE, 12);
			Console.WriteLine("Memory cell #3:");
			Cell.print_cell(Ab[2], CELL_SIZE, 12);
		}
	}
}
