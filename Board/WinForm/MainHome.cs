using Mosti.Camp2023.Business;
using System.Data;
using System.Diagnostics;

namespace Mosti.Camp2023.WinForm
{
    public partial class MainHome : Form
    {
        MemberInfo memberInfo = new MemberInfo();
        MemberList memberList = new MemberList();
        TabPage infoTabPage = new TabPage("사원 정보");
        TabPage listTabPage = new TabPage("사원 목록");

        public MainHome()
        {
            InitializeComponent();
        }
        
        private void MainHome_Load(object sender, EventArgs e)
        {
            setComboBox();
            this.btnSelect.Enabled = false;
            this.btnSave.Enabled = false;
            this.btnDelete.Enabled = false;
        }

        //comboBox 세팅
        private void setComboBox()
        {
            tabCombo.Items.Add("사원 목록");
            tabCombo.Items.Add("사원 정보");
            tabCombo.SelectedIndex = 0;
        }

        //저장 버튼 클릭
        private void btnSave_Click(object sender, EventArgs e)
        {
            var nowControl = tabControl.SelectedTab.Controls[0];
            ((iMemberMethod)nowControl).saveEmp();
        }

        //삭제 버튼 클릭
        private void btnDelete_Click(object sender, EventArgs e)
        {
            var nowControl = tabControl.SelectedTab.Controls[0];
            ((iMemberMethod)nowControl).removeEmp();
        }

        //조회 버튼 클릭
        private void btnSelect_Click(object sender, EventArgs e)
        {
            var nowControl = tabControl.SelectedTab.Controls[0];
            ((iMemberMethod)nowControl).setEmpList();
        }

        //신규 버튼 클릭
        //만약 사원정보 탭이 있다면 신규 입력창으로 초기화 시키고 해당 탭으로 이동시키고,
        //아니라면 탭을 만들고 신규 입력창으로 초기화함
        private void btnNew_Click(object sender, EventArgs e)
        {
            if (tabControl.TabPages.Contains(infoTabPage) == true)
            {
                memberInfo.initInfo();
                memberInfo.setNewCareerTable();
                tabControl.SelectedTab = infoTabPage;
                MessageBox.Show("프로그램이 이미 실행 중입니다.\n해당 TAB으로 이동합니다.");
            }
            else
            {
                createInfoTab();
                memberInfo.initInfo();
                memberInfo.setNewCareerTable();
            }
        }

        //호출 버튼 클릭
        //콤보박스의 값을 토대로 탭을 가져옴.
        //만약 탭이 있다면 탭으로 이동, 없다면 탭을 새로 만듦
        private void btnGetTab_Click(object sender, EventArgs e)
        {
            string selectedTab = tabCombo.SelectedItem.ToString();
            if(selectedTab == "사원 목록")
            {
                if (tabControl.TabPages.Contains(listTabPage) == true)
                {
                    tabControl.SelectedTab = listTabPage;
                    MessageBox.Show("프로그램이 이미 실행 중입니다.\n해당 TAB으로 이동합니다.");
                }
                else
                { 
                    createListTab();
                }
            }
            else if(selectedTab == "사원 정보")
            {
                if (tabControl.TabPages.Contains(infoTabPage) == true)
                {
                    tabControl.SelectedTab = infoTabPage;
                    MessageBox.Show("프로그램이 이미 실행 중입니다.\n해당 TAB으로 이동합니다.");
                }
                else
                {
                    createInfoTab();
                }
            }
        }

        //사원정보 탭 생성
        //memberInfo를 탭 페이지에 추가하고, 그 페이지를 컨트롤에 추가함
        //그리고 사원정보 form을 보이게하고, 해당 탭으로 이동함
        public void createInfoTab()
        {
            infoTabPage.Controls.Add(memberInfo);
            tabControl.TabPages.Add(infoTabPage);
            memberInfo.Show();

            tabControl.SelectedTab = infoTabPage;
        }

        //사원목록 탭 생성
        //memberList를 탭 페이지에 추가하고, 그 페이지를 컨트롤에 추가함
        //그리고 사원목록 form을 보이게하고, 해당 탭으로 이동함
        private void createListTab()
        {
            listTabPage.Controls.Add(memberList);
            tabControl.TabPages.Add(listTabPage);
            memberList.Show();

            tabControl.SelectedTab = listTabPage;
            
        }

        //제거 버튼 클릭
        //현재 선택된 탭에 따라, 탭의 내용을 초기화하고, 탭을 페이지에서 삭제함
        private void btnDeleteTab_Click(object sender, EventArgs e)
        {
            if (tabControl.TabPages.Count > 0)
            {
                if (tabControl.SelectedTab.ToString() == "TabPage: {사원 목록}")
                {
                    memberList.initList();
                }
                else if (tabControl.SelectedTab.ToString() == "TabPage: {사원 정보}")
                {
                    memberInfo.initInfo();
                }

                tabControl.TabPages.Remove(tabControl.SelectedTab);
            }
            else
            {
                MessageBox.Show("제거할 Tab이 없습니다");
            }
                
        }

        //목록 조회에서 상세로 넘어갈 때 탭을 호출
        //탭이 있다면 탭으로 이동, 없다면 탭을 새로 만듦
        public void moveToInfoTab()
        {
            if (tabControl.TabPages.Contains(infoTabPage) == true)
            {
                memberInfo.initInfo();
                tabControl.SelectedTab = infoTabPage;
            }
            else
            {
                createInfoTab();
            }
        }

        //버튼 세팅
        //탭에 따라 활성화되는 버튼을 구분
        private void setButtons(string selectedTab)
        {
            if (selectedTab == "TabPage: {사원 목록}")
            {
                this.btnSelect.Enabled = true;
                this.btnSave.Enabled = false;
                this.btnDelete.Enabled = false;
            }
            else if (selectedTab == "TabPage: {사원 정보}")
            {
                this.btnSelect.Enabled = false;
                this.btnSave.Enabled = true;
                this.btnDelete.Enabled = true;
            }
            else
            {
                this.btnSelect.Enabled = false;
                this.btnSave.Enabled = false;
                this.btnDelete.Enabled = false;
            }
        }

        // 선택된 탭이 바뀔 때마다 버튼세팅을 변경
        private void tabControl_Selected(object sender, TabControlEventArgs e)
        {
            string selectedTab;
            if (this.tabControl.SelectedTab == null)
            {
                selectedTab = "Clear";
            }
            else
            {
                selectedTab = this.tabControl.SelectedTab.ToString();
            }
            setButtons(selectedTab);
        }

        //// 탭이 생성될 때 버튼 세팅
        private void tabControl_ControlAdded(object sender, ControlEventArgs e)
        {
            string selectedTab = this.tabControl.SelectedTab.ToString();
            setButtons(selectedTab);
        }
    }
}