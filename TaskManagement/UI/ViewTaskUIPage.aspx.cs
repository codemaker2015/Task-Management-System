using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Net;

public partial class UI_NormalUserViewTaskUIPage : System.Web.UI.Page
{
    string taskId = null;
    Task taskObj = null;

    protected void Page_Load(object sender, EventArgs e)
    {
        this.taskId = Session["taskID"].ToString();
        LoadTaskInfo();
        LoadAllComments();
    }

    protected void postCommentButton_Click(object sender, EventArgs e)
    {
        if (DataValidator.IsEmpty(commentTextBox.Text))
        {
            errorLabel.Text = "No comment to post";
            return;
        }
        SaveComment();
    }

    protected void attachmentBulletedList_Click(object sender, BulletedListEventArgs e)
    {
        try
        {
            ListItem listItemObj = attachmentBulletedList.Items[e.Index];
            string sourcePath = listItemObj.Value;
            Response.AddHeader("Content-Disposition", "attachment;filename=\"" + listItemObj.Text + "\"");
            Response.ContentType = "application/octet-stream";
            Response.WriteFile(listItemObj.Value);
        }
        catch (SqlException sqlExceptionObj)
        {
            errorLabel.Text = sqlExceptionObj.Message;
        }
        catch (Exception exceptionObj)
        {
            errorLabel.Text = exceptionObj.Message;
        }
    }

    protected void postAndForwardButton_Click(object sender, EventArgs e)
    {
        if (DataValidator.IsEmpty(commentTextBox.Text))
        {
            errorLabel.Text = "Please enter forwarding comment";
            return;
        }
        else if (employeeNameDropDownList.SelectedIndex.Equals(0))  // Item in index 0 is "-Select-" and not a valid item. So must not use
        {
            errorLabel.Text = "Please select an employee";
            return;
        }
        SaveComment();
        ForwardTask();
        Response.Redirect("NormalUserUIPage.aspx");
    }

    protected void forwardToCheckBox_CheckedChanged1(object sender, EventArgs e)
    {
        if (forwardToCheckBox.Checked)
        {
            employeeNameDropDownList.Visible = true;
            postAndForwardButton.Visible = true;
            postCommentButton.Visible = false;
            FillDropDownListEmployeeOfTheProject();
        }
        else
        {
            employeeNameDropDownList.Visible = false;
            postAndForwardButton.Visible = false;
            postCommentButton.Visible = true;
        }
    }

    protected void employeeNameDropDownList_DataBound(object sender, EventArgs e)
    {
        //Inserting an item in the 0 index of the DDL named "-Select-"
        //which will navigate the user to select an item
        employeeNameDropDownList.Items.Insert(0, new ListItem("-Select-"));
    }
    
    protected void employeeNameDropDownList_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    /// <summary>
    /// Fills up employeeNameDropDownList DDL
    /// </summary>
    private void FillDropDownListEmployeeOfTheProject()
    {
        try
        {
            EmployeeManager employeeManagerObject = new EmployeeManager();
            employeeNameDropDownList.DataSource = employeeManagerObject.GetEmployeesOfTheProject(taskObj.Project_Id);
            employeeNameDropDownList.DataTextField = "Name";
            employeeNameDropDownList.DataValueField = "ID";
            employeeNameDropDownList.DataBind();
        }
        catch (SqlException sqlExceptionObj)
        {
            errorLabel.Text = sqlExceptionObj.Message;
        }
        catch (Exception exceptionObj)
        {
            errorLabel.Text = exceptionObj.Message;
        }
    }

    /// <summary>
    /// Loads task information in the page
    /// </summary>
    private void LoadTaskInfo()
    {
        try
        {
            TaskManager taskManagerObj = new TaskManager();
            taskObj = taskManagerObj.SelectTask(taskId);
            taskIdTextBox.Text = taskObj.Id;
            taskNameTextBox.Text = taskObj.Name;
            projectNameTextBox.Text = taskObj.Project_Title;
            taskDescriptionTextBox.Text = taskObj.Description;
            startDateTextBox.Text = Convert.ToString(taskObj.StartDate);
            estimateDateTexeBox.Text = Convert.ToString(taskObj.EstimatedTime);
        }
        catch (SqlException sqlExceptionObj)
        {
            errorLabel.Text = sqlExceptionObj.Message;
        }
        catch (Exception exceptionObj)
        {
            errorLabel.Text = exceptionObj.Message;
        }
        
    }

    /// <summary>
    /// Save a comment
    /// </summary>
    private void SaveComment()
    {
        try
        {
            Comment commentObj = new Comment();

            if (attachmentFileUpload.PostedFile.FileName != "")
            {
                UploadAttachment();

                string fileName = attachmentFileUpload.FileName;
                string fileDestinationPath = @"Attached files\" + fileName;
                    //In DB attachment File location will be "Attached files\+ fileName"
                    //while downloading the file virtual path will be added to create full path
                commentObj.CommentAttachment = fileDestinationPath;
            }

            commentObj.CommentTaskId = taskObj.Id;
            commentObj.CommentEmployeeName = taskObj.Employee_AssignTo;
            commentObj.CommentEmployeeId = taskObj.Employee_Id;
            commentObj.CommentDate = System.DateTime.Now;
            commentObj.Comments = commentTextBox.Text;
            CommentManager commentManagerObject = new CommentManager();
            commentManagerObject.SaveComment(commentObj);
            LoadAllComments();
        }
        catch (PrimaryKeyException primaryKeyExceptionObj)
        {
            errorLabel.Text = primaryKeyExceptionObj.Message;
        }
        catch (SqlException sqlExceptionObj)
        {
            errorLabel.Text = sqlExceptionObj.Message;
        }
        catch (Exception exceptionObj)
        {
            errorLabel.Text = exceptionObj.Message;
        }
    }

