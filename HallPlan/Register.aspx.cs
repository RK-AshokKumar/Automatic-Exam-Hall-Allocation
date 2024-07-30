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

public partial class _Default : System.Web.UI.Page
{
    sqldbio db = new sqldbio();
   

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["userid"] == null)
        {
           // Label lbl_user = this.Master.FindControl("lbl_userid") as Label;
            //lbl_user.Text = Session["userid"].ToString();
            Response.Redirect("Login.aspx");
        }

        int pid = db.GetLastAdminID();
        pid++;

        lbl_adminid.Text = pid.ToString();

        string sql = "select * from users";
        db.FillGrid(sql, GridView1);
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string pid = lbl_adminid.Text;
        string userid = txt_userid.Text;
        string username = txt_username.Text;


        string pass = txt_pass.Text;
      
        string sql = "insert into users values("+pid+",'"+ userid + "','" + username + "','" + pass + "')";
        db.InsertQuery(sql);
        //db.MessageBox(this,"User Stored...");
        sql = "select * from users"; // where role='admin'";
        db.FillGrid(sql, GridView1);
        
    }


    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        //Response.Write("xxx");
        Label id = GridView1.Rows[e.RowIndex].FindControl("lblid") as Label;
        string sql = "delete  from users where userid='" + id.Text+"'";
        //Response.Write(sql);
        string rv = db.DeleteQuery(sql);
       // Response.Write(rv);
        GridView1.EditIndex = -1;
        sql = "select * from users";
        db.FillGrid(sql, GridView1);
    }
}
