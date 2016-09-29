using System;

namespace AISModel
{
	public class NetworkState
	{

		private int mIdRunIteration;
		private int mCountWarningPackets;
		private int mCountErrorPackets;
		private int mCountNormalPackets;

		public NetworkState(int pIdRunIteration, int pCountNormalPackets, int pCountWarningPackets, int pCountErrorPackets)
		{
			mIdRunIteration = pIdRunIteration;
			mCountWarningPackets = pCountWarningPackets;
			mCountErrorPackets = pCountErrorPackets;
			mCountNormalPackets = pCountNormalPackets;
		}

	}
}

