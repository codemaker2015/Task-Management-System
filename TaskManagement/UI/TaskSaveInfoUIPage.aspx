<%@ Page Language="C#" MasterPageFile="~/UI/MasterPage.master" AutoEventWireup="true" CodeFile="TaskSaveInfoUIPage.aspx.cs" Inherits="UI_TaskSaveInfoUIPage" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="mainContentPlaceHolder" Runat="Server">
<div style="height:600px">
    <div>
        <table>
        <tr>
            <td align="center" style="width: 950px; color: window; background-color: royalblue;">
                <h3>
                    Make Sure All Information Is Right</h3></td>
        </tr>
    </table>
        <div id="DIV1" onclick="return DIV1_onclick()" style="z-index: 100; left: 242px;
            width: 493px; position: absolute; top: 281px; height: 422px">
            <asp:Label ID="idLabel" runat="server" BorderStyle="Groove" Font-Size="Medium" Style="z-index: 100;
                left: 216px; position: absolute; top: 35px" Width="199px"></asp:Label>
            <asp:Label ID="nameLabel" runat="server" BorderStyle="Groove" Font-Size="Medium"
                Style="z-index: 101; left: 216px; position: absolute; top: 73px" Width="199px"></asp:Label>
            <asp:Label ID="descriptionLabel" runat="server" BorderStyle="Groove" Font-Size="Medium"
                Style="z-index: 102; left: 216px; position: absolute; top: 109px" Width="199px"></asp:Label>
            <asp:Label ID="startDateLabel" runat="server" BorderStyle="Groove" Font-Size="Medium"
                Style="z-index: 103; left: 216px; position: absolute; top: 143px" Width="199px"></asp:Label>
            &nbsp; &nbsp;
            <asp:Label ID="Label8" runat="server" Style="z-index: 104; left: 98px; position: absolute;
                top: 39px" Text="Task Id: "></asp:Label>
            <asp:Label ID="Label9" runat="server" Style="z-index: 105; left: 108px; position: absolute;
                top: 79px" Text="Name: "></asp:Label>
            <asp:Label ID="Label10" runat="server" Style="z-index: 106; left: 76px; position: absolute;
                top: 114px" Text="Description: "></asp:Label>
            <asp:Label ID="Label11" runat="server" Style="z-index: 107; left: 83px; position: absolute;
                top: 147px" Text="Start Date: "></asp:Label>
            &nbsp; &nbsp;
            <asp:Label ID="estimateTimeLabel" runat="server" BorderStyle="Groove" Font-Size="Medium"
                Style="z-index: 108; left: 215px; position: absolute; top: 175px" Width="199px"></asp:Label>
            <asp:Label ID="Label1" runat="server" Style="z-index: 109; left: -1px; position: absolute;
                top: 180px" Text="Estimated Finishing Date: "></asp:Label>
            &nbsp;&nbsp;
            <asp:Button ID="saveButton" runat="server"  Style="z-index: 110;
                left: 98px; position: absolute; top: 383px" Text="Save" Width="155px" OnClick="SaveButton_Click" />
            <asp:Button ID="cancelButton" runat="server"  Style="z-index: 111;
                left: 258px; position: absolute; top: 382px" Text="Cancel" Width="155px" OnClick="cancelButton_Click" />
            <asp:Label ID="Label2" runat="server" Style="z-index: 112; left: 62px; position: absolute;
                top: 211px" Text="Employee Id: " Width="86px"></asp:Label>
            <asp:Label ID="employeeIdLabel" runat="server" BorderStyle="Groove" Font-Size="Medium"
                Style="z-index: 113; left: 214px; position: absolute; top: 207px" Width="199px"></asp:Label>
            <asp:Label ID="Labelproject" runat="server" Style="z-index: 114; left: 62px; position: absolute;
                top: 318px" Text="Project Id: " Width="86px"></asp:Label>
            <asp:Label ID="projectIdLabel" runat="server" BorderStyle="Groove" Font-Size="Medium"
                Style="z-index: 115; left: 214px; position: absolute; top: 313px" Width="199px"></asp:Label>
            <asp:Label ID="Label3" runat="server" Style="z-index: 116; left: 79px; position: absolute;
                top: 246px" Text="Assign To:" Width="69px"></asp:Label>
            <asp:Label ID="employeeNameLabel" runat="server" BorderStyle="Groove" Font-Size="Medium"
                Style="z-index: 117; left: 213px; position: absolute; top: 240px" Width="199px"></asp:Label>
            <asp:Label ID="Label4" runat="server" Style="z-index: 118; left: 62px; position: absolute;
                top: 282px" Text="Project Title: " Width="86px"></asp:Label>
            <asp:Label ID="projectTitleLabel" runat="server" BorderStyle="Groove" Font-Size="Medium"
                Style="z-index: 120; left: 213px; position: absolute; top: 276px" Width="199px"></asp:Label>
        </div>
        <asp:Label ID="errorMessageLabel" runat="server" Style="z-index: 101; left: 210px;
            position: absolute; top: 230px" Width="169px" ForeColor="Red"></asp:Label>
    </div>
</div>
</asp:Content>

