using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static schoolmenagementsystem.Models.Commanfn;

namespace schoolmenagementsystem.Teacher
{
    public partial class StudentAttendance : System.Web.UI.Page
    {

        Commanfnx fn = new Commanfnx();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["admin"] == null)
            {
                Response.Redirect("../Login.aspx");
            }
            if (!IsPostBack)
            {
                getclass();
                btnattendance.Visible = false;

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
        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            DataTable dt = fn.fatch("select student_id,roll_no,student_name  from student where class_id='" + ddlclass1.SelectedValue + "'");
            GridView1.DataSource = dt;
            GridView1.DataBind();
            if (dt.Rows.Count > 0)
            {
                btnattendance.Visible = true;
            }
            else
            {
                btnattendance.Visible = false;
            }
        }


          
     
        protected void btnattendance_Click(object sender, EventArgs e)
        {  bool isTrue=false;
            foreach (GridViewRow row in GridView1.Rows)
            {

                int rollno = Convert.ToInt32(row.Cells[2].Text.Trim());

                RadioButton rb1 = (row.Cells[0].FindControl("RadioButton1") as RadioButton);
                RadioButton rb2 = (row.Cells[0].FindControl("RadioButton1") as RadioButton);
                int status = 0;
                if (rb1.Checked)
                {
                    status = 1;
                }
                else if (rb2.Checked)
                {
                    status = 0 ;
                }
                fn.Query("insert into  studentattendence values ('" + ddlclass1.SelectedValue + "','" + ddlsubject1 .SelectedValue+ "', '" + rollno + "','" + status + "','" + lbltimer.Text + "')");
               isTrue = true;   
            }
            if (isTrue)  
            {
                LBLmsg.Text = " inserted seccessfully!";
                LBLmsg.CssClass = "alert alert-success";

            }
            else 
            {
                LBLmsg.Text = " something went wrong!";
                LBLmsg.CssClass = "alert alert-warning";
            }
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            lbltimer.Text = DateTime.Now.ToString();
        }

       
    } 
}