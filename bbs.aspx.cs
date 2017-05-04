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
using System.Threading;

public partial class bbs: System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bind2();
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

            DateTime dt = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.Now, "China Standard Time");
            Calendar1.TodaysDate = dt;
        }
    }
   private void bind2()
    {
        string bdsql = "select * from Album where alid<>3 and islock='false'";
        string connectionString = ConfigurationManager.ConnectionStrings["lijunConnectionString"].ConnectionString;
        SqlConnection conur = new SqlConnection(connectionString);
        SqlDataAdapter cmdu = new SqlDataAdapter(bdsql, conur);
        DataSet myds = new DataSet();
        conur.Open();
        cmdu.Fill(myds, "Ablum");
        gvabl.DataSource = myds;
        gvabl.DataKeyNames = new string[] { "alid" };
        gvabl.DataBind();
        conur.Close();
    }

     protected void Calendar1_PreRender(object sender, EventArgs e)//初始化日历显示语言
   {
       //提供有关特定区域性的信息
       System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("zh-CN", false);
       Thread.CurrentThread.CurrentCulture = culture;
   }
   //缩短
   public string SubStr(object caption, int nLeng)
   {
       string sString = caption.ToString().Trim();
       if (sString.Length <= nLeng)
       {
           return sString;
       }
       else
       {
           string sNewStr = sString.Substring(0, nLeng);
           sNewStr = sNewStr + "..."; return sNewStr;
       }
   }
}
