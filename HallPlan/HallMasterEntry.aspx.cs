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


            ShowHall();
        }
    }
  
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
       
        string hname = txt_hname.Text;
        string cap= txt_capacity.Text;
        string row = txt_row.Text;
        string col = txt_col.Text;
        string dept = txt_deptcode.Text;

        string sql = "insert into HallMaster values('" + hname + "','" + cap + "','" + row + "','" + col + "','" + dept + "')";
        string rv = db.InsertQuery(sql);
        //Response.Write(rv);
        ShowHall();
        
    }
    

    public void ShowHall()
    {
        string sql = "select * from HallMaster";
        db.FillGrid(sql, GridView1);
    }

    
  /*  protected void btn_edit_Click(object sender, EventArgs e)
    {
        string rollno = txt_regno.Text;
        if (rollno.Equals(""))
            return;
        ArrayList lst=db.GetStudentByRollno(rollno);
        if (lst.Count > 0)
        {
            txt_hname.Text = lst[1].ToString();
            txt_capacity.Text = lst[2].ToString();
            txt_row.Text = lst[3].ToString();
            txt_mailid.Text = lst[4].ToString();
            txt_mobile.Text = lst[5].ToString();

            ShowStudent(rollno);
        }
        
    }*/


    protected void btn_delete_Click(object sender, EventArgs e)
    {
        string hname = txt_hname.Text;


        string sql = "delete from Hallmaster where hallname='" + hname + "'";
        string rv = db.DeleteQuery(sql);
        lblmsg.Text = rv;
        ShowHall();
    }
     
}
