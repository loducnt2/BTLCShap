using ProjectQLQuanCafe.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace ProjectQLQuanCafe.DAL
{
    public class TableDAL
    {
        DataProvider dtPro = new DataProvider();
        public List<Table> GetListTable()
        {
            List<Table> tablelist = new List<Table>();
            String query = "select * from FoodTable";
            DataTable dt = dtPro.ExecuteQuery(query);

            foreach (DataRow item in dt.Rows)
            {
                Table tbl = new Table(item);
                tablelist.Add(tbl);
            }
            return tablelist;
        }
        public static int TableWidth = 80;
        public static int TableHeight = 80;
        /*
        private static TableDAL instance;

        public static TableDAL Instance
        {
            get
            {
                if (instance == null)
                    instance = new TableDAL();
                return TableDAL.instance;
            }
            private set { TableDAL.instance = value; }
        }

        public static int TableWidth = 50;
        public static int TableHeight = 50;

        private TableDAL() { }

        public List<Table> LoadTableList()
        {
            List<Table> tablelist = new List<Table>();

            DataTable data = DataProvider.ExecuteQuery("");

            foreach (DataRow item in data.Rows)
            {
                Table table = new Table(item);
                tablelist.Add(table);
            }
            return tablelist;
        }
        */
    }
}
