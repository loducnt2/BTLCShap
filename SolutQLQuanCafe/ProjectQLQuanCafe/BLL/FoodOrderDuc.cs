using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectQLQuanCafe.BLL
{
    public class FoodOrderDuc
    {
        public int ID { get; set; }
        public DateTime? TimeCheckIn { get; set; }
        public DateTime? TimeCheckOut { get; set; }
        public int Status { get; set; }
        public float TotalPrice { get; set; }
        public int Discount { get; set; }

        public FoodOrderDuc(int id, DateTime? timeCheckIn, DateTime? timeCheckOut, int status, float totalPrice, int discount)
        {
            this.ID = id;
            this.TimeCheckIn = timeCheckIn;
            this.TimeCheckOut = timeCheckOut;
            this.Status = status;
            this.TotalPrice = totalPrice;
            this.Discount = discount;
        }

        public FoodOrderDuc(DataRow row)
        {
            
            this.ID = (int)row["id"];
            this.TimeCheckIn = (DateTime?)row["TimeCheckIn"];
            /*
                 var TimeCheckInTemp = row["TimeCheckIn"];
                 if (TimeCheckInTemp.ToString() != "")
                     this.TimeCheckIn = (DateTime?)TimeCheckInTemp;
                     */
            //this.TimeCheckIn = (DateTime?)row["TimeCheckOut"];
                 var TimeCheckOutTemp = row["TimeCheckOut"];
                 if(TimeCheckOutTemp.ToString() != "")
                     this.TimeCheckOut = (DateTime?)TimeCheckOutTemp;

            this.Status = (int)row["Status"];
            //this.TotalPrice = (float)Convert.ToDouble(row["totalPrice"].ToString());
            //this.Discount = (int)row["discount"];

        }
    }
}
