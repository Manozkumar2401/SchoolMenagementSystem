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
    public partial class Student : System.Web.UI.Page
    {
        Commanfnx fn = new Commanfnx();
        protected void Page_Load(object sender, EventArgs e)
        {
          //  if (Session["admin"] == null)
            {
           //     Response.Redirect("../Login.aspx");
            }
           if (!IsPostBack)
            {
               getclass();
                getstudent();

            }

        }

        private void getstudent()
        {
            DataTable dt = fn.fatch("select ROW_NUMBER() over (order by (select 1)) as[sr.no], s.student_id,s.[student_name] ,s.[student_father_name],s.[dob],s.[mobile],s.[roll_no],s.[address],c.class_id,c.class_name from student s inner join Class c on c.class_id=s.class_id  ");
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (ddlgender1.SelectedValue != "0")
                {
                    string rollno = txtrollno1.Text.Trim();
                    DataTable dt = fn.fatch(" select * from student where class_id='" + ddlclass1.SelectedValue + "' and roll_no='" + rollno + "'");
                    string classval = ddlgender1.SelectedValue;
                    if (dt.Rows.Count == 0)
                    {
                        string query = "insert into student values('" + txtname1.Text.Trim() + "','" + txtfather1.Text.Trim() + "','" + txtdob1.Text.Trim() + "','" + ddlgender1.SelectedValue + "' ,'" + txtmobile1.Text.Trim() + "','" + txtrollno1.Text.Trim() + "','" + txtaddress1.Text.Trim() + "','" + ddlclass1.SelectedValue + "' ) ";
                        fn.Query(query);
                        LBLmsg.Text = " inserted seccessfully!";
                        LBLmsg.CssClass = "alert alert_success";
                        txtname1.Text = string.Empty;
                        txtfather1.Text = string.Empty;
                        txtdob1.Text = string.Empty;
                        ddlgender1.SelectedIndex = 0;
                        txtmobile1.Text = string.Empty;
                        txtrollno1.Text = string.Empty;
                        txtaddress1.Text = string.Empty;
                        txtrollno1.Text = string.Empty;
                        ddlgender1.SelectedIndex = 0;
                        getstudent();
                    }
                    else
                    {

                        LBLmsg.Text = "Entered Roll No.<b> '" + rollno + "'</b> already exists for selected class'" + ddlclass1.SelectedItem.Text.Trim() + "'!";
                        LBLmsg.CssClass = "alert alert_danger";

                    }
                }
                else
                {

                    LBLmsg.Text = "gender is required !";
                    LBLmsg.CssClass = "alert alert_danger";
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
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

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            getstudent();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            getstudent();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int student_id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);
            fn.Query("delete from student where student_id='" + student_id + "'");
            LBLmsg.Text = " student Deleted seccessfully!";
            LBLmsg.CssClass = "alert alert_success";
            GridView1.EditIndex = -1;
            getstudent();

        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            getstudent();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                GridViewRow row = GridView1.Rows[e.RowIndex];
                int student_id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);
                string name = (row.FindControl("TextBox1")   as TextBox).Text;
                string fname = (row.FindControl("TextBox2")  as TextBox).Text;  
                string dob = (row.FindControl("TextBox3")    as TextBox).Text;
                string mobile = (row.FindControl("TextBox4") as TextBox).Text;
                string rollno = (row.FindControl("TextBox5") as TextBox).Text;
                
                string address = (row.FindControl("TextBox6") as TextBox).Text;
                string classid = ((DropDownList)GridView1.Rows[e.RowIndex].Cells[7].FindControl("ddlclassg")).SelectedValue;

                fn.Query("update student set student_name ='" + name + "',student_father_name ='" +fname+ "', dob ='" + dob + "' , mobile ='" + mobile + "' , roll_no ='" + rollno + "',address='" + address + "' ,class_id='" +classid+ "' where student_id='" + student_id+ "' ");
                LBLmsg.Text = " teachers Updated seccessfully!";
                LBLmsg.CssClass = "alert alert-success";
                GridView1.EditIndex = -1;
                getstudent();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
            }

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

