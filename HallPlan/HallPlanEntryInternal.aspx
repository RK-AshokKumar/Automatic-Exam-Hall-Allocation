<%@ Page Language="C#" MasterPageFile="~/AdminMasterPage.master" AutoEventWireup="true" CodeFile="HallPlanEntryInternal.aspx.cs" Inherits="Default2" Title="Untitled Page" %>

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
            text-align: center;
            width: 308px;
        }
       
        .auto-style6 {
            text-align: right;
            width: 308px;
        }
        .auto-style7 {
            font-size: large;
            text-align: right;
            width: 308px;
        }
        .auto-style8 {
            font-size: large;
            text-align: center;
            width: 308px;
            height: 35px;
        }
        .auto-style9 {
            height: 35px;
        }
        .auto-style11 {
            height: 35px;
            text-align: center;
        }
        .auto-style12 {
            font-size: large;
            text-align: center;
        }
        .auto-style13 {
            font-size: large;
        }
       
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

 <h2 class="pagetitle">Hall Plan Entry</h2>
    <table style="width: 81%;" align="center">
            <tr>
                <td class="auto-style7" style="text-align: right">
                    &nbsp;</td>
                <td>
                    <strong>
                    <asp:Label ID="lbl_msg" runat="server" Text="" CssClass="auto-style13"></asp:Label>
                    </strong>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style7" style="text-align: right">
                    Date of Examination :</td>
                <td>
                    <asp:DropDownList ID="drp_examdate" runat="server" AutoPostBack="True" OnSelectedIndexChanged="drp_examdate_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
                <td>
                    &nbsp;
                </td>
                        </tr>
            <tr>
                <td class="auto-style7" style="text-align: right">
                    Session :</td>
                <td>
                    <asp:RadioButton ID="RadioButton1" runat="server" Checked="True" GroupName="rr" OnCheckedChanged="RadioButton1_CheckedChanged" Text="FN" />
&nbsp;<asp:RadioButton ID="RadioButton2" runat="server" GroupName="rr" Text="AN" />
                </td>
                <td>
                    &nbsp;</td>
                        </tr>
            <tr>
                <td class="auto-style7" style="text-align: right">
                    &nbsp;</td>
                <td>
                    <asp:Button ID="btn_load" runat="server" OnClick="btn_load_Click" Text="Load" />
                </td>
                <td>
                    &nbsp;</td>
                        </tr>
            <tr>
                <td class="auto-style12" colspan="3">
                    <asp:GridView ID="grd_timetable" runat="server" BackColor="White" 
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
            <tr>
                <td class="auto-style7">
                    &nbsp;Number of Seat Required :</td>
                <td>
                    <strong>
                    <asp:Label ID="lbl_totalcandi" runat="server"></asp:Label>
                    </strong>&nbsp;( Total Candidate Registered )</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style8">
                    Available Hall Capacity </td>
                <td class="auto-style11">
                    Selected&nbsp; Hall&nbsp; Capacity</td>
                <td class="auto-style9">
                    </td>
            </tr>
            <tr>
                <td class="auto-style5">
                    <asp:Label ID="lbl_capacity" runat="server"></asp:Label>
                </td>
                <td class="auto-style1">
                    <asp:Label ID="lbl_allocated" runat="server"></asp:Label>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style5">
                    Available Hall</td>
                <td class="auto-style1">
                    Selected&nbsp; Hall to Allocate Seat</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style6">
                     <asp:ListBox ID="lst_hall_available" SelectionMode="Multiple" runat="server" Height="150px" Width="200px" OnSelectedIndexChanged="lst_hall_available_SelectedIndexChanged"></asp:ListBox>
                </td>
                <td class="auto-style1">
                    <asp:ListBox ID="lst_hall_allocated" runat="server" Height="150px" Width="200px"></asp:ListBox>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style7">
                    &nbsp;</td>
                <td>
                    <asp:Button ID="btn_addHall" runat="server" Height="36px" Text="&gt;&gt;" Width="94px" OnClick="btn_addHall_Click" />
&nbsp;<asp:Button ID="btn_removeHall" runat="server" Height="36px" Text="&lt;&lt;" Width="94px" OnClick="btn_removeHall_Click" />
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style7">
                    Hall Allocation</td>
                <td>
                    <asp:RadioButton ID="rd_seq" runat="server" Checked="True" GroupName="pp" Text="Sequential Allocation" />
&nbsp;&nbsp;&nbsp;
                    <asp:RadioButton ID="rd_random" runat="server" GroupName="pp" Text="Random Allocation" />
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style7">
                    &nbsp;</td>
                <td>
                    <asp:Button  ID="btn_Generate" runat="server" Text="Generate Hall Plan" 
                          Height="40px" Width="275px" Font-Size="12pt" OnClick="btn_Generate_Click" />
                &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style7">
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
                    <asp:GridView ID="grd_all" runat="server" BackColor="White" 
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

