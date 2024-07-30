<%@ Page Language="C#" MasterPageFile="~/AdminMasterPage.master" AutoEventWireup="true" CodeFile="Student_Update.aspx.cs" Inherits="Default2" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">

        .style1
        {
        	font-size:large;
            text-align: right;
            width: 257px;
        }
       
        .auto-style5 {
            font-size: large;
            text-align: right;
            width: 257px;
            height: 24px;
        }
        .auto-style6 {
            height: 24px;
        }
       
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <h2 class="pagetitle">Hall Master Entry</h2>
    <table style="width: 81%;" align="center">
            <tr>
                <td class="style1" style="text-align: right">
                    Student Register Number :</td>
                <td>
                    <asp:TextBox ID="txt_regno" runat="server" Width="274px" Font-Size="15pt"></asp:TextBox>
                <asp:Button ID="btn_edit" runat="server"  Text="Edit" Font-Size="15pt" Height="30px" Width="100px" OnClick="btn_edit_Click" />
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style1" style="text-align: right">
                    Student Name :</td>
                <td>
                    <asp:TextBox ID="txt_name" runat="server" Width="400px" Font-Size="15pt"></asp:TextBox>
                </td>
                <td>
                    
                </td>
            </tr>
            <tr>
                <td class="style1" style="text-align: right">
                    Deparment Code :</td>
                <td>
                    <asp:TextBox ID="txt_deptcode" runat="server" Width="131px" Font-Size="15pt"></asp:TextBox>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style1" style="text-align: right">
                    Year of Study :</td>
                <td>
                    <asp:TextBox ID="txt_year" runat="server" Width="109px" Font-Size="15pt"></asp:TextBox>
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="style1" style="text-align: right">
                    Semester :</td>
                <td>
                    <asp:TextBox ID="txt_sem" runat="server" Width="54px" Font-Size="15pt"></asp:TextBox>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style5" style="text-align: right">
                    Section :</td>
                <td class="auto-style6">
                    <asp:TextBox ID="txt_sec" runat="server" Width="56px" Font-Size="15pt"></asp:TextBox>
                </td>
                <td class="auto-style6">
                </td>
            </tr>
            <tr>
                <td class="style1" style="text-align: right">
                    Mobile :</td>
                <td>
                    <asp:TextBox ID="txt_mobile" runat="server" Width="251px" Font-Size="15pt"></asp:TextBox>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style1">
                    &nbsp;</td>
                <td>
                    <asp:Button  ID="btn_Update" runat="server" Text="Add/Update" 
                        onclick="btnUpdate_Click" Height="30px" Width="143px" Font-Size="15pt" />
                &nbsp;
                    <asp:Button ID="btn_delete" runat="server" OnClick="btn_delete_Click" Text="Delete" Font-Size="15pt" Height="30px" Width="100px" />
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

