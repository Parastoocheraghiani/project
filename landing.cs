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
    public partial class landing : Form
    {
        public landing()
        {
            InitializeComponent();
        }

        private void landing_Load(object sender, EventArgs e)
        {
            em = new employees(this);
            refresh();
        }
        public void refresh()
        {
            try
            {
                SqlConnection sc = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Digi_VA\\source\\repos\\project\\project\\Database1.mdf;Integrated Security=True");
                sc.Open();
                SqlCommand command = new SqlCommand("SELECT name FROM employees ", sc);
                SqlDataReader reader = command.ExecuteReader();
                comboBox1.Items.Clear();
                while (reader.Read())
                {
                    comboBox1.Items.Add(reader["name"].ToString());
                }
               
                sc.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        employees em;
        private void button2_Click(object sender, EventArgs e)
        {
            em.ins = true;
            em.start("");
            em.Show();
        }

        private employees GetEm()
        {
            return em;
        }

        private void button1_Click(object sender, EventArgs e, employees em)
        {
            em.ins = false;
            string name = comboBox1.Text;
            em.Show();
            em.start("");
        }
    }
}
