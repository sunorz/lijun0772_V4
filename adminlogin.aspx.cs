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

public partial class adminlogin : System.Web.UI.Page
{
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["issuper"] == null || Session["ispwd"] == null)
        {
           
        }
        else if (WebHelp.Auth(Session["issuper"].ToString(), Session["ispwd"].ToString()) == false)
        {

        }

        else
        {
            Response.Redirect("adminweb.aspx");
        }
        footerload();
    }
	protected void btnLogin_click(object sender,ImageClickEventArgs e)
	{
        string adname =Encryption.Encode(admin.Text.Trim());
        string adpwd = Encryption.Auth(pwd.Text);
        if (adname.Trim() == "")
        {
            aptips.InnerText = "请输入用户名！ ";

        }
        else if (adpwd.Trim() == "")
        {
            aptips.InnerText = "请输入密码！";

        }
        else
        {
            string connectionString = ConfigurationManager.ConnectionStrings["lijunConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(connectionString);
            string st = "select * from Admin where adname='" + @adname + "'and adpwd='" + @adpwd + "'";
            con.Open();
            SqlCommand cmd = new SqlCommand(st, con);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                Session["issuper"] = reader["adname"].ToString();
                Session["ispwd"] = reader["adpwd"].ToString();
                Session["suadmin"] = reader["suadmin"].ToString();
                con.Close();
                Response.Redirect("adminweb.aspx");
               }
            else
            {
                Response.Write("<script type='text/javascript'>alert('请检查您输入的用户名和密码！');window.location.href='adminlogin.aspx';</script>");
                con.Close();
            }
        }
       
	}

	protected void btnReset_click(object sender,ImageClickEventArgs e)
	{
		admin.Text="";
        pwd.Text = "";
	}

    protected void btnForget_Click(object sender, EventArgs e)
    {
        Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script type='text/javascript'>window.open('forget.aspx');</script>");
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
            this.Label1.Text = Server.HtmlDecode(rdr["content"].ToString());
            cnn.Close();
        }
    }
}

    
         

