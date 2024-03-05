using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using static schoolmenagementsystem.Models.Commanfn;

namespace schoolmenagementsystem
{
    public partial class addfees1 : System.Web.UI.Page
    {
        //protected void Page_Load(object sender, EventArgs e)
        //{
        //    if (!IsPostBack)
        //    {
        //        getclass();
        //    }

        //}
        //private void getclass()
        //{

        //}

        //protected void btnAdd_Click(object sender, EventArgs e)
        //{

        //}
        //SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["manoj1"].ConnectionString);
        //SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["manoj"].ConnectionString);

        string query;
        SqlConnection con = new SqlConnection("server=MANOZKUMAR2401\\SQLEXPRESS01; initial catalog=scls; integrated security=true");
        DataTable dt = new DataTable();
        SqlDataAdapter adp;
        SqlCommandBuilder cb;
        Commanfnx fn = new Commanfnx();
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
            ddlclass1.DataTextField = "class_id";
            ddlclass1.DataBind();
            ddlclass1.Items.Insert(0, "select class");
        }

        private void Bind()
        {

        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string classval = ddlclass1.SelectedItem.Text;

                DataTable dt = fn.fatch("select * from fees where class_id='" + ddlclass1.SelectedItem.Value + "'");
                if (dt.Rows.Count == 0)
                {
                    string query = "insert into class values ('" + ddlclass1.SelectedItem.Value + "','" + feeamounts1.Text.Trim() + "')";
                    fn.Query(query);
                    LBLmsg.Text = " inserted seccessfully!";
                    LBLmsg.CssClass = "alert alert_success";
                    ddlclass1.SelectedIndex = 0;
                    feeamounts1.Text = string.Empty;
                    getfees();

                }
                else
                {

                    LBLmsg.Text = "alredy class exist<b> '" + classval + "' ";
                    LBLmsg.CssClass = "alert alert_danger";
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");

            }


        }

        private void getfees()
        {
            DataTable dt = fn.fatch("select * from fees");
            GridView1.DataSource = dt;
            GridView1.DataBind();

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
    
