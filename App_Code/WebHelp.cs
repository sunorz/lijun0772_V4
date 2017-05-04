using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Collections.Generic;
using System.Data.SqlClient;

/// <summary>
///WebHelp 的摘要说明
/// </summary>
public class WebHelp
{
    public static bool Auth(string user, string password)
    {
            string connectionString = ConfigurationManager.ConnectionStrings["lijunConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(connectionString);
            string st = "select * from Admin where adname='" + @user + "' and adpwd='" + @password + "'";
            con.Open();
            SqlCommand cmd = new SqlCommand(st, con);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                return true;

            }
            else
            {
                return false;
            }
        
    }
}
