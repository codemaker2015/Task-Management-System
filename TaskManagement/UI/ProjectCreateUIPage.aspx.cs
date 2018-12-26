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

public partial class UI_ProjectCreateUIPage : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        LoadProjectData();

        if (!Page.IsPostBack)
        {
            FillClientDropmDownList();
            FillAllEmployeeListBox();
            successLabel.Text = Request.QueryString["message"];
        }

    }
    
    protected void saveButton_Click(object sender, EventArgs e)
    {
        if (!CheckInputValues())
        {
            return;
        }

        string employeeNames = string.Empty;
        string employeeIDs = string.Empty;

        foreach (ListItem item in selectedEmployeeListBox.Items)
        {
                employeeNames += item.Text + ",";
                employeeIDs += item.Value + ",";
        }

        //removes the last coma from the string
        employeeNames = employeeNames.Substring(0, employeeNames.Length - 1);
        employeeIDs = employeeIDs.Substring(0, employeeIDs.Length - 1);


        Response.Redirect("ProjectSaveInfoUIPage.aspx?"
        + "&Id=" + Server.UrlEncode(this.idTextBox.Text)
        + "&Title=" + Server.UrlEncode(this.titleTextBox.Text)
        + "&Description=" + Server.UrlEncode(this.descriptionTextBox.Text)
        + "&StartDate=" + Server.UrlEncode(this.startDateTextBox.Text)
        + "&EstimateTime=" + Server.UrlEncode(this.estimateDateTextBox.Text)
        + "&ClientId=" + Server.UrlEncode(this.clientNameDropDownList.SelectedItem.Value)
        + "&EmployeeNames=" + Server.UrlEncode(employeeNames)
        + "&EmployeeIDs=" + Server.UrlEncode(employeeIDs)
        + "&Status=" + Server.UrlEncode(this.statusDropDownList.SelectedItem.Text));
    }

    protected void clientNameDropDownList_DataBound(object sender, EventArgs e)
    {
        //Inserting an item in the 0 index of the DDL named "-Select-"
        //which will navigate the user to select an item
        clientNameDropDownList.Items.Insert(0, new ListItem("-Select-"));
    }

    protected void singleAddButton_Click(object sender, EventArgs e)
    {
        if (allEmployeeListBox.SelectedItem == null)
        {
            return;
        }

        ListItem listItemObject = new ListItem();
        listItemObject.Text = allEmployeeListBox.SelectedItem.Text;
        listItemObject.Value = allEmployeeListBox.SelectedItem.Value;
        selectedEmployeeListBox.Items.Insert(0, listItemObject);

        allEmployeeListBox.Items.RemoveAt(allEmployeeListBox.SelectedIndex);
    }
    
    protected void singleRemoveButton_Click(object sender, EventArgs e)
    {
        if (selectedEmployeeListBox.SelectedItem == null)
        {
            return;
        }

        ListItem listItemObject = new ListItem();
        listItemObject.Text = selectedEmployeeListBox.SelectedItem.Text;
        listItemObject.Value = selectedEmployeeListBox.SelectedItem.Value;
        allEmployeeListBox.Items.Insert(0, listItemObject);

        selectedEmployeeListBox.Items.RemoveAt(selectedEmployeeListBox.SelectedIndex);

    }
    
    protected void allAddButton_Click(object sender, EventArgs e)
    {
        if (allEmployeeListBox.Items.Count == 0)
        {
            return;
        }
        foreach (ListItem item in allEmployeeListBox.Items)
        {
            ListItem listItemObject = new ListItem();
            listItemObject.Text = item.Text;
            listItemObject.Value = item.Value;
            selectedEmployeeListBox.Items.Insert(0, listItemObject);
        }
        allEmployeeListBox.Items.Clear();

    }
    
    protected void allRemoveButton_Click(object sender, EventArgs e)
    {
        if (selectedEmployeeListBox.Items.Count == 0)
        {
            return;
        }
        foreach (ListItem item in selectedEmployeeListBox.Items)
        {
            ListItem listItemObject = new ListItem();
            listItemObject.Text = item.Text;
            listItemObject.Value = item.Value;
            allEmployeeListBox.Items.Insert(0, listItemObject);
        }
        selectedEmployeeListBox.Items.Clear();
    }

    protected void clientNameDropDownList_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    
    protected void statusDropDownList_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    
    protected void projectGridView_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    
    protected void employeeCheckBoxList_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    /// <summary>
    /// Fill up employee ListBox
    /// </summary>
    private void FillAllEmployeeListBox()
    {
        try
        {
            EmployeeManager employeeManagerObject = new EmployeeManager();
            allEmployeeListBox.DataSource = employeeManagerObject.GetAllUserEmployees();
            allEmployeeListBox.DataTextField = "Name";
            allEmployeeListBox.DataValueField = "ID";
            allEmployeeListBox.DataBind();
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
    /// Load all project into project table
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
    /// Fill up client drop down list
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

            if (clientManagerObject.GetAllClient().Count == 0)
            {
                errorLabel.Text = "No client is created.";
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
    /// Check all input value for validation
    /// </summary>
    /// <returns>if all input valid returns true else false</returns>
    private bool CheckInputValues()
    {
        successLabel.Text = "";
        if (DataValidator.IsEmpty(idTextBox.Text))
        {
            errorLabel.Text = "Please enter project Id.";
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
            errorLabel.Text = "Please enter valid project description";
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
            errorLabel.Text = "Please enter estimate date";
            return false;
        }
        else if (!DataValidator.IsDate(estimateDateTextBox.Text))
        {
            errorLabel.Text = "Please enter valid date";
            return false;
        }
        else if (clientNameDropDownList.SelectedIndex.Equals(0))  // Item in index 0 is "-Select-" and not a valid item. So must not use
        {
            errorLabel.Text = "Please select a client";
            return false;
        }
        else if (selectedEmployeeListBox.Items.Count==0)
        {
            errorLabel.Text = "Please select employee(s)";
            return false;
        }
        else
        {
            return true;
        }
    }



    

    
}
