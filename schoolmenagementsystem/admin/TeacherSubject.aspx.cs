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
    public partial class TeacherSubject : System.Web.UI.Page
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
                getteacher();
                getteachersubject();
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
        private void getteacher()



        {
            DataTable dt = fn.fatch("select * from teacher");
            ddlteacher1.DataSource = dt;
            ddlteacher1.DataTextField = "teacher_name";
            ddlteacher1.DataValueField = "teacher_id";
            ddlteacher1.DataBind();
            ddlteacher1.Items.Insert(0, "select teacher");
        }
        private void getteachersubject()
        {
            DataTable dt = fn.fatch("select Row_NUMBER() over(order by (select 1)) as[sr.no],ts.teachersubject,ts.class_id,c.class_name,ts.subject_id,s.subject_name,ts.teacher_id,t.teacher_name from teachersubject ts  inner join class c on ts.class_id=c.class_id inner join subject s on ts.subject_id=s.subject_id inner join teacher t on ts.teacher_id=t.teacher_id");
            GridView1.DataSource = dt;
            GridView1.DataBind();

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

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string classid = ddlclass1.SelectedValue;
                string subjectid = ddlsubject1.SelectedValue;
                string teacher_id = ddlteacher1.SelectedValue;

                DataTable dt = fn.fatch("select * from teachersubject where teacher_id='" + teacher_id + "' or  subject_id='" + subjectid + "' and class_id='" + classid + "' ");
                if (dt.Rows.Count == 0)
                {
                    string query = "insert into teachersubject values ('" + teacher_id + "','" + subjectid + "','" + classid + "')";

                    fn.Query(query);
                    LBLmsg.Text = " inserted seccessfully!";
                    LBLmsg.CssClass = "alert alert_success";
                    ddlclass1.SelectedIndex = 0;
                    ddlsubject1.SelectedIndex = 0;
                    ddlteacher1.SelectedIndex = 0;
                    getteachersubject();

                }
                else
                {

                    LBLmsg.Text = " enter teacher subject alredy exist ";
                    LBLmsg.CssClass = "alert alert_danger";
                }




            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");

            }



        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.EditIndex = e.NewPageIndex;
            getteachersubject();

        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            getteachersubject() ;
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            getteachersubject();
        }


        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                GridViewRow row = GridView1.Rows[e.RowIndex];
                int teachersubjectid = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);
                string teacheid = ((DropDownList)GridView1.Rows[e.RowIndex].Cells[2].FindControl("ddlteacherg")).SelectedValue;
                string subjectid = ((DropDownList)GridView1.Rows[e.RowIndex].Cells[2].FindControl("ddlsubjectg")).SelectedValue;
                string classid = ((DropDownList)GridView1.Rows[e.RowIndex].Cells[2].FindControl("ddlclassg")).SelectedValue;
                fn.Query("update teachersubject set teacher_id ='" + teacheid + "', subject_id='" + subjectid + "' , class_id ='" + classid + "'   ");
                LBLmsg.Text = " teachers Updated seccessfully!";
                LBLmsg.CssClass = "alert alert_success";
                GridView1.EditIndex = -1;
                getteachersubject();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
            }

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void GridView1_RowDeleting1(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                int teachersubjectid = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);
                fn.Query("delete from teachersubject where teachersubject_id='" + teachersubjectid + "'");
                LBLmsg.Text = " teacher Deleted seccessfully!";
                LBLmsg.CssClass = "alert alert_success";

                GridView1.EditIndex = -1;
                getteachersubject();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        protected void ddlclassg_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddlclassSelected = (DropDownList)sender;
            GridViewRow row = (GridViewRow)ddlclassSelected.NamingContainer;
            if (row != null)
            {
                if ((row.RowState & DataControlRowState.Edit) > 0)
                {
                    DropDownList ddlsubjectg = (DropDownList)row.FindControl("ddlsubjectg");
                    DataTable dt = fn.fatch("select * from subject where class_id='" + ddlclassSelected.SelectedValue + "'");
                    ddlsubjectg.DataSource = dt;
                    ddlsubjectg.DataTextField = "subject_name";
                    ddlsubjectg.DataValueField = "subject_id";
                    ddlsubjectg.DataBind();
                    ddlsubjectg.Items.Insert(0, "select subject");

                }
            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {if (e.Row.RowType == DataControlRowType.DataRow)
            {

                if ((e.Row.RowState & DataControlRowState.Edit) > 0)
                {
                    DropDownList ddlclassgv = (DropDownList)e.Row.FindControl("ddlclassg");
                    DropDownList ddlsubjectgv = (DropDownList)e.Row.FindControl("ddlsubjectg");
                    DataTable dt = fn.fatch("select * from subject where class_id='" + ddlclassgv.SelectedValue + "'");
                    ddlsubjectgv.DataSource = dt;
                    ddlsubjectgv.DataTextField = "subject_name";
                    ddlsubjectgv.DataValueField = "subject_id";
                    ddlsubjectgv.DataBind();
                    ddlsubjectgv.Items.Insert(0, "select subject");
                    string teachersubjectid = GridView1.DataKeys[e.Row.RowIndex].Value.ToString();
                    DataTable dt1 = fn.fatch(@"select ts.teachersubject_id,ts.subject_id,ts.class_id,s.subject_name from teachersubject ts  inner join subject s on ts.subject_id=s.subject_id where ts.teachersubject_id='"+teachersubjectid+"' ");
                    ddlsubjectgv.SelectedValue = dt1.Rows[0]["subject_id"].ToString();


                }
            }
        } 
    }
}
