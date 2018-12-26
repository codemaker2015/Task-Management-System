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
using System.Collections.Generic;
using System.Data.SqlClient;

public partial class UI_TaskUIPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            LoadProjectDropDownList();
        }
    }

    protected void DropDownListProject_SelectedIndexChanged1(object sender, EventArgs e)
    {
        //When project changes this information is no longer valid. so removed
        errorLabel.Text = "";
        taskDropDownList.Items.Clear();
        employeeNameTextBox.Text = "";
        employeeIdTextBox.Text = "";
        descriptionTextBox.Text = "";
        startDateTextBox.Text = "";
        estimatedDateTextBox.Text = "";
        allCommentTextBox.Text = "";

        if (projectDropDownList.SelectedIndex.Equals(0))  // Item in index 0 is "-Select-" and not a valid item. So must not use
        {
            return;
        }

        try
        {
            TaskManager taskManagerObj = new TaskManager();
            taskDropDownList.DataSource = taskManagerObj.GetAllTasksOfAProject(projectDropDownList.SelectedItem.Value);
            taskDropDownList.DataTextField = "Name";
            taskDropDownList.DataValueField = "ID";
            taskDropDownList.DataBind();

            if (taskManagerObj.GetAllTasksOfAProject(projectDropDownList.SelectedItem.Value).Count == 0)
            {
                errorLabel.Text = "This project has no task";
            }
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

    protected void taskDropDownList_SelectedIndexChanged(object sender, EventArgs e)
    {
        errorLabel.Text = "";

        if (taskDropDownList.SelectedIndex.Equals(0))  // Item in index 0 is "-Select-" and not a valid item. So must not use
        {
            employeeNameTextBox.Text = "";
            employeeIdTextBox.Text = "";
            descriptionTextBox.Text = "";
            startDateTextBox.Text = "";
            estimatedDateTextBox.Text = "";
            allCommentTextBox.Text = "";
            return;
        }
        LoadTaskInfo();
        LoadAllComments();
    }

    protected void projectDropDownList_DataBound(object sender, EventArgs e)
    {
        //Inserting an item in the 0 index of the DDL named "-Select-"
        //which will navigate the user to select an item
        projectDropDownList.Items.Insert(0, new ListItem("-Select-"));
    }
    
    protected void taskDropDownList_DataBound(object sender, EventArgs e)
    {
        //Inserting an item in the 0 index of the DDL named "-Select-"
        //which will navigate the user to select an item
        taskDropDownList.Items.Insert(0, new ListItem("-Select-"));
    }

    protected void AllCommentTextBox_TextChanged(object sender, EventArgs e)
    {

    }

    /// <summary>
    /// Loads all comments of the task in allCommentTextBox
    /// </summary>
    private void LoadAllComments()
    {
        try
        {
            string allComments = null;
            CommentManager commentManagerObject = new CommentManager();
            List<Comment> commentList = commentManagerObject.GetCommentsOfTheTask(taskDropDownList.SelectedItem.Value);
            foreach (Comment commentObj in commentList)
            {
                allComments += commentObj.CommentEmployeeName + " : ";
                allComments += commentObj.Comments + ".   \n on ";
                allComments += commentObj.CommentDate + ".  \n";
            }
            allCommentTextBox.Text = allComments;
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

    /// <summary>
    /// Fills up projectDropDownList DDL
    /// </summary>
    private void LoadProjectDropDownList()
    {
        try
        {
            ProjectManager projectManagerObject = new ProjectManager();
            projectDropDownList.DataSource = projectManagerObject.GetAllOpenProjects();
            projectDropDownList.DataTextField = "Title";
            projectDropDownList.DataValueField = "ID";
            projectDropDownList.DataBind();
            if (projectManagerObject.GetAllOpenProjects().Count == 0)
            {
                errorLabel.Text = "No project is created yet";
            }
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

    /// <summary>
    /// Loads task information in the page
    /// </summary>
    private void LoadTaskInfo()
    {
        try
        {
            TaskManager taskManagerObj = new TaskManager();
            Task taskObj = taskManagerObj.SelectTask(taskDropDownList.SelectedItem.Value);
            employeeNameTextBox.Text = taskObj.Employee_AssignTo;
            employeeIdTextBox.Text = taskObj.Employee_Id;
            descriptionTextBox.Text = taskObj.Description;
            startDateTextBox.Text = Convert.ToString(taskObj.StartDate);
            estimatedDateTextBox.Text = Convert.ToString(taskObj.EstimatedTime);
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
