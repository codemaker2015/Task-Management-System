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

public partial class UI_ProjectAddEmployeeUIPage : System.Web.UI.Page
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
        //When project changes this information is not valid. so removed
        nonMemberEmployeeListBox.Items.Clear();
        selectedEmployeeListBox.Items.Clear();
        successLabel.Text = "";
        errorLabel.Text = "";

        if (projectDropDownList.SelectedIndex.Equals(0))
        {
            return;
        }
        FillEmployeeListBox();
    }

    protected void saveButton_Click(object sender, EventArgs e)
    {
        successLabel.Text = "";
        if (projectDropDownList.SelectedIndex.Equals(0))
        {
            errorLabel.Text = "Please select a project";
            return;
        }
        else if (selectedEmployeeListBox.Items.Count == 0)
        {
            errorLabel.Text = "Please select employee(s)";
            return;
        }

        string employeeNames = string.Empty;
        string employeeIDs = string.Empty;

        try
        {
            foreach (ListItem item in selectedEmployeeListBox.Items)
            {
                employeeNames += item.Text + ",";
                employeeIDs += item.Value + ",";
            }

            //removes the last coma from the string
            employeeNames = employeeNames.Substring(0, employeeNames.Length - 1);
            employeeIDs = employeeIDs.Substring(0, employeeIDs.Length - 1);

            Project projectObject = new Project();
            projectObject.ID = projectDropDownList.SelectedItem.Value;
            projectObject.Employee_Id = employeeIDs;
            ProjectManager projectManagerObject = new ProjectManager();
            successLabel.Text = projectManagerObject.AddEmployeeToProject(projectObject);

            errorLabel.Text = "";
            nonMemberEmployeeListBox.Items.Clear();
            selectedEmployeeListBox.Items.Clear();

            FillEmployeeListBox();
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

    protected void projectDropDownList_DataBound(object sender, EventArgs e)
    {
        //Inserting an item in the 0 index of the DDL named "-Select-"
        //which will navigate the user to select an item
        projectDropDownList.Items.Insert(0, new ListItem("-Select-"));
    }

    protected void singleAddButton_Click(object sender, EventArgs e)
    {
        if (nonMemberEmployeeListBox.SelectedItem == null)
        {
            return;
        }

        ListItem listItemObject = new ListItem();
        listItemObject.Text = nonMemberEmployeeListBox.SelectedItem.Text;
        listItemObject.Value = nonMemberEmployeeListBox.SelectedItem.Value;
        selectedEmployeeListBox.Items.Insert(0, listItemObject);

        nonMemberEmployeeListBox.Items.RemoveAt(nonMemberEmployeeListBox.SelectedIndex);
    }
    
    protected void allAddButton_Click(object sender, EventArgs e)
    {
        if (nonMemberEmployeeListBox.Items.Count == 0)
        {
            return;
        }
        foreach (ListItem item in nonMemberEmployeeListBox.Items)
        {
            ListItem listItemObject = new ListItem();
            listItemObject.Text = item.Text;
            listItemObject.Value = item.Value;
            selectedEmployeeListBox.Items.Insert(0, listItemObject);
        }
        nonMemberEmployeeListBox.Items.Clear();

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
        nonMemberEmployeeListBox.Items.Insert(0, listItemObject);

        selectedEmployeeListBox.Items.RemoveAt(selectedEmployeeListBox.SelectedIndex);


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
            nonMemberEmployeeListBox.Items.Insert(0, listItemObject);
        }
        selectedEmployeeListBox.Items.Clear();
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

            if(projectManagerObject.GetAllOpenProjects(employeeId).Count==0)
            {
            errorLabel.Text = "Admin is not a member of any project yet. Can't add employee(s) to any project";
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
    /// Fill up employee checkboxList who is not a member of the project
    /// </summary>
    private void FillEmployeeListBox()
    {
        try
        {
            EmployeeManager employeeManagerObject = new EmployeeManager();
            nonMemberEmployeeListBox.DataSource = employeeManagerObject.GetAllNonMemberEmployeeOfTheProject(projectDropDownList.SelectedItem.Value);
            nonMemberEmployeeListBox.DataTextField = "Name";
            nonMemberEmployeeListBox.DataValueField = "ID";
            nonMemberEmployeeListBox.DataBind();

            if (employeeManagerObject.GetAllNonMemberEmployeeOfTheProject(projectDropDownList.SelectedItem.Value).Count == 0)
            {
                errorLabel.Text = "All employees are member of this project";
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
    
}
