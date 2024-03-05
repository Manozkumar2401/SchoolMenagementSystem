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
    public partial class Subject : System.Web.UI.Page
    {
        Commanfnx fn = new Commanfnx();
        //SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["manoj"].ConnectionString);
        string query;
        //SqlConnection con1 = new SqlConnection("server=MANOZKUMAR2401\\SQLEXPRESS; initial catalog=scls; integrated security=true");
        //DataTable dt1 = new DataTable();
        //SqlDataAdapter adp;
        //SqlCommandBuilder cb;

        //SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["manoj"].ConnectionString);

        //string query;
        ////SqlConnection con = new SqlConnection("server=MANOZKUMAR2401\\SQLEXPRESS; initial catalog=scls; integrated security=true");
        //DataTable dt = new DataTable();
        //SqlDataAdapter adp;
        //SqlCommandBuilder cb;

        protected void Page_Load(object sender, EventArgs e)
        {
            //query = "select Row_NUMBER() over(order by (select 1)) as[sr.no]  ,Class_id,class_name from class ";
            //SqlDataAdapter adp = new SqlDataAdapter(query, con);
            //adp.Fill(dt);
            //SqlCommandBuilder cb = new SqlCommandBuilder(adp);
            //if (!IsPostBack)
            //{
            //    GridView1.DataSource = dt;
            //    GridView1.DataBind();
            //}
            //query = "select * from class";
            //adp = new SqlDataAdapter(query, con);
            //adp.Fill(dt);
            //cb = new SqlCommandBuilder(adp);

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
            DataTable dt = fn.fatch( "select * from class");
            ddlclass1.DataSource = dt;
            ddlclass1.DataTextField = "class_name";
            ddlclass1.DataValueField = "class_id";
            ddlclass1.DataBind();
            ddlclass1.Items.Insert(0, "select class");
        }

       
        protected void btnAdd_Click1(object sender, EventArgs e)
        { try
            {
                string classval = ddlclass1.SelectedItem.Text;

                DataTable dt = fn.fatch("select * from subject where class_id='" + ddlclass1.SelectedItem.Value + "' and  subject_name='" + txtsubject1.Text.Trim() + "' ");
                if (dt.Rows.Count ==0)
                {
                    string query = "insert into subject values ('" + ddlclass1.SelectedItem.Value + "','" + txtsubject1.Text.Trim() + "')";
                                
                   fn.Query(query);
                    LBLmsg.Text = " inserted seccessfully!";
                    LBLmsg.CssClass = "alert alert_success";
                    ddlclass1.SelectedIndex = 0;
                    txtsubject1.Text = string.Empty;
                    getsubject();

                }
                else
                {

                    LBLmsg.Text = "alredy subject  exist<b> '"+ classval+"' ";
                    LBLmsg.CssClass= "alert alert_danger";
                }




            }
            catch(Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");

            }


        }

        private void getsubject()
        {
            DataTable dt = fn.fatch(@"select Row_NUMBER() over(order by (select 1)) as[sr.no]
            ,s.subject_id,s.class_id,c.class_name,s.subject_name from subject s inner join class c on c.class_id=s.class_id");

            //DataTable dt = fn.fatch(@"select * from fees");


            GridView1.DataSource= dt;
               GridView1.DataBind();

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            getsubject();

        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            getsubject();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            // DataRow[] dr = dt.Select("fees_id=" + Convert.ToInt32(((Literal)GridView1.Rows[e.RowIndex].FindControl("Label1")).Text));

            //DataRow[] dr = dt1.Select("fees_id=" + Convert.ToInt32(((Label)GridView1.Rows[e.RowIndex].FindControl("Label1")).Text));
            //dr[0].Delete();
            //adp.Update(dt1);
            ////getfees();
            //int fees_id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);
            //fn.Query("delete from subject where subject_id='" + fees_id + "'");
            //LBLmsg.Text = " Fees Deleted seccessfully!";
            //LBLmsg.CssClass = "alert alert_success";
            //GridView1.EditIndex = -1;
            //getsubject();

        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {

            GridView1.EditIndex = e.NewEditIndex;

            getsubject();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                GridViewRow row = GridView1.Rows[e.RowIndex];
                int sub_id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);
                string classid = ((DropDownList)GridView1.Rows[e.RowIndex].Cells[2].FindControl("DropDownList2")).SelectedValue;
                string subjectname=(row.FindControl("TextBox1") as TextBox).Text;
                fn.Query("update subject set class_id ='" + classid + "', subject_name ='" +subjectname + "' where subject_id='" + sub_id + "' ");
                LBLmsg.Text = " subect Updated seccessfully!";
                 LBLmsg.CssClass = "alert alert_success";
                GridView1.EditIndex = -1;
                getsubject();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('"+ ex.Message+"')</script>");
            }

        }

        //    DataTable dt = fn.fatch("select * from fees where class_id='" + ddlclass1.SelectedItem.Value + "'");
        //    if (dt.Rows.Count == 0)
        //    { 
        //        query = ("insert into fees values (@class_name,@fee_amount)");
        //        SqlCommand cmd = new SqlCommand(query, con);   
        //        cmd.CommandType = System.Data.CommandType.Text;
        //        cmd.Parameters.AddWithValue("@class_name", ddlclass1.SelectedItem.Value);
        //        cmd.Parameters.AddWithValue("@fee_amount", txtfeeamount1.Text.Trim());
        //        con.Open();
        //        cmd.ExecuteNonQuery();
        //        ddlclass1.SelectedIndex = 0;
        //        txtfeeamount1.Text = string.Empty;



        //    con.Close();
        //    Response.Write("<script>alert('seved recored')</script>");
        //    LBLmsg.Text = " inserted seccessfully!";
        //    LBLmsg.CssClass = "alert alert_success";
        //}
        //    else
        //    {

        //        LBLmsg.Text = "alredy class exist ";
        //        LBLmsg.CssClass = "alert alert_danger";
        //    }
    }
}