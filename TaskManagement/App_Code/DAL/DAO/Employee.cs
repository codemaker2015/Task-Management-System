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
/// This class is responsible for Employee related data
/// </summary>
public class Employee
{
	public Employee()
	{
		
	}

    private string id;
    private string name;
    private string address;
    private string phoneNo;
    private string email;
    private DateTime joiningDate;
    private DateTime dOB;


    public DateTime DOB
    {
        set { dOB = value; }
        get { return dOB; }
    }

    public string ID
    {
        set { id = value; }
        get { return id; }
    }

    public string Name
    {
        set { name = value; }
        get { return name; }
    }

    public string Address
    {
        set { address = value; }
        get { return address; }
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

    public DateTime JoiningDate
    {
        set { joiningDate = value; }
        get { return joiningDate; }
    }

}
