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
/// This class manages every thing about User
/// contains methods to manage user related oparations
/// </summary>
public class UserManager
{
	public UserManager()
	{
	}

    /// <summary>
    /// Creates a user
    /// Exception:PrimaryKeyException, SqlException, Exception
    /// PrimaryKeyException:When trying to insert data in DB with existing primary key
    /// </summary>
    /// <param name="userObj">user object</param>
    /// <returns>User creation status</returns>
    public string CreateUser(User userObj)
    {
        bool isCreated = false;
        try
        {
            UserGateway userGatewayObj = new UserGateway();
            isCreated = userGatewayObj.InsertUser(userObj);
        }
        catch (PrimaryKeyException primaryKeyExceptionObject)
        {
            throw primaryKeyExceptionObject;
        }
        catch (SqlException sqlExceptionObj)
        {
            throw sqlExceptionObj;
        }
        catch (Exception exceptionObj)
        {
            throw exceptionObj;
        }

        if (isCreated)
        {
            return "User created successfully! ";
        }
        else
        {
            return "User is not created";
        }
    }

    /// <summary>
    /// Checks userId and password if & return user type
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="password"></param>
    /// <returns></returns>
    public string CheckUserIdAndPassword(string userId, string password)
    {
        try
        {
            UserGateway userGatewayObj = new UserGateway();
            return userGatewayObj.CheckUser(userId, password);
        }
        catch (SqlException sqlExceptionObj)
        {
            throw sqlExceptionObj;
        }
        catch (Exception exceptionObj)
        {
            throw exceptionObj;
        }
    }


    /// <summary>
    /// Select all user
    /// Exception:SqlException, Exception
    /// </summary>
    /// <returns>Data table of all user</returns>
    public DataTable GetUserTable()
    {
        try
        {
            UserGateway userGatewayObj = new UserGateway();
            return userGatewayObj.SelectUserTable();
        }
        catch (SqlException sqlExceptionObj)
        {
            throw sqlExceptionObj;
        }
        catch (Exception exceptionObj)
        {
            throw exceptionObj;
        }
    }

    /// <summary>
    /// Check is user a admin or not
    /// Exception:NonUserEmployeeException, SqlException, Exception
    /// NonUserEmployeeException:Occurs when employee is not a user
    /// </summary>
    /// <param name="employeeID">employeeID</param>
    /// <returns>true id user is a admin else false </returns>
    public bool IsAdmin(string employeeID)
    {
        try
        {
            UserGateway userGatewayObject = new UserGateway();
            string userType = userGatewayObject.GetUserType(employeeID);
            if (userType == "Admin")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        catch (NonUserEmployeeException nonUserEmployeeExceptionObject)
        {
            throw nonUserEmployeeExceptionObject;
        }
        catch (SqlException sqlExceptionObj)
        {
            throw sqlExceptionObj;
        }
        catch (Exception exceptionObj)
        {
            throw exceptionObj;
        }
    }

    /// <summary>
    /// Get user type
    /// Exception:NonUserEmployeeException, SqlException, Exception
    /// NonUserEmployeeException:Occurs when employee is not a user
    /// </summary>
    /// <param name="employeeID">employee ID</param>
    /// <returns>user type</returns>
    public string GetUserType(string employeeID)
    {
        try
        {
            UserGateway userGatewayObject = new UserGateway();
            return userGatewayObject.GetUserType(employeeID);
        }
        catch (NonUserEmployeeException nonUserEmployeeExceptionObject)
        {
            throw nonUserEmployeeExceptionObject;
        }
        catch (SqlException sqlExceptionObj)
        {
            throw sqlExceptionObj;
        }
        catch (Exception exceptionObj)
        {
            throw exceptionObj;
        }
    }

    /// <summary>
    /// Edit a user type
    /// Exception:OnlyOneAdminException, SqlException, Exception
    /// OnlyOneAdminException:occurs when user is the only admin of some project
    /// </summary>
    /// <param name="userObject">userObject</param>
    /// <returns>user edit exception</returns>
    public string EditUserType(User userObject)
    {
        try
        {
            UserGateway userGatewayObject = new UserGateway();
            if (IsAdmin(userObject.UserId))
            {
                string projectThatHaveOneAdmin = GetAllProjectOfAdminThatHaveOneAdmin(userObject.UserId);

                if (projectThatHaveOneAdmin != "")
                {
                        //i.e. Atleast one of admin's projects have only one admin that is admin him self
                        //throw an exception with Project ID tells that user cant be modify because No other admin to close this project
                    throw (new OnlyOneAdminException(projectThatHaveOneAdmin, new Exception()));
                }
            }

            bool isUpdated = userGatewayObject.EditUserType(userObject);

            if (isUpdated)
            {
                return userObject.UserId + " is now " + userObject.UserType;
            }
            else
            {
                return "User type is not updated ";
            }
        }
        catch (OnlyOneAdminException onlyOneAdminExceptionObject)
        {
            throw onlyOneAdminExceptionObject;
        }
        catch (SqlException sqlExceptionObj)
        {
            throw sqlExceptionObj;
        }
        catch (Exception exceptionObj)
        {
            throw exceptionObj;
        }
    }

    /// <summary>
    /// Checks if the employee is the only admin member of his projects
    /// Exception:SqlException, Exception
    /// </summary>
    /// <param name="employee">employeeID</param>
    /// <returns>string that contains all the projectID which dont have more than 1 admin</returns>
    private string GetAllProjectOfAdminThatHaveOneAdmin(string employeeID)
    {
        try
        {
            ProjectManager projectManagerObject = new ProjectManager();
            List<Project> listOfOpenProjectOfUser = projectManagerObject.GetAllOpenProjects(employeeID);
            string projectThatHaveOneAdmin = "";
            foreach (Project projectObject in listOfOpenProjectOfUser)
            {
                UserGateway userGatewayObject = new UserGateway();
                int numberOfAdminOfTheProject = userGatewayObject.GetAllAdminUserOfAProject(projectObject.ID).Count;
                
                if (numberOfAdminOfTheProject < 2)
                {
                    projectThatHaveOneAdmin += projectObject.ID + ",";
                }
            }

            if (projectThatHaveOneAdmin != "")
            {
                projectThatHaveOneAdmin = projectThatHaveOneAdmin.Substring(0, projectThatHaveOneAdmin.Length - 1);
                        //Removes last coma
            }
            return projectThatHaveOneAdmin;
        }
        catch (SqlException sqlExceptionObj)
        {
            throw sqlExceptionObj;
        }
        catch (Exception exceptionObj)
        {
            throw exceptionObj;
        }
    }
}
