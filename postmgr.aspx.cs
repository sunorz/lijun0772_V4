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


public partial class postmgr : System.Web.UI.Page
{
	//载入
    protected void Page_Load(object sender, EventArgs e)
    {
        Button4.Attributes.Add("onclick", " if(!confirm('确认删除选中的文章吗！')) return false;"); 
        if (!IsPostBack)
        {
                  footerload();
        }
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

            
        }    
    }
	protected void btnLogout_click(object sender, ImageClickEventArgs e)
    {
      Session["issuper"] = null;
      Session["suadmin"] = null;
      Response.Write("<script type='text/javascript'>window.location.href='Default.aspx';</script>");
             
    }
    protected void btnGo_Click(object sender, EventArgs e)
    {

    }
    protected void btnBack_click(object sender, ImageClickEventArgs e)
    {
        Response.Write("<script type='text/javascript'>window.location.href='adminweb.aspx';</script>");
    }
    protected void btnPost_Click(object sender, EventArgs e)
    {
        Response.Write("<script type='text/javascript'>window.location.href='newpost.aspx';</script>");
    }
      protected void gvpost_RowDele(object sender, GridViewDeleteEventArgs e)
    {
        int poid = Convert.ToInt32(gvpost.DataKeys[e.RowIndex].Value);
        string connectionString = ConfigurationManager.ConnectionStrings["lijunConnectionString"].ConnectionString;
        SqlConnection conur = new SqlConnection(connectionString);
        string delur = "delete from Article where artid='" + @poid + "'";
        SqlCommand cmdu = new SqlCommand(delur, conur);
        conur.Open();
        cmdu.ExecuteNonQuery();
        conur.Close();        
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
    //删除选中
    protected void deletemore(object sender, EventArgs e)
    {
        for (int i = 0; i < this.gvpost.Rows.Count; i++)
        {
            CheckBox ckb = (CheckBox)this.gvpost.Rows[i].FindControl("CheckBox1");
            if (ckb.Checked == true)
            {
                int id = Convert.ToInt32(gvpost.DataKeys[i].Value);
                string connectionString = ConfigurationManager.ConnectionStrings["lijunConnectionString"].ConnectionString;
                SqlConnection conur = new SqlConnection(connectionString);
                string delur = "delete from Article where artid='" + @id + "'";
                SqlCommand cmdu = new SqlCommand(delur, conur);
                conur.Open();
                cmdu.ExecuteNonQuery();
                conur.Close();

            }

        }
        gvpost.DataBind();
    }
}

