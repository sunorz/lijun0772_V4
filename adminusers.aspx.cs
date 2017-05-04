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


public partial class adminusers : System.Web.UI.Page
{
	//载入
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["issuper"] == null || Session["ispwd"] == null)
        {
            Response.Write("<script type='text/javascript'>alert('登录超时！');window.location.href='Default.aspx';</script>");
        }
        else if (WebHelp.Auth(Session["issuper"].ToString(), Session["ispwd"].ToString())==false)
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
        string txtname =Encryption.Encode(yhm.Text.Trim());
        string txtpwd = Encryption.Auth(mima.Text.Trim());
        string txtcfpwd = Encryption.Auth(mimaqu.Text.Trim());
        string txtylyx = Encryption.Encode(ylyx.Text.Trim());
        int chaoji = 0;
        if (cksuper.Checked == true)
        {
            chaoji = 1;
        }
        if (txtname== "")
        {
            aptips.InnerText = "请输入用户名！ ";

        }
        else if (txtpwd== "")
        {
            aptips.InnerText = "请输入新密码！";

        }
        else if (txtcfpwd== "")
        {
            aptips.InnerText = "请确认新密码！";


        }
        else if (txtpwd != txtcfpwd)
        {
            aptips.InnerText = "两次输入的新密码不一致！";


        }
        else if (!this.isname())//用户名判断函数的调用
        {
            aptips.InnerText = "用户名已存在！";

        }
        else
        {

            string connectionString = ConfigurationManager.ConnectionStrings["lijunConnectionString"].ConnectionString;
            SqlConnection cnn = new SqlConnection(connectionString);
            string st = "insert into Admin(adname,adpwd,suadmin,admail) values('" + @txtname + "','" + @txtpwd + "','" + @chaoji + "','"+@txtylyx+"') ";
            SqlCommand cmd = new SqlCommand(st, cnn);
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script type='text/javascript'>alert('添加成功！');window.location.href=window.location.href; </script>");
            yhm.Text = "";
           
        }
        
    }
    //清除按钮
    protected void btnReset_click(object sender, ImageClickEventArgs e)
    {
        yhm.Text = "";
        mima.Text = "";
        mimaqu.Text = "";
        cksuper.Checked = false;
        aptips.InnerText = "";

    }
//判断用户名、邮箱是否重复
    public bool isname()
    {
        string txtname = Encryption.Encode(yhm.Text.Trim());
        string txtmail = Encryption.Encode(ylyx.Text.Trim());
        string connectionString = ConfigurationManager.ConnectionStrings["lijunConnectionString"].ConnectionString;
        SqlConnection cno = new SqlConnection(connectionString);
        string ftr = "select adname from Admin where adname='" + @txtname + "' or admail='"+@txtmail+"' ";
        cno.Open();
        SqlCommand cmr = new SqlCommand(ftr, cno);
        SqlDataReader cmrd = cmr.ExecuteReader();
        if (cmrd.Read())
        {
            aptips.InnerText = "该用户已存在！";
            cno.Close(); 
            return false;
            
        }
        else
        {
            cno.Close(); 
            return true;            
        }
    }
    protected void btnBack_click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("adminweb.aspx");
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
            this.Label2.Text = Server.HtmlDecode(rdr["content"].ToString());
            cnn.Close();
        }
    }
}
