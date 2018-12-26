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
/// Gateway of employee with DB
/// </summary>
public class EmployeeGateway
{
	public EmployeeGateway()
	{
		
	}

    /// <summary>
    /// Insert a employee information into DB & set as non user
    /// Exception:PrimaryKeyException, SqlException, Exception
    /// PrimaryKeyException:When trying to insert data in DB with existing primary key
    /// </summary>
    /// <param name="employeeObject">employeeObject</param>
    /// <returns>true if employee infomation saved successfully else false</returns>
    public bool InsertEmployee(Employee employeeObject)
    {
        SqlConnection sqlConn = null;
        int noOfRowsAffected = 0;
        try
        {
            string insertString = "INSERT INTO t_Employee(employee_Id, employee_Name, employee_Address, employee_PhoneNo, employee_Email, employee_JoinDate, employee_DateOfBirth, employee_AuthenticationModeFlag) VALUES('" + employeeObject.ID + "','" + employeeObject.Name + "','" + employeeObject.Address + "','" + employeeObject.PhoneNo + "','" + employeeObject.Email + "','" + employeeObject.JoiningDate + "','" + employeeObject.DOB + "', 'False')";
            DBConnector dbConnector = new DBConnector();
            sqlConn = dbConnector.GetConnection;
            sqlConn.Open();
            SqlCommand sqlCom = new SqlCommand(insertString, sqlConn);
            noOfRowsAffected = sqlCom.ExecuteNonQuery();
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
    /// Update a employee information
    /// Exception:SqlException, Exception
    /// </summary>
    /// <param name="employeeObject">employeeObject</param>
    /// <returns>true if employee information updated successfully else false</returns>
    public bool UpdateEmployee(Employee employeeObject)
    {
        SqlConnection sqlConn = null;
        int noOfRowsAffected = 0;
        try
        {
            string updateString = "UPDATE t_Employee SET  employee_Name = '" + employeeObject.Name + "', employee_Address = '" + employeeObject.Address + "', employee_PhoneNo = '" + employeeObject.PhoneNo + "', employee_Email = '" + employeeObject.Email + "', employee_JoinDate = '" + employeeObject.JoiningDate + "', employee_DateOfBirth = '" + employeeObject.DOB + "' WHERE employee_Id = '" + employeeObject.ID + "'";
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
    /// Select an employee from DB by employee id
    /// Exception:SqlException, Exception
    /// </summary>
    /// <param name="employeeId">employee id</param>
    /// <returns>employeeObject</returns>
    public Employee SelectEmployee(string employeeId)
    {
        SqlConnection sqlConn = null;
        try
        {
            string selectString = "SELECT * FROM t_Employee WHERE employee_Id = '" + employeeId + "'";
            DBConnector dbConnector = new DBConnector();
            sqlConn = dbConnector.GetConnection;
            SqlDataAdapter sqlDataAdapterObject = new SqlDataAdapter(selectString, sqlConn);
            DataSet dataSetObject = new DataSet();
            sqlDataAdapterObject.Fill(dataSetObject);
            DataTable dataTableObject = dataSetObject.Tables[0];
            Employee employeeObject = new Employee();
            employeeObject.Name = dataTableObject.Rows[0]["employee_Name"].ToString();
            employeeObject.Address = dataTableObject.Rows[0]["employee_Address"].ToString();
            employeeObject.PhoneNo = dataTableObject.Rows[0]["employee_PhoneNO"].ToString();
            employeeObject.Email = dataTableObject.Rows[0]["employee_Email"].ToString();
            employeeObject.JoiningDate = Convert.ToDateTime(dataTableObject.Rows[0]["employee_JoinDate"].ToString());
            employeeObject.DOB = Convert.ToDateTime(dataTableObject.Rows[0]["employee_DateOfBirth"].ToString());
            return employeeObject;
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
    }

    /// <summary>
    /// Select all employee from DB(user+non user)
    /// Exception:SqlException, Exception
    /// </summary>
    /// <returns>list of all employee </returns>
    public List<Employee> SelectAllEmployees()
    {
        SqlConnection sqlConn = null;
        try
        {
            List<Employee> employeeList = new List<Employee>();
            string selectQuery = "SELECT employee_Id ,employee_Name,employee_Address,employee_PhoneNo,employee_Email,employee_JoinDate,employee_DateOfBirth FROM t_Employee";
            DBConnector dbConnector = new DBConnector();
            sqlConn = dbConnector.GetConnection;
            sqlConn.Open();
            SqlDataAdapter sqlDataAdapterObj = new SqlDataAdapter(selectQuery, sqlConn);
            DataSet dsObj = new DataSet();
            sqlDataAdapterObj.Fill(dsObj);
            DataTable dtObj = dsObj.Tables[0];
            foreach (DataRow drObj in dtObj.Rows)
            {
                Employee employeeObj = new Employee();
                employeeObj.ID = drObj[0].ToString();
                employeeObj.Name = drObj[1].ToString();
                employeeList.Add(employeeObj);
            }
            return employeeList;
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
    }

    /// <summary>
    /// Select all employee who is a user(admin/normal)
    /// Exception:SqlException, Exception
    /// </summary>
    /// <returns>List of all employees who is a user</returns>
    public List<Employee> SelectAllUserEmployees()
    {
        SqlConnection sqlConn = null;
        try
        {
            List<Employee> employeeList = new List<Employee>();
            string selectQuery = "SELECT employee_Id ,employee_Name,employee_Address,employee_PhoneNo,employee_Email,employee_JoinDate,employee_DateOfBirth FROM t_Employee WHERE employee_AuthenticationModeFlag='True'";
            DBConnector dbConnector = new DBConnector();
            sqlConn = dbConnector.GetConnection;
            sqlConn.Open();
            SqlDataAdapter sqlDataAdapterObj = new SqlDataAdapter(selectQuery, sqlConn);
            DataSet dsObj = new DataSet();
            sqlDataAdapterObj.Fill(dsObj);
            DataTable dtObj = dsObj.Tables[0];
            foreach (DataRow drObj in dtObj.Rows)
            {
                Employee employeeObj = new Employee();
                employeeObj.ID = drObj[0].ToString();
                employeeObj.Name = drObj[1].ToString();
                employeeList.Add(employeeObj);
            }
            return employeeList;
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
    }

    /// <summary>
    /// Select all NonUser employee
    /// Exception:SqlException, Exception
    /// </summary>
    /// <returns>list of NonUser Employee</returns>
    public List<Employee> SelectAllNonUserEmployees()
    {
        SqlConnection sqlConn = null;
        try
        {
            List<Employee> employeeList = new List<Employee>();
            string selectQuery = "SELECT employee_Id ,employee_Name,employee_Address,employee_PhoneNo,employee_Email,employee_JoinDate,employee_DateOfBirth FROM t_Employee WHERE employee_AuthenticationModeFlag='False'";
            DBConnector dbConnector = new DBConnector();
            sqlConn = dbConnector.GetConnection;
            sqlConn.Open();
            SqlDataAdapter sqlDataAdapterObj = new SqlDataAdapter(selectQuery, sqlConn);
            DataSet dsObj = new DataSet();
            sqlDataAdapterObj.Fill(dsObj);
            DataTable dtObj = dsObj.Tables[0];
            foreach (DataRow drObj in dtObj.Rows)
            {
                Employee employeeObj = new Employee();
                employeeObj.ID = drObj[0].ToString();
                employeeObj.Name = drObj[1].ToString();
                employeeList.Add(employeeObj);
            }
            return employeeList;
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
    }

    /// <summary>
    /// Select all employee
    /// Exception:SqlException, Exception
    /// </summary>
    /// <returns>data table of employee</returns>
    public DataTable GetEmployeeTable()
    {
        SqlConnection sqlConn = null;
        try
        {
            string selectQuery = " SELECT employee_Id, employee_Name,employee_Address,employee_phoneNo ,employee_Email, employee_JoinDate,employee_DateOfBirth  FROM t_Employee";
            DBConnector dbConnector = new DBConnector();
            sqlConn = dbConnector.GetConnection;
            sqlConn.Open();
            SqlDataAdapter sqlDataAdapterObj = new SqlDataAdapter(selectQuery, sqlConn);
            DataTable dataTableObj = new DataTable();
            sqlDataAdapterObj.Fill(dataTableObj);
            return dataTableObj;
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
    }

    /// <summary>
    /// Select all employee of a project by projectId
    /// Exception:SqlException, Exception
    /// </summary>
    /// <param name="projectID">projectId</param>
    /// <returns>List of all employees of a project</returns>
    public List<Employee> GetAllEmployeesOfAProject(string projectID)
    {
        SqlConnection sqlConn = null;
        try
        {
            List<Employee> employeeList = new List<Employee>();
            string selectQuery = "Select employeeProject_Employee_Id, employee_Name from ( t_EmployeeProject inner join t_Employee on t_EmployeeProject.employeeProject_Employee_Id = t_Employee.employee_Id ) where t_EmployeeProject.employeeProject_Project_Id = '" + projectID + "';";
            DBConnector dbConnector = new DBConnector();
            sqlConn = dbConnector.GetConnection;
            sqlConn.Open();
            SqlDataAdapter sqlDataAdapterObj = new SqlDataAdapter(selectQuery, sqlConn);
            DataSet dsObj = new DataSet();
            sqlDataAdapterObj.Fill(dsObj);
            DataTable dtObj = dsObj.Tables[0];
            foreach (DataRow drObj in dtObj.Rows)
            {
                Employee employeeObj = new Employee();
                employeeObj.ID = drObj[0].ToString();
                employeeObj.Name = drObj[1].ToString();
                employeeList.Add(employeeObj);
            }
            return employeeList;
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
    }

    /// <summary>
    /// Get all employee who is not a member of the project
    /// Exception:SqlException, Exception
    /// </summary>
    /// <param name="projectID"></param>
    /// <returns></returns>
    public List<Employee> GetAllNonMemberEmployeeOfAProjrct(string projectID)
    {
        SqlConnection sqlConn = null;
        try
        {
            List<Employee> employeeList = new List<Employee>();
            string selectQuery = "Select employee_Id, employee_Name From t_Employee where  employee_Id not in (Select employeeProject_Employee_Id from t_EmployeeProject where employeeProject_Project_Id='"+projectID+"')";
            DBConnector dbConnector = new DBConnector();
            sqlConn = dbConnector.GetConnection;
            sqlConn.Open();
            SqlDataAdapter sqlDataAdapterObj = new SqlDataAdapter(selectQuery, sqlConn);
            DataSet dsObj = new DataSet();
            sqlDataAdapterObj.Fill(dsObj);
            DataTable dtObj = dsObj.Tables[0];
            foreach (DataRow drObj in dtObj.Rows)
            {
                Employee employeeObj = new Employee();
                employeeObj.ID = drObj[0].ToString();
                employeeObj.Name = drObj[1].ToString();
                employeeList.Add(employeeObj);
            }
            return employeeList;
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
    
    }

}
