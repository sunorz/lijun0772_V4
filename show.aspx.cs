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

public partial class show : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            footerload();

        }
    }

    protected void footerload()
    {
        string connectionString = ConfigurationManager.ConnectionStrings["lijunConnectionString"].ConnectionString;
        SqlConnection cnn = new SqlConnection(connectionString);
        string st = "select * from Class where classid=7";
        cnn.Open();
        SqlCommand cmd = new SqlCommand(st, cnn);
        SqlDataReader rdr = cmd.ExecuteReader();
        if (rdr.Read())
        {
            this.Label3.Text = Server.HtmlDecode(rdr["content"].ToString());
            cnn.Close();
        }
    }    
    protected string getItems()
    {
       //获取数据库图片
        StringBuilder sb = new StringBuilder();
        string connectionString = ConfigurationManager.ConnectionStrings["lijunConnectionString"].ConnectionString;
        SqlConnection cnn = new SqlConnection(connectionString);
        string st = "select * from Photo where alid=3 order by poid desc";
        cnn.Open();
        SqlDataAdapter adp = new SqlDataAdapter(st, cnn);
        DataSet ds = new DataSet();
        adp.Fill(ds, "honour");
        DataTable dt = ds.Tables["honour"];
        int rowcount = dt.Rows.Count;
        if (rowcount == 0)
        {
            sb.Append("<li><img src=\"imgs/nopic.jpg\" width=\"588\" height=\"425\" /><br />暂时没有图片~</li>  ");  
        }
        else
        {

            for (int i = 0; i < rowcount; i++)
            {
                string name = dt.Rows[i]["poname"].ToString();
                string pourl = dt.Rows[i]["pourl"].ToString().Replace("~/imgs", "imgs");
                sb.Append("<li><img src=\"" + pourl + "\" width=\"588\" height=\"425\" /><br />" + name + "</li>  ");
            }


            cnn.Close();
        }

        return sb.ToString();

    }

}

