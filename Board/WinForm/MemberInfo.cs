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
using Mosti.Camp2023.Models;

namespace Mosti.Camp2023.WinForm
{
    public partial class MemberInfo : Form, iMemberMethod
    {
        InfoBiz infoBiz = new InfoBiz();
        Member originMember = new Member();
        public MemberInfo()
        {
            InitializeComponent();
            this.TopLevel = false;
            this.Dock = DockStyle.Fill;
            this.FormBorderStyle = FormBorderStyle.None;
            this.profileImg.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        //override
        public void saveEmp()
        {
            if (string.IsNullOrEmpty(this.labelEmpID.Text))
            {
                this.createEmp();
            }
            else
            {
                this.modifyEmp();
            }
        }

        //사원정보 저장 메서드
        //입력창의 값을 Member와 Career에 담아 생성 비즈니스 호출
        //경력이 있는 경우와 없는 경우 호출되는 메서드가 다름
        //반환된 ID값을 화면에 띄워줌
        public void createEmp()
        {
            int empID;

            Member newMember = new Member();
            newMember.Name = this.inputName.Text;
            newMember.Age = (int)this.inputAge.Value;
            newMember.Address = this.inputAddress.Text;
            newMember.PhoneNum = this.inputPhoneNum.Text;
            newMember.ProfileImg = this.profileImg.ImageLocation;

            bool result = true;
            if (this.dgvCareer.Rows.Count > 1)
            {
                List<Career> careerList = new List<Career>();
                DataTable careerTable = (DataTable)this.dgvCareer.DataSource;
                foreach (DataRow item in careerTable.Rows)
                {
                    if(item["FromDT"] != null)
                    {
                        Career career = new Career();
                        career.FromDT = item["FromDT"] as string;
                        career.EndDT = item["EndDT"] as string;

                        if (string.IsNullOrEmpty(item["Memo"] as string))
                            career.Memo = "";
                        else
                            career.Memo = item["Memo"] as string;

                        careerList.Add(career);
                    }
                }
                 empID = infoBiz.createEmpInfo(newMember);
                result = infoBiz.createEmpCareer(empID, careerList);
            }
            else
            {
                empID = infoBiz.createEmpInfo(newMember);
            }

            if (result && !string.IsNullOrEmpty(empID.ToString()))
            {
                this.labelEmpID.Text = empID.ToString();
                MessageBox.Show("사원 정보가 등록되었습니다.");
            }
            else
            {
                MessageBox.Show("사원 정보가 등록되지 못했습니다.");
            }
            
        }

        public void modifyEmp()
        {
            int empID = Convert.ToInt32(this.labelEmpID.Text);

            string name = this.inputName.Text;
            int age = (int)this.inputAge.Value;
            string address = this.inputAddress.Text;
            string phoneNum = this.inputPhoneNum.Text;
            string profileImg = this.profileImg.ImageLocation;
            

            Member newMember = null;
            if (infoIsChanged(name, age, address, phoneNum, profileImg))
            {
                newMember = new Member();
                newMember.EmpSeq = empID;
                newMember.Name = name;
                newMember.Age = age;
                newMember.Address = address;
                newMember.PhoneNum = phoneNum;
                newMember.ProfileImg = profileImg;
            }

            DataTable originCareer = (DataTable)this.dgvCareer.DataSource;
            List<Career> createList = getChangedCareer(empID, originCareer, DataRowState.Added);
            List<Career> changeList = getChangedCareer(empID, originCareer, DataRowState.Modified);

            if (newMember == null && createList == null && changeList == null)
            {
                MessageBox.Show("수정할 사항이 없습니다.");
            }
            else 
            {
                bool memberResult = true;
                bool newCareerResult = true;
                bool changeCareerResult = true;
                if (newMember != null)
                {
                    memberResult = infoBiz.changeEmpInfo(newMember);
                }
                if(createList != null)
                {
                    newCareerResult = infoBiz.createEmpCareer(empID, createList);
                }
                if(changeList != null)
                {
                    changeCareerResult = infoBiz.changeEmpCareer(changeList);
                }

                if (memberResult && newCareerResult && changeCareerResult)
                {
                    MessageBox.Show("사원 정보가 수정되었습니다.");
                }
                else
                {
                    MessageBox.Show("사원 정보가 수정되지 못했습니다.");
                }
            }

            
        }

        // 사원정보가 변경되었는지 체크하는 메서드
        private bool infoIsChanged(string name, int age, string address, string phone, string img)
        {
            bool result = false;
            
            if(originMember.Name != name || originMember.Age != age || originMember.Address != address 
                || originMember.PhoneNum != phone || originMember.ProfileImg != img)
            {
                result = true;
            }
            return result;
        }

        // 수정된 경력사항을 List로 만드는 메서드
        // DataRowState에 따라 생성/수정 여부를 판별하고
        // 그에 맞는 데이터를 입력해 반환함
        private List<Career> getChangedCareer(int empID, DataTable origin, DataRowState state)
        {
            DataTable careers = origin.GetChanges(state);
            List<Career> changeList = null;
            if(careers != null)
            {
                changeList = new List<Career>();
                foreach (DataRow item in careers.Rows)
                {
                    Career career = new Career();
                    career.EmpSeq = empID;
                    if(state == DataRowState.Modified)
                    {
                        career.CareerSeq = Convert.ToInt32(item["No"]);
                    }
                    career.FromDT = Convert.ToDateTime(item["FromDT"]).ToString("yyyy-MM-dd");
                    career.EndDT = Convert.ToDateTime(item["EndDT"]).ToString("yyyy-MM-dd");

                    if (string.IsNullOrEmpty(item["Memo"] as string))
                        career.Memo = "";
                    else
                        career.Memo = item["Memo"] as string;

                    changeList.Add(career);
                }
            }

            return changeList;
        }

        //사원정보 조회 메서드
        //사원정보 조회하는 비즈니스를 호출해
        //반환된 값을 Member와 DataTable에 담고, 화면에 보여줌
        public void getMemberInfo(int empID)
        {
            Member member = infoBiz.getEmpInfo(empID);
            originMember = member;

            this.labelEmpID.Text = Convert.ToString(member.EmpSeq);
            this.inputName.Text = member.Name;
            this.inputAge.Value = member.Age;
            this.inputAddress.Text = member.Address;
            this.inputPhoneNum.Text = member.PhoneNum;
            this.profileImg.ImageLocation = member.ProfileImg;

            DataTable career = infoBiz.getEmpCareer(empID);
            if(career.Rows.Count > 1)
            {
                this.dgvCareer.DataSource = career;
            }
            else
            {
                setNewCareerTable();
            }
        }



        //override
        //사원정보 삭제 메서드
        //화면에 쓰인 ID값을 가져와 삭제하는 비즈니스 호출 후
        //화면의 내용은 초기화하고 알림창을 띄움
        public void removeEmp()
        {
            int empID = Convert.ToInt32(this.labelEmpID.Text);

            bool result = infoBiz.eraseEmpInfo(empID);
            

            if (result)
            {
                initInfo();
                MessageBox.Show("사원 정보가 삭제되었습니다.");
            }
            else
            {
                MessageBox.Show("사원 정보가 삭제되지 못했습니다.");
            }
            
        }

        //사원정보 화면을 초기화하는 메서드
        public void initInfo()
        {
            this.labelEmpID.Text = "";
            this.inputName.Text = "";
            this.inputAge.Value = 0;
            this.inputAddress.Text = "";
            this.inputPhoneNum.Text = "";
            this.profileImg.ImageLocation = "";
            this.dgvCareer.DataSource = null;
            this.dgvCareer.Refresh();
        }

        //경력 테이블을 새로 세팅하는 메서드
        public void setNewCareerTable()
        {
            DataTable career = new DataTable("Career");
            career.Columns.Add("No", typeof(int));
            career.Columns.Add("FromDt", typeof(string));
            career.Columns.Add("EndDt", typeof(string));
            career.Columns.Add("Memo", typeof(string));
            career.Columns["No"].ReadOnly = true;

            this.dgvCareer.DataSource = career;
        }

        //사원정보 이미지 저장 메서드
        private void inputImg_Click(object sender, EventArgs e)
        {
            string imgPath;
            using(OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image Files(*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF|All files (*.*)|*.*";

                if(ofd.ShowDialog() == DialogResult.OK)
                {
                    imgPath = ofd.FileName;
                    this.profileImg.ImageLocation = imgPath;
                }
            }
        }

        //override
        public void setEmpList()
        {
            throw new NotImplementedException();
        }
    }
}
