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

namespace project
{
    public partial class employees : Form
    {
        public bool ins = true;
        landing l;
    
        public employees(landing land)
        {
            l = land;
            InitializeComponent();
        }
       

        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            string mobile = textBox2.Text;
            string employee_code = textBox3.Text;
            string department = textBox4.Text;
            change(name, mobile, employee_code , department , ins);
        }
        private void change(string name, string mobile, string employee_code, string department , bool insert)
        {

            try
            {

                string query ;
                if (ins)
                    query = "INSERT INTO employees (name , mobile , employee_code , department )" + " VALUES (@nam,mob,ep_c,dep)";
                else
                    query = "UPDATE employees SET"+" name = '"+name+"' , mobile = '"+mobile+"' , employee_code = '"+employee_code+"' , department = '"+department+"'" + "WHERE name = '"+name+"'";
                SqlConnection sc = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Digi_VA\\source\\repos\\project\\project\\Database1.mdf;Integrated Security=True");
                sc.Open();
                SqlCommand command = new SqlCommand( query, sc);
                if (ins) ;
                {
                    command.Parameters.AddWithValue("name", name);
                 
                }
                command.ExecuteNonQuery();
              

                sc.Close();
                string m = (ins) ? "insert" : "update";
                MessageBox.Show("successfully" + m );
                textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = "";
                this.Hide();
                l.refresh();
                

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        public void start(string name)
        {
            if (name == "")
            {
                textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = "";
             
            }
            else
            {
                try
                {
                 
                    SqlConnection sc = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Digi_VA\\source\\repos\\project\\project\\Database1.mdf;Integrated Security=True");
                    sc.Open();
                    SqlCommand command = new SqlCommand("SELECT * FROM employees WHERE name = '" + name + "' ", sc);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read()) ;
                    {
                        textBox1.Text = reader["name"].ToString();
                        textBox2.Text = reader["mobile"].ToString();
                        textBox3.Text = reader["employee_code"].ToString();
                        textBox4.Text = reader["department"].ToString();
                    }

                    sc.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
