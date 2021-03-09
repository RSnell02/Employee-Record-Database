using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Employee_Database
{
    public partial class frmDelModEmp : Form
    {
        SqlDataAdapter adapt;
        //ID variable used in Updating and Deleting Record
        int ID = 0;
        public frmDelModEmp()
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

        private void frmDelModEmp_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'database1DataSet1.Employee' table. You can move, or remove it, as needed.
            this.employeeTableAdapter.Fill(this.database1DataSet1.Employee);
            // TODO: This line of code loads data into the 'database1DataSet1.Employee' table. You can move, or remove it, as needed.
            this.employeeTableAdapter.Fill(this.database1DataSet1.Employee);

        }

        private void DisplayData()
        {
            SqlConnection con = new SqlConnection();
            con.Open();
            DataTable dt = new DataTable();
            adapt = new SqlDataAdapter("select * from Employee", con);
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        // Clear data
        private void ClearData()
        {
            txtEmpID.Text = "";
            txtEmpAddress.Text = "";
            txtEmpCity.Text = "";
            txtEmpFName.Text = "";
            txtEmpLName.Text = "";
            txtEmpPhone.Text = "";
        }

        // Update Employee Record
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string cn_string = Properties.Settings.Default.Database1ConnectionString;
            string Query = "update employ set EmpID ='" + this.txtEmpID.Text + "' , EmpFName = '" + this.txtEmpFName.Text + "' , EmpLName = '" + this.txtEmpLName.Text + "' , EmpAddress = '" + this.txtEmpAddress.Text + "' , EmpCity = '" + this.txtEmpCity.Text + "' , EmpPhone = '" + this.txtEmpPhone.Text + "';";

            SqlConnection Con = new SqlConnection(cn_string);
            SqlCommand Command = new SqlCommand(Query, Con);
            SqlDataReader Reader;
            Con.Open();
            Reader = Command.ExecuteReader();
            MessageBox.Show("Record Updated Successfully");
            Con.Close();
            DisplayData();
            ClearData();
        }   // End btnUpdate_Click

        // Delete Employee Record
        private void btnDelete_Click(object sender, EventArgs e)
        {
            string cn_string = Properties.Settings.Default.Database1ConnectionString;
            string Query = "delete from item where EmpID='" + this.txtEmpID.Text + "';";
            SqlConnection Con = new SqlConnection(cn_string);
            SqlCommand Command = new SqlCommand(Query, Con);
            SqlDataReader Reader;
            Con.Open();
            Reader = Command.ExecuteReader();
            MessageBox.Show("Employee's data successfully deleted!");
            DisplayData();
            ClearData();
        }   // End btnDelete_Click


        //Refreshes the table
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            string cn_string = Properties.Settings.Default.Database1ConnectionString;
            // Refreshes table and fills table
            string Query = "select * from employee;";
            SqlConnection Con = new SqlConnection(cn_string);
            SqlCommand Command = new SqlCommand(Query, Con);
            SqlDataAdapter Adapter = new SqlDataAdapter();
            Adapter.SelectCommand = Command;
            DataTable dTable = new DataTable();
            Adapter.Fill(dTable);
            dataGridView1.DataSource = dTable;
        }   // End btnRefresh_Click
    }   // End Class
}   // End Namespace
