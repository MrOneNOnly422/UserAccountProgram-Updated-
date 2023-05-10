using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace UserAccountProgram
{
    public partial class Form1 : Form
    {
        private OleDbConnection conn = new OleDbConnection();
        public Form1()
        {
            InitializeComponent();
            conn.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Z:\QQ107\UserAccountProgram-master\UserAccountProgram\bin\Debug\NewAccount.accdb;
            Persist Security Info=False;";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn.Open();
            OleDbCommand cmd = new OleDbCommand();

            cmd.Connection = conn;
            cmd.CommandText = "Select * from AccountInterior where username =  '" + textBox1.Text + "' and password = '" + textBox2.Text +"'";

            OleDbDataReader dr = cmd.ExecuteReader();

            int count = 0;
            while (dr.Read())
            {
                count = count + 1;
            }
            if (count == 1)
            {
                MessageBox.Show("Login successful", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
                Form2 Form = new Form2();
                Form.ShowDialog();
            }
            else
            {
                MessageBox.Show("Incorrect Account information", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            conn.Close();
        }
    }
}
