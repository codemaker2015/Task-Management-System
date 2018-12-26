using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;
using System.Data.SqlClient;




/// <summary>
/// This class manages every thing about Project
/// contains methods to manage project related oparations
/// </summary>
public class ProjectManager
{
	public ProjectManager()
	{
		
	}

    /// <summary>
    /// Selects all project of a user/employee
    /// Exception:SqlException, Exception
    /// </summary>
    /// <param name="employeeId">employeeId</param>
    /// <returns>list of all project of the user/employee</returns>
    public List<Project> GetAllProjectsOfUser(string employeeId)
    {
        try
        {
            ProjectGateway projectGatewayObj = new ProjectGateway();
            return projectGatewayObj.GetProjectsOfUser(employeeId);
        }
        catch (SqlException sqlExceptionObject)
        {
            throw sqlExceptionObject;
        }
        catch (Exception exceptionObj)
        {
            throw exceptionObj;
        }
    }

    /// <summary>
    /// Update a project information
    /// Exception:SqlException, Exception
    /// </summary>
    /// <param name="projectObj">projectObject</param>
    /// <returns>update status</returns>
    public string UpdateProject(Project projectObj)
    {
        bool isSaved = false;
        try
        {
            ProjectGateway projectGatewayObj = new ProjectGateway();
            isSaved = projectGatewayObj.UpdateProject(projectObj);
        }
        catch (SqlException sqlExceptionObject)
        {
            throw sqlExceptionObject;
        }
        catch (Exception exceptionObj)
        {
            throw exceptionObj;
        }

        if (isSaved)
        {
            return "Project has been updated.";
        }
        else
        {
            return "Project is not updated";
        }
    }

    /// <summary>
    /// Select a projrct by project's id
    /// Exception:SqlException, Exception
    /// </summary>
    /// <param name="projectId">projectId</param>
    /// <returns>projectObject</returns>
    public Project SelectProject(string projectId)
    {
        try
        {
            ProjectGateway projectGatewayObject = new ProjectGateway();
            return projectGatewayObject.SelectProject(projectId);
        }
        catch (SqlException sqlExceptionObject)
        {
            throw sqlExceptionObject;
        }
        catch (Exception exceptionObj)
        {
            throw exceptionObj;
        }
    }

    /// <summary>
    /// Get all open projects
    /// Exception:SqlException, Exception
    /// </summary>
    /// <returns>List of all open projects</returns>
    public List<Project> GetAllOpenProjects()
    {
        try
        {
            ProjectGateway projectGatewayObject = new ProjectGateway();
            return projectGatewayObject.SelectAllOpenProjects();
        }
        catch (SqlException sqlExceptionObject)
        {
            throw sqlExceptionObject;
        }
        catch (Exception exceptionObj)
        {
            throw exceptionObj;
        }
    }


    /// <summary>
    /// Get all open projects of a employee
    /// Exception:SqlException, Exception
    /// </summary>
    /// <param name="employeeID">employeeID</param>
    /// <returns>List of all open projects of a employee</returns>
    public List<Project> GetAllOpenProjects(string employeeID)
    {
        try
        {
            ProjectGateway projectGatewayObject = new ProjectGateway();
            return projectGatewayObject.SelectAllOpenProjects(employeeID);
        }
        catch (SqlException sqlExceptionObject)
        {
            throw sqlExceptionObject;
        }
        catch (Exception exceptionObj)
        {
            throw exceptionObj;
        }
    }




    /// <summary>
    /// Saves a project information
    /// Note: project creator will be a member of the project by default
    /// Exception:PrimaryKeyException, SqlException, Exception
    /// PrimaryKeyException:When trying to insert data in DB with existing primary key
    /// </summary>
    /// <param name="projectObj">projectObject</param>
    /// <returns>project save status</returns>
    public string SaveProject(Project projectObj)
    {
        bool isSaved = false;
        string projectCreatorID = System.Web.HttpContext.Current.Session["userID"].ToString();
                //This obtains value of a session variable
                //session variable is directly accessable in code behind a aspx page
                //to obtain session variable from classes with out aspx page, absolut path needed

        try
        {
            ProjectGateway projectGatewayObj = new ProjectGateway();
            
                    // Business logic is project creator must be a member of the project.
            if (!projectObj.Employee_Id.Contains(projectCreatorID))
            {
                projectObj.Employee_Id += ","+projectCreatorID;
            }

            isSaved = projectGatewayObj.InsertProject(projectObj);
        }
        catch (PrimaryKeyException primaryKeyExceptionObj)
        {
            throw primaryKeyExceptionObj;
        }
        catch (SqlException sqlExceptionObject)
        {
            throw sqlExceptionObject;
        }
        catch (Exception exceptionObj)
        {
            throw exceptionObj;
        }

        if (isSaved)
        {
            return "Project has been saved.";
        }
        else
        {
            return "Project is not saved";
        }
    }


    /// <summary>
    /// Closes a project
    /// Exception:SqlException, Exception
    /// </summary>
    /// <param name="projectObject">projectObject</param>
    /// <returns>Project close status</returns>
    public string CloseProject(Project projectObject)
    {
        bool isClosed = false;
        try
        {
            ProjectGateway projectGatewayObject = new ProjectGateway();
            isClosed = projectGatewayObject.CloseProject(projectObject);
        }
        catch (SqlException sqlExceptionObject)
        {
            throw sqlExceptionObject;
        }
        catch (Exception exceptionObject)
        {
            throw exceptionObject;
        }

        if (isClosed)
        {
            return "Project is closed";
        }
        else
        {
            return "Project is not closed";
        }
    }

    /// <summary>
    /// Add Employee(s) to existing project
    /// Exception:SqlException, Exception
    /// </summary>
    /// <param name="projectObject">projectObjrct</param>
    /// <returns>New employee add status</returns>
    public string AddEmployeeToProject(Project projectObject)
    {
        bool isSaved = false;
        try
        {
            ProjectGateway projectGatewayObject = new ProjectGateway();
            isSaved= projectGatewayObject.AddEmployeeToProject(projectObject);
        }
        catch (SqlException sqlExceptionObject)
        {
            throw sqlExceptionObject;
        }
        catch (Exception exceptionObject)
        {
            throw exceptionObject;
        }

        if (isSaved)
        {
            return "Employee(s) added";
        }
        else
        {
            return "Employee(s) not added";
        }
    }

    /// <summary>
    /// Remove employee from project
    /// Exception:SqlException, Exception
    /// </summary>
    /// <param name="projectObject">projectObject</param>
    /// <returns>employee remove status</returns>
    public string RemovedEmployeeFromProject(Project projectObject)
    {
        bool IsRemoved = false;
        try
        {
            ProjectGateway projectGatewayObject = new ProjectGateway();
            IsRemoved = projectGatewayObject.RemoveEmployeeFromProject(projectObject);
        }
        catch (SqlException sqlExceptionObject)
        {
            throw sqlExceptionObject;
        }
        catch (Exception exceptionObject)
        {
            throw exceptionObject;
        }

        if (IsRemoved)
        {
            return "Employee is removed";
        }
        else
        {
            return "Employee is not removed";
        }
    }

}
