<%@ Page Language="C#" MasterPageFile="~/AdminMasterPage.master" AutoEventWireup="true" CodeFile="HallPlanAttendance.aspx.cs" Inherits="Default2" Title="Untitled Page" %>

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
       
        .auto-style6 {
            width: 195px;
        }
         
        .auto-style7 {
            width: 77px;
        }
       
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <h2 class="pagetitle">Attendance</h2>
    <table style="width: 100%;" align="center">
            <tr>
                <td class="style1" style="text-align: right">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                 
            </tr>
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
                    <asp:RadioButton ID="RadioButton1" runat="server" Checked="True" GroupName="rr"   Text="FN" AutoPostBack="True" OnCheckedChanged="RadioButton1_CheckedChanged" />
&nbsp;<asp:RadioButton ID="RadioButton2" runat="server" GroupName="rr" Text="AN" AutoPostBack="True" OnCheckedChanged="RadioButton2_CheckedChanged" />
                </td>
                
            </tr>
            <tr>
                <td class="style1" style="text-align: right">
                    Hall :</td>
                <td>
                    <asp:DropDownList ID="drp_hall" runat="server" AutoPostBack="True" OnSelectedIndexChanged="drp_examdate_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
                
            </tr>
            <tr>
                <td class="style1" style="text-align: right">
                    &nbsp;</td>
                <td>
                    <asp:Button ID="btn_hallplan" runat="server" OnClick="btn_hallplan_Click" Text="Hall Plan" />
                </td>
                
            </tr>
            <tr>
                <td class="style1" style="text-align: right">
                    &nbsp;</td>
                <td>
                    <asp:Button ID="btn_hall_print" runat="server" OnClick="btn_print_Click" Text="Print" style="margin-left: 513px" Height="28px" Width="93px" />
                </td>
                
            </tr>
            </table>
         
             <%
                 sqldbio db = new sqldbio();
                 if (Session["ex_date"] == null)
                     return;
                 if (Session["esession"] == null)
                     return;
                 if (Session["hallname"] == null)
                     return;
                        
                 string ex_date = Session["ex_date"].ToString();
                 string esession = Session["esession"].ToString();
                 string hallname = Session["hallname"].ToString();
                 
                 
                
                int candi_count = db.GetCandidateInHall(hallname, ex_date,esession);
                   
                ArrayList candi_lst = db.GetCandidate_Attendance(hallname, ex_date,esession);
               // int idx = 0;
                int slno=1;
                string time = "";
              %>
                <div><h4>Hall :<%=hallname %></h4> 
                 Date of Exam : <%=ex_date %>   
                <%
                    if (esession == "FN")
                        time = "9.30 AM to 12.30 PM";
                    else
                        time = "1.30 PM to 4.30 PM";
                         %>
                 Session / Time  :<%=esession%>  : <%=time %>   <br />    
                </div>
                 <table border="1" cellpadding="0" cellspacing="0" width="100%" style="border-collapse:collapse;">

                 <tr><td><strong>Sl.No</strong></td><td><strong>Reg.No</strong></td> <td><strong>Name</strong></td><td style="width:30%"><strong>Signature</strong></td></tr>
               <%
                   try
                      {
                          for (int idx = 0; idx < candi_lst.Count; idx=idx+2)
                            {
                             %>  <tr> 
                                 <td style="padding-left:5px"><%=slno++%></td>
                                 <td style="padding-left:5px"> <%=candi_lst[idx]%></td>  
                                 <td><%=candi_lst[idx+1]%> </td>
                                 <td></td>
                                 <%
                                //   idx=idx+2;
                             } %>
                                 </tr>
                      <%
                        }catch (Exception e11) { }  
                      %>
                        </table>
          
        <table style="width: 50%;">
            <tr>
                <td >Total Candidates : <%=slno-1 %></td>
                
            </tr>
            <tr>
                <td >Present :</td>
                 
            </tr>
            <tr>
                <td>Absent :</td>
                 
            </tr>
            <tr>
                <td >Hall Superintendent 
                    Name :</td>
                
            </tr>
            <tr>
                <td>Signature :</td>
                 
            </tr>
            
        </table>
   
        </asp:Content>

