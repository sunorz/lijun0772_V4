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
using System.IO;
using System.Drawing;
public partial class guest : System.Web.UI.Page
{
     protected void Page_Load(object sender, EventArgs e)
    {
        Button4.Attributes.Add("onclick", " if(!confirm('ȷ��ɾ���÷ÿ���\\n������ֹ�÷ÿ��ٴη��ԣ���ֱ�ӽ��ԣ�')) return false;"); 
        if (Session["issuper"] == null || Session["ispwd"] == null)
        {
            Response.Write("<script type='text/javascript'>alert('��¼��ʱ��');window.location.href='Default.aspx';</script>");
        }
        else if (WebHelp.Auth(Session["issuper"].ToString(), Session["ispwd"].ToString()) == false)
        {
            Response.Write("<script type='text/javascript'>alert('��¼��ʱ��');window.location.href='Default.aspx';</script>");
        }

        else
        {
            if (!IsPostBack)
            {
                this.Label1.Text = "��ӭ����Ա��" + Encryption.Decode(Session["issuper"]);
                footerload();
                bind();
            }
        }
     }
 

    protected void btnBaphoto_click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("adminweb.aspx");
    }
    protected void btnBack_click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("adminweb.aspx");
    }
    protected void btnLogout_click(object sender, ImageClickEventArgs e)
    {
        Session["issuper"] = null;
        Session["suadmin"] = null;
        Response.Write("<script type='text/javascript'>window.location.href='Default.aspx';</script>");
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
   
    //����
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
    //�Զ������
    protected void gvguest_RowUpd(object sender, GridViewUpdateEventArgs e)
    {
        TextBox tb=gvguest.Rows[e.RowIndex].FindControl("TextBox1") as TextBox;
        TextBox tb2=gvguest.Rows[e.RowIndex].FindControl("TextBox2") as TextBox;
        CheckBox cb = gvguest.Rows[e.RowIndex].FindControl("CheckBox1") as CheckBox;
        CheckBox cb2 = gvguest.Rows[e.RowIndex].FindControl("CheckBox2") as CheckBox;
         int locker;
         int isadmin;
        if (cb.Checked)
        {
            locker = 1;
        }
        else
        {
            locker = 0;
        }
        if (cb2.Checked)
        {
            isadmin = 1;
        }
        else
        {
            isadmin = 0;
        }
        string name=Encryption.Encode(tb.Text.Trim());
        string mail=Encryption.Encode(tb2.Text.Trim());
        int guid=Convert.ToInt32(gvguest.DataKeys[e.RowIndex].Value);
        if (ckguest(guid, name, mail))
        {
            string connectionString = ConfigurationManager.ConnectionStrings["lijunConnectionString"].ConnectionString;
            SqlConnection conur = new SqlConnection(connectionString);
            string delur = "update Guest set gname='" + @name + "',gmail='" + @mail + "',gflag='" + @locker + "',ismgr='" + @isadmin + "' where guid='" + @guid + "'";
            SqlCommand cmdu = new SqlCommand(delur, conur);
            conur.Open();
            cmdu.ExecuteNonQuery();
            conur.Close();
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script type='text/javascript'>alert('���³ɹ���');</script>");
            bind();
            gvguest.EditIndex = -1;
        }       
        bind();
    }
    //���
    protected bool ckguest(int guid,string name, string mail)
    {
        string connectionString = ConfigurationManager.ConnectionStrings["lijunConnectionString"].ConnectionString;
        SqlConnection cnn = new SqlConnection(connectionString);
        string st = "select * from Guest where (gname='" + @name + "' or gmail='" + @mail + "') and guid<>'"+@guid+"'";
        cnn.Open();
        SqlCommand cmd = new SqlCommand(st, cnn);
        SqlDataReader rdr = cmd.ExecuteReader();
        if (rdr.Read())
        {         
            cnn.Close();
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script type='text/javascript'>alert('��Ϣ�Ѵ��ڣ�');</script>");
            return false;
        }
        else
        {
            cnn.Close();
           return true;
        }

    }
    //��
    private void bind()
    {

        if (Session["issuper"] != null)
        {
            string adname = Session["issuper"].ToString();
        }
        string bdsql = "select *,ROW_NUMBER()OVER (order by guid) AS rowsid from Guest where guid<>19";
        string connectionString = ConfigurationManager.ConnectionStrings["lijunConnectionString"].ConnectionString;
        SqlConnection conur = new SqlConnection(connectionString);
        SqlDataAdapter cmdu = new SqlDataAdapter(bdsql, conur);
        DataSet myds = new DataSet();
        conur.Open();
        cmdu.Fill(myds, "Guest");
        gvguest.DataSource = myds;
        gvguest.DataKeyNames = new string[] { "guid" };
        gvguest.DataBind();
        conur.Close();
    }
    protected void gvguest_RowEdt(object sender, GridViewEditEventArgs e)
    {
        gvguest.EditIndex = e.NewEditIndex;
        bind();
    }
    protected void gvguest_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvguest.PageIndex = e.NewPageIndex;
        bind();
    }
    //ɾ��ѡ��
    protected void deletemore(object sender, EventArgs e)
    {
   
        for (int i = 0; i < this.gvguest.Rows.Count; i++)
        {
            CheckBox ckb = (CheckBox)this.gvguest.Rows[i].FindControl("CheckBox3");
            if (ckb.Checked == true)
            {

                string id = gvguest.DataKeys[i].Value.ToString();
                if (ckhvre(id) && ckhvro(id))
                {
                    string delur = "delete from Guest where guid='" + @id + "'";
                    DBHelp.cn(delur).ExecuteNonQuery();

                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script type='text/javascript'>alert('��ɾ���ķÿ��б��ظ������ۣ�\\n��ѡ��ͣ�á���');</script>");
                }
                
                }

            }        
        bind();
    }
    protected void gvguest_RowsDel(object sender, GridViewDeleteEventArgs e)
    {
      string id = gvguest.DataKeys[e.RowIndex].Value.ToString();
      ckhvre(id);
      if (ckhvre(id) && ckhvro(id))//û�����Ժͱ��ظ�����
      {
          string delur = "delete Guest where guid='" + @id + "'";
          DBHelp.cn(delur).ExecuteNonQuery();
      }
      else
      {
          Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script type='text/javascript'>alert('��ɾ���ķÿ��б��ظ������ۣ�\\n��ѡ��ͣ�á���');</script>");
      }
      bind();
    }
    //�жϱ�ɾ�����û��Ƿ������۱��ظ�
    protected bool ckhvre(string id)
    {
        string st3 = "select * from Comment where repid in (select comid from Comment where gid='"+@id+"')";
        SqlDataReader reader3 = DBHelp.cn(st3).ExecuteReader();
        if (reader3.Read())
        {
            return false;
        }
        else
        {
            return true;

        }

    }
    //�жϱ�ɾ�����û��Ƿ�������
    protected bool ckhvro(string id)
    {
        string st4 = "select * from Mess where gid='" + @id + "'";
        SqlDataReader reader4 = DBHelp.cn(st4).ExecuteReader();
        if (reader4.Read())
        {
            return false;
        }
        else
        {
            return true;
        }

    }
   
}