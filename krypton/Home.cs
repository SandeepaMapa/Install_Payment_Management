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
    public partial class Home : KryptonForm
    {
        public Home()
        {
            InitializeComponent();
        }

        private void Home_Load(object sender, EventArgs e)
        {
            label2.Text = DateTime.Now.ToLongDateString();
           

            SqlConnection conn1 = new SqlConnection(@"Data Source=DESKTOP-FPULHH0;Initial Catalog=Wajira;Integrated Security=True");
            { 
            if (conn1.State == ConnectionState.Closed)
                    conn1.Open();
            }
            try
            {
                SqlCommand cmd1 = new SqlCommand("SELECT C.[Card_No], C.[Total], C.[DownPayment], C.[Balance], C.[Ins_Amount], c1.[Cus_Name],c1.[Telephone] FROM Card AS C LEFT JOIN Cus_Details AS c1  ON C.NIC =c1.NIC  LEFT JOIN Ins_Dates AS c2  ON C.Da_Ref = c2.Da_Ref WHERE c2.Installment_1 ='" + dateTimePicker1.Text + "'OR c2.Installment_2 ='" + dateTimePicker1.Text + "'OR c2.Installment_3 ='" + dateTimePicker1.Text + "'OR c2.Installment_4 ='" + dateTimePicker1.Text + "'OR c2.Installment_5 ='" + dateTimePicker1.Text + "'OR c2.Installment_6 ='" + dateTimePicker1.Text + "';", conn1);
                SqlDataAdapter adapter = new SqlDataAdapter();
                DataTable dt = new DataTable();

                adapter.SelectCommand = cmd1;
                dt.Clear();

                adapter.Fill(dt);

                dataGridView1.DataSource = dt;
            }
            catch (Exception ex) {

                MessageBox.Show("Error loading Card Details");
            }
        }

        private void kryptonButton3_Click(object sender, EventArgs e)
        {
            SearchDirectory formn = new SearchDirectory();
            this.Hide();
            formn.ShowDialog();
        }

        private void kryptonButton2_Click(object sender, EventArgs e)
        {
            InstallmentPayment form = new InstallmentPayment();
            this.Hide();
            form.ShowDialog();
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            AddNew a = new AddNew();
            this.Hide();
            a.ShowDialog();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {
            SqlConnection conn1 = new SqlConnection(@"Data Source=DESKTOP-FPULHH0;Initial Catalog=Wajira;Integrated Security=True");
            {
                if (conn1.State == ConnectionState.Closed)
                    conn1.Open();
            }
            try
            {
                SqlCommand cmd1 = new SqlCommand("SELECT C.[Card_No], C.[Total], C.[DownPayment], C.[Balance], C.[Ins_Amount], c1.[Cus_Name],c1.[Telephone] FROM Card AS C LEFT JOIN Cus_Details AS c1  ON C.NIC =c1.NIC  LEFT JOIN Ins_Dates AS c2  ON C.Da_Ref = c2.Da_Ref WHERE c2.Installment_1 ='" + dateTimePicker1.Text + "'OR c2.Installment_2 ='" + dateTimePicker1.Text + "'OR c2.Installment_3 ='" + dateTimePicker1.Text + "'OR c2.Installment_4 ='" + dateTimePicker1.Text + "'OR c2.Installment_5 ='" + dateTimePicker1.Text + "'OR c2.Installment_6 ='" + dateTimePicker1.Text + "';", conn1);
                SqlDataAdapter adapter = new SqlDataAdapter();
                DataTable dt = new DataTable();

                adapter.SelectCommand = cmd1;
                dt.Clear();

                adapter.Fill(dt);

                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void kryptonButton4_Click(object sender, EventArgs e)
        {
            DeleteCard a = new DeleteCard();
            this.Hide();
            a.ShowDialog();
        }

        private void Closing_Form(object sender, FormClosingEventArgs e)
        {
           /* if (MessageBox.Show("Are you sure you want to exit the application","Exit application?",MessageBoxButtons.YesNo, MessageBoxIcon.Question)== DialogResult.Yes) { 
            
               Application.Exit();
            }*/
        }
    }
}
