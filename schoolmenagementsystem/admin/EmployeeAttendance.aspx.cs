using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static schoolmenagementsystem.Models.Commanfn;

namespace schoolmenagementsystem
{
    public partial class EmployeeAttendance : System.Web.UI.Page
    {
        Commanfnx fn = new Commanfnx(); 
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Session["admin"] == null)
            //{
            //    Response.Redirect("../Login.aspx");
            //}

            if (!IsPostBack)
            {
                getattendance();
            }
        }

        private void getattendance()
        {
            DataTable dt = fn.fatch("select teacher_id,teacher_name,mobile,email from teacher ");
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        protected void btnattendance_Click(object sender, EventArgs e)
        {
            foreach( GridViewRow row in GridView1.Rows)
            {
                
                int teacherid = Convert.ToInt32(row.Cells[1].Text );
                
                RadioButton rb1 = (row.Cells[0].FindControl("RadioButton1") as RadioButton);
                RadioButton rb2 = (row.Cells[0].FindControl("RadioButton1") as RadioButton);
                int status = 0;
                    if(rb1.Checked)
                {
                    status = 1;
                }
                else if (rb2.Checked)
                { 
                    status = 0;
                }
                fn.Query("insert into teacherattendence values ( '" + teacherid + "','" + status + "','" +lbltimer.Text+ "')");
                LBLmsg.Text = " inserted seccessfully!";
                 LBLmsg.CssClass = "alert alert-success";

            }
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            lbltimer.Text = DateTime.Now.ToString();
        }
    }
}