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
/// Gateway of project with DB
/// </summary>
public class ProjectGateway
{
	public ProjectGateway()
	{
		
	}

    /// <summary>
    /// Insert a project in DB
    /// Exception:PrimaryKeyException, SqlException, Exception
    /// PrimaryKeyException:When trying to insert data in DB with existing primary key
    /// </summary>
    /// <param name="projectObj">projectObj</param>
    /// <returns>return true if project is saved in DB else false</returns>
    public bool InsertProject(Project projectObj)
    {
        int noOfRowsAffectedPro = 0;
        int noOfRowsAffectedEP = 0;
        SqlConnection sqlConn = null;
        string[] projectEmployeeIDs = projectObj.Employee_Id.Split(Convert.ToChar(","));

        try
        {
            string insertString = "INSERT INTO t_Project(project_Id, project_Title, project_Description, project_StartTime, project_EstimateTime, project_Client_ID, project_Status) VALUES('"
            + projectObj.ID + "','" + projectObj.Title + "','" + projectObj.Description + "','" + projectObj.StartDate + "','" + projectObj.EstimateTime + "','" + projectObj.ClientId + "','" + projectObj.Status + "')";

            DBConnector dbConnector = new DBConnector();
            sqlConn = dbConnector.GetConnection;
            sqlConn.Open();
            SqlCommand sqlCom = new SqlCommand(insertString, sqlConn);
            noOfRowsAffectedPro = sqlCom.ExecuteNonQuery();

            foreach (string employeeID in projectEmployeeIDs)
            {
                string insertSecondString = "INSERT INTO t_EmployeeProject(employeeProject_Project_Id, employeeProject_Employee_Id, employeeProject_AssigenDate) VALUES('"
                + projectObj.ID + "','" + employeeID + "','" + System.DateTime.Now.ToString() + "')";
                sqlCom = new SqlCommand(insertSecondString, sqlConn);
                noOfRowsAffectedEP += sqlCom.ExecuteNonQuery();
            }
        }
        catch (SqlException sqlExceptionObj)
        {
            if (sqlExceptionObj.Number == 2627)  //Violation of primary key Msg no =2627
            {
                throw (new PrimaryKeyException(sqlExceptionObj));
            }
            else
            {
                throw sqlExceptionObj;
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

        if (noOfRowsAffectedPro > 0 && noOfRowsAffectedEP > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    /// <summary>
    /// Add employee(s) to existing project
    /// Exception:PrimaryKeyException, SqlException, Exception
    /// PrimaryKeyException:When trying to insert data in DB with existing primary key
    /// </summary>
    /// <param name="projectObj">projectObject</param>
    /// <returns>true if employee added else false</returns>
    public bool AddEmployeeToProject(Project projectObj)
    {
        int noOfRowsAffected = 0;
        SqlConnection sqlConn = null;
        string[] projectEmployeeIDs = projectObj.Employee_Id.Split(Convert.ToChar(","));

        try
        {
            DBConnector dbConnector = new DBConnector();
            sqlConn = dbConnector.GetConnection;
            sqlConn.Open();
            SqlCommand sqlCom = null;
            foreach (string employeeID in projectEmployeeIDs)
            {
                string insertString = "INSERT INTO t_EmployeeProject(employeeProject_Project_Id, employeeProject_Employee_Id, employeeProject_AssigenDate) VALUES('"
                + projectObj.ID + "','" + employeeID + "','" + System.DateTime.Now.ToString() + "')";
                sqlCom = new SqlCommand(insertString, sqlConn);
                noOfRowsAffected += sqlCom.ExecuteNonQuery();
            }
        }
        catch (SqlException sqlExceptionObj)
        {
            if (sqlExceptionObj.Number == 2627)  //Violation of primary key Msg no =2627
            {
                throw (new PrimaryKeyException(sqlExceptionObj));
            }
            else
            {
                throw sqlExceptionObj;
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
    /// Remove an employee from project
    /// Exception:SqlException, Exception
    /// </summary>
    /// <param name="projectID">projectID</param>
    /// <param name="EmployeeID">employeeID</param>
    /// <returns>true if employee removed else false</returns>
    public bool RemoveEmployeeFromProject(Project projectObject)
    {
        SqlConnection sqlConn = null;
        int noOfRowsAffected = 0;
        try
        {
            DBConnector dbConnector = new DBConnector();
            sqlConn = dbConnector.GetConnection;
            sqlConn.Open();
            SqlCommand sqlCom = null;
            string deleteString = "DELETE FROM t_EmployeeProject WHERE employeeProject_Project_Id='" + projectObject.ID + "' AND employeeProject_Employee_Id= '" + projectObject.Employee_Id + "'";
            sqlCom = new SqlCommand(deleteString, sqlConn);
            noOfRowsAffected = sqlCom.ExecuteNonQuery();
        }
        catch (SqlException sqlExceptionObj)
        {
            throw sqlExceptionObj;
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
    /// Select all project
    /// Exception:SqlException, Exception
    /// </summary>
    /// <returns>data table of all project</returns>
    public DataTable GetProjectTable()
    {
        SqlConnection sqlConn = null;
        DataTable dataTableObj = null;
        try
        {
            string selectQuery = "SELECT project_Id, project_Title, project_Description, project_StartTime, project_EstimateTime, project_Client_ID, project_Status FROM t_Project";
            DBConnector dbConnector = new DBConnector();
            sqlConn = dbConnector.GetConnection;
            sqlConn.Open();
            SqlDataAdapter sqlDataAdapterObj = new SqlDataAdapter(selectQuery, sqlConn);
            dataTableObj = new DataTable();
            sqlDataAdapterObj.Fill(dataTableObj);
        }
        catch (SqlException sqlExceptionObj)
        {
            throw sqlExceptionObj;
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
        return dataTableObj;
    }

    /// <summary>
    /// Select all open projects
    /// Exception:SqlException, Exception
    /// </summary>
    /// <returns>list of all open projects</returns>
    public List<Project> SelectAllOpenProjects()
    {
        SqlConnection sqlConn = null;
        List<Project> projectList = null;
        try
        {
            projectList = new List<Project>();
            string selectQuery = "SELECT * FROM t_Project WHERE project_Status='Open'";
            DBConnector dbConnector = new DBConnector();
            sqlConn = dbConnector.GetConnection;
            SqlDataAdapter sqlDataAdapterObj = new SqlDataAdapter(selectQuery, sqlConn);
            DataSet dataSetObj = new DataSet();
            sqlDataAdapterObj.Fill(dataSetObj);
            DataTable dataTableObj = dataSetObj.Tables[0];
            foreach (DataRow dr in dataTableObj.Rows)
            {
                Project projectObj = new Project();
                projectObj.ID = dr[0].ToString();
                projectObj.Title = dr[1].ToString();
                projectList.Add(projectObj);
            }
        }
        catch (SqlException sqlExceptionObj)
        {
            throw sqlExceptionObj;
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
        return projectList;
    }

    /// <summary>
    /// Select all open project of a employee
    /// Exception:SqlException, Exception
    /// </summary>
    /// <param name="employeeID">employeeID</param>
    /// <returns>List of all open project of employee</returns>
    public List<Project> SelectAllOpenProjects(string employeeID)
    {
        SqlConnection sqlConn = null;
        List<Project> projectList = null;
        try
        {
            projectList = new List<Project>();
            string selectQuery = "select employeeProject_Project_Id, project_Title From t_EmployeeProject INNER JOIN t_Project ON t_EmployeeProject.employeeProject_Project_Id =t_Project.project_Id WHERE t_EmployeeProject.employeeProject_Employee_Id='" + employeeID + "' AND t_Project.project_Status='Open'";
            DBConnector dbConnector = new DBConnector();
            sqlConn = dbConnector.GetConnection;
            SqlDataAdapter sqlDataAdapterObj = new SqlDataAdapter(selectQuery, sqlConn);
            DataSet dataSetObj = new DataSet();
            sqlDataAdapterObj.Fill(dataSetObj);
            DataTable dataTableObj = dataSetObj.Tables[0];
            foreach (DataRow dr in dataTableObj.Rows)
            {
                Project projectObj = new Project();
                projectObj.ID = dr[0].ToString();
                projectObj.Title = dr[1].ToString();
                projectList.Add(projectObj);
            }
        }
        catch (SqlException sqlExceptionObj)
        {
            throw sqlExceptionObj;
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
        return projectList;
    }

   /// <summary>
   /// Select a project by project Id
   /// Exception:SqlException, Exception
   /// </summary>
   /// <param name="projectId">projectId</param>
   /// <returns>projectObject</returns>
    public Project SelectProject(string projectId)
    {
        SqlConnection sqlConn = null;
        Project projectObject = null;
        try
        {
            string selectString = "SELECT * FROM t_Project WHERE project_Id = '" + projectId + "'";
            DBConnector dbConnector = new DBConnector();
            sqlConn = dbConnector.GetConnection;
            SqlDataAdapter sqlDataAdapterObject = new SqlDataAdapter(selectString, sqlConn);
            DataSet dataSetObject = new DataSet();
            sqlDataAdapterObject.Fill(dataSetObject);

            DataTable dataTableObject = dataSetObject.Tables[0];
            projectObject = new Project();
            projectObject.ID = dataTableObject.Rows[0]["project_Id"].ToString();
            projectObject.Title = dataTableObject.Rows[0]["project_Title"].ToString();
            projectObject.Description = dataTableObject.Rows[0]["project_Description"].ToString();
            projectObject.StartDate = Convert.ToDateTime(dataTableObject.Rows[0]["project_StartTime"].ToString());
            projectObject.EstimateTime = Convert.ToDateTime(dataTableObject.Rows[0]["project_EstimateTime"].ToString());
            projectObject.ClientId = dataTableObject.Rows[0]["project_Client_ID"].ToString();
            projectObject.Status = dataTableObject.Rows[0]["project_Status"].ToString();
        }
        catch (SqlException sqlExceptionObj)
        {
            throw sqlExceptionObj;
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
        return projectObject;
    }

    /// <summary>
    /// Update a project into DB
    /// Exception:SqlException, Exception
    /// </summary>
    /// <param name="projectObject">projectObject</param>
    /// <returns>true if project is updated else false</returns>
    public bool UpdateProject(Project projectObject)
    {
        SqlConnection sqlConn = null;
        int noOfRowsAffected = 0;
        try
        {
            string updateString = "UPDATE t_Project SET  project_Title = '" + projectObject.Title + "', project_Description ='" + projectObject.Description + "', project_StartTime = '" + projectObject.StartDate + "', project_EstimateTime = '" + projectObject.EstimateTime + "', project_Client_ID = '" + projectObject.ClientId + "', project_Status = '" + projectObject.Status + "' WHERE project_Id = '" + projectObject.ID + "'";
            DBConnector dbConnector = new DBConnector();
            sqlConn = dbConnector.GetConnection;
            sqlConn.Open();
            SqlCommand sqlCom = new SqlCommand(updateString, sqlConn);
            noOfRowsAffected = sqlCom.ExecuteNonQuery();
        }
        catch (SqlException sqlExceptionObj)
        {
            throw sqlExceptionObj;
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
    /// select all project of a user
    /// Exception:SqlException, Exception
    /// </summary>
    /// <param name="employeeId">employee/user Id</param>
    /// <returns>List of all project of user</returns>
    public List<Project> GetProjectsOfUser(string employeeId)
    {
        SqlConnection sqlConn = null;
        List<Project> projectList = null;
        try
        {
            projectList = new List<Project>();
            string selectQuery = "select employeeProject_Project_Id, project_Title From t_EmployeeProject INNER JOIN t_Project ON t_EmployeeProject.employeeProject_Project_Id =t_Project.project_Id WHERE t_EmployeeProject.employeeProject_Employee_Id='" + employeeId + "'";
            DBConnector dbConnector = new DBConnector();
            sqlConn = dbConnector.GetConnection;
            SqlDataAdapter sqlDataAdapterObj = new SqlDataAdapter(selectQuery, sqlConn);
            DataSet dataSetObj = new DataSet();
            sqlDataAdapterObj.Fill(dataSetObj);
            DataTable dataTableObj = dataSetObj.Tables[0];
            foreach (DataRow dr in dataTableObj.Rows)
            {
                Project projectObj = new Project();
                projectObj.ID = dr[0].ToString();
                projectObj.Title = dr[1].ToString();
                projectList.Add(projectObj);
            }
        }
        catch (SqlException sqlExceptionObj)
        {
            throw sqlExceptionObj;
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
        return projectList;
    }

    /// <summary>
    /// Close a project
    /// Exception:SqlException, Exception
    /// </summary>
    /// <param name="projectObject">projectObject</param>
    /// <returns>true if project is closed else false</returns>
    public bool CloseProject(Project projectObject)
    {
        SqlConnection sqlConn = null;
        int noOfRowsAffected = 0;
        try
        {
            string updateString = "UPDATE t_Project SET project_Status = '" + projectObject.Status + "' WHERE project_Id = '" + projectObject.ID + "'";
            DBConnector dbConnector = new DBConnector();
            sqlConn = dbConnector.GetConnection;
            sqlConn.Open();
            SqlCommand sqlCom = new SqlCommand(updateString, sqlConn);
            noOfRowsAffected = sqlCom.ExecuteNonQuery();
        }
        catch (SqlException sqlExceptionObj)
        {
            throw sqlExceptionObj;
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
