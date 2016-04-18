using System.ComponentModel;
using System.Data;

namespace AISModel
{
    public static class State
    {
        public static DataTable mLogTable;
        public static DataSet mLogDataSet;

        public static void Init()
        {
            mLogTable = new DataTable("logTable");
            
            mLogTable.Columns.Add("id");
	        mLogTable.Columns.Add("Bane");
	        

            mLogDataSet = new DataSet();
            mLogDataSet.Tables.Add(mLogTable);
        }

        public static void InsertRow(string pId, string pName)
        {
            mLogTable.Rows.Add(pId, pName);
        }

    }
}