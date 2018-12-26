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
using System.Data.SqlClient;

public partial class UI_NormalUserUIPage : System.Web.UI.Page
{
    string employeeId;
    string taskId;
    protected void Page_Load(object sender, EventArgs e)
    {
        employeeId = Session["userID"].ToString();
        FillTaskOfUser();
        FillProjectsOfUser();
    }

    protected void tasksOfUserBulletedList_Click(object sender, BulletedListEventArgs e)
    {
        ListItem listItemObj = tasksOfUserBulletedList.Items[e.Index];
        taskId = listItemObj.Value;
        Session["taskID"] = taskId;
        Response.Redirect("ViewTaskUIPage.aspx");
    }

    /// <summary>
    /// Fills up tasksOfUserBulletedList DDL
    /// </summary>
    private void FillTaskOfUser()
    {
        try
        {
            TaskManager taskmanagerObj = new TaskManager();
            numberOfTasksLabel.Text = taskmanagerObj.GetAllOpenTasksOfAUser(employeeId).Count + " task(s) " + " \nAssigened to this employee  \n";
            tasksOfUserBulletedList.DataSource = taskmanagerObj.GetAllOpenTasksOfAUser(employeeId);
            tasksOfUserBulletedList.DataTextField = "Name";
            tasksOfUserBulletedList.DataValueField = "ID";
            tasksOfUserBulletedList.DataBind();
        }
        catch (SqlException sqlExceptionObj)
        {
            Label4.Text = sqlExceptionObj.Message;
        }
        catch (Exception exceptionObj)
        {
            Label4.Text = exceptionObj.Message;
        }
    }

    /// <summary>
    /// Fills up projectListBulletedList
    /// </summary>
    private void FillProjectsOfUser()
    {
        try
        {
            ProjectManager projectManagerObject = new ProjectManager();
            numberOfProjectsLabel.Text = projectManagerObject.GetAllProjectsOfUser(employeeId).Count + "Project(s) Assigned to this employee";
            projectListBulletedList.DataSource = projectManagerObject.GetAllProjectsOfUser(employeeId);
            projectListBulletedList.DataTextField = "Title";
            projectListBulletedList.DataValueField = "ID";
            projectListBulletedList.DataBind();
        }
        catch (SqlException sqlExceptionObj)
        {
            Label4.Text = sqlExceptionObj.Message;
        }
        catch (Exception exceptionObj)
        {
            Label4.Text = exceptionObj.Message;
        }
    }

}
