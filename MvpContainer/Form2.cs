using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MvpContainer
{
    public partial class Form2 : Form, IView
    {
        private readonly IPresenter _presenter;

        public Form2(PresenterFactory presenterFactory)
        {
            InitializeComponent();

            _presenter = presenterFactory.Create<IPresenter, IView>(this);
        }

        public void Show(string msg)
        {
            label1.Text = msg;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _presenter.Show();
        }
    }
}
