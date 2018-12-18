using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace database
{
    public partial class Form1 : Form


    {
        private string connectionString;
        private MySqlConnection connection;


        public Form1()
        {
            InitializeComponent();
        }

       
        private void Form1_Load(object sender, EventArgs e)
        {
            connectionString = "server=localhost; Database=hosteldb;Uid=root;Pwd=;";
            connection = new MySqlConnection(connectionString);
            connection.Open();
        }



        private void button1_Click(object sender, EventArgs e)
        {

            var usernameText = textBox1.Text;
            var passwordText = textBox2.Text;


            var SelectCommand = new MySqlCommand();
            SelectCommand.CommandText = "select * from users where username=@username and password=@password";
            SelectCommand.Parameters.AddWithValue("@username", usernameText);
            SelectCommand.Parameters.AddWithValue("@password", passwordText);

            SelectCommand.Connection = connection;

            MySqlDataReader dataReader = SelectCommand.ExecuteReader();

            if (dataReader.Read())
            {
                MessageBox.Show("login successful");
            }
            else
            {
                MessageBox.Show("Invalid Username or Password");
            }

        }

    }
}
