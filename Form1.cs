using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace ExampleAdoNet
{
    public partial class Form1 : Form
    {
        //string connectionStr = "Server=localhost; Port=5432; Database=jewerly; User Id=postgres; Password=saak2108;";
        public Form1()
        {
            InitializeComponent();
            textBox_addres.Text = "localhost";
            textBox_port.Text = "5432";
            textBox_user.Text = "postgres";
            textBox_pass.Text = "saak2108";
            textBox_database.Text = "jewerly";
        }


        private void btn_ConnDB_Click(object sender, EventArgs e)
        {
            //string connectionSt = "Server=localhost; Port=5432; Database=jewerly; User Id=postgres; Password=saak2108;";
            string server = "Server=" + textBox_addres.Text+";";
            string port = "Port=" + textBox_port.Text + ";";
            string user = "User Id=" + textBox_user.Text + ";";
            string pass = "Password=" + textBox_pass.Text + ";";
            string data = "Database=" + textBox_database.Text + ";";
            try
            {

                NpgsqlConnection connection = new NpgsqlConnection(server+port+user+pass+data);
                connection.Open();
                textBox_result.Text = "Подключился " + connection.Database;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
