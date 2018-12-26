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

public partial class UI_ClientEditUIPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            FillClientIdDropDownList();
        }
    }

    protected void updateButton_Click(object sender, EventArgs e)
    {
        string message = null;

        if (!CheckInputValues())
        {
            return;
        }

        Client clientObject = new Client();
        clientObject.Id = clientIdDropDownList.Text;
        clientObject.CompanyName = companyNameTextBox.Text;
        clientObject.ContactPerson = contactPersonTextBox.Text;
        clientObject.ContactDate = Convert.ToDateTime(contactDateTextBox.Text);
        clientObject.Address = addressTextBox.Text;
        clientObject.PhoneNo = phoneNoTextBox.Text;
        clientObject.Email = emailTextBox.Text;

        try
        {
            ClientManager clientManagerObject = new ClientManager();
            message = clientManagerObject.UpdateClient(clientObject);
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

    protected void clientIdDropDownList_DataBound(object sender, EventArgs e)
    {
        //Inserting an item in the 0 index of the DDL named "-Select-"
        //which will navigate the user to select an item
        clientIdDropDownList.Items.Insert(0, new ListItem("-Select-"));
    }

    /// <summary>
    /// Loads client's information when a client is selected from dropdownlist 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void clientIdDropDownList_SelectedIndexChanged(object sender, EventArgs e)
    {
        //When client change this information is not valid 
        companyNameTextBox.Text = "";
        contactPersonTextBox.Text = "";
        contactDateTextBox.Text = "";
        addressTextBox.Text = "";
        phoneNoTextBox.Text = "";
        emailTextBox.Text = "";
        errorLabel.Text = "";
        successLabel.Text = "";

        if (clientIdDropDownList.SelectedIndex.Equals(0))  // Item in index 0 is "-Select-" and not a valid item. So must not use
        {
            return;
        }

        try
        {
            ClientManager clientManagerObject = new ClientManager();
            Client clientObject = clientManagerObject.SelectClient(clientIdDropDownList.SelectedItem.Value);
            companyNameTextBox.Text = clientObject.CompanyName;
            contactPersonTextBox.Text = clientObject.ContactPerson;
            contactDateTextBox.Text = clientObject.ContactDate.ToString();
            addressTextBox.Text = clientObject.Address;
            phoneNoTextBox.Text = clientObject.PhoneNo;
            emailTextBox.Text = clientObject.Email;
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
    /// Check all input value for validation
    /// </summary>
    /// <returns>if all input valid returns true else false</returns>
    private bool CheckInputValues()
    {
        successLabel.Text = "";
        string temp = DataValidator.EmailValidator(emailTextBox.Text);

        if (clientIdDropDownList.SelectedIndex.Equals(0))  // Item in index 0 is "-Select-" and not a valid item. So must not use
        {
            errorLabel.Text = "Please select a client";
            return false;
        }
        else if (DataValidator.IsEmpty(companyNameTextBox.Text))
        {
            errorLabel.Text = "Please enter company name.";
            return false;
        }
        else if (DataValidator.IsNumber(companyNameTextBox.Text))
        {
            errorLabel.Text = "Please enter valid company name";
            return false;
        }
        else if (DataValidator.IsEmpty(contactPersonTextBox.Text))
        {
            errorLabel.Text = "Please enter contact person's name";
            return false;
        }
        else if (DataValidator.IsNumber(contactPersonTextBox.Text))
        {
            errorLabel.Text = "Please enter valid contact person's name";
            return false;
        }
        else if (DataValidator.IsEmpty(contactDateTextBox.Text))
        {
            errorLabel.Text = "Please enter contact date";
            return false;
        }
        else if (!DataValidator.IsDate(contactDateTextBox.Text))
        {
            errorLabel.Text = "Please enter valid contact date";
            return false;
        }
        else if (DataValidator.IsEmpty(addressTextBox.Text))
        {
            errorLabel.Text = "Please enter address";
            return false;
        }
        else if (DataValidator.IsNumber(addressTextBox.Text))
        {
            errorLabel.Text = "Please enter valid address";
            return false;
        }
        else if (DataValidator.IsEmpty(phoneNoTextBox.Text))
        {
            errorLabel.Text = "Please enter client phone number";
            return false;
        }
        else if (!DataValidator.IsNumber(phoneNoTextBox.Text))
        {
            errorLabel.Text = "Please enter valid phone number";
            return false;
        }
        else if (temp.Length != 0)
        {
            errorLabel.Text = temp;
            return false;
        }
        else
        {
            return true;
        }
    }

    /// <summary>
    /// Fills client droupdownlist
    /// </summary>
    private void FillClientIdDropDownList()
    {
        try
        {
            ClientManager clientManagerObject = new ClientManager();
            clientIdDropDownList.DataSource = clientManagerObject.GetAllClient();
            clientIdDropDownList.DataTextField = "CompanyName";
            clientIdDropDownList.DataValueField = "ID";
            clientIdDropDownList.DataBind();

            if (clientManagerObject.GetAllClient().Count == 0)
            {
                errorLabel.Text = "No client is created yet. Can't edit client information";
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

}
