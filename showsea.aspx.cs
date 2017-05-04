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

public partial class showsea : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
            string connectionString = ConfigurationManager.ConnectionStrings["lijunConnectionString"].ConnectionString;
            SqlConnection cnn = new SqlConnection(connectionString);
            string st = "select * from Class where classid=7";
            cnn.Open();
            SqlCommand cmd = new SqlCommand(st, cnn);
            SqlDataReader rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                this.Label1.Text = Server.HtmlDecode(rdr["content"].ToString());
                cnn.Close();
            }
            //if (UrlIsExist("http://facebook.com/"))
            //{
            //    google.Visible = true;
            //    google.Disabled = false;
            //    baidu.Visible = false;
            //    baidu.Disabled = true;
            //}
            //else
            //{
            google.Visible = false;
            google.Disabled = true;
            baidu.Visible = true;
            baidu.Disabled = false;
            //}
        
    }


    //private bool UrlIsExist(String url)
    //{
    //    System.Uri u = null;
    //    try
    //    {
    //        u = new Uri(url);
    //    }
    //    catch { return false; }
    //    bool isExist = false;
    //    System.Net.HttpWebRequest r = System.Net.HttpWebRequest.Create(u) as System.Net.HttpWebRequest;
    //    r.Method = "HEAD";
    //    r.Timeout = 2000;
    //    try
    //    {
    //        System.Net.HttpWebResponse s = r.GetResponse() as System.Net.HttpWebResponse;
    //        if (s.StatusCode == System.Net.HttpStatusCode.OK)
    //        {
    //            isExist = true;
    //        }
    //    }
    //    catch (System.Net.WebException x)
    //    {
    //        try
    //        {
    //            isExist = ((x.Response as System.Net.HttpWebResponse).StatusCode != System.Net.HttpStatusCode.NotFound);
    //        }
    //        catch { isExist = (x.Status == System.Net.WebExceptionStatus.Success); }
    //    }
    //    return isExist;
    //}  
}
