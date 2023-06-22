using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;


namespace ElectricBillll
{
    public partial class MainForm : Form
    {
        string ordb = "Data Source=ORCL;User Id=hr;Password=hr;";
        OracleConnection conn;
        public MainForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ConnForm form2 = new ConnForm();
            form2.Show();
            this.Hide();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DissConnForm form1 = new DissConnForm();
            form1.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            crys1 cr1 = new crys1();
            cr1.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            crys2 cr2 = new crys2();
            cr2.Show();
            this.Hide();
        }
    }
}
