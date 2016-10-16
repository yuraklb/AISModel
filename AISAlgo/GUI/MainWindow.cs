using System;
using Gtk;

namespace AISAlgo
{
	public class MainWindow : Gtk.Window
	{

		private HScale hscale_b;
		private HScale hscale_y;
		private HScale hscale_a;
		private HScale hscale_mc;
		private HScale hscale_p;
		private HScale hscale_n;
		private HScale hscale_mf;

		private CPlot mPlot;

		public void Recalculate() {

			mPlot.Clear ();

			MathModel mm = new MathModel ();

			mm.V=0.1;

			//1.1;
			mm.b= this.hscale_b.Value;
				
			//1.0;
			mm.y=this.hscale_y.Value;

			mm.C=0.1;
			//0.9;
			mm.a=this.hscale_a.Value;
			//0.2;
			mm.mc=this.hscale_mc.Value;

			mm.F=0.0;
			//1.1;
			mm.p=this.hscale_p.Value;
			//0.1;
			mm.n=this.hscale_n.Value;
			//0.4;
			mm.mf=this.hscale_mf.Value;

			int i = 0; 

			foreach(var sp in mm.Solve()) {
				//	Console.WriteLine("{0}\t{1}", sp.T, sp.X);
				mPlot.AddPoints(i++, sp.X[0], sp.X[1], sp.X[2]);
			}

		}

		public MainWindow() : base("AIS Model")
		{

			mPlot = new CPlot();

			this.DeleteEvent += (o, args) => {
				args.RetVal = true;
				Application.Quit();
			};



			this.SetSizeRequest(700, 900);

			VBox vbox1 = new VBox(false, 0);

			vbox1.PackStart(mPlot.GetPlotView(), true, false, 0);

			hscale_b = new HScale(0.0, 1.0, 0.1);

			hscale_b.SetSizeRequest (200, -1);
			hscale_b.UpdatePolicy = UpdateType.Continuous;
			hscale_b.Digits = 1;
			hscale_b.ValuePos = PositionType.Top;
			hscale_b.DrawValue = true;
			vbox1.PackStart (new Label ("b - которое будем называть коэффициентом «размножения» антигенов"), true, true, 0);
			vbox1.PackStart (hscale_b, true, true, 0);
			hscale_b.ShowAll ();
			hscale_b.ChangeValue += Hscale_b_ChangeValue;

			hscale_y = new HScale(0.0, 1.0, 0.1);
			hscale_y.SetSizeRequest (200, -1);
			hscale_y.UpdatePolicy = UpdateType.Continuous;
			hscale_y.Digits = 1;
			hscale_y.ValuePos = PositionType.Top;
			hscale_y.DrawValue = true;
			vbox1.PackStart (new Label ("y- коэффициент, связанный с вероятностью предотвращения несанкционированных действий;"), true, true, 0);
			vbox1.PackStart (hscale_y, true, true, 0);
			hscale_y.ShowAll ();
			hscale_y.ChangeValue += Hscale_b_ChangeValue;


			hscale_a = new HScale(0.0, 1.0, 0.1);
			hscale_a.SetSizeRequest (200, -1);
			hscale_a.UpdatePolicy = UpdateType.Continuous;
			hscale_a.Digits = 1;
			hscale_a.ValuePos = PositionType.Top;
			hscale_a.DrawValue = true;
			vbox1.PackStart (new Label ("a - коэффициент генерации детекторов"), true, true, 0);
			vbox1.PackStart (hscale_a, true, true, 0);
			hscale_a.ShowAll ();
			hscale_a.ChangeValue += Hscale_b_ChangeValue;


			hscale_mc = new HScale(0.0, 1.0, 0.1);
			hscale_mc.SetSizeRequest (200, -1);
			hscale_mc.UpdatePolicy = UpdateType.Continuous;
			hscale_mc.Digits = 1;
			hscale_mc.ValuePos = PositionType.Top;
			hscale_mc.DrawValue = true;
			vbox1.PackStart (new Label ("mc - коэффициент времени работы детектора"), true, true, 0);
			vbox1.PackStart (hscale_mc, true, true, 0);
			hscale_mc.ShowAll ();
			hscale_mc.ChangeValue += Hscale_b_ChangeValue;



			hscale_p = new HScale(0.0, 1.0, 0.1);
			hscale_p.SetSizeRequest (200, -1);
			hscale_p.UpdatePolicy = UpdateType.Continuous;
			hscale_p.Digits = 1;
			hscale_p.ValuePos = PositionType.Top;
			hscale_p.DrawValue = true;
			vbox1.PackStart (new Label ("p - скорость производства антител одним детектором"), true, true, 0);
			vbox1.PackStart (hscale_p, true, true, 0);
			hscale_p.ShowAll ();
			hscale_p.ChangeValue += Hscale_b_ChangeValue;

			hscale_n = new HScale(0.0, 1.0, 0.1);
			hscale_n.SetSizeRequest (200, -1);
			hscale_n.UpdatePolicy = UpdateType.Continuous;
			hscale_n.Digits = 1;
			hscale_n.ValuePos = PositionType.Top;
			hscale_n.DrawValue = true;
			vbox1.PackStart (new Label ("n - уменьшение числа антител"), true, true, 0);
			vbox1.PackStart (hscale_n, true, true, 0);
			hscale_n.ShowAll ();
			hscale_n.ChangeValue += Hscale_b_ChangeValue;

			hscale_mf = new HScale(0.0, 1.0, 0.1);
			hscale_mf.SetSizeRequest (200, -1);
			hscale_mf.UpdatePolicy = UpdateType.Continuous;
			hscale_mf.Digits = 1;
			hscale_mf.ValuePos = PositionType.Top;
			hscale_mf.DrawValue = true;
			vbox1.PackStart (new Label ("mf - уменьшение количества антител (время жизни)"), true, true, 0);
			vbox1.PackStart (hscale_mf, true, true, 0);
			hscale_mf.ShowAll ();
			hscale_mf.ChangeValue += Hscale_b_ChangeValue;

			this.Add(vbox1);


			double b=1.1;
			double y=1.0;

			hscale_b.Value = b;
			hscale_y.Value = y;

			double a=0.9;
			double mc=0.2;
			hscale_a.Value = a;
			hscale_mc.Value = mc;

			double p=1.1;
			double n=0.1;
			double mf=0.4;
			hscale_p.Value = p;
			hscale_n.Value = n;
			hscale_mf.Value = mf;


		}

		void Hscale_b_ChangeValue (object o, ChangeValueArgs args)
		{
			Recalculate ();
		}
	}
}

