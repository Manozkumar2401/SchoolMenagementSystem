using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;        
using System.Web;
using System.Web.Configuration;

namespace schoolmenagementsystem.Models
{
    public class Commanfn
    {
         public class Commanfnx
         {
            SqlConnection con = new SqlConnection("server=MANOZKUMAR2401\\SQLEXPRESS01; initial catalog=scls; integrated security=true");

            public void Query(string query)
            {
                if(con.State == ConnectionState.Closed) 
                {
                con.Open();
                }
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                con.Close();

            }
            public DataTable fatch(string query)
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                return dt;

            }

            internal DataTable fatch(object value)
            {
                throw new NotImplementedException();
            }
        }
    }
}