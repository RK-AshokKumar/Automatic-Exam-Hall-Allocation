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
        string sql1 = "select * from Subjects order by departmentcode,semester,Subjecttype";
        db.FillGrid(sql1, GridView1); 

        if(!Page.IsPostBack)
        {
            string sql3 = "select distinct departmentcode from subjects";
            db.FillDropdownListBox(sql3, drp_scode);
        }
    }
   
    protected void Button1_Click(object sender, EventArgs e)
    {
        //Coneection String by default empty  
        string ConStr = "";
        //Extantion of the file upload control saving into ext because   
        //there are two types of extation .xls and .xlsx of Excel   
        string ext = Path.GetExtension(FileUpload1.FileName).ToLower();
        //getting the path of the file   
        string path = Server.MapPath("~/MyFolder/" + FileUpload1.FileName);
        //saving the file inside the MyFolder of the server  
        FileUpload1.SaveAs(path);
        Label1.Text = FileUpload1.FileName + "\'s Data showing into the GridView";
        //checking that extantion is .xls or .xlsx  
        if (ext.Trim() == ".xls")
        {
            //connection string for that file which extantion is .xls  
            ConStr = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + path + ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=2\"";
        }
        else if (ext.Trim() == ".xlsx")
        {
            //connection string for that file which extantion is .xlsx  
            ConStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + ";Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=2\"";
        }
        //making query  
        string query = "SELECT * FROM [Sheet1$]";
        //Providing connection  
        OleDbConnection conn = new OleDbConnection(ConStr);
        //checking that connection state is closed or not if closed the   
        //open the connection  
        if (conn.State == ConnectionState.Closed)
        {
            conn.Open();
        }
        //create command object  
        OleDbCommand cmd = new OleDbCommand(query, conn);
        // create a data adapter and get the data into dataadapter  
        OleDbDataAdapter da = new OleDbDataAdapter(cmd);
        
        DataSet ds = new DataSet();
        
        //fill the Excel data to data set  
        da.Fill(ds);
        //set data source of the grid view  
        gvExcelFile.DataSource = ds.Tables[0];
        //binding the gridview  
        gvExcelFile.DataBind();
        //close the connection  
        conn.Close();

    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        //Response.Write("Hidden value"+HiddenField1.Value);

        if (HiddenField1.Value == "0")
        {
            //Response.Write(" No " + HiddenField1.Value);
            return;
        }

        string sqldel = "delete   from Subjects";
        db.DeleteQuery(sqldel);

        dt = GetDataTable(gvExcelFile);

        foreach (DataRow row in dt.Rows)
        {
            //int id = db.GetLastTimeTableID();
            //id++;
            string scode = row[0].ToString();
            string sname = row[1].ToString();
            string dept = row[2].ToString();
            string sem = row[3].ToString();
            string stype = row[4].ToString();
            if (scode != "&nbsp;")
            {
                string sql = "insert into Subjects values('" + scode + "','" + sname + "','" + dept + "','" + sem + "','" + stype + "')";
                string rv = db.InsertQuery(sql);
            }
            // Response.Write(sql);
           // Response.Write(rv);
        }
        string sql1 = "select * from subjects order by departmentcode,semester,Subjecttype";
        db.FillGrid(sql1, GridView1); 
    }

    DataTable GetDataTable(GridView dtg)
    {
        DataTable dt = new DataTable();

        // add the columns to the datatable            
        if (dtg.HeaderRow != null)
        {

            for (int i = 0; i < dtg.HeaderRow.Cells.Count; i++)
            {
                dt.Columns.Add(dtg.HeaderRow.Cells[i].Text);
            }
        }

        //  add each of the data rows to the table
        foreach (GridViewRow row in dtg.Rows)
        {
            DataRow dr;
            dr = dt.NewRow();

            for (int i = 0; i < row.Cells.Count; i++)
            {
                dr[i] = row.Cells[i].Text.Replace(" ", " ");
            }
            dt.Rows.Add(dr);
        }
        return dt;
    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        dt = GetDataTable(gvExcelFile);

        foreach (DataRow row in dt.Rows)
        {
            string scode = row[0].ToString();
            string sname = row[1].ToString();
            string dept = row[2].ToString();
            string sem = row[3].ToString();
            string stype = row[4].ToString();
            if (scode != "&nbsp;")
            {
                string sql = "insert into Subjects values('" + scode + "','" + sname + "','" + dept + "','" + sem + "','" + stype + "')";
                string rv = db.InsertQuery(sql);
                // Response.Write(sql);
                // Response.Write(rv);
            }
        }
        string sql1 = "select * from subjects order by departmentcode,semester,Subjecttype";
        db.FillGrid(sql1, GridView1); 
    }
    protected void btn_delete_Click(object sender, EventArgs e)
    {
        string scode = txt_scode.Text;
        string dept = drp_scode.SelectedValue;

        string sql = "delete from subjects where subjectcode='" + scode + "' and departmentcode='"+dept+"'";
        string rv = db.DeleteQuery(sql);
        lbl_msg.Text = rv;
        reload_subjects();
    }

    public void reload_subjects()
    {
        string sql1 = "select * from subjects order by departmentcode,semester,Subjecttype";
        db.FillGrid(sql1, GridView1); 
    }
}
