using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using Mosti.Camp2023.Models;

namespace Mosti.Camp2023.DataAccess
{
    public class InfoAccess
    {
        Base connInfo = new Base();

        public int insertEmp(string sql, Member member)
        {
            int empID = 0;
            using (SqlConnection conn = new SqlConnection(connInfo.getStrConn()))
            {
                try
                {
                    conn.Open();

                    SqlCommand command = new SqlCommand(sql, conn);
                    //@name, @age, @address, @phoneNum, @profileImg
                    command.Parameters.AddWithValue("@name", member.Name);
                    command.Parameters.AddWithValue("@age", member.Age);
                    command.Parameters.AddWithValue("@address", member.Address);
                    command.Parameters.AddWithValue("@phoneNum", member.PhoneNum);
                    command.Parameters.AddWithValue("@profileImg", member.ProfileImg);

                    empID = (int)command.ExecuteScalar();
                }
                catch(Exception ex)
                {
                    Debug.WriteLine(ex.ToString());
                }
            }
            return empID;
        }

        public bool insertCareer(string sql, int empID, List<Career> careers)
        {
            bool result = false;
            using(SqlConnection conn = new SqlConnection(connInfo.getStrConn()))
            {
                try
                {
                    conn.Open();

                    foreach(Career career in careers)
                    {
                        SqlCommand command = new SqlCommand(sql, conn);
                        // @empID, @fromDT, @endDT, @memo
                        command.Parameters.AddWithValue("@empID", empID);
                        command.Parameters.AddWithValue("@fromDT", career.FromDT);
                        command.Parameters.AddWithValue("@endDT", career.EndDT);
                        command.Parameters.AddWithValue("@memo", career.Memo);

                        command.ExecuteNonQuery();
                    }

                    result = true;

                }
                catch(Exception ex)
                {
                    Debug.WriteLine(ex.ToString());
                }
            }
            return result;
        }

        public Member selectEmpInfo(string sql, int empID)
        {
            Member member = new Member();
            using(SqlConnection conn = new SqlConnection(connInfo.getStrConn()))
            {
                try
                {
                    conn.Open();

                    SqlCommand command = new SqlCommand(sql, conn);
                    command.Parameters.AddWithValue("@empID", empID);

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        member.EmpSeq = Convert.ToInt32(reader["Emp_Seq"]);
                        member.Name = reader["Emp_Name"] as string;
                        member.Age = Convert.ToInt32(reader["Emp_Age"]);
                        member.Address = reader["Emp_Address"] as string;
                        member.PhoneNum = reader["Emp_Phone"] as string;
                        member.ProfileImg = reader["Emp_Profile"] as string;
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.ToString());
                }
            }
            return member;
        }

        public DataTable selectEmpCareer(string sql, int empID)
        {
            DataTable careerTable = new DataTable();
            using(SqlConnection conn = new SqlConnection(connInfo.getStrConn()))
            {
                try
                {
                    conn.Open();

                    SqlCommand command = new SqlCommand(sql, conn);
                    command.Parameters.AddWithValue("@empID", empID);

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(careerTable);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.ToString());
                }
            }
            careerTable.Columns[0].ColumnName = "No";
            careerTable.Columns[1].ColumnName = "FromDt";
            careerTable.Columns[2].ColumnName = "EndDt";
            return careerTable;
        }

        public bool updateEmp(string sql, Member member)
        {
            bool result = false;

            using(SqlConnection conn = new SqlConnection(connInfo.getStrConn()))
            {
                try
                {
                    conn.Open();

                    SqlCommand command = new SqlCommand(sql, conn);
                    //@name, @age, @address, @phoneNum, @profileImg, @empID
                    command.Parameters.AddWithValue("@name", member.Name);
                    command.Parameters.AddWithValue("@age", member.Age);
                    command.Parameters.AddWithValue("@address", member.Address);
                    command.Parameters.AddWithValue("@phoneNum", member.PhoneNum);
                    command.Parameters.AddWithValue("@profileImg", member.ProfileImg);
                    command.Parameters.AddWithValue("@empID", member.EmpSeq);

                    command.ExecuteNonQuery();

                    result = true;
                }
                catch(Exception ex)
                {
                    Debug.WriteLine(ex.ToString());
                }
            }
            return result;
        }

        public bool updateCareer(string sql, List<Career> careers)
        {
            bool result = false;
            using (SqlConnection conn = new SqlConnection(connInfo.getStrConn()))
            {
                try
                {
                    conn.Open();

                    foreach (Career career in careers)
                    {
                        SqlCommand command = new SqlCommand(sql, conn);
                        // @empID, @Career_Seq, @fromDT, @endDT, @memo
                        command.Parameters.AddWithValue("@empID", career.EmpSeq);
                        command.Parameters.AddWithValue("@careerSeq", career.CareerSeq);
                        command.Parameters.AddWithValue("@fromDT", career.FromDT);
                        command.Parameters.AddWithValue("@endDT", career.EndDT);
                        command.Parameters.AddWithValue("@memo", career.Memo);

                        command.ExecuteNonQuery();
                    }

                    result = true;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.ToString());
                }
            }
            return result;
        }

        public bool deleteEmpInfo(string sql, int empID)
        {
            bool result = false;
            using(SqlConnection conn = new SqlConnection(connInfo.getStrConn()))
            {
                try
                {
                    conn.Open();

                    SqlCommand command = new SqlCommand(sql, conn);
                    command.Parameters.AddWithValue("@empID", empID);
                    command.ExecuteNonQuery();

                    result = true;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.ToString());
                }
            }

            return result;
        }

        public bool deleteEmpCareer(string sql, int empID)
        {
            bool result = false;
            using (SqlConnection conn = new SqlConnection(connInfo.getStrConn()))
            {
                try
                {
                    conn.Open();

                    SqlCommand command = new SqlCommand(sql, conn);
                    command.Parameters.AddWithValue("@empID", empID);
                    command.ExecuteNonQuery();

                    result = true;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.ToString());
                }
            }
            return result;
        }

    }
}