﻿using System;
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
            string sql = "select distinct DateOfExam from HallPlan";
            db.FillDropdownListBox(sql, drp_examdate);

            
          

        }
    }
  
   
   
    protected void drp_examdate_SelectedIndexChanged(object sender, EventArgs e)
    {
        string ex_date = drp_examdate.SelectedValue;

        Session["examdate"] = ex_date;

      //  string sql = "select distinct Hallname from HallPlan where dateofexam='"+ex_date+"'";
      //  db.FillDropdownListBox(sql, drp_hall);
       
        string hall_capacity = db.GetHallCapacity();
       
    }

    protected void btn_hallplan_Click(object sender, EventArgs e)
    {
        string ex_date = drp_examdate.SelectedValue;
        Session["ex_date"] = ex_date;
        string esession;

        if (RadioButton1.Checked)
            esession = "FN";
        else
            esession = "AN";

        string hallname = drp_hall.SelectedValue;

        Session["esession"] = esession;
        Session["hallname"] = hallname;
       
    }
    protected void RadioButton1_CheckedChanged(object sender, EventArgs e)
    {
        string ex_date = drp_examdate.SelectedValue;
        string sql = "select distinct Hallname from HallPlan where dateofexam='" + ex_date + "' and session='FN'";
        db.FillDropdownListBox(sql, drp_hall);
    }
    protected void RadioButton2_CheckedChanged(object sender, EventArgs e)
    {
        string ex_date = drp_examdate.SelectedValue;
        string sql = "select distinct Hallname from HallPlan where dateofexam='" + ex_date + "' and session='AN'";
        db.FillDropdownListBox(sql, drp_hall);
    }
    protected void btn_print_Click(object sender, EventArgs e)
    {
        ClientScript.RegisterStartupScript(this.GetType(), "PrintScript", "window.print()", true);
    }
}
