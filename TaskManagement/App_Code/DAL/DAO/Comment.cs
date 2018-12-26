using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// This class is responsible for comment related data
/// </summary>
public class Comment
{
    public Comment()
    {
        
    }

    private DateTime commentDate;
    private string commentEmployeeName;
    private string commentEmployeeId;
    private string commentTaskId;
    private string comments;
    private string commentAttachment;

    public DateTime CommentDate
    {
        set { commentDate = value; }
        get { return commentDate; }
    }

    public string CommentEmployeeName
    {
        set { commentEmployeeName = value; }
        get { return commentEmployeeName; }
    }

    public string CommentEmployeeId
    {
        set { commentEmployeeId = value; }
        get { return commentEmployeeId; }
    }

    public string CommentTaskId
    {
        set { commentTaskId = value; }
        get { return commentTaskId; }
    }

    public string Comments
    {
        set { comments = value; }
        get { return comments; }
    }

    public string CommentAttachment
    {
        set { commentAttachment = value; }
        get { return commentAttachment; }
    }

}
