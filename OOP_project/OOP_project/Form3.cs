using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace OOP_project
{
    public partial class Form3add_Member : Form
    {
        public Form3add_Member()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\shaker\OneDrive\Documents\GymDB.mdf;Integrated Security=True;Connect Timeout=30");
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {
            Form2main_Window form2 = new Form2main_Window();
            form2.Show();
            this.Hide();
        }

        private void Form3add_Member_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (NameTb.Text == "" || PhoneTb.Text == "" || AmountTb.Text == "" || AgeTb.Text == "") 
            {
                MessageBox.Show("Missing Information", "Problem!");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "insert into MemberTbl values('" + NameTb.Text + "', '" + PhoneTb.Text + "', '" + GenderCb.SelectedItem.ToString() + "', " + AgeTb.Text + ", "+AmountTb.Text+ ", '" + TimingCb.SelectedItem.ToString() + "') ";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Member Succesfully Added", "Done");
                    Con.Close();
                    AmountTb.Text = "";
                    AgeTb.Text = "";
                    NameTb.Text = "";
                    TimingCb.Text = "";
                    GenderCb.Text = "";
                    PhoneTb.Text = "";
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message, "Exception");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AmountTb.Text = "";
            AgeTb.Text = "";
            NameTb.Text = "";
            TimingCb.Text = "";
            GenderCb.Text = "";
            PhoneTb.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2main_Window form2 = new Form2main_Window();
            form2.Show();
            this.Hide();
        }

        private void NameTb_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
