using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TKTSpider.BaseForm
{
    public partial class BaseFrom : CCWin.CCSkinMain
    {
        public BaseFrom()
        {
            InitializeComponent();
        }
        public void SetTextBox(string text, TextBox textBox)
        {
            if (textBox.InvokeRequired)
            {
                Action<string, TextBox> action = new Action<string, TextBox>(SetTextBox);
                Invoke(action, new object[] { text });
            }
            else
            {
                textBox.Text += "\r\n";
                textBox.AppendText(text);
                //定位到最后一行
            }
        }
        public void SetLable(string text, Label lable)
        {
            if (lable.InvokeRequired)
            {
                Action<string, Label> action = new Action<string, Label>(SetLable);
                Invoke(action, new object[] { text });
            }
            else
            {
                lable.Text = text;

            }
        }

    }
}
