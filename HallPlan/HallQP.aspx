<%@ Page Language="C#" MasterPageFile="~/AdminMasterPage.master" AutoEventWireup="true" CodeFile="HallQP.aspx.cs" Inherits="Default2" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
table, td, th {  
  border: 1px solid #ddd;
  text-align: left;
}

table {
  border-collapse: collapse;
  width: 50%;
}

th, td {
  padding: 5px;
}
</style>


    <style type="text/css">

        .style1
        {
        	font-size:large;
            text-align: right;
            width: 30%;
        }
       
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <h2 class="pagetitle">Question Paper Distribution </h2>
    <table style="width: 100%;" align="center">
            <tr>
                <td class="style1" style="text-align: right">
                    Date of Examination :</td>
                <td>
                    <asp:DropDownList ID="drp_examdate" runat="server" AutoPostBack="True" OnSelectedIndexChanged="drp_examdate_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
                
            </tr>
            <tr>
                <td class="style1" style="text-align: right">
                    Session :</td>
                <td>
                    <asp:RadioButton ID="RadioButton1" runat="server" Checked="True" GroupName="rr"   Text="FN" AutoPostBack="True"   />
&nbsp;<asp:RadioButton ID="RadioButton2" runat="server" GroupName="rr" Text="AN" AutoPostBack="True"   />
                </td>
                
            </tr>
            <tr>
                <td class="style1" style="text-align: right">
                    &nbsp;</td>
                <td>
                    <asp:Button ID="btn_hallplan" runat="server" OnClick="btn_hallplan_Click" Text="Show" Height="38px" Width="123px" />
                    <asp:Button ID="btn_hall_print" runat="server" OnClick="btn_print_Click" Text="Print" style="margin-left: 454px" Height="28px" Width="93px" />
                </td>
                
            </tr>
            <tr>
                <td class="style1" style="text-align: right">
                    Total Number of Candidates:</td>
                <td>
                    <asp:Label ID="lbl_count" runat="server"></asp:Label>
                </td>
                
            </tr>
            <tr>
                <td class="style1" style="text-align: right">
                    &nbsp;</td>
                <td>
                    <strong>Question Paper Distribution Chart</strong></td>
                
            </tr>
            <tr>
                <td class="style1" style="text-align: right">
                    &nbsp;</td>
                <td>
                    <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
                        <AlternatingRowStyle BackColor="White" />
                        <EditRowStyle BackColor="#2461BF" />
                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#EFF3FB" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#F5F7FB" />
                        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                        <SortedDescendingCellStyle BackColor="#E9EBEF" />
                        <SortedDescendingHeaderStyle BackColor="#4870BE" />
                    </asp:GridView>
                </td>
                
            </tr>
            <tr>
                <td class="style1" style="text-align: right">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                
            </tr>
            <tr>
                <td class="style1" style="text-align: right">
                    &nbsp;</td>
                <td>
                    <strong>Department wise Question Paper Count</strong></td>
                
            </tr>
            <tr>
                <td class="style1" style="text-align: right">
                    &nbsp;</td>
                <td>
                     <asp:GridView ID="GridView2" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
                        <AlternatingRowStyle BackColor="White" />
                        <EditRowStyle BackColor="#2461BF" />
                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#EFF3FB" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#F5F7FB" />
                        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                        <SortedDescendingCellStyle BackColor="#E9EBEF" />
                        <SortedDescendingHeaderStyle BackColor="#4870BE" />
                    </asp:GridView></td>
                
            </tr>
            <tr>
                <td class="style1" style="text-align: right">
                    &nbsp;</td>
                <td>
        </td>
                
            </tr>
            </table>
         
         
   
        </asp:Content>

