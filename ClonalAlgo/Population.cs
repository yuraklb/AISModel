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
		private List<Antibody> ABs = new List<Antibody>();

		public void Init()
		{
			for (int i = 0; i < Helper.NumberOfAntibody; i++)
			{
				ABs.Add(new Antibody(Helper.CellSize));
			}
		}

		public void Init(Population pPopulation)
		{
			for (int i = 0; i < Helper.NumberOfAntibody; i++) {
				ABs.Add(pPopulation.ABs[i]);
			}
		}

		public int FindBestGeneration(Antigene pAg)
		{
			//for (int generation = 0; generation < Helper.NumberOfGeneration; generation++) {

				List<KeyValuePair<double, Antibody>> aff = new List<KeyValuePair<double, Antibody>>();

				for (int i = 0; i < ABs.Count; i++) {
					aff.Add(new KeyValuePair<double, Antibody>(Helper.Affinity(pAg, ABs[i]), ABs[i]));
				}

				aff.Sort((x, y) => { return y.Key.CompareTo(x.Key); });

				double treashold = Helper.GenerateTreashold(aff);

				 aff.RemoveAll((obj) => obj.Key < treashold);


				if (aff.Count > 0) {

					Console.WriteLine("Best aff: " + aff[0].Key);

					if (aff[0].Key > 95.0) {
						Console.WriteLine("Find!!!");
						Helper.Print(aff[0].Value);
						return 0;
					}
				}

				List<Antibody> newGeneration = new List<Antibody>();

				if (aff.Count == 0) {
					newGeneration.Add(new Antibody(pAg.Size));
				} else {
					for (int i = 0; i < aff.Count; i++) {
						for (int j = 0; j < (int)ABs.Count / aff.Count; j++) {
							newGeneration.Add(aff[i].Value);
						}
					}

					while (newGeneration.Count < ABs.Count) {
						newGeneration.Add(aff[0].Value);
					}
				}

				ABs.Clear();

				ABs = new List<Antibody>(newGeneration);

				ABs.ForEach((obj) => obj.Mutate(1));

				if (aff.Count > 0) {
					Helper.Print(pAg);
					Console.WriteLine("Affinity: {0}%", aff[0].Key);
					Helper.Print(aff[0].Value);
				} else {
					Console.WriteLine("Destroy all population!");
				}



			//}
			return -1;
		}
	}
}
