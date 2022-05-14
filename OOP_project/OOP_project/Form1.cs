using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP_project
{
    public partial class Form1login : Form
    {
        public Form1login()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UidTb.Clear();
            PassTb.Clear();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (UidTb.Text == "" || PassTb.Text == "")
            {
                MessageBox.Show("Missing Inforamtion.", "Wait!!");
            }
            else if (UidTb.Text == "Admin" && PassTb.Text == "SherLocked")
            {
                Form2main_Window form2 = new Form2main_Window();
                form2.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Wrong User id or Password.", "هتستعبط يالا ؟!!");
            }
        }
    }
}
