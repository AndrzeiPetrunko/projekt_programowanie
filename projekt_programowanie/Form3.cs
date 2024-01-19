using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projekt_programowanie
{
    public partial class Form3 : Form

    {
        public Form3()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection Connection = new SqlConnection("Data Source = (localDB)\\MSSQLLocalDB; Initial Catalog = LocalDB; Integrated Security = true; MultipleActiveResultSets = true");
            Connection.Open();
            string query = $"SELECT UserLogin, UserPassword FROM UserLogin";
            SqlCommand cmd = new SqlCommand(query, Connection);
            SqlDataReader reader = cmd.ExecuteReader();
            bool UserExists = false;
            while (reader.Read())
            {
                if (reader.GetValue(0).ToString() == textBox1.Text)
                {
                    UserExists = true;
                    Connection.Close();
                    break;
                    
                }
            }
            if (UserExists)
            {
                MessageBox.Show("Podany login już jest zajęty.", "Błąd!");
            }
            else
            {
                if (textBox2.Text == textBox3.Text)
                {
                    SqlConnection ConnectionCreateAccount = new SqlConnection("Data Source = (localDB)\\MSSQLLocalDB; Initial Catalog = LocalDB; Integrated Security = true; MultipleActiveResultSets = true");
                    ConnectionCreateAccount.Open();
                    string CreateAccount = $"INSERT INTO UserLogin(UserLogin,UserPassword) VALUES ('{textBox1.Text.ToString()}', " +
                    $"'{textBox2.Text.ToString()}')";
                    SqlCommand sqlCommand = new SqlCommand(CreateAccount, Connection);
                    SqlDataReader ReadCreateAccount = sqlCommand.ExecuteReader();
                    MessageBox.Show("Utworzyłeś konto !");
                    this.Hide();
                    Form RegScreen = new Form1();
                    RegScreen.Size = this.Size;
                    RegScreen.Location = this.Location;
                    RegScreen.StartPosition = FormStartPosition.Manual;
                    RegScreen.Show();
                    RegScreen.BringToFront();
                    RegScreen.Text = "Varus";
                }
                else
                {
                    MessageBox.Show("Hasła się nie zgadzają !");
                }
                
            }
        }
    }
}
