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


public partial class cntmgr : System.Web.UI.Page
{
    //载入
    protected void Page_Load(object sender, EventArgs e)
    {
        Button4.Attributes.Add("onclick", " if(!confirm('确认删除选中的留言吗！')) return false;");
        Button6.Attributes.Add("onclick", " if(!confirm('确认删除选中的评论吗！')) return false;");
        if (!IsPostBack)
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
                bind();
                bind2();
            }
        }

    }
    protected void btnLogout_click(object sender, ImageClickEventArgs e)
    {
        Session["issuper"] = null;
        Session["suadmin"] = null;
        Response.Write("<script type='text/javascript'>window.location.href='Default.aspx';</script>");

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
    //绑定总开关
    private void bind()
    {
        string connectionString = ConfigurationManager.ConnectionStrings["lijunConnectionString"].ConnectionString;
        SqlConnection cnn = new SqlConnection(connectionString);
        string st = "select top 1 * from Auth";
        cnn.Open();
        SqlCommand cmd = new SqlCommand(st, cnn);
        SqlDataReader rdr = cmd.ExecuteReader();
        if (rdr.Read())
        {
            if (rdr["comment"].ToString() == "True" && rdr["mess"].ToString() == "True")
            {
                ibtnc.ImageUrl = "~/imgs/off.gif";
                ibtnc.ToolTip = "点击打开";
                ibtnm.ImageUrl = "~/imgs/off.gif";
                ibtnm.ToolTip = "点击打开";
            }
            else if (rdr["comment"].ToString() == "False" && rdr["mess"].ToString() == "False")
            {
                ibtnc.ImageUrl = "~/imgs/on.gif";
                ibtnc.ToolTip = "点击关闭";
                ibtnm.ImageUrl = "~/imgs/on.gif";
                ibtnm.ToolTip = "点击关闭";
            }
            else if (rdr["comment"].ToString() == "False" && rdr["mess"].ToString() == "True")
            {
                ibtnc.ImageUrl = "~/imgs/on.gif";
                ibtnc.ToolTip = "点击关闭";
                ibtnm.ImageUrl = "~/imgs/off.gif";
                ibtnm.ToolTip = "点击打开";
            }
            else if (rdr["comment"].ToString() == "True" && rdr["mess"].ToString() == "False")
            {
                ibtnc.ImageUrl = "~/imgs/off.gif";
                ibtnc.ToolTip = "点击打开";
                ibtnm.ImageUrl = "~/imgs/on.gif";
                ibtnm.ToolTip = "点击关闭";
            }
            cnn.Close();
        }
    }
    protected void ibtnc_Click(object sender, ImageClickEventArgs e)
    {
        string connectionString = ConfigurationManager.ConnectionStrings["lijunConnectionString"].ConnectionString;
        SqlConnection cnn = new SqlConnection(connectionString);
        cnn.Open();
        int i;
        if (ibtnc.ToolTip == "点击关闭")
        {
            i = 1;
        }
        else
        {
            i = 0;
        }
        string st = "update Auth set comment='" + @i + "' ";
        SqlCommand cmd = new SqlCommand(st, cnn);
        SqlDataReader rdr = cmd.ExecuteReader();
        cnn.Close();
        bind();
    }
    protected void ibtnm_Click(object sender, ImageClickEventArgs e)
    {
        string connectionString = ConfigurationManager.ConnectionStrings["lijunConnectionString"].ConnectionString;
        SqlConnection cnn = new SqlConnection(connectionString);
        cnn.Open();
        int i;
        if (ibtnm.ToolTip == "点击关闭")
        {
            i = 1;
        }
        else
        {
            i = 0;
        }
        string st = "update Auth set mess='" + @i + "' ";
        SqlCommand cmd = new SqlCommand(st, cnn);
        SqlDataReader rdr = cmd.ExecuteReader();
        cnn.Close();
        bind();
    }
    //删除选中留言
    protected void deletemore(object sender, EventArgs e)
    {
        for (int i = 0; i < this.gvmess.Rows.Count; i++)
        {
            CheckBox ckb = (CheckBox)this.gvmess.Rows[i].FindControl("CheckBox1");
            if (ckb.Checked == true)
            {
                int id = Convert.ToInt32(gvmess.DataKeys[i].Value);
                string connectionString = ConfigurationManager.ConnectionStrings["lijunConnectionString"].ConnectionString;
                SqlConnection conur = new SqlConnection(connectionString);
                string delur = "delete from Mess where pid='" + @id + "'";
                SqlCommand cmdu = new SqlCommand(delur, conur);
                conur.Open();
                cmdu.ExecuteNonQuery();
                conur.Close();

            }

        }
        gvmess.DataBind();
    }
    //删除选中评论 
    protected void deletemore_2(object sender, EventArgs e)
    {
        for (int i = 0; i < this.gvcom2.Rows.Count; i++)
        {
            CheckBox ckb = (CheckBox)this.gvcom2.Rows[i].FindControl("CheckBox1");
            if (ckb.Checked == true)
            {
                int id = Convert.ToInt32(gvcom2.DataKeys[i].Value);
                 string connectionString = ConfigurationManager.ConnectionStrings["lijunConnectionString"].ConnectionString;
                    SqlConnection conur = new SqlConnection(connectionString);
                    if (!ckhvre(id))
                    {
                        string delur = "delete Comment where comid='" + @id + "'";
                        SqlCommand cmdu = new SqlCommand(delur, conur);
                        conur.Open();
                        cmdu.ExecuteNonQuery();
                        conur.Close();
                    }
                    else
                    {
                        string delur = "update Comment set comment='"+Encryption.Encode("该评论被删除！")+"' where comid='" + @id + "'";
                        SqlCommand cmdu = new SqlCommand(delur, conur);
                        conur.Open();
                        cmdu.ExecuteNonQuery();
                        conur.Close();
                    }

            }

        }
        bind2();
    }
    //绑定评论
    private void bind2()
    {
        string bdsql = "SELECT *,ROW_NUMBER()OVER (order by comid desc) AS rowsid FROM [Comment],[Article],[Guest]  where [aid]=[artid] and [gid]=[guid] ORDER BY [comid] DESC";
        string connectionString = ConfigurationManager.ConnectionStrings["lijunConnectionString"].ConnectionString;
        SqlConnection conur = new SqlConnection(connectionString);
        SqlDataAdapter cmdu = new SqlDataAdapter(bdsql, conur);
        DataSet myds = new DataSet();
        conur.Open();
        cmdu.Fill(myds, "Comment");
        gvcom2.DataSource = myds;
        gvcom2.DataKeyNames = new string[] { "comid" };
        gvcom2.DataBind();
        conur.Close();
    }
    //判断是否有回复
    protected bool ckhvre(int comid)
    {
        string connectionString = ConfigurationManager.ConnectionStrings["lijunConnectionString"].ConnectionString;
        SqlConnection cnn = new SqlConnection(connectionString);
        string st = "select  * from Comment where repid='" + @comid + "'";
        cnn.Open();
        SqlCommand cmd = new SqlCommand(st, cnn);
        SqlDataReader rdr = cmd.ExecuteReader();
        if (rdr.Read())
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    protected void gvcom2_Dele(object sender, GridViewDeleteEventArgs e)
    {
        int id = Convert.ToInt32(gvcom2.DataKeys[e.RowIndex].Value);
        string connectionString = ConfigurationManager.ConnectionStrings["lijunConnectionString"].ConnectionString;
        SqlConnection conur = new SqlConnection(connectionString);
        if (!ckhvre(id))
        {
            string delur = "delete Comment where comid='" + @id + "'";
            SqlCommand cmdu = new SqlCommand(delur, conur);
            conur.Open();
            cmdu.ExecuteNonQuery();
            conur.Close();
        }
        else
        {
            string delur = "update Comment set comment='" + Encryption.Encode("该评论被删除！") + "' where comid='" + @id + "'";
            SqlCommand cmdu = new SqlCommand(delur, conur);
            conur.Open();
            cmdu.ExecuteNonQuery();
            conur.Close();
        }
        bind2();
    }
    protected void gvmess_Com(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Ups")
        {
            int id = Convert.ToInt32(e.CommandArgument.ToString());
            string st1 = "select * from Mess where gid='" + @id + "'";
            SqlDataReader rea = DBHelp.cn(st1).ExecuteReader();
            string i = null;
            if (rea.Read())
            {
                  if (rea["ispub"].ToString() == "False")
                {
                    i = "1";
                }
                else
                {
                    i = "0";
                }
                string st2 = "update Mess set ispub='" + @i + "' where gid='" + @id + "'";
                DBHelp.cn(st2).ExecuteNonQuery();
                gvmess.DataBind();
            }
        }
    }
}
