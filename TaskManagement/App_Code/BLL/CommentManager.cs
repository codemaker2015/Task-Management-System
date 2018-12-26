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
/// This class manages every thing about Comment
/// contains methods to manage comment related oparations
/// </summary>
public class CommentManager
{
	public CommentManager()
	{
		
	}

    /// <summary>
    /// Save a comment
    /// Exception:PrimaryKeyException, SqlException, Exception
    /// PrimaryKeyException:When trying to insert data in DB with existing primary key
    /// </summary>
    /// <param name="commentObj">commentObj</param>
    /// <returns>save status</returns>
    public string SaveComment(Comment commentObj)
    {
        bool isSaved = false;
        try
        {
            CommentGateway commentGatewayObj = new CommentGateway();
            isSaved = commentGatewayObj.InsertComment(commentObj);
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
            return "Comment is saved";
        }
        else
        {
            return "Comment is not saved";
        }
    }

    /// <summary>
    /// Select all comments of a task
    /// Exception:SqlException, Exception
    /// </summary>
    /// <param name="taskId">task id</param>
    /// <returns>List of all comments of the task</returns>
    public List<Comment> GetCommentsOfTheTask(string taskId)
    {
        try
        {
            CommentGateway commentGatewayObj = new CommentGateway();
            return commentGatewayObj.SelectAllCommentsOfTheTask(taskId);
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
