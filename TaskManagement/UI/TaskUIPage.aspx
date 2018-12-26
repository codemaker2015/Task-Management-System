<%@ Page Language="C#" MasterPageFile="~/UI/MasterPage.master" AutoEventWireup="true" CodeFile="TaskUIPage.aspx.cs" Inherits="UI_TaskUIPage" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="mainContentPlaceHolder" Runat="Server">
<div style="height:800px">
  <table>
        <tr>
            <td align="center" style="width: 950px; color: window; background-color: royalblue;">
                <h3>
                    Task (View Only)</h3></td>
        </tr>
    </table>
    <asp:Label ID="Label2" runat="server" Style="z-index: 100; left: 313px; position: absolute;
        top: 275px" Text="Project"></asp:Label>
    <asp:DropDownList ID="projectDropDownList" runat="server" AutoPostBack="True" 
        Style="z-index: 101; left: 397px; position: absolute; top: 272px" Width="187px" OnSelectedIndexChanged="DropDownListProject_SelectedIndexChanged1" OnDataBound="projectDropDownList_DataBound">
    </asp:DropDownList>
    <asp:Label ID="TaskIdLabel" runat="server" Style="z-index: 102; left: 327px; position: absolute;
        top: 312px" Text="Task"></asp:Label>
    <asp:TextBox ID="employeeIdTextBox" runat="server" ReadOnly="True" Style="z-index: 103;
        left: 397px; position: absolute; top: 499px" Width="180px"></asp:TextBox>
    <asp:Label ID="Label" runat="server" Style="z-index: 104; left: 277px; position: absolute;
        top: 499px" Text="Employee ID"></asp:Label>
    <asp:TextBox ID="allCommentTextBox" runat="server" Height="191px" ReadOnly="True"
        Style="z-index: 105; left: 238px; position: absolute; top: 560px" TextMode="MultiLine"
        Width="560px"></asp:TextBox>
    <asp:Label ID="allCommentsLabel" runat="server" Style="z-index: 106; left: 244px;
        position: absolute; top: 532px" Text="All Comments"></asp:Label>
    &nbsp;
    <asp:TextBox ID="employeeNameTextBox" runat="server" ReadOnly="True" Style="z-index: 107;
        left: 397px; position: absolute; top: 460px" Width="180px"></asp:TextBox>
    <asp:Label ID="Label1" runat="server" Style="z-index: 108; left: 256px; position: absolute;
        top: 460px" Text="Employee Name"></asp:Label>
    <asp:DropDownList ID="taskDropDownList" runat="server" AutoPostBack="True" 
        Style="z-index: 109; left: 397px; position: absolute; top: 309px" Width="187px" OnSelectedIndexChanged="taskDropDownList_SelectedIndexChanged" OnDataBound="taskDropDownList_DataBound">
    </asp:DropDownList>
    <asp:Label ID="Label3" runat="server" Style="z-index: 110; left: 288px; position: absolute;
        top: 349px" Text="Description"></asp:Label>
    <asp:TextBox ID="descriptionTextBox" runat="server" ReadOnly="True" Style="z-index: 111;
        left: 397px; position: absolute; top: 342px" TextMode="MultiLine" Width="180px"></asp:TextBox>
    <asp:Label ID="Label4" runat="server" Style="z-index: 112; left: 295px; position: absolute;
        top: 386px" Text="Start Date"></asp:Label>
    <asp:Label ID="Label5" runat="server" Style="z-index: 113; left: 266px; position: absolute;
        top: 423px" Text="Estimated Date"></asp:Label>
    <asp:TextBox ID="estimatedDateTextBox" runat="server" ReadOnly="True" Style="z-index: 114;
        left: 396px; position: absolute; top: 423px" Width="180px"></asp:TextBox>
    <asp:TextBox ID="startDateTextBox" runat="server" ReadOnly="True" Style="z-index: 115;
        left: 397px; position: absolute; top: 386px" Width="180px"></asp:TextBox>
    <asp:Label ID="errorLabel" runat="server" Style="z-index: 117; left: 210px; position: absolute;
        top: 230px" ForeColor="Red"></asp:Label>
</div>
</asp:Content>

