using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static schoolmenagementsystem.Models.Commanfn;

namespace schoolmenagementsystem.admin
{
    public partial class addclass : System.Web.UI.Page
    {
        Commanfnx fn = new Commanfnx();
        string query;
        SqlConnection con = new SqlConnection("server=MANOZKUMAR2401\\SQLEXPRESS01; initial catalog=scls; integrated security=true");
        DataTable dt = new DataTable();
        SqlDataAdapter adp;
        SqlCommandBuilder cb;

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
            // query = "select * from class";
            //query = "select Row_NUMBER() over(order by (select 1)) as[sr.no],Class_id,class_name from class ";
            //adp = new SqlDataAdapter(query, con);
            //adp.Fill(dt);
            //cb = new SqlCommandBuilder(adp);

            //if (!IsPostBack)
            //{
            //    Bind();
            //}
            if (!IsPostBack)
            {
                Getclass();
                //  Getclass1();


            }


        }
        private void Bind()
        {
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
        private void Getclass()
        {
            DataTable dt = fn.fatch("select Row_NUMBER() over(order by (select 1)) as[sr.no], Class_id,class_name from class");
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
        //private void Getclass1()
        //{
        //    query = "select Row_NUMBER() over(order by (select 1)) as[sr.no],Class_id,class_name from class ";
        //    adp = new SqlDataAdapter(query, con);
        //   DataTable dt1 = new DataTable();
        //    adp.Fill(dt);
        //    cb = new SqlCommandBuilder(adp);
        //    GridView2.DataSource = dt1;
        //    GridView2.DataBind();
        //}

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = fn.fatch(" select * from class where class_name= '" + txtclass.Text.Trim() + "'");
                if (dt.Rows.Count == 0)
                {
                    string query = "insert into class(class_name) values('" + txtclass.Text.Trim() + "')";
                    fn.Query(query);
                    LBLmsg.Text = " inserted seccessfully!";
                    LBLmsg.CssClass = "alert alert-success";
                    txtclass.Text = string.Empty;
                    Getclass();
                }
                else
                {
                    LBLmsg.Text = "alredy class exist ";
                    LBLmsg.CssClass = "alert alert-danger";
                }

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
            }



        }

        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void GridView2_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

            int class_id = Convert.ToInt32(((Literal)GridView1.Rows[e.RowIndex].FindControl("literal1")).Text);
            fn.Query("delete from class where class_id='" + class_id + "'");
            LBLmsg.Text = " student Deleted seccessfully!";
            LBLmsg.CssClass = "alert alert_success";
            GridView1.EditIndex = -1;
            Getclass();

        }

        protected void GridView2_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            Getclass();
        }

        protected void GridView2_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            Getclass();
        }

        protected void GridView2_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {


            //DataRow[] dr = dt.Select("class_id=" + Convert.ToInt32(((Literal)GridView2.Rows[e.RowIndex].FindControl("Literal2")).Text));
            //dr[0][1] = ((TextBox)GridView2.Rows[e.RowIndex].FindControl("Textbox1")).Text;
            //cb = new SqlCommandBuilder(adp);
            //adp.Update(dt);

            //GridView2.EditIndex = -1;
            //Bind();


            try
            {
                GridViewRow row = GridView1.Rows[e.RowIndex];
                int class_id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);
                string name = (row.FindControl("TextBox1") as TextBox).Text;


                fn.Query("update class set class_name ='" + name + "' where class_id='" + class_id + "' ");
                LBLmsg.Text = " teachers Updated seccessfully!";
                LBLmsg.CssClass = "alert alert_success";
                GridView1.EditIndex = -1;
                Getclass();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
            }
        }
        protected void Timer1_Tick(object sender, EventArgs e)
        {
            lbltimer.Text = DateTime.Now.ToString();
        }

        
    }
}
