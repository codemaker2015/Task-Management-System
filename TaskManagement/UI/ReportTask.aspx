<%@ Page Language="C#" MasterPageFile="~/UI/MasterPage.master" AutoEventWireup="true" CodeFile="ReportTask.aspx.cs" Inherits="UI_ReportTask" Title="Untitled Page" %>


<asp:Content ID="Content1" ContentPlaceHolderID="mainContentPlaceHolder" Runat="Server">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="task_Id" DataSourceID="SqlDataSource1" EnableModelValidation="True" CssClass="tabel table-hover">
        <Columns>
            <asp:BoundField DataField="task_Id" HeaderText="task_Id" ReadOnly="True" SortExpression="task_Id" />
            <asp:BoundField DataField="task_Name" HeaderText="task_Name" SortExpression="task_Name" />
            <asp:BoundField DataField="task_Description" HeaderText="task_Description" SortExpression="task_Description" />
            <asp:BoundField DataField="task_Project_Title" HeaderText="task_Project_Title" SortExpression="task_Project_Title" />
            <asp:BoundField DataField="task_StartDate" HeaderText="task_StartDate" SortExpression="task_StartDate" />
            <asp:BoundField DataField="task_EstimateTime" HeaderText="task_EstimateTime" SortExpression="task_EstimateTime" />
            <asp:BoundField DataField="task_Employee_Name" HeaderText="task_Employee_Name" SortExpression="task_Employee_Name" />
            <asp:BoundField DataField="task_Project_Id" HeaderText="task_Project_Id" SortExpression="task_Project_Id" />
            <asp:BoundField DataField="task_Employee_Id" HeaderText="task_Employee_Id" SortExpression="task_Employee_Id" />
            <asp:BoundField DataField="task_Status" HeaderText="task_Status" SortExpression="task_Status" />
        </Columns>
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:TaskManagementDBConnectionString2 %>" SelectCommand="SELECT * FROM [t_Task]"></asp:SqlDataSource>
</asp:Content>

