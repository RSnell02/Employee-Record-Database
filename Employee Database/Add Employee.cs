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

namespace Employee_Database
{
    public partial class frmAddEmp : Form
    {
        SqlDataAdapter adapt;
        //ID variable used in Updating and Deleting Record
        int ID = 0;
        public frmAddEmp()
        {
            InitializeComponent();
        }

        // Returns to tha Main Menu
        private void btnMain_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmMain main = new frmMain();
            main.ShowDialog();
        }   // End btnMain_Click

        private void frmAddEmp_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'database1DataSet1.Employee' table. You can move, or remove it, as needed.
            this.employeeTableAdapter.Fill(this.database1DataSet1.Employee);
        }   // End frmAddEmp_Load

        // Display Data in DataGridView
        private void DisplayData()
        {
            string cn_string = Properties.Settings.Default.Database1ConnectionString;

            SqlConnection con = new SqlConnection(cn_string);
            con.Open();
            DataTable dt = new DataTable();
            adapt = new SqlDataAdapter("Select * from Employee", con);
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }   // End DisplayData

        // Clear Data
        private void ClearData()
        {
            txtEmpFName.Text = "";
            txtEmpLName.Text = "";
            txtEmpPhone.Text = "";
            txtEmpAddress.Text = "";
            txtEmpCity.Text = "";
            ID = 0;
        }

        // Add new employee data
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtEmpFName.Text != "" && txtEmpLName.Text != "" && txtEmpAddress.Text != "" && txtEmpAddress.Text != "" && txtEmpPhone.Text != "")
            {
                string cn_string = Properties.Settings.Default.Database1ConnectionString;

                SqlConnection con = new SqlConnection(cn_string);
                if (con.State != ConnectionState.Open) con.Open();

                string empID = txtEmpNum.Text;
                string empFName = txtEmpFName.Text;
                string empLName = txtEmpLName.Text;
                string empCity = txtEmpCity.Text;
                string empAddress = txtEmpAddress.Text;
                string empPhone = txtEmpPhone.Text;

                string Query = "INSERT INTO EMPLOYEE(EmpID, EmpFName, EmpLName, EmpAddress, EmpCity, EmpPhone) values('" + empID + "', '" + empFName + "', '" + empLName + "', '" + empCity + "', '" + empAddress + "', '" + empPhone + "')";
                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Employee record added successfully");
                DisplayData();
                ClearData();
            }   // End if
            else
            {
                MessageBox.Show("Please Provice Details!");
            }
        }
    }   // End Class
}   // End Namespace
