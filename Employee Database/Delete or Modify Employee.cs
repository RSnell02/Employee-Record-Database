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
        SqlConnection con = new SqlConnection("Data Source=.; Initial Catalog = Employee,; Integrated Security = true;");
        SqlCommand cmd;
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
            if (txtEmpID.Text != "" && txtEmpFName.Text != "" && txtEmpLName.Text != "")
            {
                cmd = new SqlCommand("update Employee set FName = @EmpFName, LName = @EmpLName, Address = @EmpAddress, City = @EmpCity, Phone = @EmpPhone where EmpID = @EmpID", con);
                con.Open();
                cmd.Parameters.AddWithValue("@EmpID", ID);
                cmd.Parameters.AddWithValue("@EmpFName", txtEmpFName.Text);
                cmd.Parameters.AddWithValue("@EmpLName", txtEmpLName.Text);
                cmd.Parameters.AddWithValue("@EmpAddress", txtEmpAddress.Text);
                cmd.Parameters.AddWithValue("@EmpCity", txtEmpCity.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Record Updated Successfully");
                con.Close();
                DisplayData();
                ClearData();
            }   // End if
            else
            {
                MessageBox.Show("Select an employee to update");
            }   // End else
        }   // End btnUpdate_Click

        // Delete Employee Record
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(ID!=0)
            {
                cmd = new SqlCommand("delete Employee where ID=@EmpID", con);
                con.Open();
                cmd.Parameters.AddWithValue("@EmpID", ID);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Employee's data successfully deleted!");
                DisplayData();
                ClearData();
            }   // End if
            else
            {
                MessageBox.Show("Please select a record to delete");
            }   // End else
        }   // End btnDelete_Click
    }   // End Class
}   // End Namespace
