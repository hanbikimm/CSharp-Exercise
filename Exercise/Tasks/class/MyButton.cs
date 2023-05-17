using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasks
{
    public class MyButton :Button
    {
        public MyButton()
        {
            this.BackColor = Color.Aquamarine;
            this.Click += new EventHandler(changeBackColor);

        }


        private void changeBackColor(object? sender, EventArgs e)
        {
            this.BackColor = Color.Red;
            MessageBox.Show("Change Color!");
        }
    }
}
