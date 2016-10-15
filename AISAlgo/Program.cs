using System;
using System.IO;
using System.Collections.Generic;
using Microsoft.Research.Oslo;
using System.Diagnostics;
using System.Globalization;
using Gtk;

namespace AISAlgo
{
    class Program
    {
        static void Main(string[] args)
        {

			Application.Init();

			var plot = new CPlot();

			MainWindow window = new MainWindow(plot);

			var sol = Ode.RK547M(
				0,
				new Vector(1, 1, 0.0),
				(t, x) => new Vector(
					1.1*x[0] - 0.5 * x[2] * x[0], 
					1.2-x[0] - 0.2,
					1.3 * x[1] - 0.5 * x[0] * x[1] - 0.8 * x[2]
				)
			);

			var points = sol.SolveFromToStep(0, 1200, 1);

			int i = 0; 

			foreach(var sp in points) {
				//	Console.WriteLine("{0}\t{1}", sp.T, sp.X);
				plot.AddPoints(i++, sp.X[0], sp.X[1], sp.X[2]);
			}

			window.ShowAll();

			Application.Run();

        }
    }
}