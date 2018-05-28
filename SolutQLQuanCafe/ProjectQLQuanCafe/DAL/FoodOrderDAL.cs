using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using ProjectQLQuanCafe.BLL;

namespace ProjectQLQuanCafe.DAL
{
    public class FoodOrderDAL
    {
        DataProvider dtPro = new DataProvider();
        public int GetUnCheckOrderByTableID(int id)
        {
            string query = "select * from FoodOrder where idFoodTable = "+ id +" AND Status = 0";
            DataTable dt = dtPro.ExecuteQuery(query);
            if(dt.Rows.Count > 0)
            {
                FoodOrderDuc order = new FoodOrderDuc(dt.Rows[0]);
                return order.ID;
            }
            return -1;
        }
    }
}
