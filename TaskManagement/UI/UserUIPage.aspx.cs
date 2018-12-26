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

public partial class UI_UserUIPage : System.Web.UI.Page
{
    enum UserType
    {
        Admin,
        Normal
    }

    protected void Page_Load(object sender, EventArgs e)
    {


        if (!Page.IsPostBack)
        {
            FillEmployeeDropDownList();
            this.typeDropDownList.DataSource = Enum.GetNames(typeof(UserType));
            this.typeDropDownList.DataBind();

        }

    }

    protected void createButton_Click(object sender, EventArgs e)
    {
        if (!CheckInput())
        {
            successLabel.Text = "";
            return;
        }

        try
        {
            User userObj = new User();
            userObj.EmployeeId = employeeIdDropDownList.SelectedValue;
            userObj.UserPassword = passwordField.Text;
            userObj.CreateDate = System.DateTime.Now;
            userObj.UserType = typeDropDownList.SelectedItem.Text;
            UserManager userManagerObject = new UserManager();
            string msg = userManagerObject.CreateUser(userObj);
            successLabel.Text = msg + "  " + employeeIdDropDownList.SelectedItem.Text.ToString() + " is now a " + typeDropDownList.SelectedItem.Text.ToString();
            errorMessageLabel.Text = "";
            employeeIdDropDownList.Items.Clear();
            FillEmployeeDropDownList();
        }
        catch (SqlException sqlExceptionObj)
        {
            errorMessageLabel.Text = sqlExceptionObj.Message;
        }
        catch (Exception exceptionObj)
        {
            errorMessageLabel.Text = exceptionObj.Message;
        }
    }

    protected void employeeIdDropDownList_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (employeeIdDropDownList.SelectedIndex.Equals(0))
        {
            successLabel.Text = "";
            errorMessageLabel.Text = "";
            return;
        }

        successLabel.Text = employeeIdDropDownList.SelectedItem.Value.ToString();
        errorMessageLabel.Text = "";
    }

    protected void employeeIdDropDownList_DataBound(object sender, EventArgs e)
    {
        //Inserting an item in the 0 index of the DDL named "-Select-"
        //which will navigate the user to select an item
        employeeIdDropDownList.Items.Insert(0, new ListItem("-Select-"));
    }
    
    protected void typeDropDownList_DataBound(object sender, EventArgs e)
    {
        //Inserting an item in the 0 index of the DDL named "-Select-"
        //which will navigate the user to select an item
        typeDropDownList.Items.Insert(0, new ListItem("-Select-"));
    }

    /// <summary>
    /// Fills up employeeIdDropDownList DDL
    /// </summary>
    private void FillEmployeeDropDownList()
    {
        try
        {
            TaskManager taskManagerObj = new TaskManager();
            EmployeeManager employeeManagerObject = new EmployeeManager();
            employeeIdDropDownList.DataSource = employeeManagerObject.GetAllNonUserEmployees();
            employeeIdDropDownList.DataTextField = "Name";
            employeeIdDropDownList.DataValueField = "ID";
            employeeIdDropDownList.DataBind();

            if (employeeManagerObject.GetAllNonUserEmployees().Count == 0)
            {
                errorMessageLabel.Text = "All employee is a user.";
            }
        }
        catch (SqlException sqlExceptionObj)
        {
            errorMessageLabel.Text = sqlExceptionObj.Message;
        }
        catch (Exception exceptionObj)
        {
            errorMessageLabel.Text = exceptionObj.Message;
        }
    }
    
    /// <summary>
    /// Checks input values
    /// </summary>
    /// <returns>true in all input is correct else false</returns>
    private bool CheckInput()
    {
        if (employeeIdDropDownList.SelectedIndex.Equals(0))  // Item in index 0 is "-Select-" and not a valid item. So must not use
        {
            errorMessageLabel.Text = "Select an employee";
            return false;
        }
        else if (typeDropDownList.SelectedIndex.Equals(0))  // Item in index 0 is "-Select-" and not a valid item. So must not use
        {
            errorMessageLabel.Text = "Select new user type";
            return false;
        }
        else if (passwordField.Text != reTypePasswordField.Text)
        {
            errorMessageLabel.Text = "Type the same Password";
            return false;
        }
        else if (passwordField.Text == "")
        {
            errorMessageLabel.Text = "Please type a password";
            return false;
        }
        else
        {
            return true;
        }
    }

}
