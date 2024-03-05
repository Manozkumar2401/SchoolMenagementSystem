using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace schoolmenagementsystem.admin
{
    public partial class Addclass1 : System.Web.UI.Page
    {
        string query;
        SqlConnection con = new SqlConnection("server=MANOZKUMAR2401\\SQLEXPRESS01; initial catalog=scls; integrated security=true");
        DataTable dt = new DataTable();
        SqlDataAdapter adp;
        SqlCommandBuilder cb;

        protected void Page_Load(object sender, EventArgs e)
        {
            //query = "select Row_NUMBER() over(order by (select 1)) as[sr.no]  ,Classid,classname from class ";
            //SqlDataAdapter adp = new SqlDataAdapter(query, con);
            //adp.Fill(dt);
            //SqlCommandBuilder cb = new SqlCommandBuilder(adp);
            //if (!IsPostBack)
            //{
            //    GridView1.DataSource = dt;
            //    GridView1.DataBind();
            //}
            query = "select * from class";
            adp = new SqlDataAdapter(query, con);
            adp.Fill(dt);
            cb = new SqlCommandBuilder(adp);
            if (!IsPostBack)
            {
                Bind();
            }

        }
        private void Bind()
        {
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

            DataRow[] dr = dt.Select("class_id=" + Convert.ToInt32(GridView1.Rows[e.RowIndex].Cells[0].Text));
            dr[0][1] = ((TextBox)GridView1.Rows[e.RowIndex].Cells[1].Controls[0]).Text;

            adp.Update(dt);
            GridView1.EditIndex = -1;
            Bind();
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            Bind();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {

            GridView1.EditIndex = -1;
            Bind();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            DataRow[] dr = dt.Select("class_id=" + Convert.ToInt32(GridView1.Rows[e.RowIndex].Cells[0].Text));
            dr[0].Delete();
            adp.Update(dt);
            Bind();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {

            if (dt.Rows.Count >= 0)
            {
                query = ("insert into class values (@class_name)");
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.AddWithValue("@class_name", txtclass1.Text);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('seved recored')</script>");
                LBLmsg.Text = " inserted seccessfully!";
                LBLmsg.CssClass = "alert alert-success";
                Response.Redirect("../Admin/AddClass1.aspx");
            }
            else
            {
                LBLmsg.Text = "alredy class exist ";
                LBLmsg.CssClass = "alert alert_danger";
            }

           

        }
    }
}