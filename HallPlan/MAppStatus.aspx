<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MAppStatus.aspx.cs" Inherits="MAppStatus" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="bootstrap-4.0/css/bootstrap.min.css" rel="stylesheet" />
    <script src="bootstrap-4.0/js/bootstrap.min.js"></script>
</head>

<body>
    <form id="form1" runat="server">
    <div class="container">
            <div class="jumbotron text-center" style="height:60px">
                <h2>Appointment Status</h2>
             </div>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="true"
                OnPreRender="GridView_PreRender"
                CssClass="table table-striped">
            </asp:GridView>
    </div>
    </form>
     <script src="bootstrap-4.0/js/jquery-3.3.1.min.js"></script>
     <script src="bootstrap-4.0/js/bootstrap.min.js"></script>
</body>
</html>
