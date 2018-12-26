<%@ Page Language="C#" MasterPageFile="~/UI/MasterPage.master" AutoEventWireup="true" CodeFile="UserUIPage.aspx.cs" Inherits="UI_UserUIPage" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="mainContentPlaceHolder" Runat="Server">
<div style="height:600px">
        <div>
        <table>
        <tr>
            <td align="center" style="width: 949px; color: window; background-color: royalblue;">
                <h3>
                    Add User</h3></td>
        </tr>
    </table>
            <asp:Label ID="successLabel" runat="server" Font-Bold="True" ForeColor="Green" Style="z-index: 100;
                left: 623px; position: absolute; top: 276px"></asp:Label>
            <asp:Button ID="createButton" runat="server"  Style="z-index: 101;
                left: 431px; position: absolute; top: 408px" Text="Create" Width="89px" OnClick="createButton_Click" />
            <asp:Label ID="Label2" runat="server" Style="z-index: 102; left: 289px; position: absolute;
                top: 280px" Text="Employee ID: "></asp:Label>
            <asp:Label ID="Label4" runat="server" Style="z-index: 103; left: 277px; position: absolute;
                top: 311px" Text="Type Password: "></asp:Label>
            <asp:Label ID="Label5" runat="server" Style="z-index: 104; left: 267px; position: absolute;
                top: 342px" Text="Retype Password: "></asp:Label>
            <asp:DropDownList ID="employeeIdDropDownList" runat="server" Style="z-index: 105;
                left: 408px; position: absolute; top: 275px" Width="155px" OnSelectedIndexChanged="employeeIdDropDownList_SelectedIndexChanged" OnDataBound="employeeIdDropDownList_DataBound">
            </asp:DropDownList>
            <asp:TextBox ID="reTypePasswordField" runat="server" Style="z-index: 106; left: 408px;
                position: absolute; top: 335px" TextMode="Password" Width="150px"></asp:TextBox>
            <asp:TextBox ID="passwordField" runat="server" Style="z-index: 107; left: 408px;
                position: absolute; top: 305px" TextMode="Password" Width="150px"></asp:TextBox>
            <asp:Label ID="Label1" runat="server" Style="z-index: 108; left: 307px; position: absolute;
                top: 369px" Text="User Type: "></asp:Label>
            <asp:DropDownList ID="typeDropDownList" runat="server" Style="z-index: 109; left: 408px;
                position: absolute; top: 364px" Width="155px" OnDataBound="typeDropDownList_DataBound">
            </asp:DropDownList>
            <asp:Label ID="errorMessageLabel" runat="server" Font-Bold="True" ForeColor="Red"
                Style="z-index: 111; left: 610px; position: absolute; top: 300px"></asp:Label>
        </div>
 
</div>
</asp:Content>

