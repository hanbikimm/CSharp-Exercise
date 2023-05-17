using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mosti.Camp2023.DataAccess;
using Mosti.Camp2023.Models;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Data;

namespace Mosti.Camp2023.Business
{
    public class InfoBiz
    {
        InfoAccess infoAccess = new InfoAccess();

        public Member getEmpInfo(int empID)
        {
            string sql = "SELECT Emp_Seq, Emp_Name, Emp_Age, Emp_Address, Emp_Phone, Emp_Profile " +
                "FROM Employee WHERE Emp_Seq = @empID";

            Member member = infoAccess.selectEmpInfo(sql, empID);

            return member;
        }

        public DataTable getEmpCareer(int empID)
        {
            string sql = "SELECT Career_Seq, From_DT, End_DT, Memo " +
                "FROM Career WHERE Emp_Seq = @empID";

            DataTable careerTable = infoAccess.selectEmpCareer(sql, empID);

            return careerTable;
        }

        public bool eraseEmpInfo(int empID)
        {
            bool result = false;
            if (eraseEmpCareer(empID))
            {
                string sql = "DELETE FROM Employee WHERE Emp_Seq = @empID";
                result = infoAccess.deleteEmpInfo(sql, empID);
            }

            return result;
        }

        public bool eraseEmpCareer(int empID)
        {
            string sql = "DELETE FROM Career WHERE Emp_Seq = @empID";
            bool result = infoAccess.deleteEmpCareer(sql, empID);

            return result;
        }

        public int createEmpInfo(Member member) 
        {
            string sql = "INSERT INTO Employee " +
                "OUTPUT  INSERTED.Emp_Seq " +
                "VALUES (@name, @age, @address, @phoneNum, @profileImg)";
            
            int empID = infoAccess.insertEmp(sql, member);

            return empID;
        }

        public bool  createEmpCareer(int empID, List<Career> careers)
        {
            string sql = "INSERT INTO Career " +
                "VALUES (@empID, CONVERT(DATE, @fromDT), CONVERT(DATE, @endDT), @memo)";

            bool result = infoAccess.insertCareer(sql, empID, careers);

            return result;
        }

        public bool changeEmpInfo(Member member)
        {
            string sql = "UPDATE Employee " +
                "SET Emp_Name = @name" +
                ", Emp_Age = @age" +
                ", Emp_Address = @address" +
                ", Emp_Phone = @phoneNum" +
                ", Emp_Profile = @profileImg " +
                "WHERE Emp_Seq = @empID";

            bool result = infoAccess.updateEmp(sql, member);
            
            return result;
        }

        public bool changeEmpCareer(List<Career> careers)
        {
            string sql = "UPDATE Career " +
                "SET From_DT = Convert(DATE, @fromDT)" +
                ", End_DT = CONVERT(DATE, @endDT)" +
                ", Memo = @memo " +
                "WHERE Emp_Seq = @empID AND Career_Seq = @careerSeq";

            bool result = infoAccess.updateCareer(sql, careers);

            return result;
        }

        

    }
}
