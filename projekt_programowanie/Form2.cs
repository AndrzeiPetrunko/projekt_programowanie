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
    public partial class Form2 : Form
    {
        private Panel panel1;
        private Button button2;
        private Button button3;
        private Panel panel2;
        private Button AllOrders;
        private Button NewOrder;
        private DataGridView dataGridView1;
        private Button button1;

        public Form2()
        {
            InitializeComponent();
           
        }

        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.AllOrders = new System.Windows.Forms.Button();
            this.NewOrder = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(56, 303);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(89, 42);
            this.button1.TabIndex = 0;
            this.button1.Text = "Edytuj profil";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.EditProfile);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkBlue;
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Location = new System.Drawing.Point(-34, -1);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(166, 426);
            this.panel1.TabIndex = 1;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(56, 19);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(89, 42);
            this.button3.TabIndex = 3;
            this.button3.Text = "Zamówienia";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.Orders);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(56, 366);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(89, 42);
            this.button2.TabIndex = 2;
            this.button2.Text = "Wyloguj się";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Wylogowanie);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.DarkBlue;
            this.panel2.Controls.Add(this.AllOrders);
            this.panel2.Controls.Add(this.NewOrder);
            this.panel2.Location = new System.Drawing.Point(132, -1);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(143, 148);
            this.panel2.TabIndex = 2;
            this.panel2.Visible = false;
            // 
            // AllOrders
            // 
            this.AllOrders.Location = new System.Drawing.Point(30, 87);
            this.AllOrders.Name = "AllOrders";
            this.AllOrders.Size = new System.Drawing.Size(75, 42);
            this.AllOrders.TabIndex = 4;
            this.AllOrders.Text = "Zobacz wszystkie";
            this.AllOrders.UseVisualStyleBackColor = true;
            // 
            // NewOrder
            // 
            this.NewOrder.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.NewOrder.Location = new System.Drawing.Point(30, 19);
            this.NewOrder.Name = "NewOrder";
            this.NewOrder.Size = new System.Drawing.Size(75, 42);
            this.NewOrder.TabIndex = 4;
            this.NewOrder.Text = "Złóż nowe";
            this.NewOrder.UseVisualStyleBackColor = true;
            this.NewOrder.Click += new System.EventHandler(this.NewOrder_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.RoyalBlue;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(275, -1);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.Size = new System.Drawing.Size(319, 188);
            this.dataGridView1.TabIndex = 3;
            this.dataGridView1.Visible = false;
            // 
            // Form2
            // 
            this.BackColor = System.Drawing.Color.RoyalBlue;
            this.ClientSize = new System.Drawing.Size(749, 419);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Form2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        private void EditProfile(object sender, EventArgs e)
        {
            Form EditProfile = new Form4();
            EditProfile.Size = this.Size;
            EditProfile.Location = this.Location;
            EditProfile.StartPosition = FormStartPosition.Manual;
            EditProfile.Show();
            this.Hide();
            EditProfile.BringToFront();
            EditProfile.Text = "Edycja profilu";
        }

        private void Wylogowanie(object sender, EventArgs e)
        {
            this.Hide();
            Form1 Logowanie = new Form1();
            Logowanie.Location = this.Location;
            Logowanie.StartPosition = FormStartPosition.Manual;
            Logowanie.Show();
            Logowanie.BringToFront();
        }

        private void Orders(object sender, EventArgs e)
        {
            if (panel2.Visible == false) { panel2.Visible = true;  }
            else { panel2.Visible = false; };
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            SqlConnection Connection = new SqlConnection("Data Source = (localDB)\\MSSQLLocalDB; Initial Catalog = LocalDB; Integrated Security = true; MultipleActiveResultSets = true");
            Connection.Open();
            SqlDataAdapter Adapter = new SqlDataAdapter("SELECT ProductID, ProductName, UnitPrice FROM Products", Connection);
            DataSet dataSet = new DataSet();
            Adapter.Fill(dataSet, "Products");
            dataGridView1.DataSource = dataSet;
            dataGridView1.DataMember = "Products";
            DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn
            {
                Name = "Select",
                HeaderText = "Select",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            };
            DataGridViewTextBoxColumn textBoxColumn = new DataGridViewTextBoxColumn
            {
                Name = "Amount",
                HeaderText = "Amount",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            };
            dataGridView1.Columns.Insert(0, checkBoxColumn);
            dataGridView1.Columns.Insert(4, textBoxColumn);
            dataGridView1.AllowUserToAddRows = false;
        }

        private void NewOrder_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = true;
        }
    }
}
