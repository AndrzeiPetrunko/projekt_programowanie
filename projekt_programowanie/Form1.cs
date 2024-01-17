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
            string query = $"INSERT INTO Customers(FirstName, LastName) VALUES (\'{textBox1.Text.ToString()}\',\'{textBox2.Text.ToString()}\');" +
                $"SELECT * FROM Customers WHERE FirstName = \'{textBox1.Text.ToString()}\'";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                MessageBox.Show($"{r.GetValue(3).ToString()} : {r.GetValue(4).ToString()}");
            }
            OpenSecondForm();
            
        }
        void OpenSecondForm()
        {
            Form form2 = new Form();
            form2.ShowDialog();
        }
    }
}
