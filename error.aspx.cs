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
using System.Text.RegularExpressions;

public partial class error: System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["lijunConnectionString"].ConnectionString;
            SqlConnection cnn = new SqlConnection(connectionString);
            string st = "select * from Class where classid=2";
            cnn.Open();
            SqlCommand cmd = new SqlCommand(st, cnn);
            SqlDataReader rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                this.Label1.Text = OutputByLine(rdr["content"].ToString());
                title.InnerText = rdr["cltitle"].ToString();
                cnn.Close();
                footerload();
            }
            else
            {
                this.Label1.Text = "（暂无内容！）";
                cnn.Close();
            }


        }

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
    public string OutputByLine(string strContent)//通过设定的行数分页 
    {
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
                pageInfo += "<a href=error.aspx?" + "page=" + i + ">" + i + "</a>";
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
}
