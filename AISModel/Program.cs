﻿using System;
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

            myNetwork.GenerateGraphFile();


        }
    }
}
