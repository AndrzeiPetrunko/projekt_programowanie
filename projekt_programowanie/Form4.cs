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

namespace projekt_programowanie
{
    public partial class Form4 : Form
    {
        int thisUserID;
        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {   thisUserID = Form1.UserID;
            string EditQ = $"UPDATE Customers " +
                           $"SET FirstName = '{FName.Text.ToString()}', LastName = '{Surname.Text.ToString()}', Email = '{Mail.Text.ToString()}', " +
                           $"PhoneNumber = '{Phone.Text.ToString()}', FKP_PaymentID = {Payment.SelectedIndex + 1} " +
                           $"WHERE FK_UserID = {thisUserID}";
            SqlConnection EditCon = new SqlConnection("Data Source = (localDB)\\MSSQLLocalDB; Initial Catalog = LocalDB; Integrated Security = true");
            EditCon.Open();
            SqlCommand EditCommand = new SqlCommand(EditQ, EditCon);
            SqlDataReader EditRead = EditCommand.ExecuteReader();
            EditRead.Close();
            EditCon.Close();
            MessageBox.Show("Edycja odbyła się poprawnie !", "Edycja");
            this.Hide();
            Form2 UserScreen = new Form2();
            UserScreen.Location = this.Location;
            UserScreen.StartPosition = FormStartPosition.Manual;
            UserScreen.Show();
            UserScreen.BringToFront();


            SqlConnection con = new SqlConnection("Data Source = (localDB)\\MSSQLLocalDB; Initial Catalog = LocalDB; Integrated Security = true");
            con.Open();
            string checkUsernameQ = "SELECT FirstName FROM Customers C JOIN UserLogin UL ON C.FK_UserID = UL.UserID WHERE UL.UserID = '" + thisUserID + "';";
            SqlCommand checkUsernameCom = new SqlCommand(checkUsernameQ, con);
            SqlDataReader checkUsernameRead = checkUsernameCom.ExecuteReader();
            if (checkUsernameRead.Read())
            {
                if (checkUsernameRead.IsDBNull(0) || checkUsernameRead.GetValue(0).ToString() == "")
                {
                    UserScreen.Text = "User's profile";
                }
                else
                {
                    UserScreen.Text = checkUsernameRead.GetValue(0).ToString() + "'s profile";
                }
            }
            checkUsernameRead.Close();
            UserScreen.Show();

        }
    }
}
