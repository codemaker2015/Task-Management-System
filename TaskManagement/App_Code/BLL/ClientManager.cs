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
/// This class manages every thing about client
/// </summary>
public class ClientManager
{
	public ClientManager()
	{
		
	}

    /// <summary>
    /// Selects all client
    /// Exception:SqlException, Exception
    /// </summary>
    /// <returns>List of clients</returns>
    public List<Client> GetAllClient()
    {
        try
        {
            ClientGateway clientGetwayObject = new ClientGateway();
            return clientGetwayObject.SelectAllClients();
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
    /// Selects all client from DB
    /// Exception:SqlException, Exception
    /// </summary>
    /// <returns>DataTable of all clients information</returns>
    public DataTable GetClientTable()
    {
        try
        {
            ClientGateway clientGatewayObject = new ClientGateway();
            return clientGatewayObject.GetClientTable();
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
    /// Selects a client from DB by clients id
    /// Exception:SqlException, Exception
    /// </summary>
    /// <param name="clientId">clients id</param>
    /// <returns>clientObject</returns>
    public Client SelectClient(string clientId)
    {
        try
        {
            ClientGateway clientGateWay = new ClientGateway();
            return clientGateWay.SelectClient(clientId);
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
    /// Updates a client information
    /// Exception:SqlException, Exception
    /// </summary>
    /// <param name="clientObject">clientObject</param>
    /// <returns>client information updated status</returns>
    public string UpdateClient(Client clientObject)
    {
        bool isSaved = false;

        try
        {
            ClientGateway clientGatewayObject = new ClientGateway();
            isSaved = clientGatewayObject.UpdateClient(clientObject);
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
            return "Client has been updated.";
        }
        else
        {
            return "Client is not updated";
        }

    }

    /// <summary>
    /// Saves a client information
    /// Exception:PrimaryKeyException, SqlException, Exception
    /// PrimaryKeyException:When trying to insert data in DB with existing primary key
    /// </summary>
    /// <param name="clientObj">clientObj</param>
    /// <returns>client information save status</returns>
    public string SaveClient(Client clientObj)
    {
        ClientGateway clientGatewayObj = null;
        bool isSaved = false;
        try
        {
            clientGatewayObj = new ClientGateway();
            isSaved = clientGatewayObj.InsertClient(clientObj);
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
            return "Client has been saved.";
        }
        else
        {
            return "Client is not saved";
        }
    }

}
