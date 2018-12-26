<%@ Page Language="C#" MasterPageFile="~/UI/MasterPage.master" AutoEventWireup="true" CodeFile="TaskEditUIPage.aspx.cs" Inherits="UI_TaskEditUIPage" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="mainContentPlaceHolder" Runat="Server">
<div style="height:600px">
    <asp:Panel ID="Panel1" runat="server" Height="367px" Style="z-index: 100; left: 249px;
        position: absolute; top: 317px" Width="450px">
        &nbsp; &nbsp;&nbsp;
        <asp:TextBox ID="taskDescriptionTextBox" runat="server" Style="z-index: 100; left: 229px;
            position: absolute; top: 81px" TextMode="MultiLine"></asp:TextBox>
        <asp:TextBox ID="startDateTextBox" runat="server" Style="z-index: 101; left: 229px;
            position: absolute; top: 196px" Width="171px"></asp:TextBox>
        &nbsp;
        <asp:TextBox ID="taskNameTextBox" runat="server" Height="22px" Style="z-index: 102;
            left: 229px; position: absolute; top: 44px" Width="180px"></asp:TextBox>
        <asp:TextBox ID="estimatedDateTextBox" runat="server" Style="z-index: 103; left: 229px;
            position: absolute; top: 227px" Width="169px"></asp:TextBox>
        <asp:Label ID="taskIdLabel" runat="server" Style="z-index: 104; left: 171px; position: absolute;
            top: 13px" Text="ID"></asp:Label>
        <asp:Label ID="taskNameLabel" runat="server" Style="z-index: 105; left: 150px; position: absolute;
            top: 44px" Text="Name"></asp:Label>
        <asp:Label ID="taskDescriptionLabel" runat="server" Style="z-index: 106; left: 118px;
            position: absolute; top: 86px" Text="Description"></asp:Label>
        <asp:Label ID="StartDateLabel" runat="server" Style="z-index: 107; left: 125px; position: absolute;
            top: 196px" Text="Start Date"></asp:Label>
        <asp:Label ID="Label2" runat="server" Style="z-index: 108; left: 103px; position: absolute;
            top: 227px" Text="Estimate Date"></asp:Label>
        <asp:Label ID="updateSuccessLabel" runat="server" Style="z-index: 109; left: -38px;
            position: absolute; top: -90px" Width="187px" ForeColor="Green"></asp:Label>
        &nbsp;&nbsp;
        <asp:Label ID="Label1" runat="server" Style="z-index: 110; left: 83px; position: absolute;
            top: 167px" Text="Employee Name: "></asp:Label>
        <asp:Label ID="projectLabel" runat="server" Style="z-index: 111; left: 143px; position: absolute;
            top: 130px" Text="Project"></asp:Label>
        &nbsp;
        <asp:Button ID="updateButton" runat="server"  Style="z-index: 112;
            left: 190px; position: absolute; top: 275px" Text="Update" OnClick="updateButton_Click" Width="60px" />
        <asp:DropDownList ID="taskIdDropDownList" runat="server" AutoPostBack="True" Height="22px"
             Style="z-index: 113;
            left: 229px; position: absolute; top: 10px" Width="180px" OnSelectedIndexChanged="taskIdDropDownList_SelectedIndexChanged1" OnDataBound="taskIdDropDownList_DataBound">
        </asp:DropDownList>
        <asp:Label ID="projectNameLabel" runat="server" BorderStyle="Groove" Style="z-index: 114;
            left: 229px; position: absolute; top: 130px" Width="144px"></asp:Label>
        <asp:Label ID="employeeNameLabel" runat="server" BorderStyle="Groove" Style="z-index: 116;
            left: 229px; position: absolute; top: 164px" Width="143px"></asp:Label>
    </asp:Panel>
    <asp:Label ID="errorLabel" runat="server" Style="z-index: 102; left: 210px; position: absolute;
        top: 250px" ForeColor="Red" Width="200px"></asp:Label>
        <table>
        <tr>
            <td align="center" style="width: 951px; color: window; background-color: royalblue;">
                <h3>
                    Edit Task Information</h3></td>
        </tr>
    </table>
</div>
</asp:Content>

