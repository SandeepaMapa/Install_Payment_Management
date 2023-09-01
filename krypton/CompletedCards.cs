using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using System.Data.SqlClient;


namespace krypton
{
    public partial class CompletedCards : KryptonForm
    {
        public CompletedCards()
        {
            InitializeComponent();
        }

        private void CompletedCards_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
            SqlConnection connm = new SqlConnection(@"Data Source=DESKTOP-FPULHH0;Initial Catalog=Wajira;Integrated Security=True");
            {
                if (connm.State == ConnectionState.Closed)
                    connm.Open();
            }

            SqlCommand cmd1 = new SqlCommand("SELECT C.[Card_No], C.[Date], C.[Total], S.[Cus_Name] , S.[Telephone] FROM Card C, Cus_Details S, Status T WHERE T.Completed_Status='YES' AND C.NIC=S.NIC AND C.St_Ref= T.St_Ref", connm);

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable dt = new DataTable();

            adapter.SelectCommand = cmd1;
            dt.Clear();

            adapter.Fill(dt);

            dataGridView1.DataSource = dt;
        }

        private void kryptonButton4_Click(object sender, EventArgs e)
        {
            SearchDirectory a = new SearchDirectory();
            this.Hide();
            a.ShowDialog();
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            {

                SqlConnection conn1 = new SqlConnection(@"Data Source=DESKTOP-FPULHH0;Initial Catalog=Wajira;Integrated Security=True");
                {
                    if (conn1.State == ConnectionState.Closed)
                        conn1.Open();
                }

                SqlCommand cmd1 = new SqlCommand("SELECT I.[One], I.[Two], I.[Three], I.[Four], I.[Five], I.[Six] FROM Status I, Card C WHERE C.Card_No=" + int.Parse(textBox1.Text) + "AND I.St_Ref=C.Da_Ref;", conn1);
                SqlDataAdapter adapter = new SqlDataAdapter();
                DataTable dt = new DataTable();

                adapter.SelectCommand = cmd1;
                dt.Clear();

                adapter.Fill(dt);

                dataGridView1.DataSource = dt;


            }
        }
    }
}
