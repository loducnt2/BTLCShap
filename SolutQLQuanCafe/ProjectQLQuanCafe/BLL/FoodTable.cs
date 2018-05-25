using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using ProjectQLQuanCafe.DAL;

namespace ProjectQLQuanCafe.BLL
{
    public class FoodTable
    {
        DataProvider da = new DataProvider();

        public DataTable HienThiBan()
        {
            string sql = "select * from FoodTable";
            DataTable dt = new DataTable();

            dt = da.GetTable(sql);
            return dt;
        }

        public DataTable HienThiDanhMuc()
        {
            string sql = "select * from FoodCategory";
            DataTable dt = new DataTable();

            dt = da.GetTable(sql);
            return dt;
        }

        public DataTable HienThiMonTheoDanhMuc(int id)
        {
            string sql = "select Food.name from Food where idFoodCategory = " + id;
            DataTable dt = new DataTable();

            dt = da.GetTable(sql);
            return dt;
        }

        /*
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
