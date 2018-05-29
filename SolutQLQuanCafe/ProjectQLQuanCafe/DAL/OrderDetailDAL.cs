using ProjectQLQuanCafe.BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectQLQuanCafe.DAL
{
    public class OrderDetailDAL
    {
        DataProvider dtPro = new DataProvider();
        public List<OrderDetailDuc> GetListOrderDetail(int id)
        {
            List<OrderDetailDuc> listOrderDetail = new List<OrderDetailDuc>();

            string query = "select * from OrderDetail where OrderDetail.idFoodOrder = " + id;
            DataTable dt = dtPro.ExecuteQuery(query);

            foreach (DataRow item in dt.Rows)
            {
                OrderDetailDuc detail = new OrderDetailDuc(item);
                listOrderDetail.Add(detail);
            }
            return listOrderDetail;
        }
    }
}
