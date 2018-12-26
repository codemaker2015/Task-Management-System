<%@ Page Language="C#" MasterPageFile="~/UI/MasterPage.master" AutoEventWireup="true" CodeFile="ClientCreateUIPage.aspx.cs" Inherits="UI_ClientCreateUIPage" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="mainContentPlaceHolder" Runat="Server">
<div style="height:600px; ">
    <div align="center" style="z-index: 102; left: 388px; width: 333px; position: absolute;
        top: 300px; height: 266px">
        <asp:Label ID="Label2" runat="server" Font-Size="Small" Style="z-index: 100; left: 24px;
            position: absolute; top: 43px" Text="Company Name:"></asp:Label>
        <asp:Label ID="Label8" runat="server" Font-Size="Small" Style="z-index: 101; left: 61px;
            position: absolute; top: 14px" Text="Client ID:"></asp:Label>
        <asp:Label ID="Label3" runat="server" Font-Size="Small" Style="z-index: 102; left: 26px;
            position: absolute; top: 75px" Text="Contact Person:"></asp:Label>
        <asp:Label ID="Label4" runat="server" Font-Size="Small" Style="z-index: 103; left: 38px;
            position: absolute; top: 107px" Text="Contact Date:"></asp:Label>
        <asp:Label ID="Label5" runat="server" Font-Size="Small" Style="z-index: 104; left: 62px;
            position: absolute; top: 139px" Text="Address:"></asp:Label>
        <asp:Label ID="Label6" runat="server" Font-Size="Small" Style="z-index: 105; left: 55px;
            position: absolute; top: 169px" Text="Phone No:"></asp:Label>
        <asp:Label ID="Label7" runat="server" Font-Size="Small" Style="z-index: 106; left: 31px;
            position: absolute; top: 197px" Text="Email Address:"></asp:Label>
        <asp:TextBox ID="idTextBox" runat="server" Height="22px" Style="z-index: 107; left: 162px;
            position: absolute; top: 9px" Width="155px"></asp:TextBox>
        <asp:TextBox ID="companyNameTextBox" runat="server" Height="22px" Style="z-index: 108;
            left: 162px; position: absolute; top: 39px" Width="155px"></asp:TextBox>
        <asp:TextBox ID="contactPersonTextBox" runat="server" Height="22px" Style="z-index: 109;
            left: 162px; position: absolute; top: 70px" Width="155px"></asp:TextBox>
        &nbsp;
        <asp:TextBox ID="contactDateTextBox" runat="server" Height="22px" Style="z-index: 111;
            left: 162px; position: absolute; top: 101px" Width="155px"></asp:TextBox>
        <asp:TextBox ID="addressTextBox" runat="server" Height="22px" Style="z-index: 112;
            left: 162px; position: absolute; top: 132px" Width="155px" TextMode="MultiLine"></asp:TextBox>
        <asp:TextBox ID="phoneNoTextBox" runat="server" Height="22px" Style="z-index: 113;
            left: 162px; position: absolute; top: 162px" Width="155px"></asp:TextBox>
        <asp:TextBox ID="emailTextBox" runat="server" Height="23px" Style="z-index: 114;
            left: 162px; position: absolute; top: 192px" Width="156px"></asp:TextBox>
        <asp:Button ID="saveButton" runat="server" Style="z-index: 115;
            left: 114px; position: absolute; top: 235px" Text="Save" Width="98px" OnClick="saveButton_Click" />
        &nbsp;
    </div>
    <asp:Label ID="successLabel" runat="server" Style="z-index: 100; left: 210px; position: absolute;
        top: 225px" Width="143px" ForeColor="Green"></asp:Label>
    <asp:Label ID="errorLabel" runat="server" ForeColor="Red" Style="z-index: 105; left: 210px;
        position: absolute; top: 250px"></asp:Label>
    <asp:GridView ID="clientGridView" runat="server" Style="z-index: 102; left: 200px;
        position: absolute; top: 574px" Caption="All Client Information" CaptionAlign="Top">
    </asp:GridView>
    <table>
        <tr>
            <td align="center" style="width: 951px; color: window; background-color: royalblue;">
                <h3>Enter a New Client Information</h3></td>
        </tr>
    </table>
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    <asp:Label ID="dateEGLabel" runat="server" Style="z-index: 103; left: 719px; position: absolute;
        top: 392px" Text="(mm/dd/yyyy)"></asp:Label>
    <asp:Label ID="emailEGLabel" runat="server" Style="z-index: 104; left: 715px; position: absolute;
        top: 480px" Text="(e.g. name@domain.com)" Width="190px"></asp:Label>
</div>
</asp:Content>

