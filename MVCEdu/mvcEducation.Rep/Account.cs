using mvcEducation.Contract.Models;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mvcEducation.Rep
{
    public class Account
    {
        private string strConn = "Data Source=localhost;Initial Catalog=MVC;Persist Security Info=false;Integrated Security=false;User ID=sa;Password=mssql;enlist=true;";
        public bool CheckLogin(AccountModel request)
        {
            // 결과 반환 데이터 
            bool result = false;
            AccountModel response = new AccountModel();
            string responseID = response.accountEntity.ID;
            string responsePW = response.accountEntity.Password;

            // DB 쿼리문 실행해 받은 데이터를 확인
            DataTable userInfo = new DataTable();
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("UP_ACT_CheckLogin", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Request_ID", request.accountEntity.ID);

                    SqlDataAdapter adapter = new SqlDataAdapter();
                    adapter.SelectCommand = cmd;

                    adapter.Fill(userInfo);
                }
                catch(Exception ex)
                {
                    Debug.WriteLine(ex.ToString());
                }

            }

            foreach(DataRow row in userInfo.Rows)
            {
                string ID = row["ID"] as string;
                string PW = row["Password"]as string;

                if (checkNull(ID, PW))
                {
                    responseID = ID;
                    responsePW = PW;
                }
            }

            
            if (request.accountEntity.ID == responseID && request.accountEntity.Password == responsePW)
            {
                result = true;
            }

            return result;
        }

        private bool checkNull(string ID, string PW)
        {
            bool result = false;
            if (!string.IsNullOrEmpty(ID) && !string.IsNullOrEmpty(PW))
            {
                result = true;
            }
                return result;
        }
    }
}
