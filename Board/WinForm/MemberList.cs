using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Mosti.Camp2023.Business;

namespace Mosti.Camp2023.WinForm
{
    public partial class MemberList : Form, iMemberMethod
    {
        ListBiz listBiz = new ListBiz();

        public MemberList()
        {
            InitializeComponent();
            this.TopLevel = false;
            this.Dock = DockStyle.Fill;
            this.FormBorderStyle = FormBorderStyle.None;
        }

        //DGV 더블클릭시 상세정보로 이동하는 메서드
        //사원정보 탭으로 이동하고, 해당 탭에 ID 값에 따라 사원 정보를 화면에 보여줌
        private void dgvList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int empID = Convert.ToInt32(dgvList.Rows[e.RowIndex].Cells[0].Value);

            MainHome main = (MainHome)Application.OpenForms["MainHome"];
            main.moveToInfoTab();

            MemberInfo memberInfo = (MemberInfo)Application.OpenForms["MemberInfo"];
            memberInfo.getMemberInfo(empID);
        }

        //목록 조회 메서드
        //검색어가 있는지 체크하고 있다면 검색조회를,
        //아니라면 전체조회하는 비즈니스를 호출해 DataTable에 담고
        //화면에 데이터를 보여줌
        public void setEmpList()
        {
            DataTable empList = new DataTable();
            Dictionary<string, string> keyWords = checkKeyWords();
            if(keyWords.Count == 0)
            {
                empList = listBiz.getEmpList();
            }
            else
            {
                empList = listBiz.getEmpList(keyWords); 
            }
            dgvList.DataSource = empList;
        }

        //검색어 체크 메서드
        //검색 조건 중 입력된 값들을 체크해서 Dictionary 형태로 반환해줌
        private Dictionary<string, string> checkKeyWords()
        {
            Dictionary<string, string> keyWords = new Dictionary<string, string>();
            keyWords.Add("Emp_Seq", this.inputEmpID.Text);
            keyWords.Add("Emp_Name", this.inputName.Text);
            keyWords.Add("Emp_Address", this.inputAddress.Text);
            keyWords.Add("Memo", this.inputCareer.Text);
            keyWords.Add("From_DT", this.inputFromDT.Value.ToString("yyyy-MM-dd"));
            keyWords.Add("End_DT", this.inputEndDT.Value.ToString("yyyy-MM-dd"));

            if (keyWords["From_DT"] == keyWords["End_DT"])
            {
                keyWords.Remove("From_DT");
                keyWords.Remove("End_DT");
            }

            foreach(var key in keyWords.Keys)
            {
                if(keyWords[key] == null || keyWords[key] == string.Empty)
                {
                    keyWords.Remove(key);
                }
            }

            return keyWords;
        }

        //사원 목록 화면을 초기화하는 메서드
        public void initList()
        {
            this.inputEmpID.Text = "";
            this.inputName.Text = "";
            this.inputAddress.Text = "";
            this.inputCareer.Text = "";
            this.inputFromDT.Value = DateTime.Now;
            this.inputEndDT.Value = DateTime.Now;
            this.dgvList.DataSource = "";

        }

        //override
        public void saveEmp()
        {
            throw new NotImplementedException();
        }

        //override
        public void removeEmp()
        {
            throw new NotImplementedException();
        }

        
    }
}
