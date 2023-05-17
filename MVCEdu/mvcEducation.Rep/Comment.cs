using mvcEducation.Contract.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Data;

namespace mvcEducation.Rep
{
    public class Comment
    {
        private string strConn = "Data Source=localhost;Initial Catalog=MVC;Persist Security Info=false;Integrated Security=false;User ID=sa;Password=mssql;enlist=true;";
        public List<CommentEntity> CommentList()
        {
            List<CommentEntity> result = new List<CommentEntity>();

            // 과제: 
            // 댓글 테이블 설계 및 생성 -> 작성자, 본문, 댓글 ID, 보드 ID, Depth
            // 댓글 목록 데이터를 DB에서 등록 Depth는 2까지 (댓글과 대댓글): 본문은 0, 
            // 댓글 목록 조회 SP 생성 > DB 연결 > SP 조회 > result에 담아서 화면에 뿌리기
            DataTable commentList = new DataTable();

            using (SqlConnection conn = new SqlConnection(strConn))
            {
                try
                {
                    conn.Open();
                    Debug.WriteLine("접속 성공");

                    SqlCommand cmd = new SqlCommand("UP_CMT_GetComment_Depth2", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(commentList);

                }
                catch(Exception ex)
                {
                    Debug.WriteLine(ex.ToString());
                }
            }

            // DB 데이터 result에 넣기
            foreach (DataRow data in commentList.Rows)
            {
                CommentEntity comment = new CommentEntity();
                comment.Relation = data["Relation"] as string;
                comment.Writer = data["Writer"] as string;
                comment.Content = data["Content"] as string;

                result.Add(comment);
            }

            return result;
        }
    }
}
