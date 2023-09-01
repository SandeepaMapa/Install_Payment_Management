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
    public partial class SearchCards : KryptonForm
    {
        public SearchCards()
        {
            InitializeComponent();
        }

        private void SearchCards_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
           
            { {
                SqlConnection Conn = new SqlConnection(@"Data Source=DESKTOP-FPULHH0;Initial Catalog=Wajira;Integrated Security=True");
                SqlCommand Comm1 = new SqlCommand("SELECT S.[Cus_Name] FROM Card C, Cus_Details S WHERE C.Card_No=" + int.Parse(textBox1.Text) + "AND C.NIC=S.NIC;", Conn);
                Conn.Open();

                object myobject = new object();
                myobject = Comm1.ExecuteScalar();
                    if (myobject == null)
                    {
                        MessageBox.Show("Error in loading data\n Try Again!!", "Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    }
                    else
                    {
                        string myObjectString = myobject.ToString();
                        textBox4.Text = myObjectString;
                        Conn.Close();
                    } //NEW COMMIT TEST
            }

            {
                SqlConnection Conn = new SqlConnection(@"Data Source=DESKTOP-FPULHH0;Initial Catalog=Wajira;Integrated Security=True");
                SqlCommand Comm1 = new SqlCommand("SELECT NIC FROM Card WHERE Card_No=" + int.Parse(textBox1.Text) + ";", Conn);
                Conn.Open();

                object myobject = new object();
                myobject = Comm1.ExecuteScalar();
                    if (myobject == null)
                    {
                        label12.Text = "x";
                    }
                    else
                    {
                        string myObjectString = myobject.ToString();
                        textBox5.Text = myObjectString;
                        Conn.Close();
                    }

            }
            {

                SqlConnection Conn = new SqlConnection(@"Data Source=DESKTOP-FPULHH0;Initial Catalog=Wajira;Integrated Security=True");
                SqlCommand Comm1 = new SqlCommand("SELECT S.[Telephone] FROM Cus_Details S, Card C WHERE C.Card_No =" + int.Parse(textBox1.Text) + "AND C.NIC=S.NIC;", Conn);
                Conn.Open();

                object myobject = new object();
                myobject = Comm1.ExecuteScalar();
                    if (myobject == null)
                    {
                        label12.Text = "x";
                    }
                    else
                    {
                        string myObjectString = myobject.ToString();
                        textBox2.Text = myObjectString;
                        Conn.Close();
                    }

            }

            {

                SqlConnection Conn = new SqlConnection(@"Data Source=DESKTOP-FPULHH0;Initial Catalog=Wajira;Integrated Security=True");
                SqlCommand Comm1 = new SqlCommand("SELECT Date FROM Card WHERE Card_No =" + int.Parse(textBox1.Text) + ";", Conn);
                Conn.Open();
                DateTime z;

                object myobject = new object();
                myobject = Comm1.ExecuteScalar();
                    if (myobject == null)
                    {
                        label12.Text = "x";
                    }
                    else
                    {

                        DateTime y = Convert.ToDateTime(myobject);
                        var dateTime = y;
                        var shortDateValue = dateTime.ToShortDateString();



                        String myObjectString = shortDateValue.ToString();

                        textBox3.Text = myObjectString;
                        Conn.Close();
                    }
            }

            {

                SqlConnection Conn = new SqlConnection(@"Data Source=DESKTOP-FPULHH0;Initial Catalog=Wajira;Integrated Security=True");
                SqlCommand Comm1 = new SqlCommand("SELECT Total FROM Card WHERE Card_No =" + int.Parse(textBox1.Text) + ";", Conn);
                Conn.Open();

                object myobject = new object();
                myobject = Comm1.ExecuteScalar();
                    if (myobject == null)
                    {
                        label12.Text = "x";
                    }
                    else
                    {
                        string myObjectString = myobject.ToString();
                        textBox6.Text = myObjectString;
                        Conn.Close();
                    }

            }

            {

                SqlConnection Conn = new SqlConnection(@"Data Source=DESKTOP-FPULHH0;Initial Catalog=Wajira;Integrated Security=True");
                SqlCommand Comm1 = new SqlCommand("SELECT DownPayment FROM Card WHERE Card_No =" + int.Parse(textBox1.Text) + ";", Conn);
                Conn.Open();

                object myobject = new object();
                myobject = Comm1.ExecuteScalar();
                    if (myobject == null)
                    {
                        label12.Text = "x";
                    }
                    else
                    {
                        string myObjectString = myobject.ToString();
                        textBox7.Text = myObjectString;
                        Conn.Close();
                    }
            }

            {
                SqlConnection Conn = new SqlConnection(@"Data Source=DESKTOP-FPULHH0;Initial Catalog=Wajira;Integrated Security=True");
                SqlCommand Comm1 = new SqlCommand("SELECT Ins_Amount FROM Card WHERE Card_No =" + int.Parse(textBox1.Text) + ";", Conn);
                Conn.Open();

                object myobject = new object();
                myobject = Comm1.ExecuteScalar();
                    if (myobject == null)
                    {
                        label12.Text = "x";
                    }
                    else
                    {
                        string myObjectString = myobject.ToString();
                        textBox8.Text = myObjectString;
                        Conn.Close();
                    }

            }

            {

                SqlConnection conn1 = new SqlConnection(@"Data Source=DESKTOP-FPULHH0;Initial Catalog=Wajira;Integrated Security=True");
                {
                    if (conn1.State == ConnectionState.Closed)
                        conn1.Open();
                }

                SqlCommand cmd1 = new SqlCommand("SELECT I.[Installment_1], I.[Installment_2], I.[Installment_3], I.[Installment_4], I.[Installment_5], I.[Installment_6] FROM Ins_Dates I, Card C WHERE C.Card_No=" + int.Parse(textBox1.Text) + "AND I.Da_Ref=C.Da_Ref;", conn1);
                SqlDataAdapter adapter = new SqlDataAdapter();
                DataTable dt = new DataTable();

                adapter.SelectCommand = cmd1;
                dt.Clear();

                adapter.Fill(dt);

                dataGridView1.DataSource = dt;


            }

            {
                SqlConnection conn1 = new SqlConnection(@"Data Source=DESKTOP-FPULHH0;Initial Catalog=Wajira;Integrated Security=True");
                {
                    if (conn1.State == ConnectionState.Closed)
                        conn1.Open();
                }

                SqlCommand cmd1 = new SqlCommand("SELECT S.[One], S.[Two], S.[Three], S.[Four], S.[Five], S.[Six], S.[Completed_Status] FROM Status S, Card C WHERE C.Card_No=" + int.Parse(textBox1.Text) + "AND S.St_Ref=C.St_Ref;", conn1);
                SqlDataAdapter adapter = new SqlDataAdapter();
                DataTable dt1 = new DataTable();

                adapter.SelectCommand = cmd1;
                dt1.Clear();

                adapter.Fill(dt1);

                dataGridView2.DataSource = dt1;
            }
        }
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void kryptonButton4_Click(object sender, EventArgs e)
        {
            SearchDirectory a = new SearchDirectory();
            this.Hide();
            a.ShowDialog();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void kryptonButton2_Click(object sender, EventArgs e)
        {
            textBox1.Text = String.Empty;
            textBox2.Text = String.Empty;
            textBox3.Text = String.Empty;
            textBox4.Text = String.Empty;
            textBox5.Text = String.Empty;
            textBox6.Text = String.Empty;
            textBox7.Text = String.Empty;
            textBox8.Text = String.Empty;

            this.dataGridView1.DataSource = null;
            this.dataGridView1.Rows.Clear();

            this.dataGridView2.DataSource = null;
            this.dataGridView2.Rows.Clear();

        }
        }
    }

