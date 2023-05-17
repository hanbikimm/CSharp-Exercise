using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tasks
{
    public partial class ThreadTest : Form
    {
        private bool isRunning = false;
        private bool isRunning20 = false;
        private bool isRunning30 = false;

        private Thread thread;
        private Thread thread20;
        private Thread thread30;

        public ThreadTest()
        {
            InitializeComponent();
        }

        private void btnError_Click(object sender, EventArgs e)
        {
            // error
            isRunning = true;
            while (isRunning)
            {
                // 현재 시간을 표시한다
                string time = DateTime.Now.ToString("HH:mm:ss");
                btnError.Text = time;
                // 0.5초간 대기한다
                Thread.Sleep(2500);
            }

            // 쓰레드의 권한을 해당 함수에서 가져 감 / 이후 동작 할 수 없음
        }

        private void btnThread20_Click(object sender, EventArgs e)
        {
            if (isRunning20)
            {
                // 스레드를 멈춘다
                isRunning20 = false;
                thread20.Join(); // 스레드가 완전히 종료될 때까지 대기
                btnThread20.Text = "2.0 Start";
            }
            else
            {
                // 스레드를 시작한다
                isRunning20 = true;
                thread20 = new Thread(new ThreadStart(DisplayTime20));
                thread20.Start();
                btnThread20.Text = "2.0 Stop";
            }
        }

        private delegate void UpdateTextDelegate(string text);

        private void DisplayTime20()
        {
            while (isRunning20)
            {
                // 현재 시간을 표시한다
                string time = DateTime.Now.ToString("HH:mm:ss.fff");

                UpdateText(time);

                // 1000분의 1초간 대기한다
                Thread.Sleep(100);
            }
        }

        private void UpdateText(string text)
        {
            // 해당 컨트롤에접근 할 수 없는지를 확인 ( 접근 제어권이 있는지.. )
            if (btnThread20.InvokeRequired)
            {
                btnThread20.Invoke(new UpdateTextDelegate(UpdateText), text);
            }
            else
            {
                btnThread20.BackColor = System.Drawing.Color.Red;
                btnThread20.Text = text;
            }
        }

        private void btnThread30_Click(object sender, EventArgs e)
        {
            if (isRunning30)
            {
                // 스레드를 멈춘다
                isRunning30 = false;
                thread30.Join(); // 스레드가 완전히 종료될 때까지 대기
                btnThread30.Text = "3.0 Start";
            }
            else
            {
                // 스레드를 시작한다
                isRunning30 = true;
                thread30 = new Thread(new ThreadStart(DisplayTime30));
                thread30.Start();
                btnThread30.Text = "3.0 Stop";
            }
        }

        private void DisplayTime30()
        {
            while (isRunning30)
            {
                // 현재 시간을 표시한다
                string time = DateTime.Now.ToString("HH:mm:ss.fff");

                // Type1 : 델리게이트를 생성해서 하는 방법
                //UpdateTextDelegate utd = new UpdateTextDelegate(UpdateText30);
                //btnDisp.Invoke(utd, time);

                // Type2 : 델리게이트를 생성하지 않는 방법
                btnThread30.Invoke(new Action(delegate ()
                {
                    btnThread30.Text = time;
                }));

                btnThread30.BackColor = System.Drawing.Color.Green;
                // 1000분의 1초간 대기한다
                Thread.Sleep(3000);
            }
        }

        private void UpdateText30(string text)
        {
            btnThread30.Text = text;
        }

        private void btnThread_Click(object sender, EventArgs e)
        {
            if (isRunning)
            {
                // 스레드를 멈춘다
                isRunning = false;
                thread.Join(); // 스레드가 완전히 종료될 때까지 대기
                btnThread.Text = "Start";
            }
            else
            {
                // 스레드를 시작한다
                isRunning = true;
                thread = new Thread(new ThreadStart(DisplayTime));
                thread.Start();
                btnThread.Text = "Stop";
            }
        }

        private void DisplayTime()
        {
            while (isRunning)
            {
                // 현재 시간을 표시한다
                string time = DateTime.Now.ToString("HH:mm:ss ffff");
                //Invoke(new Action(() => { btnDisp.Text = time; }));

                //btnDisp.BackColor = System.Drawing.Color.Yellow;
                // 1초간 대기
                Thread.Sleep(100);
            }
        }
    }
}
