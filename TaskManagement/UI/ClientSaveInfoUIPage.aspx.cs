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

public partial class UI_ClientSaveInfoUIPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this.idLabel.Text = Request.QueryString["Id"];
        this.nameLabel.Text = Request.QueryString["CompanyName"];
        this.contactPersonLabel.Text = Request.QueryString["ContactPerson"];
        this.contactDateLabel.Text = Request.QueryString["ContactDate"];
        this.addressLabel.Text = Request.QueryString["Address"];
        this.phoneLabel.Text = Request.QueryString["Phone"];
        this.emailLabel.Text = Request.QueryString["Email"];
    }

    protected void saveButton_Click(object sender, EventArgs e)
    {
        Client clientObj = null;
        ClientManager clientManagerObject = null;
        string message = null;
        try
        {
            clientObj = new Client();
            clientObj.Id = idLabel.Text;
            clientObj.CompanyName = nameLabel.Text;
            clientObj.ContactPerson = contactPersonLabel.Text;
            clientObj.ContactDate = Convert.ToDateTime(contactDateLabel.Text);
            clientObj.Address = addressLabel.Text;
            clientObj.PhoneNo = phoneLabel.Text;
            clientObj.Email = emailLabel.Text;
            clientManagerObject = new ClientManager();
            message = clientManagerObject.SaveClient(clientObj);
            Response.Redirect("ClientCreateUIPage.aspx?"+"&message="+Server.UrlEncode(message));
        }
        catch (PrimaryKeyException primaryKeyExceptionObj)
        {
            errorMessageLabel.Text = primaryKeyExceptionObj.Message;
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

    protected void cancelButton_Click(object sender, EventArgs e)
    {
        Response.Redirect("ClientCreateUIPage.aspx");
    }
}
