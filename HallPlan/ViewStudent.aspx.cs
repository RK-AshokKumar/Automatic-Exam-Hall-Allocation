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
using System.IO;
using System.Data.OleDb;

public partial class Default2 : System.Web.UI.Page
{
    sqldbio db = new sqldbio();

    DataTable dt;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            string sql1 = "select * from student order by regno";
            db.FillGrid(sql1, GridView1);

            sql1 = "SELECT DISTINCT DepartmentCode from student";
            db.FillDropdownListBox(sql1, DropDownList1);

            sql1 = "select distinct Semester from student";
            db.FillDropdownListBox(sql1, DropDownList2);
        }

    }


    protected void btn_show_Click(object sender, EventArgs e)
    {
        string deptcode = DropDownList1.SelectedValue;
        string semester = DropDownList2.SelectedValue;

        string sql1 = "select * from student where DepartmentCode='" + deptcode + "' and semester='" + semester + "' order by regno";
        db.FillGrid(sql1, GridView1);
    }
}
