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
using System.IO;

namespace projekt_programowanie
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.textBox2.AutoSize = false;
            this.textBox1.AutoSize = false;

        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source = (localDB)\\MSSQLLocalDB; Initial Catalog = LocalDB; Integrated Security = true");
            con.Open();
            string query = $"SELECT * FROM UserLogin WHERE UserLogin = '{textBox1.Text.ToString()}' AND UserPassword = '{textBox2.Text.ToString()}'";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader read = cmd.ExecuteReader();
            bool userFound = false;
            while (read.Read())
            {
                if (read.GetValue(1).ToString() == textBox1.Text && read.GetValue(2).ToString() == textBox2.Text)
                {
                    userFound = true;
                    this.Hide();
                    Form LoggedUser = new Form2();
                    LoggedUser.Size = this.Size;
                    LoggedUser.Location = this.Location;
                    LoggedUser.StartPosition = FormStartPosition.Manual;
                    LoggedUser.Show();
                    LoggedUser.BringToFront();
                    con.Close();
                    break;
                }
                
            }
            if (!userFound)
            {
                MessageBox.Show("Nie znaleziono użytkownika.");
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            this.Hide();
            Form RegScreen = new Form3();
            RegScreen.Size = this.Size;
            RegScreen.Location = this.Location;
            RegScreen.StartPosition = FormStartPosition.Manual;
            RegScreen.Show();
            RegScreen.BringToFront();
            RegScreen.Text = "Rejestacja użytkownika Varus";
            
        }
    }
}
