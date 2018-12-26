<%@ Page Language="C#" MasterPageFile="~/UI/MasterPage.master" AutoEventWireup="true" CodeFile="ProjectAddEmployeeUIPage.aspx.cs" Inherits="UI_ProjectAddEmployeeUIPage" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="mainContentPlaceHolder" Runat="Server">
    <asp:DropDownList ID="projectDropDownList" runat="server" AutoPostBack="True" OnSelectedIndexChanged="projectDropDownList_SelectedIndexChanged"
        Style="z-index: 100; left: 531px; position: absolute; top: 305px" OnDataBound="projectDropDownList_DataBound" Width="200px">
    </asp:DropDownList>
    <asp:Label ID="Label1" runat="server" Style="z-index: 101; left: 397px; position: absolute;
        top: 305px" Text="Project"></asp:Label>
    <asp:Label ID="Label2" runat="server" Style="z-index: 102; left: 397px; position: absolute;
        top: 335px" Text="Select Employee(s) :"></asp:Label>
    <asp:Button ID="saveButton" runat="server" OnClick="saveButton_Click" Style="z-index: 103;
        left: 210px; position: absolute; top: 230px" Text="Save" Width="50px" />
    <asp:Label ID="successLabel" runat="server" ForeColor="Green" Style="z-index: 104;
        left: 210px; position: absolute; top: 260px"></asp:Label>
    <asp:Label ID="errorLabel" runat="server" ForeColor="Red" Style="z-index: 105; left: 210px;
        position: absolute; top: 280px"></asp:Label>
    <asp:ListBox ID="nonMemberEmployeeListBox" runat="server" Height="120px" Style="z-index: 106;
        left: 400px; position: absolute; top: 375px" Width="100px"></asp:ListBox>
    <asp:Button ID="singleAddButton" runat="server"  Style="z-index: 107;
        left: 530px; position: absolute; top: 375px" Text=">" Width="30px" OnClick="singleAddButton_Click" />
    <asp:Button ID="singleRemoveButton" runat="server" 
        Style="z-index: 108; left: 530px; position: absolute; top: 470px" Text="<" Width="30px" OnClick="singleRemoveButton_Click" />
    <asp:ListBox ID="selectedEmployeeListBox" runat="server" Height="120px" Style="z-index: 109;
        left: 600px; position: absolute; top: 375px" Width="100px"></asp:ListBox>
    <asp:Button ID="allAddButton" runat="server"  Style="z-index: 110;
        left: 530px; position: absolute; top: 406px" Text=">>" Width="30px" OnClick="allAddButton_Click" />
    <asp:Button ID="allRemoveButton" runat="server"  Style="z-index: 111;
        left: 530px; position: absolute; top: 437px" Text="<<" Width="30px" OnClick="allRemoveButton_Click" />
        <table>
        <tr>
            <td align="center" style="width: 951px; color: window; background-color: royalblue;">
                <h3>
                    Admin Is Adding New Employee(s) To Project</h3></td>
        </tr>
    </table>
</asp:Content>

