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
        public void setFormName(Form2 frm)
        {
            thisUserID = Form1.UserID;
            SqlConnection con = new SqlConnection("Data Source = (localDB)\\MSSQLLocalDB; Initial Catalog = LocalDB; Integrated Security = true");
            con.Open();
            string checkUsernameQ = "SELECT FirstName FROM Customers C JOIN UserLogin UL ON C.FK_UserID = UL.UserID WHERE UL.UserID = '" + thisUserID + "';";
            SqlCommand checkUsernameCom = new SqlCommand(checkUsernameQ, con);
            SqlDataReader checkUsernameRead = checkUsernameCom.ExecuteReader();
            if (checkUsernameRead.Read())
            {
                if (checkUsernameRead.IsDBNull(0) || checkUsernameRead.GetValue(0).ToString() == "")
                {
                    frm.Text = "User's profile";
                }
                else
                {
                   frm.Text = checkUsernameRead.GetValue(0).ToString() + "'s profile";
                }
            }
            checkUsernameRead.Close();

        }
        private void Edytuj(object sender, EventArgs e)
        {   thisUserID = Form1.UserID;
            string EditQ = $"UPDATE Customers " +
                           $"SET FirstName = '{FName.Text.ToString()}', LastName = '{Surname.Text.ToString()}', Email = '{Mail.Text.ToString()}', " +
                           $"PhoneNumber = '{Phone.Text.ToString()}', FKP_PaymentID = {Payment.SelectedIndex + 1} " +
                           $"WHERE FK_UserID = {thisUserID}";
            SqlConnection DeleteProfileCon = new SqlConnection("Data Source = (localDB)\\MSSQLLocalDB; Initial Catalog = LocalDB; Integrated Security = true");
            DeleteProfileCon.Open();
            SqlCommand EditCommand = new SqlCommand(EditQ, DeleteProfileCon);
            SqlDataReader EditRead = EditCommand.ExecuteReader();
            EditRead.Close();
            DeleteProfileCon.Close();
            MessageBox.Show("Edycja odbyła się poprawnie !", "Edycja");
            this.Hide();
            Form2 Logowanie = new Form2();
            Logowanie.Location = this.Location;
            Logowanie.StartPosition = FormStartPosition.Manual;
            setFormName(Logowanie);
            Logowanie.Show();
            Logowanie.BringToFront();

        }

        private void CancelEdit(object sender, EventArgs e)
        {
            this.Hide();
            Form2 Logowanie = new Form2();
            Logowanie.Location = this.Location;
            Logowanie.StartPosition = FormStartPosition.Manual;
            setFormName(Logowanie);
            Logowanie.Show();
            Logowanie.BringToFront();
        }

        private void DeleteProfile(object sender, EventArgs e)
        {
            thisUserID = Form1.UserID;
            string DeleteProfileQ = $"DELETE FROM Customers WHERE FK_UserID = {thisUserID};" +
                                    $"DELETE FROM UserLogin WHERE UserID = {thisUserID};";
            SqlConnection DeleteProfileCon = new SqlConnection("Data Source = (localDB)\\MSSQLLocalDB; Initial Catalog = LocalDB; Integrated Security = true");
            DeleteProfileCon.Open();
            SqlCommand DeleteProfileCom = new SqlCommand(DeleteProfileQ, DeleteProfileCon);
            SqlDataReader DeleteProfileRead = DeleteProfileCom.ExecuteReader();
            DeleteProfileCon.Close();
            DeleteProfileRead.Close();
            MessageBox.Show("Usunąłeś swoje konto!", "Usuwanie konta!");
            this.Close();
            Form1 Logowanie = new Form1();
            Logowanie.Location = this.Location;
            Logowanie.StartPosition = FormStartPosition.Manual;
            Logowanie.Show();
            Logowanie.BringToFront();

        }
        
    }
}
