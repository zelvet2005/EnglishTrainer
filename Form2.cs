using System;
using System.Windows.Forms;

namespace EnglishTrainer
{
    public partial class Form2 : Form
    {
        private Form1 parentForm = null;
        public Form2(Form1 form)
        {
            InitializeComponent();
            parentForm = form;
            parentForm.Hide();
        }
        private void back_Click(object sender, EventArgs e)
        {
            Close();
            parentForm.Show();
        }
        private void next_Click(object sender, EventArgs e)
        {
            if (NumWords.Text != string.Empty)
            {
                try
                {
                    int num = int.Parse(NumWords.Text);
                    Form4 form4 = new Form4(num, this);
                    form4.Show();
                    Hide();
                }
                catch 
                {
                    MessageBox.Show("Сталася помилка: Введіть ціле число у відведене поле!");
                }
            }
        }
    }
}
