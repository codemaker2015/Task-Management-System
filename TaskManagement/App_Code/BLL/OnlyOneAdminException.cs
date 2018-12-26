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
/// OnlyOneAdminException: user define exception
/// while trying to change a admin's user type
/// if admin is only admin user of a project at this point this exception occurs
/// </summary>
public class OnlyOneAdminException : ApplicationException
{
	public OnlyOneAdminException(string projectID, Exception e):base("Admin is the only Admin of project(s) '"+projectID+"'",e)
	{
        /*
         * OnlyOneAdminException: user define exception
         * while trying to change a admin's user type(Admin user to normal user)
         * if admin is only admin user of a project, his user type can not be change
         * because only admin can close task and project
         * if OnlyOneAdmin become normal type then nobody can close task and project
         * at this point this exception occurs 
         * */
    }
}