    /// <summary>
    /// Forwards a task
    /// </summary>
    private void ForwardTask()
    {
        try
        {
            TaskManager taskManagerObj = new TaskManager();
            Task taskObject = new Task();
            taskObject.Id = taskIdTextBox.Text;
            taskObject.Employee_Id = employeeNameDropDownList.SelectedItem.Value;
            taskObject.Employee_AssignTo = employeeNameDropDownList.SelectedItem.Text;
            taskObject.Employee_AssigenBy = taskObj.Employee_Id;
            taskObject.Project_Id = projectNameTextBox.Text;
            taskObject.StartDate = System.DateTime.Now;
            string forwardStatus = taskManagerObj.ForwardATask(taskObject);
        }
        catch (SqlException sqlExceptionObj)
        {
            errorLabel.Text = sqlExceptionObj.Message;
        }
        catch (Exception exceptionObj)
        {
            errorLabel.Text = exceptionObj.Message;
        }
    }

    /// <summary>
    /// Loads all comment in allCommentsTextBox
    /// </summary>
    private void LoadAllComments()
    {
        try
        {
            string allComments = null;
            CommentManager commentManagerObject = new CommentManager();
            List<Comment> commentList = commentManagerObject.GetCommentsOfTheTask(taskId);
            foreach (Comment commentObj in commentList)
            {
                allComments += commentObj.CommentEmployeeName + " : ";
                allComments += commentObj.Comments + ".   \n on ";
                allComments += commentObj.CommentDate + ".  \n";
            }
            allCommentsTextBox.Text = allComments;
            CheckForAttachmentAndLoadInBulletedList();
        }
        catch (SqlException sqlExceptionObj)
        {
            errorLabel.Text = sqlExceptionObj.Message;
        }
        catch (Exception exceptionObj)
        {
            errorLabel.Text = exceptionObj.Message;
        }

    }
    
    /// <summary>
    /// Check if there any attachment with this task
    /// if any Load attachments of the task into BulletedList
    /// BulletedList text field=file name
    /// BulletedList value field= source path
    /// </summary>
    private void CheckForAttachmentAndLoadInBulletedList()
    {
        if (numberOfAttachment() == 0)
        {
            attachmentLabel.Text = "No attachment with this task";
            attachmentBulletedList.Visible = false;
        }
        else
        {
            attachmentLabel.Text = "Attachment :";
            attachmentBulletedList.Visible = true;
            attachmentBulletedList.Items.Clear();
            AddAttachmentToBulletedList();

        }
    }

    /// <summary>
    /// Counts number of attachments of the task
    /// </summary>
    /// <returns>number of attachments of the task</returns>
    private int numberOfAttachment()
    {
        int noOfAttachment = 0;
        try
        {
            CommentManager commentManagerObject = new CommentManager();
            List<Comment> commentList = commentManagerObject.GetCommentsOfTheTask(taskId);
            foreach (Comment commentObj in commentList)
            {
                if (commentObj.CommentAttachment != "")
                {
                    noOfAttachment++;
                }
            }

        }
        catch (SqlException sqlExceptionObj)
        {
            errorLabel.Text = sqlExceptionObj.Message;
        }
        catch (Exception exceptionObj)
        {
            errorLabel.Text = exceptionObj.Message;
        }

        return noOfAttachment;

    }

    /// <summary>
    /// Dynamically add attachments of a task in the bulletedList
    /// text fild= file name
    /// value fild= source path
    /// </summary>
    private void AddAttachmentToBulletedList()
    {
        try
        {
            CommentManager commentManagerObject = new CommentManager();
            List<Comment> commentList = commentManagerObject.GetCommentsOfTheTask(taskId);
            foreach (Comment commentObj in commentList)
            {
                if (commentObj.CommentAttachment != "")
                {
                    string sourcePath = commentObj.CommentAttachment;
                    int lastIndexOfSlash = sourcePath.LastIndexOf(@"\");
                    string fileName = sourcePath.Substring(lastIndexOfSlash + 1);
                    ListItem listItemObj = new ListItem();
                    listItemObj.Text = fileName;
                    listItemObj.Value = Server.MapPath("~/")+sourcePath;
                    attachmentBulletedList.Items.Add(listItemObj);
                }
            }
        }
        catch (SqlException sqlExceptionObj)
        {
            errorLabel.Text = sqlExceptionObj.Message;
        }
        catch (Exception exceptionObj)
        {
            errorLabel.Text = exceptionObj.Message;
        }
    }

    /// <summary>
    /// Upload a attachment
    /// </summary>
    private void UploadAttachment()
    {
        /* All attachment will be saved in 
         * virtual path + \Attached files\ + file name
         * */

        try
        {
            string fileSourcePath = attachmentFileUpload.PostedFile.FileName;
            string fileName = attachmentFileUpload.FileName;
            string fileDestinationPath = Server.MapPath("~/");
            fileDestinationPath = fileDestinationPath + @"Attached files\" + fileName;
            WebClient webClientObj = new WebClient();
            webClientObj.UploadFile(fileDestinationPath, fileSourcePath);
        }
        catch (SqlException sqlExceptionObj)
        {
            errorLabel.Text = sqlExceptionObj.Message;
        }
        catch (Exception exceptionObj)
        {
            errorLabel.Text = exceptionObj.Message;
        }
    }
    
}
