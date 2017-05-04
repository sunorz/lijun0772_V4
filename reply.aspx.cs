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


public partial class reply : System.Web.UI.Page
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
            Ismid();
            string mid = Request.QueryString["mid"];
            if (!Ismid())
            {
                Response.Write("<script type='text/javascript'>alert('没有这条信息！');window.opener=null;window.open('','_self');window.close();</script>");
            }
        }
    }
    protected void btnLogout_click(object sender, ImageClickEventArgs e)
    {
        Session["issuper"] = null;
        Session["suadmin"] = null;
        Response.Write("<script type='text/javascript'>window.location.href='Default.aspx';</script>");

    }
    //更新
    protected void btnInsert_Click(object sender, ImageClickEventArgs e)
    {
        string mid = Request.QueryString["mid"];
        string replys = txtreply.Text.Trim();
        DateTime dt = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.Now, "China Standard Time");//转东八区
        string st;
        if (replys == "")
        {
            st = "update Mess set reply=null,retime='" + @dt + "' where pid='" + @mid + "'";
        }
        else
        {
            st = "update Mess set reply='" + @replys + "',retime='" + @dt + "' where pid='" + @mid + "'";
        }
        string connectionString = ConfigurationManager.ConnectionStrings["lijunConnectionString"].ConnectionString;
        SqlConnection cnn = new SqlConnection(connectionString);        
        cnn.Open();
        SqlCommand cmd = new SqlCommand(st, cnn);
        cmd.ExecuteNonQuery();
        cnn.Close();
        Response.Redirect("cntmgr.aspx");


    }
    //清除按钮
    protected void btnReset_click(object sender, ImageClickEventArgs e)
    {
        txtreply.Text = "";
    }


    protected void btnBack_click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("cntmgr.aspx");
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
    private bool Ismid()
    {
        string mid = Request.QueryString["mid"];
        string connectionString = ConfigurationManager.ConnectionStrings["lijunConnectionString"].ConnectionString;
        SqlConnection cnn = new SqlConnection(connectionString);
        string st = "select * from Mess,Guest where Mess.gid=Guest.guid and  pid='" + @mid + "'";
        cnn.Open();
        SqlCommand cmd = new SqlCommand(st, cnn);
        SqlDataReader rdr = cmd.ExecuteReader();
        if (!rdr.Read())
        {
            cnn.Close();
            return false;
        }
        else
        {
            lbuser.Text = Encryption.Decode(rdr["gname"].ToString());
            lbliuyan.Text = Encryption.Decode(rdr["pcontent"].ToString());
            if (rdr["reply"].ToString().Trim() == "")
            {
                lbhuifu.Text = "（暂无回复！）";
                btnCeuser.Visible = false;
            }
            else
            {
                lbhuifu.Text = rdr["reply"].ToString();
            }
            cnn.Close();
            return true;

        }


    }

    protected void btnCeuser_Click(object sender, EventArgs e)
    {
        string mid = Request.QueryString["mid"];
        string connectionString = ConfigurationManager.ConnectionStrings["lijunConnectionString"].ConnectionString;
        SqlConnection cnn = new SqlConnection(connectionString);
        string st = "update Mess set reply=null,retime=null where pid='" + @mid + "'";
        cnn.Open();
        SqlCommand cmd = new SqlCommand(st, cnn);
        cmd.ExecuteNonQuery();
        cnn.Close();
        Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script type='text/javascript'>alert(删除成功！');</script>");
        Ismid();

    }
   
}
