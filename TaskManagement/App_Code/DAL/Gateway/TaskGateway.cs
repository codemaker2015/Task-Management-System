using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Collections.Generic;


/// <summary>
/// Gateway of task with DB
/// </summary>
public class TaskGateway
{
	public TaskGateway()
	{
		
	}

    /// <summary>
    /// Saves a new task to DB
    /// Exception:PrimaryKeyException, SqlException, Exception
    /// PrimaryKeyException:When trying to insert data in DB with existing primary key
    /// </summary>
    /// <param name="taskObject">object of task type to save in DB</param>
    /// <returns>returns true if task saved properly in DB else false</returns>
    public bool InsertTask(Task taskObject)
    {
        SqlConnection sqlConn = null;
        int noOfRowsAffectedTaskHistory = 0;
        int noOfRowsAffectedTask = 0;
        try
        {
            string insertString = "INSERT INTO t_Task(task_Id, task_Name, task_Description, task_Project_Title, task_StartDate, task_EstimateTime, task_Employee_Name, task_Project_Id, task_Employee_Id, task_Status) VALUES('" + taskObject.Id + "','" + taskObject.Name + "','" + taskObject.Description + "','" + taskObject.Project_Title + "','" + taskObject.StartDate + "','" + taskObject.EstimatedTime + "','" + taskObject.Employee_AssignTo + "','" + taskObject.Project_Id + "','" + taskObject.Employee_Id + "','Open')";
            DBConnector dbconectorObj = new DBConnector();
            sqlConn = dbconectorObj.GetConnection;
            sqlConn.Open();
            SqlCommand sqlCom = new SqlCommand(insertString, sqlConn);
            noOfRowsAffectedTask = sqlCom.ExecuteNonQuery();

            insertString = "INSERT INTO t_TaskHistory(taskHistory_Task_Id, taskHistory_Employee_Id_AssignedTo, taskHistory_Project_Id, taskHistory_TaskAsignDate, taskHistory_Employee_Id_AssignedBy) VALUES('"
            + taskObject.Id + "','" + taskObject.Employee_Id + "','" + taskObject.Project_Id + "','" + taskObject.StartDate + "','" + taskObject.Employee_AssigenBy + "')";
            sqlCom = new SqlCommand(insertString, sqlConn);
            noOfRowsAffectedTaskHistory = sqlCom.ExecuteNonQuery();
        }
        catch (SqlException sqlExceptionObject)
        {
            if (sqlExceptionObject.Number == 2627)  //Violation of primary key Msg no =2627
            {
                throw (new PrimaryKeyException(sqlExceptionObject));
            }
            else
            {
                throw sqlExceptionObject;
            }
        }
        catch (Exception exceptionObj)
        {
            throw exceptionObj;
        }
        finally
        {
            if (sqlConn.State == System.Data.ConnectionState.Open)
            {
                sqlConn.Close();
            }
        }

        if (noOfRowsAffectedTask > 0 && noOfRowsAffectedTaskHistory > 0)
        {
            return true;
        }
        else
        {
            return false;
        }

    }

    /// <summary>
    /// Get all the task of a project
    /// Exception:SqlException, Exception
    /// </summary>
    /// <param name="projectId">Id of the project</param>
    /// <returns>List of tasks of the project</returns>
    public List<Task> SelectAllTasksOfTheProject(string projectId)
    {
        List<Task> taskListOfTheProjectObj = null;
        SqlConnection sqlConn = null;
        try
        {
            taskListOfTheProjectObj = new List<Task>();
            string selectQuery = "SELECT task_Id, task_Name FROM t_Task WHERE task_Project_Id='" + projectId + "'";
            DBConnector dbConnector = new DBConnector();
            sqlConn = dbConnector.GetConnection;
            sqlConn.Open();
            SqlDataAdapter sqlDataAdapterObject = new SqlDataAdapter(selectQuery, sqlConn);
            DataSet dataSetObject = new DataSet();
            sqlDataAdapterObject.Fill(dataSetObject);
            DataTable dataTableObject = dataSetObject.Tables[0];
            foreach (DataRow dataRowObj in dataTableObject.Rows)
            {
                Task taskObject = new Task();
                taskObject.Id = dataRowObj[0].ToString();
                taskObject.Name = dataRowObj[1].ToString();

                taskListOfTheProjectObj.Add(taskObject);
            }
        }
        catch (SqlException sqlExceptionObject)
        {
            throw sqlExceptionObject;
        }
        catch (Exception exceptionObject)
        {
            throw exceptionObject;
        }
        finally
        {
            if (sqlConn.State == System.Data.ConnectionState.Open)
            {
                sqlConn.Close();
            }
        }
        return taskListOfTheProjectObj;
    }

