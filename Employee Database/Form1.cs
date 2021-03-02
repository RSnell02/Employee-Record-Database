using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Employee_Database
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            frmHelp Help = new frmHelp();
            Help.ShowDialog();
        }

        private void btnAddEmp_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmAddEmp Add = new frmAddEmp();
            Add.ShowDialog();
        }

        private void btnSearchEmp_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmSearchEmp Search = new frmSearchEmp();
            Search.ShowDialog();
        }

        private void btnDelModEmp_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmDelModEmp DeleteModify = new frmDelModEmp();
            DeleteModify.ShowDialog();
        }
    }
}
