<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MApp.aspx.cs" Inherits="MAppStatus" %>

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
                <h2>Appointment Booking</h2>
             </div>
            
    
    <div>
        <asp:Label class="bloginput" ID="lbl_msg" runat="server" Width="100%" Font-Bold="True" Font-Size="Large" ForeColor="#FF3300"></asp:Label>
     </div>
     <div>
     User ID <br />
        <asp:TextBox class="bloginput" ID="txt_userid" runat="server" width="100%"></asp:TextBox>
     </div>
     <div>
      User Name<br />
        <asp:TextBox class="bloginput" ID="txt_username" runat="server"  width="100%"></asp:TextBox>
     </div>
     <div>
       Select Doctor<br />
       <asp:DropDownList ID="drp_pid" runat="server" AutoPostBack="True" OnSelectedIndexChanged="drp_pid_SelectedIndexChanged" width="100%">
        </asp:DropDownList>
     </div>    
     
      <div>
        Select Time<br />
        <asp:DropDownList ID="Drp_timeslot" runat="server" width="100%">
        </asp:DropDownList>
      </div>  
      <div>
        <asp:Label ID="lbl_availableday" runat="server" ForeColor="#CC3300"></asp:Label>
      </div>
      <div>
         Date (DD-MM-YYYY)<br />
         <asp:TextBox ID="txt_date" runat="server" width="100%"></asp:TextBox >
     </div> 
        <br /> 
      <div>
          <asp:Button class="bloginput" ID="btn_book" runat="server" onclick="Button1_Click" Text="Book " />
      </div>

    

    </div>
    </form>
     <script src="bootstrap-4.0/js/jquery-3.3.1.min.js"></script>
     <script src="bootstrap-4.0/js/bootstrap.min.js"></script>
</body>
</html>
