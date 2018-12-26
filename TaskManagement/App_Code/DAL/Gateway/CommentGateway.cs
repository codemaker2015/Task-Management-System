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
/// Gateway of comment with DB
/// </summary>
public class CommentGateway
{
    public CommentGateway()
    {
        
    }

    /// <summary>
    /// Save a commend to DB
    /// Exception:PrimaryKeyException, SqlException, Exception
    /// PrimaryKeyException:When trying to insert data in DB with existing primary key
    /// </summary>
    /// <param name="commentObj">object of type comment</param>
    /// <returns>true if comment saved else false</returns>
    public bool InsertComment(Comment commentObj)
    {
        SqlConnection sqlConn = null;
        int noOfRowsAffected = 0;
        try
        {
            string insertString = "INSERT INTO t_Comment(comment_Date, comment_Employee_Name, comment_Comments, comment_Employee_Id, comment_Task_Id, comment_Attachment) VALUES('"
                + commentObj.CommentDate + "','" + commentObj.CommentEmployeeName + "','" + commentObj.Comments + "','" + commentObj.CommentEmployeeId + "','" + commentObj.CommentTaskId +"','"+ commentObj.CommentAttachment+ "')";
            DBConnector dbconectorObj = new DBConnector();
            sqlConn = dbconectorObj.GetConnection;
            sqlConn.Open();
            SqlCommand sqlCom = new SqlCommand(insertString, sqlConn);
            noOfRowsAffected = sqlCom.ExecuteNonQuery();
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
    /// Get all commend of a task
    /// Exception:SqlException, Exception
    /// </summary>
    /// <param name="taskId">id of task</param>
    /// <returns>list of comments of the task</returns>
    public List<Comment> SelectAllCommentsOfTheTask(string taskId)
    {
        SqlDataAdapter sqlDataAdapterObj = null;
        SqlConnection sqlConn = null;
        List<Comment> commentListOfTask = null;
        try
        {
            commentListOfTask = new List<Comment>();
            string commendString = "SELECT comment_Date, comment_Employee_Name, comment_Comments ,comment_Attachment FROM t_Comment WHERE comment_Task_Id='" + taskId + "'";
            DBConnector dbConnector = new DBConnector();
            sqlConn = dbConnector.GetConnection;
            sqlConn.Open();
            sqlDataAdapterObj = new SqlDataAdapter(commendString, sqlConn);
            DataSet dsObj = new DataSet();
            sqlDataAdapterObj.Fill(dsObj);
            DataTable dtObj = dsObj.Tables[0];
            foreach (DataRow drObj in dtObj.Rows)
            {
                Comment commentObj = new Comment();
                commentObj.CommentDate = Convert.ToDateTime(drObj[0]);
                commentObj.CommentEmployeeName = drObj[1].ToString();
                commentObj.Comments = drObj[2].ToString();
                commentObj.CommentAttachment = drObj[3].ToString();
                commentListOfTask.Add(commentObj);
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
            if (sqlDataAdapterObj != null)
            {
                if (sqlConn.State == System.Data.ConnectionState.Open)
                {
                    sqlConn.Close();
                }
            }
        }
        return commentListOfTask;
    }

}
