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
/// This class is responsible for User related data
/// </summary>
public class User
{
    public User()
    {
        
    }

    private string userId;
    private DateTime createDate;
    private string userPasword;
    private string employeeId;
    private string userType;

    public string UserId
    {
        set { userId = value; }
        get { return userId; }
    }

    public DateTime CreateDate
    {
        set { createDate = value; }
        get { return createDate; }

    }

    public string UserPassword
    {
        set { userPasword = value; }
        get { return userPasword; }
    }
    
    public string EmployeeId
    {
        set { employeeId = value; }
        get { return employeeId; }
    }

    public string UserType
    {
        set { userType = value; }
        get { return userType; }
    }
}
