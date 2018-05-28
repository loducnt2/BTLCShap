using ProjectQLQuanCafe.BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectQLQuanCafe.DAL
{
    public class FoodTableDAL
    {
        public static int TableWidth = 80;
        public static int TableHeight = 80;

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
 
    }
}
