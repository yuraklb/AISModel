using System;
using System.IO;
using System.Collections.Generic;

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

			MainWindow window = new MainWindow();

			window.ShowAll();

			Application.Run();

        }
    }
}