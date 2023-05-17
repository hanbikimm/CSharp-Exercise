using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Collections.Specialized;
using System.Diagnostics;

namespace Mosti.Camp2023.DataAccess
{
    public class Base
    {
        //readonly string dataSource = ConfigurationManager.AppSettings["dataURL"];
        //readonly string dataName = ConfigurationManager.AppSettings["dataName"];
        //readonly string userID = ConfigurationManager.AppSettings["userID"];
        //readonly string userPW = ConfigurationManager.AppSettings["userPW"];

        private string dataSource
        {
            get { return "localhost"; }
        }

        private string dataName
        {
            get { return "Board";  }
        }

        private string userID
        {
            get { return "sa";  }
        }

        private string userPW
        {
            get { return "mssql";  }
        }

        public string getStrConn()
        {
            string strConn = string.Format($"Data Source={dataSource};Initial Catalog={dataName};Persist Security Info=false;Integrated Security=false;User ID={userID};Password={userPW};enlist=true;");

            return strConn;
        }
    }
}
