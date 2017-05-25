using Gtk;

namespace ClonalAlgoGUI
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			Application.Init();

			MainWindow window = new MainWindow();

			window.ShowAll();

			Application.Run();
		}


	}
}
