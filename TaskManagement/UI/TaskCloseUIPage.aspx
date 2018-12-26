<%@ Page Language="C#" MasterPageFile="~/UI/MasterPage.master" AutoEventWireup="true" CodeFile="TaskCloseUIPage.aspx.cs" Inherits="UI_TaskStatusEditUIPage" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="mainContentPlaceHolder" Runat="Server">
    <asp:Label ID="Label1" runat="server" Style="z-index: 100; left: 390px; position: absolute;
        top: 312px" Text="Task ID"></asp:Label>
    <asp:Label ID="statusLabel" runat="server" Style="z-index: 101; left: 403px; position: absolute;
        top: 383px" Text="Status "></asp:Label>
    <asp:Label ID="successLabel" runat="server" ForeColor="Green" Style="z-index: 102;
        left: 210px; position: absolute; top: 230px"></asp:Label>
    <asp:Label ID="errorLabel" runat="server" ForeColor="Red" Style="z-index: 103; left: 210px;
        position: absolute; top: 250px"></asp:Label>
    <asp:Label ID="TaskIdLabel" runat="server" Style="z-index: 104; left: 475px; position: absolute;
        top: 312px"></asp:Label>
    <asp:Label ID="Label2" runat="server" Style="z-index: 105; left: 369px; position: absolute;
        top: 347px" Text="Task Name"></asp:Label>
    <asp:Label ID="TaskNameLabel" runat="server" Style="z-index: 106; left: 475px; position: absolute;
        top: 347px"></asp:Label>
    <asp:Button ID="closeTaskButton" runat="server" Style="z-index: 107; left: 455px; position: absolute;
        top: 428px" Text="Close Task" Width="100px" OnClick="closeTaskButton_Click" />
    <asp:Label ID="taskStatusLabel" runat="server" Style="z-index: 109; left: 477px; position: absolute;
        top: 382px"></asp:Label>
        <table>
        <tr>
            <td align="center" style="width: 951px; color: window; background-color: royalblue;">
                <h3>
                    Admin Is Closing A Task</h3></td>
        </tr>
    </table>
</asp:Content>

