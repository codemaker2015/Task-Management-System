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

public partial class UI_UserRemoveUIPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }


    /* User will be selected by DDL
     * While selected a user a label will show user type
     *      if user is a non admin user all of his task will assigen to one of it projects admin
     *      if user is a admin
     *                  check if he is the only admin of all of his projects
     *                  if he is only admin of any of his project user cant be removed
     *                  if all of his project has any other admin
     *                      assigen all of his task to its appropiet admin
     * remove user from all of his projects
     * remove user 
     *      remove user_Authenticatmode form t_User
     * 
     * */




}
