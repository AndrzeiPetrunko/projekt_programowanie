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
using System.Diagnostics.Eventing.Reader;
using System.Security.Cryptography.X509Certificates;

namespace projekt_programowanie
{
    public partial class Form1 : Form   
    {
        public static int UserID;
        public Form1()
        {
            InitializeComponent();
            this.textBox2.AutoSize = false;
            this.textBox1.AutoSize = false;
            
        }
        
        public void button1_Click(object sender, EventArgs e)
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
                    UserID = Convert.ToInt32(read.GetValue(0));
                    read.Close();
                    userFound = true;
                    this.Hide();
                    Form2 LoggedUser = new Form2();
                    string checkUsernameQ = "SELECT FirstName FROM Customers C JOIN UserLogin UL ON C.FK_UserID = UL.UserID WHERE UL.UserLogin = '" + textBox1.Text.ToString() + "';";
                    SqlCommand checkUsernameCom = new SqlCommand(checkUsernameQ, con);
                    SqlDataReader checkUsernameRead = checkUsernameCom.ExecuteReader();
                    if (checkUsernameRead.Read())
                    {
                        if (checkUsernameRead.IsDBNull(0) || checkUsernameRead.GetValue(0).ToString() == "")
                        {
                            LoggedUser.Text = "User's profile";
                        }
                        else
                        {
                            LoggedUser.Text = checkUsernameRead.GetValue(0).ToString() + "'s profile";
                        }
                    }

                    
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
