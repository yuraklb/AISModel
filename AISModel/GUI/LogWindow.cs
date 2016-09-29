using System;


namespace AISModel
{
	public class LogWindow : Gtk.Window
	{
		private Gtk.ListStore logListStore;

		public LogWindow() : base("Log Model")
		{
			this.Move(0,0);

			this.SetSizeRequest(600, 500);

			Gtk.TreeView treeviewLog = new Gtk.TreeView();

			Gtk.TreeViewColumn idColumn = new Gtk.TreeViewColumn ();
			idColumn.Title = "Id";

			Gtk.TreeViewColumn typeColumn = new Gtk.TreeViewColumn ();
			typeColumn.Title = "Type";

			Gtk.TreeViewColumn descriptionColumn = new Gtk.TreeViewColumn ();
			descriptionColumn.Title = "Description";

			logListStore = new Gtk.ListStore (typeof (string), typeof (string), typeof (string));

			treeviewLog.AppendColumn(idColumn);
			treeviewLog.AppendColumn(typeColumn);
			treeviewLog.AppendColumn(descriptionColumn);

			treeviewLog.Model = logListStore;




			Gtk.CellRendererText idCell = new Gtk.CellRendererText ();
			idColumn.PackStart(idCell, true);

			Gtk.CellRendererText typeCell = new Gtk.CellRendererText ();
			typeColumn.PackStart(typeCell, true);

			Gtk.CellRendererText descriptionCell = new Gtk.CellRendererText ();
			descriptionColumn.PackStart(descriptionCell, true);

			idColumn.AddAttribute(idCell, "text", 0);
			typeColumn.AddAttribute(typeCell, "text", 1);
			descriptionColumn.AddAttribute(descriptionCell, "text", 2);

			Gtk.ScrolledWindow scWindow = new Gtk.ScrolledWindow();
			scWindow.Add(treeviewLog);

			this.Add(scWindow);

		}

		public Gtk.ListStore GetListStore() {
			return logListStore;
		}
	}
}

