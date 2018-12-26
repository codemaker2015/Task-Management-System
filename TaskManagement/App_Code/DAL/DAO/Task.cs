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
/// This class is responsible for Task related data
/// </summary>
public class Task
{
	public Task()
	{
		
	}

    private string id;
    private string name;
    private string description;
    private string project_Title;
    private DateTime startDate;
    private DateTime estimatedTime;
    private string employee_AssignTo;
    private string employee_AssigenBy;
    private string project_Id;
    private string employee_Id;
    private string taskStatus;
   
    public string Id
    {
        set { id = value; }
        get { return id; }
    }

    public string Name
    {
        set { name = value; }
        get { return name; }
    }

    public string Description
    {
        set { description = value; }
        get { return description; }

    }

    public string Project_Title
    {
        set { project_Title = value; }
        get { return project_Title; }
    }

    public DateTime StartDate
    {
        set { startDate = value; }
        get { return startDate; }
    }

    public DateTime EstimatedTime
    {
        set { estimatedTime = value; }
        get { return estimatedTime; }
    }

    public string Employee_AssignTo
    {
        set { employee_AssignTo = value; }
        get { return employee_AssignTo; }
    }

    public string Employee_AssigenBy
    {
        set { employee_AssigenBy = value; }
        get { return employee_AssigenBy; }
    }

    public string Project_Id
    {
        set { project_Id = value; }
        get { return project_Id; }
    }

    public string Employee_Id
    {
        set { employee_Id = value; }
        get { return employee_Id; }
    }

    public string TaskStatus
    {
        set { taskStatus = value; }
        get { return taskStatus; }
    }

}
