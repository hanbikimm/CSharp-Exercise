using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tasks
{
    public partial class Conversion : Form
    {
        public Conversion()
        {
            InitializeComponent();
            initComboBox();
        }

        public void initComboBox()
        {
            comboBox.Items.Add("10진수 -> 2진수");
            comboBox.Items.Add("10진수 -> 16진수");
            comboBox.Items.Add("2진수 -> 16진수");
            comboBox.Items.Add("16진수 -> 2진수");

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string selected = comboBox.SelectedItem.ToString();
            string num = inputNum.Text;

            if (string.IsNullOrEmpty(num))
            {
                MessageBox.Show("숫자를 입력해주세요!");
            }
            else
            {
                switch (selected)
                {
                    case "10진수 -> 2진수":
                        MessageBox.Show($"결과는 {decimalToBinary(num)} 입니다.");
                        break;
                    case "10진수 -> 16진수":
                        MessageBox.Show($"결과는 {decimalToHexa(num)} 입니다.");
                        break;
                    case "2진수 -> 16진수":
                        MessageBox.Show($"결과는 {binaryToHexa(num)} 입니다.");
                        break;
                    case "16진수 -> 2진수":
                        MessageBox.Show($"결과는 {HexaToBinary(num)} 입니다.");
                        break;
                    default:
                        MessageBox.Show("변환 형식을 선택해주세요!");
                        break;
                }
            }
        }


        private string decimalToBinary(string num)
        {
            int intNum = Convert.ToInt32(num);
            num = Convert.ToString(intNum, 2);
            return num;
        }

        private string decimalToHexa(string num)
        {
            int intNum = Convert.ToInt32(num);
            num = Convert.ToString(intNum, 16);
            return num;
        }

        private string binaryToHexa(string num)
        {
            int intNum = Convert.ToInt32(num, 2);
            num = Convert.ToString(intNum, 16);
            return num;
        }

        private string HexaToBinary(string num)
        {
            int intNum = Convert.ToInt32(num, 16);
            num = Convert.ToString(intNum, 2);
            return num;
        }
    }
}
