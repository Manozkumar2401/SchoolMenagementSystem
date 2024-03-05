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
    public partial class Expence : System.Web.UI.Page
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
                getclass();

                getexpence();
               // getsubject();
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
                                                                                                         {
            try
             {
                string classid = ddlclass1.SelectedValue;
                string subjectid = ddlsubject1.SelectedValue;
                string amount = txtexpense1.Text;

                DataTable dt = fn.fatch("select * from expance where  subject_id='" +subjectid+ "' or class_id='" +classid+ "'  and amount='" + amount+"' ");
                if (dt.Rows.Count == 0)
                {
                    string query = "insert into expance values ('" + subjectid+ "','"+classid+ "','" +amount+ "')";
                    fn.Query(query);
                    LBLmsg.Text = " inserted seccessfully!";
                    LBLmsg.CssClass = "alert alert_success";
                    ddlclass1.SelectedIndex = 0;
                    ddlsubject1.SelectedIndex = 0;                    
                    getexpence();

                }    
                else
                {

                    LBLmsg.Text = " enter expanse amount is alredy exist ";
                    LBLmsg.CssClass = "alert alert_danger";
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
        private void getexpence()
        {
            DataTable dt = fn.fatch("select Row_NUMBER() over(order by (select 1)) as[sr.no],e.expance_id,e.class_id,c.class_name,e.subject_id,s.subject_name , e.amount from expance e  inner join class c on e.class_id=c.class_id inner join subject s on e.subject_id=s.subject_id ");
            GridView1.DataSource = dt;
            GridView1.DataBind();

        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex=e.NewPageIndex;
            getexpence();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            getexpence();
        }

        protected void GridView1_RowDeleting1(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                int expenseid = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);
                fn.Query("delete from expance  where expance_id='" + expenseid + "'");
                LBLmsg.Text = " teacher Deleted seccessfully!";
                LBLmsg.CssClass = "alert alert-success";

                GridView1.EditIndex = -1;
                getexpence();

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }

        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex; getexpence();
        }


        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                GridViewRow row = GridView1.Rows[e.RowIndex];
                int expenseid = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);
                string classid = ((DropDownList)GridView1.Rows[e.RowIndex].Cells[2].FindControl("ddlclassg")).SelectedValue;
                string subjectid = ((DropDownList)GridView1.Rows[e.RowIndex].Cells[2].FindControl("ddlsubjectg")).SelectedValue;
                string amount = (row.FindControl("txtamountg") as TextBox).Text;

                fn.Query("update expance set class_id ='" + classid + "', subject_id='" + subjectid + "' , amount ='" + amount+ "' where expance_id='" + expenseid+"'   ");
                LBLmsg.Text = " teachers Updated seccessfully!";
                LBLmsg.CssClass = "alert alert-success";
                GridView1.EditIndex = -1;
                getexpence();
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
                    DataTable dt1 = fn.fatch(@"select e.expense_id,e.subject_id,e.class_id from expense e  inner join subject s on e.subject_id=s.subject_id where e.expense_id='" + expenceid + "' ");
                    ddlsubjectgv.SelectedValue = dt1.Rows[0]["expense_id"].ToString();


                }
            }
        }
    }
}