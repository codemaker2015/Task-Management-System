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
/// This class manages every thing about Employee
/// contains methods to manage employee related oparations
/// </summary>
public class EmployeeManager
{
	public EmployeeManager()
	{
		
	}


    /// <summary>
    /// Saves a employee information 
    /// Exception:PrimaryKeyException, SqlException, Exception
    /// PrimaryKeyException:When trying to insert data in DB with existing primary key
    /// </summary>
    /// <param name="employeeObj">employeeObject</param>
    /// <returns>save status</returns>
    public string SaveEmployee(Employee employeeObj)
    {
        bool isSaved = false;
        try
        {
            EmployeeGateway employeeGatewayObj = new EmployeeGateway();
            isSaved = employeeGatewayObj.InsertEmployee(employeeObj);
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

        if (isSaved)
        {
            return "Employee has been saved";
        }
        else
        {
            return "Employee is not saved";
        }
    }

    /// <summary>
    /// Update an employee information
    /// Exception:SqlException, Exception
    /// </summary>
    /// <param name="employeeObj">employeeObject</param>
    /// <returns>update status</returns>
    public string UpdateEmployee(Employee employeeObj)
    {
        bool isUpdate = false;
        try
        {
            EmployeeGateway employeeGatewayObj = new EmployeeGateway();
            isUpdate = employeeGatewayObj.UpdateEmployee(employeeObj);
        }
        catch (SqlException sqlExceptionObj)
        {
            throw sqlExceptionObj;
        }
        catch (Exception exceptionObj)
        {
            throw exceptionObj;
        }

        if (isUpdate)
        {
            return "Employee has been updated";
        }
        else
        {
            return "Employee is not updated";
        }
    }

    /// <summary>
    /// Get all employee(user+non user) info
    /// Exception:SqlException, Exception
    /// </summary>
    /// <returns>return list of all employees</returns>
    public List<Employee> GetAllEmployees()
    {
        try
        {
            EmployeeGateway employeeGatewayObj = new EmployeeGateway();
            return employeeGatewayObj.SelectAllEmployees();
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
    /// Select an employee by employee id
    /// Exception:SqlException, Exception
    /// </summary>
    /// <param name="employeeId">employeeID</param>
    /// <returns>employeeObject</returns>
    public Employee SelectEmployee(string employeeId)
    {
        try
        {
            EmployeeGateway employeeGateWay = new EmployeeGateway();
            return employeeGateWay.SelectEmployee(employeeId);
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
    /// Select all employee of a project
    /// Exception:SqlException, Exception
    /// </summary>
    /// <param name="projectID">projectId</param>
    /// <returns>list of all employee of the project</returns>
    public List<Employee> GetEmployeesOfTheProject(string projectID)
    {
        try
        {
            EmployeeGateway employeeGateway = new EmployeeGateway();
            return employeeGateway.GetAllEmployeesOfAProject(projectID);
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
    /// Get all employee who is not a member of the project
    /// Exception:SqlException, Exception
    /// </summary>
    /// <param name="projectID">project ID</param>
    /// <returns>list of all non member employee of the project</returns>
    public List<Employee> GetAllNonMemberEmployeeOfTheProject(string projectID)
    {
        try
        {
            EmployeeGateway employeeGatewayObject = new EmployeeGateway();
            return employeeGatewayObject.GetAllNonMemberEmployeeOfAProjrct(projectID);
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
    /// Get all employee who is a user
    /// Exception:SqlException, Exception
    /// </summary>
    /// <returns>return list of employee who is a user</returns>
    public List<Employee> GetAllUserEmployees()
    {
        try
        {
            EmployeeGateway employeeGatewayObj = new EmployeeGateway();
            return employeeGatewayObj.SelectAllUserEmployees();
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
    /// Get all NonUser employee
    /// Exception:SqlException, Exception
    /// </summary>
    /// <returns>List of all NonUser employee</returns>
    public List<Employee> GetAllNonUserEmployees()
    {
        try
        {
            EmployeeGateway employeeGatewayObj = new EmployeeGateway();
            return employeeGatewayObj.SelectAllNonUserEmployees();
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
