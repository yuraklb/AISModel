using System;

namespace AISModel
{
	public static class RandomGenerator
	{
		private static Random rnd;

		public static int GetRandomInt(int pMin, int pMax) {

			if(rnd == null) {
				rnd = new Random();
			}

			return rnd.Next(pMin, pMax);
		}
	}
}

