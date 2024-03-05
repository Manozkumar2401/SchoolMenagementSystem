using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static schoolmenagementsystem.Models.Commanfn;

namespace schoolmenagementsystem.Teacher
{
    public partial class StudentAttendanceDetails : System.Web.UI.Page
    {
        Commanfnx fn = new Commanfnx();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["staff"] == null)
            {
                Response.Redirect("../Login.aspx");
            }
        }
    }
}