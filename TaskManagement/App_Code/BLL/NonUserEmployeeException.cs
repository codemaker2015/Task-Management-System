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
/// NonUserEmployeeException: User defined exception
/// when trying to get a user type(Admin / Normal) of a employee
/// if employee is not a user
/// this exception occurs
/// Note:Not all employee is a user
/// </summary>
public class NonUserEmployeeException:ApplicationException
{
    public NonUserEmployeeException(Exception e):base("Employee is not a user",e)
	{
		
	}
}
