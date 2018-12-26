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

public partial class UI_EmployeeUIPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        LoadInitialData();
        if (!Page.IsPostBack)
        {
            successMessageLabel.Text = Request.QueryString["message"];
        }
    }

    protected void saveButton_Click(object sender, EventArgs e)
    {
        if (!CheckInputValues())
        {
            return;
        }

        Response.Redirect("EmployeeSaveInfoUIPage.aspx? "
        + "&Id=" + Server.UrlEncode(this.employeeIdTextBox.Text)
        + "&Name=" + Server.UrlEncode(this.employeeNameTextBox.Text)
        + "&Address=" + Server.UrlEncode(this.employeeAddressTextBox.Text)
        + "&Phone=" + Server.UrlEncode(this.employeePhoneTextBox.Text)
        + "&Email=" + Server.UrlEncode(this.employeeEmailTextBox.Text)
        + "&JoinDate=" + Server.UrlEncode(this.employeeJoindateTextBox.Text)
        + "&DOB=" + Server.UrlEncode(employeeDOBTextBox.Text));
        LoadInitialData();
    }
    
    /// <summary>
    /// Fills up employeeGridView
    /// </summary>
    private void LoadInitialData()
    {
        try
        {
            EmployeeGateway employeeGateObj = new EmployeeGateway();
            employeeGridView.DataSource = employeeGateObj.GetEmployeeTable();
            employeeGridView.DataBind();
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
    /// Checks input value
    /// </summary>
    /// <returns></returns>
    private bool CheckInputValues()
    {
        successMessageLabel.Text = "";
        string temp = DataValidator.EmailValidator(employeeEmailTextBox.Text);
        if (DataValidator.IsEmpty(employeeIdTextBox.Text))
        {
            errorMessageLabel.Text = "Please enter employee Id.";
            return false;
        }
        else if (DataValidator.IsEmpty(employeeNameTextBox.Text))
        {
            errorMessageLabel.Text = "Please enter employee name.";
            return false;
        }
        else if (DataValidator.IsNumber(employeeNameTextBox.Text))
        {
            errorMessageLabel.Text = "Please enter valid employee name";
            return false;
        }
        else if (DataValidator.IsEmpty(employeeAddressTextBox.Text))
        {
            errorMessageLabel.Text = "Please enter employee address";
            return false;
        }
        else if (DataValidator.IsNumber(employeeAddressTextBox.Text))
        {
            errorMessageLabel.Text = "Please enter valid employee address";
            return false;
        }
        else if (DataValidator.IsEmpty(employeePhoneTextBox.Text))
        {
            errorMessageLabel.Text = "Please enter employee phone number";
            return false;
        }
        else if (!DataValidator.IsNumber(employeePhoneTextBox.Text))
        {
            errorMessageLabel.Text = "Please enter valid phone number";
            return false;
        }
        else if (temp.Length != 0)
        {
            errorMessageLabel.Text = temp;
            return false;
        }
        else if (DataValidator.IsEmpty(employeeJoindateTextBox.Text))
        {
            errorMessageLabel.Text = "Please enter Joining date";
            return false;
        }
        else if (!DataValidator.IsDate(employeeJoindateTextBox.Text))
        {
            errorMessageLabel.Text = "Please enter valid joining date";
            return false;
        }
        else if (DataValidator.IsEmpty(employeeDOBTextBox.Text))
        {
            errorMessageLabel.Text = "Please enter date of birth";
            return false;
        }
        else if (!DataValidator.IsDate(employeeDOBTextBox.Text))
        {
            errorMessageLabel.Text = "Please enter valid date of birth";
            return false;
        }
        else
        {
            return true;
        }
    }
}
