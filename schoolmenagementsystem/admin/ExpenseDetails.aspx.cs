using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static schoolmenagementsystem.Models.Commanfn;

namespace schoolmenagementsystem 
{
    public partial class ExpenseDetails : System.Web.UI.Page
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
                getexpensedetails();
            }

        }

        private void getexpensedetails()
        {
            DataTable dt = fn.fatch("select Row_NUMBER() over(order by (select 1)) as [sr.no],expance_id,e.class_id,c.class_name,e.subject_id,s.subject_name , e.amount from expance e  inner join class c on e.class_id=c.class_id inner join subject s on e.subject_id=s.subject_id ");
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
    }
}