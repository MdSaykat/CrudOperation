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
    public partial class Form3 : Form
    {
        string ConnectionString = "Data Source=LAPTOP-1USDA8V1\\SQLEXPRESS;Initial Catalog=\"User RegistrationDB\";Integrated Security=True";
        public Form3()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection sqlCon = new SqlConnection(ConnectionString))
            {
                sqlCon.Open();
                SqlCommand sqlCmd = new SqlCommand("PropertyAdd", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@propertyId", textBox1.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@location", textBox2.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@propertyType", textBox3.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@price", textBox4.Text.Trim());
                sqlCmd.ExecuteNonQuery();
                MessageBox.Show("Add Property is Successful");

                Clear();

            }
            void Clear()
            {
                textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = "";

            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (SqlConnection sqlCon = new SqlConnection(ConnectionString))
            { sqlCon.Open();
            

                string query = "Select * from Property";
                SqlCommand cmd = new SqlCommand(query, sqlCon);
                var reader = cmd.ExecuteReader();
                DataTable Property = new DataTable();
                Property.Load(reader);
                dataGridView1.DataSource = Property;
                sqlCon.Close(); 
            }
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (SqlConnection sqlCon = new SqlConnection(ConnectionString))
            {
                sqlCon.Open();
                string query= "UPDATE Property SET location=@location,propertyType=@propertyType,price=@price WHERE propertyID=@propertyID";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
              
                sqlCmd.Parameters.AddWithValue("@location", textBox2.Text);
                sqlCmd.Parameters.AddWithValue("@propertyType", textBox3.Text);
                sqlCmd.Parameters.AddWithValue("@price", textBox4.Text);
                sqlCmd.Parameters.AddWithValue("@propertyId", textBox1.Text);
                sqlCmd.ExecuteNonQuery();
                MessageBox.Show("Update is Successful");
                sqlCon.Close(); 
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            using (SqlConnection sqlCon = new SqlConnection(ConnectionString))
            {
                sqlCon.Open();
                string query = "DELETE FROM Property WHERE propertyID=@propertyID";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.Parameters.AddWithValue("@propertyId", textBox1.Text);
                sqlCmd.ExecuteNonQuery();
                MessageBox.Show("Delete Rows");
                sqlCon.Close();
            }
        }
    }
}
