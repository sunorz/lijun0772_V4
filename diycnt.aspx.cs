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
using System.Drawing;
using System.IO;


public partial class diycnt : System.Web.UI.Page
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

    //文本区的更新
    protected void btnPost_Click(object sender, EventArgs e)
    {
        string id = ddlclasstxt.SelectedValue;
        string title = txttitle.Text;
        string tcontent = this.content.Text;
        if (tcontent == "")
        {
            aptips.InnerText = "请输入内容！";
        }
        else if (title == "")
        {
            aptips.InnerText = "请输入标题！";
        }
        else
        {

            //链接数据库
            aptips.InnerText = "";
            string connectionString = ConfigurationManager.ConnectionStrings["lijunConnectionString"].ConnectionString;
            SqlConnection cnn = new SqlConnection(connectionString);
            string st = "update Class set content='" + @tcontent + "',cltitle='" + @title + "' where classid='" + @id + "'";
            cnn.Open();
            SqlCommand cmd = new SqlCommand(st, cnn);
            cmd.ExecuteNonQuery();
            cnn.Close();
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script type='text/javascript'>alert('更新成功！');</script>");
            content.Text = "";
        }
    }
 
    protected void btnReset_Click(object sender, EventArgs e)
    {
        content.Text = "";
        aptips.InnerText = "";
            }
   
    protected void btnPost2_Click(object sender, EventArgs e)
    {
        string footer = tbfooter.Text;
        if (footer == "")
        {
            aptips3.InnerText = "请输入内容！";
        }
        else
        {
            //预处理文本
            string str = "";
            str = this.tbfooter.Text;  //把TextBox中的内容先赋给str，再做处理
            str = str.Replace("\r\n", "<p>&nbsp;&nbsp;");
            str = str.Replace("\n", "<p>&nbsp;&nbsp;");
            str = str.Replace(" ", "&nbsp;");
            footer = Server.HtmlEncode(str);
            //链接数据库
            aptips.InnerText = "";
            string connectionString = ConfigurationManager.ConnectionStrings["lijunConnectionString"].ConnectionString;
            SqlConnection cnn = new SqlConnection(connectionString);
            string st = "update Class set content='" + @footer + "' where classid=7";
            cnn.Open();
            SqlCommand cmd = new SqlCommand(st, cnn);
            cmd.ExecuteNonQuery();
                            cnn.Close();
                Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script type='text/javascript'>alert('更新成功！');</script>");
                tbfooter.Text = "";
                aptips3.InnerText = "";
                footerload();           
          
        }

    }
    protected void btnRsst_Click(object sender, EventArgs e)
    {
        tbfooter.Text = "";
        aptips3.InnerText = "";
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


    protected void btnBack_click(object sender, ImageClickEventArgs e)
    {
        Response.Write("<script type='text/javascript'>window.location.href='adminweb.aspx';</script>");
    }
}

