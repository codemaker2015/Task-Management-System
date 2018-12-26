<%@ Page Language="C#" MasterPageFile="~/UI/MasterPage.master" AutoEventWireup="true" CodeFile="EmployeeSaveInfoUIPage.aspx.cs" Inherits="UI_EmployeeSaveInfoUIPage" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="mainContentPlaceHolder" Runat="Server">
<div style="height:600px">
    <div>
        <div style="z-index: 100; left: 330px; width: 430px; position: absolute; top: 295px;
            height: 347px">
            <asp:Label ID="Label1" runat="server" BorderStyle="None" Height="26px" Style="z-index: 100;
                left: 22px; position: absolute; top: 13px" Text="Id: " Width="141px"></asp:Label>
            <asp:Label ID="employeeIdLabel" runat="server" BorderStyle="Groove" Height="26px"
                Style="z-index: 101; left: 235px; position: absolute; top: 14px" Text="Label"
                Width="141px"></asp:Label>
            <asp:Label ID="employeeNameLabel" runat="server" BorderStyle="Groove" Height="26px"
                Style="z-index: 102; left: 235px; position: absolute; top: 49px" Text="Label"
                Width="141px"></asp:Label>
            <asp:Label ID="employeeAddressLabel" runat="server" BorderStyle="Groove" Height="26px"
                Style="z-index: 103; left: 235px; position: absolute; top: 85px" Text="Label"
                Width="141px"></asp:Label>
            <asp:Label ID="employeePhoneLabel" runat="server" BorderStyle="Groove" Height="26px"
                Style="z-index: 104; left: 235px; position: absolute; top: 121px" Text="Label"
                Width="141px"></asp:Label>
            <asp:Label ID="employeeEmailLabel" runat="server" BorderStyle="Groove" Height="26px"
                Style="z-index: 105; left: 235px; position: absolute; top: 157px" Text="Label"
                Width="141px"></asp:Label>
            <asp:Label ID="joinDateLabel" runat="server" BorderStyle="Groove" Height="26px" Style="z-index: 106;
                left: 235px; position: absolute; top: 192px" Text="Label" Width="141px"></asp:Label>
            <asp:Label ID="dOBLabel" runat="server" BorderStyle="Groove" Height="26px" Style="z-index: 107;
                left: 235px; position: absolute; top: 228px" Text="Label" Width="141px"></asp:Label>
            <asp:Label ID="Label9" runat="server" BorderStyle="None" Height="26px" Style="z-index: 108;
                left: 22px; position: absolute; top: 48px" Text="Name: " Width="141px"></asp:Label>
            <asp:Label ID="Label10" runat="server" BorderStyle="None" Height="26px" Style="z-index: 109;
                left: 22px; position: absolute; top: 84px" Text="Address" Width="141px"></asp:Label>
            <asp:Label ID="Label11" runat="server" BorderStyle="None" Height="26px" Style="z-index: 110;
                left: 22px; position: absolute; top: 120px" Text="Phone: " Width="141px"></asp:Label>
            <asp:Label ID="Label12" runat="server" BorderStyle="None" Height="26px" Style="z-index: 111;
                left: 22px; position: absolute; top: 156px" Text="Email: " Width="141px"></asp:Label>
            <asp:Label ID="Label13" runat="server" BorderStyle="None" Height="26px" Style="z-index: 112;
                left: 22px; position: absolute; top: 195px" Text="Join Date: " Width="141px"></asp:Label>
            <asp:Label ID="Label14" runat="server" BorderStyle="None" Height="26px" Style="z-index: 113;
                left: 22px; position: absolute; top: 230px" Text=" Date of Birth: " Width="141px"></asp:Label>
            <asp:Button ID="saveButton" runat="server"  Style="z-index: 114;
                left: 22px; position: absolute; top: 300px" Text="Save" Width="141px" OnClick="saveButton_Click" />
            <asp:Button ID="cancelButton" runat="server"  Style="z-index: 116;
                left: 235px; position: absolute; top: 300px" Text="Cancel" Width="155px" OnClick="cancelButton_Click" />
        </div>
        <table>
        <tr>
            <td align="center" style="width: 951px; color: window; background-color: royalblue;">
                <h3>
                    Make Sure All Information Is Right</h3></td>
        </tr>
    </table>
    </div>
    <asp:Label ID="errorMessageLabel" runat="server" Style="z-index: 100; left: 210px;
        position: absolute; top: 230px" ForeColor="Red"></asp:Label>
</div>
</asp:Content>

