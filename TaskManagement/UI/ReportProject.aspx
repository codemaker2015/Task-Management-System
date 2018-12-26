<%@ Page Language="C#" MasterPageFile="~/UI/MasterPage.master" AutoEventWireup="true" CodeFile="ReportProject.aspx.cs" Inherits="UI_ReportProject" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="mainContentPlaceHolder" Runat="Server">
    
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="project_Id" DataSourceID="SqlDataSource1" EnableModelValidation="True" CssClass="table table-hover">
    <Columns>
        <asp:BoundField DataField="project_Id" HeaderText="project_Id" ReadOnly="True" SortExpression="project_Id" />
        <asp:BoundField DataField="project_Title" HeaderText="project_Title" SortExpression="project_Title" />
        <asp:BoundField DataField="project_Description" HeaderText="project_Description" SortExpression="project_Description" />
        <asp:BoundField DataField="project_StartTime" HeaderText="project_StartTime" SortExpression="project_StartTime" />
        <asp:BoundField DataField="project_EstimateTime" HeaderText="project_EstimateTime" SortExpression="project_EstimateTime" />
        <asp:BoundField DataField="project_Client_ID" HeaderText="project_Client_ID" SortExpression="project_Client_ID" />
        <asp:BoundField DataField="project_Status" HeaderText="project_Status" SortExpression="project_Status" />
    </Columns>
</asp:GridView>
<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:TaskManagementDBConnectionString3 %>" SelectCommand="SELECT * FROM [t_Project]"></asp:SqlDataSource>
    
</asp:Content>

