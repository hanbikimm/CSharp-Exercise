using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Data;

namespace Mosti.Camp2023.DataAccess
{
    public class ListAccess
    {
        Base connInfo = new Base();

        public DataTable selectAllEmpList(string sql)
        {
            DataTable empList = new DataTable();
            using (SqlConnection conn = new SqlConnection(connInfo.getStrConn()))
            {
                try
                {
                    conn.Open();
                    Debug.WriteLine("접속성공");
                    
                    SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
                    adapter.Fill(empList);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.ToString());
                }
            }

            return empList;
        }

        public DataTable selectSomeEmpList(string origin, Dictionary<string, string> keyWords)
        {
            DataTable empList = new DataTable();
            using(SqlConnection conn = new SqlConnection(connInfo.getStrConn()))
            {
                try
                {
                    conn.Open();

                    SqlCommand command = new SqlCommand();
                    StringBuilder sql = new StringBuilder();
                    sql.Append(origin);

                    int count = keyWords.Count;
                    foreach (var key in keyWords.Keys)
                    {
                        switch (key)
                        {
                            case "Emp_Seq":
                                sql.Append($"A.{key} = @Emp_Seq");
                                command.Parameters.AddWithValue("@Emp_Seq", Convert.ToInt32(keyWords[key]));
                                --count;
                                break;
                            case "Emp_Name":
                                sql.Append($"A.{key} LIKE @Emp_Name");
                                command.Parameters.AddWithValue("@Emp_Name", $"%{keyWords[key]}%");
                                --count;
                                break;
                            case "Emp_Address":
                                sql.Append($"A.{key} LIKE @Emp_Address");
                                command.Parameters.AddWithValue("@Emp_Address", $"%{keyWords[key]}%");
                                --count;
                                break;
                            case "Memo":
                                sql.Append($"A.{key} LIKE @Memo");
                                command.Parameters.AddWithValue("@Memo", $"%{keyWords[key]}%");
                                --count;
                                break;
                            case "From_DT":
                                sql.Append($"A.{key} >= @From_DT");
                                command.Parameters.AddWithValue("@From_DT", keyWords[key]);
                                --count;
                                break;
                            case "End_DT":
                                sql.Append($"A.{key} <= @End_DT");
                                command.Parameters.AddWithValue("@End_DT", keyWords[key]);
                                --count;
                                break;
                        }

                        if (count > 0)
                        {
                            sql.Append(" AND ");
                        }

                    }

                    command.CommandText = sql.ToString();
                    command.Connection = conn;

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(empList);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.ToString());
                }
            }
            return empList;
        }
    }
}
