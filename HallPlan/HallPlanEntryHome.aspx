<%@ Page Language="C#" MasterPageFile="~/AdminMasterPage.master" AutoEventWireup="true" CodeFile="HallPlanEntryHome.aspx.cs" Inherits="Default2" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">

        .style1
        {
        	font-size:large;
            text-align: right;
            width: 257px;
        }
       
        .auto-style5 {
            width: 81%;
            height: 317px;
        }
       
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

 <h2 class="pagetitle">Hall Plan Generator</h2>
    <table align="center" class="auto-style5">
            <tr>
                <td class="style1">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style1">
                    <asp:Button  ID="btn_Generate" runat="server" Text="Generate Hall Plan - University Exam" 
                          Height="128px" Width="504px" Font-Size="Large"   Font-Bold="True" OnClick="btn_Generate_Click" />
                </td>
                <td>
                    &nbsp;</td>
                <td>
                    
                    <asp:Button  ID="btn_Generate0" runat="server" Text="Generate Hall Plan - Internal Exam" 
                          Height="128px" Width="485px" Font-Size="Large"   Font-Bold="True" OnClick="btn_Generate0_Click" />
                </td>
            </tr>
            <tr>
                <td class="style1">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
        
   
    
        <table style="width: 70%;" align="center">
            <tr align="center">
                <td>
                    &nbsp;</td>
            </tr>
            </table>


</asp:Content>

