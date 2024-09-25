using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SelfMadeContainerExample;

namespace MvpContainer
{
    public partial class Form1 : Form
    {
        private Form2 _form2;

        public Form1(Form2 form2)
        {
            InitializeComponent();

            _form2 = form2;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _form2.Show();
        }
    }
}
