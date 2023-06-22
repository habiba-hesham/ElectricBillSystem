using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ElectricBillll
{
    public partial class DissConnForm : Form
    {
        OracleDataAdapter adapter;
        OracleCommandBuilder builder;
        DataSet ds;

        public DissConnForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //search button
            string connstr = "User Id =hr;Password=hr;Data Source=orcl";
            string cmdstr = @"select COMPLAINT , COMP_DATE ,CUST_ID  from complaint  where COMP_ID =:id";

            adapter = new OracleDataAdapter(cmdstr, connstr);
            adapter.SelectCommand.Parameters.Add("id", textBox1.Text);

            ds = new DataSet();
            adapter.Fill(ds);

            dataGridView1.DataSource = ds.Tables[0];
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //save button
            builder = new OracleCommandBuilder(adapter);
            adapter.Update(ds.Tables[0]);
            MessageBox.Show("Data Updated");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // load info button
            string connstr = "User Id =hr;Password=hr;Data Source=orcl";
            string cmdstr = "";

            if (radioButton1.Checked)
            {
                cmdstr = "select * from admin";
            }
            else if (radioButton2.Checked)
            {
                cmdstr = "select * from bill";
            }

            adapter = new OracleDataAdapter(cmdstr, connstr);
            ds = new DataSet();
            adapter.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            MainForm MN = new MainForm();
            MN.Show();
            this.Hide();
        }

        private void DissConnForm_Load(object sender, EventArgs e)
        {

        }
    }
}
