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


public partial class newpost : System.Web.UI.Page
{
    //载入
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["issuper"] == null || Session["ispwd"] == null)
        {
            Response.Write("<script type='text/javascript'>alert('登录超时！');window.location.href='Default.aspx';</script>");
        }
        else if (WebHelp.Auth(Session["issuper"].ToString(), Session["ispwd"].ToString()) == false)
        {
            Response.Write("<script type='text/javascript'>alert('登录超时！');window.location.href='Default.aspx';</script>");
        }

        else
        {
            this.Label1.Text = "欢迎管理员：" + Encryption.Decode(Session["issuper"]);
            footerload();
        }
    }
    protected void btnLogout_click(object sender, ImageClickEventArgs e)
    {
        Session["issuper"] = null;
        Session["suadmin"] = null;
        Response.Write("<script type='text/javascript'>window.location.href='Default.aspx';</script>");

    }

    protected void btnInsert_Click(object sender, ImageClickEventArgs e)
    {
        string tcontent = this.content.Text;
        string title = tbtitle.Text;
        string poster = tbposter.Text;
        if (title == "")
        {
            aptips.InnerText = "请输入标题！ ";

        }
        else if (poster == "")
        {
            aptips.InnerText = "请输入作者！";

        }
        else
        {
            if(cktitle(title)==true)
            {
            string connectionString = ConfigurationManager.ConnectionStrings["lijunConnectionString"].ConnectionString;
            SqlConnection cnn = new SqlConnection(connectionString);
            DateTime dt = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.Now, "China Standard Time");//转东八区
            string st = "insert into Article(artitle,artmkr,arttime,artcnt) values('" + @title + "','" + @poster + "','"+@dt+"','" + @tcontent + "') ";
            SqlCommand cmd = new SqlCommand(st, cnn);
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script type='text/javascript'>alert('发表成功！');</script>");
            tbtitle.Text = "";
            tbposter.Text = "";
            aptips.InnerText = "";
            this.content.Text = "";          
            }
        }

    }
    //清除按钮
    protected void btnReset_click(object sender, ImageClickEventArgs e)
    {
        tbtitle.Text = "";
        tbposter.Text = "";
        aptips.InnerText = "";
    }
    protected void btnBack_click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("postmgr.aspx");
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
    protected bool cktitle(string title)
    {
        string connectionString = ConfigurationManager.ConnectionStrings["lijunConnectionString"].ConnectionString;
        SqlConnection cnn = new SqlConnection(connectionString);
        string st = "select * from Article where artitle='"+@title+"'";
        cnn.Open();
        SqlCommand cmd = new SqlCommand(st, cnn);
        SqlDataReader rdr = cmd.ExecuteReader();
        if (rdr.Read())
        {
            aptips.InnerText = "这篇文章已存在！";
            cnn.Close();
            return false;
        }
        else
        {
            return true;
        }
    }
}
