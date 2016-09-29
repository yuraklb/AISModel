using System;
using System.Collections.Generic;

namespace AISModel
{
	public static class RouteGenerator
	{
		public static Queue<int> GenerateRoute(int pMaxId) {

			Queue<int> route = new Queue<int>();

			int maxhop = 0;

			maxhop = RandomGenerator.GetRandomInt(1, pMaxId);

			for(int i = 0; i < maxhop; i++) {

				do {

					int tmpId = RandomGenerator.GetRandomInt(1, pMaxId);
					if(route.Contains(tmpId)) {
						continue;
					} else {
						route.Enqueue(tmpId);
						break;
					}
				} while(true);
			}

			return route;
		}
	}
}

