using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class GetUsersJSON : System.Web.UI.Page
{
    dbio db = new dbio();
    MyJSON json = new MyJSON();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request["userid"] != null)
        {
            string userid = Request["userid"].ToString();
            string pass = Request["pass"].ToString();

           // Response.Write("Userid" + userid);
           // Response.Write("Password" + pass);
          
            if (db.CheckUserByMobileNo(userid, pass))
            {
               sendJSONData("Success");
            }
            else
            {
                sendJSONData("Fail");
            }
        }
        else
        {
            sendJSONData("User id Empty");
        }
    }

    public void sendJSONData(string data)
    {
        Response.Clear();
        Response.ClearHeaders();
        Response.AddHeader("Content-Type", "text/plain");
        Response.Write(data);
        Response.End();
    }
}