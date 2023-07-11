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

namespace project
{
    public partial class Form1 : Form
    {
        landing l = new landing();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string username = textBox1.Text;
                string password = textBox2.Text;
                SqlConnection sc = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Digi_VA\\source\\repos\\project\\project\\Database1.mdf;Integrated Security=True");
                sc.Open();
                SqlCommand command = new SqlCommand("SELECT password FROM users WHERE username = '" + username + "'", sc);
                SqlDataReader reader = command.ExecuteReader();
                reader.Read();
                string pass = reader["password"].ToString();
                if (password == pass)

                {
                    l.Show();
                    this.Hide();
                }

                else
                    MessageBox.Show("incorrect");
                sc.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("incorrect");
            }
        }
    }
}
