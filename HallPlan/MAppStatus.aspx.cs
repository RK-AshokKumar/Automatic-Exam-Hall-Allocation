using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MAppStatus : System.Web.UI.Page
{
    dbio db = new dbio();
    protected void Page_Load(object sender, EventArgs e)
    {
       if (Request.QueryString["userid"] != null)
        {
            string userid = Request.QueryString["userid"].ToString();

            //string sql = "select * from appointment_view where mailid='" + lbl_user.Text + "'";
            string sql = "select DateOfAppointment as [Date],DoctorName as [Doctor Name],Timeslot,Status from appointment_view where mailid='" + userid + "'";
            db.FillGrid(sql, GridView1);
           // Response.Write("userid "+userid);
        }
        else
        {
            //string sql = "select BookingID as ID,DoctorName as [Doctor Name],DateOfAppointment as AppDate,Timeslot,Status from appointment_view";
            string sql = "select DateOfAppointment as [Date],DoctorName as [Doctor Name],Timeslot,Status from appointment_view";
            db.FillGrid(sql, GridView1);
           // Response.Write("NULL");
        }

    }
    protected void GridView_PreRender(object sender, EventArgs e)
    {
        GridView gv = (GridView)sender;

        if ((gv.ShowHeader == true && gv.Rows.Count > 0))
        {
            //Force GridView to use <thead> instead of <tbody> - 11/03/2013 - MCR.
            gv.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
        if (gv.ShowFooter == true && gv.Rows.Count > 0)
        {
            //Force GridView to use <tfoot> instead of <tbody> - 11/03/2013 - MCR.
            gv.FooterRow.TableSection = TableRowSection.TableFooter;
        }
    }
}