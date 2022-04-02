using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
namespace projet
{
    public partial class loginpage : Form
    {
        SqlConnection cnx = new SqlConnection(@"Data Source=LAPTOP-NJ81HHSQ\SQLSERVER;Initial Catalog=dbdd;Integrated Security=True");
        SqlCommand cmd = new SqlCommand();
        SqlDataReader Reader;
        public loginpage()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }


        public void Deconnecter()//ay bd ma7loula tssakerha//
        {
            if (cnx.State == ConnectionState.Open)
            {
                cnx.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            this.Hide();
            admin admin = new admin();
            employe agent = new employe();
            agent employe = new agent();


            Deconnecter();
            cnx.Open();

            cmd = new SqlCommand("select role from users where login='" + textBox2.Text + "'", cnx);

            Reader = cmd.ExecuteReader();
            Reader.Read();
            string x = Convert.ToString(Reader["role"]);


            cnx.Close();
            if (x == "1")
            {
                admin.Show();
            }
            else if (x == "2")
            {
                agent.Show();
            }
            else if (x == "3")
            {
                employe.Show();

            }

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}