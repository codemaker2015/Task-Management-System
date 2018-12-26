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

public partial class UI_TaskEditUIPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack == false)
        {
            FillTaskIdDropDownList();
            
        }
    }

    protected void updateButton_Click(object sender, EventArgs e)
    {
        if (!CheckInputValues())
        {
            return;
        }

        Task taskObject = new Task();
        taskObject.Id = taskIdDropDownList.Text;
        taskObject.Name = taskNameTextBox.Text;
        taskObject.Description = taskDescriptionTextBox.Text;
        taskObject.StartDate = Convert.ToDateTime(startDateTextBox.Text);
        taskObject.EstimatedTime = Convert.ToDateTime(estimatedDateTextBox.Text);

        try
        {
            TaskManager taskManager = new TaskManager();
            string message = taskManager.UpdateTask(taskObject);
            updateSuccessLabel.Text = message;
            errorLabel.Text = "";
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
    
    protected void taskIdDropDownList_SelectedIndexChanged1(object sender, EventArgs e)
    {
        if (taskIdDropDownList.SelectedIndex.Equals(0))  // Item in index 0 is "-Select-" and not a valid item. So must not use
        {
            projectNameLabel.Text = "";
            employeeNameLabel.Text = "";
            taskNameTextBox.Text = "";
            taskDescriptionTextBox.Text = "";
            startDateTextBox.Text = "";
            estimatedDateTextBox.Text = "";
            errorLabel.Text = "";
            updateSuccessLabel.Text = "";
            return;
        }
        try
        {
            TaskManager taskManagerObject = new TaskManager();
            Task taskObject = taskManagerObject.SelectTask(taskIdDropDownList.Text);
            projectNameLabel.Text = taskObject.Project_Title;
            employeeNameLabel.Text = taskObject.Employee_AssignTo;
            taskNameTextBox.Text = taskObject.Name;
            taskDescriptionTextBox.Text = taskObject.Description;
            startDateTextBox.Text = taskObject.StartDate.ToString();
            estimatedDateTextBox.Text = taskObject.EstimatedTime.ToString();
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

    protected void taskIdDropDownList_DataBound(object sender, EventArgs e)
    {
        //Inserting an item in the 0 index of the DDL named "-Select-"
        //which will navigate the user to select an item
        taskIdDropDownList.Items.Insert(0, new ListItem("-Select-"));
    }

    /// <summary>
    /// Fills up taskIdDropDownList DDL
    /// </summary>
    private void FillTaskIdDropDownList()
    {
        try
        {
            string employeeId = Session["userID"].ToString();
            TaskManager taskManagerObject = new TaskManager();
            taskIdDropDownList.DataSource = taskManagerObject.GetAllOpenTasksOfAUser(employeeId);
            taskIdDropDownList.DataTextField = "Id";
            taskIdDropDownList.DataValueField = "Id";
            taskIdDropDownList.DataBind();

            if (taskManagerObject.GetAllOpenTasksOfAUser(employeeId).Count == 0)
            {
                errorLabel.Text = "Admin don't have any task in hand right now. Other employee is working on it. Cant edit task information now.";
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
    /// Checks in values
    /// </summary>
    /// <returns>return true if all input is correct else false</returns>
    private bool CheckInputValues()
    {
        updateSuccessLabel.Text = "";
        if (taskIdDropDownList.SelectedIndex.Equals(0))  // Item in index 0 is "-Select-" and not a valid item. So must not use
        {
            errorLabel.Text = "Please select a task";
            return false;
        }
        else if (DataValidator.IsEmpty(taskNameTextBox.Text))
        {
            errorLabel.Text = "Please enter task name";
            return false;
        }
        else if (DataValidator.IsEmpty(taskDescriptionTextBox.Text))
        {
            errorLabel.Text = "Please enter task description";
            return false;
        }
        else if (DataValidator.IsNumber(taskDescriptionTextBox.Text))
        {
            errorLabel.Text = "Please enter valid task description";
            return false;
        }
        else if (DataValidator.IsEmpty(startDateTextBox.Text))
        {
            errorLabel.Text = "Please enter task start date";
            return false;
        }
        else if (!DataValidator.IsDate(startDateTextBox.Text))
        {
            errorLabel.Text = "Please enter valid date";
            return false;
        }
        else if (DataValidator.IsEmpty(estimatedDateTextBox.Text))
        {
            errorLabel.Text = "Please enter estimatedate";
            return false;
        }
        else if (!DataValidator.IsDate(estimatedDateTextBox.Text))
        {
            errorLabel.Text = "Please enter valid date";
            return false;
        }
        else
        {
            return true;
        }
    }

}
