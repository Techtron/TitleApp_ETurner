<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Title.aspx.cs" Inherits="TitleApp_ETurner.Title" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Home" ContentPlaceHolderID="Main" runat="server">

    <div style="padding-left: 30px; padding-top: 20px;">
        <div>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
            
                <ContentTemplate>
                    <asp:Panel ID="pnlSearch" runat="server">
                        <div style="width: 900px; height:300px">
                            <fieldset style="height:200px" class="Main">
                                <legend class="Main">Title Search</legend>
                                <asp:Panel ID="pnlSearchCredential" runat="server">
                                <asp:Label ID="lblMessage" runat="server"></asp:Label> <br /><br />
                                Enter Title: <asp:TextBox ID="txtTitle" runat="server" Width="200px"></asp:TextBox>&nbsp; <span style="color: Red">*</span> &nbsp;
                                <asp:RequiredFieldValidator ID="rfldTitle" runat="server" ControlToValidate="txtTitle"
                                                    SetFocusOnError="true" Display="Dynamic" ForeColor="Red" ErrorMessage="Required"></asp:RequiredFieldValidator>
                                <asp:Button ID="btnSearch" runat="server" Text="Search" Width="80px" Height="25px" 
                                        onclick="btnSearch_Click" />
                                </asp:Panel>
                            </fieldset>
                        </div>
                     
                            <asp:Panel ID="pnlResults" Visible="false" runat="server">
                            <div style="width: 980px; padding: 1px 5px 15px 10px;">
                            <asp:GridView ID="gvSearchResults" DataKeyNames="TitleID" runat="server" 
                                     AutoGenerateColumns="false" CssClass="mGrid" 
                                    OnRowCommand="gvSearchResults_RowCommand" Width="100%" AllowPaging="true" AllowSorting="true"
                                    PageSize="10" PagerStyle-CssClass="pgr" OnSorting="gvSearchResults_OnSorting" OnPageIndexChanging="gvSearchResults_PageIndexChanging"
                                    PagerStyle-ForeColor="Gray" AlternatingRowStyle-CssClass="alt" CellPadding="2"
                                    ForeColor="#333333" BorderWidth="1" HorizontalAlign="Left" GridLines="None"
                                    HeaderStyle-Wrap="true" EmptyDataText="No Results for this search!">
                                    <Columns>
                                        <asp:TemplateField HeaderStyle-Font-Bold="true" ItemStyle-Width="5%" ItemStyle-HorizontalAlign="Left" HeaderStyle-ForeColor="#FFF550"
                                             SortExpression="TitleID"
                                            ItemStyle-VerticalAlign="Middle" HeaderStyle-HorizontalAlign="Left" HeaderStyle-Wrap="true"
                                            HeaderText="Title" ItemStyle-Wrap="true">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lbtnSelect" runat="server" CommandName="NodeSelected" ForeColor="#4F709F"
                                                    Text='<%#Eval("TitleID")%>' Font-Bold="true" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"
                                                    Style="text-decoration: none;"></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:BoundField DataField="TitleName" ItemStyle-HorizontalAlign="center" HeaderStyle-ForeColor="#FFF550"
                                          HeaderStyle-Wrap="true" SortExpression="TitleName"
                                            HeaderStyle-HorizontalAlign="Center" ItemStyle-Wrap="false" HeaderText="Title Name">
                                            <ItemStyle Wrap="False" Width="5%" CssClass="" />
                                            <HeaderStyle Font-Bold="True" />
                                        </asp:BoundField>

                                          <asp:BoundField DataField="ReleaseYear" ItemStyle-HorizontalAlign="center" HeaderStyle-ForeColor="#FFF550"
                                          HeaderStyle-Wrap="true" SortExpression="ReleaseYear"
                                            HeaderStyle-HorizontalAlign="Center" ItemStyle-Wrap="false" HeaderText="Release Year">
                                            <ItemStyle Wrap="False" Width="5%" CssClass="" />
                                            <HeaderStyle Font-Bold="True" />
                                        </asp:BoundField>

                                          <asp:BoundField DataField="Language" ItemStyle-HorizontalAlign="center" HeaderStyle-ForeColor="#FFF550"
                                          HeaderStyle-Wrap="true" SortExpression="Language"
                                            HeaderStyle-HorizontalAlign="Center" ItemStyle-Wrap="false" HeaderText="Language">
                                            <ItemStyle Wrap="False" Width="5%" CssClass="" />
                                            <HeaderStyle Font-Bold="True" />
                                        </asp:BoundField>

                                          
                                    </Columns>

                                    </asp:GridView>
                            </div>

                            </asp:Panel>

                       </asp:Panel>

                        <asp:Panel ID="pnlTitleDetail" Visible="false" runat="server">
                        <div>
                            <div style="width: 980px;">
                                <fieldset class="Main">
                                    <legend class="Main">Title Detail Screen</legend>
                       <div>
                       <table>
                       <tr>
                       <td>
                       Title ID:
                       </td>
                       <td>
                       <asp:Label ID="lblTitleID" runat="server"></asp:Label>
                       </td>
                       </tr>
                         <tr>
                       <td>
                       Title Name:
                       </td>
                       <td>
                       <asp:Label ID="lblTitleName" runat="server"></asp:Label>
                       </td>
                       </tr>
                         <tr>
                       <td>
                       Language:
                       </td>
                       <td>
                       <asp:Label ID="lblLanguage" runat="server"></asp:Label>
                       </td>
                       </tr>
                         <tr>
                       <td>
                       Release Year:
                       </td>
                       <td>
                       <asp:Label ID="lblReleaseYear" runat="server"></asp:Label>
                       </td>
                       </tr>
                       <tr>
                       <td colspan="2"></td>
                       </tr>
                       <tr>
                       <td colspan="2" align="center">
                       <asp:Button ID="btnBack" runat="server" Text="Back to search" Height="25px" Width="100px" 
                               onclick="btnBack_Click" />
                       </td>
                       </tr>
                       </table>
                       </div>
                       </fieldset>
                       </div>
                       
                       </asp:Panel>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>
