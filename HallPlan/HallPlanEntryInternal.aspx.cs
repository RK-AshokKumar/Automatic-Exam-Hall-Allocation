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
            string sql = "select distinct DateOfExam from student_exam_view";
            db.FillDropdownListBox(sql, drp_examdate);


            //ShowEvent();
        }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {


    }


    public void ShowEvent()
    {
        string sql = "select * from HallPlan";
        db.FillGrid(sql, grd_all);
    }


    protected void drp_examdate_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void btn_Generate_Click(object sender, EventArgs e)
    {
        //check require halls are selected to allocate 
        int required = 0, available = 0;
        required = int.Parse(lbl_totalcandi.Text);
        available = int.Parse(lbl_allocated.Text);
        if (available < required)
        {
            db.MessageBox(this, "insufficient Hall Please Add More Halls");
            return;
        }
        //---

        string ex_date = drp_examdate.SelectedValue;
        //ArrayList lst_hall = db.GetHallDetails();

        //ArrayList lst_hall = db.GetHallList();  // get from database

        ArrayList lst_hall = new ArrayList();  // get from list Box 

        for (int i = 0; i < lst_hall_allocated.Items.Count; i++)
        {
            string hl = lst_hall_allocated.Items[i].ToString();
            lst_hall.Add(hl);
        }

        if (rd_random.Checked)  //random allocation
        {
            Shuffle(lst_hall);  //shuffle the Halls to be allocated 
        }
        string esession;
        if (RadioButton1.Checked)
            esession = "FN";
        else
            esession = "AN";

        //ArrayList lst_candidates = db.GetCandidatesRegisterNumber(ex_date, esession);

        ArrayList lst_candidates = new ArrayList();

        ArrayList lst_cand_eee = db.GetCandidatesRegisterNumber(ex_date, esession, "EEE");
        ArrayList lst_cand_cse = db.GetCandidatesRegisterNumber(ex_date, esession, "CSE");
        ArrayList lst_cand_ece = db.GetCandidatesRegisterNumber(ex_date, esession, "ECE");
        ArrayList lst_cand_me = db.GetCandidatesRegisterNumber(ex_date, esession, "ME");
        ArrayList lst_cand_it = db.GetCandidatesRegisterNumber(ex_date, esession, "IT");
        ArrayList lst_cand_ce = db.GetCandidatesRegisterNumber(ex_date, esession, "CE");

        int tot_count = lst_cand_eee.Count + lst_cand_cse.Count + lst_cand_ece.Count + lst_cand_me.Count + lst_cand_it.Count + lst_cand_ce.Count;

        //  Response.Write("<br>Total Candiates all branch =" + tot_count);

        //   Response.Write("<br>Total Candiates CSE =" + lst_cand_cse.Count);
        //   Response.Write("<br>Total Candiates EEE =" + lst_cand_eee.Count);
        //   Response.Write("<br>Total Candiates ECE =" + lst_cand_ece.Count);

        /* Response.Write("<br>Computer");
         for (int i = 0; i < lst_cand_cse.Count; i=i+2)
         {
             Response.Write("<br>" + lst_cand_cse[i].ToString());
             Response.Write("<br>" + lst_cand_cse[i+1].ToString());
         }
 zzzz
         Response.Write("<br>EEE");
         for (int i = 0; i < lst_cand_eee.Count; i=i+2)
         {
             Response.Write("<br>" + lst_cand_eee[i].ToString());
             Response.Write("<br>" + lst_cand_eee[i+1].ToString());
         }
         */

        /*   Response.Write("<br>ECE");
          for (int i = 0; i < lst_cand_ece.Count; i=i+2)
          {
              Response.Write("<br>" + lst_cand_ece[i].ToString());
              Response.Write("<br>" + lst_cand_ece[i+1].ToString());
          }
          */

        int cidx = 0;

        //ArrayList lst_dept = db.GetNoOfDepartmentsStudents(ex_date, esession);
        string r1 = "";
        string r2 = "";
        string s1 = "";
        string s2 = "";

        bool eee_full = false;
        bool cse_full = false;
        bool ece_full = false;
        bool me_full = false;
        bool it_full = false;

        int eee_idx = 0;
        int cse_idx = 0;
        int ece_idx = 0;
        int me_idx = 0;
        int it_idx = 0;

        for (int i = 0; i < tot_count; i = i + 2)
        {
            try
            {
                if (eee_idx < lst_cand_eee.Count)
                {
                    r1 = lst_cand_eee[eee_idx].ToString();
                    s1 = lst_cand_eee[eee_idx + 1].ToString();
                    lst_candidates.Add(r1);
                    lst_candidates.Add(s1);
                    eee_idx = eee_idx + 2;
                }
                else
                {
                    eee_full = true;
                }
            }
            catch (Exception ee1)
            {
                eee_full = true; // Response.Write(ee1.ToString());
            }
            if (eee_full == true)
            {
                try
                {
                    if (cse_idx < lst_cand_cse.Count)
                    {
                        r2 = lst_cand_cse[cse_idx].ToString();
                        s2 = lst_cand_cse[cse_idx + 1].ToString();
                        lst_candidates.Add(r2);
                        lst_candidates.Add(s2);
                        cse_idx = cse_idx + 2;
                    }
                    else
                    {
                        cse_full = true;
                    }
                }
                catch (Exception ee2)
                {
                    cse_full = true;// Response.Write(ee2.ToString());
                }
            }
            if (eee_full == true && cse_full == true)
            {
                try
                {
                    //if (eee_full == true)
                    //{
                    if (ece_idx < lst_cand_ece.Count)
                    {
                        r2 = lst_cand_ece[ece_idx].ToString();
                        s2 = lst_cand_ece[ece_idx + 1].ToString();
                        lst_candidates.Add(r2);
                        lst_candidates.Add(s2);
                        ece_idx = ece_idx + 2;
                    }
                    else
                    {
                        ece_full = true;
                    }
                }
                //}
                catch (Exception ee2)
                {
                    ece_full = true;// Response.Write(ee2.ToString());
                }
            }
            if ((cse_full == true && eee_full == true && ece_full == true))
            { 
            try
            {
                //if (cse_full == true)
                //{
                    if (me_idx < lst_cand_me.Count)
                    {
                        r2 = lst_cand_me[me_idx].ToString();
                        s2 = lst_cand_me[me_idx + 1].ToString();
                        lst_candidates.Add(r2);
                        lst_candidates.Add(s2);
                        me_idx = me_idx + 2;
                    }
                    else
                    {
                        me_full = true;
                    }
                }
            //}
            catch (Exception ee2)
            {
                me_full = true;// Response.Write(ee2.ToString());
            }
            }
            
            if ((eee_full == true && cse_full == true && ece_full == true && me_full == true))
            {
            try
            {
                //if (ece_full == true)
                //{
                    if (it_idx < lst_cand_it.Count)
                    {
                        r2 = lst_cand_it[it_idx].ToString();
                        s2 = lst_cand_it[it_idx + 1].ToString();
                        lst_candidates.Add(r2);
                        lst_candidates.Add(s2);
                        it_idx = it_idx + 2;
                    }
                    else
                    {
                        it_full = true;
                    }
                }
            //}
            catch (Exception ee2)
            {
                it_full = true;// Response.Write(ee2.ToString());
            }
                }


            //Response.Write("<br> EEE "+eee_idx + " CSE " + cse_idx + " ECE  " + ece_idx);
        }

        /* Response.Write("<br>Total Candiates  after Loop=" + lst_candidates.Count);
         for (int i = 0; i < tot_count; i++)
         {
             Response.Write("After Loop <br>"+lst_candidates[i].ToString());
         }

       */

        //remove old records for the date

        string sql1 = "delete from HallPlan";
        string rv1 = db.InsertQuery(sql1);

        for (int i = 0; i < lst_hall.Count; i++)
        {
            string hallname = lst_hall[i].ToString();
            int capacity = db.GetHallCapacity(hallname);

            //  Response.Write("<br>   Hall=" + hallname);
            //   Response.Write("<br>   Cap=" + capacity);

            for (int j = 0; j < capacity; j++)
            {
                if (cidx < lst_candidates.Count)
                {
                    //      Response.Write("<br>   Hall=" + hallname);
                    //       Response.Write("<br>   Regno=" + lst_candidates[cidx]);
                    string regno = lst_candidates[cidx].ToString();
                    string scode = lst_candidates[cidx + 1].ToString();
                    //        Response.Write("<br>   index =" + cidx);

                    int id = db.GetHallPlanID();
                    id++;

                    string sql = "insert into Hallplan values(" + id + ",'" + hallname + "','" + regno + "','" + scode + "','" + ex_date + "','" + esession + "')";
                    string rv = db.InsertQuery(sql);
                    //       Response.Write(rv);
                }
                else
                {
                    lbl_msg.Text = "Seat Allocated for " + lst_candidates.Count / 2 + " Candidates ";
                    lblmsg.Text = "Seat Allocated for " + lst_candidates.Count / 2 + " Candidates ";
                    return;
                }
                cidx = cidx + 2;
            }

        }

        lbl_msg.Text = "Seat Allocated for " + lst_candidates.Count / 2 + " Candidates ";
        lblmsg.Text = "Seat Allocated for " + lst_candidates.Count / 2 + " Candidates ";
    }
    protected void RadioButton1_CheckedChanged(object sender, EventArgs e)
    {

    }
    protected void btn_load_Click(object sender, EventArgs e)
    {
        string ex_date = drp_examdate.SelectedValue;
        string esession;
        if (RadioButton1.Checked)
            esession = "FN";
        else
            esession = "AN";

        string sql = "select * from timetable_view where dateofexam='" + ex_date + "' and Session='" + esession + "'";
        db.FillGrid(sql, grd_timetable);

        //string count = db.GetTotalCandidates(ex_date);
        string count = db.GetTotalCandidatesWithSession(ex_date, esession);
        lbl_totalcandi.Text = count;

        string hall_capacity = db.GetHallCapacity();
        lbl_capacity.Text = hall_capacity;

        LoadavailableHalls();  // load available halls
    }

    public void LoadavailableHalls()
    {
        string sql = "select Hallname from HallMaster";
        db.FillListBox(sql, lst_hall_available);

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        ArrayList lst = new ArrayList();
        lst.Add(10);
        lst.Add(20);
        lst.Add(30);
        lst.Add(40);
        lst.Add(50);
        lst.Add(60);
        Shuffle(lst);

        foreach (var item in lst)
        {
            Response.Write(item);
        }

    }

    public void Shuffle(ArrayList list)
    {
        Random rng = new Random();
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            object value = list[k];
            list[k] = list[n];
            list[n] = value;
        }

    }
    protected void lst_hall_available_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void btn_addHall_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < lst_hall_available.Items.Count; i++)
        {
            if (lst_hall_available.Items[i].Selected == true)
            {
                string hall = lst_hall_available.Items[i].Text;
                lst_hall_allocated.Items.Add(hall);
                // lst_hall_available.Items.Remove(hall);

                int allocated = lst_hall_allocated.Items.Count * 25;
                lbl_allocated.Text = allocated.ToString();
            }
        }

        for (int i = 0; i < lst_hall_allocated.Items.Count; i++)
        {
            string hall = lst_hall_allocated.Items[i].Text;
            lst_hall_available.Items.Remove(hall);
        }


    }



    protected void btn_removeHall_Click(object sender, EventArgs e)
    {
        string hall = lst_hall_allocated.SelectedValue;
        lst_hall_available.Items.Add(hall);
        lst_hall_allocated.Items.Remove(hall);
        int allocated = lst_hall_allocated.Items.Count * 25;
        lbl_allocated.Text = allocated.ToString();
    }
}
