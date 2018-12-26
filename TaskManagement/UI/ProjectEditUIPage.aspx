<%@ Page Language="C#" MasterPageFile="~/UI/MasterPage.master" AutoEventWireup="true" CodeFile="ProjectEditUIPage.aspx.cs" Inherits="UI_ProjectEditUIPage" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="mainContentPlaceHolder" Runat="Server">
<div style="height:600px">
                <asp:Label ID="Label1" runat="server" Text="Project ID" style="z-index: 100; left: 355px; position: absolute; top: 327px"></asp:Label>
                <asp:DropDownList ID="projectIdDropDownList" runat="server" AutoPostBack="True" Height="22px"
                     Width="238px" OnSelectedIndexChanged="projectIdDropDownList_SelectedIndexChanged" style="z-index: 101; left: 457px; position: absolute; top: 320px" OnDataBound="projectIdDropDownList_DataBound">
                </asp:DropDownList>
                <asp:Label ID="Label2" runat="server" Style="left: 345px; top: 354px; z-index: 102; position: absolute;" Text="Project Title"></asp:Label>
                <asp:TextBox ID="titleTextBox" runat="server" Height="22px" Width="233px" style="z-index: 103; left: 457px; position: absolute; top: 354px"></asp:TextBox>
                <asp:TextBox ID="descriptionTextBox" runat="server" Height="71px" Width="233px" TextMode="MultiLine" style="z-index: 104; left: 457px; position: absolute; top: 397px"></asp:TextBox>
    <asp:Label ID="Label3" runat="server" Style="z-index: 105; left: 350px; position: absolute;
        top: 397px" Text="Description"></asp:Label>
                <asp:Label ID="Label4" runat="server" Text="Start Date" style="z-index: 106; left: 357px; position: absolute; top: 485px"></asp:Label>
                <asp:TextBox ID="startDateTextBox" runat="server" Height="22px" Width="233px" style="z-index: 107; left: 457px; position: absolute; top: 485px"></asp:TextBox>
                <asp:Label ID="Label5" runat="server" Text="Estimate Date" style="z-index: 108; left: 335px; position: absolute; top: 525px"></asp:Label>
                <asp:TextBox ID="estimateDateTextBox" runat="server" Height="22px" Width="233px" style="z-index: 109; left: 457px; position: absolute; top: 525px"></asp:TextBox>
                <asp:Label ID="Label6" runat="server" Text="Client Name: " style="z-index: 110; left: 340px; position: absolute; top: 567px"></asp:Label>
                <asp:DropDownList ID="clientNameDropDownList" runat="server" Width="233px" style="z-index: 111; left: 457px; position: absolute; top: 567px">
                </asp:DropDownList>
                <asp:Label ID="Label7" runat="server" Text="Status" style="z-index: 112; left: 382px; position: absolute; top: 605px"></asp:Label>
                <asp:Button ID="updateButton" runat="server" Text="Update" OnClick="updateButton_Click" style="z-index: 113; left: 458px; position: absolute; top: 642px" Width="60px" />
                <asp:GridView ID="projectGridView" runat="server" style="z-index: 114; left: 210px; position: absolute; top: 691px">
                </asp:GridView>
    <asp:Label ID="projectStatusLabel" runat="server" Style="z-index: 115; left: 457px;
        position: absolute; top: 605px" Width="100px"></asp:Label>
    <asp:Label ID="successLabel" runat="server" ForeColor="Green" Style="z-index: 116;
        left: 210px; position: absolute; top: 230px"></asp:Label>
    <asp:Label ID="errorLabel" runat="server" ForeColor="Red" Style="z-index: 118; left: 210px;
        position: absolute; top: 250px"></asp:Label>
        <table>
        <tr>
            <td align="center" style="width: 951px; color: window; background-color: royalblue;">
                <h3>
                    Edit Project Information</h3></td>
        </tr>
    </table>
</div>
</asp:Content>

