using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static schoolmenagementsystem.Models.Commanfn;
using System.Web.Configuration;

namespace schoolmenagementsystem.admin
{
   
    public partial class addfees : System.Web.UI.Page
    {



        SqlCommand cmd = new SqlCommand();
        string query;
        SqlConnection con = new SqlConnection("server=MANOZKUMAR2401\\SQLEXPRESS01; initial catalog=scls; integrated security=true");
        DataTable dt = new DataTable();
        SqlDataAdapter adp;
        SqlCommandBuilder cb;
        Commanfnx fn = new Commanfnx();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                getclass();
                getfees();
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


        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                int classval = Convert.ToInt32(ddlclass1.SelectedItem.Value);
                query = "select * from fees where class_id=@classid ";
                cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@classid", classval);

                adp = new SqlDataAdapter(cmd);
                dt = new DataTable();
                adp.Fill(dt);
                if (dt.Rows.Count == 0)
                {

                    query = "insert into fees values ('" + ddlclass1.SelectedItem.Value + "','" + txtfeeamount1.Text.Trim() + "')";
                    cmd = new SqlCommand(query, con);
                   // cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@classid", ddlclass1.SelectedItem.Value);
                    cmd.Parameters.AddWithValue("@feeamount", txtfeeamount1.Text.Trim());
                    adp = new SqlDataAdapter(cmd);
                    adp.Fill(dt);
                    LBLmsg.Text = " inserted seccessfully!";
                    LBLmsg.CssClass = "alert alert-success";
                    ddlclass1.SelectedIndex = 0;
                    txtfeeamount1.Text = string.Empty;
                    getfees();




                }
                else
                {

                    LBLmsg.Text = "alredy fees exist<b> '" + classval + "' ";
                    LBLmsg.CssClass = "alert alert-danger";
                }




            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");

            }


        }

        private void getfees()
        {
            query = "_getfees";

            cmd = new SqlCommand(query, con);
            adp = new SqlDataAdapter(cmd);
            dt = new DataTable();
            adp.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            getfees();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            getfees();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

            int fees_id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);
            fn.Query("delete from fees where fees_id='" + fees_id + "'");
            LBLmsg.Text = " Fees Deleted seccessfully!";
            LBLmsg.CssClass = "alert alert-success";
            GridView1.EditIndex = -1;
            getfees();

        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {

            GridView1.EditIndex = e.NewEditIndex;

            getfees();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                GridViewRow row = GridView1.Rows[e.RowIndex];
                int fees_id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);
                string feeAmt = (row.FindControl("TextBox1") as TextBox).Text;
                fn.Query("update Fees set Fee_amount ='" + feeAmt + "' where fees_id='" + fees_id + "' ");
                LBLmsg.Text = " Fees Updated seccessfully!";
                LBLmsg.CssClass = "alert alert-success";
                GridView1.EditIndex = -1;
                getfees();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
            }

        }
    }
    }
    
