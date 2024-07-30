using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class Default2 : System.Web.UI.Page
{
    sqldbio db = new sqldbio();

  
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            string sql = "select distinct dateofexam from HallPlan";
            db.FillDropdownListBox(sql, drp_date);
        }
    }
  
    
    protected void txt_hname_TextChanged(object sender, EventArgs e)
    {
        string regno = txt_regno.Text;
        string stud_name = db.GetUserName(regno);
        lbl_name.Text = stud_name;
        lblmsg.Text = "";
        if (db.CheckRegisterNumber(regno))
        {
             
            string sql = "select HallName,DateOfExam,Time,Session,SubjectCode,SubjectName,Semester from  HallPlan_View where regno='" + regno + "'";
            db.FillGrid(sql, GridView1);
        }
        else
        {
            lblmsg.Text = "Please Check Register Number";
        }
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        string regno = txt_regno.Text;
        string dt = drp_date.SelectedValue;

        string sql = "select HallName,DateOfExam,Time,Session,SubjectCode,SubjectName,Semester from  HallPlan_View where regno='" + regno + "'";
        db.FillGrid(sql, GridView1);

        
    }
}
