using System.Diagnostics;


namespace Task2
{
    public partial class accModifier : Form
    {
        public accModifier()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SecondClass secondClass = new SecondClass();
        }
    }

    public class FirstClass
    {
        public String strPublic = "ù��° Ŭ������ public ����";
        internal String strInternal = "ù��° Ŭ������ internal ����";
        protected String strProtected = "ù��° Ŭ������ protected ����";
        private String strPrivate = "ù��° Ŭ������ private ����";

        public void getFirstClass()
        {
            Debug.WriteLine("���� ������Ʈ�� 1��° Ŭ���� ���� ȣ��");
            Debug.WriteLine(strPublic);
            //Debug.WriteLine(strInternal);
            //Debug.WriteLine(strProtected);
            //Debug.WriteLine(strPrivate);
            Debug.WriteLine("");

        }

    }

    public class SecondClass
    {
        public SecondClass()
        {
            FirstClass firstClass = new FirstClass();
            Debug.WriteLine("2��° Ŭ�������� 1��° Ŭ���� ���� ȣ��");
            Debug.WriteLine(firstClass.strPublic);
            Debug.WriteLine(firstClass.strInternal);
            //Debug.WriteLine(firstClass.strProtected);
            //Debug.WriteLine(firstClass.strPrivate);
            Debug.WriteLine("");

            ThirdClass thirdClass = new ThirdClass();

        }
    }

    public class ThirdClass : FirstClass
    {
        public ThirdClass()
        {
            Debug.WriteLine("3��° Ŭ�������� ��ӹ��� 1��° Ŭ���� ���� ȣ��");
            Debug.WriteLine(this.strPublic);
            Debug.WriteLine(this.strInternal);
            Debug.WriteLine(this.strProtected);
            //Debug.WriteLine(this.strPrivate);
            Debug.WriteLine("");
        }

        public void getThirdClass()
        {
            Debug.WriteLine("���� ������Ʈ�� 3��° Ŭ���� ���� ȣ��");
            Debug.WriteLine(this.strPublic);
            //Debug.WriteLine(this.strInternal);
            Debug.WriteLine(this.strProtected);
            //Debug.WriteLine(this.strPrivate);
            Debug.WriteLine("");
        }
    }

}