
using System.IO;
using System.Data;
using System.Data.SqlClient;

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
using System.Globalization;
using System.Text;

	public class sqldbio
	{
		public SqlConnection conn;
		SqlCommand ocmd;
		SqlDataReader odr;
		SqlDataAdapter oda;

    
        ArrayList members = new ArrayList();
        public sqldbio()
        {
            CultureInfo culture = (CultureInfo)CultureInfo.CurrentCulture.Clone();
            culture.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy";
            culture.DateTimeFormat.LongTimePattern = "";
            System.Threading.Thread.CurrentThread.CurrentCulture = culture;

            //For SQLConnection
             //conn=new SqlConnection("Data Source=SIT-CIICP-PC\\SQLEXPRESS;Initial Catalog=Shopping;Integrated Security=True;Pooling=False");
            string apppath = System.Web.HttpContext.Current.Request.PhysicalApplicationPath;
            //conn = new SqlConnection("Data Source=.\\SQLEXPRESS;AttachDbFilename="+apppath+"App_Data\\Database.mdf;Integrated Security=True;User Instance=True");

            conn = new SqlConnection("Data Source=(LocalDB)\\v11.0;AttachDbFilename=" + apppath + "App_Data\\Database.mdf;Integrated Security=True");
        }

        public string GetSecurityCode()
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            for (int i = 0; i <4 ; i++)
            {

                //26 letters in the alfabet, ascii + 65 for the capital letters
                builder.Append(Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65))));

            }
            string s = builder.ToString();
            return s;
        }

        public void MessageBox(System.Web.UI.Page page, string Msg)
        {
            string MsgScript = "<script language='javascript'>alert('" + Msg + "')</script>";

            if (!(page.IsStartupScriptRegistered("MessageScript")))
                page.RegisterStartupScript("MessageScript", MsgScript);
        }

        public string GetCurrentDate()
        {
            string day = DateTime.Now.ToShortDateString();

            return day;
        }

        public string GetCurrentDateAndTime()
        {
            string day = DateTime.Now.ToString("dd MMM yyyy");
           
            day = day + "  " + DateTime.Now.ToShortTimeString();

            return day;
        }

        public string GetCurrentDateAndTimeForMail()
        {
            string day = DateTime.Now.ToString("dd/MM/yyyy");

            day = day + "  " + DateTime.Now.ToShortTimeString();

            return day;
        }

        public string InsertQuery(string sql)
        {
            string str;
            try
            {
                ocmd = new SqlCommand(sql,conn);
                conn.Open();
                ocmd.ExecuteNonQuery();
                conn.Close();
                str = "Inserted Successfully";
                return str;
            }
            catch (Exception ex)
            {
                conn.Close();
                return ex.Message;
            }
        }

        public string DeleteQuery(string sql)
        {
             string str;
             try
             {
                 ocmd = new SqlCommand(sql, conn);
                 conn.Open();
                 ocmd.ExecuteNonQuery();
                 conn.Close();
                 str = "Deleted Successfully";
                 return str;
             }
             catch (Exception ex)
             {
                 conn.Close();
                 return ex.Message;
             }
        }

        public string UpdateQuery(string sql)
        {
           string str;
           try
            {
            ocmd = new SqlCommand(sql, conn);
            conn.Open();
            ocmd.ExecuteNonQuery();
            conn.Close();
            str = "Updated Successfully";
            return str;
            }
            catch (Exception ex)
             {
                 conn.Close();
                 return ex.Message;
             }
        }

        public void FillDropdownListBox(string sq, DropDownList lst)
        {
            string val = "";
            oda = new SqlDataAdapter(sq, conn);
            ocmd = new SqlCommand(sq, conn);
            conn.Open();

            odr = ocmd.ExecuteReader();
            lst.Items.Clear();
            lst.Items.Add("--Select--");
            while (odr.Read())
            {
                val = odr.GetValue(0).ToString();
                val = val.Trim();
                lst.Items.Add(val);
            }

            conn.Close();

        }

        public void FillListBox(string sq, ListBox lst)
        {
            string val = "";
            oda = new SqlDataAdapter(sq, conn);
            ocmd = new SqlCommand(sq, conn);
            conn.Open();

            odr = ocmd.ExecuteReader();
            lst.Items.Clear();
           // lst.Items.Add("--Select--");
            while (odr.Read())
            {
                val = odr.GetValue(0).ToString();
                val = val.Trim();
                lst.Items.Add(val);
            }

            conn.Close();

        }

        public void FillGrid(string sql, GridView dg)
        {
            DataSet ds = new DataSet();
            ocmd = new SqlCommand(sql, conn);
            oda = new SqlDataAdapter(ocmd);
            ds = new DataSet();
            oda.Fill(ds, "Cust");
            dg.DataSource = ds.Tables["Cust"];
            dg.DataBind();
        }
        public void FillRepeater(string sq, Repeater NewsListRepeater)
        {

            string val = "";
            oda = new SqlDataAdapter(sq, conn);
            ocmd = new SqlCommand(sq, conn);
            conn.Open();

            odr = ocmd.ExecuteReader();

            NewsListRepeater.DataSource = odr;
            NewsListRepeater.DataBind();

            conn.Close();


        }
 //----------------------------------hallplan

        public ArrayList GetStudentData(string regno)
        {
            ArrayList val = new ArrayList();

            string sql = "select *  from student where regno='"+regno+"'";
            ocmd = new SqlCommand(sql, conn);
            conn.Open();

            odr = ocmd.ExecuteReader();

            while (odr.Read())
            {
                val.Add(odr.GetValue(0).ToString());
                val.Add(odr.GetValue(1).ToString());
                val.Add(odr.GetValue(2).ToString());
                val.Add(odr.GetValue(3).ToString());
                val.Add(odr.GetValue(4).ToString());
                val.Add(odr.GetValue(5).ToString());
                val.Add(odr.GetValue(6).ToString());

            }
            conn.Close();
            return val;
        }

        public bool CheckRegisterNumber(string regno)
        {
            bool flag;
            string sql = null;

            sql = "select * from HallPlan where regno='" + regno + "'";

            ocmd = new SqlCommand(sql, conn);
            conn.Open();

            odr = ocmd.ExecuteReader();
            odr.Read();

            if (odr.HasRows)
                flag = true;
            else
                flag = false;
            conn.Close();

            return flag;

        }
        public int GetLastTimeTableID()
        {
            //ArrayList val = new ArrayList();
            int id = 0;
            string sql = "select id from TimeTable order by id";
            oda = new SqlDataAdapter(sql, conn);
            ocmd = new SqlCommand(sql, conn);
            conn.Open();

            odr = ocmd.ExecuteReader();

            while (odr.Read())
            {
                //id = odr.GetValue(0).ToString();
                id = odr.GetInt32(0);
            }
            // id = odr.GetInt32(0);
            conn.Close();
            return id;
        }

        public int GetHallPlanID()
        {
            //ArrayList val = new ArrayList();
            int id = 0;
            string sql = "select id from Hallplan order by id";
            oda = new SqlDataAdapter(sql, conn);
            ocmd = new SqlCommand(sql, conn);
            conn.Open();

            odr = ocmd.ExecuteReader();

            while (odr.Read())
            {
                //id = odr.GetValue(0).ToString();
                id = odr.GetInt32(0);
            }
            // id = odr.GetInt32(0);
            conn.Close();
            return id;
        }

        public string GetTotalCandidates(string ex_date)
        {
            string ps = "Not Found";

            string sql = "select count(*) from Student_Exam_View where DateOfExam='" + ex_date + "'";

            ocmd = new SqlCommand(sql, conn);
            conn.Open();

            odr = ocmd.ExecuteReader();
            odr.Read();

            if (odr.HasRows)
            {
                string ps1 = odr.GetValue(0).ToString();
                ps = ps1;
            }
            conn.Close();
            return ps;

        }

        public string GetTotalCandidatesWithSession(string ex_date,string esession)
        {
            string ps = "Not Found";

            string sql = "select count(*) from Student_Exam_View where DateOfExam='" + ex_date + "' and session='"+esession+"'";

            ocmd = new SqlCommand(sql, conn);
            conn.Open();

            odr = ocmd.ExecuteReader();
            odr.Read();

            if (odr.HasRows)
            {
                string ps1 = odr.GetValue(0).ToString();
                ps = ps1;
            }
            conn.Close();
            return ps;

        }

        public string GetTotalHalls()
        {
            string ps = "Not Found";

            string sql = "select count(*) from HallMaster"; // where DateOfExam='" + ex_date + "'";

            ocmd = new SqlCommand(sql, conn);
            conn.Open();

            odr = ocmd.ExecuteReader();
            odr.Read();

            if (odr.HasRows)
            {
                string ps1 = odr.GetValue(0).ToString();
                ps = ps1;
            }
            conn.Close();
            return ps;

        }
        public string GetHallCapacity()
        {
            string ps = "Not Found";

            string sql = "select sum(capacity) from HallMaster";

            ocmd = new SqlCommand(sql, conn);
            conn.Open();

            odr = ocmd.ExecuteReader();
            odr.Read();

            if (odr.HasRows)
            {
                string ps1 = odr.GetValue(0).ToString();
                ps = ps1;
            }
            conn.Close();
            return ps;

        }

        
        public int GetHallCapacity(string hallname)
        {
            int rv = 0;

            string sql = "select capacity from HallMaster where hallname='"+hallname+"'";

            ocmd = new SqlCommand(sql, conn);
            conn.Open();

            odr = ocmd.ExecuteReader();
            odr.Read();

            if (odr.HasRows)
            {
                string ps1 = odr.GetValue(0).ToString();
                rv = int.Parse(ps1);
            }
            conn.Close();
            return rv;

        }

        public ArrayList GetHallListForDate(string examdate,string esession)
        {
            ArrayList val = new ArrayList();

            string sql = "select distinct HallName  from HallPlan where DateOfExam='"+examdate+"' and session='"+esession+"'";
            ocmd = new SqlCommand(sql, conn);
            conn.Open();

            odr = ocmd.ExecuteReader();

            while (odr.Read())
            {
                val.Add(odr.GetValue(0).ToString());

            }
            conn.Close();
            return val;
        }

        public ArrayList GetSubjectForDateAndHall(string hallname,string examdate)
        {
            ArrayList val = new ArrayList();

            string sql = "select distinct SubjectCode,SubjectName,DepartmentCode  from HallPlan_View where DateOfExam='" + examdate + "' and HallName='"+hallname+"'";
            ocmd = new SqlCommand(sql, conn);
            conn.Open();

            odr = ocmd.ExecuteReader();

            while (odr.Read())
            {
                val.Add(odr.GetValue(0).ToString());
                val.Add(odr.GetValue(1).ToString());
                val.Add(odr.GetValue(2).ToString());

            }
            conn.Close();
            return val;
        }

        public ArrayList GetNoOfDepartmentsStudents(string examdate, string esession)
        {
            ArrayList val = new ArrayList();

            string sql = "select distinct DepartmentCode  from Student_Exam_View where DateOfExam='" + examdate + "' and session='" + esession + "'";
            ocmd = new SqlCommand(sql, conn);
            conn.Open();

            odr = ocmd.ExecuteReader();

            while (odr.Read())
            {
                val.Add(odr.GetValue(0).ToString());
            }
            conn.Close();
            return val;
        }

     /*   public int GetCandidateInHall(string hallname,string examdate)
        {
            int rv = 0;

            string sql = "select count(*)  from HallPlan where DateOfExam='" + examdate + "' and hallname='"+hallname+"'";
            ocmd = new SqlCommand(sql, conn);
            conn.Open();

            odr = ocmd.ExecuteReader();

            while (odr.Read())
            {
                string pp=odr.GetValue(0).ToString();
                rv = int.Parse(pp);
            }
            conn.Close();
            return rv;
        }
     */

        public int GetCandidateInHall(string hallname, string examdate,string session)
        {
            int rv = 0;

            string sql = "select count(*)  from HallPlan_view where DateOfExam='" + examdate + "' and hallname='" + hallname + "' and session='"+session+"'";
            ocmd = new SqlCommand(sql, conn);
            conn.Open();

            odr = ocmd.ExecuteReader();

            while (odr.Read())
            {
                string pp = odr.GetValue(0).ToString();
                rv = int.Parse(pp);
            }
            conn.Close();
            return rv;
        }

        
        public ArrayList GetCandidateRegisterNoInHall(string hallname, string examdate,string esession)
        {
            ArrayList val = new ArrayList();

            string sql = "select regno  from HallPlan_view where DateOfExam='" + examdate + "' and hallname='" + hallname + "' and session='"+esession+"' order by id";
            ocmd = new SqlCommand(sql, conn);
            conn.Open();

            odr = ocmd.ExecuteReader();

            while (odr.Read())
            {
                val.Add(odr.GetValue(0).ToString());
               
            }
            conn.Close();
            return val;
        }

        public ArrayList GetCandidate_Attendance(string hallname, string examdate, string esession)
        {
            ArrayList val = new ArrayList();

            string sql = "select regno,studentname  from HallPlan_view where DateOfExam='" + examdate + "' and hallname='" + hallname + "' and session='" + esession + "' order by regno";
            ocmd = new SqlCommand(sql, conn);
            conn.Open();

            odr = ocmd.ExecuteReader();

            while (odr.Read())
            {
                val.Add(odr.GetValue(0).ToString());
                val.Add(odr.GetValue(1).ToString());

            }
            conn.Close();
            return val;
        }
      
        public ArrayList GetHallList()
        {
            ArrayList val = new ArrayList();

            string sql = "select HallName  from HallMaster"; // order by HallName";
            ocmd = new SqlCommand(sql, conn);
            conn.Open();

            odr = ocmd.ExecuteReader();

            while (odr.Read())
            {
                val.Add(odr.GetValue(0).ToString());
                
            }
            conn.Close();
            return val;
        }
        public ArrayList GetHallDetails()
        {
            ArrayList val = new ArrayList();

            string sql = "select *  from HallMaster order by HallName";
            ocmd = new SqlCommand(sql, conn);
            conn.Open();

            odr = ocmd.ExecuteReader();

            while (odr.Read())
            {
                val.Add(odr.GetValue(0).ToString());
                val.Add(odr.GetValue(1).ToString());
                val.Add(odr.GetValue(2).ToString());
                val.Add(odr.GetValue(3).ToString());
            }
            conn.Close();
            return val;
        }

        public ArrayList GetCandidatesRegisterNumber(string dateofexam,string esession)
        {
            ArrayList val = new ArrayList();

            string sql = "select regno,subjectcode  from student_exam_view where dateofexam='"+dateofexam+"' and session='"+esession+"' order by regno,departmentcode";
            ocmd = new SqlCommand(sql, conn);
            conn.Open();
            odr = ocmd.ExecuteReader();
            while (odr.Read())
            {
                val.Add(odr.GetValue(0).ToString());
                val.Add(odr.GetValue(1).ToString());
            }
            conn.Close();
            return val;
        }

        public ArrayList GetCandidatesRegisterNumber(string dateofexam, string esession,string deptcode)
        {
            ArrayList val = new ArrayList();

            string sql = "select regno,subjectcode  from student_exam_view where dateofexam='" + dateofexam + "' and session='" + esession + "' and departmentcode='" + deptcode + "' order by regno,departmentcode";
            ocmd = new SqlCommand(sql, conn);
            conn.Open();
            odr = ocmd.ExecuteReader();
            while (odr.Read())
            {
                val.Add(odr.GetValue(0).ToString());
                val.Add(odr.GetValue(1).ToString());
            }
            conn.Close();
            return val;
        }
