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
    public partial class AddNew : KryptonForm
    {
        public AddNew()
        {
            InitializeComponent();
        }

        private void AddNew_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
            lbldate2.Text = "Today is " + " " + DateTime.Now.ToLongDateString();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void kryptonPalette1_PalettePaint(object sender, PaletteLayoutEventArgs e)
        {

        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            Home a = new Home();
            this.Hide();
            a.Show();

        }

        private void kryptonButton3_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection on = new SqlConnection(@"Data Source=DESKTOP-FPULHH0;Initial Catalog=Wajira;Integrated Security=True");

                on.Open();
                SqlCommand cmd = new SqlCommand("insert into Card(Card_No,NIC,St_Ref,Da_Ref,Date,Total, DownPayment, Balance, Ins_Amount) values (@Card_No,@NIC,@St_Ref,@Da_Ref,@Date,@Total,@DownPayment, @Balance, @Ins_Amount)", on);
                cmd.Parameters.AddWithValue("@Card_No", int.Parse(textBox1.Text));
                cmd.Parameters.AddWithValue("@NIC", textBox5.Text);
                cmd.Parameters.AddWithValue("@St_Ref", int.Parse(textBox1.Text));
                cmd.Parameters.AddWithValue("@Da_Ref", int.Parse(textBox1.Text));
                cmd.Parameters.AddWithValue("@Date", DateTime.Parse(dateTimePicker1.Text));
                cmd.Parameters.AddWithValue("@Total", float.Parse(textBox6.Text));
                cmd.Parameters.AddWithValue("@DownPayment", float.Parse(textBox3.Text));
                cmd.Parameters.AddWithValue("@Balance", float.Parse(textBox8.Text));
                cmd.Parameters.AddWithValue("@Ins_Amount", float.Parse(textBox9.Text));


                cmd.ExecuteNonQuery();
                on.Close();

                MessageBox.Show("Saved Successfully","Success!!",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            catch (Exception ex) {

                MessageBox.Show("Unable to Proceed \n Try Again!!");
            }

            {
                textBox1.Text = String.Empty;
                textBox2.Text = String.Empty;
                textBox3.Text = String.Empty;
                textBox4.Text = String.Empty;
                textBox5.Text = String.Empty;
                textBox6.Text = String.Empty;
                textBox8.Text = String.Empty;
                textBox9.Text = String.Empty;

                dateTimePicker2.Text = DateTime.Now.ToString();
                dateTimePicker3.Text = DateTime.Now.ToString();
                dateTimePicker4.Text = DateTime.Now.ToString();
                dateTimePicker5.Text = DateTime.Now.ToString();
                dateTimePicker6.Text = DateTime.Now.ToString();
                dateTimePicker7.Text = DateTime.Now.ToString();


            }
        }

        private void kryptonButton4_Click(object sender, EventArgs e)
        {
            {
                int total = int.Parse(textBox6.Text);
                int dp = int.Parse(textBox3.Text);
                int balance = total - dp;
                int installment = balance / 6;
                textBox8.Text = balance.ToString();
                textBox9.Text = installment.ToString();
            }

            
                {
                    SqlConnection connd = new SqlConnection(@"Data Source=DESKTOP-FPULHH0;Initial Catalog=Wajira;Integrated Security=True");

                    connd.Open();

                    SqlCommand cmd1 = new SqlCommand("insert into Cus_Details(NIC,Cus_Name,Telephone) values (@NIC,@Cus_Name,@Telephone)", connd);

                    cmd1.Parameters.AddWithValue("@NIC", textBox5.Text);
                    cmd1.Parameters.AddWithValue("@Cus_Name", textBox4.Text);
                    cmd1.Parameters.AddWithValue("@Telephone", textBox2.Text);

                    cmd1.ExecuteNonQuery();
                    connd.Close();
                }

                {
                    SqlConnection connd2 = new SqlConnection(@"Data Source=DESKTOP-FPULHH0;Initial Catalog=Wajira;Integrated Security=True");

                    connd2.Open();

                    SqlCommand cmd2 = new SqlCommand("insert into Ins_Dates(Da_Ref, Installment_1, Installment_2, Installment_3, Installment_4, Installment_5, Installment_6) values (@Da_Ref, @Installment_1, @Installment_2, @Installment_3, @Installment_4, @Installment_5, @Installment_6)", connd2);

                    cmd2.Parameters.AddWithValue("@Da_Ref", int.Parse(textBox1.Text));
                    cmd2.Parameters.AddWithValue("@Installment_1", DateTime.Parse(dateTimePicker2.Text));
                    cmd2.Parameters.AddWithValue("@Installment_2", DateTime.Parse(dateTimePicker3.Text));
                    cmd2.Parameters.AddWithValue("@Installment_3", DateTime.Parse(dateTimePicker4.Text));
                    cmd2.Parameters.AddWithValue("@Installment_4", DateTime.Parse(dateTimePicker5.Text));
                    cmd2.Parameters.AddWithValue("@Installment_5", DateTime.Parse(dateTimePicker6.Text));
                    cmd2.Parameters.AddWithValue("@Installment_6", DateTime.Parse(dateTimePicker7.Text));

                    cmd2.ExecuteNonQuery();
                    connd2.Close();
                }


            {
                SqlConnection connd3 = new SqlConnection(@"Data Source=DESKTOP-FPULHH0;Initial Catalog=Wajira;Integrated Security=True");

                connd3.Open();

                string x = "Incomplete";
                string y = "NO";

                SqlCommand cmd3 = new SqlCommand("insert into Status (St_Ref, One, Two, Three, Four, Five, Six, Completed_Status) values (@St_Ref,@One, @Two, @Three, @Four, @Five, @Six, @Completed_Status)", connd3);

                cmd3.Parameters.AddWithValue("@St_Ref", int.Parse(textBox1.Text));
                cmd3.Parameters.AddWithValue("@One", x);
                cmd3.Parameters.AddWithValue("@Two", x);
                cmd3.Parameters.AddWithValue("@Three", x);
                cmd3.Parameters.AddWithValue("@Four", x);
                cmd3.Parameters.AddWithValue("@Five", x);
                cmd3.Parameters.AddWithValue("@Six", x);
                cmd3.Parameters.AddWithValue("@Completed_Status", y);

                cmd3.ExecuteNonQuery();
                connd3.Close();
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void kryptonButton2_Click(object sender, EventArgs e)
        {
            {
                textBox1.Text = String.Empty;
                textBox2.Text = String.Empty;
                textBox3.Text = String.Empty;
                textBox4.Text = String.Empty;
                textBox5.Text = String.Empty;
                textBox6.Text = String.Empty;
                textBox8.Text = String.Empty;
                textBox9.Text = String.Empty;

                dateTimePicker2.Text = DateTime.Now.ToString();
                dateTimePicker3.Text = DateTime.Now.ToString();
                dateTimePicker4.Text = DateTime.Now.ToString();
                dateTimePicker5.Text = DateTime.Now.ToString();
                dateTimePicker6.Text = DateTime.Now.ToString();
                dateTimePicker7.Text = DateTime.Now.ToString();


            }
        }

        private void AddNew_FormClosing(object sender, FormClosingEventArgs e)
        {
           
        }
    }
}
