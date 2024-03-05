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
    public partial class Marks : System.Web.UI.Page
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

                getmarks();
            }
        }

       

        protected void btnAdd_Click(object sender, EventArgs e)
        {

            try
            {
                string classid = ddlclass1.SelectedValue;
                string subjectid = ddlsubject1.SelectedValue;
                string roll = txtroll1.Text;
                string totalmarks = txtmarks1.Text;
                string outofmarks = txtoutofmarks1.Text;
                DataTable dt1 = fn.fatch("select * from student where  class_id='" + classid + "'and roll_no='" + roll+ "'");
                if (dt1.Rows.Count>0)
                {


                    DataTable dt = fn.fatch("select * from exam where  subject_id='" + subjectid + "' or class_id='" + classid + "'  and roll_no='" + roll + "'");
                    if (dt.Rows.Count == 0)
                    {
                        string query = "insert into exam values ('" + classid + "','" + subjectid + "','" + roll + "','" + totalmarks + "','" + outofmarks + "')";



                        fn.Query(query);
                        LBLmsg.Text = " inserted seccessfully!";
                        LBLmsg.CssClass = "alert alert-success";
                        ddlclass1.SelectedIndex = 0;
                        ddlsubject1.SelectedIndex = 0;
                        txtroll1.Text = string.Empty;
                        txtmarks1.Text = string.Empty;
                        txtoutofmarks1.Text = string.Empty;

                        getmarks();

                    }
                    else
                    {

                        LBLmsg.Text = " enter data is alredy exist ";
                        LBLmsg.CssClass = "alert alert-danger";
                    }

                }
                else
                {

                    LBLmsg.Text = " entered student rollno:<b>'"+roll+"'<b> does not exist ";
                    LBLmsg.CssClass = "alert alert-danger";
                }


            }
            catch (Exception ex)
            {

                Response.Write("<script>alert('" + ex.Message + "');</script>");

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
        private void getmarks()
        {
            DataTable dt = fn.fatch("select Row_NUMBER() over(order by (select 1)) as[sr.no],e.exam_id,e.class_id,c.class_name,e.subject_id,s.subject_name , e.roll_no,e.total_marks,e.outof_marks from exam e  inner join class c on e.class_id=c.class_id inner join subject s on e.subject_id=s.subject_id ");
            GridView1.DataSource = dt;
            GridView1.DataBind();

        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            getmarks();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            getmarks();
        }

        protected void GridView1_RowDeleting1(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                int expenseid = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);
                fn.Query("delete from exam  where exam_id='" + expenseid + "'");
                LBLmsg.Text = " teacher Deleted seccessfully!";
                LBLmsg.CssClass = "alert alert-success";

                GridView1.EditIndex = -1;
                getmarks();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }

        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex; getmarks();
        }


        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                GridViewRow row = GridView1.Rows[e.RowIndex];
                int expenseid = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);
                string classid = ((DropDownList)GridView1.Rows[e.RowIndex].Cells[2].FindControl("ddlclassg")).SelectedValue;
                string subjectid = ((DropDownList)GridView1.Rows[e.RowIndex].Cells[2].FindControl("ddlsubjectg")).SelectedValue;
                string roll = (row.FindControl("txtrollnog") as TextBox).Text;
                string marks = (row.FindControl("txtmarksg") as TextBox).Text;
                string outofmarks = (row.FindControl("txtoutofmarksg") as TextBox).Text;

                fn.Query("update exam set class_id ='" + classid + "', subject_id='" + subjectid + "' , roll_no ='" + roll + "', total_marks ='" + roll + "',outof_marks ='" +outofmarks+ "' where exam_id='" + expenseid + "'   ");
                LBLmsg.Text = " teachers Updated seccessfully!";
                LBLmsg.CssClass = "alert alert-success";
                GridView1.EditIndex = -1;
                getmarks();  
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
            }
        }

        protected void ddlclassg_SelectedIndexChanged1(object sender, EventArgs e)
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
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
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
                    string expenceid = GridView1.DataKeys[e.Row.RowIndex].Value.ToString();
                    DataTable dt1 = fn.fatch(@"select e.exam_id,e.subject_id,e.class_id from exam e  inner join subject s on e.subject_id=s.subject_id where e.exam_id='" + expenceid + "' ");
                    ddlsubjectgv.SelectedValue = dt1.Rows[0]["exam_id"].ToString();


                }
            }
        }
    }

}