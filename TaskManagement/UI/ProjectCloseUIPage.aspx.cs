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
using System.Collections.Generic;

public partial class UI_ProjectStatusEditUIPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            LoadAllOpenProject();
        }
    }

    protected void projectDropDownList_SelectedIndexChanged(object sender, EventArgs e)
    {
        clientIdLabel.Text = "";
        projectStatusLabel.Text = "";
        openTaskBulletedList.Items.Clear();
        closeProjectButton.Visible = true;
        errorLabel.Text = "";
        successLabel.Text = "";

        if (projectDropDownList.SelectedIndex.Equals(0))
        {
            return;
        }

        successLabel.Text = "";
        LoadProjectInfo();
        CheckForOpenTask();
    }

    protected void closeProjectButton_Click(object sender, EventArgs e)
    {
        if (projectDropDownList.SelectedIndex.Equals(0))
        {
            errorLabel.Text = "Please select a project";
            return;
        }
        try
        {
            Project projectObject = new Project();
            projectObject.ID = projectDropDownList.SelectedItem.Value;
            projectObject.Status = "Close";
            ProjectManager projectManagerObject = new ProjectManager();
            string message = projectManagerObject.CloseProject(projectObject);
            successLabel.Text = message;
            errorLabel.Text = "";
        }
        catch (SqlException sqlExceptionObject)
        {
            errorLabel.Text = sqlExceptionObject.Message;
        }
        catch (Exception exceptionObject)
        {
            errorLabel.Text = exceptionObject.Message;
        }
    }

    protected void projectDropDownList_DataBound(object sender, EventArgs e)
    {
        //Inserting an item in the 0 index of the DDL named "-Select-"
        //which will navigate the user to select an item
        projectDropDownList.Items.Insert(0, new ListItem("-Select-"));
    }

    /// <summary>
    /// Loads all open project of employee into project DDL
    /// </summary>
    private void LoadAllOpenProject()
    {
        try
        {
            string employeeId = Session["userID"].ToString();
            ProjectManager projectManagerObject = new ProjectManager();
            projectDropDownList.DataSource = projectManagerObject.GetAllOpenProjects(employeeId);
            projectDropDownList.DataTextField = "Title";
            projectDropDownList.DataValueField = "ID";
            projectDropDownList.DataBind();
        }
        catch (SqlException sqlExceptionObject)
        {
            errorLabel.Text = sqlExceptionObject.Message;
        }
        catch(Exception exceptionObject)
        {
            errorLabel.Text = exceptionObject.Message;
        }
    }

    /// <summary>
    /// Check for open task
    /// also disable project closing if any open task founded
    /// </summary>
    private void CheckForOpenTask()
    {
        try
        {
            TaskManager taskManagerObject = new TaskManager();
            List<Task> listOfOpenTasksOfTheProject= taskManagerObject.GetAllOpenTasksOfAProject(projectDropDownList.SelectedItem.Value);
            int numberOfOpenTask = listOfOpenTasksOfTheProject.Count;
            if (numberOfOpenTask == 0)
            {
                successLabel.Text = "All task of this project is closed.Admin can close this project";
                errorLabel.Text = "";
                closeProjectButton.Visible = true;
            }
            else
            {
                errorLabel.Text = "Task listed below is not closed.Please close all task before.";
                openTaskBulletedList.Visible = true;
                closeProjectButton.Visible = false;
                successLabel.Text = "";
                openTaskBulletedList.DataSource = listOfOpenTasksOfTheProject;
                openTaskBulletedList.DataTextField = "Name";
                openTaskBulletedList.DataValueField = "ID";
                openTaskBulletedList.DataBind();
            }
        }
        catch (SqlException sqlExceptionObject)
        {
            errorLabel.Text = sqlExceptionObject.Message;
        }
        catch (Exception exceptionObject)
        {
            errorLabel.Text = exceptionObject.Message;
        }

    }

    /// <summary>
    /// Load project Information
    /// </summary>
    private void LoadProjectInfo()
    {
        ProjectManager projectManagerObject = new ProjectManager();
        Project projectObject= projectManagerObject.SelectProject(projectDropDownList.SelectedItem.Value);
        clientIdLabel.Text = projectObject.ClientId;
        projectStatusLabel.Text= projectObject.Status;
    }

}
