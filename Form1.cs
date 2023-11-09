using System;
using System.Windows.Forms;

namespace EnglishTrainer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void start_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(this);
            form2.Show();
        }
        private void exit1_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void Dictionary_Click(object sender, EventArgs e)
        {
            Form3 dict = new Form3(this);
            dict.Show();
        }
    }
}
