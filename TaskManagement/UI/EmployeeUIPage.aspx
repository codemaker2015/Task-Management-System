<%@ Page Language="C#" MasterPageFile="~/UI/MasterPage.master" AutoEventWireup="true" CodeFile="EmployeeUIPage.aspx.cs" Inherits="UI_EmployeeUIPage" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="mainContentPlaceHolder" Runat="Server">
<div style="height:600px">
    <h2>
        <table>
        <tr>
            <td align="center" style="width: 950px; color: window; background-color: royalblue;">
                <h3>
                    Enter Employee Information</h3></td>
        </tr>
    </table>
    </h2>

        <div>
            <asp:Label ID="Label1" runat="server" Style="z-index: 100; left: 334px; position: absolute;
                top: 540px" Text="Date of Birth: "></asp:Label>
            <asp:Label ID="Label2" runat="server" Style="z-index: 101; left: 374px; position: absolute;
                top: 449px" Text="Phone: "></asp:Label>
            <asp:Label ID="Label4" runat="server" Style="z-index: 102; left: 355px; position: absolute;
                top: 510px" Text="Join Date: "></asp:Label>
            <asp:Label ID="Label5" runat="server" Style="z-index: 103; left: 379px; position: absolute;
                top: 477px" Text="Email: "></asp:Label>
            <asp:Label ID="Label6" runat="server" Style="z-index: 104; left: 375px; position: absolute;
                top: 343px" Text="Name: " Width="39px"></asp:Label>
            <asp:Label ID="Label7" runat="server" Height="6px" Style="z-index: 105; left: 396px;
                position: absolute; top: 312px" Text="ID:  "></asp:Label>
            <asp:TextBox ID="employeeNameTextBox" runat="server" Style="z-index: 106; left: 451px;
                position: absolute; top: 343px"></asp:TextBox>
            <asp:TextBox ID="employeeAddressTextBox" runat="server" Height="56px" Style="z-index: 107;
                left: 451px; position: absolute; top: 376px" TextMode="MultiLine"></asp:TextBox>
            <asp:TextBox ID="employeePhoneTextBox" runat="server" Style="z-index: 108; left: 451px;
                position: absolute; top: 449px"></asp:TextBox>
            <asp:TextBox ID="employeeEmailTextBox" runat="server" Style="z-index: 109; left: 451px;
                position: absolute; top: 477px"></asp:TextBox>
            <asp:TextBox ID="employeeJoindateTextBox" runat="server" Style="z-index: 110; left: 451px;
                position: absolute; top: 510px"></asp:TextBox>
            <asp:TextBox ID="employeeDOBTextBox" runat="server" Style="z-index: 111; left: 451px;
                position: absolute; top: 540px"></asp:TextBox>
            <asp:Label ID="Label3" runat="server" Style="z-index: 112; left: 361px; position: absolute;
                top: 376px" Text="Address: "></asp:Label>
            <asp:TextBox ID="employeeIdTextBox" runat="server" Style="z-index: 113; left: 451px;
                position: absolute; top: 312px"></asp:TextBox>
            <asp:Button ID="saveButton" runat="server"  Style="z-index: 114;
                left: 479px; position: absolute; top: 582px" Text="Save" Width="94px" OnClick="saveButton_Click" />
            <asp:Label ID="successMessageLabel" runat="server" Style="z-index: 115; left: 210px;
                position: absolute; top: 230px" Width="325px" ForeColor="Green"></asp:Label>
            <asp:GridView ID="employeeGridView" runat="server" EnableTheming="True" 
                Style="z-index: 116; left: 210px; position: absolute; top: 631px" Width="421px" PageSize="4">
            </asp:GridView>
            <asp:Label ID="dateEGLabel" runat="server" Style="z-index: 117; left: 609px; position: absolute;
                top: 510px" Text="(mm/dd/yyyy)"></asp:Label>
            <asp:Label ID="emailEGLabel" runat="server" Style="z-index: 118; left: 608px; position: absolute;
                top: 477px" Text="(e.g. name@domain.com)" Width="190px"></asp:Label>
            <asp:Label ID="Label8" runat="server" Style="z-index: 119; left: 610px; position: absolute;
                top: 540px" Text="(mm/dd/yyyy)"></asp:Label>
            <asp:Label ID="errorMessageLabel" runat="server" Style="z-index: 121; left: 210px;
                position: absolute; top: 250px" ForeColor="Red"></asp:Label>
        </div>
    
   
</div>
</asp:Content>

