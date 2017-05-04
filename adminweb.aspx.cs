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


public partial class adminweb : System.Web.UI.Page
{
    //载入
    protected void Page_Load(object sender, EventArgs e)
    {
        Button4.Attributes.Add("onclick", " if(!confirm('确认删除选中的用户吗？')) return false;"); 
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
            aptips.InnerText = "";
            footerload();
            if (Session["suadmin"].ToString() == "True")
            {
                this.btnUser.Visible = true;
            }
            else
            {
                this.btnUser.Visible = false;
            }

        }

    }
    //切换用户
    protected void btnSwitch_click(object sender, ImageClickEventArgs e)
    {
        Session["issuper"] = null;
        Session["suadmin"] = null;
        Response.Write("<script type='text/javascript'>window.location.href='adminlogin.aspx';</script>");

    }
    //登出
    protected void btnLogout_click(object sender, ImageClickEventArgs e)
    {
        Session["issuper"] = null;
        Session["suadmin"] = null;
        Response.Write("<script type='text/javascript'>window.location.href='Default.aspx';</script>");

    }
    //修改密码窗口
    protected void Chgpwd_click(object sender, ImageClickEventArgs e)
    {
        string oldpwd = this.oldpwd.Text.Trim();
        string newpwd = this.newpwd.Text.Trim();
        string conf = this.newconf.Text.Trim();
        aptips.InnerText = "";
        if (oldpwd == "")
        {
            aptips.InnerText = "请输入原密码！ ";

        }
        else if (newpwd == "")
        {
            aptips.InnerText = "请输入新密码！";

        }
        else if (conf == "")
        {
            aptips.InnerText = "请确认新密码！";


        }
        else if (newpwd != conf)
        {
            aptips.InnerText = "两次输入的新密码不一致！";


        }
        else if (oldpwd == newpwd)
        {
            aptips.InnerText = "新密码与原密码相同！";

        }
        else
        {

            string connectionString = ConfigurationManager.ConnectionStrings["lijunConnectionString"].ConnectionString;
            SqlConnection cnn = new SqlConnection(connectionString);
            string st = "update Admin set adpwd='" + @conf + "' where adname='" + @Session["issuper"] + "' and adpwd='" + @oldpwd + "'";
            cnn.Open();
            SqlCommand cmd = new SqlCommand(st, cnn);
            int ret = cmd.ExecuteNonQuery();
            if (ret != 0)
            {
                cnn.Close();
                Response.Write("<script type='text/javascript'>alert('修改成功,请重新登录！');</script>");
                Response.Redirect("adminlogin.aspx");
            }
            else
            {
                aptips.InnerText = "原密码输入错误！";
                cnn.Close();
            }
        }
    }
    //清除按钮
    protected void btnReset_click(object sender, ImageClickEventArgs e)
    {
        oldpwd.Text = "";
        newpwd.Text = "";
        newconf.Text = "";
        aptips.InnerText = "";

    }
    //修改密码窗口控制
    protected void btnChgpwd_click(object sender, ImageClickEventArgs e)
    {
        divusers.Visible = false;
        divchgpwd.Visible = true;

    }
    //关闭修改密码窗口
    protected void Cls_click(object sender, ImageClickEventArgs e)
    {
        divchgpwd.Visible = false;
    }
    //关闭用户管理窗口
    protected void Cls2_click(object sender, ImageClickEventArgs e)
    {
        divusers.Visible = false;
    }

    protected void btnGo_Click(object sender, EventArgs e)
    {

    }
    //用户管理窗口控制
    protected void btnUser_Click(object sender, ImageClickEventArgs e)
    {
        divchgpwd.Visible = false;
        bind();
        divusers.Visible = true;
    }

    //新增用户按钮
    protected void btnCeuser_Click(object sender, EventArgs e)
    {
        //用以下代码代替Response.Write()
        Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script type='text/javascript'>window.open('adminusers.aspx');</script>");
    }
    //GridView的绑定
    private void bind()
    {
        string bdsql = "select *,ROW_NUMBER()OVER (order by id) AS rowsid  from Admin where id<>3 and adname<>'" + Session["issuper"] + "'";
        string connectionString = ConfigurationManager.ConnectionStrings["lijunConnectionString"].ConnectionString;
        SqlConnection conur = new SqlConnection(connectionString);
        SqlDataAdapter cmdu = new SqlDataAdapter(bdsql, conur);
        DataSet myds = new DataSet();
        conur.Open();
        cmdu.Fill(myds, "Admin");
        gvuser.DataSource = myds;
        gvuser.DataKeyNames = new string[] { "id" };
        gvuser.DataBind();
        conur.Close();


    }
    //删除操作
    protected void gvuser_RowDele(object sender, GridViewDeleteEventArgs e)
    {

        int id = Convert.ToInt32(gvuser.DataKeys[e.RowIndex].Value);
        string connectionString = ConfigurationManager.ConnectionStrings["lijunConnectionString"].ConnectionString;
        SqlConnection conur = new SqlConnection(connectionString);
        string delur = "delete from Admin where id='" + @id + "'";
        SqlCommand cmdu = new SqlCommand(delur, conur);
        conur.Open();
        cmdu.ExecuteNonQuery();
        conur.Close();
        Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script type='text/javascript'>alert('删除成功！');</script>");
        bind();

    }
    //管理
    protected void gvuser_RowEdt(object sender, GridViewEditEventArgs e)
    {

        gvuser.EditIndex = e.NewEditIndex;
        bind();

    }
    //更新
    protected void gvuser_RowUpd(object sender, GridViewUpdateEventArgs e)
    {


        int id = Convert.ToInt32(gvuser.DataKeys[e.RowIndex].Value);
        CheckBox cb = gvuser.Rows[e.RowIndex].FindControl("CheckBox1") as CheckBox;
        TextBox tb= gvuser.Rows[e.RowIndex].FindControl("txtcmail") as TextBox;      
        int auth;
        string email;
        email=tb.Text.Trim();
        email=Encryption.Encode(email);
        if (cb.Checked)
        {
            auth = 1;
        }
        else
        {
            auth = 0;
        }

                    string connectionString = ConfigurationManager.ConnectionStrings["lijunConnectionString"].ConnectionString;
                    SqlConnection conur = new SqlConnection(connectionString);
                    string delur = "update Admin set suadmin='" + @auth + "',admail='" + @email + "' where id='" + @id + "'";
                    SqlCommand cmdu = new SqlCommand(delur, conur);
                    conur.Open();
                    cmdu.ExecuteNonQuery();
                    conur.Close();
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script type='text/javascript'>alert('更新成功！');</script>");
                    bind();
               
            
     

    }

    //内容定制
    protected void btnSet_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("diycnt.aspx");
    }
    protected void btnCont_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("cntmgr.aspx");
    }
    protected void btnArt_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("postmgr.aspx");

    }
    protected void btnAub_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("photomgr.aspx");
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

    protected void btnGuest_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("guest.aspx");
    }

    //删除选中
    protected void deletemore(object sender, EventArgs e)
    {
        for (int i = 0; i < this.gvuser.Rows.Count; i++)
        {
            CheckBox ckb = (CheckBox)this.gvuser.Rows[i].FindControl("CheckBox2");
            if (ckb.Checked == true)
            {
                int id = Convert.ToInt32(gvuser.DataKeys[i].Value);
               
                   
                    string connectionString = ConfigurationManager.ConnectionStrings["lijunConnectionString"].ConnectionString;
                    SqlConnection conur = new SqlConnection(connectionString);
                    string delur = "delete from Admin where id='" + @id + "'";
                    SqlCommand cmdu = new SqlCommand(delur, conur);
                    conur.Open();
                    cmdu.ExecuteNonQuery();
                    conur.Close();

               

            }

        }

        bind();
    }
}
     
   

