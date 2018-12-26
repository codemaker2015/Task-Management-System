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

public partial class UI_TaskSaveInfoUIPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this.idLabel.Text = Request.QueryString["Id"];
        this.nameLabel.Text = Request.QueryString["Title"];
        this.descriptionLabel.Text = Request.QueryString["Description"];
        this.startDateLabel.Text = Request.QueryString["StartDate"];
        this.estimateTimeLabel.Text = Request.QueryString["EstimateTime"];
        this.employeeIdLabel.Text = Request.QueryString["EmployeeId"];
        this.employeeNameLabel.Text = Request.QueryString["EmployeeName"];
        this.projectTitleLabel.Text = Request.QueryString["ProjectTitle"];
        this.projectIdLabel.Text = Request.QueryString["ProjectId"];
    }
    
    protected void SaveButton_Click(object sender, EventArgs e)
    {
        string message = null;

        Task taskObj = new Task();
        taskObj.Id = idLabel.Text;
        taskObj.Name = nameLabel.Text;
        taskObj.Description = descriptionLabel.Text;
        taskObj.Project_Title = projectTitleLabel.Text;
        taskObj.StartDate = Convert.ToDateTime(startDateLabel.Text);
        taskObj.EstimatedTime = Convert.ToDateTime(estimateTimeLabel.Text);
        taskObj.Employee_AssignTo = employeeNameLabel.Text;
        taskObj.Project_Id = projectIdLabel.Text;
        taskObj.Employee_Id = employeeIdLabel.Text;
        taskObj.Employee_AssigenBy=Session["userID"].ToString();

        try
        {
            TaskManager taskManager = new TaskManager();
            message = taskManager.SaveTask(taskObj);
            Response.Redirect("TaskNewUIPage.aspx?" + "&message=" + Server.UrlEncode(message));
        }
        catch (PrimaryKeyException primaryKeyExceptionObj)
        {
            errorMessageLabel.Text = primaryKeyExceptionObj.Message;
        }
        catch (SqlException sqlExceptionObj)
        {
            errorMessageLabel.Text = sqlExceptionObj.Message;
        }
        catch (Exception exceptionObj)
        {
            errorMessageLabel.Text = exceptionObj.Message;
        }
        
    }

    protected void cancelButton_Click(object sender, EventArgs e)
    {
        Response.Redirect("TaskNewUIPage.aspx");
    }
}
