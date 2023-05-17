using Mosti.Camp2023.DataAccess;
using System.Data;
using System.Text;

namespace Mosti.Camp2023.Business
{
    public class ListBiz
    {
        ListAccess listAccess = new ListAccess();

        public DataTable getEmpList()
        {
            string sql = "SELECT Emp_Seq, Emp_Name, Emp_Age, Emp_Address, Emp_Phone, Emp_Profile " +
                "FROM Employee";
            return listAccess.selectAllEmpList(sql);
        }

        public DataTable getEmpList(Dictionary<string, string> keyWords)
        {
            string sql = "SELECT DISTINCT A.Emp_Seq, A.Emp_Name, A.Emp_Age, A.Emp_Address, A.Emp_Phone, A.Emp_Profile " +
                "FROM ( " +
                    "SELECT E.Emp_Seq, E.Emp_Name, E.Emp_Age, E.Emp_Address, E.Emp_Phone, E.Emp_Profile, C.From_DT, C.End_DT, C.Memo " +
                    "FROM Employee AS E " +
                    "LEFT OUTER JOIN Career AS C ON E.Emp_Seq = C.Emp_Seq " +
                ") AS A WHERE ";

            return listAccess.selectSomeEmpList(sql, keyWords);
        }
    }
}