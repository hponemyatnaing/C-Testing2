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

namespace LabTest
{
    public partial class no1 : Form
    {
        public no1()
        {
            InitializeComponent();
        }

        private void no1_Load(object sender, EventArgs e)
        {
            string connection = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Aung Kan Phyo\C#\LabTest\labTestDatabase.mdf;Integrated Security=True;Connect Timeout=30;";
            int rno = GetNextRno(connection);
            rnoTextBox.Text = rno.ToString();
        }

        private int GetNextRno(string connection)
        {
            int lastRno = 0;
            using (SqlConnection conn = new SqlConnection(connection))
            {
                string query = "SELECT MAX(rno) FROM Student";
                SqlCommand command = new SqlCommand(query, conn);
                conn.Open();
                lastRno = (int)command.ExecuteScalar();
            }
                return lastRno+1;
        }

        private void SubmitButton(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Aung Kan Phyo\C#\LabTest\labTestDatabase.mdf;Integrated Security=True;Connect Timeout=30;");
            conn.Open();
            string query = "INSERT INTO Student (rno,name,address) VALUES (@rno,@name,@address)";
            SqlCommand command = new SqlCommand(query,conn);
            command.Parameters.AddWithValue("@rno", int.Parse(rnoTextBox.Text));
            command.Parameters.AddWithValue("@name", nameBox.Text);
            command.Parameters.AddWithValue("@address", addressBox.Text);
            command.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Registration successful");
        }
    }
}
