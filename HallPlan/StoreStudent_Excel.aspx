<%@ Page Language="C#" MasterPageFile="~/AdminMasterPage.master" AutoEventWireup="true" CodeFile="StoreStudent_Excel.aspx.cs" Inherits="Default2" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style1
        {
            width: 222px;
            text-align: right;
        }
        .style2
        {
            width: 481px;
        }
        .style3
        {
            width: 481px;
            color: #FF3300;
            font-weight: bold;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <h2 class="pagetitle">Student Registration</h2>
        <table style="width: 81%;" align="center">
            <tr>
                <td class="style1">
                    &nbsp;</td>
                <td class="style3">
                    Create Excel File with extenson .xsl ( Excel 97-2003 Format)</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style1">
                    &nbsp;</td>
                <td class="style2">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style1">
                    Select Excel File to Upload </td>
                <td class="style2">
                    <asp:FileUpload ID="FileUpload1" runat="server" Height="24px" Width="341px" 
                        Font-Size="12pt" />
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style1">
                    Selected File :</td>
                <td class="style2">
                    <asp:Label ID="Label1" runat="server"></asp:Label>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style1">
                    &nbsp;</td>
                <td class="style2">
                    <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Load" 
                        Height="28px" Width="64px" Font-Size="12pt" />
                </td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
        
   
    
        <table style="width: 80%;" align="center">
            <tr align="center">
                <td colspan="2">
                    &nbsp;</td>
            </tr>
            <tr align="center">
                <td colspan="2">
                    <asp:GridView ID="gvExcelFile" runat="server" BackColor="White" 
                        BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" 
                        ForeColor="Black" GridLines="Vertical">
                        <FooterStyle BackColor="#CCCCCC" />
                        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                        <AlternatingRowStyle BackColor="#CCCCCC" />
                    </asp:GridView>
                </td>
            </tr>
            <tr align="center">
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr align="center">
                <td>
                    &nbsp;</td>
                <td>
                    <asp:Button ID="Button3" runat="server"  Text="Update Records " 
                        Width="227px" Font-Size="12pt" onclick="Button3_Click" />
                    <asp:Button ID="Button2" runat="server" onclick="Button2_Click" Text="Delete Records and Store " 
                        Width="201px" Font-Size="12pt" />
                </td>
            </tr>
            <tr align="center">
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr align="center">
                <td colspan="2">
                    <asp:GridView ID="GridView1" runat="server" BackColor="White" 
                        BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" 
                        ForeColor="Black" GridLines="Vertical">
                        <FooterStyle BackColor="#CCCCCC" />
                        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                        <AlternatingRowStyle BackColor="#CCCCCC" />
                    </asp:GridView>
                </td>
            </tr>
            </table>
        
    </asp:Content>

