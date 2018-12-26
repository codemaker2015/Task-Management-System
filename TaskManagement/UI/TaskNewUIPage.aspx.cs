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

public partial class UI_TaskNewUIPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.FillProjectDropDownList();
            CreateTaskSuccessLabel.Text = Request.QueryString["message"];
        }
    }

    protected void ProjectDropDownList_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (projectDropDownList.SelectedIndex.Equals(0))  // Item in index 0 is "-Select-" and not a valid item. So must not use
        {
            employeeDropDownList.Items.Clear();
            return;
        }

        FillEmployeeDropdownList();
    }

    protected void CreateButton_Click(object sender, EventArgs e)
    {
        if (!CheckInputValues())
        {
            return;
        }

        Response.Redirect("TaskSaveInfoUIPage.aspx?"
        + "&Id=" + Server.UrlEncode(this.taskIdTextBox.Text)
        + "&Title=" + Server.UrlEncode(this.taskNameTextBox.Text)
        + "&Description=" + Server.UrlEncode(this.taskDescriptionTextBox.Text)
        + "&StartDate=" + Server.UrlEncode(this.startDateTextBox.Text)
        + "&EstimateTime=" + Server.UrlEncode(this.estimatedDateTextBox.Text)
        + "&EmployeeName=" + Server.UrlEncode(this.employeeDropDownList.SelectedItem.Text)
        + "&ProjectTitle=" + Server.UrlEncode(this.projectDropDownList.SelectedItem.Text)
        + "&EmployeeId=" + Server.UrlEncode(this.employeeDropDownList.SelectedItem.Value)
        + "&ProjectId=" + Server.UrlEncode(this.projectDropDownList.SelectedItem.Value));
    }
    
    protected void projectDropDownList_DataBound(object sender, EventArgs e)
    {
        //Inserting an item in the 0 index of the DDL named "-Select-"
        //which will navigate the user to select an item
        projectDropDownList.Items.Insert(0, new ListItem("-Select-"));
    }
    
    protected void employeeDropDownList_DataBound(object sender, EventArgs e)
    {
        //Inserting an item in the 0 index of the DDL named "-Select-"
        //which will navigate the user to select an item
        employeeDropDownList.Items.Insert(0, new ListItem("-Select-"));
    }

    /// <summary>
    /// Fills project DDL
    /// </summary>
    private void FillProjectDropDownList()
    {
        try
        {
            string employeeId = Session["userID"].ToString();
            ProjectManager projectManagerObject = new ProjectManager();
            projectDropDownList.DataSource = projectManagerObject.GetAllOpenProjects(employeeId);
            projectDropDownList.DataTextField = "Title";
            projectDropDownList.DataValueField = "ID";
            projectDropDownList.DataBind();

            if (projectManagerObject.GetAllOpenProjects(employeeId).Count == 0)
            {
                errorLabel.Text = "Admin is not a member of any project. Can't create task for any project.";
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
    /// Fills employee DDL
    /// </summary>
    private void FillEmployeeDropdownList()
    {
        try
        {
            EmployeeManager employeeManagerObject = new EmployeeManager();
            employeeDropDownList.DataSource = employeeManagerObject.GetEmployeesOfTheProject(projectDropDownList.SelectedItem.Value);
            employeeDropDownList.DataTextField = "Name";
            employeeDropDownList.DataValueField = "Id";
            employeeDropDownList.DataBind();
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
    /// Check all input value for validation
    /// </summary>
    /// <returns>if all input valid returns true else false</returns>
    private bool CheckInputValues()
    {
        CreateTaskSuccessLabel.Text = "";
        if (DataValidator.IsEmpty(taskIdTextBox.Text))
        {
            errorLabel.Text = "Please enter task ID";
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
        else if (projectDropDownList.SelectedIndex.Equals(0))  // Item in index 0 is "-Select-" and not a valid item. So must not use
        {
            errorLabel.Text = "Please select a project";
            return false;
        }
        else if (employeeDropDownList.SelectedIndex.Equals(0))  // Item in index 0 is "-Select-" and not a valid item. So must not use
        {
            errorLabel.Text = "Please select an employee";
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
