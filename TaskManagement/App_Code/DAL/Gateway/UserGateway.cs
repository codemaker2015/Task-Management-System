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
using System.Web.UI.MobileControls;
using System.Collections.Generic;

/// <summary>
/// Gateway of user with DB
/// </summary>
public class UserGateway
{
    public UserGateway()
    {
      
    }

    /// <summary>
    /// Insert a User information in Db
    /// Exception:PrimaryKeyException, SqlException, Exception
    /// PrimaryKeyException:When trying to insert data in DB with existing primary key
    /// </summary>
    /// <param name="userObj"></param>
    /// <returns></returns>
    public bool InsertUser(User userObj)
    {
        SqlConnection sqlConn = null;
        int noOfRowsAffectedUserTable = 0;
        int noOfRowAffectedEmployeeTable = 0;
        try
        {
            string insertString = "INSERT INTO t_User(user_Employee_Id, user_Password,user_CreationDate, user_AuthenticationMode )VALUES('" + userObj.EmployeeId + "','" + userObj.UserPassword + "','" + userObj.CreateDate + "','" + userObj.UserType + "')";
            string updateString = "UPDATE t_Employee SET  employee_AuthenticationModeFlag = 'True' WHERE employee_Id= '" + userObj.EmployeeId + "'";
            DBConnector dbConnectorObj = new DBConnector();
            sqlConn = dbConnectorObj.GetConnection;
            sqlConn.Open();
            SqlCommand sqlCom = new SqlCommand(insertString, sqlConn);
            noOfRowsAffectedUserTable = sqlCom.ExecuteNonQuery();
            sqlCom = new SqlCommand(updateString, sqlConn);
            noOfRowAffectedEmployeeTable = sqlCom.ExecuteNonQuery();
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

        if (noOfRowsAffectedUserTable > 0 && noOfRowAffectedEmployeeTable > 0)
        {
            return true;
        }
        else
        {
            return false;
        }

    }

    /// <summary>
    /// Selects all users 
    /// Exception:SqlException, Exception
    /// </summary>
    /// <returns>Data table of user</returns>
    public DataTable SelectUserTable()
    {
        DataTable dataTableObj = null;
        SqlConnection sqlConn = null;
        try
        {
        string selectQuery = "select user_Employee_Id FROM t_User";
        DBConnector dbConnectorObj = new DBConnector();
        sqlConn = new SqlConnection();
        sqlConn = dbConnectorObj.GetConnection;
        SqlDataAdapter sqlDataAdapterObj = new SqlDataAdapter(selectQuery, sqlConn);
        dataTableObj = new DataTable();
        sqlDataAdapterObj.Fill(dataTableObj);
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
        return dataTableObj;
    }

    /// <summary>
    /// Checks user id & password
    /// Exception:SqlException, Exception
    /// </summary>
    /// <param name="userId">userid</param>
    /// <param name="password">password</param>
    /// <returns>usertype</returns>
    public string CheckUser(string userId, string password)
    {
        SqlConnection sqlConn = null;
        string userType = null;
        try
        {
            string selectQuery = "select user_Employee_Id, user_Password, user_AuthenticationMode FROM t_User";
            DBConnector dbConnectorObj = new DBConnector();
            sqlConn = new SqlConnection();
            sqlConn = dbConnectorObj.GetConnection;
            SqlDataAdapter sqlDataAdapterObj = new SqlDataAdapter(selectQuery, sqlConn);
            DataSet dataSetObj = new DataSet();
            sqlDataAdapterObj.Fill(dataSetObj);
            DataTable dataTableObj = dataSetObj.Tables[0];

            foreach (DataRow dataRowObj in dataTableObj.Rows)
            {
                if ((userId == dataRowObj[0].ToString()) && (password == dataRowObj[1].ToString()))
                {
                    userType = dataRowObj[2].ToString();
                }
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
         return userType;
    }

    /// <summary>
    /// Get the user type by employeeID
    /// Exception:NonUserEmployeeException, SqlException, Exception
    /// NonUserEmployeeException:Occurs when employee is not a user
    /// </summary>
    /// <param name="employeeID">employeeID</param>
    /// <returns>user type</returns>
    public string GetUserType(string employeeID)
    {
        SqlConnection sqlConn = null;
        string userType = null;
        try
        {
            string selectQuery = "select user_AuthenticationMode FROM t_User WHERE user_Employee_Id = '"+ employeeID+"'";
            DBConnector dbConnectorObj = new DBConnector();
            sqlConn = new SqlConnection();
            sqlConn = dbConnectorObj.GetConnection;
            SqlDataAdapter sqlDataAdapterObj = new SqlDataAdapter(selectQuery, sqlConn);
            DataSet dataSetObj = new DataSet();
            sqlDataAdapterObj.Fill(dataSetObj);
            DataTable dataTableObj = dataSetObj.Tables[0];

            userType = dataTableObj.Rows[0]["user_AuthenticationMode"].ToString();
            //userType = dataTableObj.Rows[0].ToString();
            return userType;
        }
        catch (SqlException sqlExceptionObject)
        {
            throw sqlExceptionObject;
        }
        catch (Exception exceptionObject)
        {
            if (exceptionObject.Message == "There is no row at position 0.")
            {
                /*If there is no row at 0 position this mean user_AuthenticationMode is not set
                 * and employee is not a user
                 * */
                throw (new NonUserEmployeeException(exceptionObject));
            }
            else
            {
                throw exceptionObject;
            }
        }
        finally
        {
            if (sqlConn.State == System.Data.ConnectionState.Open)
            {
                sqlConn.Close();
            }
        }
    }

    /// <summary>
    /// Get all admin user of a project
    /// Exception:SqlException, Exception
    /// </summary>
    /// <param name="projectID">projectID</param>
    /// <returns>List of admin users of the project</returns>
    public List<User> GetAllAdminUserOfAProject(string projectID)
    { 
        SqlConnection sqlConn = null;
        List<User> userList = null;
        try
        {
            userList = new List<User>();
            string selectQuery = "SELECT employeeProject_Employee_Id FROM (t_EmployeeProject INNER JOIN t_User ON t_EmployeeProject.employeeProject_Employee_Id=t_User.user_Employee_Id) WHERE t_User.user_AuthenticationMode='Admin' AND t_EmployeeProject.employeeProject_Project_Id='"+projectID+"'";
            DBConnector dbConnector = new DBConnector();
            sqlConn = dbConnector.GetConnection;
            SqlDataAdapter sqlDataAdapterObj = new SqlDataAdapter(selectQuery, sqlConn);
            DataSet dataSetObj = new DataSet();
            sqlDataAdapterObj.Fill(dataSetObj);
            DataTable dataTableObj = dataSetObj.Tables[0];
            foreach (DataRow dr in dataTableObj.Rows)
            {
                User userObject = new User();
                userObject.UserId = dr[0].ToString();
                userList.Add(userObject);
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
        return userList;
    }

    /// <summary>
    /// Edit a user type
    /// Exception:SqlException, Exception
    /// </summary>
    /// <param name="userObject">userObject</param>
    /// <returns>true if user information is updated else false</returns>
    public bool EditUserType(User userObject)
    {
        SqlConnection sqlConn = null;
        int noOfRowsAffected = 0;
        try
        {
            string updateString = "UPDATE t_User SET user_AuthenticationMode='" + userObject.UserType + "' WHERE user_Employee_Id='" + userObject.UserId + "'";
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
