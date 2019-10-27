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
    public partial class inputVersion : Form
    {
        public Version Version { get; set; }

        public inputVersion()
        {
            InitializeComponent();
        }

        private void inputVersion_Load(object sender, EventArgs e)
        {
            if(Version != null)
            {
                textBox1.Text = Version.Major.ToString();
                textBox2.Text = Version.Minor.ToString();
                textBox3.Text = Version.Build.ToString();
                textBox4.Text = Version.Revision.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int n1, n2, n3, n4;
            var try1 = int.TryParse(textBox1.Text, out n1);
            var try2 = int.TryParse(textBox2.Text, out n2);
            var try3 = int.TryParse(textBox3.Text, out n3);
            var try4 = int.TryParse(textBox4.Text, out n4);
            if (!try1)
                textBox1.Focus();
            if (!try2)
                textBox2.Focus();
            if (!try3)
                textBox3.Focus();
            if (!try4)
                textBox4.Focus();
            if (!try1 || !try2 || !try3 || !try4)
                return;
            Version version = new Version(n1, n2, n3, n4);
            Version = version;
            DialogResult = DialogResult.OK;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

    }
}
