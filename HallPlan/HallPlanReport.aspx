<%@ Page Language="C#" MasterPageFile="~/AdminMasterPage.master" AutoEventWireup="true" CodeFile="HallPlanReport.aspx.cs" Inherits="Default2" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style>
table, td, th {  
  border: 1px solid #ddd;
  text-align: left;
}

table {
  border-collapse: collapse;
  width: 50%;
}

th, td {
  padding: 15px;
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

 <h2 class="pagetitle">Hall Plan Entry</h2>
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
                    <asp:RadioButton ID="RadioButton1" runat="server" Checked="True" GroupName="rr"   Text="FN" />
&nbsp;<asp:RadioButton ID="RadioButton2" runat="server" GroupName="rr" Text="AN" />
                </td>
                
            </tr>
            <tr>
                <td class="style1" style="text-align: right">
                    &nbsp;</td>
                <td>
                    <asp:Button ID="btn_hallplan" runat="server" OnClick="btn_hallplan_Click" Text="Hall Plan" />
                    <asp:Button ID="btn_hall_print" runat="server" OnClick="btn_print_Click" Text="Print" style="margin-left: 454px" Height="28px" Width="93px" />
                </td>
                
            </tr>
            </table>
         <p>
             <%
                 Dictionary<string, string> My_dict2 = new Dictionary<string, string>() {{"11", "A1"},{"21", "A2"},{"31", "A3"} }; 
                 sqldbio db = new sqldbio();
                 if (Session["ex_date"] == null)
                     return;
                     
                 string ex_date = Session["ex_date"].ToString();
                 string esession = Session["esession"].ToString();
                 
                 
                 ArrayList lst = db.GetHallListForDate(ex_date,esession);
                 Dictionary<string, string> dict = new Dictionary<string, string>{
                                         {"r1c1","A1"},
                                         {"r1c2","B1"},
                                         {"r1c3","C1"},
                                         {"r1c4","D1"},
                                         {"r1c5","E1"},
                                        
                                         {"r2c1","A2"},
                                         {"r2c2","B2"},
                                         {"r2c3","C2"},
                                         {"r2c4","D2"},
                                         {"r2c5","E2"},
                                         
                                         {"r3c1","A3"},
                                         {"r3c2","B3"},
                                         {"r3c3","C3"},
                                         {"r3c4","D3"},
                                         {"r3c5","E3"},
                                         
                                         {"r4c1","A4"},
                                         {"r4c2","B4"},
                                         {"r4c3","C4"},
                                         {"r4c4","D4"},
                                         {"r4c5","E4"},
                                         
                                         {"r5c1","A5"},
                                         {"r5c2","B5"},
                                         {"r5c3","C5"},
                                         {"r5c4","D5"},
                                         {"r5c5","E5"},
                                         };

                
                 for (int i = 0; i < lst.Count; i++)
                 {
                     string hallname = lst[i].ToString();
                     int candi_count = db.GetCandidateInHall(hallname, ex_date,esession);
                     ArrayList sub_dept=db.GetSubjectForDateAndHall(hallname, ex_date);
                     ArrayList candi_lst = db.GetCandidateRegisterNoInHall(hallname, ex_date,esession);
                     int idx = 0;
                     if (sub_dept.Count > 6)
                     {
                         //Response.Write("Hall Name :" + hallname + "  Count : " + candi_lst.Count + " Subject Code :" + sub_dept[0] + "  " + sub_dept[2] + "  Subject Name :" + sub_dept[1] +"  "+ sub_dept[3] +"<br>");
                         Response.Write("Hall Name :" + hallname + "  Count : " + candi_lst.Count +  "<br>");
                         Response.Write( " Subject Code :" + sub_dept[0] + " Subject Name  :" + sub_dept[1] + "<br>");
                         Response.Write( " Subject Code :" + sub_dept[3] + "  Subject Name :" + sub_dept[4] + "<br>");
                         Response.Write( " Subject Code :" + sub_dept[6] + "  Subject Name :" + sub_dept[7] + "<br>");
                     }
                     else if (sub_dept.Count > 3)
                     {
                         //Response.Write("Hall Name :" + hallname + "  Count : " + candi_lst.Count + " Subject Code :" + sub_dept[0] + "  " + sub_dept[2] + "  Subject Name :" + sub_dept[1] +"  "+ sub_dept[3] +"<br>");
                         Response.Write("Hall Name :" + hallname + "  Count : " + candi_lst.Count + "<br>");
                         Response.Write(" Subject Code :" + sub_dept[0] + " Subject Name  :" + sub_dept[1] + "<br>");
                         Response.Write(" Subject Code :" + sub_dept[3] + "  Subject Name :" + sub_dept[4] + "<br>");
                     }                         
                     else
                     {
                         Response.Write("Hall Name :" + hallname + "  Count : " + candi_lst.Count + " Subject Code :" + sub_dept[0] + "  Subject Name :" + sub_dept[1] + "<br>");
                       
                     }
                     try
                     {
                         %>
                         <table border="1" cellpadding="0" cellspacing="0" width="200px" style="border-collapse:collapse;">

                         <tr><td style="padding-left:5px"><strong>Reg.No</strong></td><td><strong>Seat</strong></td><td><strong>Reg.No</strong></td><td><strong>Seat</strong></td><td><strong>Reg.No</strong></td><td><strong>Seat</strong></td><td><strong>Reg.No</strong></td><td><strong>Seat</strong></td><td><strong>Reg.No</strong></td><td><strong>Seat</strong></td></tr>
                         <%
                         for (int row = 1; row <= 5; row++)
                         {
                             %> <tr> <%
                            
                             for (int col = 1; col <= 5; col++)
                             {
                                 string seat = "r" + row + "c" + col;
                                 var foundKey = dict[seat].ToString();
                                  
                                 %><td style="padding-left:5px"><%=candi_lst[idx]%></td>
                                 <td style="padding-left:5px"><%=foundKey%></td>
                                 <%
                                 idx++;
                             }
                             %></tr><%
                         }
                         %></table><%
                         Response.Write("<hr>");

                     }
                     catch (Exception ee)
                     {
                          %></tr><%
                        %></table><%
                       Response.Write("<hr>");
                     }
                     //Response.Write("<br><br>  Halls Allocated" + lst[i] + " Candidates=" + candi_count + " " + candi_lst.Count);
                 }
                 
                  %>
          
         </p>
    
        </asp:Content>

