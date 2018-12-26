<%@ Page Language="C#" MasterPageFile="~/UI/MasterPage.master" AutoEventWireup="true" CodeFile="AdimHomePage.aspx.cs" Inherits="UI_AdimHomePage" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="mainContentPlaceHolder" Runat="Server">
<div style="height:400px">
    <div>
        <asp:BulletedList ID="tasksOfUserBulletedList" runat="server" DisplayMode="LinkButton"
            Font-Size="Large"  Style="z-index: 100;  left: 0px; position: absolute; top: 239px" OnClick="tasksOfUserBulletedList_Click" Width="300px" TabIndex="3">
        </asp:BulletedList>
        <asp:Label ID="numberOfTasksLabel" runat="server" Font-Size="Large" Style="z-index: 101;
            left: 427px; position: absolute; top: 180px" Width="300px"></asp:Label>
        <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="X-Large" Style="z-index: 102;
            left: 427px; position: absolute; top: 134px" Text="Individual Tasks" Width="200px"></asp:Label>
        <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Size="X-Large" Style="z-index: 103;
            left: 53px; position: absolute; top: 138px" Text="Involved Projects" Width="200px"></asp:Label>
        <asp:Label ID="numberOfProjectsLabel" runat="server" Font-Size="Large" Style="z-index: 104;
            left: 53px; position: absolute; top: 183px" Width="300px"></asp:Label>
        <asp:BulletedList ID="projectListBulletedList" runat="server" Font-Bold="False" Font-Size="Large"
            ForeColor="#0000C0" Style="z-index: 105; left: 57px; position: absolute; top: 244px" Width="300px">
        </asp:BulletedList>
        <asp:Label ID="errorLabel" runat="server" Style="z-index: 106; left: 10px; position: absolute;
            top: 150px" ForeColor="Red"></asp:Label>
        <asp:Label ID="successLabel" runat="server" ForeColor="Green" Style="z-index: 108;
            left: 10px; position: absolute; top: 125px"></asp:Label>
        <table>
            <tr>
                <td align="center" style="width: 950px; color: window; background-color: royalblue; font-size: 20pt;">
                    Welcome Admin</td>
            </tr>
        </table>
    </div>
</div>
</asp:Content>

