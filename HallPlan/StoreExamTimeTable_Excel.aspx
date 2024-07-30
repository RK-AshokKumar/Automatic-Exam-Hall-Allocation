<%@ Page Language="C#" MasterPageFile="~/AdminMasterPage.master" AutoEventWireup="true" CodeFile="StoreExamTimeTable_Excel.aspx.cs" Inherits="Default2" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style1
        {
            width: 255px;
            text-align: right;
        }
        .style2
        {
            width: 362px;
        }
        .style3
        {
            width: 255px;
            text-align: right;
            font-size: large;
        }
        .style4
        {
            font-size: large;
        }
        .style5
        {
            width: 362px;
            font-size: large;
        }

       
    </style>
    <script type="text/javascript">
        function funCheck() {
            var flag = confirm('Do you wants to Delete Existing Records and Upload ?');
            var hdnfld = document.getElementById('<%= HiddenField1.ClientID %>');
          hdnfld.value = flag ? '1' : '0';
        }
        function myFunc() {
            var flag = confirm('Roll Number Not Found Please Check Roll Number ?');
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <h2 class="pagetitle">Exam Time Table</h2>
        <table style="width: 70%;" align="center">
            <tr>
                <td class="style3">
                    Select Excel File to Upload </td>
                <td class="style2">
                    <asp:FileUpload ID="FileUpload1" runat="server" Height="24px" Width="341px" 
                        Font-Size="12pt" />
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style3">
                    Selected File :</td>
                <td class="style5">
                    <asp:Label ID="Label1" runat="server"></asp:Label>
                </td>
                <td class="style4">
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
        
   
    
        <table style="width: 70%;" align="center">
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

                    <asp:Button ID="Button2" runat="server" OnClientClick="funCheck()" onclick="Button2_Click" Text="Delete Records and Store " 
                        Width="201px" Font-Size="12pt" />
                     <asp:HiddenField ID="HiddenField1" runat="server" />
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

