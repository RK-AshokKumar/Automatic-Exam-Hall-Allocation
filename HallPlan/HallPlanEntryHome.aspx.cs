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
            
        }
    }

    protected void btn_Generate_Click(object sender, EventArgs e)
    {
        Response.Redirect("HallPlanEntry.aspx");
    }
    protected void btn_Generate0_Click(object sender, EventArgs e)
    {
        Response.Redirect("HallPlanEntryInternal.aspx");
    }
}
