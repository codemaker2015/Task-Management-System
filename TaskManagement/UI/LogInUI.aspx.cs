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
using System.Data.SqlClient;


public partial class UI_LogInUI : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (!Page.IsPostBack)
        {
            Session.Abandon();
            LoadUserId();
        }
    }

    protected void logInButton_Click(object sender, EventArgs e)
    {
        string userType = null;
        try
        {
            UserManager userManagerObject = new UserManager();
            userType = userManagerObject.CheckUserIdAndPassword(employeeIdDropDownList.SelectedItem.Value, passwordTextBox.Text);
        }
        catch (SqlException sqlExceptionObj)
        {
            Label4.Text = sqlExceptionObj.Message;
        }
        catch (Exception exceptionObj)
        {
            Label4.Text = exceptionObj.Message;
        }
        

        switch (userType)
        { 
            case "Admin":
                Session["userID"] = employeeIdDropDownList.SelectedItem.Value;
                Response.Redirect("AdimHomePage.aspx");
                break;
            case "Normal":
                Session["userID"] = employeeIdDropDownList.SelectedItem.Value;
                Response.Redirect("NormalUserUIPage.aspx");
                break;
            default:
                Label4.Text = " Invalid Password! Please retype the Password";
                break;
        }
    }

    /// <summary>
    /// Load employeeIdropDownList with existing users
    /// </summary>
    private void LoadUserId()
    {
        try
        {
            UserManager userManagerObject = new UserManager();
            employeeIdDropDownList.DataSource = userManagerObject.GetUserTable();
            employeeIdDropDownList.DataTextField = "user_Employee_Id";
            employeeIdDropDownList.DataValueField = "user_Employee_Id";
            employeeIdDropDownList.DataBind();
        }
        catch (SqlException sqlExceptionObj)
        {
            Label4.Text = sqlExceptionObj.Message;
        }
        catch (Exception exceptionObj)
        {
            Label4.Text = exceptionObj.Message;
        }
    }
}
