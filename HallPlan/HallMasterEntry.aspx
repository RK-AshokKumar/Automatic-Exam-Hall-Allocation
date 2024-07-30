<%@ Page Language="C#" MasterPageFile="~/AdminMasterPage.master" AutoEventWireup="true" CodeFile="HallMasterEntry.aspx.cs" Inherits="Default2" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">

        .style1
        {
        	font-size:large;
            text-align: right;
            width: 257px;
        }
       
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <h2 class="pagetitle">Hall Master Entry</h2>
    <table style="width: 81%;" align="center">
            <tr>
                <td class="style1" style="text-align: right">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style1" style="text-align: right">
                    Hall
                    Name :</td>
                <td>
                    <asp:TextBox ID="txt_hname" runat="server" Width="400px" Font-Size="15pt"></asp:TextBox>
                <asp:Button ID="btn_delete" runat="server" OnClick="btn_delete_Click" Text="Delete" Font-Size="15pt" Height="30px" Width="100px" />
                </td>
                <td>
                    
                </td>
            </tr>
            <tr>
                <td class="style1" style="text-align: right">
                    Capacity :</td>
                <td>
                    <asp:TextBox ID="txt_capacity" runat="server" Width="100px" Font-Size="15pt"></asp:TextBox>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style1" style="text-align: right">
                    Rows :</td>
                <td>
                    <asp:TextBox ID="txt_row" runat="server" Width="50px" Font-Size="15pt"></asp:TextBox>
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="style1" style="text-align: right">
                    Columns :</td>
                <td>
                    <asp:TextBox ID="txt_col" runat="server" Width="50px" Font-Size="15pt"></asp:TextBox>
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="style1" style="text-align: right">
                    Department Code :</td>
                <td>
                    <asp:TextBox ID="txt_deptcode" runat="server" Width="251px" Font-Size="15pt"></asp:TextBox>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style1">
                    &nbsp;</td>
                <td>
                    <asp:Button  ID="btn_Update" runat="server" Text="Update" 
                        onclick="btnUpdate_Click" Height="42px" Width="125px" Font-Size="15pt" />
                &nbsp;
                    </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style1">
                    &nbsp;</td>
                <td>
                    <asp:Label ID="lblmsg" runat="server" Font-Size="12pt"></asp:Label>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
        
   
    
        <table style="width: 70%;" align="center">
            <tr align="center">
                <td>
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

