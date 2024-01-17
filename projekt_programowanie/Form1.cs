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

namespace projekt_programowanie
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string ConString = "Data Source = (localDB)\\MSSQLLocalDB; Initial Catalog = LocalDB; Integrated Security = true";
            SqlConnection con = new SqlConnection(ConString);
            con.Open();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string ConString = "Data Source = (localDB)\\MSSQLLocalDB; Initial Catalog = LocalDB; Integrated Security = true";
            SqlConnection con = new SqlConnection(ConString);
            con.Open();
            string query = $"INSERT INTO Customers VALUES (\'{textBox1.Text.ToString()}\',\'{textBox2.Text.ToString()}\');" +
                $"SELECT * FROM Customers WHERE Imie = \'{textBox1.Text.ToString()}\'";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                MessageBox.Show($"{r.GetValue(0).ToString()} : {r.GetValue(1).ToString()}");
            }
        }
    }
}
