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
    public partial class WebUserControl1 : System.Web.UI.UserControl
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
                Getmarksdetails();
            }
        }

        private void Getmarksdetails()
        {

            DataTable dt = fn.fatch("select Row_NUMBER() over(order by (select 1)) as[sr.no],e.exam_id,e.class_id,c.class_name,e.subject_id,s.subject_name,e.roll_no,e.total_marks,e.outof_marks from exam e  inner join class c on e.class_id=c.class_id inner join subject s on e.subject_id=s.subject_id ");
            GridView1.DataSource = dt;
            GridView1.DataBind();
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


        protected void btnAdd_Click1(object sender, EventArgs e)

        {
            try
            {
                string classid = ddlclass1.SelectedValue;
                string rollno = txtroll1.Text.Trim();
                DataTable dt = fn.fatch("select Row_NUMBER() over(order by (select 1)) as[sr.no] , e.exam_id,e.class_id,c.class_name,e.subject_id,s.subject_name , e.roll_no,e.total_marks,e. outof_marks from exam e  inner join class c on e.class_id=c.class_id inner join subject s on e.subject_id=s.subject_id where e.class_id='" + classid + "' and e.roll_no='" + rollno + "' ");
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }
    }
}