using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

/// <summary>
///PageNums 的摘要说明
/// </summary>
public class PageNums
{
    /// </summary>
    /// <param name="ds">DataSet实例</param>
    /// <param name="datalistname">DataList名称</param>
    /// <param name="pagesize">分页大小</param>
    public static string GetPageNum(DataSet ds, DataList datalistname, int pagesize)
    {
        PagedDataSource objPds = new PagedDataSource();
        objPds.DataSource = ds.Tables[0].DefaultView;
        objPds.AllowPaging = true;
        int total = ds.Tables[0].Rows.Count;
        objPds.PageSize = pagesize;
        int page;
        if (HttpContext.Current.Request.QueryString["page"] != null)
        {
            page = Convert.ToInt32(HttpContext.Current.Request.QueryString["page"]);
            if(page>total||page<total)
            {
                page = 1;
            }         
        }
        else
        page = 1;
        objPds.CurrentPageIndex = page - 1;
        datalistname.DataSource = objPds;
        datalistname.DataBind();
        int allpage = 0;
        int next = 0;
        int pre = 0;
        int startcount = 0;
        int endcount = 0;
        string pagestr = "";
        if (page < 1) { page = 1; }
        //计算总页数
        if (pagesize != 0)
        {
            allpage = (total / pagesize);
            allpage = ((total % pagesize) != 0 ? allpage + 1 : allpage);
            allpage = (allpage == 0 ? 1 : allpage);
        }
        next = page + 1;
        pre = page - 1;
        startcount = (page + 5) > allpage ? allpage - 9 : page - 4;//中间页起始序号
        //中间页终止序号
        endcount = page < 5 ? 10 : page + 5;
        if (startcount < 1 || startcount > allpage) { startcount = 1; } //为了避免输出的时候产生负数，设置如果小于1就从序号1开始
        if (allpage < endcount) { endcount = allpage; } //页码+5的可能性就会产生最终输出序号大于总页码，那么就要将其控制在页码数之内
        //中间页处理，这个增加时间复杂度，减小空间复杂度
        if (page == allpage)
        {
            pagestr = "";
        }
        else
        {
            for (int i = startcount; i <= endcount; i++)
            {
                if (i == page)
                {
                    pagestr += "<span>" + i + "</span>";
                    pagestr = "<div class='pager'>" + pagestr + "<div>";
                }
                else
                {
                    pagestr += "<a href=\"" + HttpContext.Current.Request.CurrentExecutionFilePath + "?page=" + i + "\">" + i + "</a>";
                    pagestr = "<div class='pager'>" + pagestr + "<div>";
                }
            }
        }
        return pagestr;
    }
}