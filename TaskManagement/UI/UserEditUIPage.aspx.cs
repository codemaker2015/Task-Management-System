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
using System.Collections.Generic;
using System.Data.SqlClient;

public partial class UI_UserEditUIPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            LoadUserId();
        }
    }

    protected void userDropDownList_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (userDropDownList.SelectedIndex.Equals(0))  // Item in index 0 is "-Select-" and not a valid item. So must not use
        {
            errorLabel.Text = "";
            successLabel.Text = "";
            userCurrentTypeLabel.Text = "";
            userNameLabel.Text = "";
            changeUserTypeButton.Text = "Change Type";
            return;
        }
        try
        {
            UserManager userManagerObject = new UserManager();
            EmployeeManager employeeManagerObject = new EmployeeManager();
            Employee employeeObject = employeeManagerObject.SelectEmployee(userDropDownList.SelectedItem.Value);
            userNameLabel.Text = employeeObject.Name;
            if (userManagerObject.IsAdmin(userDropDownList.SelectedItem.Value))
            {
                userCurrentTypeLabel.Text = "Admin";
                changeUserTypeButton.Text = "Change to Normal user ";
            }
            else
            {
                userCurrentTypeLabel.Text = "Normal";
                changeUserTypeButton.Text = "Change to Admin user ";
            }
        }
        catch (SqlException sqlExceptionObj)
        {
            errorLabel.Text = sqlExceptionObj.Message;
        }
        catch (Exception exceptionObj)
        {
            errorLabel.Text = exceptionObj.Message;
        }
    }

    protected void changeUserTypeButton_Click(object sender, EventArgs e)
    {
        successLabel.Text = "";
        if (userDropDownList.SelectedIndex.Equals(0))  // Item in index 0 is "-Select-" and not a valid item. So must not use
        {
            errorLabel.Text = "Select a user";
            return;
        }
        else if (userDropDownList.SelectedItem.Value == Session["userID"].ToString())
        {
            errorLabel.Text = "Admin can't edit his own user type";
            return;
        }

        try
        {
            User userObj = new User();
            UserManager userManagerObject = new UserManager();

            if (userManagerObject.IsAdmin(userDropDownList.SelectedItem.Value))
            {
                userObj.UserType = "Normal";
            }
            else
            {
                userObj.UserType = "Admin";
            }

            userObj.UserId = userDropDownList.SelectedItem.Value;
            string message = userManagerObject.EditUserType(userObj);
            successLabel.Text = message;

            userDropDownList.Items.Clear();
            LoadUserId();
            userNameLabel.Text = "";
            userCurrentTypeLabel.Text = "";
            changeUserTypeButton.Text = "Change Type";
            errorLabel.Text = "";
        }
        catch (OnlyOneAdminException onlyOneAdminExceptionObject)
        {
            errorLabel.Text = onlyOneAdminExceptionObject.Message;
        }
        catch (SqlException sqlExceptionObj)
        {
            errorLabel.Text = sqlExceptionObj.Message;
        }
        catch (Exception exceptionObj)
        {
            errorLabel.Text = exceptionObj.Message;
        }
    }

    protected void userDropDownList_DataBound(object sender, EventArgs e)
    {
        //Inserting an item in the 0 index of the DDL named "-Select-"
        //which will navigate the user to select an item
        userDropDownList.Items.Insert(0, new ListItem("-Select-"));
    }

    /// <summary>
    /// Load employeeIdropDownList with existing users
    /// </summary>
    private void LoadUserId()
    {
        try
        {
            UserManager userManagerObject = new UserManager();
            userDropDownList.DataSource = userManagerObject.GetUserTable();
            userDropDownList.DataTextField = "user_Employee_Id";
            userDropDownList.DataValueField = "user_Employee_Id";
            userDropDownList.DataBind();
        }
        catch (SqlException sqlExceptionObj)
        {
            errorLabel.Text = sqlExceptionObj.Message;
        }
        catch (Exception exceptionObj)
        {
            errorLabel.Text = exceptionObj.Message;
        }
    }

}
