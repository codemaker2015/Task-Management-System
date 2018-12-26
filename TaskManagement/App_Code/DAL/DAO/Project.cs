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
/// This class is responsible for project realted data
/// </summary>
public class Project
{
	public Project()
	{
		
	}

    private string id;
    private string title;
    private string description;
    private DateTime startDate;
    private DateTime estimateTime;
    private string clientId;
    private string emloyee_Id;
    private string status;

    public string ID
    {
        set { id = value; }
        get { return id; }
    }

    public string Title
    {
        set { title = value; }
        get { return title; }
    }

    public string Description
    {
        set { description = value; }
        get { return description; }
    }

    public DateTime StartDate
    {
        set { startDate = value; }
        get { return startDate; }
    }

    public DateTime EstimateTime
    {
        set { estimateTime = value; }
        get { return estimateTime; }
    }

    public string ClientId
    {
        set { clientId = value; }
        get { return clientId; }
    }

    public string Employee_Id
    {
        set { emloyee_Id = value; }
        get { return emloyee_Id; }
    }

    public string Status
    {
        set { status = value; }
        get { return status; }
    }

}
