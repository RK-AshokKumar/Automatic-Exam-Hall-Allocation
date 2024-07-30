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


            ShowStudent();
        }
    }
  
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        string regno = txt_regno.Text;
        string name = txt_name.Text;
        string dept= txt_deptcode.Text;
        string yofstudy = txt_year.Text;
        string sem = txt_sem.Text;
        string section = txt_sec.Text;
        string mobile = txt_mobile.Text;

        string sql = "delete  from student where regno='" + regno+"'";
        string rv1 = db.DeleteQuery(sql);
        //Response.Write(rv1);

        sql = "insert into student values('" + regno + "','" + name + "','" + dept + "','" + yofstudy + "','" + sem + "','" + section + "','" + mobile + "')";
        string rv2 = db.UpdateQuery(sql);
       // Response.Write(rv);
        lblmsg.Text = rv2;
        ShowStudent();
        
    }
    

    public void ShowStudent()
    {
        string sql = "select * from student order by regno,departmentcode";
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
        string regno = txt_regno.Text;


        string sql = "delete from student where regno='" + regno + "'";
        string rv = db.DeleteQuery(sql);
        lblmsg.Text = rv;
        ShowStudent();
    }

    protected void btn_edit_Click(object sender, EventArgs e)
    {
        string regno = txt_regno.Text;
        ArrayList lst=db.GetStudentData(regno);
        txt_regno.Text = lst[0].ToString();
        txt_name.Text = lst[1].ToString();
        txt_deptcode.Text = lst[2].ToString();
        txt_year.Text = lst[3].ToString();
        txt_sem.Text = lst[4].ToString();
        txt_sec.Text = lst[5].ToString();
        txt_mobile.Text = lst[6].ToString();


    }
}
