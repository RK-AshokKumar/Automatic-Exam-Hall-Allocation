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

public partial class GetUsers : System.Web.UI.Page
{
    dbio db = new dbio();
    MyJSON json = new MyJSON();

    protected void Page_Load(object sender, EventArgs e)
    {

        string sql = "select * from student";
        DataTable dt = db.GetDataTable(sql);
        String jsondata = json.DataTableToJSON(dt, "svrstudent");
        Response.Write(jsondata);
        
    }
}
