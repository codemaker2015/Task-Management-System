<%@ Page Language="C#" MasterPageFile="~/UI/MasterPage.master" AutoEventWireup="true" CodeFile="ClientSaveInfoUIPage.aspx.cs" Inherits="UI_ClientSaveInfoUIPage" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="mainContentPlaceHolder" Runat="Server">
<div style="height:600px">
    <div>
        <div id="DIV1" onclick="return DIV1_onclick()" style="z-index: 101; left: 334px;
            width: 474px; position: absolute; top: 271px; height: 422px">
            <asp:Label ID="idLabel" runat="server" BorderStyle="Groove" Font-Size="Medium" Style="z-index: 100;
                left: 216px; position: absolute; top: 35px" Width="199px"></asp:Label>
            <asp:Label ID="nameLabel" runat="server" BorderStyle="Groove" Font-Size="Medium"
                Style="z-index: 101; left: 216px; position: absolute; top: 73px" Width="199px"></asp:Label>
            <asp:Label ID="contactPersonLabel" runat="server" BorderStyle="Groove" Font-Size="Medium"
                Style="z-index: 102; left: 216px; position: absolute; top: 109px" Width="199px"></asp:Label>
            <asp:Label ID="contactDateLabel" runat="server" BorderStyle="Groove" Font-Size="Medium"
                Style="z-index: 103; left: 216px; position: absolute; top: 143px" Width="199px"></asp:Label>
            &nbsp; &nbsp;
            <asp:Label ID="Label8" runat="server" Style="z-index: 104; left: 98px; position: absolute;
                top: 39px" Text="Client Id: "></asp:Label>
            <asp:Label ID="Label9" runat="server" Style="z-index: 105; left: 46px; position: absolute;
                top: 79px" Text="Company Name : "></asp:Label>
            <asp:Label ID="Label10" runat="server" Style="z-index: 106; left: 56px; position: absolute;
                top: 114px" Text="Contact Person: "></asp:Label>
            <asp:Label ID="Label11" runat="server" Style="z-index: 107; left: 69px; position: absolute;
                top: 147px" Text="Contact Date: "></asp:Label>
            &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
            <asp:Label ID="Label2" runat="server" Style="z-index: 110; left: 89px; position: absolute;
                top: 179px" Text="Address: " Width="64px"></asp:Label>
            <asp:Label ID="addressLabel" runat="server" BorderStyle="Groove" Font-Size="Medium"
                Style="z-index: 111; left: 214px; position: absolute; top: 175px" Width="199px"></asp:Label>
            &nbsp;&nbsp;
            <asp:Label ID="Label3" runat="server" Style="z-index: 114; left: 97px; position: absolute;
                top: 214px" Text="Phone: " Width="56px"></asp:Label>
            <asp:Label ID="phoneLabel" runat="server" BorderStyle="Groove" Font-Size="Medium"
                Style="z-index: 115; left: 213px; position: absolute; top: 208px" Width="199px"></asp:Label>
            <asp:Label ID="Label4" runat="server" Style="z-index: 116; left: 104px; position: absolute;
                top: 250px" Text="Email: " Width="49px"></asp:Label>
            <asp:Label ID="emailLabel" runat="server" BorderStyle="Groove" Font-Size="Medium"
                Style="z-index: 117; left: 213px; position: absolute; top: 244px" Width="199px"></asp:Label>
            <asp:Button ID="saveButton" runat="server"  Style="z-index: 118;
                left: 86px; position: absolute; top: 389px" Text="Save" Width="155px" OnClick="saveButton_Click" />
            <asp:Button ID="cancelButton" runat="server"  Style="z-index: 120;
                left: 249px; position: absolute; top: 389px" Text="Cancel" Width="155px" OnClick="cancelButton_Click" />
        </div>
        <asp:Label ID="errorMessageLabel" runat="server" Style="z-index: 102; left: 210px;
            position: absolute; top: 230px" Width="169px" ForeColor="Red"></asp:Label>
        <table>
        <tr>
            <td align="center" style="width: 950px; color: window; background-color: royalblue;">
                <h3>
                    Make Sure All Information Is Right</h3></td>
        </tr>
    </table>
    </div>
</div>

</asp:Content>

