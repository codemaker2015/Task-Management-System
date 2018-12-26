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

public partial class UI_ProjectRemoveEmployeeUIPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            LoadAllOpenProject();
        }
    }

    protected void removeemployeeButton_Click(object sender, EventArgs e)
    {
        if (!CheckForEmployeeRemove())
        {
            return;
        }


        AssignEmployeesTaskToAdmin();
        RemoveEmployee();
        LoadAllOpenProject();
        employeeDropDownList.Items.Clear();
    }

    protected void projectDropDownList_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (projectDropDownList.SelectedIndex.Equals(0))  // Item in index 0 is "-Select-" and not a valid item. So must not use
        {
            employeeDropDownList.Items.Clear();
            return;
        }
        LoadAllEmployeeOfTheProject();
        successLabel.Text = "";
        errorLabel.Text = "";
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
    /// Remove an employee from project
    /// </summary>
    private void RemoveEmployee()
    {
        try
        {
            Project projectObject = new Project();
            projectObject.ID = projectDropDownList.SelectedItem.Value;
            projectObject.Employee_Id = employeeDropDownList.SelectedItem.Value;
            ProjectManager projectManagerObject = new ProjectManager();
            string employeeRemoveStatus = projectManagerObject.RemovedEmployeeFromProject(projectObject);
            successLabel.Text = employeeRemoveStatus;
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

    /// <summary>
    /// Loads all open project of employee into project DDL
    /// </summary>
    private void LoadAllOpenProject()
    {
        try
        {
            string employeeId = Session["userID"].ToString();
            ProjectManager projectManagerObject = new ProjectManager();
            int noOfProject = projectManagerObject.GetAllOpenProjects(employeeId).Count;
            projectDropDownList.DataSource = projectManagerObject.GetAllOpenProjects(employeeId);
                                                    //Admin can remove an employee from a project only if he is a member of it
            
            projectDropDownList.DataTextField = "Title";
            projectDropDownList.DataValueField = "ID";
            projectDropDownList.DataBind();
            if (noOfProject.Equals(0))
            {
                errorLabel.Text = "Admin is not a member of any project. Admin cant remove any employee";
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
    /// Loads employee DDL
    /// </summary>
    private void LoadAllEmployeeOfTheProject()
    {
        try
        {
            EmployeeManager employeeManagerObject = new EmployeeManager();
            employeeDropDownList.DataSource = employeeManagerObject.GetEmployeesOfTheProject(projectDropDownList.SelectedItem.Value);
            employeeDropDownList.DataTextField = "Name";
            employeeDropDownList.DataValueField = "ID";
            employeeDropDownList.DataBind();
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
    /// Assigen all task of the employee to admin before remove
    /// </summary>
    private void AssignEmployeesTaskToAdmin()
    {
        try
        {
            TaskManager taskManagerObject = new TaskManager();
            List<Task> taskListObject = taskManagerObject.GetAllOpenTasksOfAProject(projectDropDownList.SelectedItem.Value, employeeDropDownList.SelectedItem.Value);
            foreach (Task task in taskListObject)
            {
                string employeeId = Session["userID"].ToString();
                string employeeName = Session["userName"].ToString();
                Task taskObject = new Task();
                taskObject.Id = task.Id;
                taskObject.Name = task.Name;
                taskObject.Project_Id = projectDropDownList.SelectedItem.Value;
                taskObject.Project_Title = projectDropDownList.SelectedItem.Text;
                taskObject.Employee_Id = employeeId;
                taskObject.Employee_AssignTo = employeeName;
                taskObject.Employee_AssigenBy = employeeId;
                taskObject.StartDate = System.DateTime.Now;
                taskManagerObject.ForwardATask(taskObject);
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
    /// Checks if admin can remove a employee
    /// </summary>
    /// <returns>true if admin can remove employee else false</returns>
    private bool CheckForEmployeeRemove()
    {
        successLabel.Text = "";

        try
        {
            string employeeId = Session["userID"].ToString();
            ProjectManager projectManagerObject = new ProjectManager();
            int numberOfProject = projectManagerObject.GetAllOpenProjects(employeeId).Count;
                    //Admin can remove an employee from a project only if he is a member of it
                    //This counts the number of projects admin have


            EmployeeManager employeeManagerObject = new EmployeeManager();
            int numberOfEmployee = employeeManagerObject.GetEmployeesOfTheProject(projectDropDownList.SelectedItem.Value).Count;
                    //If there is only one project member then he cant be removed        
                    //This counts the number of members of the selected project

            UserManager userManagerObjrct = new UserManager();

            if (projectDropDownList.SelectedIndex.Equals(0))  // Item in index 0 is "-Select-" and not a valid item. So must not use
            {
                errorLabel.Text = "Please select a project";
                return false;
            }
            else if (numberOfProject == 0)
            {
                errorLabel.Text = "Admin is not a member of any project. Admin cant remove any employee";
                return false;
            }
            else if (numberOfEmployee == 1)
            {
                errorLabel.Text = "Only Admin is employee of the ptoject. Cant remove!";
                return false;
            }
            else if (employeeDropDownList.SelectedIndex.Equals(0))  // Item in index 0 is "-Select-" and not a valid item. So must not use
            {
                errorLabel.Text = "Please select an employee to remove";
                return false;
            }
            else if (userManagerObjrct.IsAdmin(employeeDropDownList.SelectedItem.Value))
            {
                errorLabel.Text = "Admin cant be removed";
                return false;
            }
            else
            {
                return true;
            }
        }
        catch (NonUserEmployeeException nonUserEmployeeExceptionObject)
        {
            /*This exception occours when employee is not a user
             * but is a member of a project
             * A non user employee can be removed from the project
             * so true is returned
             * Admin will not be aware of this event as errorLabel.text will be removed when non user employee successfully removed
             * */
            errorLabel.Text = nonUserEmployeeExceptionObject.Message + "Can be removed";
            return true;
        }
        catch (SqlException sqlExceptionObject)
        {
            errorLabel.Text = sqlExceptionObject.Message;
            return false;
        }
        catch (Exception exceptionObject)
        {
            errorLabel.Text = exceptionObject.Message;
            return false;
        }
    }
    
}


