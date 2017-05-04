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


public partial class photomgr : System.Web.UI.Page
{
    //载入
    protected void Page_Load(object sender, EventArgs e)
    {
        Button4.Attributes.Add("onclick", " if(!confirm('确认删除选中的相册吗？\\n如果删除的相册有图片，将会移动到“未分类”下！')) return false;"); 
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
            if (!IsPostBack)
            {
                this.Label1.Text = "欢迎管理员：" + Encryption.Decode(Session["issuper"]);
                bind();
              
                footerload();

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
        Response.Write("<script type='text/javascript'>window.location.href='adminweb.aspx';</script>");
    }

    protected void btnnew_Click(object sender, EventArgs e)
    {
        string newbl = txtnew.Text;
        if (newbl == "")
        {
            aptips.InnerText = "请输入相册名称！";
        }
        else
        {
            if (ckalname(0, newbl))
            {
                insertalb();
            }
        }
    }
    //新建相册
    protected void insertalb()
    {
        string connectionString = ConfigurationManager.ConnectionStrings["lijunConnectionString"].ConnectionString;
        SqlConnection cnn = new SqlConnection(connectionString);
        string newbl = txtnew.Text;
        string st = "insert into Album(alname) values('" + @newbl + "')";
        cnn.Open();
        SqlCommand cmd = new SqlCommand(st, cnn);
        cmd.ExecuteNonQuery();
        bind();
        cnn.Close();
        aptips.InnerText = "";
    }

    protected void gvalb_RowDele(object sender, GridViewDeleteEventArgs e)
    {

        int id = Convert.ToInt32(gvalb.DataKeys[e.RowIndex].Value);
        if (id == 5||id==3)
        {
            aptips.InnerText = "系统相册不允许删除！";
        }
        else
        {
            Photomov(id);
            string connectionString = ConfigurationManager.ConnectionStrings["lijunConnectionString"].ConnectionString;
            SqlConnection conur = new SqlConnection(connectionString);
            string delur = "delete from Album where alid='" + @id + "'";
            SqlCommand cmdu = new SqlCommand(delur, conur);
            conur.Open();
            cmdu.ExecuteNonQuery();
            conur.Close();
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script type='text/javascript'>alert('删除成功！');</script>");
            bind();
        }
    }

    protected void gvalb_RowEdt(object sender, GridViewEditEventArgs e)
    {
        int id = Convert.ToInt32(gvalb.DataKeys[e.NewEditIndex].Value);//获得点击的id
        if (id == 5||id==3)//不允许修改指定的相册
        {
            aptips.InnerText = "系统相册不允许修改！";
        }
        else
        {
            gvalb.EditIndex = e.NewEditIndex;
            bind();
        }
    }
    //更新
    protected void gvalb_RowUpd(object sender, GridViewUpdateEventArgs e)
    {
        TextBox tb=gvalb.Rows[e.RowIndex].FindControl("TextBox1") as TextBox;
        CheckBox cb = gvalb.Rows[e.RowIndex].FindControl("CheckBox1") as CheckBox;
        string alname = tb.Text.Trim();
        int id = Convert.ToInt32(gvalb.DataKeys[e.RowIndex].Value);
        int locker;
        if (cb.Checked)
        {
            locker = 1;
        }
        else
        {
            locker = 0;
        }
      if( ckalname(id,alname))
{
                string connectionString = ConfigurationManager.ConnectionStrings["lijunConnectionString"].ConnectionString;
                SqlConnection conur = new SqlConnection(connectionString);
                string delur = "update Album set alname='" + @alname + "',islock='" + @locker + "' where alid='" + @id + "'";
                SqlCommand cmdu = new SqlCommand(delur, conur);
                conur.Open();
                cmdu.ExecuteNonQuery();
                conur.Close();
                Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script type='text/javascript'>alert('更新成功！');</script>");
                gvalb.EditIndex = -1;
                bind();
                aptips.InnerText = "";
               
}
            
        
    }
    //绑定
    private void bind()
    {
        string bdsql = "select *,ROW_NUMBER()OVER (order by alid desc) AS rowsid from Album";
        string connectionString = ConfigurationManager.ConnectionStrings["lijunConnectionString"].ConnectionString;
        SqlConnection conur = new SqlConnection(connectionString);
        SqlDataAdapter cmdu = new SqlDataAdapter(bdsql, conur);
        DataSet myds = new DataSet();
        conur.Open();
        cmdu.Fill(myds, "Ablum");
        gvalb.DataSource = myds;
        gvalb.DataKeyNames = new string[] { "alid" };
        gvalb.DataBind();
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
    protected void Photomov(int id)//一个移动被删除相册内图片到“未分类”的函数
    {
        string connectionString = ConfigurationManager.ConnectionStrings["lijunConnectionString"].ConnectionString;
        SqlConnection cnn = new SqlConnection(connectionString);
        string st = "update Photo set alid=5 where alid='"+@id+"'";
        cnn.Open();
        SqlCommand cmd = new SqlCommand(st, cnn);
        cmd.ExecuteNonQuery();
        cnn.Close();

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
    //检查相册名是否重复
    private bool ckalname(int alid,string name)
    {
        string connectionString = ConfigurationManager.ConnectionStrings["lijunConnectionString"].ConnectionString;
        SqlConnection cnn = new SqlConnection(connectionString);
        string st = "select  * from Album where alname = '"+@name+"' and alid<>'"+@alid+"'";
        cnn.Open();
        SqlCommand cmd = new SqlCommand(st, cnn);
        SqlDataReader rdr = cmd.ExecuteReader();
        if (rdr.Read())
        {
            cnn.Close();
            aptips.InnerText = "输入的相册名已存在！";
            return false;
        }
        else
        {
            cnn.Close();
            return true;
        }       

    }
    //删除选中
    protected void deletemore(object sender, EventArgs e)
    {
             for (int i = 0; i < this.gvalb.Rows.Count; i++)
        {
            CheckBox ckb = (CheckBox)this.gvalb.Rows[i].FindControl("CheckBox2");
            if (ckb.Checked==true)
            {
                int id = Convert.ToInt32(gvalb.DataKeys[i].Value);
                        if (id == 5 || id == 3)
                {
                    aptips.InnerText = "系统相册不允许删除！";
                }
                else
                {
                    Photomov(id);
                    string connectionString = ConfigurationManager.ConnectionStrings["lijunConnectionString"].ConnectionString;
                    SqlConnection conur = new SqlConnection(connectionString);
                    string delur = "delete from Album where alid='" + @id + "'";
                    SqlCommand cmdu = new SqlCommand(delur, conur);
                    conur.Open();
                    cmdu.ExecuteNonQuery();
                    conur.Close();                   
           
                }
               
            }

        }
        
        bind();
    }
}

