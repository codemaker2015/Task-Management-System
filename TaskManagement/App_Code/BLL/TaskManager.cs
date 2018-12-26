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
/// This class manages every thing about Task
/// contains methods to manage task related oparations
/// </summary>
public class TaskManager
{
	public TaskManager()
	{
		
	}

    /// <summary>
    /// Save a task information
    /// Exception:PrimaryKeyException, SqlException, Exception
    /// PrimaryKeyException:When trying to insert data in DB with existing primary key
    /// </summary>
    /// <param name="taskObj">taskObject</param>
    /// <returns>Task save status</returns>
    public string SaveTask(Task taskObj)
    {
        bool isSaved = false;
        try
        {
            TaskGateway taskGatewayObj = new TaskGateway();
            isSaved = taskGatewayObj.InsertTask(taskObj);
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
            return "Task information saved";
        }
        else
        {
            return "Task information is not saved";
        }
    }

    /// <summary>
    /// Update a task
    /// Exception:SqlException, Exception
    /// </summary>
    /// <param name="taskObject">taskObject</param>
    /// <returns>task update status</returns>
    public string UpdateTask(Task taskObject)
    {
        bool isSaved = false;
        try
        {
            TaskGateway taskGatewayObject = new TaskGateway();
            isSaved = taskGatewayObject.UpdateTask(taskObject);
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
            return "Task has been updated.";
        }
        else
        {
            return "Task is not updated";
        }
    }

    /// <summary>
    /// Get all the task
    /// Exception:SqlException, Exception
    /// </summary>
    /// <returns>List of all tasks</returns>
    public List<Task> GetListOfAllTasks()
    {
        try
        {
            TaskGateway taskGatewayObject = new TaskGateway();
            return taskGatewayObject.GetListOfAllTasks();
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
    /// Get all task of a project
    /// Exception:SqlException, Exception
    /// </summary>
    /// <param name="projectId">projectId</param>
    /// <returns>List of all tasks of the project</returns>
    public List<Task> GetAllTasksOfAProject(string projectId)
    {
        try
        {
            TaskGateway taskGatewayObj = new TaskGateway();
            return taskGatewayObj.SelectAllTasksOfTheProject(projectId);
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
    /// Get all open task of an employee of a project
    /// Exception:SqlException, Exception
    /// </summary>
    /// <param name="projectID">projectID</param>
    /// <param name="employeeID">employeeID</param>
    /// <returns>list of all open task of an employee of a project</returns>
    public List<Task> GetAllOpenTasksOfAProject(string projectID, string employeeID)
    {
        try
        {
            TaskGateway taskGatewayObj = new TaskGateway();
            return taskGatewayObj.SelectAllOpenTaskOfTheProject(projectID, employeeID);
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
    /// Get all open tasks of a project
    /// Exception:SqlException, Exception
    /// </summary>
    /// <param name="projectID">projectID</param>
    /// <returns>List of all open tasks</returns>
    public List<Task> GetAllOpenTasksOfAProject(string projectID)
    {
        try
        {
            TaskGateway taskGatewayObj = new TaskGateway();
            return taskGatewayObj.SelectAllOpenTaskOfTheProject(projectID);
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
    /// Selects a task
    /// Exception:SqlException, Exception
    /// </summary>
    /// <param name="taskId">task Id</param>
    /// <returns>task object</returns>
    public Task SelectTask(string taskId)
    {
        try
        {
            TaskGateway taskGatewayObject = new TaskGateway();
            return taskGatewayObject.SelectTask(taskId);
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
    /// Forwards a task
    /// Exception:SqlException, Exception
    /// </summary>
    /// <param name="taskObj">taskObj</param>
    /// <returns>task forward status</returns>
    public string ForwardATask(Task taskObj)
    {
        bool isForwarded =false;
        try
        {
            TaskGateway taskGatewayObj = new TaskGateway();
            isForwarded = taskGatewayObj.ForwardTask(taskObj);
        }
        catch (SqlException sqlExceptionObject)
        {
            throw sqlExceptionObject;
        }
        catch (Exception exceptionObj)
        {
            throw exceptionObj;
        }

        if (isForwarded)
        {
            return "Task is forwarded to " + taskObj.Employee_AssignTo;
        }
        else
        {
            return "Forwarding failed";
        }
    }

    /// <summary>
    /// Selects all task of a employee
    /// Exception:SqlException, Exception
    /// </summary>
    /// <param name="employeeID">employee Id</param>
    /// <returns>List of all task of a employee</returns>
    public List<Task> GetAllOpenTasksOfAUser(string employeeID)
    {
        List<Task> userAllTasks = null;
        try
        {
            TaskGateway taskGatewayObj = new TaskGateway();
            userAllTasks = taskGatewayObj.GetAllOpenTasksOfAUser(employeeID);
        }
        catch (SqlException sqlExceptionObject)
        {
            throw sqlExceptionObject;
        }
        catch (Exception exceptionObj)
        {
            throw exceptionObj;
        }
        return userAllTasks;
    }

    /// <summary>
    /// Closes a task
    /// Exception:SqlException, Exception
    /// </summary>
    /// <param name="taskObject">taskObject</param>
    /// <returns>task close status</returns>
    public string CloseTask(Task taskObject)
    {
        bool isSaved = false;
        try
        {
            TaskGateway taskGatewayObject = new TaskGateway();
            isSaved = taskGatewayObject.CloseTask(taskObject);
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
            return "Task is closed.";
        }
        else
        {
            return "Task is still open. some problem occurs during closing the task. ";
        }
    }

}
