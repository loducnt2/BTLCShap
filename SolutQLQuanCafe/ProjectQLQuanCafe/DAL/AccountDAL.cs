using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Data;
using ProjectQLQuanCafe.BLL;

namespace ProjectQLQuanCafe.DAL
{
    public class AccountDAL
    {
        /*
        private static AccountDAL instance;

        public static AccountDAL Instance
        {
            get { if (instance == null) instance = new AccountDAL(); return instance; }
            private set { instance = value; }
        }

        private AccountDAL() { }
        */
        DataProvider dtPro = new DataProvider();

        public bool Login(string userName, string password)
        {
            string query = "Select * from dbo.Account WHERE UserName = '" + userName+ "' AND Password = '" + password + "' "; //"USP_login @userName, @password";

            DataTable result = dtPro.ExecuteQuery(query);
            return result.Rows.Count > 0;
        }


        public Account GetAccountByUserName(string userName)
        {
            DataTable data =dtPro.ExecuteQuery("Select * from account where userName= '" + userName + "'");
            foreach (DataRow item in data.Rows)
            {
                return new Account(item);
            }

            return null;
        }

        internal void GetAccountByUserName()
        {
            throw new NotImplementedException();
        }
    }
}
