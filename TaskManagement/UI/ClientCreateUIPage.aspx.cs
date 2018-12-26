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

public partial class UI_ClientCreateUIPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        LoadClientData();
        if (!Page.IsPostBack)
        {
            successLabel.Text = Request.QueryString["message"];
        }
    }

    /// <summary>
    /// Check values by DataValidator
    /// Redirect to page "ClientSaveInfoUIPage" for input value recheck by user
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void saveButton_Click(object sender, EventArgs e)
    {
        if (!CheckInputValues())
        {
            return;
        }
        Response.Redirect("ClientSaveInfoUIPage.aspx?"
        + "&Id=" + Server.UrlEncode(this.idTextBox.Text)
        + "&CompanyName=" + Server.UrlEncode(this.companyNameTextBox.Text)
        + "&ContactPerson=" + Server.UrlEncode(this.contactPersonTextBox.Text)
        + "&ContactDate=" + Server.UrlEncode(this.contactDateTextBox.Text)
        + "&Address=" + Server.UrlEncode(this.addressTextBox.Text)
        + "&Phone=" + Server.UrlEncode(this.phoneNoTextBox.Text)
        + "&Email=" + Server.UrlEncode(this.emailTextBox.Text));
    }

    /// <summary>
    /// Check all input value for validation
    /// </summary>
    /// <returns>if all input valid returns true else false</returns>
    private bool CheckInputValues()
    {
       successLabel.Text = "";
       string temp= DataValidator.EmailValidator(emailTextBox.Text);
       if (DataValidator.IsEmpty(idTextBox.Text))
       {
           errorLabel.Text = "Please enter client Id.";
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
           errorLabel.Text = "Please enter valid contact person name";
           return false;
       }
       else if (DataValidator.IsEmpty(contactDateTextBox.Text))
       {
           errorLabel.Text = "Please enter contact date";
           return false;
       }
       else if (!DataValidator.IsDate(contactDateTextBox.Text))
       {
           errorLabel.Text = "Please enter valid date";
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
           errorLabel.Text = "Please enter address";
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
    /// Loads all clients information in dataGridView
    /// </summary>
    private void LoadClientData()
    {
        try
        {
            ClientManager clientManagerObject = new ClientManager();
            clientGridView.DataSource = clientManagerObject.GetClientTable();
            clientGridView.DataBind();
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
