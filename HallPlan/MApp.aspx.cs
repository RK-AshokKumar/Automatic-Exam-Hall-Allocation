using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MAppStatus : System.Web.UI.Page
{
    dbio db = new dbio();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            string sql = "select  Dname from Doctorprofile";
            db.FillDropdownListBox(sql, drp_pid);

        }

       if (Request.QueryString["userid"] != null)
        {
       /*     string userid = Request.QueryString["userid"].ToString();
            string uname = db.GetPatientName(userid);
            txt_userid.Text = userid;
            txt_username.Text = uname; */
        }

    }
    protected void DateChange(object sender, EventArgs e)
    {
       // string date = Calendar1.SelectedDate.ToShortDateString();
       // txt_date.Text = date;
    }
    protected void drp_pid_SelectedIndexChanged(object sender, EventArgs e)
    {
      /*  string doctorname = drp_pid.SelectedValue;
        string timeslot1 = db.GetDoctorTimeSlot1(doctorname);
        string timeslot2 = db.GetDoctorTimeSlot2(doctorname);
        string available_day = db.GetDoctorAvailableDays(doctorname);
        Drp_timeslot.Items.Add(timeslot1);
        Drp_timeslot.Items.Add(timeslot2);
        lbl_availableday.Text = available_day; */

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
    /*    string patient_mailid = txt_userid.Text;
        string pname = txt_username.Text;
        string dname = drp_pid.SelectedValue;
        string dt = txt_date.Text;
        string pid = db.GetPatientID(patient_mailid);
        string timeslot = Drp_timeslot.SelectedValue;
        string sql = "insert into Appointment(Patientid,DoctorName,DateOfAppointment,timeslot,status) values('" + pid + "','" + dname + "','" + dt + "','" + timeslot + "','Pending')";
        string rv = db.InsertQuery(sql);
        if (rv.Equals("Inserted Successfully"))
        {
            lbl_msg.Text = "Your Appointment Request Submitted";
        }
        sql = "select BookingID,DoctorName,Specialization,DateOfAppointment,Timeslot,Status from Appointment_view";

        //db.FillGrid(sql, GridView1);
        */
    }
}