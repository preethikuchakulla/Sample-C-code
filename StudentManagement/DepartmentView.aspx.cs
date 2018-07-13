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
    public partial class DepartmentView : System.Web.UI.Page
    {
        #region Page Events
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.GetDepartment();
            }
        }
        #endregion

        #region Bindings
        public void GetDepartment()
        {
            DepartmentBS departmentBS = new DepartmentBS();
            ClsDepartmentDetailResult result = departmentBS.ProcessRead();

            if (result.Success)
            {
                gvDepartment.DataSource = result.departments;
                gvDepartment.DataBind();
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('" + result.ErrorDesc + "');", true);
            }
        }
        #endregion

        #region Grid Event
        protected void gvDepartment_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Delete")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);

                GridViewRow row = gvDepartment.Rows[rowIndex];

                int Id = Convert.ToInt32((row.FindControl("lblId") as Label).Text);
                string name = (row.FindControl("lblName") as Label).Text;

                DepartmentBS departmentBS = new DepartmentBS();
                ClsDepartmentResult result = departmentBS.ProcessRemove(new DepartmentBO()
                {
                    Id = Id,
                    Name = name
                });

                if (result.Success)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Deparment Name: " + name + "');", true);
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
            var Name = txtDepartment.Text;
            DepartmentBS departmentBS = new DepartmentBS();
            ClsDepartmentResult result = departmentBS.ProcessSave(new DepartmentBO()
            {
                Name = Name
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