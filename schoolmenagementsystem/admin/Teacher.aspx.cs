using schoolmenagementsystem.Models;
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
    public partial class Teacher : System.Web.UI.Page
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
                getteacher();
            }
           
         }

        private void getteacher()
        {
            DataTable dt = fn.fatch("select ROW_NUMBER() over (order by (select 1)) as[sr.no], teacher_id,[teacher_name],[dob],[mobile],[email],[password],[address] from teacher  ");
                GridView1.DataSource = dt;
                GridView1.DataBind();
        }

        protected void btnAdd_Click1(object sender, EventArgs e)
        {
            try
            {
                if(ddlgender1.SelectedValue !=  "0")
                {  string emailadd =txtemail1.Text.Trim();
                    DataTable dt = fn.fatch(" select * from teacher  where email='"+emailadd+"'");
                    string classval = ddlgender1.SelectedValue;
                    if (dt.Rows.Count==0 )      
                    {
                       string query ="insert into teacher values('" + txtname1.Text.Trim() + "','" + txtdob1.Text.Trim() +"' ,'"+  txtmobile1.Text.Trim()+ "','"+  txtemail1.Text.Trim()+ "','"+txtpassword1.Text.Trim()+"','" +  txtaddress1.Text.Trim()+ "','"+ ddlgender1.SelectedValue+"' ) ";
                        fn.Query(query);
                        LBLmsg.Text = " inserted seccessfully!";
                        LBLmsg.CssClass = "alert alert_success";
                      
                        txtname1.Text = string.Empty;
                        txtdob1.Text = string.Empty;
                        txtmobile1.Text = string.Empty;
                        txtemail1.Text = string.Empty;
                        txtaddress1.Text = string.Empty;
                        txtpassword1.Text = string.Empty;
                        ddlgender1.SelectedIndex = 0;
                        getteacher();

                    }
                    else
                    {

                        LBLmsg.Text = "Entered <b> '" + emailadd + "'</b> already exists!";
                        LBLmsg.CssClass = "alert alert_danger";

                    }

                }
                else
                {

                    LBLmsg.Text = "gender is required !";
                    LBLmsg.CssClass = "alert alert_danger";


                }
            }
            catch(Exception ex) 
            {

                Response.Write("<script>alert('" + ex.Message + "');</script>");
            } 
             
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {GridView1.PageIndex=e.NewPageIndex;
            getteacher();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int teacher_id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);
            fn.Query("delete from teacher where teacher_id='" + teacher_id + "'");
            LBLmsg.Text = " teacher Deleted seccessfully!";
            LBLmsg.CssClass = "alert alert_success";
            GridView1.EditIndex = -1;
            getteacher();

        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex=e.NewEditIndex;
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                GridViewRow row = GridView1.Rows[e.RowIndex];
                int teacher_id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);
                string name = (row.FindControl("TextBox1") as TextBox).Text;
                string dob = (row.FindControl("TextBox2") as TextBox).Text;
                string mobile = (row.FindControl("TextBox3") as TextBox).Text;
                string email = (row.FindControl("TextBox4") as TextBox).Text;
                string password = (row.FindControl("TextBox5") as TextBox).Text;
                string address = (row.FindControl("TextBox6") as TextBox).Text;
                fn.Query("update teacher set teacher_name ='" + name+ "', dob ='" + dob + "' , mobile ='" + mobile + "' , email ='" +email + "', password ='" + password+ "', address='" +address+ "'  where teacher_id='" + teacher_id + "' ");
                LBLmsg.Text = " teachers Updated seccessfully!";
                LBLmsg.CssClass = "alert alert_success";
                GridView1.EditIndex = -1;
                getteacher();
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