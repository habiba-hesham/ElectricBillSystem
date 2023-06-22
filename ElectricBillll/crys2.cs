using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.Shared;

namespace ElectricBillll
{
    public partial class crys2 : Form
    {
        CrystalReport2 CR2;
        public crys2()
        {
            InitializeComponent();
        }

        private void crys2_Load(object sender, EventArgs e)
        {
            CR2 = new CrystalReport2();

            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MainForm mm = new MainForm();
            mm.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            CR2.SetParameterValue(0, textBox1.Text);
            //CR2.SetParameterValue(1, textBox2.Text);
            crystalReportViewer1.ReportSource = CR2;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
