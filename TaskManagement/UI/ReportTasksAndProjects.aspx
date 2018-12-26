<%@ Page Language="C#" MasterPageFile="~/UI/MasterPage.master" AutoEventWireup="true" CodeFile="ReportTasksAndProjects.aspx.cs" Inherits="UI_TasksAndProjects" Title="Untitled Page" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=10.2.3600.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="mainContentPlaceHolder" Runat="Server">
    <CR:CrystalReportViewer ID="tasksAndProjectsCrystalReportViewer" runat="server" AutoDataBind="true"
        Style="z-index: 102; left: 200px; position: absolute; top: 210px" />
</asp:Content>

