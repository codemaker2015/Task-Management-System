using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// This class is responsible for client related data
/// </summary>
public class Client
{
	public Client()
	{

	}

    private string id;
    private string companyName;
    private string contactPerson;
    private string address;
    private DateTime contactDate;
    private string phoneNo;
    private string email;

    public string Id
    {
        set { id = value; }
        get { return id; }
    }

    public string CompanyName
    {
        set { companyName = value; }
        get { return companyName; }
    }

    public string ContactPerson
    {
        set { contactPerson = value; }
        get { return contactPerson; }
    }

    public string Address
    {
        set { address = value; }
        get { return address; }
    }

    public DateTime ContactDate
    {
        set { contactDate = value; }
        get { return contactDate; }
    }

    public string PhoneNo
    {
        set { phoneNo = value; }
        get { return phoneNo; }
    }

    public string Email
    {
        set { email = value; }
        get { return email; }
    }

}
