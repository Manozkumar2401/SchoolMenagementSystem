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
    public partial class WebForm1 : System.Web.UI.Page
    {
        Commanfnx fn = new Commanfnx();
        protected void Page_Load(object sender, EventArgs e)
        {

          //  if (Session["admin"] == null)
            {
              //  Response.Redirect("../Login.aspx");
            }
            if (!IsPostBack)
            {
                
                getteacher();
               


            }
        }
        private void getteacher()



        {
            DataTable dt = fn.fatch("select * from teacher");
            ddlteacher1.DataSource = dt;
            ddlteacher1.DataTextField = "teacher_name";
            ddlteacher1.DataValueField = "teacher_id";
            ddlteacher1.DataBind();
            ddlteacher1.Items.Insert(0, "select teacher");
        }

        protected void btncheckattendance_Click(object sender, EventArgs e)
        {    DateTime date=Convert.ToDateTime(txtmonth1.Text);

            DataTable dt = fn.fatch("select Row_NUMBER() over(order by(select 1)) as[sr.no],t.teacher_name, ta.status, ta.date from teacherattendence ta inner join teacher t on ta.teacher_id = t.teacher_id where DATEPART(YY, DATE)='" + date.Year+"' and DATEPART(MM, DATE)= '"+ date.Month+"' and ta.teacher_id = '"+ddlteacher1.SelectedValue+"'");
            GridView1.DataSource = dt;
            GridView1.DataBind();

        }
        
    }
}