using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class _Default : System.Web.UI.Page
{
    sqldbio db = new sqldbio();
    //dbio db = new dbio();
   

    protected void Page_Load(object sender, EventArgs e)
    {
       

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string userid = txt_userid.Text;
        string pass = txt_pass.Text;
        if (db.CheckUser(userid, pass))
        {
            Session["userid"] = userid;
            Response.Redirect("AdminHome.aspx"); 
        }
        else
        {
            Label1.Text = "Please Check UserID & Password";
        }
      
    }
   
}
