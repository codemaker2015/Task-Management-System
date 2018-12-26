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

public partial class UI_ProjectEditUIPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            FillProjectIdDropDownList();
            FillClientDropmDownList();
            LoadProjectData();
        }
    }

    protected void updateButton_Click(object sender, EventArgs e)
    {
        string message = null;

        if (!CheckInputValues())
        {
            return;
        }

        Project projectObj = new Project();
        projectObj.ID = projectIdDropDownList.Text;
        projectObj.Title = titleTextBox.Text;
        projectObj.Description = descriptionTextBox.Text;
        projectObj.StartDate = Convert.ToDateTime(startDateTextBox.Text);
        projectObj.EstimateTime = Convert.ToDateTime(estimateDateTextBox.Text);
        projectObj.ClientId = clientNameDropDownList.SelectedValue;
        //projectObj.Employee_Id = assignedToDropDownList.Text;
        projectObj.Status = projectStatusLabel.Text;

        try
        {
            ProjectManager projectManagerObject = new ProjectManager();
            message = projectManagerObject.UpdateProject(projectObj);
            successLabel.Text = message;
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
        successLabel.Text = message;
        errorLabel.Text = "";
        LoadProjectData();

    }

    protected void projectIdDropDownList_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (projectIdDropDownList.SelectedIndex.Equals(0))
        {
            titleTextBox.Text = "";
            descriptionTextBox.Text = "";
            startDateTextBox.Text = "";
            estimateDateTextBox.Text = "";
            projectStatusLabel.Text = "";
            errorLabel.Text = "";
            successLabel.Text = "";
            clientNameDropDownList.Items.Clear();
            FillClientDropmDownList();
            return;
        }
        try
        {
            ProjectManager projectManagerObject = new ProjectManager();
            Project projectObject = projectManagerObject.SelectProject(projectIdDropDownList.Text);
            titleTextBox.Text = projectObject.Title;
            descriptionTextBox.Text = projectObject.Description;
            startDateTextBox.Text = projectObject.StartDate.ToString();
            estimateDateTextBox.Text = projectObject.EstimateTime.ToString();
            projectStatusLabel.Text = projectObject.Status.ToString();
            clientNameDropDownList.Text = projectObject.ClientId;
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

    protected void projectIdDropDownList_DataBound(object sender, EventArgs e)
    {
        //Inserting an item in the 0 index of the DDL named "-Select-"
        //which will navigate the user to select an item
        projectIdDropDownList.Items.Insert(0, new ListItem("-Select-"));
    }

    /// <summary>
    /// Fills up projectIdDropDownList DDL
    /// </summary>
    private void FillProjectIdDropDownList()
    {
        try
        {
            ProjectManager projectManagerObject = new ProjectManager();
            projectIdDropDownList.DataSource = projectManagerObject.GetAllProjectsOfUser(Session["userID"].ToString());
            projectIdDropDownList.DataTextField = "ID";
            projectIdDropDownList.DataValueField = "ID";
            projectIdDropDownList.DataBind();

            if (projectManagerObject.GetAllProjectsOfUser(Session["userID"].ToString()).Count==0)
            {
                errorLabel.Text = "Admin is not a member of any project yet. Can't edit any project information";
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
    /// Fills up clientNameDropDownList DDL
    /// </summary>
    private void FillClientDropmDownList()
    {
        try
        {
            ClientManager clientManagerObject = new ClientManager();
            clientNameDropDownList.DataSource = clientManagerObject.GetAllClient();
            clientNameDropDownList.DataTextField = "CompanyName";
            clientNameDropDownList.DataValueField = "ID";
            clientNameDropDownList.DataBind();
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
    /// Fills up projectGridView 
    /// </summary>
    private void LoadProjectData()
    {
        try
        {
            ProjectGateway projectGatewayObj = new ProjectGateway();
            projectGridView.DataSource = projectGatewayObj.GetProjectTable();
            projectGridView.DataBind();
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
    /// Checks input values
    /// </summary>
    /// <returns></returns>
    private bool CheckInputValues()
    {
        successLabel.Text = "";
        if (projectIdDropDownList.SelectedIndex.Equals(0))
        {
            errorLabel.Text = "Please select a project";
            return false;
        }
        else if (DataValidator.IsEmpty(titleTextBox.Text))
        {
            errorLabel.Text = "Please enter project title";
            return false;
        }
        else if (DataValidator.IsEmpty(descriptionTextBox.Text))
        {
            errorLabel.Text = "Please enter project description";
            return false;
        }
        else if (DataValidator.IsNumber(descriptionTextBox.Text))
        {
            errorLabel.Text = "Please enter valid description";
            return false;
        }
        else if (DataValidator.IsEmpty(startDateTextBox.Text))
        {
            errorLabel.Text = "Please enter project start date";
            return false;
        }
        else if (!DataValidator.IsDate(startDateTextBox.Text))
        {
            errorLabel.Text = "Please enter valid date";
            return false;
        }
        else if (DataValidator.IsEmpty(estimateDateTextBox.Text))
        {
            errorLabel.Text = "Please enter estimatedate";
            return false;
        }
        else if (!DataValidator.IsDate(estimateDateTextBox.Text))
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
