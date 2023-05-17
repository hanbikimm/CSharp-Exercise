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
        public String strPublic = "첫번째 클래스의 public 변수";
        internal String strInternal = "첫번째 클래스의 internal 변수";
        protected String strProtected = "첫번째 클래스의 protected 변수";
        private String strPrivate = "첫번째 클래스의 private 변수";

        public void getFirstClass()
        {
            Debug.WriteLine("참조 프로젝트의 1번째 클래스 변수 호출");
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
            Debug.WriteLine("2번째 클래스에서 1번째 클래스 변수 호출");
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
            Debug.WriteLine("3번째 클래스에서 상속받은 1번째 클래스 변수 호출");
            Debug.WriteLine(this.strPublic);
            Debug.WriteLine(this.strInternal);
            Debug.WriteLine(this.strProtected);
            //Debug.WriteLine(this.strPrivate);
            Debug.WriteLine("");
        }

        public void getThirdClass()
        {
            Debug.WriteLine("참조 프로젝트의 3번째 클래스 변수 호출");
            Debug.WriteLine(this.strPublic);
            //Debug.WriteLine(this.strInternal);
            Debug.WriteLine(this.strProtected);
            //Debug.WriteLine(this.strPrivate);
            Debug.WriteLine("");
        }
    }

}