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
using ComponentFactory.Krypton.Toolkit;
namespace krypton
{
    public partial class Login : KryptonForm
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void kryptonButton2_Click(object sender, EventArgs e)
        {

        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {

        }

        private void kryptonTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void kryptonTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void kryptonButton1_Click_1(object sender, EventArgs e)
        {
            SqlConnection log = new SqlConnection(@"Data Source=DESKTOP-FPULHH0;Initial Catalog=Wajira;Integrated Security=True");
            log.Open();
            SqlCommand cmd = new SqlCommand("select count(*) from LogInfo where Username='" + kryptonTextBox1.Text + "'and Password='" + kryptonTextBox2.Text + "'", log);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            log.Close();


            try
            {
                if (dt.Rows[0][0].ToString() == "1")
                {
                    Home a = new Home();
                    this.Hide();//colse the log in
                    a.ShowDialog();

                }
                else
                {
                    MessageBox.Show("Invalid Credentials \n Try Again!!");

                }

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
