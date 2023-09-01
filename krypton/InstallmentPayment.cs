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
    public partial class InstallmentPayment : KryptonForm
    {
        public InstallmentPayment()
        {
            InitializeComponent();
        }

        private void InstallmentPayment_Load(object sender, EventArgs e)
        {
            try { 
            
            AutoCompleteStringCollection auto = new AutoCompleteStringCollection();
                SqlConnection co = new SqlConnection(@"Data Source=DESKTOP-FPULHH0;Initial Catalog=Wajira;Integrated Security=True");
                co.Open();
                string sql = "SELECT * FROM Card";
                SqlCommand cmd = new SqlCommand(sql, co);
                SqlDataReader sdr = null;
                sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    auto.Add(sdr["Card_No"].ToString());
                }
                
                textBox1.AutoCompleteCustomSource=auto;
                sdr.Close();
                co.Close();
            
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
            
            }
        }

        private void kryptonButton4_Click(object sender, EventArgs e)
        {
            Home a = new Home();
            this.Hide();
            a.Show();
        }

        private void kryptonButton2_Click(object sender, EventArgs e)
        {
            
            
                SqlConnection Conn = new SqlConnection(@"Data Source=DESKTOP-FPULHH0;Initial Catalog=Wajira;Integrated Security=True");
                SqlCommand Comm1 = new SqlCommand("SELECT Ins_Amount FROM Card WHERE Card_No =" + int.Parse(textBox1.Text) + ";", Conn);
                SqlCommand comm2 = new SqlCommand("SELECT Total FROM Card WHERE Card_No =" + int.Parse(textBox1.Text) + ";", Conn);
                SqlCommand comm3 = new SqlCommand("SELECT DownPayment FROM Card WHERE Card_No =" + int.Parse(textBox1.Text) + ";", Conn);
                Conn.Open();

                object insAmt = new object();
                object total = new object();
                object down = new object();



                insAmt = Comm1.ExecuteScalar();
                total = comm2.ExecuteScalar();
                down = comm3.ExecuteScalar();
        
            
                string myObjectString = total.ToString();
                label4.Text = "Total Amount is " + myObjectString;
            

                String ins = insAmt.ToString();
                label6.Text = "Installment Amount is " + ins;

                String lbldp = down.ToString();
                label7.Text = "Down Payment is " + lbldp;

                int x = int.Parse(ins);
                int t = int.Parse(myObjectString);
                int d = int.Parse(lbldp);
                        
            

            int balance;
            int paid;
            try
            {
                if (comboBox1.Text == "Installment One")
                {

                    paid = x * 1;
                    balance = (t - paid) - d;
                    string inslbl = balance.ToString();
                    label5.Text = "Remaining Balance is " + inslbl;

                }

                else if (comboBox1.Text == "Installment Two")
                {

                    paid = x * 2;
                    balance = (t - paid) - d;
                    string inslbl = balance.ToString();
                    label5.Text = "Remaining Balance is " + inslbl;

                }

                else if (comboBox1.Text == "Installment Three")
                {

                    paid = x * 3;
                    balance = (t - paid) - d;
                    string inslbl = balance.ToString();
                    label5.Text = "Remaining Balance is " + inslbl;

                }

                else if (comboBox1.Text == "Installment Four")
                {

                    paid = x * 4;
                    balance = (t - paid) - d;
                    string inslbl = balance.ToString();
                    label5.Text = "Remaining Balance is " + inslbl;

                }

                else if (comboBox1.Text == "Installment Five")
                {

                    paid = x * 5;
                    balance = (t - paid) - d;
                    string inslbl = balance.ToString();
                    label5.Text = "Remaining Balance is " + inslbl;

                }

                else if (comboBox1.Text == "Installment Six")
                {

                    paid = (x * 6) - d;
                    balance = t - paid;
                    string inslbl = balance.ToString();
                    label5.Text = "Remaining Balance is " + inslbl;

                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Unable to Process" + "" + ex.Message);

            }
            finally {
                Conn.Close(); } }

            

          

        private void kryptonButton3_Click(object sender, EventArgs e)
        {
            string var;
            var = comboBox1.Text;

            try
            {

                if (var == "Installment One")
                {
                    SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-FPULHH0;Initial Catalog=Wajira;Integrated Security=True");

                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "update Status set One ='" + "Complete" + "',Two ='" + "Incomplete" + "',Three ='" + "Incomplete" + "',Four ='" + "Incomplete" + "',Five ='" + "Incomplete" + "',Six ='" + "Incomplete" + "',Completed_Status='" + "NO" + "' where St_Ref='" + int.Parse(textBox1.Text) + "'";
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Updated Successfully", "Transaction succesful", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }

                else if (var == "Installment Two")
                {

                    SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-FPULHH0;Initial Catalog=Wajira;Integrated Security=True");

                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "update Status set One ='" + "Complete" + "',Two ='" + "Complete" + "',Three ='" + "Incomplete" + "',Four ='" + "Incomplete" + "',Five ='" + "Incomplete" + "',Six ='" + "Incomplete" + "',Completed_Status='" + "NO" + "' where St_Ref='" + int.Parse(textBox1.Text) + "'";
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Updated Successfully","Transaction succesful", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }

                else if (var == "Installment Three")
                {

                    SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-FPULHH0;Initial Catalog=Wajira;Integrated Security=True");

                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "update Status set One ='" + "Complete" + "',Two ='" + "Complete" + "',Three ='" + "Complete" + "',Four ='" + "Incomplete" + "',Five ='" + "Incomplete" + "',Six ='" + "Incomplete" + "',Completed_Status='" + "NO" + "' where St_Ref='" + int.Parse(textBox1.Text) + "'";
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Updated Successfully", "Transaction succesful", MessageBoxButtons.OK, MessageBoxIcon.Information);


                }

                else if (var == "Installment Four")
                {

                    SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-FPULHH0;Initial Catalog=Wajira;Integrated Security=True");

                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "update Status set One ='" + "Complete" + "',Two ='" + "Complete" + "',Three ='" + "Complete" + "',Four ='" + "Complete" + "',Five ='" + "Incomplete" + "',Six ='" + "Incomplete" + "',Completed_Status='" + "NO" + "' where St_Ref='" + int.Parse(textBox1.Text) + "'";
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Updated Successfully", "Transaction succesful", MessageBoxButtons.OK, MessageBoxIcon.Information);


                }

                else if (var == "Installment Five")
                {

                    SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-FPULHH0;Initial Catalog=Wajira;Integrated Security=True");

                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "update Status set One ='" + "Complete" + "',Two ='" + "Complete" + "',Three ='" + "Complete" + "',Four ='" + "Complete" + "',Five ='" + "Complete" + "',Six ='" + "Incomplete" + "',Completed_Status='" + "NO" + "' where St_Ref='" + int.Parse(textBox1.Text) + "'";
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Updated Successfully", "Transaction succesful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                else if (var == "Installment Six")
                {

                    SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-FPULHH0;Initial Catalog=Wajira;Integrated Security=True");

                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "update Status set One ='" + "Complete" + "',Two ='" + "Complete" + "',Three ='" + "Complete" + "',Four ='" + "Complete" + "',Five ='" + "Complete" + "',Six ='" + "Complete" + "',Completed_Status='" + "YES" + "' where St_Ref='" + int.Parse(textBox1.Text) + "'";
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Updated Successfully", "Transaction succesful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            catch (Exception ex) {

                MessageBox.Show("Unable to Process the Payment");
            }

            textBox1.Text = String.Empty;
            comboBox1.Text = String.Empty;

            label5.Text = "";
            label6.Text = "";
            label7.Text = "";
            label4.Text = "";
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            textBox1.Text = String.Empty;
            comboBox1.Text = String.Empty;

            label5.Text = "";
            label6.Text = "";
            label7.Text = "";
            label4.Text = "";
        }
    }
}
