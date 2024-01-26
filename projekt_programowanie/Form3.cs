using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
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
                    int ID;
                    string CreateAccount = $"INSERT INTO UserLogin(UserLogin,UserPassword) VALUES ('{textBox1.Text.ToString()}', " +
                    $"'{textBox2.Text.ToString()}');";
                    SqlCommand sqlCommand = new SqlCommand(CreateAccount, Connection);
                    SqlDataReader ReadCreateAccount = sqlCommand.ExecuteReader();
                    ReadCreateAccount.Close();
                    string getIDQ = "SELECT UserID FROM UserLogin WHERE UserLogin = " + "'" + this.textBox1.Text.ToString() + "'";
                    SqlCommand getIDCom = new SqlCommand(getIDQ, Connection);
                    SqlDataReader getIDRead = getIDCom.ExecuteReader();
                    while (getIDRead.Read()) { ID = Convert.ToInt32(getIDRead.GetValue(0));
                        DateTime dateTime = DateTime.UtcNow.Date;
                        string InsertCustomerQ = $"INSERT INTO Customers(FK_UserID, RegistrationDate) VALUES ({ID}, '{dateTime.Year.ToString()}-{dateTime.Month.ToString()}-{dateTime.Day.ToString()}')";
                        SqlCommand InsertCustomerCom = new SqlCommand(InsertCustomerQ, Connection);
                        SqlDataReader InsertCustomerRead = InsertCustomerCom.ExecuteReader();
                        InsertCustomerRead.Close();
                        getIDRead.Close();
                        break;
                    }

                    
                    MessageBox.Show("Utworzyłeś konto !");
                    this.Hide();
                    Form LogScreen = new Form1();
                    LogScreen.Size = this.Size;
                    LogScreen.Location = this.Location;
                    LogScreen.StartPosition = FormStartPosition.Manual;
                    LogScreen.Show();
                    LogScreen.BringToFront();
                    LogScreen.Text = "Varus";
                    Connection.Close();
                }
                else
                {
                    MessageBox.Show("Hasła się nie zgadzają !");
                }
                
            }
        }
    }
}