//----------------------------- for user rating 

        public int GetLastAdminID()
        {
            //ArrayList val = new ArrayList();
            int id = 0;
            string sql = "select adminid from users order by adminid";
            oda = new SqlDataAdapter(sql, conn);
            ocmd = new SqlCommand(sql, conn);
            conn.Open();

            odr = ocmd.ExecuteReader();

            while (odr.Read())
            {
                //id = odr.GetValue(0).ToString();
                id = odr.GetInt32(0);
            }
            // id = odr.GetInt32(0);
            conn.Close();
            return id;
        }
        public string GetUserCategory(string userid)
        {
            string ps = "Not Found";

            string sql = "select category from users where userid='" + userid + "'";

            ocmd = new SqlCommand(sql, conn);
            conn.Open();

            odr = ocmd.ExecuteReader();
            odr.Read();

            if (odr.HasRows)
                ps = odr.GetValue(0).ToString();

            conn.Close();
            return ps;

        }

        public string GetOwnerMobileByTitle(string userid)
        {
            string ps = "Not Found";

            string sql = "select mobile from users where userid='" + userid + "'";

            ocmd = new SqlCommand(sql, conn);
            conn.Open();

            odr = ocmd.ExecuteReader();
            odr.Read();

            if (odr.HasRows)
                ps = odr.GetValue(0).ToString();

            conn.Close();
            return ps;

        }

        public string GetFileIDByTitle(string title)
        {
            string ps = "Not Found";

            string sql = "select FileUploaded from UploadLog where title='" + title + "'";

            ocmd = new SqlCommand(sql, conn);
            conn.Open();

            odr = ocmd.ExecuteReader();
            odr.Read();

            if (odr.HasRows)
                ps = odr.GetValue(0).ToString();

            conn.Close();
            return ps;

        }

        public string GetFile_FullDocByTitle(string title)
        {
            string ps = "Not Found";

            string sql = "select FileFullDoc from UploadLog where title='" + title + "'";

            ocmd = new SqlCommand(sql, conn);
            conn.Open();

            odr = ocmd.ExecuteReader();
            odr.Read();

            if (odr.HasRows)
                ps = odr.GetValue(0).ToString();

            conn.Close();
            return ps;

        }

        public string GetKeyByTitle(string title)
        {
            string ps = "Not Found";

            string sql = "select EncKey1 from UploadLog where title='" + title + "'";

            ocmd = new SqlCommand(sql, conn);
            conn.Open();

            odr = ocmd.ExecuteReader();
            odr.Read();

            if (odr.HasRows)
                ps = odr.GetValue(0).ToString();

            conn.Close();
            return ps;

        }

        public string GetFileOwner(string filename)
        {
            string ps = "Not Found";

            string sql = "select uploadedBy from UploadLog where fileuploaded='" + filename + "'";

            ocmd = new SqlCommand(sql, conn);
            conn.Open();

            odr = ocmd.ExecuteReader();
            odr.Read();

            if (odr.HasRows)
            {
               ps = odr.GetValue(0).ToString();
            
            }
            conn.Close();
            return ps;

        }
        public string GetFileOwnerByTitle(string title)
        {
            string ps = "Not Found";

            string sql = "select uploadedBy from UploadLog where title='" + title + "'";

            ocmd = new SqlCommand(sql, conn);
            conn.Open();

            odr = ocmd.ExecuteReader();
            odr.Read();

            if (odr.HasRows)
            {
                ps = odr.GetValue(0).ToString();

            }
            conn.Close();
            return ps;

        }
        public string GetAbstractByTitle(string title)
        {
            string ps = "Not Found";

            string sql = "select Abstract from UploadLog where title='" + title + "'";

            ocmd = new SqlCommand(sql, conn);
            conn.Open();

            odr = ocmd.ExecuteReader();
            odr.Read();

            if (odr.HasRows)
            {
                ps = odr.GetValue(0).ToString();

            }
            conn.Close();
            return ps;

        }

        public string GetKey(string title)
        {
            string ps = "Not Found";

            string sql = "select EncKey1 from UploadLog where title='" + title + "'";

            ocmd = new SqlCommand(sql, conn);
            conn.Open();

            odr = ocmd.ExecuteReader();
            odr.Read();

            if (odr.HasRows)
            {
               string ps1 = odr.GetValue(0).ToString();
               ps = ps1;
            }
            conn.Close();
            return ps;

        }

        public int GetLastUploadID()
        {
            //ArrayList val = new ArrayList();
            int id = 0;
            string sql = "select UploadID from UploadLog order by UploadID";
            oda = new SqlDataAdapter(sql, conn);
            ocmd = new SqlCommand(sql, conn);
            conn.Open();

            odr = ocmd.ExecuteReader();

            while (odr.Read())
            {
                //id = odr.GetValue(0).ToString();
                id = odr.GetInt32(0);
            }
           // id = odr.GetInt32(0);
            conn.Close();
            return id;
        }
        public int GetLastUserID()
        {
            //ArrayList val = new ArrayList();
            int id = 0;
            string sql = "select id from users order by id";
            oda = new SqlDataAdapter(sql, conn);
            ocmd = new SqlCommand(sql, conn);
            conn.Open();

            odr = ocmd.ExecuteReader();

            while (odr.Read())
            {
                //id = odr.GetValue(0).ToString();
                id = odr.GetInt32(0);
            }
            // id = odr.GetInt32(0);
            conn.Close();
            return id;
        }
        public int GetLastKeyRequestID()
        {
            //ArrayList val = new ArrayList();
            int id = 0;
            string sql = "select RequestID from KeyRequest order by RequestID";
            oda = new SqlDataAdapter(sql, conn);
            ocmd = new SqlCommand(sql, conn);
            conn.Open();

            odr = ocmd.ExecuteReader();

            while (odr.Read())
            {
                //id = odr.GetValue(0).ToString();
                id = odr.GetInt32(0);
            }
            // id = odr.GetInt32(0);
            conn.Close();
            return id;
        }

        public int GetLastPostIDOfUser(string userid)
        {
            //ArrayList val = new ArrayList();
            int id = 0;
            string sql = "select postid from post where postedby='"+userid+"' order by postid";
            oda = new SqlDataAdapter(sql, conn);
            ocmd = new SqlCommand(sql, conn);
            conn.Open();

            odr = ocmd.ExecuteReader();

            while (odr.Read())
            {
                //id = odr.GetValue(0).ToString();
                id = odr.GetInt32(0);
            }
            // id = odr.GetInt32(0);
            conn.Close();
            return id;
        }

        public int GetLastCategoryID()
        {
            //ArrayList val = new ArrayList();
            int id = 0;
            string sql = "select categoryid from category order by categoryid";
            oda = new SqlDataAdapter(sql, conn);
            ocmd = new SqlCommand(sql, conn);
            conn.Open();

            odr = ocmd.ExecuteReader();
           
            while (odr.Read())
             {
                    //id = odr.GetValue(0).ToString();
                id = odr.GetInt32(0);
             }
            // id = odr.GetInt32(0);
            conn.Close();
            return id;
        }
        public int GetLastProductID()
        {
            //ArrayList val = new ArrayList();
            int id = 0;
            string sql = "select productid from product order by productid";
            oda = new SqlDataAdapter(sql, conn);
            ocmd = new SqlCommand(sql, conn);
            conn.Open();

            odr = ocmd.ExecuteReader();

            while (odr.Read())
            {
                //id = odr.GetValue(0).ToString();
                id = odr.GetInt32(0);
            }
            // id = odr.GetInt32(0);
            conn.Close();
            return id;
        }
        public ArrayList GetTopLikesProduct()
        {
            ArrayList val = new ArrayList();
            int c = 0;
            string sql = "select LikeCount,ProductID,ProductName,Image from ProductLike_view order by likecount desc";
            oda = new SqlDataAdapter(sql, conn);
            ocmd = new SqlCommand(sql, conn);
            conn.Open();

            odr = ocmd.ExecuteReader();
            try
            {
                odr.Read();
                val.Add(odr.GetValue(0).ToString());
                val.Add(odr.GetValue(1).ToString());
                val.Add(odr.GetValue(2).ToString());
                val.Add(odr.GetValue(3).ToString());
            }
            catch (Exception e) { }
            
            // id = odr.GetInt32(0);
            conn.Close();
            return val;
        }

        public int GetTotalLikes(int productid)
        {
            //ArrayList val = new ArrayList();
            int c = 0;
            string sql = "select ratingid from Rating where productid="+productid;
            oda = new SqlDataAdapter(sql, conn);
            ocmd = new SqlCommand(sql, conn);
            conn.Open();

            odr = ocmd.ExecuteReader();

            while (odr.Read())
            {
                //id = odr.GetValue(0).ToString();
                c++; 
            }
            // id = odr.GetInt32(0);
            conn.Close();
            return c;
        }

        public int GetLastRatingID()
        {
            //ArrayList val = new ArrayList();
            int id = 0;
            string sql = "select ratingid from Rating order by ratingid";
            oda = new SqlDataAdapter(sql, conn);
            ocmd = new SqlCommand(sql, conn);
            conn.Open();

            odr = ocmd.ExecuteReader();

            while (odr.Read())
            {
                //id = odr.GetValue(0).ToString();
                id = odr.GetInt32(0);
            }
            // id = odr.GetInt32(0);
            conn.Close();
            return id;
        }

        public int GetLastRecommendID()
        {
            //ArrayList val = new ArrayList();
            int id = 0;
            string sql = "select recommendid from recommendation order by recommendid";
            oda = new SqlDataAdapter(sql, conn);
            ocmd = new SqlCommand(sql, conn);
            conn.Open();

            odr = ocmd.ExecuteReader();

            while (odr.Read())
            {
                //id = odr.GetValue(0).ToString();
                id = odr.GetInt32(0);
            }
            // id = odr.GetInt32(0);
            conn.Close();
            return id;
        }

        public ArrayList GetRecommendedProduct(string userid)
        {
            ArrayList val = new ArrayList();

            string sql = "select UserName,ProductName,Manufacture,Description,UnitPrice,Comment,Image  from Recommendation_View where recommendto='"+userid+"' order by RecommendID desc";
            ocmd = new SqlCommand(sql, conn);
            conn.Open();

            odr = ocmd.ExecuteReader();

            while (odr.Read())
            {
                val.Add(odr.GetValue(0).ToString());
                val.Add(odr.GetValue(1).ToString());
                val.Add(odr.GetValue(2).ToString());
                val.Add(odr.GetValue(3).ToString());
                val.Add(odr.GetValue(4).ToString());
                val.Add(odr.GetValue(5).ToString());
                val.Add(odr.GetValue(6).ToString());
            }
            conn.Close();
            return val;
        }

        public ArrayList GetAllProducts()
        {
            ArrayList val = new ArrayList();

            string sql = "select *  from product order by productid desc";
            ocmd = new SqlCommand(sql, conn);
            conn.Open();

            odr = ocmd.ExecuteReader();

            while (odr.Read())
            {
                val.Add(odr.GetValue(0).ToString());
                val.Add(odr.GetValue(1).ToString());
                val.Add(odr.GetValue(2).ToString());
                val.Add(odr.GetValue(3).ToString());
                val.Add(odr.GetValue(4).ToString());
                val.Add(odr.GetValue(5).ToString());
                val.Add(odr.GetValue(6).ToString());
            }
            conn.Close();
            return val;
        }

        public ArrayList GetAllProductsByCategory(string category)
        {
            ArrayList val = new ArrayList();

            string sql = "select *  from product where productcategory='"+category+"' order by productid desc";
            ocmd = new SqlCommand(sql, conn);
            conn.Open();

            odr = ocmd.ExecuteReader();

            while (odr.Read())
            {
                val.Add(odr.GetValue(0).ToString());
                val.Add(odr.GetValue(1).ToString());
                val.Add(odr.GetValue(2).ToString());
                val.Add(odr.GetValue(3).ToString());
                val.Add(odr.GetValue(4).ToString());
                val.Add(odr.GetValue(5).ToString());
                val.Add(odr.GetValue(6).ToString());
            }
            conn.Close();
            return val;
        }

        public ArrayList GetByProduct(string pid)
        {
            ArrayList val = new ArrayList();

            string sql = "select *  from product where productid='"+pid+"'";
            ocmd = new SqlCommand(sql, conn);
            conn.Open();

            odr = ocmd.ExecuteReader();

            while (odr.Read())
            {
                val.Add(odr.GetValue(0).ToString());
                val.Add(odr.GetValue(1).ToString());
                val.Add(odr.GetValue(2).ToString());
                val.Add(odr.GetValue(3).ToString());
                val.Add(odr.GetValue(4).ToString());
                val.Add(odr.GetValue(5).ToString());
                val.Add(odr.GetValue(6).ToString());
            }
            conn.Close();
            return val;
        }

        public ArrayList GetMembersPostes()
        {
            ArrayList val = new ArrayList();

            string sql = "select *  from post order by postid desc";
            ocmd = new SqlCommand(sql, conn);
            conn.Open();

            odr = ocmd.ExecuteReader();

            while (odr.Read())
            {
                val.Add(odr.GetValue(0).ToString());
                val.Add(odr.GetValue(1).ToString());
                val.Add(odr.GetValue(2).ToString());
                val.Add(odr.GetValue(3).ToString());
                val.Add(odr.GetValue(4).ToString());
            }
            conn.Close();
            return val;
        }

        public string GetUserMobile(string userid)
        {
            string ps = "Not Found";

            string sql = "select mobile from users where userid='" + userid+"'";

            ocmd = new SqlCommand(sql, conn);
            conn.Open();

            odr = ocmd.ExecuteReader();
            odr.Read();

            if (odr.HasRows)
                ps = odr.GetValue(0).ToString();

            conn.Close();
            return ps;

        }

        public string GetUserName(string regno)
        {
            string ps = "Not Found";

            string sql = "select studentname from Student where regno='" + regno + "'";

            ocmd = new SqlCommand(sql, conn);
            conn.Open();

            odr = ocmd.ExecuteReader();
            odr.Read();

            if (odr.HasRows)
                ps = odr.GetValue(0).ToString();

            conn.Close();
            return ps;

        }

        public string GetToUserMailID(string mailrefno)
        {
            string ps = "Not Found";

            string sql = "select fromuser from Mailbox where mailid=" + mailrefno;

            ocmd = new SqlCommand(sql, conn);
            conn.Open();

            odr = ocmd.ExecuteReader();
            odr.Read();

            if (odr.HasRows)
                ps = odr.GetValue(0).ToString();

            conn.Close();
            return ps;

        }
        public bool CheckUser(string userid, string pass)
        {
            bool flag;
            string sql = null;

            sql = "select * from Users where userid='" + userid + "' and passwd='" + pass + "'";

            ocmd = new SqlCommand(sql, conn);
            conn.Open();

            odr = ocmd.ExecuteReader();
            odr.Read();

            if (odr.HasRows)
                flag = true;
            else
                flag = false;
            conn.Close();

            return flag;

        }

        public bool CheckUser_Mobile(string mailid, string mobile, string type)
        {
            bool flag;
            string sql = null;

            sql = "select * from User_Basic where mailid='" + mailid + "' and mobile='" + mobile + "' and type='" + type + "'";

            ocmd = new SqlCommand(sql, conn);
            conn.Open();

            odr = ocmd.ExecuteReader();
            odr.Read();

            if (odr.HasRows)
                flag = true;
            else
                flag = false;
            conn.Close();

            return flag;

        }
        public bool IsCategoryExists(string category)
        {
            bool flag;
            string sql = null;

            sql = "select * from Category where category='" + category + "'";

            ocmd = new SqlCommand(sql, conn);
            conn.Open();

            odr = ocmd.ExecuteReader();
            odr.Read();

            if (odr.HasRows)
                flag = true;
            else
                flag = false;
            conn.Close();

            return flag;

        }



        public string GetPassword(string mailid)
        {
            string ps = "Pl. Check the Mail ID";

            string sql = "select passwd from User_Basic where mailid='" + mailid + "'";

            ocmd = new SqlCommand(sql, conn);
            conn.Open();

            odr = ocmd.ExecuteReader();
            odr.Read();

            if (odr.HasRows)
                ps = odr.GetValue(0).ToString();

            conn.Close();
            return ps;

        }

