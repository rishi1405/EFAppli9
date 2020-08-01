using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
namespace EFAppli9
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        private DataTable GetEmployeeData()
        {
            EmployeeDBContext employeeDBContext = new EmployeeDBContext();
            List<Employee> employees = employeeDBContext.Employees.ToList();

            DataTable dataTable = new DataTable();
            DataColumn[] columns = { new DataColumn("EmployeeID"),
                                 new DataColumn("FirstName"),
                                 new DataColumn("LastName"),
                                 new DataColumn("Gender")};

            dataTable.Columns.AddRange(columns);

            foreach (Employee employee in employees)
            {
                DataRow dr = dataTable.NewRow();
                dr["EmployeeID"] = employee.EmployeeID;
                dr["FirstName"] = employee.FirstName;
                dr["LastName"] = employee.LastName;
                dr["Gender"] = employee.Gender;

                dataTable.Rows.Add(dr);
            }

            return dataTable;
        }

        private DataTable GetEmployeeDataIncludingContactDetails()
        {
            EmployeeDBContext employeeDBContext = new EmployeeDBContext();
            List<Employee> employees = employeeDBContext.Employees
                .Include("EmployeeContactDetail").ToList();

            DataTable dataTable = new DataTable();
            DataColumn[] columns = { new DataColumn("EmployeeID"),
                                 new DataColumn("FirstName"),
                                 new DataColumn("LastName"),
                                 new DataColumn("Gender"),
                                 new DataColumn("Email"),
                                 new DataColumn("Mobile"),
                                 new DataColumn("LandLine") };
            dataTable.Columns.AddRange(columns);

            foreach (Employee employee in employees)
            {
                DataRow dr = dataTable.NewRow();
                dr["EmployeeID"] = employee.EmployeeID;
                dr["FirstName"] = employee.FirstName;
                dr["LastName"] = employee.LastName;
                dr["Gender"] = employee.Gender;
                dr["Email"] = employee.EmployeeContactDetail.Email;
                dr["Mobile"] = employee.EmployeeContactDetail.Mobile;
                dr["LandLine"] = employee.EmployeeContactDetail.LandLine;

                dataTable.Rows.Add(dr);
            }

            return dataTable;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (checkBoxIncludeContactDetails.Checked)
            {
                GridView1.DataSource = GetEmployeeDataIncludingContactDetails();
            }
            else
            {
                GridView1.DataSource = GetEmployeeData();
            }
            GridView1.DataBind();
        }
    }
}