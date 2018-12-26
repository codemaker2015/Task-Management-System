<%@ Page Language="C#" MasterPageFile="~/UI/MasterPage.master" AutoEventWireup="true" CodeFile="TaskNewUIPage.aspx.cs" Inherits="UI_TaskNewUIPage" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="mainContentPlaceHolder" Runat="Server">
<div style="height:600px">
    <asp:Panel ID="Panel1" runat="server" Height="367px" Style="z-index: 100; left: 245px;
        position: absolute; top: 292px" Width="450px">
        &nbsp;
        <asp:TextBox ID="taskIdTextBox" runat="server" Style="z-index: 100; left: 228px;
            position: absolute; top: 13px" Width="172px"></asp:TextBox>
        &nbsp;
        <asp:TextBox ID="taskDescriptionTextBox" runat="server" Style="z-index: 101; left: 230px;
            position: absolute; top: 77px" TextMode="MultiLine"></asp:TextBox>
        <asp:TextBox ID="startDateTextBox" runat="server" Style="z-index: 102; left: 231px;
            position: absolute; top: 196px" Width="171px"></asp:TextBox>
        &nbsp;
        <asp:TextBox ID="taskNameTextBox" runat="server" Style="z-index: 103; left: 231px;
            position: absolute; top: 45px" Width="171px"></asp:TextBox>
        <asp:TextBox ID="estimatedDateTextBox" runat="server" Style="z-index: 104; left: 232px;
            position: absolute; top: 228px" Width="169px"></asp:TextBox>
        <asp:Label ID="TaskIdLabel" runat="server" Style="z-index: 105; left: 171px; position: absolute;
            top: 19px" Text="ID"></asp:Label>
        <asp:Label ID="TaskNameLabel" runat="server" Style="z-index: 106; left: 153px; position: absolute;
            top: 44px" Text="Name"></asp:Label>
        <asp:Label ID="TaskDescriptionLabel" runat="server" Style="z-index: 107; left: 126px;
            position: absolute; top: 75px" Text="Description"></asp:Label>
        <asp:Label ID="StartDateLabel" runat="server" Style="z-index: 108; left: 126px; position: absolute;
            top: 202px" Text="Start Date"></asp:Label>
        <asp:Label ID="Label2" runat="server" Style="z-index: 109; left: 107px; position: absolute;
            top: 233px" Text="Estimate Date"></asp:Label>
        <asp:Button ID="createButton" runat="server"  Style="z-index: 110;
            left: 193px; position: absolute; top: 301px" Text="Create Task" Width="103px" OnClick="CreateButton_Click" />
        <asp:Label ID="CreateTaskSuccessLabel" runat="server" Style="z-index: 111; left: -34px;
            position: absolute; top: -60px" Width="187px" ForeColor="Green"></asp:Label>
        <asp:Label ID="Label3" runat="server" Style="z-index: 112; left: 416px; position: absolute;
            top: 230px" Text="(mm/dd/yyyy)" Width="97px"></asp:Label>
        <asp:Label ID="Label4" runat="server" Style="z-index: 113; left: 416px; position: absolute;
            top: 200px" Text="(mm/dd/yyyy)" Width="100px"></asp:Label>
        <asp:Label ID="Label5" runat="server" Style="z-index: 114; left: 416px; position: absolute;
            top: 170px" Text="(Select employee)" Width="113px"></asp:Label>
        <asp:Label ID="Label6" runat="server" Style="z-index: 120; left: 416px; position: absolute;
            top: 130px" Text="(Select project)" Width="106px"></asp:Label>
        <asp:DropDownList ID="projectDropDownList" runat="server" AutoPostBack="True" 
            Style="z-index: 116; left: 229px; position: absolute; top: 127px" Width="180px" OnSelectedIndexChanged="ProjectDropDownList_SelectedIndexChanged" OnDataBound="projectDropDownList_DataBound">
        </asp:DropDownList>
        <asp:DropDownList ID="employeeDropDownList" runat="server" Style="z-index: 117;
            left: 232px; position: absolute; top: 166px" Width="176px" OnDataBound="employeeDropDownList_DataBound" >
        </asp:DropDownList>
        <asp:Label ID="Label1" runat="server" Style="z-index: 118; left: 129px; position: absolute;
            top: 167px" Text="Employee "></asp:Label>
        <asp:Label ID="ProjectLabel" runat="server" Style="z-index: 119; left: 145px; position: absolute;
            top: 130px" Text="Project"></asp:Label>
    </asp:Panel>
        <table>
        <tr>
            <td align="center" style="width: 950px; color: window; background-color: royalblue;">
                <h3>
                    Enter task information</h3></td>
        </tr>
    </table>
    <asp:Label ID="errorLabel" runat="server" ForeColor="Red" Style="z-index: 102; left: 210px;
        position: absolute; top: 250px"></asp:Label>
</div>
</asp:Content>

