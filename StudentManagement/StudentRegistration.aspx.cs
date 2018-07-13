using BusinessObject;
using BusinessService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StudentManagement
{
    public partial class StudentRegistration : System.Web.UI.Page
    {
        #region Page Events
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.GetStudent();
                this.GetDepartment();
            }
        }
        #endregion

        #region Bindings
        public void GetStudent()
        {
            StudentDetailBS StudentBS = new StudentDetailBS();
            ClsStudentDetailResult result = StudentBS.ProcessRead();

            if (result.Success)
            {
                gvStudent.DataSource = result.Students;
                gvStudent.DataBind();
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('" + result.ErrorDesc + "');", true);
            }
        }

        public void GetDepartment()
        {
            DepartmentBS departmentBS = new DepartmentBS();
            ClsDepartmentDetailResult result = departmentBS.ProcessRead();

            if (result.Success)
            {
                ddlDepartment.DataSource = result.departments;
                ddlDepartment.DataTextField = "Name";
                ddlDepartment.DataValueField = "Id";
                ddlDepartment.DataBind();
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('" + result.ErrorDesc + "');", true);
            }
        }
        #endregion

        #region Grid Event
        protected void gvStudent_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Delete")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);

                GridViewRow row = gvStudent.Rows[rowIndex];

                int Id = Convert.ToInt32((row.FindControl("lblId") as Label).Text);
                string Name = (row.FindControl("lblName") as Label).Text;
                int DepartmentId = Convert.ToInt32((row.FindControl("lblDepartmentId") as Label).Text);
                string DepartmentName = (row.FindControl("lblDepartmentName") as Label).Text;

                StudentDetailBS studentDetailBS = new StudentDetailBS();
                ClsStudentResult result = studentDetailBS.ProcessRemove(new StudentDetailBO()
                {
                    Id = Id,
                    Name = Name,
                    DepartmentId = DepartmentId,
                    DepartmentName = DepartmentName
                });

                if (result.Success)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Student Name: " + Name + "');", true);
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('" + result.ErrorDesc + "');", true);
                }
            }
        }
        #endregion

        #region Events
        protected void btn_Click(object sender, EventArgs e)
        {
            var Name = txtStudent.Text;
            var DepartmentId = Convert.ToInt32(ddlDepartment.SelectedValue);

            StudentDetailBS studentDetailBS = new StudentDetailBS();
            ClsStudentResult result = studentDetailBS.ProcessSave(new BusinessObject.StudentDetailBO()
            {

                Name = Name,
                DepartmentId = DepartmentId

            });

            if (result.Success)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Inserted');", true);
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('" + result.ErrorDesc + "');", true);
            }
        }
        #endregion
    }
}