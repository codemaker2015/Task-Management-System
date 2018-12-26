<%@ Page Language="C#" MasterPageFile="~/UI/MasterPage.master" AutoEventWireup="true" CodeFile="EmployeeEditUIPage.aspx.cs" Inherits="UI_EmployeeEditUIPage" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="mainContentPlaceHolder" Runat="Server">
<div style="height:600px">
    <table style="z-index: 100; left: 366px; position: absolute; top: 295px">
        <tr>
            <td style="width: 100px">
                <asp:Label ID="Label7" runat="server" Height="6px" Text="ID:  "></asp:Label></td>
            <td style="width: 147px">
                <asp:DropDownList ID="employeeIdDropDownList" runat="server" AutoPostBack="True"
                     Width="153px" OnSelectedIndexChanged="employeeIdDropDownList_SelectedIndexChanged1" OnDataBound="employeeIdDropDownList_DataBound">
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td style="width: 100px; height: 21px">
                <asp:Label ID="Label6" runat="server" Text="Name: " Width="39px"></asp:Label></td>
            <td style="width: 147px; height: 21px">
                <asp:TextBox ID="employeeNameTextBox" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 100px">
                <asp:Label ID="Label3" runat="server" Text="Address: "></asp:Label></td>
            <td style="width: 147px">
                <asp:TextBox ID="employeeAddressTextBox" runat="server" Height="56px" TextMode="MultiLine"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 100px">
                <asp:Label ID="Label2" runat="server" Text="Phone: "></asp:Label></td>
            <td style="width: 147px">
                <asp:TextBox ID="employeePhoneTextBox" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 100px">
                <asp:Label ID="Label5" runat="server" Text="Email: "></asp:Label></td>
            <td style="width: 147px">
                <asp:TextBox ID="employeeEmailTextBox" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 100px">
                <asp:Label ID="Label4" runat="server" Text="Join Date: "></asp:Label></td>
            <td style="width: 147px">
                <asp:TextBox ID="employeeJoinDateTextBox" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 100px">
                <asp:Label ID="Label1" runat="server" Text="Date of Birth: "></asp:Label></td>
            <td style="width: 147px">
                <asp:TextBox ID="employeeDOBTextBox" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 100px">
            </td>
            <td style="width: 147px">
                <asp:Button ID="updateButton" runat="server"  Text="Update" OnClick="updateButton_Click" /></td>
        </tr>
        <tr>
            <td style="width: 100px">
            </td>
            <td style="width: 147px">
                </td>
        </tr>
        <tr>
            <td style="width: 100px">
            </td>
            <td style="width: 147px">
            </td>
        </tr>
    </table>
    <table>
        <tr>
            <td align="center" style="width: 950px; color: window; background-color: royalblue;">
                <h3>
                    Edit Employee Information</h3></td>
        </tr>
    </table>
    &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp;
    <asp:Label ID="dateEGLabel" runat="server" Height="18px" Style="z-index: 100; left: 632px;
        position: absolute; top: 507px" Text="(mm/dd/yyyy)"></asp:Label>
    <asp:Label ID="emailEGLabel" runat="server" Height="18px" Style="z-index: 101; left: 629px;
        position: absolute; top: 450px" Text="(e.g. name@domain.com)" Width="190px"></asp:Label>
    <asp:Label ID="Label8" runat="server" Height="18px" Style="z-index: 102; left: 629px;
        position: absolute; top: 478px" Text="(mm/dd/yyyy)"></asp:Label>
                <asp:Label ID="successLabel" runat="server" style="z-index: 103; left: 210px; position: absolute; top: 230px" ForeColor="Green"></asp:Label>
    <asp:Label ID="errorLabel" runat="server" Style="z-index: 105; left: 210px; position: absolute;
        top: 250px" ForeColor="Red"></asp:Label>
</div>
</asp:Content>

