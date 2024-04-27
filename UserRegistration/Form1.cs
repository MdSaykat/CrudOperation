using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserRegistration
{
    public partial class Form1 : Form
    {
        string ConnectionString = "Data Source=LAPTOP-1USDA8V1\\SQLEXPRESS;Initial Catalog=\"User RegistrationDB\";Integrated Security=True";
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection sqlCon = new SqlConnection(ConnectionString);
            string check = "select count(*) from usertable where UserName = '" + textBox1.Text + "' and password = '" + textBox2.Text + "'";
            SqlCommand com = new SqlCommand(check, sqlCon);
            sqlCon.Open();
            int temp = Convert.ToInt32(com.ExecuteScalar().ToString());
            sqlCon.Close();
            if (temp == 1)
            {
                Form3 form3 = new Form3();
                form3.Show();
            }
        }
    }
}
