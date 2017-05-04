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

public partial class messages : System.Web.UI.Page
{
    protected SqlDataAdapter da;
    protected DataSet ds;
    protected SqlCommand comm;
    private int rowscount = 0; 
    protected int RowsCount
    {

        get { return rowscount; }
        set { this.rowscount = value; }
    }    

    protected void Page_Load(object sender, EventArgs e)
    {
         if (!IsPostBack)
        {
            footerload();
            bind();
            authmess();
        }
      }
    protected void btnCommit_click(object sender, ImageClickEventArgs e)
    {
            txtcname.Text = txtcname.Text.Replace(" ", "");//去空格
            txtcmail.Text = txtcmail.Text.Replace(" ", "");
            string pname =Encryption.Encode( txtcname.Text.Trim());
            string pmail =Encryption.Encode( txtcmail.Text.Trim());
            string pcontent = Encryption.Encode(txtccontent.Text);
            ckuser(pname, pmail);
            string connectionString = ConfigurationManager.ConnectionStrings["lijunConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(connectionString);
            DateTime dt = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.Now, "China Standard Time");//转东八区
            string st2 = "select * from Guest where gname='" + @pname + "' and gmail='" + @pmail + "'";
            con.Open();
            SqlCommand cmd2 = new SqlCommand(st2, con);
            SqlDataReader rdrr = cmd2.ExecuteReader();
                    if (rdrr.Read())
                    {
                        if (rdrr["gflag"].ToString() == "True")
                        {
                            Response.Write("<script type='text/javascript'>alert('你已经被管理员禁言！');window.location.href='messages.aspx?Page=1'; </script>");
                            con.Close();
                        }
                        else
                        {
                            int gid = Convert.ToInt32(rdrr["guid"]);
                            con.Close();
                            string st = "insert into Mess (pcontent,pposttime,ispub,gid) values('" + @pcontent + "','" + @dt + "','0','" + @gid + "')";
                            SqlCommand cmd = new SqlCommand(st, con);
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();
                            txtcname.Text = "";
                            txtcmail.Text = "";
                            txtccontent.Text = " ";
                            Response.Write("<script type='text/javascript'>alert('谢谢您的支持！');window.location.href='messages.aspx?Page=1'; </script>");
                            dvmess.Visible = false;
                            close.Visible = false;
                            bind();
                        }
                    }                    
                    else
                    {
                        con.Close();
                        Response.Write("<script type='text/javascript'>alert('昵称和邮箱不匹配，请重新输入！');window.location.href='messages.aspx?Page=1'; </script>");
                    }
                }
            
       

               
	
	protected void btnReset_click(object sender,ImageClickEventArgs e)
	{
		txtccontent.Text=" ";
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
            this.Label4.Text = Server.HtmlDecode(rdr["content"].ToString());
            cnn.Close();
        }
    }
  
    protected void close_Click(object sender, ImageClickEventArgs e)
    {
        dvmess.Visible = false;    
    }
    protected void btnnew_Click(object sender, EventArgs e)
    {
        dvmess.Visible = true;
        txtccontent.Attributes.Add("Value", "报修请直接联系我们，请不要在此输入！");
        txtccontent.Attributes.Add("OnFocus", "if(this.value=='报修请直接联系我们，请不要在此输入！'){this.value=''}");
        txtccontent.Attributes.Add("OnBlur", "if(this.value==''){this.value='报修请直接联系我们，请不要在此输入！'}");
 
    }
    private void bind()
    {

        string connectionString = ConfigurationManager.ConnectionStrings["lijunConnectionString"].ConnectionString;
        SqlConnection cnn = new SqlConnection(connectionString);
        string st = "select * from Mess,Guest where Guest.guid=Mess.gid and ispub=1 order by pid desc";
        cnn.Open();
        SqlDataAdapter da = new SqlDataAdapter(st, cnn);
        DataSet ds = new DataSet();
        da.Fill(ds);
        this.dlmess.DataSource = ds.Tables[0].DefaultView;
        DataColumn col = ds.Tables[0].Columns.Add("state", typeof(bool));//自定义列state，判断reply是否为空，绑定Datalist中的“回复：”
        RowsCount = ds.Tables[0].Rows.Count;//为RowsCount赋值
        for (int k = 0; k < ds.Tables[0].Rows.Count; k++)//遍历DataTable，将自定义的state列赋值
        {
            for (int j = 0; j < ds.Tables[0].Columns.Count; j++)
            {
                if (ds.Tables[0].Rows[k]["reply"].ToString().Trim() == "")
                {
                    ds.Tables[0].Rows[k]["state"] = false;//如果                    
                }
                else
                {
                    ds.Tables[0].Rows[k]["state"] = true;
                }
            }
        }
        DataColumn col2 = ds.Tables[0].Columns.Add("rowsid", typeof(int));//序号
        for (int i = 0; i < RowsCount; i++)
        {
            ds.Tables[0].Rows[i]["rowsid"] =RowsCount- i ;
        }
        ds.AcceptChanges();//保存更改
        this.labPageNumber.Text = PageNums.GetPageNum(ds, dlmess, 5); //传入DataSet,DataList名称和分页大小
        dlmess.DataBind();
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
  //检查用户
  protected void ckuser(string name, string mail)
  {
      if (name.Trim() != "" || mail.Trim() != "")
      {
          string connectionString = ConfigurationManager.ConnectionStrings["lijunConnectionString"].ConnectionString;
          SqlConnection cnn = new SqlConnection(connectionString);
          string st = "select * from Guest where gname='" + @name + "' or gmail='" + @mail + "'";
          cnn.Open();
          SqlCommand cmd = new SqlCommand(st, cnn);
          SqlDataReader rdr = cmd.ExecuteReader();
          if (rdr.Read())
          {
              cnn.Close();
          }
          else
          {
              cnn.Close();
              cnn.Open();
              string st2 = "insert into Guest(gname,gmail) values('" + @name + "','" + @mail + "')";
              SqlCommand cmd2 = new SqlCommand(st2, cnn);
              cmd2.ExecuteNonQuery();
              cnn.Close();
          }
      }

  }
    //禁止留言
  protected void authmess()
  {
      string connectionString = ConfigurationManager.ConnectionStrings["lijunConnectionString"].ConnectionString;
      SqlConnection cnn = new SqlConnection(connectionString);
      string st = "select * from Auth";
      cnn.Open();
      SqlCommand cmd = new SqlCommand(st, cnn);
      SqlDataReader rdr = cmd.ExecuteReader();
      if (rdr.Read())
      {
          if (rdr["mess"] .ToString()== "True")
          {
              cnn.Close();
              btnnew.Enabled = false;
              btnnew.Text="管理员关闭了留言功能！";
          }
          else
          {
              cnn.Close();
          }
      }
      else
      {
          cnn.Close();         
      }
  }
      }
 


    
         