    /// <summary>
    /// Selects all open tasks of the project
    /// Exception:SqlException, Exception
    /// </summary>
    /// <param name="projectID">projectID</param>
    /// <returns>List of all open tasks</returns>
    public List<Task> SelectAllOpenTaskOfTheProject(string projectID)
    {

        List<Task> openTaskListOfTheProjectObj = null;
        SqlConnection sqlConn = null;
        try
        {
            openTaskListOfTheProjectObj = new List<Task>();
            string selectQuery = "SELECT task_Id, task_Name FROM t_Task WHERE task_Project_Id='" + projectID + "'AND task_Status = 'Open'";
            DBConnector dbConnector = new DBConnector();
            sqlConn = dbConnector.GetConnection;
            sqlConn.Open();
            SqlDataAdapter sqlDataAdapterObject = new SqlDataAdapter(selectQuery, sqlConn);
            DataSet dataSetObject = new DataSet();
            sqlDataAdapterObject.Fill(dataSetObject);
            DataTable dataTableObject = dataSetObject.Tables[0];
            foreach (DataRow dataRowObj in dataTableObject.Rows)
            {
                Task taskObject = new Task();
                taskObject.Id = dataRowObj[0].ToString();
                taskObject.Name = dataRowObj[1].ToString();

                openTaskListOfTheProjectObj.Add(taskObject);
            }
        }
        catch (SqlException sqlExceptionObject)
        {
            throw sqlExceptionObject;
        }
        catch (Exception exceptionObject)
        {
            throw exceptionObject;
        }
        finally
        {
            if (sqlConn.State == System.Data.ConnectionState.Open)
            {
                sqlConn.Close();
            }
        }
        return openTaskListOfTheProjectObj;
    }

    /// <summary>
    /// Selects all open tasks of an employee of a project
    /// Exception:SqlException, Exception
    /// </summary>
    /// <param name="projectID">projectID</param>
    /// <returns>List of all open tasks of an employee of a project</returns>
    public List<Task> SelectAllOpenTaskOfTheProject(string projectID, string employeeID)
    {

        List<Task> openTaskListOfTheProjectObj = null;
        SqlConnection sqlConn = null;
        try
        {
            openTaskListOfTheProjectObj = new List<Task>();
            string selectQuery = "SELECT task_Id, task_Name FROM t_Task WHERE task_Project_Id='"+ projectID +"'AND task_Employee_Id='" + employeeID + "' AND task_Status = 'Open'";
            DBConnector dbConnector = new DBConnector();
            sqlConn = dbConnector.GetConnection;
            sqlConn.Open();
            SqlDataAdapter sqlDataAdapterObject = new SqlDataAdapter(selectQuery, sqlConn);
            DataSet dataSetObject = new DataSet();
            sqlDataAdapterObject.Fill(dataSetObject);
            DataTable dataTableObject = dataSetObject.Tables[0];
            foreach (DataRow dataRowObj in dataTableObject.Rows)
            {
                Task taskObject = new Task();
                taskObject.Id = dataRowObj[0].ToString();
                taskObject.Name = dataRowObj[1].ToString();

                openTaskListOfTheProjectObj.Add(taskObject);
            }
        }
        catch (SqlException sqlExceptionObject)
        {
            throw sqlExceptionObject;
        }
        catch (Exception exceptionObject)
        {
            throw exceptionObject;
        }
        finally
        {
            if (sqlConn.State == System.Data.ConnectionState.Open)
            {
                sqlConn.Close();
            }
        }
        return openTaskListOfTheProjectObj;
    }

