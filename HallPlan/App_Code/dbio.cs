
using System.IO;
using System.Data.OleDb;
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
using System.Net.Mail;

	public class dbio
	{
		public OleDbConnection conn;
	
		OleDbCommand ocmd;
		OleDbDataReader odr;
		OleDbDataAdapter oda;
        ArrayList members = new ArrayList();
        public dbio()
        {
            CultureInfo culture = (CultureInfo)CultureInfo.CurrentCulture.Clone();
            culture.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy";
            culture.DateTimeFormat.LongTimePattern = "";
            System.Threading.Thread.CurrentThread.CurrentCulture = culture;

            string apppath = System.Web.HttpContext.Current.Request.PhysicalApplicationPath;

          

           // String apppath =  System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase); 


            conn = new OleDbConnection("provider = MicroSoft.JET.OLEDB.4.0;data source=" + apppath + "\\student.mdb;");
            //string strConnection = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
           // conn = new OleDbConnection(strConnection);           

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
                ocmd = new OleDbCommand(sql, conn);
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
                 ocmd = new OleDbCommand(sql, conn);
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
            ocmd = new OleDbCommand(sql, conn);
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
            oda = new OleDbDataAdapter(sq, conn);
            ocmd = new OleDbCommand(sq, conn);
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

        public void FillGrid(string sql, GridView dg)
        {
            DataSet ds = new DataSet();
            ocmd = new OleDbCommand(sql, conn);
            oda = new OleDbDataAdapter(ocmd);
            ds = new DataSet();
            oda.Fill(ds, "Cust");
            dg.DataSource = ds.Tables["Cust"];
            dg.DataBind();
        }

        public void UpdateDatasetTable(DataSet ds, string table)
        {
           

        }

        public DataTable GetDataTable(string sql)
        {
            DataSet ds = new DataSet();
            
            ocmd = new OleDbCommand(sql, conn);
            oda = new OleDbDataAdapter(ocmd);
            ds = new DataSet();
            oda.Fill(ds, "Cust");
            DataTable dt = ds.Tables["Cust"];
            return dt;
        }

//-----------------------------Standard Functions
        //----- for student
        //school

        public ArrayList GetStudentByRollno(string regno)
        {
            string sql = "select * from student where rollno='" + regno + "'";
            ArrayList val = new ArrayList();
            ocmd = new OleDbCommand(sql, conn);
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
                 
            }
            conn.Close();
            return val;
        }

        public ArrayList GetMark(string rollno,string test,string subject)
        {
            string sql = "select dateofexam,mark from marks where rollno='" + rollno + "' and test='" + test + "' and subject='" + subject + "'";
            ArrayList val = new ArrayList();
            ocmd = new OleDbCommand(sql, conn);
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
        public ArrayList GetMarkByRollno(string regno)
        {
            string sql = "select * from marks where rollno='" + regno + "'";
            ArrayList val = new ArrayList();
            ocmd = new OleDbCommand(sql, conn);
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

            }
            conn.Close();
            return val;
        }
        public string GetExamDate(string test,string subject)
        {
            string val = "not found";

            string sq = "select dateofexam from examschedule where test='" + test+"' and subject='"+subject+"'";
            oda = new OleDbDataAdapter(sq, conn);
            ocmd = new OleDbCommand(sq, conn);
            conn.Open();

            odr = ocmd.ExecuteReader();

            while (odr.Read())
            {
                val = odr.GetValue(0).ToString();
            }
            conn.Close();
            return val;
        }

        public bool CheckRollNumber(string rollno)
        {
            bool flag;
            string sql = null;

            sql = "select * from Student where rollno='" + rollno + "'"; 

            ocmd = new OleDbCommand(sql, conn);
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
        public bool CheckUserByMobileNo(string rollno,string mobile)
        {
            bool flag;
            string sql = null;

            sql = "select * from Student where rollno='" + rollno + "' and mobile='"+mobile+"'";

            ocmd = new OleDbCommand(sql, conn);
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

        public string GetStudentName(string rollno)
        {
            string ps = "Not Found";

            string sql = "select StudentName,SClass,SSection from Student where rollno='" + rollno + "'";

            ocmd = new OleDbCommand(sql, conn);
            conn.Open();

            odr = ocmd.ExecuteReader();
            odr.Read();

            if (odr.HasRows)
            {
                string ps1 = odr.GetValue(0).ToString();
                string ps2 = odr.GetValue(1).ToString();
                string ps3 = odr.GetValue(2).ToString();
                ps = ps1 + " -- " + ps2 + "  " + ps3;
            }


            conn.Close();
            return ps;

        }

        public string GetStudentNameByMobile(string mobile)
        {
            string ps = "Not Found";

            string sql = "select StudentName,SClass,SSection from Student where mobile='" + mobile + "'";

            ocmd = new OleDbCommand(sql, conn);
            conn.Open();

            odr = ocmd.ExecuteReader();
            odr.Read();

            if (odr.HasRows)
            {
                string ps1 = odr.GetValue(0).ToString();
                string ps2 = odr.GetValue(1).ToString();
                string ps3 = odr.GetValue(2).ToString();
                ps = ps1 + " -- " + ps2 + "  " + ps3;
            }


            conn.Close();
            return ps;

        }

        public ArrayList GetStudentEMail(string sclass)
        {
            ArrayList val = new ArrayList();
            string sq = "select mailid from Exam_Mail where sclass='" + sclass + "'";
            oda = new OleDbDataAdapter(sq, conn);
            ocmd = new OleDbCommand(sq, conn);
            conn.Open();

            odr = ocmd.ExecuteReader();

            while (odr.Read())
            {
                val.Add(odr.GetValue(0).ToString());
            }
            conn.Close();
            return val;
        }

        public string GetExamMessage(string sclass,string dateofexam)
        {
            string val = "";
            string sq = "select sclass,subject,dateofexam from Exam_Mail where sclass='" + sclass + "' and dateofexam='"+dateofexam+"'";
            oda = new OleDbDataAdapter(sq, conn);
            ocmd = new OleDbCommand(sq, conn);
            conn.Open();

            odr = ocmd.ExecuteReader();

            while (odr.Read())
            {
                string scl = odr.GetValue(0).ToString();
                string sub = odr.GetValue(1).ToString();
                string dt = odr.GetValue(2).ToString();
                val = "Exam Notification \n\nClass :" + sclass + "\n Subject : " + sub + "\n Date of Exam :" + dateofexam + "\n\n\n Exam Cell ";
            }
            conn.Close();
            return val;
        }

        //school


        public ArrayList GetArrearStudentEMail(string subject)
        {
            ArrayList val = new ArrayList();
            string sq = "select mailid from SuppExam_Mail where subject='" + subject + "'";
            oda = new OleDbDataAdapter(sq, conn);
            ocmd = new OleDbCommand(sq, conn);
            conn.Open();

            odr = ocmd.ExecuteReader();

            while (odr.Read())
            {
                val.Add(odr.GetValue(0).ToString());
            }
            conn.Close();
            return val;
        }

        public string GetArrearMessage(string subject)
        {
            string val = "";
            string sq = "select semester,subject,dateofexam from SuppExam_Mail where subject='" + subject + "'";
            oda = new OleDbDataAdapter(sq, conn);
            ocmd = new OleDbCommand(sq, conn);
            conn.Open();

            odr = ocmd.ExecuteReader();

            while (odr.Read())
            {
                string semester=odr.GetValue(0).ToString();
                string sub = odr.GetValue(1).ToString();
                string dateofexam = odr.GetValue(2).ToString();
                val = "Arrear Exam Notification \n\nSemester :" +semester + "\n Subject : " + sub + "\n Date of Exam :" + dateofexam +"\n\n\n Exam Cell MCE";
            }
            conn.Close();
            return val;
        }

        public ArrayList GetAllStudentEMail()
        {
            ArrayList val = new ArrayList();
            string sq = "select mailid from student"; 
            oda = new OleDbDataAdapter(sq, conn);
            ocmd = new OleDbCommand(sq, conn);
            conn.Open();

            odr = ocmd.ExecuteReader();

            while (odr.Read())
            {
                val.Add(odr.GetValue(0).ToString());
            }
            conn.Close();
            return val;
        }

        public string GetInterviewMessage()
        {
            string val=""; 
            string sq = "select * from interviewmessage";
            oda = new OleDbDataAdapter(sq, conn);
            ocmd = new OleDbCommand(sq, conn);
            conn.Open();
            odr = ocmd.ExecuteReader();
            while (odr.Read())
            {
                val=odr.GetValue(0).ToString();
            }
            conn.Close();
            return val;
        }

        public string GetEventMessage()
        {
            string val = "";
            string sq = "select * from eventmessage";
            oda = new OleDbDataAdapter(sq, conn);
            ocmd = new OleDbCommand(sq, conn);
            conn.Open();
            odr = ocmd.ExecuteReader();
            while (odr.Read())
            {
                val = odr.GetValue(0).ToString();
            }
            conn.Close();
            return val;
        }


        public ArrayList GetStudent(string rollno)
        {
            string sql = "select * from student where rollno='"+rollno+"'";
            ArrayList val = new ArrayList();
            ocmd = new OleDbCommand(sql, conn);
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
                val.Add(odr.GetValue(7).ToString());
                val.Add(odr.GetValue(8).ToString());
                val.Add(odr.GetValue(9).ToString());
                val.Add(odr.GetValue(10).ToString());
                val.Add(odr.GetValue(11).ToString());
           
            }
            conn.Close();
            return val;
        }

        public ArrayList GetAbsentMaster(string regno)
        {
            string sql = "select * from absent where regno='" + regno + "'";
            ArrayList val = new ArrayList();
            ocmd = new OleDbCommand(sql, conn);
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
        public ArrayList GetMarks(string regno)
        {
            string sql = "select * from marks where regno='" + regno + "'";
            ArrayList val = new ArrayList();
            ocmd = new OleDbCommand(sql, conn);
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
                val.Add(odr.GetValue(7).ToString());
            }
            conn.Close();
            return val;
        }
        //--- for student function
        //--- for student function
        
        public string GetCourseName(string mailid)
        {
            string ps = "Not Found";

            //  string sql = "select CourseName from  Basic_user where mailid='" + mailid + "' and flag=No";

            string sql = "select CourseName from  User_Basic where mailid='" + mailid + "'";

            ocmd = new OleDbCommand(sql, conn);
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

            ocmd = new OleDbCommand(sql, conn);
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

            ocmd = new OleDbCommand(sql, conn);
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

            ocmd = new OleDbCommand(sql, conn);
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
            ocmd = new OleDbCommand(sql, conn);
            conn.Open();

            odr = ocmd.ExecuteReader();

            while (odr.Read())
            {
                val.Add(odr.GetValue(0).ToString());
            }
            conn.Close();
            return val;
        }
        
        public string GetToUserMailID(string mailrefno)
        {
            string ps = "Not Found";

            string sql = "select fromuser from Mailbox where mailid=" + mailrefno;

            ocmd = new OleDbCommand(sql, conn);
            conn.Open();

            odr = ocmd.ExecuteReader();
            odr.Read();

            if (odr.HasRows)
                ps = odr.GetValue(0).ToString();

            conn.Close();
            return ps;

        }
        public string GetMemberType(string mailid)
        {
            string ps = "Not Found";

            string sql = "select type from User_Basic where mailid='" + mailid + "'";

            ocmd = new OleDbCommand(sql, conn);
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

            ocmd = new OleDbCommand(sql, conn);
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

            ocmd = new OleDbCommand(sql, conn);
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
              
        public string  GetPassword(string mailid)
        {
            string ps = "Pl. Check the Mail ID";

            string sql = "select passwd from User_Basic where mailid='" + mailid + "'";

            ocmd = new OleDbCommand(sql, conn);
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
            oda = new OleDbDataAdapter(sql, conn);
            ocmd = new OleDbCommand(sql, conn);
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
       
        public ArrayList GetMailforCourse(string courseid)
        {
            ArrayList ps = new ArrayList();

            string sql = "select mailid from CourseMembers where courseid=" + courseid;

            ocmd = new OleDbCommand(sql, conn);
            conn.Open();

            odr = ocmd.ExecuteReader();
            while (odr.Read())
            {
                string mid = odr.GetValue(0).ToString();
                ps.Add(mid);
            }

            conn.Close();
            return ps;
        }

              
        public bool IsUserAlreadyRegistered(string mailid)
        {
            bool flag;

            string sql = "select * from User_Basic where mailid='" + mailid + "'";

            ocmd = new OleDbCommand(sql, conn);
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

       

        public bool IsLeaveEntered(string dt,string sid)
        {
            bool flag;

            string sql = "select * from leave where leavedate='" + dt + "' and staffid="+sid;

            ocmd = new OleDbCommand(sql, conn);
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

      
       

        public ArrayList GetDayBook(string st,string ed)
        {
            ArrayList val = new ArrayList();
           // string sql = "select * from trans WHERE TransDate BETWEEN #" + st + "# AND #" + ed + "#";
            string sql = "select * from TransReport";             // WHERE TransDate BETWEEN #" + st + "# AND #" + ed + "#";
            oda = new OleDbDataAdapter(sql, conn);
            ocmd = new OleDbCommand(sql, conn);
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
            oda = new OleDbDataAdapter(sql, conn);
            ocmd = new OleDbCommand(sql, conn);
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
            oda = new OleDbDataAdapter(sql, conn);
            ocmd = new OleDbCommand(sql, conn);
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
            oda = new OleDbDataAdapter(sq, conn);
            ocmd = new OleDbCommand(sq, conn);
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

        public string GetLastQuestion()
        {
            //ArrayList val = new ArrayList();
            string rv=null;
            string sql = "select question,mailid,PostedDate from Forum order by qid desc";
            oda = new OleDbDataAdapter(sql, conn);
            ocmd = new OleDbCommand(sql, conn);
            conn.Open();

            odr = ocmd.ExecuteReader();

            while(odr.Read())
            {
                    string q= odr.GetValue(0).ToString();
                    string m= odr.GetValue(1).ToString();
                    string pd=odr.GetValue(2).ToString();
                    if (q.Length >= 30)
                    {
                        rv = q.Substring(0, 30) + "... <br> by : " + m + "  " + pd;
                    }
                    else
                    {
                        rv = q + "... <br> by : " + m + "  " + pd;
                    }
                    break;
            }
            conn.Close();
            return rv;
        }

        public string GetLast2ndQuestion()
        {
            //ArrayList val = new ArrayList();
            string rv = null;
            string sql = "select question,mailid,PostedDate from Forum order by qid desc";
            oda = new OleDbDataAdapter(sql, conn);
            ocmd = new OleDbCommand(sql, conn);
            conn.Open();

            odr = ocmd.ExecuteReader();

            while (odr.Read())
            {
                odr.Read();
                if (odr.GetValue(0)!=null)
                {
                    string q = odr.GetValue(0).ToString();
                    string m = odr.GetValue(1).ToString();
                    string pd = odr.GetValue(2).ToString();
                    if (q.Length >= 30)
                    {
                        rv = q.Substring(0, 30) + "... <br> by : " + m + "  " + pd;
                    }
                    else
                    {
                        rv = q + "... <br> by : " + m + "  " + pd;
                    }
                }
                break;
            }
            conn.Close();
            return rv;
        }

        public string GetCategory(string CourseName)
        {
            string val = "not found";

            string sq = "select category from Course where coursename='" + CourseName+"'";
            oda = new OleDbDataAdapter(sq, conn);
            ocmd = new OleDbCommand(sq, conn);
            conn.Open();

            odr = ocmd.ExecuteReader();

            while (odr.Read())
            {
                val = odr.GetValue(0).ToString();
            }
            conn.Close();
            return val;
        }

        public string  GetChapterName(string chapterid)
        {
            string val = "not found";

            string sq = "select Chapter from Course_Chapter where chapterid=" +chapterid;
            oda = new OleDbDataAdapter(sq, conn);
            ocmd = new OleDbCommand(sq, conn);
            conn.Open();

            odr = ocmd.ExecuteReader();

            while (odr.Read())
            {
                val= odr.GetValue(0).ToString();
            }
            conn.Close();
            return val;
        }

        public ArrayList GetChapters(string coursename)
        {
            ArrayList val = new ArrayList();
            string sq = "select ChapterID,Chapter from Course_Chapter where course='"+coursename+"' order by chapterid";
            oda = new OleDbDataAdapter(sq, conn);
            ocmd = new OleDbCommand(sq, conn);
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

        public ArrayList GetChapters_Demo(string coursename)
        {
            ArrayList val = new ArrayList();
            string sq = "select ChapterID,Chapter from Course_Chapter where course='" + coursename + "' order by chapterid";
            oda = new OleDbDataAdapter(sq, conn);
            ocmd = new OleDbCommand(sq, conn);
            conn.Open();

            odr = ocmd.ExecuteReader();

            while (odr.Read())
            {
                val.Add(odr.GetValue(0).ToString());
                val.Add(odr.GetValue(1).ToString());
                break;
            }
            conn.Close();
            return val;
        }

        public ArrayList GetChapterVideos(string chapter)
        {
            ArrayList val = new ArrayList();
            string sq = "select VideoID,VideoName from Chapter_Videos where chapter='" + chapter + "' order by videoid";
            oda = new OleDbDataAdapter(sq, conn);
            ocmd = new OleDbCommand(sq, conn);
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
       


        public ArrayList GetURL(string category)
        {
            ArrayList val = new ArrayList();
           
            string sql = "select Subject,PageURL from links where category='" + category + "'";           
            oda = new OleDbDataAdapter(sql, conn);
            ocmd = new OleDbCommand(sql, conn);
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

        public ArrayList GetEvents()
        {
            ArrayList val = new ArrayList();
            string sq = "select * from Events order by eventid desc";
            oda = new OleDbDataAdapter(sq, conn);
            ocmd = new OleDbCommand(sq, conn);
            conn.Open();

            odr = ocmd.ExecuteReader();

            while (odr.Read())
            {
                val.Add(odr.GetValue(1).ToString());
            }
            conn.Close();
            return val;
        }
       

        public void FillRepeater(string sq, Repeater NewsListRepeater)
        {

            string val = "";
            oda = new OleDbDataAdapter(sq, conn);
            ocmd = new OleDbCommand(sq, conn);
            conn.Open();

            odr = ocmd.ExecuteReader();


            /*DataTable newsDataTable = new DataTable();
            
            newsDataTable.Columns.Add("PostedBy");
            newsDataTable.Columns.Add("JobTitle");

            while (odr.Read())
            {

                    DataRow newsDataRow = newsDataTable.NewRow();

                    newsDataRow["PostedBy"] = odr.GetValue(0).ToString();
                    newsDataRow["JobTitle"] = odr.GetValue(1).ToString();

                    newsDataTable.Rows.Add(newsDataRow);

            }*/
            NewsListRepeater.DataSource = odr;
            NewsListRepeater.DataBind();

            conn.Close();



            //// create a datatable
            //DataTable newsDataTable = new DataTable();

            //// add some columns to our datatable
            //newsDataTable.Columns.Add("SpecialNumber");
            //newsDataTable.Columns.Add("SpecialLetters");

            //// create some rows in our data
            //string _letters = "ABCDE";
            //for (int i = 1; i <= 5; i++)
            //{
            //    DataRow newsDataRow = newsDataTable.NewRow();

            //    newsDataRow["SpecialNumber"] = i;
            //    newsDataRow["SpecialLetters"] = _letters.Substring(5 - i);

            //    newsDataTable.Rows.Add(newsDataRow);
            //}

            //// bind our datatable to our repeater
            //NewsListRepeater.DataSource = newsDataTable;
            //NewsListRepeater.DataBind();

        }

        public void SendMail_new(string mailfrom,string toaddress,string message)
        {
            System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
            mail.To.Add(toaddress);
            mail.From = new MailAddress(mailfrom, "Arrear Exam Reminder");
            mail.Subject = "Arrear Exam Notification";
            mail.Body = message;
            mail.IsBodyHtml = true;

            
            SmtpClient client = new SmtpClient();
            client.Credentials = new System.Net.NetworkCredential("suryamce2014@gmail.com", "suryamce@2014");
            client.Host = "smtpout.secureserver.net";
            client.Port = 80;
            try
            {
                client.Send(mail);
            }
            catch (Exception ex)
            {
                //System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        public string SendEMail(string toid, string message,string emailsubject)
        {
            try
            {
                string emailid = "muthamil.course@gmail.com";
                string emailpass = "Aj@y1234";

               // string emailsubject = "Arrear Exam Notification";

                System.Net.Mail.MailMessage MyMailMessage = new System.Net.Mail.MailMessage(emailid, toid, emailsubject, message);

                MyMailMessage.IsBodyHtml = false;

                // Proper Authentication Details need to be passed when sending email from gmail
                System.Net.NetworkCredential mailAuthentication = new System.Net.NetworkCredential(emailid, emailpass);

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

        public string SendEMailOld(string toid, string message)
        {
            try
            {

                string emailid = "mailer@ezeelearn.com";
                string emailpass = "mailer@ezeelearn";

                string emailsubject = "ezeelearn.com";

                System.Net.Mail.MailMessage MyMailMessage = new System.Net.Mail.MailMessage(emailid, toid, emailsubject, message);

                MyMailMessage.IsBodyHtml = false;

                // Proper Authentication Details need to be passed when sending email from gmail
                System.Net.NetworkCredential mailAuthentication = new System.Net.NetworkCredential(emailid, emailpass);

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
	}//dbio

