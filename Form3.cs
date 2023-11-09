using System;
using System.Windows.Forms;

namespace EnglishTrainer
{
    public partial class Form3 : Form
    {
        private Form1 parentForm = null;
        public Form3(Form1 form)
        {
            InitializeComponent();
            parentForm = form;
            parentForm.Hide();
            AutoScroll = true;
        }
        private void back_Click(object sender, EventArgs e)
        {
            Close();
            parentForm.Show();
        }
    }
}
