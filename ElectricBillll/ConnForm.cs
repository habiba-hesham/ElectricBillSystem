using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ElectricBillll
{
    public partial class ConnForm : Form
    {
        string ordb = "Data Source=ORCL;User Id=hr;Password=hr;";
        OracleConnection conn;

        public ConnForm()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

       
        private void button1_Click(object sender, EventArgs e)
        {
            //show
            textBox2.Clear();
            comboBox1.Items.Clear();
            comboBox2.Items.Clear();
            comboBox3.Items.Clear();
            comboBox4.Items.Clear();
            comboBox5.Items.Clear();

            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select BILL_ID , BILL_PRICE , BILL_DATE ,ADMIN_ID from bill where BILL_CUST_ID =:id";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("id", textBox1.Text.ToString());
            OracleDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox3.Items.Add(dr[0]);
                comboBox1.Items.Add(dr[1]);
                comboBox2.Items.Add(dr[2]);
                comboBox4.Items.Add(dr[3]);
            }
           
            dr.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //insert
           
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "insert into bill values (:billid,:customerid,:billprice,:billdate,:billstatus,:adminid)" ;

            cmd.Parameters.Add("bill id", comboBox3.Text);
            cmd.Parameters.Add("customer id", textBox1.Text);
            cmd.Parameters.Add("bill price", comboBox1.Text);
            cmd.Parameters.Add("bill date", DateTime.Now);
            cmd.Parameters.Add("bill status", "unpaid");
            cmd.Parameters.Add("admin id", comboBox4.Text);
            
            int r = cmd.ExecuteNonQuery();
            if (r != -1)
            {
                comboBox3.Items.Add(comboBox3.Text);
                comboBox1.Items.Add(comboBox1.Text);
                comboBox4.Items.Add(comboBox4.Text);

                MessageBox.Show("NEW BILL IS ADDED");

                comboBox3.Text = "";
                textBox1.Text = "";
                comboBox1.Text = "";
                comboBox4.Text = "";

            }


        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            conn = new OracleConnection(ordb);
            conn.Open();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox2.Clear();
            comboBox1.Items.Clear();
            comboBox2.Items.Clear();
            comboBox3.Items.Clear();
            comboBox4.Items.Clear();
            comboBox5.Items.Clear();
            int price;

            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;

            cmd.CommandText = "GetTotalBill";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("id", textBox1.Text);
            cmd.Parameters.Add("price", OracleDbType.Int32, ParameterDirection.Output);

            cmd.ExecuteNonQuery();
            try
            {
                price = Convert.ToInt32(cmd.Parameters["price"].Value.ToString());
                textBox2.Text = price.ToString();

            }
            catch {
                price = 0;
            }
           
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox2.Clear();
            comboBox1.Items.Clear();
            comboBox2.Items.Clear();
            comboBox3.Items.Clear();
            comboBox4.Items.Clear();
            comboBox5.Items.Clear();

            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;

            cmd.CommandText = "GetPrices";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("id", textBox1.Text);
            cmd.Parameters.Add("price", OracleDbType.RefCursor, ParameterDirection.Output);

            OracleDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                comboBox5.Items.Add(reader[0]);
            }
            
            reader.Close();
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MainForm m = new MainForm();
            m.Show();
            this.Hide();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
