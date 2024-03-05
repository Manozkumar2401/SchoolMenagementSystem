using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static schoolmenagementsystem.Models.Commanfn;

namespace schoolmenagementsystem.admin
{
    public partial class StudentAttendanceDetails : System.Web.UI.Page
    {
        Commanfnx fn = new Commanfnx();
        private object dt;

        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["admin"] == null)
            {
                Response.Redirect("../Login.aspx");
            }
            if (!IsPostBack)
            {
                getclass();

                getsubject();

            }
        }
        private void getclass()
        {
            DataTable dt = fn.fatch("select * from class");
            ddlclass1.DataSource = dt;
            ddlclass1.DataTextField = "class_name";
            ddlclass1.DataValueField = "class_id";
            ddlclass1.DataBind();
            ddlclass1.Items.Insert(0, "select class");
        }
        private void getsubject()

        {
            DataTable dt = fn.fatch("select * from subject");
            ddlsubject1.DataSource = dt;
            ddlsubject1.DataTextField = "subject_name";
            ddlsubject1.DataValueField = "subject_id";
            ddlsubject1.DataBind();
            ddlsubject1.Items.Insert(0, "select subject");
        }
        protected void ddlclass1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string classid = ddlclass1.SelectedValue;
            DataTable dt = fn.fatch("select * from subject where class_id='" + classid + "' ");
            ddlsubject1.DataSource = dt;
            ddlsubject1.DataTextField = "subject_name";
            ddlsubject1.DataValueField = "subject_id";
            ddlsubject1.DataBind();
            ddlsubject1.Items.Insert(0, "select subject");
        }

        protected void btnattendance_Click(object sender, EventArgs e)
        {
            DateTime date = Convert.ToDateTime(txtmonth1.Text);
            if (ddlsubject1.SelectedValue == "select subject")
            {
                DataTable dt = fn.fatch("select Row_NUMBER() over(order by(select 1)) as[sr.no],s.student_name, sa.status, sa.date from studentattendence sa inner join student s on sa.roll_no = s.roll_no where sa.roll_no='" + txtroll1 + "' and DATEPART(YY, DATE)='" + date.Year + "' and DATEPART(MM, DATE)= '" + date.Month + "'");

            }
            else

            {
                DataTable dt = fn.fatch("select Row_NUMBER() over(order by(select 1)) as[sr.no],s.student_name, sa.status, sa.date from studentattendence sa inner join student s on sa.roll_no = s.roll_no where sa.roll_no='" + txtroll1 + "' and sa.subject_id='" + ddlsubject1.SelectedValue + "' and DATEPART(YY, DATE)='" + date.Year + "' and DATEPART(MM, DATE)= '" + date.Month + "'");

            }
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
    }
}