<%@ Page Language="C#" MasterPageFile="~/UI/MasterPage.master" AutoEventWireup="true" CodeFile="ProjectCreateUIPage.aspx.cs" Inherits="UI_ProjectCreateUIPage" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="mainContentPlaceHolder" Runat="Server">
    <div style="height:600px">
    <asp:Panel ID="Panel1" runat="server" Height="352px" Style="z-index: 100; left: 241px;
        position: absolute; top: 81px" Width="410px">
        <asp:Label ID="Label1" runat="server" Style="z-index: 100; left: 27px; position: absolute;
            top: 16px" Text="Project ID"></asp:Label>
        <asp:Label ID="Label2" runat="server" Style="z-index: 101; left: 17px; position: absolute;
            top: 44px" Text="Project Title"></asp:Label>
        <asp:Label ID="Label3" runat="server" Style="z-index: 102; left: 22px; position: absolute;
            top: 74px" Text="Description"></asp:Label>
        <asp:Label ID="Label4" runat="server" Style="z-index: 103; left: 29px; position: absolute;
            top: 104px" Text="Start Date"></asp:Label>
        <asp:TextBox ID="titleTextBox" runat="server" Style="z-index: 104; left: 135px; position: absolute;
            top: 41px"></asp:TextBox>
        <asp:TextBox ID="descriptionTextBox" runat="server" Style="z-index: 105; left: 135px;
            position: absolute; top: 71px"></asp:TextBox>
        <asp:TextBox ID="startDateTextBox" runat="server" Style="z-index: 106; left: 135px;
            position: absolute; top: 101px"></asp:TextBox>
        <asp:Label ID="Label5" runat="server" Style="z-index: 107; left: 7px; position: absolute;
            top: 134px" Text="Estimate Date"></asp:Label>
        <asp:TextBox ID="estimateDateTextBox" runat="server" Style="z-index: 108; left: 135px;
            position: absolute; top: 131px"></asp:TextBox>
        <asp:Label ID="Label6" runat="server" Style="z-index: 109; left: 12px; position: absolute;
            top: 163px" Text="Client Name: "></asp:Label>
        <asp:Label ID="Label7" runat="server" Style="z-index: 110; left: 54px; position: absolute;
            top: 194px" Text="Status"></asp:Label>
        <asp:DropDownList ID="statusDropDownList" runat="server" Style="z-index: 111; left: 135px;
            position: absolute; top: 191px" OnSelectedIndexChanged="statusDropDownList_SelectedIndexChanged">
            <asp:ListItem>Open</asp:ListItem>
            <asp:ListItem>Close</asp:ListItem>
        </asp:DropDownList>
        <asp:DropDownList ID="clientNameDropDownList" runat="server" Style="z-index: 112;
            left: 135px; position: absolute; top: 160px" Width="153px" OnSelectedIndexChanged="clientNameDropDownList_SelectedIndexChanged" OnDataBound="clientNameDropDownList_DataBound">
        </asp:DropDownList>
        <asp:Label ID="employeesLabel" runat="server" Style="z-index: 113; left: 8px; position: absolute;
            top: 227px" Text="Employee(s) :"></asp:Label>
        &nbsp;
        <asp:TextBox ID="idTextBox" runat="server" Style="z-index: 114; left: 135px; position: absolute;
            top: 13px"></asp:TextBox>
        <asp:Label ID="dateEGLabel" runat="server" Height="18px" Style="z-index: 115; left: 294px;
            position: absolute; top: 132px" Text="(mm/dd/yyyy)"></asp:Label>
        <asp:Label ID="Label8" runat="server" Height="18px" Style="z-index: 116; left: 293px;
            position: absolute; top: 105px" Text="(mm/dd/yyyy)"></asp:Label>
        <asp:ListBox ID="allEmployeeListBox" runat="server" Style="z-index: 117; left: 135px; position: absolute;
            top: 227px" Height="120px" Width="100px"></asp:ListBox>
        <asp:Button ID="singleAddButton" runat="server" Style="z-index: 118; left: 250px;
            position: absolute; top: 227px" Text=">" Width="30px" OnClick="singleAddButton_Click" />
        <asp:Button ID="singleRemoveButton" runat="server" Style="z-index: 119; left: 250px;
            position: absolute; top: 321px" Text="<" Width="30px" OnClick="singleRemoveButton_Click" />
        <asp:ListBox ID="selectedEmployeeListBox" runat="server" Height="120px" Style="z-index: 120; left: 294px;
            position: absolute; top: 227px" Width="100px"></asp:ListBox>
        <asp:Button ID="allAddButton" runat="server" Style="z-index: 121; left: 250px; position: absolute;
            top: 258px" Text=">>" Width="30px" OnClick="allAddButton_Click" />
        <asp:Button ID="allRemoveButton" runat="server" Style="z-index: 123; left: 250px;
            position: absolute; top: 289px" Text="<<" Width="30px" OnClick="allRemoveButton_Click" />
    </asp:Panel>
    <asp:Button ID="saveButton" runat="server"  Style="z-index: 101;
        left: 250px; position: absolute; top: 450px" Width="400px" Text="Save" OnClick="saveButton_Click" CssClass="btn-outline-primary"  />
    <asp:Label ID="successLabel" runat="server" Style="z-index: 102; left: 210px; position: absolute;
        top: 230px" ForeColor="Green"></asp:Label>
    <asp:Label ID="errorLabel" runat="server" ForeColor="Red" Style="z-index: 105; left: 210px;
        position: absolute; top: 250px"></asp:Label>
    <asp:GridView ID="projectGridView" runat="server" Style="z-index: 104; left: 80px;
        position: absolute; top: 500px" OnSelectedIndexChanged="projectGridView_SelectedIndexChanged">
    </asp:GridView>
    <table>
        <tr>
            <td align="center" style="width: 949px; color: window; background-color: royalblue;">
                <h3>
                    Enter Project Information</h3></td>
        </tr>
    </table>
    </div>
</asp:Content>

