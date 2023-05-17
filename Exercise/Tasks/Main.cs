using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Data;
using System.Collections;
using Task2;
//using System.Configuration;

namespace Tasks
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            AppConfiguration.SetAppConfig("MostiID", "hanbikimm");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Read only
            //SetReadOnly original = new SetReadOnly();
            SetReadOnly useConstructor = new SetReadOnly("�����ڷ� ������ Read Only �Դϴ�.");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Float
            //float
            float floatNum = 1.1F;
            float floatNum2 = 2.5F;

            if (floatNum + floatNum2 == 3.3F)
            {
                MessageBox.Show("true");
            }
            else
            {
                MessageBox.Show("false");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Decimal
            decimal decimalNum = 1.1M;
            decimal decimalNum2 = 2.2M;

            if (decimalNum + decimalNum2 == 3.3M)
            {
                MessageBox.Show("true");
            }
            else
            {
                MessageBox.Show("false");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Enum
            ColorType color = ColorType.Yellow;
            if (color == ColorType.Black)
            {
                Debug.WriteLine("It's True.");
                Debug.WriteLine($"Color is {color.ToString()}");
                Debug.WriteLine($"Type name is {color.GetType().Name}");
                Debug.WriteLine($"Type full name is {color.GetType().FullName}");
            }
            else
            {
                Debug.WriteLine($"It's False. It's {Enum.GetName(typeof(ColorType), ColorType.Black)}");
                Debug.WriteLine($"Color is {color.ToString()}");
                Debug.WriteLine($"Type name is {color.GetType().Name}");
                Debug.WriteLine($"Type full name is {color.GetType().FullName}");
            }
        }

        public enum ColorType
        {
            [Description("Black")]
            Black = 1,
            [Description("White")]
            White = 2,
            [Description("Yellow")]
            Yellow = 3,
            [Description("Red")]
            Red = 4

        }

        private void button5_Click(object sender, EventArgs e)
        {
            // Parse, Convert
            string sNum = "1234";
            //string sWord = "code";

            int iNum2 = 0;
            int.TryParse(sNum, out iNum2);

            //parse�� ������ ����
            int iNum = int.Parse(sNum);
            //int iNum3 = Convert.ToInt32(sNum);
            //int iWord = int.Parse(sWord);

            Debug.WriteLine($"Parse: {iNum} 's type is {iNum.GetType().Name}");

            //convert�� null �϶��� �⺻���� ��ȯ�ϰ�, �ٸ� �ڷ����̸� ������ �߻�
            iNum = Convert.ToInt32(sNum);
            //iWord = Convert.ToInt32(sWord); 
            Debug.WriteLine($"Convert: {iNum} 's type is {iNum.GetType().Name}");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            // ���� ������
            int a = 100;

            int b = ++a;
            Debug.WriteLine($"b = ++a: b = {b} a = {a}");

            b = a++;
            Debug.WriteLine($"b = a++: b = {b} a = {a}");

            b = --a;
            Debug.WriteLine($"b = --a: b = {b} a = {a}");

            b = a--;
            Debug.WriteLine($"b = a--: b = {b} a = {a}");
        }

        private void button12_Click(object sender, EventArgs e)
        {
            // Switch Enum
            LanguageType language = LanguageType.Russian;
            switch (language)
            {
                case LanguageType.Korean:
                    Debug.WriteLine("�ȳ�!");
                    break;
                case LanguageType.English:
                    Debug.WriteLine("Hello!");
                    break;
                case LanguageType.Russian:
                    Debug.WriteLine("���ڬӬ֬�!");
                    break;
                case LanguageType.Spanish:
                    Debug.WriteLine("��Hola!");
                    break;
                case LanguageType.French:
                    Debug.WriteLine("Bonjuor!");
                    break;
            }
        }

        public enum LanguageType
        {
            [Description("Korean")]
            Korean = 1,
            [Description("English")]
            English = 2,
            [Description("Russian")]
            Russian,
            [Description("Spanish")]
            Spanish = 4,
            [Description("French")]
            French = 5
        }

        private void button11_Click(object sender, EventArgs e)
        {
            // While
            int i = 1;
            while (i < 10)
            {
                int j = 1;
                while (j < 10)
                {
                    Debug.WriteLine($"{i} * {j} = {i * j}");
                    j++;
                }
                i++;
                Debug.WriteLine("");
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            // Foreach
            string[] arrBTS = { "����", "����", "����", "ȣ��", "����", "����", "����" };

            foreach (string member in arrBTS)
            {
                Debug.Write($"{member} ");
            }
            Debug.WriteLine("");

            Dog[] dogList = { new Dog("��ī", "�����ͽ�", 2), new Dog("������", "������ �׸���", 3),
                                     new Dog("����", "�ùٰ�", 3), new Dog("�¿�", "�㽺Ű", 4),
                                     new Dog("����", "�ڽ���Ʈ", 1), new Dog("�ӷ���", "��Ƽ��", 7)};

            foreach (Dog dog in dogList)
            {
                Debug.WriteLine($"{dog.getName()}�� {dog.getBreed()}�̰�, {dog.getAge()}���̿���.");
            }
        }

        public class Dog
        {
            private string name;
            private string breed;
            private int age;

            public Dog(string name, string breed, int age)
            {
                this.name = name;
                this.breed = breed;
                this.age = age;
            }

            public string getName()
            {
                return name;
            }

            public string getBreed()
            {
                return breed;
            }

            public int getAge()
            {
                return age;
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            // String
            string greeting = "Hello World!";
            string nothing = null;
            string empty = "";
            string space = " ";
            Debug.WriteLine(greeting);
            Debug.WriteLine(greeting.Length);

            Debug.WriteLine($"{greeting} isNullOrEmpty: {string.IsNullOrEmpty(greeting)}");
            Debug.WriteLine($"null isNullOrEmpty: {string.IsNullOrEmpty(nothing)}");
            Debug.WriteLine($"empty isNullOrEmpty: {string.IsNullOrEmpty(empty)}");
            Debug.WriteLine($"space isNullOrEmpty: {string.IsNullOrEmpty(space)}");

            Debug.WriteLine($"{greeting} isNullOrWhiteSpace: {string.IsNullOrWhiteSpace(greeting)}");
            Debug.WriteLine($"null isNullOrWhiteSpace: {string.IsNullOrWhiteSpace(nothing)}");
            Debug.WriteLine($"empty isNullOrWhiteSpace: {string.IsNullOrWhiteSpace(empty)}");
            Debug.WriteLine($"space isNullOrWhiteSpace: {string.IsNullOrWhiteSpace(space)}");

            Debug.WriteLine(greeting.ToUpper());
            Debug.WriteLine(greeting.ToLower());

            Debug.WriteLine($"{greeting} starts with 'Hell'?: {greeting.StartsWith("Hell")}");
            Debug.WriteLine($"{greeting} ends with 'world!'?: {greeting.EndsWith("world!")}");
            Debug.WriteLine($"{greeting} contains ' '?: {greeting.Contains(" ")}");
            Debug.WriteLine($"'{greeting}' indexof o: {greeting.IndexOf("o")}");
            Debug.WriteLine($"'{greeting}' last indexof o: {greeting.LastIndexOf("o")}");

            string company = "  Mosti  ";
            Debug.WriteLine($"'{company}' trim: {company.Trim()}");

            company = company.Trim();
            Debug.WriteLine($"'{company}' concat 'soft': {string.Concat(company, " soft")}");

            company = string.Concat(company, " soft");
            Debug.WriteLine($"{company} replace ' ' -> - : {company.Replace(" ", "-")}");

            string[] arrName = company.Split(' ');
            Debug.WriteLine($"{company} split: {arrName[0]}, {arrName[1]}");
            Debug.WriteLine($"{company} substring(0,5): {company.Substring(0, 5)}");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            // Join
            string[] arrBTS = { "Jin", "Suga", "RM", "J-Hope", "Jimin", "V", "JK" };
            Debug.WriteLine("BTS join: " + string.Join(" & ", arrBTS));
        }

        private void button7_Click(object sender, EventArgs e)
        {
            // String Builder
            //String str = "abcde";
            //str += "FGHIJK";

            // 0-6
            StringBuilder stringBuilder = new StringBuilder("�ȳ��ϼ���!");
            // 7-13
            stringBuilder.Append(" �ݰ����ϴ�.");
            Debug.WriteLine(stringBuilder.ToString());

            // 14-21
            stringBuilder.Insert(6, " ���Ѻ��Դϴ�.");
            Debug.WriteLine(stringBuilder.ToString());

            stringBuilder.Remove(14, 7);
            Debug.WriteLine(stringBuilder);

            stringBuilder.Replace(".", "!!!");
            Debug.WriteLine(stringBuilder);
        }

        private void button18_Click(object sender, EventArgs e)
        {
            // ���� ������
            FirstClass firstClass = new FirstClass();
            firstClass.getFirstClass();

            ThirdClass thirdClass = new ThirdClass();
            thirdClass.getThirdClass();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            // �Լ�
            string changeName(string name = "RM")
            {
                return name;
            }

            void changeParams(ref string name, ref int age)
            {
                name = "�̸� �ٲ�";
                age = 999;
            }

            // ������ �Ű����� 
            Debug.WriteLine("�޼��� �Ű����� �⺻�� �ֱ�");
            Debug.WriteLine(changeName());
            Debug.WriteLine(changeName("JK"));
            Debug.WriteLine("");

            // ref
            string originName = "���Ѻ�";
            int originAge = 26;

            changeParams(ref originName, ref originAge);
            Debug.WriteLine("ref ����ϱ�");
            Debug.WriteLine($"{originName} , {originAge}��");
            Debug.WriteLine("");

            // out
            int a = 20;
            int b = 3;
            int c = 0;
            int d = 0;

            void Divide(int a, int b, out int quotient, out int remainder)
            {
                quotient = a + b;
                remainder = a - b;
            }

            Divide(a, b, out c, out d);

            Debug.WriteLine("out ����ϱ�");
            Debug.WriteLine($"c: {c}, d: {d}");
            Debug.WriteLine("");

            // ���� �Ű�����
            string koreanName = "���Ѻ�";
            string sentence = null;

            void introduce(string name, out string sentence)
            {
                sentence = "�� �̸��� " + name;
            }

            introduce(name: koreanName, out sentence);

            Debug.WriteLine("out ����ϱ�");
            Debug.WriteLine(sentence);
            Debug.WriteLine("");
        }

        private void button16_Click(object sender, EventArgs e)
        {
            // Date Time
            DateTime now = DateTime.Now;
            DateTime date = new DateTime(2023, 2, 1, 16, 0, 0);
            TimeSpan duration = now - date;

            Debug.WriteLine(now.AddDays(10));
            Debug.WriteLine(now.AddDays(-10));
            Debug.WriteLine(now.AddMonths(17));
            Debug.WriteLine(now.AddMonths(-17));
            Debug.WriteLine(now.AddYears(76)
                                .AddHours(33)
                                .AddMinutes(29));
            Debug.WriteLine(duration);

        }

        private void button15_Click(object sender, EventArgs e)
        {
            // Params
            int result = 0;
            result = sumArr(1, 2, 3, 4, 5);
            Debug.WriteLine(result);

            result = sumArr(1, 2, 3, 4, 5, 6, 7, 8, 9, 10);
            Debug.WriteLine(result);

            int sumArr(params int[] arr)
            {
                int sum = 0;

                foreach (int i in arr)
                {
                    sum += i;
                }

                return sum;
            }
        }
        private void button14_Click(object sender, EventArgs e)
        {
            // Extension Method
            string[] arrBTS = { "����", "����", "����", "ȣ��", "����", "����", "����" };
            Debug.WriteLine(arrBTS.sumArray());
            Debug.WriteLine(ExtensionClass.sumArray(arrBTS));
        }

        private void button13_Click(object sender, EventArgs e)
        {
            // ��� �帧 �˱�

            //Parent parent = new Parent();
            //Debug.WriteLine(parent.name);

            //Parent parent2 = new Parent("�ι�° �θ� Ŭ����");
            //Debug.WriteLine(parent2.name);

            Child child = new Child();
            Debug.WriteLine(child.childName);

            //Child child2 = new Child("�ι�° �ڽ� Ŭ����");
            //Debug.WriteLine(child2.name);
        }

        public class Parent
        {
            public string parentName;

            public Parent()
            {
                parentName = "�θ� Ŭ����";
            }

            public Parent(string nameParam) : this()
            {
                parentName = nameParam;
            }
        }
        public class Child : Parent
        {
            public string childName;

            public Child()
            {
                childName = "�ڽ� Ŭ����";
                Debug.WriteLine(base.parentName);
            }

            public Child(string nameParam) : this()
            {
                childName = nameParam;
            }

        }

        private void button24_Click(object sender, EventArgs e)
        {
            // Arrays
            //string[] arrColor = new string[3];
            //string[] arrColor = new string[] { "Red", "Orange", "Yellow" , "Blue", "Purple" };
            string[] arrColor = { "Red", "Orange", "Yellow", "Green", "Blue", "Purple" };

            Debug.WriteLine("Green�� ��ġ��" + Array.IndexOf(arrColor, "Green"));
            Debug.WriteLine($"arrColor's Length is {arrColor.Length}");
            Debug.WriteLine($"arrColor has 'black' ? {arrColor.Contains("Black")}");
            Debug.WriteLine("");

            Array.Sort(arrColor);
            Debug.Write("Array.Sort => ");
            Array.ForEach<string>(arrColor, color => Debug.Write($"{color} "));
            Debug.WriteLine("");

            Array.Reverse(arrColor);
            Debug.Write("Array.Reverse => ");
            Array.ForEach(arrColor, color => Debug.Write($"{color} "));
            Debug.WriteLine("");

            Array.Resize(ref arrColor, 4);
            Debug.Write("Array.Resize 4 => ");
            Array.ForEach(arrColor, color => Debug.Write($"{color} "));
            Debug.WriteLine("");

            // �迭 ��� �ʱ�ȭ
            Array.Clear(arrColor, 0, arrColor.Length);

        }

        private void button22_Click(object sender, EventArgs e)
        {
            // Virtual
            OverrideBase overrideBase = new OverrideBase();
        }

        internal class Base
        {
            public Base()
            {
                //publicMethod();
                //virtualMethod();
            }

            public void publicMethod()
            {
                Debug.WriteLine("Public method from Class 'Base'");
            }

            public virtual void virtualMethod()
            {
                Debug.WriteLine("Virtual method from Class 'Base'");
            }

        }

        internal class OverrideBase : Base
        {
            public OverrideBase()
            {
                publicMethod();
                virtualMethod();
            }

            public sealed override void virtualMethod()
            {
                base.virtualMethod();
                Debug.WriteLine("Override method from Class 'OverridBase'");
            }
        }

        private void button21_Click(object sender, EventArgs e)
        {
            // Static
            Debug.WriteLine(StaticName.stName);

            StaticName.changeName("�޼���� �̸� �ٲ�");
            Debug.WriteLine(StaticName.stName);

            StaticName.stName = "�ٽ� ���Ѻ��";
            Debug.WriteLine(StaticName.stName);

        }
        public static class StaticName
        {
            //public string publicName;
            //���� Ŭ������ �ν��Ͻ� ����� ������ �� �����ϴ�.
            public static string stName = "���Ѻ�";

            public static void changeName(string name)
            {
                stName = name;
            }

        }

        private void button20_Click(object sender, EventArgs e)
        {
            // Struct
            Person hbkim;
            hbkim.name = "Hanbi Kim";
            hbkim.age = 26;
            hbkim.introduce();

            Person hmSon = new Person { name = "Heungmin Son", age = 30 };
            hmSon.introduce();
        }

        public struct Person
        {
            public string name;
            public int age;

            public void introduce()
            {
                Debug.WriteLine($"{name} is {age} years old.");
            }
        }

        private void button19_Click(object sender, EventArgs e)
        {
            // Is, As
            // is
            Animal animal = new Animal();
            Animal dog;

            if (animal is Animal)
            {
                dog = animal;
                dog.howl();
            }

            OverrideBase overrideBase = new OverrideBase();
            if (overrideBase is Base)
            {
                Debug.WriteLine("overrideBase is Base!");
            }
            else
            {
                Debug.WriteLine("overrideBase is not Base!");
            }

            // as
            Animal cat = animal as Animal;

            if (cat != null)
            {
                cat.howl();
            }
        }
        public class Animal
        {
            public void howl()
            {
                Debug.WriteLine("Wof Wof!");
            }
        }

        private void button28_Click(object sender, EventArgs e)
        {
            //interface
            KoreanCar sorento = new KoreanCar("Sorento", "Red", 2023);
            KoreanCar sonata = new KoreanCar("Sonata", "Blue", 2020);
            KoreanCar avante = new KoreanCar("Avante", "Gray", 2017);

            sorento.goForward();
            sonata.goBackward();

            sorento.getInterface(sonata, avante);

            Car car = new KoreanCar("Car", "Rainbow", 2000);
            car.goBackward();
        }

        internal interface Car
        {
            void goForward();
            void goBackward();
            void getInterface(params object[] koreanCars);

        }

        internal class KoreanCar : Car
        {
            private string carName;
            private string carColor;
            private int carModel;

            public KoreanCar(string name, string color, int model)
            {
                this.carName = name;
                this.carColor = color;
                this.carModel = model;
                Debug.WriteLine($"{carColor} {carName} {carModel} ");
            }

            // 'Main.KoreanCar'��(��) 'Main.Car.goForward()' �������̽� ����� �������� �ʽ��ϴ�. 'Main.KoreanCar.goForward()'��(��) public�� �ƴϹǷ� �������̽� ����� ������ �� �����ϴ�.
            public void goForward()
            {
                Debug.WriteLine($"{carColor} {carName} {carModel} is moving forwad.");
            }

            public void goBackward()
            {
                Debug.WriteLine($"{carColor} {carName} {carModel} is moving backward.");
            }

            public void getInterface(params object[] koreanCars)
            {
                for (int i = 0; i < koreanCars.Length; i++)
                {
                    Car car = (Car)koreanCars[i];
                    car.goForward();
                }
            }
        }

        private void button25_Click(object sender, EventArgs e)
        {
            // sealed

        }

        public class Basic
        {
            public Basic()
            {
                Debug.WriteLine("This is Basic Class");
            }

            public virtual void basicMethod()
            {
                Debug.WriteLine("This is Basic Virtual Method");
            }

            //public sealed virtual void basicMethod() { }
            //public sealed void sealedMethod() { }


        }
        public class Intermediate : Basic
        {
            public Intermediate()
            {
                Debug.WriteLine("This is Intermediate Class");
            }

            public sealed override void basicMethod()
            {
                Debug.WriteLine("This is overrided sealed basicMethod From Intermediate Class");
            }
        }

        public sealed class Advanced : Basic //Intermediate
        {
            public Advanced()
            {
                Debug.WriteLine("This is Advanced Class");
            }

            public override void basicMethod()
            {
                Debug.WriteLine("This is overrided sealed basicMethod");
            }
        }

        private void button23_Click(object sender, EventArgs e)
        {
            // partial
            Debug.WriteLine("Partial is Working");

            //���������� �ٸ� �� ���̸� �浹��
            //'Main'�� partial ���� �浹�ϴ� �׼��� ���ɼ� �����ڰ� ���ԵǾ� �ֽ��ϴ�.v

        }
        private void button27_Click(object sender, EventArgs e)
        {
            // Data table
            DataTable data = new DataTable("class1");
            data.Columns.Add("No", typeof(int));
            data.Columns.Add("Name", typeof(string));
            data.Columns.Add("Age", typeof(int));

            // �� �Է�
            DataRow row1 = data.NewRow();
            row1["No"] = 1;
            row1["Name"] = "Hanbi Kim";
            row1["Age"] = 26;
            data.Rows.Add(row1);

            data.Rows.Remove(row1);

            data.Rows.Add(new object[] { 7, "Heungmin Son", 30 });
            data.Rows.Add(new object[] { 4, "Minjae Kim", 32 });
            data.Rows.Add(new object[] { 6, "Inbeom Hwang", 28 });
            data.Rows.Add(new object[] { 19, "Kangin Lee", 23 });
            data.Rows.Add(new object[] { 10, "Guesung Cho", 26 });
            data.Rows.Add(new object[] { 11, "Heechan Hwang", 28 });
            dgvMain.DataSource = data;

            // �� ���
            foreach (DataRow row in data.Rows)
            {
                Debug.WriteLine($"{row["Name"]} is {row["age"]} years old.");
            }

            object[] dataTable = data.Select();
            foreach(DataRow dataRow in dataTable)
            {
                Debug.WriteLine(dataRow.isNullOrEmpty("Name"));
            }

            //������ ������ ����
            DataRow[] testRow = data.Select("No < 10", "No DESC");
            DataTable testTable = testRow.CopyToDataTable();

            //testTable�� ����Ǳ� ������ ������. Copy()�ؼ� ����ϱ�
            //DataTable testTable2 = testTable;

            DataTable newData = new DataTable();
            //newData = data.Clone();
            //newData = data.Copy();
            newData = data.Select("Name = 'Heungmin Son'").CopyToDataTable();
            for (int i = 0; i < newData.Rows.Count; i++)
            {
                DataRow row = newData.Rows[i];
                Debug.Write($"{row["No"]} ");
                Debug.Write($"{row["Name"]} ");
                Debug.WriteLine(row["Age"]);
            }

            DataTable data2 = new DataTable("class2");
            data2.Columns.Add("No", typeof(int));
            data2.Columns.Add("Name", typeof(string));
            data2.Columns.Add("Age", typeof(int));

            // �� �Է�
            DataRow row2 = data2.NewRow();
            row2["No"] = 1;
            row2["Name"] = "Kangin Lee";
            row2["Age"] = 24;
            data2.Rows.Add(row2);

            data2.Rows.Add(new object[] { 3, "Gyuseong Cho", 28 });

            // Data Set
            DataSet dataSet = new DataSet("School");

            dataSet.Tables.Add(data);
            dataSet.Tables.Add(data2);

            Debug.WriteLine(dataSet.GetXml());
        }

        private void button32_Click(object sender, EventArgs e)
        {
            //item item = new item { name = "shoes", count = 12, price = 19 };
            Item item = new Item { Name = "Shoes", Price = 19 };
            Debug.WriteLine($"{item.Name}: sells for ${item.Price}");


        }
        public class Item
        {
            private string data;

            public string Name
            {
                get; set;
            }

            public string Name2
            {
                get { return data; }
                set { data = "Hello" + value; }
            }

            public int Count
            {
                get; private set;
            }

            public int Price
            {
                get; set;
            }
        }

        private void button26_Click(object sender, EventArgs e)
        {
            // Abstract
            MostiSoft mostiSoft = new MostiSoft();
            mostiSoft.Work();
            mostiSoft.meeting();
        }

        public abstract class Company
        {
            public string name;
            public string meetingRoom;
            public int numOfWorker;

            public Company()
            {
                name = "Company";
                meetingRoom = "Main";
                numOfWorker = 200;
            }

            public abstract void Work();
            public void meeting()
            {
                Debug.WriteLine($"{name}'s workers have a conference in {meetingRoom}");
            }
        }

        public class MostiSoft : Company
        {
            public MostiSoft()
            {
                name = "Mostisoft";
                meetingRoom = "FIFO";
                numOfWorker = 40;
            }
            public override void Work()
            {
                Debug.WriteLine($"{numOfWorker} workers are working at {name}");
            }
        }

        private void button30_Click(object sender, EventArgs e)
        {
            // Generic List

            //List<int> lstNumbers = new List<int>();
            List<int> lstNumbers = new List<int> { 1, 3, 5, 7, 9, 11, 3 };

            Debug.WriteLine("3�� ù��° ��ġ��" + lstNumbers.IndexOf(3));

            lstNumbers.Sort();
            foreach (int item in lstNumbers)
            {
                Debug.WriteLine(item);
            }

            lstNumbers.Remove(11);
            lstNumbers.RemoveAt(4);
            lstNumbers.Insert(3, 99);

            Debug.WriteLine(lstNumbers.Count());
            Debug.WriteLine(lstNumbers.Contains(99));

            lstNumbers.Clear();

            List<Cat> lstCats = new List<Cat> ();
            Cat firstCat;
            firstCat.name = "Nabi";
            firstCat.age = 2;

            Cat secondCat;
            secondCat.name = "Yuri";
            secondCat.age = 5;

            Cat thirdCat;
            thirdCat.name = "Woojoo";
            thirdCat.age = 7;

            lstCats.Add(firstCat);
            lstCats.Add(secondCat);
            lstCats.Add(thirdCat);

            foreach (Cat cat in lstCats)
            {
                Debug.WriteLine($"Cat {cat.name} is {cat.age} years old.");
            }

            Dictionary<string, int> dic = new Dictionary<string, int>()
            {
                { "Cat", 2 },
                { "Dog", 3 },
                { "Hamster", 4 },
                { "Iguana", 5 }
            };

            foreach(KeyValuePair<string, int> pair in dic)
            {
                Debug.Write($"{pair.Key} {pair.Value}, ");
            }

            dic.Add("Parrot", 6);
            Debug.WriteLine(dic.ContainsKey("Lion"));
            Debug.WriteLine(dic.ContainsValue(3));

            // dictionary �����ϱ�
            var myNewDic = new Dictionary<string, int>(dic);
            foreach (KeyValuePair<string, int> pair in myNewDic)
            {
                Debug.Write($"{pair.Key} {pair.Value}, ");
            }

            // dictionary�� list�� ��ȯ�ϱ�
            List<string> dicKeyList = new List<string>(myNewDic.Keys);
            foreach (string key in dicKeyList)
            {
                Debug.Write($"{key}, ");
            }

        }



        public struct Cat
        {
            public string name;
            public int age;
        }

        private void button29_Click(object sender, EventArgs e)
        {
            //HashTable
            Hashtable table = new Hashtable();
            table["ID"] = 1;
            table["Name"] = "Hanbi Kim";
            table.Add("Phone", "010-8073-7748");
            table.Add("Address", "����� ������");

            // ���� ����(���)
            table["Name"] = "Jimin Park";
            // ���� �Ұ���(����)
            //table.Add("Name", "Namjoon Kim");

            table.Remove("Address");

            Debug.WriteLine(table["ID"]);
            Debug.WriteLine(table["Name"]);
            Debug.WriteLine(table["Phone"]);
            Debug.WriteLine($"table contains [Con]? {table.ContainsKey("Con")}");
            Debug.WriteLine($"table contains [Con]? {table.ContainsValue(1)}");

            Debug.WriteLine("Hashtable.Keys");
            foreach (object key in table.Keys)
            {
                Debug.WriteLine($"{table[key]} ");
            }
            Debug.WriteLine("");

            Debug.WriteLine("Hashtable.Values");
            foreach (object value in table.Values)
            {
                Debug.WriteLine($"{value} ");
            }
            Debug.WriteLine("");


            Debug.WriteLine("DictionaryEntry");
            foreach (var item in table)
            {
                //as �����ڴ� ���� ���� �Ǵ� null ��� ���İ� �Բ� ����ؾ� �մϴ�.
                //'DictionaryEntry'��(��) null�� ������� �ʴ� �� �����Դϴ�.
                //DictionaryEntry entry = item as DictionaryEntry;
                DictionaryEntry entry = (DictionaryEntry)item;
                Debug.WriteLine($"{entry.Key} - {entry.Value}");
            }
            Debug.WriteLine("");

            foreach (DictionaryEntry item in table)
            {
                Debug.WriteLine($"{item.Key} - {item.Value}");
            }

        }

        private void button31_Click(object sender, EventArgs e)
        {
            //indexer
            IndexerClass intIndexer = new IndexerClass();
            intIndexer[0] = 1;
            Debug.WriteLine(intIndexer[0]);


        }

        public class IndexerClass
        {
            private int[] arr = new int[100];

            public int this[int i]
            {
                get { return arr[i]; }
                set { arr[i] = value; }
            }
        }


        private void button34_Click(object sender, EventArgs e)
        {
            //Error

            try
            {
                //throw new CustomException("����� ���� ���� �߻�", new Exception());
                throw new CustomException("����� ���� ���� �߻�")
                {
                    CustomErrorCode = 100
                };
            }
            catch (CustomException ex)
            {
                Debug.WriteLine($"Error code: {ex.CustomErrorCode}");

            }
            finally
            {
                Debug.WriteLine("Finally!");
            }

        }


        private void button35_Click(object sender, EventArgs e)
        {

            //������ �׸���信�� '�̸�'���� �˻�
            string keyword = searchText.Text.ToLower();
            if(string.IsNullOrWhiteSpace(keyword))
            {
                MessageBox.Show("�˻�� �Է����ּ���.");
            }
            else
            {
                bool result = false;
                for (int i = 0; i < dgvMain.Rows.Count-1; i++)
                {
                    string name = dgvMain.Rows[i].Cells[1].Value.ToString().ToLower();
  
                    DataGridViewRow row = dgvMain.Rows[i];
                    if (name.Contains(keyword))
                    {
                        result = true;
                        MessageBox.Show($"���ȣ: {row.Cells[0].Value.ToString()}, �̸�: {row.Cells[1].Value.ToString()}, ����: {row.Cells[2].Value.ToString()}");
                    }
                    
                }

                if (result == false)
                {
                    MessageBox.Show("�˻� ����� �����ϴ�. �ٸ� '�̸�'�� �Է��غ�����.");
                }
            }
            
        }

        private void button36_Click(object sender, EventArgs e)
        {
            // delegate

            // ���� �����
            int[] intArr = { 3, 7, 4, 2, 10 };
            BubbleSort(intArr, new Compare(AscendCompare));
            Debug.Write("Ascending => ");
            foreach (int i in intArr)
            {
                Debug.Write($"{i} ");
            }
            Debug.WriteLine("");

            BubbleSort(intArr, new Compare(DescendCompare));
            Debug.Write("Descending => ");
            foreach (int i in intArr)
            {
                Debug.Write($"{i} ");
            }
            Debug.WriteLine("");


            int AscendCompare(int firstNum, int secondNum)
            {
                if (firstNum > secondNum)
                    return 1;
                else if (firstNum == secondNum)
                    return 0;
                else
                    return -1;
            }

            int DescendCompare(int firstNum, int secondNum)
            {
                if (firstNum < secondNum)
                    return 1;
                else if (firstNum == secondNum)
                    return 0;
                else
                    return -1;
            }

            void BubbleSort(int[] DataSet, Compare comparer)
            {
                int temp = 0;
                for (int i = 0; i < DataSet.Length; i++)
                {
                    for(int j = 0; j < DataSet.Length - (i+1); j++)
                    {
                        if(comparer(DataSet[j], DataSet[j + 1]) > 0)
                        {
                            temp = DataSet[j + 1];
                            DataSet[j + 1] = DataSet[j];
                            DataSet[j] = temp;
                        }
                    }
                }
            }

            // delegate chain
            //ThereIsAFire fire = new ThereIsAFire(Call119);
            //fire += new ThereIsAFire(ShotOut);
            //fire += new ThereIsAFire(Escape);

            ThereIsAFire fire = (ThereIsAFire)Delegate.Combine(
                                        new ThereIsAFire(Call119),
                                        new ThereIsAFire(ShotOut),
                                        new ThereIsAFire(Escape)
                                 );

            fire("��� �Ե���");
            void Call119(string location)
            {
                Debug.WriteLine($"�ҹ漭��? {location}�� ���� �����!");
            }

            void ShotOut(string location)
            {
                Debug.WriteLine($"���ϼ���! {location}�� ���� �����!");
            }

            void Escape(string location)
            {
                Debug.WriteLine($"{location}���� �����ô�!");
            }


            // �͸� �޼���
            Plus Sum = delegate (int a, int b) {
                                        return a + b;
                                    };

            Debug.WriteLine(Sum(3, 10));

            // Func
            Func<string, string> Introduce = name => name + " From Mosti";
            string sentence = Introduce("Hanbi Kim");
            Debug.WriteLine(sentence);

            Func<int, int, int, int, int, int> Result = (a,b,c,d,e) => (a+b)*c - (d+e);
            int result = Result(5, 9, 12, 7, 88);
            Debug.WriteLine(result);


            // Action
            Action<string> greeting = name => Debug.WriteLine($"Hello {name}!");
            greeting("Hanbi Kim");

            Action<string, string, int, string, int> Info = (color, name, model, company, year) =>
            {
                KoreanCar car = new KoreanCar(name, color, model);
                Debug.WriteLine($"is made from {company} in {year}");
            };

            Info("Red", "Sorento", 33, "KIA", 2023);

        }
        private delegate int Compare(int a, int b);
        private delegate void ThereIsAFire(string location);
        private delegate int Plus(int x, int y);

        private void button33_Click(object sender, EventArgs e)
        {
            //event

            //���� 1.
            //event handler ��� Ŭ���� �ν��Ͻ� ����
            Market market = new Market();


            //�̺�Ʈ�� ��ü �ܺο��� ���� ȣ���� �� ����.
            //�̺�Ʈ�� += �Ǵ� -= �� ���ʿ��� ����� �� �ֽ��ϴ�.
            //�� �� �̺�Ʈ�� 'Main.Market' ���Ŀ��� ���� ������ �����Դϴ�.
            //market.CustomerEvent(29);

            //�̺�Ʈ �ڵ鷯 ���: event += delegate(method)
            market.CustomerEvent += new EventHandler(congratsMsg);

            //�̺�Ʈ �߻�
            for (int i = 0; i < 35; i++)
            {
                market.buySomething(i);
            }

            void congratsMsg(int num)
            {
                Debug.WriteLine($"�����մϴ�! {num}��° �� �̺�Ʈ�� ��÷�Ǽ̽��ϴ�.");
            }

            // ���� 2.
            this.MyEventDelTest += new MydelClickDelegate(FnMyEventDelTest1);
            // => this.MyEventDelTest += FnMyEventDelTest1;

            void FnMyEventDelTest1(int num)
            {
                Debug.Write("FnMyEventDelTest1 is working!");
            }
        }
        // ���� 2.
        public delegate void MydelClickDelegate(int i);
        event MydelClickDelegate MyEventDelTest;

        // ���� 1.
        public delegate void EventHandler(int num);
        public class Market
        {
            public event EventHandler CustomerEvent;

            public void buySomething(int customerNo)
            {
                // class �������� event ��� ����
                if(customerNo == 30)
                {
                    CustomerEvent(customerNo);
                }
                
            }
        }

        private void button37_Click(object sender, EventArgs e)
        {
            TaskTest task = new TaskTest();
            task.DoMultipleTasksAsync();
            //task.DoWorkAsync();
        }

        public class TaskTest
        {

            public async Task DoMultipleTasksAsync()
            {
                var tasks = new List<Task>();

                // Task.Run() �޼ҵ带 ����Ͽ� �ٸ� �����忡�� ����Ǵ� �۾��� ����
                for (int i = 0; i < 5; i++)
                {
                    tasks.Add(Task.Run(() =>
                    {
                        Debug.WriteLine($"{i}��° �۾��� �Ϸ��߽��ϴ�.");
                    }));
                }

                // ��� �۾��� �Ϸ�� ������ ��ٸ�
                await Task.WhenAll(tasks);

                Console.WriteLine("��� �۾��� �Ϸ�Ǿ����ϴ�.");
            }

            public async Task DoWorkAsync()
            {
                Debug.WriteLine("�۾��� �����մϴ�.");

                // Task.Delay() �޼ҵ带 ����Ͽ� 1�� �Ŀ� �۾��� �Ϸ�� �� �ֵ��� ������Ŵ
                await Task.Delay(1000);

                Debug.WriteLine("1�ʰ� �������ϴ�. ù ��° �۾��� �Ϸ�Ǿ����ϴ�.");

                // �ٸ� �۾��� ����
                await DoOtherWorkAsync();

                Debug.WriteLine("�� ��° �۾��� �Ϸ�Ǿ����ϴ�.");
            }

            public async Task DoOtherWorkAsync()
            {
                // �ٸ� �����忡�� ����Ǵ� �۾��� �����մϴ�.
                var task = Task.Run(() =>
                {
                    Debug.WriteLine("�ٸ� �۾��� �����մϴ�.");
                });

                // �۾��� �Ϸ�� ������ ��ٸ��ϴ�.
                await task;
            }
        }

    }

    public static class ExtensionClass
    {
        public static string sumArray(this string[] arr)
        {
            StringBuilder sb = new StringBuilder();
            foreach (string member in arr)
            {
                sb.Append($"{member} ");
            }

            return sb.ToString();
        }

        public static string isNullOrEmpty(this DataRow data, string colName)
        {
            string result;
            if(data != null && string.IsNullOrEmpty(colName) == false)
            {
                result = data[colName].ToString();
            }
            else
            {
                result = "������X";
            }

            return result;
        }
    }
}