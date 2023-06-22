using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ElectricBillll
{
    public partial class crys1 : Form
    {
        CrystalReport1 CR1;
        public crys1()
        {
            InitializeComponent();
        }

        
        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
            CR1 = new CrystalReport1();

        }
        private void button1_Click(object sender, EventArgs e)
        {
            crystalReportViewer1.ReportSource = CR1;
        }

        private void crys1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            MainForm mn = new MainForm();
            mn.Show();
            this.Hide();
        }
    }
}
