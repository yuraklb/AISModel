using System;
using System.Collections.Generic;

namespace GANew
{
	public class Population
	{
		private int mId;

		private List<Genome> mGenomes;

		private double mFitness;

		private double mMinFitness;
		public double mMaxFitness;

		private int mCountPositiveFitness;

		public Population(int pId, List<Genome> pListGenomes) {

			mId = pId;

			mGenomes = new List<Genome>();

			foreach(var item in pListGenomes) {
				this.mGenomes.Add(new Genome(item));
			}
		}

		public double GetFitness() {
			return mFitness;
		}

		public List<Genome> GetGenomes() {
			return mGenomes;
		}

		public void SetFitness(double pFitness) {
			mFitness = pFitness;
		}

		private void SortPopulation() {
			mGenomes.Sort(delegate(Genome x, Genome y) {
				if(x.Fitness > y.Fitness)
					return 1;
				else if(x.Fitness == y.Fitness)
					return 0;
				else
					return -1;
			});
		}

		public Genome GetBestGenome() {
			return mGenomes[mGenomes.Count - 1];
		}

		public Genome this[int pIdx] {
			get {
				return mGenomes[pIdx];
			}
			set {
				mGenomes[pIdx] = value;
			}
		}

		public int GetMidIdxWithFitness() {
			int idx = 0;

			foreach(var item in mGenomes) {
				if(item.Fitness > 0.0)
					mCountPositiveFitness++;
			}

			double midFitness = (mCountPositiveFitness == 0) ? 0 : mFitness / mCountPositiveFitness;

			idx = mGenomes.FindIndex(delegate(Genome genome) {
				return genome.Fitness >= midFitness;
			});

			return idx;
		}

		public void Output() {
			
			Console.WriteLine("C {3} FITNESS POPULATION {0} MIN {1} MAX {2} ", mFitness, mMinFitness, mMaxFitness, mId);

			foreach(var item in mGenomes[mGenomes.Count-1].GetGenes()) {
				Console.Write("{0}", item);
			}
			Console.Write('\n');
		}

		private void RankPopulation()
		{
			mFitness = 0.0;
			mMinFitness = 0.0;
			mMaxFitness = 0.0;
			foreach(var item in mGenomes) {
				item.Fitness = MainClass.theActualFunction(item.GetGenes());

				if(item.Fitness > mMaxFitness) {
					mMaxFitness = item.Fitness;
				}

				if(item.Fitness < mMinFitness) {
					mMinFitness = item.Fitness;
				}

				mFitness += item.Fitness;
			}
		}

		private void Selection(double pSelectionRate) {

			int cnt = (int) (mGenomes.Count * pSelectionRate);

			mGenomes.RemoveRange(0, cnt);
		}

		public void DoMagic(double pSelectionRate) {
			RankPopulation();
			SortPopulation();
			Selection(pSelectionRate);

		}

		public void Info() {
			Console.Write("id {0} count {1} fitness {2} best genome {3}\n", mId, mGenomes.Count, mGenomes[mGenomes.Count - 1].Fitness, mGenomes[mGenomes.Count - 1].GetString());
		}

	}
}