//-------------------------------
//-----------------------------Standard Functions

        public string GetCourseName(string mailid)
        {
            string ps = "Not Found";

            //  string sql = "select CourseName from  Basic_user where mailid='" + mailid + "' and flag=No";

            string sql = "select CourseName from  User_Basic where mailid='" + mailid + "'";

            ocmd = new SqlCommand(sql, conn);
            conn.Open();

            odr = ocmd.ExecuteReader();
            odr.Read();

            if (odr.HasRows)
                ps = odr.GetValue(0).ToString();

            conn.Close();
            return ps;

        }

        public string GetMailID(string question)
        {
            string ps = "Not Found";

            string sql = "select mailid from question where question='" + question + "' and flag=No";

            ocmd = new SqlCommand(sql, conn);
            conn.Open();

            odr = ocmd.ExecuteReader();
            odr.Read();

            if (odr.HasRows)
                ps = odr.GetValue(0).ToString();

            conn.Close();
            return ps;

        }

        public string GetQuestionID(string question)
        {
            string ps = "Not Found";

            string sql = "select QID from question where question='" + question + "' and flag=No";

            ocmd = new SqlCommand(sql, conn);
            conn.Open();

            odr = ocmd.ExecuteReader();
            odr.Read();

            if (odr.HasRows)
                ps = odr.GetValue(0).ToString();

            conn.Close();
            return ps;

        }

        public string GetMemberName(string mailid)
        {
            string ps = "Not Found";

            string sql = "select UserName from User_Basic where mailid='" + mailid +"'";

            ocmd = new SqlCommand(sql, conn);
            conn.Open();

            odr = ocmd.ExecuteReader();
            odr.Read();

            if (odr.HasRows)
                ps = odr.GetValue(0).ToString();

            conn.Close();
            return ps;

        }
        public ArrayList GetMembers()
        {
            ArrayList val = new ArrayList();

            string sql = "select userid from users";
            ocmd = new SqlCommand(sql, conn);
            conn.Open();

            odr = ocmd.ExecuteReader();

            while (odr.Read())
            {
                val.Add(odr.GetValue(0).ToString());
            }
            conn.Close();
            return val;
        }
        
        public string GetMemberType(string mailid)
        {
            string ps = "Not Found";

            string sql = "select type from User_Basic where mailid='" + mailid + "'";

            ocmd = new SqlCommand(sql, conn);
            conn.Open();

            odr = ocmd.ExecuteReader();
            odr.Read();

            if (odr.HasRows)
                ps = odr.GetValue(0).ToString();

            conn.Close();
            return ps;

        }
              
              
      

        public ArrayList GetUser_BasicDatas(string mailid)
        {
            ArrayList val = new ArrayList();

            string sql = "select * from user_basic where mailid='" + mailid + "'";
            oda = new SqlDataAdapter(sql, conn);
            ocmd = new SqlCommand(sql, conn);
            conn.Open();

            odr = ocmd.ExecuteReader();

            while (odr.Read())
            {
                for (int i = 0; i < odr.FieldCount; i++)
                {
                    val.Add(odr.GetValue(i).ToString());
                }
            }
            conn.Close();
            return val;
        }
       
                  
        public bool IsUserAlreadyRegistered(string mailid)
        {
            bool flag;

            string sql = "select * from Users where mailid='" + mailid + "'";

            ocmd = new SqlCommand(sql, conn);
            conn.Open();

            odr = ocmd.ExecuteReader();
            odr.Read();

            if (odr.HasRows)
                flag = true;
            else
                flag = false;
            conn.Close();

            return flag;

        }

       
        public string SendEMail(string toid, string message)
        {
            try
            {

                string emailid = "mailer@ezeelearn.com";
                string emailpass = "mailer@ezeelearn";

                string emailsubject = "ezeelearn.com";

                System.Net.Mail.MailMessage MyMailMessage = new System.Net.Mail.MailMessage(emailid, toid, emailsubject, message);

                MyMailMessage.IsBodyHtml = false;

                // Proper Authentication Details need to be passed when sending email from gmail
                System.Net.NetworkCredential mailAuthentication = new
                System.Net.NetworkCredential(emailid, emailpass);

                // Smtp Mail server of Gmail is "smpt.gmail.com" and it uses port no. 587
                // For different server like yahoo this details changes and you can
                // Get it from respective server.
                System.Net.Mail.SmtpClient mailClient = new System.Net.Mail.SmtpClient("smtp.gmail.com", 587);

                // Enable SSL
                mailClient.EnableSsl = true;

                mailClient.UseDefaultCredentials = false;

                mailClient.Credentials = mailAuthentication;

                mailClient.Send(MyMailMessage);
            }
            catch (Exception ee1)
            {
                return ee1.Message;
            }
            return "Mail Sent";
        }

        public ArrayList GetDayBook(string st,string ed)
        {
            ArrayList val = new ArrayList();
           // string sql = "select * from trans WHERE TransDate BETWEEN #" + st + "# AND #" + ed + "#";
            string sql = "select * from TransReport";             // WHERE TransDate BETWEEN #" + st + "# AND #" + ed + "#";
            oda = new SqlDataAdapter(sql, conn);
            ocmd = new SqlCommand(sql, conn);
            conn.Open();

            odr = ocmd.ExecuteReader();

            while (odr.Read())
            {
                for (int i = 0; i < odr.FieldCount; i++)
                {
                    val.Add(odr.GetValue(i).ToString());
                }
            }
            conn.Close();
            return val;
        }


        public ArrayList GetCategory()
        {
            ArrayList val = new ArrayList();

            string sql = "select distinct category from links";
            oda = new SqlDataAdapter(sql, conn);
            ocmd = new SqlCommand(sql, conn);
            conn.Open();

            odr = ocmd.ExecuteReader();

            while (odr.Read())
            {
                for (int i = 0; i < odr.FieldCount; i++)
                {
                    val.Add(odr.GetValue(i).ToString());
                }
            }
            conn.Close();
            return val;
        }

        public ArrayList GetMailID()
        {
            ArrayList val = new ArrayList();

            string sql = "select mailid  from users";
            oda = new SqlDataAdapter(sql, conn);
            ocmd = new SqlCommand(sql, conn);
            conn.Open();

            odr = ocmd.ExecuteReader();

            while (odr.Read())
            {
              val.Add(odr.GetValue(0).ToString());
            }
            conn.Close();
            return val;
        }

        public string GetUnReadMailCount(string mailid)
        {
            string sq = "select count(*) as mcout from mailbox where touser='"+mailid+"' and checked=No";
            oda = new SqlDataAdapter(sq, conn);
            ocmd = new SqlCommand(sq, conn);
            conn.Open();
            odr = ocmd.ExecuteReader();
            string val = null;
            while (odr.Read())
            {
                val = odr.GetValue(0).ToString();
            }
            conn.Close();
            return val;
        }

      
	}//dbio

