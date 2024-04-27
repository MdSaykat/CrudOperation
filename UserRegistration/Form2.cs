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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace UserRegistration
{
    public partial class Form2 : Form
    {
        string ConnectionString = "Data Source=LAPTOP-1USDA8V1\\SQLEXPRESS;Initial Catalog=\"User RegistrationDB\";Integrated Security=True";
        public Form2()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            {
                if (textBox5.Text == "" || textBox6.Text == "")
                    MessageBox.Show("Please fill Mandatory fields");
                else if (textBox6.Text != textBox7.Text)
                    MessageBox.Show("password do not match");
                else
                {
                    using (SqlConnection sqlCon = new SqlConnection(ConnectionString))
                    {
                        sqlCon.Open();
                        SqlCommand sqlCmd = new SqlCommand("UserAdd", sqlCon);
                        sqlCmd.CommandType = CommandType.StoredProcedure;
                        sqlCmd.Parameters.AddWithValue("@FirstName", textBox1.Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@LastName", textBox3.Text.Trim());
                        sqlCmd.Parameters.AddWithValue("Address", textBox4.Text.Trim());
                        sqlCmd.Parameters.AddWithValue("UserName", textBox5.Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@Password", textBox6.Text.Trim());
                        sqlCmd.ExecuteNonQuery();
                        MessageBox.Show("Registration is Successful");
                        Clear();

                    }
                }


            }
            void Clear()
            {
                textBox1.Text = textBox3.Text = textBox4.Text = textBox5.Text = textBox6.Text = textBox7.Text = "";
            }


        }

    }
}

