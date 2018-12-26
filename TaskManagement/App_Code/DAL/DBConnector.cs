using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;



/// <summary>
/// Connects with DB
/// </summary>
public class DBConnector
{
    private string sqlConnectionString = null;
    private SqlConnection sqlConn = null; 
    public DBConnector()
	{
        sqlConnectionString = ConfigurationManager.AppSettings["ConnectionString"];
        sqlConn = new SqlConnection(sqlConnectionString);
	}

    public SqlConnection GetConnection
    {
        get { return sqlConn; }
    }
}
