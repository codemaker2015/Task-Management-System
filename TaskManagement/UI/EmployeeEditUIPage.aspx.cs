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

public partial class UI_EmployeeEditUIPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            FillEmployeeIdDropDownList();
        }
    }

    protected void updateButton_Click(object sender, EventArgs e)
    {
        string message = null;

        if (!CheckInputValues())
        {
            return;
        }

        Employee employeeObject = new Employee();
        employeeObject.ID = employeeIdDropDownList.Text;
        employeeObject.Name = employeeNameTextBox.Text;
        employeeObject.Address = employeeAddressTextBox.Text;
        employeeObject.PhoneNo = employeePhoneTextBox.Text;
        employeeObject.Email = employeeEmailTextBox.Text;
        employeeObject.JoiningDate = Convert.ToDateTime(employeeJoinDateTextBox.Text);
        employeeObject.DOB = Convert.ToDateTime(employeeDOBTextBox.Text);

        try
        {
            EmployeeManager employeeManagerObject = new EmployeeManager();
            message = employeeManagerObject.UpdateEmployee(employeeObject);
        }
        catch (SqlException sqlExceptionObj)
        {
            errorLabel.Text = sqlExceptionObj.Message;
        }
        catch (Exception exceptionObj)
        {
            errorLabel.Text = exceptionObj.Message;
        }
        successLabel.Text = message;
        errorLabel.Text = "";
    }

    protected void employeeIdDropDownList_SelectedIndexChanged1(object sender, EventArgs e)
    {
        if (employeeIdDropDownList.SelectedIndex.Equals(0))  // Item in index 0 is "-Select-" and not a valid item. So must not use
        {
            employeeNameTextBox.Text = "";
            employeeAddressTextBox.Text = "";
            employeePhoneTextBox.Text = "";
            employeeEmailTextBox.Text = "";
            employeeJoinDateTextBox.Text = "";
            employeeDOBTextBox.Text = "";
            return;
        }

        try
        {
            EmployeeManager employeeManagerObject = new EmployeeManager();
            Employee employeeObject = employeeManagerObject.SelectEmployee(employeeIdDropDownList.Text);
            employeeNameTextBox.Text = employeeObject.Name;
            employeeAddressTextBox.Text = employeeObject.Address;
            employeePhoneTextBox.Text = employeeObject.PhoneNo;
            employeeEmailTextBox.Text = employeeObject.Email;
            employeeJoinDateTextBox.Text = employeeObject.JoiningDate.ToString();
            employeeDOBTextBox.Text = employeeObject.DOB.ToString();
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

    protected void employeeIdDropDownList_DataBound(object sender, EventArgs e)
    {
        //Inserting an item in the 0 index of the DDL named "-Select-"
        //which will navigate the user to select an item
        employeeIdDropDownList.Items.Insert(0, new ListItem("-Select-"));
    }

    /// <summary>
    /// Fills up employeeIdDropDownList DDL
    /// </summary>
    private void FillEmployeeIdDropDownList()
    {
        try
        {
            EmployeeManager employeeManagerObject = new EmployeeManager();
            employeeIdDropDownList.DataSource = employeeManagerObject.GetAllEmployees();
            employeeIdDropDownList.DataTextField = "ID";
            employeeIdDropDownList.DataValueField = "ID";
            employeeIdDropDownList.DataBind();
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
    
    /// <summary>
    /// Checks input value
    /// </summary>
    /// <returns></returns>
    private bool CheckInputValues()
    {
        successLabel.Text = "";

        string temp = DataValidator.EmailValidator(employeeEmailTextBox.Text);

        if (employeeIdDropDownList.SelectedIndex.Equals(0))  // Item in index 0 is "-Select-" and not a valid item. So must not use
        {
            errorLabel.Text = "Please select an employee";
            return false;
        }
        else if (DataValidator.IsEmpty(employeeNameTextBox.Text))
        {
            errorLabel.Text = "Please enter employee name.";
            return false;
        }
        else if (DataValidator.IsNumber(employeeEmailTextBox.Text))
        {
            errorLabel.Text = "Please enter valid employee name";
            return false;
        }
        else if (DataValidator.IsEmpty(employeeAddressTextBox.Text))
        {
            errorLabel.Text = "Please enter employee address";
            return false;
        }
        else if (DataValidator.IsNumber(employeeAddressTextBox.Text))
        {
            errorLabel.Text = "Please enter valid employee address";
            return false;
        }
        else if (DataValidator.IsEmpty(employeePhoneTextBox.Text))
        {
            errorLabel.Text = "Please enter employee phone number";
            return false;
        }
        else if (!DataValidator.IsNumber(employeePhoneTextBox.Text))
        {
            errorLabel.Text = "Please enter valid phone number";
            return false;
        }
        else if (temp.Length != 0)
        {
            errorLabel.Text = temp;
            return false;
        }
        else if (DataValidator.IsEmpty(employeeJoinDateTextBox.Text))
        {
            errorLabel.Text = "Please enter employee phone number";
            return false;
        }
        else if (!DataValidator.IsDate(employeeJoinDateTextBox.Text))
        {
            errorLabel.Text = "Please enter valid date";
            return false;
        }
        else if (DataValidator.IsEmpty(employeeDOBTextBox.Text))
        {
            errorLabel.Text = "Please enter employee phone number";
            return false;
        }
        else if (!DataValidator.IsDate(employeeDOBTextBox.Text))
        {
            errorLabel.Text = "Please enter valid date";
            return false;
        }
        else
        {
            return true;
        }
    }
    
}
