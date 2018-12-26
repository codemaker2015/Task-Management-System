<%@ Page Language="C#" MasterPageFile="~/UI/MasterPage.master" AutoEventWireup="true" CodeFile="AdminViewTaskUIPage.aspx.cs" Inherits="UI_AdminViewTaskUIPage" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="mainContentPlaceHolder" Runat="Server">
    <asp:Label ID="Label1" runat="server" Style="z-index: 100; left: -98px; position: absolute;
        top: -41px" Text="Estimate Date: " Width="114px"></asp:Label>
    <asp:Label ID="Label2" runat="server" Style="z-index: 101; left: 303px; position: absolute;
        top: 490px" Text="Start Date: " Width="96px"></asp:Label>
    <asp:Label ID="Label3" runat="server" Style="z-index: 102; left: 263px; position: absolute;
        top: 443px" Text="Task Description: " Width="136px"></asp:Label>
    <asp:Label ID="Label5" runat="server" Style="z-index: 103; left: 280px; position: absolute;
        top: 368px" Text="Project Name: " Width="119px"></asp:Label>
    <asp:Label ID="Label8" runat="server" Style="z-index: 104; left: 303px; position: absolute;
        top: 406px" Text="Project ID : " Height="19px" Width="96px"></asp:Label>
    <asp:TextBox ID="projectNameTextBox" runat="server" ReadOnly="True" Style="z-index: 105;
        left: 428px; position: absolute; top: 368px"></asp:TextBox>
    <asp:TextBox ID="taskDescriptionTextBox" runat="server" ReadOnly="True" Style="z-index: 106;
        left: 428px; position: absolute; top: 443px" TextMode="MultiLine" TabIndex="-1"></asp:TextBox>
    <asp:TextBox ID="startDateTextBox" runat="server" ReadOnly="True" Style="z-index: 107;
        left: 428px; position: absolute; top: 490px"></asp:TextBox>
    <asp:TextBox ID="estimateDateTexeBox" runat="server" ReadOnly="True" Style="z-index: 108;
        left: 428px; position: absolute; top: 524px"></asp:TextBox>
    <asp:Label ID="Label4" runat="server" Style="z-index: 109; left: 294px; position: absolute;
        top: 338px" Text="Task Name: " Width="105px"></asp:Label>
    <asp:TextBox ID="taskNameTextBox" runat="server" ReadOnly="True" Style="z-index: 110;
        left: 428px; position: absolute; top: 338px"></asp:TextBox>
    <asp:Label ID="Label6" runat="server" Style="z-index: 111; left: 322px; position: absolute;
        top: 309px" Text="Task Id: " Width="77px"></asp:Label>
    <asp:TextBox ID="taskIdTextBox" runat="server" Style="z-index: 112; left: 428px;
        position: absolute; top: 309px" ReadOnly="True"></asp:TextBox>
    <asp:Label ID="Label7" runat="server" Style="z-index: 113; left: 285px; position: absolute;
        top: 528px" Text="Estimate Date: " Width="114px"></asp:Label>
    <asp:TextBox ID="allCommentsTextBox" runat="server" Height="168px" ReadOnly="True"
        Style="z-index: 114; left: 293px; position: absolute; top: 587px" TextMode="MultiLine"
        Width="369px"></asp:TextBox>
    <asp:TextBox ID="commentTextBox" runat="server" Height="89px" Style="z-index: 115;
        left: 296px; position: absolute; top: 799px" TextMode="MultiLine" Width="369px" TabIndex="4"></asp:TextBox>
    <asp:CheckBox ID="forwardToCheckBox" runat="server" AutoPostBack="True" 
        Style="z-index: 116; left: 302px; position: absolute; top: 949px" Text="Forward To"
        Width="113px" OnCheckedChanged="forwardToCheckBox_CheckedChanged" TabIndex="6" />
    <asp:DropDownList ID="employeeNameDropDownList" runat="server" Style="z-index: 117;
        left: 453px; position: absolute; top: 950px" Visible="False" TabIndex="7" OnDataBound="employeeNameDropDownList_DataBound">
    </asp:DropDownList>
    <asp:Button ID="postAndForwardButton" runat="server" OnClick="postAndForwardButton_Click"
        Style="z-index: 118; left: 302px; position: absolute; top: 1015px" Text="Post & Forward"
        Visible="False" Width="105px" TabIndex="9" />
    <asp:Button ID="postCommentButton" runat="server" OnClick="postCommentButton_Click"
        Style="z-index: 119; left: 302px; position: absolute; top: 979px" Text="Post Comment" Font-Size="Small" Width="105px" TabIndex="8" />
    <asp:Label ID="errorLabel" runat="server" Style="z-index: 120; left: 210px; position: absolute;
        top: 225px" Width="400px" ForeColor="Red"></asp:Label>
    <asp:LinkButton ID="closeTaskLinkButton" runat="server" ForeColor="DarkGreen"
        PostBackUrl="~/UI/TaskCloseUIPage.aspx" Style="z-index: 121; left: 693px; position: absolute;
        top: 309px" Width="80px" TabIndex="3">Close Task</asp:LinkButton>
    <asp:TextBox ID="projectIdTextBox" runat="server" Style="z-index: 122; left: 428px; position: absolute;
        top: 406px" ReadOnly="True"></asp:TextBox>
    <asp:FileUpload ID="attachmentFileUpload" runat="server" Style="z-index: 123; left: 448px;
        position: absolute; top: 901px" Width="220px" TabIndex="5" />
    <asp:Label ID="Label9" runat="server" Style="z-index: 124; left: 302px; position: absolute;
        top: 901px" Text="Attach a file (optional)"></asp:Label>
    <asp:BulletedList ID="attachmentBulletedList" runat="server" CausesValidation="True"
        DisplayMode="LinkButton" Style="z-index: 125; left: 693px; position: absolute;
        top: 610px" Visible="False" BulletStyle="Square" OnClick="attachmentBulletedList_Click" TabIndex="10">
    </asp:BulletedList>
    <asp:Label ID="attachmentLabel" runat="server" Style="z-index: 127; left: 693px; position: absolute;
        top: 587px" Text="Attachment :"></asp:Label>
    <table>
        <tr>
            <td align="center" style="font-size: 20pt; width: 950px; color: window; background-color: royalblue">
                Task</td>
        </tr>
    </table>
</asp:Content>

