<%@ Page Language="C#" MasterPageFile="~/UI/MasterPage.master" AutoEventWireup="true" CodeFile="ProjectRemoveEmployeeUIPage.aspx.cs" Inherits="UI_ProjectRemoveEmployeeUIPage" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="mainContentPlaceHolder" Runat="Server">
    <asp:DropDownList ID="projectDropDownList" runat="server" AutoPostBack="True" Style="z-index: 100;
        left: 568px; position: absolute; top: 320px" Width="120px" OnSelectedIndexChanged="projectDropDownList_SelectedIndexChanged" OnDataBound="projectDropDownList_DataBound">
    </asp:DropDownList>
    <asp:Label ID="Label1" runat="server" Style="z-index: 101; left: 354px; position: absolute;
        top: 322px" Text="Select project"></asp:Label>
    <asp:Label ID="Label2" runat="server" Style="z-index: 102; left: 287px; position: absolute;
        top: 370px" Text="Select Emplyee To remove"></asp:Label>
    <asp:DropDownList ID="employeeDropDownList" runat="server" Style="z-index: 103; left: 566px;
        position: absolute; top: 366px" Width="120px" OnDataBound="employeeDropDownList_DataBound">
    </asp:DropDownList>
    <asp:Label ID="errorLabel" runat="server" ForeColor="Red" Style="z-index: 104; left: 210px;
        position: absolute; top: 250px"></asp:Label>
    <asp:Label ID="successLabel" runat="server" ForeColor="Green" Style="z-index: 105;
        left: 210px; position: absolute; top: 230px"></asp:Label>
    <asp:Button ID="removeemployeeButton" runat="server" OnClick="removeemployeeButton_Click"
        Style="z-index: 107; left: 474px; position: absolute; top: 417px" Text="Remove Employee" Width="150px" />
        <table>
        <tr>
            <td align="center" style="width: 950px; color: window; background-color: royalblue;">
                <h3>
                    Remove an employee from a project</h3></td>
        </tr>
    </table>
</asp:Content>

