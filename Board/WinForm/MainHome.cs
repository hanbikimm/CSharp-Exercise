using Mosti.Camp2023.Business;
using System.Data;
using System.Diagnostics;

namespace Mosti.Camp2023.WinForm
{
    public partial class MainHome : Form
    {
        MemberInfo memberInfo = new MemberInfo();
        MemberList memberList = new MemberList();
        TabPage infoTabPage = new TabPage("��� ����");
        TabPage listTabPage = new TabPage("��� ���");

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

        //comboBox ����
        private void setComboBox()
        {
            tabCombo.Items.Add("��� ���");
            tabCombo.Items.Add("��� ����");
            tabCombo.SelectedIndex = 0;
        }

        //���� ��ư Ŭ��
        private void btnSave_Click(object sender, EventArgs e)
        {
            var nowControl = tabControl.SelectedTab.Controls[0];
            ((iMemberMethod)nowControl).saveEmp();
        }

        //���� ��ư Ŭ��
        private void btnDelete_Click(object sender, EventArgs e)
        {
            var nowControl = tabControl.SelectedTab.Controls[0];
            ((iMemberMethod)nowControl).removeEmp();
        }

        //��ȸ ��ư Ŭ��
        private void btnSelect_Click(object sender, EventArgs e)
        {
            var nowControl = tabControl.SelectedTab.Controls[0];
            ((iMemberMethod)nowControl).setEmpList();
        }

        //�ű� ��ư Ŭ��
        //���� ������� ���� �ִٸ� �ű� �Է�â���� �ʱ�ȭ ��Ű�� �ش� ������ �̵���Ű��,
        //�ƴ϶�� ���� ����� �ű� �Է�â���� �ʱ�ȭ��
        private void btnNew_Click(object sender, EventArgs e)
        {
            if (tabControl.TabPages.Contains(infoTabPage) == true)
            {
                memberInfo.initInfo();
                memberInfo.setNewCareerTable();
                tabControl.SelectedTab = infoTabPage;
                MessageBox.Show("���α׷��� �̹� ���� ���Դϴ�.\n�ش� TAB���� �̵��մϴ�.");
            }
            else
            {
                createInfoTab();
                memberInfo.initInfo();
                memberInfo.setNewCareerTable();
            }
        }

        //ȣ�� ��ư Ŭ��
        //�޺��ڽ��� ���� ���� ���� ������.
        //���� ���� �ִٸ� ������ �̵�, ���ٸ� ���� ���� ����
        private void btnGetTab_Click(object sender, EventArgs e)
        {
            string selectedTab = tabCombo.SelectedItem.ToString();
            if(selectedTab == "��� ���")
            {
                if (tabControl.TabPages.Contains(listTabPage) == true)
                {
                    tabControl.SelectedTab = listTabPage;
                    MessageBox.Show("���α׷��� �̹� ���� ���Դϴ�.\n�ش� TAB���� �̵��մϴ�.");
                }
                else
                { 
                    createListTab();
                }
            }
            else if(selectedTab == "��� ����")
            {
                if (tabControl.TabPages.Contains(infoTabPage) == true)
                {
                    tabControl.SelectedTab = infoTabPage;
                    MessageBox.Show("���α׷��� �̹� ���� ���Դϴ�.\n�ش� TAB���� �̵��մϴ�.");
                }
                else
                {
                    createInfoTab();
                }
            }
        }

        //������� �� ����
        //memberInfo�� �� �������� �߰��ϰ�, �� �������� ��Ʈ�ѿ� �߰���
        //�׸��� ������� form�� ���̰��ϰ�, �ش� ������ �̵���
        public void createInfoTab()
        {
            infoTabPage.Controls.Add(memberInfo);
            tabControl.TabPages.Add(infoTabPage);
            memberInfo.Show();

            tabControl.SelectedTab = infoTabPage;
        }

        //������ �� ����
        //memberList�� �� �������� �߰��ϰ�, �� �������� ��Ʈ�ѿ� �߰���
        //�׸��� ������ form�� ���̰��ϰ�, �ش� ������ �̵���
        private void createListTab()
        {
            listTabPage.Controls.Add(memberList);
            tabControl.TabPages.Add(listTabPage);
            memberList.Show();

            tabControl.SelectedTab = listTabPage;
            
        }

        //���� ��ư Ŭ��
        //���� ���õ� �ǿ� ����, ���� ������ �ʱ�ȭ�ϰ�, ���� ���������� ������
        private void btnDeleteTab_Click(object sender, EventArgs e)
        {
            if (tabControl.TabPages.Count > 0)
            {
                if (tabControl.SelectedTab.ToString() == "TabPage: {��� ���}")
                {
                    memberList.initList();
                }
                else if (tabControl.SelectedTab.ToString() == "TabPage: {��� ����}")
                {
                    memberInfo.initInfo();
                }

                tabControl.TabPages.Remove(tabControl.SelectedTab);
            }
            else
            {
                MessageBox.Show("������ Tab�� �����ϴ�");
            }
                
        }

        //��� ��ȸ���� �󼼷� �Ѿ �� ���� ȣ��
        //���� �ִٸ� ������ �̵�, ���ٸ� ���� ���� ����
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

        //��ư ����
        //�ǿ� ���� Ȱ��ȭ�Ǵ� ��ư�� ����
        private void setButtons(string selectedTab)
        {
            if (selectedTab == "TabPage: {��� ���}")
            {
                this.btnSelect.Enabled = true;
                this.btnSave.Enabled = false;
                this.btnDelete.Enabled = false;
            }
            else if (selectedTab == "TabPage: {��� ����}")
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

        // ���õ� ���� �ٲ� ������ ��ư������ ����
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

        //// ���� ������ �� ��ư ����
        private void tabControl_ControlAdded(object sender, ControlEventArgs e)
        {
            string selectedTab = this.tabControl.SelectedTab.ToString();
            setButtons(selectedTab);
        }
    }
}