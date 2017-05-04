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

public partial class detail: System.Web.UI.Page
{
protected void Page_Load(object sender, EventArgs e)

{

if (!IsPostBack)
{
getnews();
string connectionString = ConfigurationManager.ConnectionStrings["lijunConnectionString"].ConnectionString;
SqlConnection cnn = new SqlConnection(connectionString);
string newid = Request.QueryString["id"];
string st = "select * from Article where artid='" + @newid+ "'";
cnn.Open();
SqlCommand cmd = new SqlCommand(st, cnn);
SqlDataReader rdr = cmd.ExecuteReader();
if (!rdr.Read())//如果id未输入或者错误
{
commpo.Visible = false;
share.Visible = false;
Label1.Visible = true;
btngood.Visible = false;
cnn.Close();
Label5.Visible = false;
banner.Visible = false;
}
else
{
ckadmin(newid);
bind2();
bind1();
authcom();
showgood();
cnn.Close();
txtcomment.Attributes.Add("Value", "请不要输入包含个人隐私（账号密码等）的内容，谢谢！");
txtcomment.Attributes.Add("OnFocus", "if(this.value=='请不要输入包含个人隐私（账号密码等）的内容，谢谢！'){this.value=''}");
txtcomment.Attributes.Add("OnBlur", "if(this.value==''){this.value='请不要输入包含个人隐私（账号密码等）的内容，谢谢！'}");
}
showfoot();
deletethis();

}
}
//赞的实现方法
protected void btngood_Click(object sender, ImageClickEventArgs e)
{
    string connectionString = ConfigurationManager.ConnectionStrings["lijunConnectionString"].ConnectionString;
    SqlConnection cnn = new SqlConnection(connectionString);
    string newid = Request.QueryString["id"];
    string st = "update Article set good=good+1 where artid='" + @newid + "'";
    cnn.Open();
    SqlCommand cmd = new SqlCommand(st, cnn);
    cmd.ExecuteNonQuery();
    cnn.Close();
    Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script type='text/javascript'>alert('谢谢支持！');</script>");
    showgood();
}
//提交评论
protected void btnPost_Click(object sender, EventArgs e)
{

string comment = txtcomment.Text.ToString().Trim();
string cmail = txtmail.Text.ToString().Trim();
string coname = txtname.Text.ToString().Trim();

coname = Encryption.Encode(coname);
cmail = Encryption.Encode(cmail);
comment = Encryption.Encode(comment);

ckuser(coname, cmail);
string connectionString = ConfigurationManager.ConnectionStrings["lijunConnectionString"].ConnectionString;
SqlConnection cnn = new SqlConnection(connectionString);
string newid = Request.QueryString["id"];
DateTime dt = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.Now, "China Standard Time");//转东八区               
string st2 = "select * from Guest where gname='" + @coname + "' and gmail='" + @cmail + "' and gflag=0";
cnn.Open();
SqlCommand cmd2 = new SqlCommand(st2, cnn);
SqlDataReader rdrr = cmd2.ExecuteReader();
if (rdrr.Read())
{
int fids = getfloors();
int gid = Convert.ToInt32(rdrr["guid"]);
cnn.Close();
string st = "";
if (lbif.Visible == true)
{
st = "insert into Comment (aid,gid,comment,cposttime,fid) values('" + @newid + "','" + @gid + "','" + @comment + "','" + @dt + "','" + @fids + "')";
}
else
{
    int repid = Convert.ToInt32(Session["repis"]); 
st = "insert into Comment (aid,gid,repid,comment,cposttime,fid) values('" + @newid + "','" + @gid + "','" + @repid + "','" + @comment + "','" + @dt + "','" + @fids + "')";
}
SqlCommand cmd = new SqlCommand(st, cnn);
cnn.Open();
cmd.ExecuteNonQuery();
Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script type='text/javascript'>alert('回复成功！');window.location.href=window.location.href; </script>");
bind1();
cnn.Close();
}
else
{
cnn.Close();
Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script type='text/javascript'>alert('邮箱地址和昵称不匹配！');window.location.href=window.location.href; </script>");

}



}
protected void btnReset_Click(object sender, EventArgs e)
{
txtname.Text = "";
txtmail.Text="";
txtcomment.Text="";
}

