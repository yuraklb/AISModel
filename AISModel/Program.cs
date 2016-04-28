using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AISModel
{
    class Program
    {
        static void Main(string[] args) {

            State.Init();

            Network myNetwork = new Network(50);

            myNetwork.Init();

            for(int i = 0; i < 100; i++) {
                myNetwork.RunIteration();
            }

            //myNetwork.GenerateGraphFile();


        }
    }
}
