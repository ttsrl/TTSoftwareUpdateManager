using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TTSoftwareUpdateManager
{
    public partial class inputText : Form
    {
        public string Value { get; set; }
        public string TitleProp { get; set; }
        public inputText()
        {
            InitializeComponent();
        }

        private void InputText_Load(object sender, EventArgs e)
        {
            textBox1.Text = Value;
            label1.Text = TitleProp ?? "";
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                Value = textBox1.Text;
                DialogResult = DialogResult.OK;
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
