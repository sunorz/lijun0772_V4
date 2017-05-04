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
using System.Text;
using System.Text.RegularExpressions;

public partial class Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        show();
        string connectionString = ConfigurationManager.ConnectionStrings["lijunConnectionString"].ConnectionString;
        SqlConnection cnn = new SqlConnection(connectionString);
        string st = "select * from Class where classid=7";
        cnn.Open();
        SqlCommand cmd = new SqlCommand(st, cnn);
        SqlDataReader rdr = cmd.ExecuteReader();
        if (rdr.Read())
        {
            string data = rdr["content"].ToString();
            data = data.Replace("&lt;p&gt;&amp;nbsp;&amp;nbsp;", "<br/><br/><br/>");
            this.Label3.Text = Server.HtmlDecode(data);
            cnn.Close();
        }
        swimg();
    }


    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("intro.aspx");
    }

    protected void show()
    {
        string connectionString = ConfigurationManager.ConnectionStrings["lijunConnectionString"].ConnectionString;
        SqlConnection cnn = new SqlConnection(connectionString);
        string st = "select * from Class where classid=1";
        cnn.Open();
        SqlCommand cmd = new SqlCommand(st, cnn);
        SqlDataReader rdr = cmd.ExecuteReader();
        if (rdr.Read())
        {
            cutwords(rdr["content"].ToString());

            cnn.Close();

        }
        else
        {
            intro.InnerText = "";
            cnn.Close();
        }
    }

    protected void cutwords(string data)
    {
        int i;
        int j = 0;
        string data2;
        for (i = 0; i < data.Length; i++)
        {
            if (data.Substring(i, 1) == "¡£" || data.Substring(i, 1) == "£¿")
            {
                j++;

            }
            if (j == 3)
            {
                j = i;
                data2=Server.HtmlDecode(data.Substring(0, j + 1));
                data2=data2.Replace("<p>","    ");
                data2=data2.Replace("</p>","<br/>");
                intro.InnerText = data2;
                break;
            }

        }
        if (j < 3)
        {
            intro.InnerText = Server.HtmlDecode(data).Replace("<p>","    ");
        }
    }
    protected void swimg()//Ö÷Ò³Í¼Æ¬Ëæ»úÏÔÊ¾
    {
            Random rd = new Random();
            string str = "01";
            string result = "";
            for (int i = 0; i < 1; i++)
            {
                result += str[rd.Next(str.Length)];
            }
            if (result == "0")
            {
                Image3.ImageUrl = "imgs/class/cover_v.jpg";
                Image3.Height = 450;
                Image3.Width = 300;
            }
            else
            {
                Image3.ImageUrl = "imgs/class/cover_h.jpg";
                Image3.Height = 300;
                Image3.Width = 450;
            }
    }
    
}
