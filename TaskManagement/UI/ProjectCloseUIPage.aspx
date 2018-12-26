<%@ Page Language="C#" MasterPageFile="~/UI/MasterPage.master" AutoEventWireup="true" CodeFile="ProjectCloseUIPage.aspx.cs" Inherits="UI_ProjectStatusEditUIPage" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="mainContentPlaceHolder" Runat="Server">
    <asp:Label ID="projectLabel" runat="server" Style="z-index: 100; left: 258px; position: absolute;
        top: 355px" Text="Select Project to Close"></asp:Label>
    <asp:Label ID="statusLabel" runat="server" Style="z-index: 101; left: 361px; position: absolute;
        top: 404px" Text="Status"></asp:Label>
    <asp:DropDownList ID="projectDropDownList" runat="server" Style="z-index: 102; left: 463px;
        position: absolute; top: 352px" AutoPostBack="True" OnSelectedIndexChanged="projectDropDownList_SelectedIndexChanged" Width="200px" OnDataBound="projectDropDownList_DataBound">
    </asp:DropDownList>
    <asp:Label ID="successLabel" runat="server" ForeColor="Green" Style="z-index: 103;
        left: 210px; position: absolute; top: 260px"></asp:Label>
    <asp:Label ID="errorLabel" runat="server" ForeColor="Red" Style="z-index: 104; left: 210px;
        position: absolute; top: 280px"></asp:Label>
    <asp:BulletedList ID="openTaskBulletedList" runat="server" Style="z-index: 105; left: 180px;
        position: absolute; top: 437px" Visible="False" ForeColor="Red">
    </asp:BulletedList>
    <asp:Button ID="closeProjectButton" runat="server" OnClick="closeProjectButton_Click"
        Style="z-index: 106; left: 210px; position: absolute; top: 230px" Text="Close Project"
        Width="120px" />
    <asp:Label ID="projectStatusLabel" runat="server" Style="z-index: 107; left: 463px;
        position: absolute; top: 404px" Width="200px"></asp:Label>
    <asp:Label ID="Label1" runat="server" Style="z-index: 108; left: 363px; position: absolute;
        top: 380px" Text="Client"></asp:Label>
    <asp:Label ID="clientIdLabel" runat="server" Style="z-index: 110; left: 463px; position: absolute;
        top: 380px" Width="200px"></asp:Label>
        <table>
        <tr>
            <td align="center" style="width: 950px; color: window; background-color: royalblue;">
                <h3>
                    Admin Is Closing A Project</h3></td>
        </tr>
    </table>
</asp:Content>

