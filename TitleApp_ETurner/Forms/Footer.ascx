<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Footer.ascx.cs" Inherits="TitleApp_ETurner.Forms.Footer" %>
<style type="text/css">
    a
    {
       text-decoration:none
    }
</style>
<div id="footer_container">
    
    
    <table cellpadding="0px" cellspacing="0px" width="100%" border="0px">
    <tr>
        <td align="center">
            <asp:Button ID="f_home" ToolTip="go back to portal home" runat="server" Text="Home"
                BorderStyle="None" ForeColor="Maroon" BackColor="White" BorderColor="White" />
            <%--<a href="javascript:document.frmHome.submit();">Home</a>--%>&nbsp;&nbsp;|&nbsp;&nbsp;
            <asp:Button ID="f_contact" ToolTip="Contact" runat="server" Text="Contact" BorderStyle="None"
                ForeColor="Maroon" BackColor="White" BorderColor="White" />
              &nbsp;&nbsp;|&nbsp;&nbsp;
            <asp:Button ID="f_Turnerhome" runat="server" Text="Turner Home Page" BackColor="White" BorderColor="White" BorderStyle="None" ForeColor="Maroon"></asp:Button>&nbsp;&nbsp;|&nbsp;&nbsp;<asp:Button
                ID="f_Logout" ToolTip="logout" runat="server" Text="Logout" BorderStyle="None"
                ForeColor="Maroon" BackColor="White" BorderColor="White" />
        </td>
    </tr>
    </table>
</div>