protected void btnBack_click(object sender, ImageClickEventArgs e)
{
Response.Redirect("bbs.aspx");
}
protected void showfoot()
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
}
cnn.Close();
}
protected void showgood()//获取赞的数量
{
string connectionString = ConfigurationManager.ConnectionStrings["lijunConnectionString"].ConnectionString;
SqlConnection cnn = new SqlConnection(connectionString);
string newid = Request.QueryString["id"];
string st = "select * from Article where artid='" + @newid + "'";
cnn.Open();
SqlCommand cmd = new SqlCommand(st, cnn);
SqlDataReader rdr = cmd.ExecuteReader();
if (rdr.Read())
{
this.Label4.Text = rdr["good"].ToString();
}
cnn.Close();
}
protected void bind1()
{
string connectionString = ConfigurationManager.ConnectionStrings["lijunConnectionString"].ConnectionString;
SqlConnection cnn = new SqlConnection(connectionString);
string newid = Request.QueryString["id"];
//对两个查询表进行查询
string st = "Select  a.fid,rfid,ismgr,a.gname,rcomment,rname,comment,cposttime,a.comid,cflag,comon from (Select * from Comment,Guest,Article where Comment.gid=Guest.guid and aid=artid and aid='" + @newid + "') as a left join (Select comid,gname as rname,repid,fid as rfid,comment as rcomment from Comment,Guest where Comment.gid=Guest.guid and comid in (Select repid from Comment)) as b on a.repid=b.comid and aid='" + @newid + "' order by a.comid";
cnn.Open();
SqlDataAdapter da = new SqlDataAdapter(st, cnn);
DataSet ds = new DataSet();
da.Fill(ds);
DataColumn col=ds.Tables[0].Columns.Add("state",typeof(bool));//自定义列state，判断reply是否为空，绑定Datalist中的“回复：”
for (int k = 0; k < ds.Tables[0].Rows.Count; k++)//遍历DataTable，将自定义的state列赋值
{
for (int j = 0; j < ds.Tables[0].Columns.Count; j++)
{
if (ds.Tables[0].Rows[k]["rfid"].ToString().Trim() == "")
{
ds.Tables[0].Rows[k]["state"] = false;
ds.Tables[0].Rows[k]["rname"] = "W09e9r226HPhomHFSD8Ktg==";
ds.Tables[0].Rows[k]["rcomment"] = "W09e9r226HPhomHFSD8Ktg==";
}
else
{
ds.Tables[0].Rows[k]["state"] =true;
}
}
}

ds.AcceptChanges();//保存更改
dlcom.DataSource = ds;
dlcom.DataBind();
if (dlcom.Items.Count == 0)
{
Label5.Visible = false;
comdiv.Visible = false;
}
ds.Clear();
cnn.Close();      
}
protected void bind2()
{
string connectionString = ConfigurationManager.ConnectionStrings["lijunConnectionString"].ConnectionString;
SqlConnection cnn = new SqlConnection(connectionString);
string newid = Request.QueryString["id"];
string st = "select * from Article where artid='" + @newid + "'";
SqlDataAdapter da = new SqlDataAdapter(st, cnn);
DataSet ds = new DataSet();
da.Fill(ds);        
fvtxt.DataSource = ds;
fvtxt.DataBind();
if (ds.Tables[0].Rows[0]["comon"].ToString() == "True")
{
ImageButton ibtn = fvtxt.FindControl("btnRly") as ImageButton;
dlcom.Enabled = false;
}
ds.Clear();
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
protected void getnews()//用于显示上一篇、下一篇文章
{
int newsid = Convert.ToInt32(Request.QueryString["id"]);
string connectionString = ConfigurationManager.ConnectionStrings["lijunConnectionString"].ConnectionString;
SqlConnection cnn = new SqlConnection(connectionString);
string st = "select top 1 * from Article where artid<" + @newsid + " order by artid desc";
string st2 = "select top 1 *  from  Article  where artid>" + @newsid + " order by artid"; 
cnn.Open();
SqlCommand cmd = new SqlCommand(st, cnn);
SqlCommand cmd2 = new SqlCommand(st2, cnn);
SqlDataReader rdr = cmd.ExecuteReader();
if (rdr.Read())
{
hlpre.Text = rdr["artitle"].ToString();
hlpre.Enabled = true;
hlpre.NavigateUrl = "detail.aspx?id=" + rdr["artid"].ToString();
cnn.Close();
}
else
{
hlpre.Font.Underline = false;
cnn.Close();
}
cnn.Open();
SqlDataReader rdr2 = cmd2.ExecuteReader();
if (rdr2.Read())
{
hlnext.Text = rdr2["artitle"].ToString();
hlnext.Enabled = true;
hlnext.NavigateUrl = "detail.aspx?id=" + rdr2["artid"].ToString();
cnn.Close();
}
else
{
hlnext.Font.Underline = false;
cnn.Close();
}

}
//检查用户
protected void ckuser(string name, string mail)
{
string connectionString = ConfigurationManager.ConnectionStrings["lijunConnectionString"].ConnectionString;
SqlConnection cnn = new SqlConnection(connectionString);
string st = "select * from Guest where gname='" + @name + "' or gmail='" + @mail + "'";
cnn.Open();
SqlCommand cmd = new SqlCommand(st, cnn);
SqlDataReader rdr = cmd.ExecuteReader();
if (rdr.Read())
{
if (rdr["gflag"].ToString() == "True")
{
cnn.Close();
Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script type='text/javascript'>alert('你已被管理员禁言！');window.location.href=window.location.href; </script>");
}
else
{
cnn.Close();
}
}
else
{
cnn.Close();
cnn.Open();
string st2 = "insert into Guest(gname,gmail,gflag,ismgr) values('" + @name + "','" + @mail + "','0','0')";
SqlCommand cmd2 = new SqlCommand(st2, cnn);
cmd2.ExecuteNonQuery();
cnn.Close();
}

}
//楼层回复
protected void btnR_Click(object sender, EventArgs e)
{
reply.Visible = true;
lbif.Visible = false;
lbr1.Visible = true;
lbr2.Visible = true;
lbre.Visible = true;
Button btn = sender as Button;
    string commm=btn.CommandArgument.ToString();
Session["repis"] = commm;
int newsid = Convert.ToInt32(Request.QueryString["id"]);
string st = "select * from Comment as a,Guest as b where comid='"+@commm+"' and a.gid=b.guid ";
SqlDataReader reader = DBHelp.cn(st).ExecuteReader();
if (reader.Read())
{
    
    lbre.Text =Encryption.Decode(reader["gname"]).ToString();
}
}   


//获取楼层
protected int getfloors()
{
int newsid = Convert.ToInt32(Request.QueryString["id"]);
string connectionString = ConfigurationManager.ConnectionStrings["lijunConnectionString"].ConnectionString;
SqlConnection cnn = new SqlConnection(connectionString);
string st = "SELECT COUNT(comid) AS floors FROM Comment WHERE aid='"+@newsid+"'";
cnn.Open();
SqlCommand cmd = new SqlCommand(st, cnn);
SqlDataReader rdr = cmd.ExecuteReader();
if (rdr.Read())
{
int fids = Convert.ToInt32(rdr["floors"]);
cnn.Close();
return fids+1;
}
else
{
cnn.Close();
return 0;
}
}
//检查是否允许评论
protected void authcom()
{
string connectionString = ConfigurationManager.ConnectionStrings["lijunConnectionString"].ConnectionString;
SqlConnection cnn = new SqlConnection(connectionString);
string st = "SELECT * from Auth";
cnn.Open();
SqlCommand cmd = new SqlCommand(st, cnn);
SqlDataReader rdr = cmd.ExecuteReader();
if (rdr.Read())
{
    if (rdr["comment"].ToString() == "True")//评论已经关闭
    {
        dlcom.Enabled = false;
        reply.Visible = false;
    }
    else
    {
if (ckcomm() == true)
    {
        dlcom.Enabled = false;
      
        reply.Visible = false;
    }
    }
cnn.Close();
}
else
{
    
       dlcom.Enabled = true;
        reply.Visible = true;
   
cnn.Close();
}
}
public string OutputByLine(object caption)//通过设定的行数分页 
{
string strContent = caption.ToString().Trim();
int pageSize = int.Parse(ConfigurationManager.AppSettings["pageSize"]);//每页显示行数从CONFIG文件中取出 
string lineBreak = ConfigurationManager.AppSettings["lineBreak"];//换行符从CONFIG文件中取出 
strContent = strContent.Replace("\r\n", "");
string[] strLined = strContent.Split(new string[] { lineBreak }, StringSplitOptions.RemoveEmptyEntries);//以DIV为换行符 
int pageCount = strLined.Length / pageSize;
int pageCountPlus = strLined.Length % pageSize == 0 ? 0 : 1;//非满页 
pageCount = pageCount + pageCountPlus;//总页数 
int currentPage = 1;//当前页码 
string displayText = null;
string epage = Request.QueryString["page"];
if (epage != null) //获取翻页页码 
{
if (epage.Trim() == "")        //错误处理
{
currentPage = 1;
}
else
{
currentPage = Convert.ToInt32(epage);
if (currentPage < 1 || currentPage > pageCount)
{
currentPage = 1;
}
}
}
else
{
currentPage = 1;
}
string pageInfo = "";//页数信息 
for (int i = 1; i < pageCount + 1; i++)
{
if (i == currentPage)
{
pageInfo += "<span>" + i + "</span>";
pageInfo = "<div class='pager'>" + pageInfo + "<div>";
}
else
{
string newsid = Request.QueryString["id"];
pageInfo += "<a href=detail.aspx?" +"id="+newsid+"&page=" + i + ">" + i + "</a>";
pageInfo = "<div class='pager'>" + pageInfo + "<div>";
}
}
if (pageCount == 1)
{
labPageNumber.Visible = false;
}
labPageNumber.Text = pageInfo;
for (int i = (currentPage - 1) * pageSize; i < currentPage * pageSize && i < strLined.Length; i++)
{
displayText += "<div>" + strLined[i] + "</div>";
}
return displayText;
}
    //验证管理员
protected void ckadmin(string artid)
{
    if (Session["issuper"] == null || Session["ispwd"] == null)
    {
        HyperLink1.Visible = false;
        HyperLink2.Visible = false;
    }
    else if (WebHelp.Auth(Session["issuper"].ToString(), Session["ispwd"].ToString()) == false)
    {
        HyperLink1.Visible = false;
        HyperLink2.Visible = false;
    }
    else
    {
        //HyperLink1.NavigateUrl = "javascript:void if(!confirm('确认删除本文吗？')) return false;window.location.href='editpost.aspx?id=" + artid+"';";
        HyperLink1.NavigateUrl = "editpost.aspx?id=" + artid;
        HyperLink2.NavigateUrl = "detail.aspx?id=" + artid+"&ac=delete";
    }
}
protected void deletethis()
{
    string newid = Request.QueryString["id"];
    string action = Request.QueryString["ac"];
    if(action=="delete")
    {
    string connectionString = ConfigurationManager.ConnectionStrings["lijunConnectionString"].ConnectionString;
    SqlConnection cnn = new SqlConnection(connectionString);
    string st = "Delete Article where artid='" + @newid + "'";
    SqlCommand cmd = new SqlCommand(st, cnn);
    cnn.Open();
    cmd.ExecuteNonQuery();
    cnn.Close();
    Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script type='text/javascript'>alert('删除成功！');  window.location.href='bbs.aspx'; </script>");
    }
}
    //验证关闭评论
protected bool ckcomm()
{
    string newid = Request.QueryString["id"];
    string st = "select * from Article where artid='" + @newid + "'";
    SqlDataReader red = DBHelp.cn(st).ExecuteReader();
    if (red.Read())
    {
        if (red["comon"].ToString() == "True")
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    else
    {
        return false;
    }
}

}
