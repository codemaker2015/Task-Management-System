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
/// Gateway of client with DB
/// </summary>
public class ClientGateway
{
	public ClientGateway()
	{
		
	}
        
    /// <summary>
    /// Inserts a client information into DB
    /// Exception:PrimaryKeyException, SqlException, Exception
    /// PrimaryKeyException:When trying to insert data in DB with existing primary key
    /// </summary>
    /// <param name="clientObj">Client object</param>
    /// <returns>true if successfully information saved else false</returns>
    public bool InsertClient(Client clientObj)
    {
        SqlConnection sqlConn = null;
        int noOfRowsAffected = 0;
        try
        {
            string insertString = "INSERT INTO t_Client(client_ID, client_CompanyName, client_ContactPerson, client_ContactDate, client_Location, client_Phone, client_Email) VALUES('"
            + clientObj.Id + "','" + clientObj.CompanyName + "','" + clientObj.ContactPerson + "','" + clientObj.ContactDate + "','" + clientObj.Address + "','" + clientObj.PhoneNo + "','" + clientObj.Email + "')";
            DBConnector dbConnector = new DBConnector();
            sqlConn = dbConnector.GetConnection;
            sqlConn.Open();
            SqlCommand sqlCom = new SqlCommand(insertString, sqlConn);
            noOfRowsAffected = sqlCom.ExecuteNonQuery();
        }
        catch (SqlException sqlExceptionObj)
        {
            if (sqlExceptionObj.Number == 2627)     //Violation of primary key Msg no =2627
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
    /// Select all clients from DB
    /// Exception:SqlException, Exception
    /// </summary>
    /// <returns>returns list of clients</returns>
    public List<Client> SelectAllClients()
    {
        SqlConnection sqlConn = null;
        SqlDataAdapter sqlDataAdapterObject = null;
        List<Client> clientList = null;

        try
        {
            clientList = new List<Client>();
            string selectQuery = "SELECT client_ID, client_CompanyName, client_ContactPerson, client_ContactDate, client_Location, client_Phone, client_Email FROM t_Client";
            DBConnector dbConnector = new DBConnector();
            sqlConn = dbConnector.GetConnection;
            sqlConn.Open();
            sqlDataAdapterObject = new SqlDataAdapter(selectQuery, sqlConn);
            DataSet dataSetObject = new DataSet();
            sqlDataAdapterObject.Fill(dataSetObject);
            DataTable dataTableObject = dataSetObject.Tables[0];
            foreach (DataRow dataRowObj in dataTableObject.Rows)
            {
                Client clientObj = new Client();
                clientObj.Id = dataRowObj[0].ToString();
                clientObj.CompanyName = dataRowObj[1].ToString();
                clientList.Add(clientObj);
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
            if (sqlDataAdapterObject != null)
            {
                if (sqlConn.State == System.Data.ConnectionState.Open)
                {
                    sqlConn.Close();
                }
            }
        }
        return clientList;
    }

    /// <summary>
    /// Select all clients from DB
    /// Exception:SqlException, Exception
    /// </summary>
    /// <returns>DataTable of all clients information</returns>
    public DataTable GetClientTable()
    {
        SqlConnection sqlConn = null;
        SqlDataAdapter sqlDataAdapterObj = null;
        DataTable dataTableObj;

        try
        {
            string selectQuery = "SELECT client_ID, client_CompanyName, client_ContactPerson, client_ContactDate, client_Location, client_Phone, client_Email FROM t_Client";
            DBConnector dbConnector = new DBConnector();
            sqlConn = dbConnector.GetConnection;
            sqlConn.Open();
            sqlDataAdapterObj = new SqlDataAdapter(selectQuery, sqlConn);
            dataTableObj = new DataTable();
            sqlDataAdapterObj.Fill(dataTableObj);
        }
        catch (SqlException sqlExceptionObject)
        {
            throw sqlExceptionObject;
        }
        catch (Exception exceptionObj)
        {
            throw exceptionObj;
        }
        finally
        {
            if (sqlDataAdapterObj != null)
            {
                if (sqlConn.State == System.Data.ConnectionState.Open)
                {
                    sqlConn.Close();
                }
            }
        }

        return dataTableObj;
    }

    /// <summary>
    /// Update a client information
    /// Exception:SqlException, Exception
    /// </summary>
    /// <param name="clientObject">clientObject</param>
    /// <returns>true if client information updated successfully else false</returns>
    public bool UpdateClient(Client clientObject)
    {
        SqlConnection sqlConn = null;
        int noOfRowsAffected = 0;

        try
        {
            string updateString = "UPDATE t_Client SET  client_CompanyName = '" + clientObject.CompanyName + "', client_ContactPerson ='" + clientObject.ContactPerson + "', client_ContactDate = '" + clientObject.ContactDate + "', client_Location = '" + clientObject.Address + "', client_Phone = '" + clientObject.PhoneNo + "', client_Email = '" + clientObject.Email + "' WHERE client_Id = '" + clientObject.Id + "'";
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
    /// Select a client from DB by clients id
    /// Exception:SqlException, Exception
    /// </summary>
    /// <param name="clientId">client id </param>
    /// <returns>clientObject</returns>
    public Client SelectClient(string clientId)
    {
        SqlConnection sqlConn = null;
        SqlDataAdapter sqlDataAdapterObject = null;
        DataTable dataTableObject = null;

        try
        {
            string selectString = "SELECT * FROM t_Client WHERE client_Id = '" + clientId + "'";
            DBConnector dbConnector = new DBConnector();
            sqlConn = dbConnector.GetConnection;
            sqlDataAdapterObject = new SqlDataAdapter(selectString, sqlConn);
            DataSet dataSetObject = new DataSet();
            sqlDataAdapterObject.Fill(dataSetObject);
            dataTableObject = dataSetObject.Tables[0];
            Client clientObject = new Client();
            clientObject.CompanyName = dataTableObject.Rows[0]["client_CompanyName"].ToString();
            clientObject.ContactPerson = dataTableObject.Rows[0]["client_ContactPerson"].ToString();
            clientObject.Address = dataTableObject.Rows[0]["client_Location"].ToString();
            clientObject.ContactDate = Convert.ToDateTime(dataTableObject.Rows[0]["client_ContactDate"].ToString());
            clientObject.PhoneNo = dataTableObject.Rows[0]["client_Phone"].ToString();
            clientObject.Email = dataTableObject.Rows[0]["client_Email"].ToString();
            return clientObject;
        }
        catch (SqlException sqlExceptionObject)
        {
            throw sqlExceptionObject;
        }
        catch (Exception exceptionObj)
        {
            throw exceptionObj;
        }
        finally
        {
            if (sqlDataAdapterObject != null)
            {
                if (sqlConn.State == System.Data.ConnectionState.Open)
                {
                    sqlConn.Close();
                }
            }
        }

       
    }
     
}
