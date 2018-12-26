using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class UI_MasterPageNormalUser : System.Web.UI.MasterPage
{
    string employeeId = null;
    string employeeName = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            employeeId = Session["userID"].ToString();
            employeeName = GetEmployeeName();
            userNameLabel.Text = "User : " + employeeName;
            Session["userName"] = employeeName;
        }
        catch (NullReferenceException nullReferenceExceptionObject)
        {
            userNameLabel.Text = "Cant find user Id. Session time may be out. " + nullReferenceExceptionObject.Message;
           
        }

    }

    private string GetEmployeeName()
    {
        EmployeeManager employeeManagerObject = new EmployeeManager();
        Employee employeeObject = employeeManagerObject.SelectEmployee(employeeId);
        return employeeObject.Name;
    }

}
