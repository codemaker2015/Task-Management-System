<%@ Page Language="C#" MasterPageFile="~/UI/MasterPage.master" AutoEventWireup="true" CodeFile="ReportEmployee.aspx.cs" Inherits="UI_ReportEmployee" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="mainContentPlaceHolder" Runat="Server">
    
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="employee_Id" DataSourceID="SqlDataSource1" EnableModelValidation="True" CssClass="tabel table-hover">
        <Columns>
            <asp:BoundField DataField="employee_Id" HeaderText="employee_Id" ReadOnly="True" SortExpression="employee_Id" />
            <asp:BoundField DataField="employee_Name" HeaderText="employee_Name" SortExpression="employee_Name" />
            <asp:BoundField DataField="employee_Address" HeaderText="employee_Address" SortExpression="employee_Address" />
            <asp:BoundField DataField="employee_PhoneNo" HeaderText="employee_PhoneNo" SortExpression="employee_PhoneNo" />
            <asp:BoundField DataField="employee_Email" HeaderText="employee_Email" SortExpression="employee_Email" />
            <asp:BoundField DataField="employee_JoinDate" HeaderText="employee_JoinDate" SortExpression="employee_JoinDate" />
            <asp:BoundField DataField="employee_DateOfBirth" HeaderText="employee_DateOfBirth" SortExpression="employee_DateOfBirth" />
            <asp:BoundField DataField="employee_AuthenticationModeFlag" HeaderText="employee_AuthenticationModeFlag" SortExpression="employee_AuthenticationModeFlag" />
        </Columns>
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:TaskManagementDBConnectionString %>" SelectCommand="SELECT * FROM [t_Employee]"></asp:SqlDataSource>
    
</asp:Content>

