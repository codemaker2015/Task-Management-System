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
/// PrimaryKeyException: user define exception
/// Exception occurs when trying to insert data into DB with existing primary key
/// </summary>
public class PrimaryKeyException:ApplicationException
{
	public PrimaryKeyException(Exception e):base("ID already exist.Try again with Different ID",e)
	{
		
	}
}
