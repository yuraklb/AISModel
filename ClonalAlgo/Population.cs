using System;
using System.Collections.Generic;
namespace ClonalAlgo
{
	//population - set of ab;
/*
	Крок 1. Ініціалізація. Створення (звичайно випадковою генерацією) 
	початкової популяції антитіл(AB).

Крок 2. Обчислення афінності.Для кожного антитіла обчислити його афінність 
стосовно кожного антигену. Результати записати в матрицю афінностей.

Крок 3. Клональна селекція та поширення. Вибрати з популяції по n найкращих 
антитіл для кожного рядка матриці D і помістити їх в окрему популяцію клонів.
Згенерувати клони елементів популяції AB пропорційно до їх афінності; 
тобто чим вища афінність, тим більша створюється кількість клонів і навпаки.

Крок 4. Дозрівання афінності. Піддати мутації всі клони популяції AB
з імовірністю, обернено пропорційною їх афінностям, 
тобто чим нижча афінність індивідуума, тим вища ймовірність його мутації.
Обчислити нову афінність кожного антитіла j аналогічно до кроку 2, 
одержавши нову матрицю афінностей CD.Вибрати з популяції AB n антитіл, 
для яких відповідний вектор-стовпчик матриці CD дає кращий узагальнений 
результат афінності, і перенести їх у популяцію клітин пам'яті RM .


Крок 5. Метадинаміка.Замінити d гірших антитіл популяції AB
новими випадковими індивідуумами.

Крок 6. Замінити n антитіл популяції AB клітками пам'яті з 
RM і переходити до кроку 2 до тих пір, поки не буде досягнуто 
критерію зупинки.
*/
	public class Population
	{

		double beta = 1.0;
			double p_mutmax = 0.6; // 60% of the cell will mutate
			int Abr_begin = 1; // range in set of antibodies, it shows where is a remaining cells (from Arm_begin to Arm_end)
		int Abr_end = Helper.NumberOfAntibody;

		int amount = 6; // how many antibodies need to select with the lowest affinity
		

		public List<Antibody> ABs = new List<Antibody>();

		public void Init()
		{
			for (int i = 0; i < Helper.NumberOfAntibody; i++)
			{
				ABs.Add(new Antibody(Helper.CellSize));
			}
		}

		public Population GenerateNewPopulation()
		{
			Population pop = new Population();

			pop.ABs.Add(ABs[0].Copy());

			// Editing of remaining population
			while (pop.ABs.Count != Helper.NumberOfAntibody) {
				pop.ABs.Add(new Antibody(Helper.CellSize));
			}

			return pop;
		}

		public Antibody FindBestAntibody(Antigene pAg)
		{
			for (int i = 0; i < Helper.NumberOfAntibody; i++) {
				ABs.Add(new Antibody(Helper.CellSize));
			}

			List<KeyValuePair<int, int>> aff = new List<KeyValuePair<int, int>>();
			for (int i = 0; i < Helper.NumberOfAntibody; i++) {
				aff.Add(new KeyValuePair<int, int>(Helper.Affinity(ABs[i], pAg), i));
			}

			aff.Sort((x, y) => {
				return x.Key.CompareTo(y.Key);
			});

			//TODO remove bad items
			aff = aff.GetRange(0, amount);


			//TODO cloning good items
			// Clonning 
			List<int> c_amount = new List<int>();
			for (int _i = 0; _i < aff.Count; _i++) {
				double qwe = (int)((beta * Helper.NumberOfAntibody) / (aff[_i].Value + 1));
				c_amount.Add((int)qwe);
			}

			int Nc = 0; // sum of the all clones
			for (int i = 0; i < c_amount.Count; i++) {
				Nc += c_amount[i];
			}

			List<Antibody> C = new List<Antibody>();
			List<int> C_indexes = new List<int>();

			for (int i = 0; i < aff.Count; i++) {
				while (c_amount[i] != 0) {
					
					C.Add(ABs[aff[i].Value].Copy());
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
				aff_star.Add(new KeyValuePair<int, int>(Helper.Affinity(C[i], pAg), i));
			}

			aff_star.Sort((x, y) => {
				return x.Key.CompareTo(y.Key);
			});


			// Replacing antibody with its best clone
			if (aff_star[0].Key < Helper.Affinity(ABs[0], pAg)) {
				ABs[0] = C[aff_star[0].Value].Copy();
			}

			return ABs[0];
		}
	}
}