    /// <summary>
    /// Forwards a task
    /// changes task_Employee_Name & task_Employee_Id in t_task
    /// insert taks info in t_TaskHistory
    /// Exception:PrimaryKeyException, SqlException, Exception
    /// PrimaryKeyException:When trying to insert data in DB with existing primary key
    /// </summary>
    /// <param name="taskObj">taskobj </param>
    /// <returns>true if forwarded else false</returns>
    public bool ForwardTask(Task taskObj)
    {
        SqlConnection sqlConn = null;
        int noOfRowsAffectedTask = 0;
        int noOfRowsAffectedTaskHistory = 0;
        try
        {
            string updateString = "UPDATE t_Task SET  task_Employee_Name = '" + taskObj.Employee_AssignTo + "', task_Employee_Id ='" + taskObj.Employee_Id + "' WHERE task_Id = '" + taskObj.Id + "'";
            DBConnector dbConnector = new DBConnector();
            sqlConn = dbConnector.GetConnection;
            sqlConn.Open();
            SqlCommand sqlCom = new SqlCommand(updateString, sqlConn);
            noOfRowsAffectedTask = sqlCom.ExecuteNonQuery();

            string insertString = "INSERT INTO t_TaskHistory(taskHistory_Task_Id, taskHistory_Employee_Id_AssignedTo, taskHistory_Project_Id, taskHistory_TaskAsignDate, taskHistory_Employee_Id_AssignedBy) VALUES('"
            + taskObj.Id + "','" + taskObj.Employee_Id + "','" + taskObj.Project_Id + "','" + taskObj.StartDate + "','" + taskObj.Employee_AssigenBy + "')";
            sqlCom = new SqlCommand(insertString, sqlConn);
            noOfRowsAffectedTaskHistory = sqlCom.ExecuteNonQuery();
        }
        catch (SqlException sqlExceptionObject)
        {
            if (sqlExceptionObject.Number == 2627)  //Violation of primary key Msg no =2627
            {
                throw (new PrimaryKeyException(sqlExceptionObject));
            }
            else
            {
                throw sqlExceptionObject;
            }
        }
        catch (Exception exceptionObject)
        {
            throw exceptionObject;
        }
        finally
        {
            if (sqlConn.State == System.Data.ConnectionState.Open)
            {
                sqlConn.Close();
            }
        }

        if (noOfRowsAffectedTask > 0 && noOfRowsAffectedTaskHistory > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    /// <summary>
    /// Selects a task
    /// Exception:SqlException, Exception
    /// </summary>
    /// <param name="taskId">task id </param>
    /// <returns>task object</returns>
    public Task SelectTask(string taskId)
    {
        SqlConnection sqlConn = null;
        Task taskObject = null;
        try
        {
            string selectString = "SELECT * FROM t_Task WHERE task_Id = '" + taskId + "'";
            DBConnector dbConnector = new DBConnector();
            sqlConn = dbConnector.GetConnection;
            SqlDataAdapter sqlDataAdapterObject = new SqlDataAdapter(selectString, sqlConn);
            DataSet dataSetObject = new DataSet();
            sqlDataAdapterObject.Fill(dataSetObject);
            DataTable dataTableObject = dataSetObject.Tables[0];

            taskObject = new Task();
            taskObject.Id = dataTableObject.Rows[0]["task_Id"].ToString();
            taskObject.Name = dataTableObject.Rows[0]["task_Name"].ToString();
            taskObject.Description = dataTableObject.Rows[0]["task_Description"].ToString();
            taskObject.Project_Title = dataTableObject.Rows[0]["task_Project_Title"].ToString();
            taskObject.Project_Id = dataTableObject.Rows[0]["task_Project_Id"].ToString();
            taskObject.Employee_AssignTo = dataTableObject.Rows[0]["task_Employee_Name"].ToString();
            taskObject.Employee_Id = dataTableObject.Rows[0]["task_Employee_Id"].ToString();
            taskObject.StartDate = Convert.ToDateTime(dataTableObject.Rows[0]["task_StartDate"].ToString());
            taskObject.EstimatedTime = Convert.ToDateTime(dataTableObject.Rows[0]["task_EstimateTime"].ToString());
            taskObject.TaskStatus = dataTableObject.Rows[0]["task_Status"].ToString();
        }
        catch (SqlException sqlExceptionObject)
        {
            throw sqlExceptionObject;
        }
        catch (Exception exceptionObject)
        {
            throw exceptionObject;
        }
        finally
        {
            if (sqlConn.State == System.Data.ConnectionState.Open)
            {
                sqlConn.Close();
            }
        }
        return taskObject;
    }

    /// <summary>
    /// updates a task
    /// Exception:SqlException, Exception
    /// </summary>
    /// <param name="taskObject">task object</param>
    /// <returns>True if task updated else false</returns>
    public bool UpdateTask(Task taskObject)
    {
        SqlConnection sqlConn = null;
        int noOfRowsAffected = 0;
        try
        {
            string updateString = "UPDATE t_Task SET  task_Name = '" + taskObject.Name + "', task_Description ='" + taskObject.Description + "', task_StartDate = '" + taskObject.StartDate + "', task_EstimateTime = '" + taskObject.EstimatedTime + "'WHERE task_Id = '" + taskObject.Id + "'";
            DBConnector dbConnector = new DBConnector();
            sqlConn = dbConnector.GetConnection;
            sqlConn.Open();
            SqlCommand sqlCom = new SqlCommand(updateString, sqlConn);
            noOfRowsAffected = sqlCom.ExecuteNonQuery();
        }
        catch (SqlException sqlExceptionObject)
        {
            throw sqlExceptionObject;
        }
        catch (Exception exceptionObject)
        {
            throw exceptionObject;
        }
        finally
        {
            if (sqlConn.State == System.Data.ConnectionState.Open)
            {
                sqlConn.Close();
            }
        }

        if (noOfRowsAffected > 0)
        {
            return true;
        }
        else
        {
            return false;
        }

    }

    /// <summary>
    /// Get all the task
    /// Exception:SqlException, Exception
    /// </summary>
    /// <param name="projectId">Id of the project</param>
    /// <returns>List of tasks of the project</returns>
    public List<Task> GetListOfAllTasks()
    {
        List<Task> taskListObject = null;
        SqlConnection sqlConn = null;
        try
        {
            taskListObject = new List<Task>();
            string selectQuery = "SELECT * FROM t_Task";
            DBConnector dbConnector = new DBConnector();
            sqlConn = dbConnector.GetConnection;
            sqlConn.Open();
            SqlDataAdapter sqlDataAdapterObject = new SqlDataAdapter(selectQuery, sqlConn);
            DataSet dataSetObject = new DataSet();
            sqlDataAdapterObject.Fill(dataSetObject);
            DataTable dataTableObject = dataSetObject.Tables[0];
            foreach (DataRow dataRowObj in dataTableObject.Rows)
            {
                Task taskObject = new Task();
                taskObject.Id = dataRowObj[0].ToString();
                taskObject.Name = dataRowObj[1].ToString();

                taskListObject.Add(taskObject);
            }
        }
        catch (SqlException sqlExceptionObject)
        {
            throw sqlExceptionObject;
        }
        catch (Exception exceptionObject)
        {
            throw exceptionObject;
        }
        finally
        {
            if (sqlConn.State == System.Data.ConnectionState.Open)
            {
                sqlConn.Close();
            }
        }
        return taskListObject;
    }

    /// <summary>
    /// Selects all task of a employee/user
    /// Exception:SqlException, Exception
    /// </summary>
    /// <param name="employeeId">employeeId</param>
    /// <returns>List of all task of a user/employee</returns>
    public List<Task> GetAllOpenTasksOfAUser(string employeeId)
    {
        List<Task> taskListObj = null;
        SqlConnection sqlConn =null;
        try
        {
            taskListObj = new List<Task>();
            string selectQuery = "SELECT * FROM t_Task WHERE task_Employee_Id='" + employeeId + "' AND task_Status='Open'";
            DBConnector dbConnector = new DBConnector();
            sqlConn = dbConnector.GetConnection;
            sqlConn.Open();
            SqlDataAdapter sqlDataAdapterObject = new SqlDataAdapter(selectQuery, sqlConn);
            DataSet dataSetObject = new DataSet();
            sqlDataAdapterObject.Fill(dataSetObject);
            DataTable dataTableObject = dataSetObject.Tables[0];
            foreach (DataRow dataRowObj in dataTableObject.Rows)
            {
                Task taskObject = new Task();
                taskObject.Id = dataRowObj[0].ToString();
                taskObject.Name = dataRowObj[1].ToString();

                taskListObj.Add(taskObject);
            }
        }
        catch (SqlException sqlExceptionObject)
        {
            throw sqlExceptionObject;
        }
        catch (Exception exceptionObject)
        {
            throw exceptionObject;
        }
        finally
        {
            if (sqlConn.State == System.Data.ConnectionState.Open)
            {
                sqlConn.Close();
            }
        }
        return taskListObj;
    }

    /// <summary>
    /// Closes a task
    /// Exception:SqlException, Exception
    /// </summary>
    /// <param name="taskObject">taskObject</param>
    /// <returns>true if task closed successfully else false</returns>
    public bool CloseTask(Task taskObject)
    {
        SqlConnection sqlConn = null;
        int noOfRowsAffected = 0;
        try
        {
            string updateString = "UPDATE t_Task SET  task_Status = '" + taskObject.TaskStatus + "'WHERE task_Id = '" + taskObject.Id + "'";
            DBConnector dbConnector = new DBConnector();
            sqlConn = dbConnector.GetConnection;
            sqlConn.Open();
            SqlCommand sqlCom = new SqlCommand(updateString, sqlConn);
            noOfRowsAffected = sqlCom.ExecuteNonQuery();
        }
        catch (SqlException sqlExceptionObject)
        {
            throw sqlExceptionObject;
        }
        catch (Exception exceptionObject)
        {
            throw exceptionObject;
        }
        finally
        {
            if (sqlConn.State == System.Data.ConnectionState.Open)
            {
                sqlConn.Close();
            }
        }

        if (noOfRowsAffected > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }


}
