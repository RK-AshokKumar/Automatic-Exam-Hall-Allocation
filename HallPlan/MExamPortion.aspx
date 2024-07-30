<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MExamPortion.aspx.cs" Inherits="MAppStatus" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="bootstrap-4.0/css/bootstrap.min.css" rel="stylesheet" />
    <script src="bootstrap-4.0/js/bootstrap.min.js"></script>
</head>

<body>
    <form id="form1" runat="server">
        <p style="height:50px"></p> 
    
    <div class="container" >
            <div class="jumbotron text-center" style="height:30px">
                <h2>Exam&nbsp; Schedule</h2>
             </div>
            <div class="jumbotron text-center" style="height:30px">
                <h4>Hi , <asp:Label ID="lbl_username" runat="server" Text="Label"></asp:Label></h4>
                
             </div>

             <div class="jumbotron text-center" style="height:30px">
                <h4>Select Date :<asp:DropDownList ID="drp_date" runat="server" AutoPostBack="True" OnSelectedIndexChanged="drp_date_SelectedIndexChanged"></asp:DropDownList></h4>
                
             </div>
            <asp:GridView ID="GridView1" runat="server"
                OnPreRender="GridView_PreRender"
                CssClass="table table-striped" CellPadding="4" ForeColor="#333333" GridLines="None">
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
    </div>
    </form>
     <script src="bootstrap-4.0/js/jquery-3.3.1.min.js"></script>
     <script src="bootstrap-4.0/js/bootstrap.min.js"></script>
</body>
</html>
