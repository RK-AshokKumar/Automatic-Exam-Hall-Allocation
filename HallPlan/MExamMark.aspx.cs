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
       // Response.Write("Load Event");
        try
        {
            if (Request.QueryString["userid"] != null)
            {
                string userid = Request.QueryString["userid"].ToString();
                string username = db.GetStudentNameByMobile(userid);
                lbl_username.Text = username;
                //string sql = "select * from appointment_view where mailid='" + lbl_user.Text + "'";
                //string sql = "select DateOfExam,Test,Subject,Portions from ExamSchedule_view where mobile='" + userid + "'";
                //db.FillGrid(sql, GridView1);
                //Response.Write("userid "+userid);
                if(!Page.IsPostBack)
                {
                    string sql1 = "select subject from Marks_view where mobile='" + userid + "'";
                    db.FillDropdownListBox(sql1, drp_subject);
                }
            }
        }catch(Exception eee)
        {
            Response.Write(eee.Message);
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
    protected void drp_date_SelectedIndexChanged(object sender, EventArgs e)
    {
        string userid = Request.QueryString["userid"].ToString();
        string sub = drp_subject.SelectedValue;
        string sql = "select DateofExam,Test,Subject,Mark from Marks_view where mobile='" + userid + "' and subject='"+sub+"'";
        db.FillGrid(sql, GridView1);

    }
}