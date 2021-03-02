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
    public partial class frmSearchEmp : Form
    {
        public frmSearchEmp()
        {
            InitializeComponent();
        }

        // Returns to the Main Menu
        private void btnMain_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmMain main = new frmMain();
            main.ShowDialog();
        }   // End btnMain_Click

        private void frmSearchEmp_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'database1DataSet1.Employee' table. You can move, or remove it, as needed.
            this.employeeTableAdapter.Fill(this.database1DataSet1.Employee);

        }
    }   // End class
}   // End Namespace
