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
    public partial class Form6payments : Form
    {
        public Form6payments()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\shaker\OneDrive\Documents\GymDB.mdf;Integrated Security=True;Connect Timeout=30");
        private void FillName()
        {
            Con.Open();
            SqlCommand cmd = new SqlCommand("select MName from MemberTbl", Con);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("MName", typeof(string));
            dt.Load(rdr);
            NameCb.ValueMember = "MName";
            NameCb.DataSource = dt;
            Con.Close();
        }
        private void label10_Click(object sender, EventArgs e)
        {
            Form2main_Window form2 = new Form2main_Window();
            form2.Show();
            this.Hide();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            //NameTb.Text = "";
            AmountTb.Text = "";
        }

        private void Form6payments_Load(object sender, EventArgs e)
        {
            FillName();
            Populate();
        }

        private void AmountTb_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void NameCb_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void Populate()
        {
            Con.Open();
            string query = "select * from PaymentTbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder();
            var ds = new DataSet();
            sda.Fill(ds);
            PaymentDGV.DataSource = ds.Tables[0];
            Con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (NameCb.Text == "" || AmountTb.Text == "")
            {
                MessageBox.Show("Missing Information", "Alert!!");
            }
            else
            {
                string payperiode = Periode.Value.Month.ToString() + Periode.Value.Year.ToString();
                Con.Open();
                SqlDataAdapter sda = new SqlDataAdapter("select count(*) from PaymentTbl where PMember='" + NameCb.SelectedValue.ToString() + "' and PMonth= ' " + payperiode + "'", Con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows[0][0].ToString() == "1")
                {
                    MessageBox.Show("Already paid for this month", "Wait!!");
                }
                else
                {
                    string query = "insert into PaymentTbl values('" + payperiode + "', '" + NameCb.SelectedValue.ToString() + "', " + AmountTb.Text + ")";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Amount paid Successfully", "Done!");
                }
                Con.Close();
                Populate();
            }
        }
        private void FilterByName()
        {
            Con.Open();
            string query = "select * from PaymentTbl where PMember= '"+SearchName.Text+"'";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder();
            var ds = new DataSet();
            sda.Fill(ds);
            PaymentDGV.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void Periode_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Search_Click(object sender, EventArgs e)
        {
            FilterByName();
            SearchName.Text = "";
        }

        private void Refresh_Click(object sender, EventArgs e)
        {
            Populate();
        }
    }
}
