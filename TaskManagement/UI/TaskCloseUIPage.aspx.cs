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

public partial class UI_TaskStatusEditUIPage : System.Web.UI.Page
{
    Task taskObj = null;
    string taskId = null;
    string message = null;

    protected void Page_Load(object sender, EventArgs e)
    {
        taskId = Session["taskID"].ToString();
        if (!Page.IsPostBack)
        {
            LoadTaskInfo();
        }
    }

    protected void closeTaskButton_Click(object sender, EventArgs e)
    {
        try
        {
            TaskManager taskManagerObject = new TaskManager();
            taskObj = taskManagerObject.SelectTask(taskId);
            taskObj.TaskStatus = "Close";
            message = taskManagerObject.CloseTask(taskObj);
            SaveClosingComment();
            Response.Redirect("AdimHomePage.aspx?" + "&message=" + Server.UrlEncode(message));
        }
        catch (SqlException sqlExceptionObj)
        {
            errorLabel.Text = sqlExceptionObj.Message;
        }
        catch (Exception exceptionObj)
        {
            errorLabel.Text = exceptionObj.Message;
        }
    }

    private void LoadTaskInfo()
    {
        try
        {
            TaskManager taskManagerObj = new TaskManager();
            taskObj = taskManagerObj.SelectTask(taskId);
            TaskIdLabel.Text = taskObj.Id;
            TaskNameLabel.Text = taskObj.Name;
            taskStatusLabel.Text = taskObj.TaskStatus;
        }
        catch (SqlException sqlExceptionObj)
        {
            errorLabel.Text = sqlExceptionObj.Message;
        }
        catch (Exception exceptionObj)
        {
            errorLabel.Text = exceptionObj.Message;
        }
    }

    private void SaveClosingComment()
    {
        try
        {
            Comment commentObj = new Comment();
            commentObj.CommentTaskId = taskObj.Id;
            commentObj.CommentEmployeeName = taskObj.Employee_AssignTo;
            commentObj.CommentEmployeeId = taskObj.Employee_Id;
            commentObj.CommentDate = System.DateTime.Now;
            commentObj.Comments = "This task is colsed by admin :" + taskObj.Employee_AssignTo;
            CommentManager commentManagerObject = new CommentManager();
            commentManagerObject.SaveComment(commentObj);
        }
        catch (PrimaryKeyException primaryKeyExceptionObj)
        {
            errorLabel.Text = primaryKeyExceptionObj.Message;
        }
        catch (SqlException sqlExceptionObj)
        {
            errorLabel.Text = sqlExceptionObj.Message;
        }
        catch (Exception exceptionObj)
        {
            errorLabel.Text = exceptionObj.Message;
        }
    }

}
