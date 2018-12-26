<%@ Page Language="C#" MasterPageFile="~/UI/MasterPageNormalUser.master" AutoEventWireup="true" CodeFile="~/UI/NormalUserUIPage.aspx.cs" Inherits="UI_NormalUserUIPage" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div style="height:452px">
    <div>
        
        <table style="z-index: 100; left: 220px; position: absolute; top: 301px">
            <tr>
                <td colspan="2">
                    &nbsp;<br />
                </td>
            </tr>
            <tr>
                <td style="width: 100px">
                </td>
                <td style="width: 100px">
                </td>
            </tr>
            <tr>
                <td style="width: 100px">
        <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Size="X-Large" Text="Involved Projects" Width="297px"></asp:Label></td>
                <td style="width: 100px">
        <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="X-Large" Text="Individual Tasks" Width="285px"></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 100px; height: 1px">
        <asp:Label ID="numberOfProjectsLabel" runat="server" Font-Size="Large" Width="296px"></asp:Label></td>
                <td style="width: 100px; height: 1px">
        <asp:Label ID="numberOfTasksLabel" runat="server" Font-Size="Large" Width="292px"></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 100px; height: 41px;">
        <asp:BulletedList ID="projectListBulletedList" runat="server" Font-Bold="False" Font-Size="Large"
            ForeColor="#0000C0" Style="left: -30px; top: 131px; z-index: 100; position: absolute;" Width="234px">
        </asp:BulletedList>
                </td>
                <td style="width: 100px; height: 41px;">
        <asp:BulletedList ID="tasksOfUserBulletedList" runat="server" DisplayMode="LinkButton"
            Font-Size="Large" OnClick="tasksOfUserBulletedList_Click" style="z-index: 100; left: 273px; position: absolute; top: 130px" Width="208px">
        </asp:BulletedList>
                </td>
            </tr>
        </table>
        <table>
        <tr>
            <td align="center" style="width: 951px; color: window; background-color: royalblue;">
                <h3>
                    Welcome User</h3></td>
        </tr>
        </table>
        <asp:Label ID="Label4" runat="server" Style="z-index: 100; left: 210px; position: absolute;
            top: 245px" ForeColor="Red"></asp:Label>
    </div>
</div>

</asp:Content>

