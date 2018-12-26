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

public partial class UI_ProjectSaveInfoUIPage : System.Web.UI.Page
{
    string employeeIDs;

    protected void Page_Load(object sender, EventArgs e)
    {
        this.idLabel.Text = Request.QueryString["ID"];
        this.nameLabel.Text = Request.QueryString["Title"];
        this.descriptionLabel.Text = Request.QueryString["Description"];
        this.startDateLabel.Text = Request.QueryString["StartDate"];
        this.estimateTimeLabel.Text = Request.QueryString["EstimateTime"];
        this.clientIdLabel.Text = Request.QueryString["ClientId"];
        this.employeeIdLabel.Text = Request.QueryString["EmployeeNames"];
        employeeIDs = Request.QueryString["EmployeeIDs"];
        this.statusLabel.Text = Request.QueryString["Status"];
    }

    protected void saveButton_Click(object sender, EventArgs e)
    {
        Project projectObj = null;
        ProjectManager projectManagerObject = null;
        try
        {
            projectObj = new Project();
            projectObj.ID = idLabel.Text;
            projectObj.Title = nameLabel.Text;
            projectObj.Description = descriptionLabel.Text;
            projectObj.StartDate = Convert.ToDateTime(startDateLabel.Text);
            projectObj.EstimateTime = Convert.ToDateTime(estimateTimeLabel.Text);
            projectObj.ClientId = clientIdLabel.Text;
            projectObj.Employee_Id = employeeIDs;
            projectObj.Status = statusLabel.Text;

            projectManagerObject = new ProjectManager();
            string message = projectManagerObject.SaveProject(projectObj);
            Response.Redirect("ProjectCreateUIPage.aspx?" + "&message =" + Server.UrlEncode(message));
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
        Response.Redirect("ProjectCreateUIPage.aspx");
    }
}
