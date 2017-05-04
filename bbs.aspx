<%@ Page Language="C#" AutoEventWireup="true" CodeFile="bbs.aspx.cs" Inherits="bbs" Debug="true"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
<link rel="stylesheet" type="text/css" href="style.css" />
<title>丽军数码-业界新闻</title>
    <style type="text/css">
        .style2
        {
            color: black;
            background-color: #FFFFFF;
             text-align:center;
        }
		#title{
	line-height:5pt;
	font-family:"楷书";
	font-size:20pt;
    color:#ffffff;
    line-height:40pt;
	letter-spacing:8pt;
}
    body {
	background-image: url(imgs/class/bg5.jpg);
	background-repeat: repeat;
	background-attachment: fixed;
}
a:link {
	text-decoration: none;
}
a:visited {
	text-decoration: none;
}
a:hover {
	text-decoration: underline;
}
a:active {
	text-decoration: none;
} a.bbs:link{ color:#336699;}
 a.bbs:hover{ text-decoration:underline;color:#336699;;}
 a.bbs:visited{ color:#336699;}
        .newl
        {
            font-size: xx-small;
            color: #7E5705;
        }
        .pager
 {
     width:100%;  margin:10px; line-height:20px; display:block;
    
 }
.pager a
 {

    border: 1px solid #1C5E55; 
    line-height: 30px;
    margin-right: 5px;
    padding: 2px 6px;
    background-color:White;color:#1C5E55;
 }
 .pager span
 {

    border: 1px solid #1C5E55; 
    line-height: 30px;
    margin-right: 5px;
    padding: 2px 6px;
    background-color:#1C5E55; color:White;
 }
.pager a:hover
 {border:1 solid #1C5E55; background-color:#1C5E55; color:White;  padding: 2px 6px;}

    </style>
<script type="text/javascript" src="http://z.cnzz.net/o.php?sid=1253974593"></script></head>
  <body>
  <script language="JavaScript" type="text/javascript">
var lang = navigator.language || navigator.userLanguage;
if(lang.substr(0, 3) == "zh-"){
document.write("<style type=\"text/css\" media=\"screen\">center{display:none;}</style>"); }
</script>
    <form id="form1" runat="server">
<table width="1038" border="0" align="center" cellpadding="0" cellspacing="0" class="layoute">
  <tr>
    <td height="49px" valign="middle" class="foote"><img src="imgs/logo.gif" width="100px" height="49px"  border="0"/>丽军数码摄影器材维修中心<div style="position:absolute; right:20px; bottom:26px;"><a href="showsea.aspx" title="点此搜索"><img src="imgs/search.gif" width="40px" height="48px" border="0" /></a></div></td>
  </tr>
   <tr>
    <td height="20" colspan="9"></td>
  </tr>  
  <tr>
  <td colspan="9" height="20"><table align="center" cellspacing="0" width="1035px">
      <tr>

     <td align="center" valign="middle" class="topbar"><a href="Default.aspx" class="ht">网站首页</a></td>
    <td   align="center" valign="middle" class="topbar"><a href="show.aspx" class="ht">配件展示</a></td>
    <td  align="center" valign="middle" class="topbar"><a href="error.aspx" class="ht">常见故障</a></td>
    <td   align="center" valign="middle" class="topbar"><a href="fix.aspx" class="ht">报修流程</a></td>
    <td  align="center" valign="middle" class="ht" bgcolor="#E96800">业界新闻</td>
    <td  align="center" valign="middle" class="topbar"><a href="shop.aspx" class="ht">网店介绍</a></td>
   <td  align="center" valign="middle" class="topbar"> <a href="staff.aspx" class="ht">人才招聘</a></td>
    <td  align="center" valign="middle" class="topbar"><a href="messages.aspx" class="ht">网上留言</a></td>
    <td   align="center" valign="middle" class="topbar"><a href="connect.aspx" class="ht">联系我们</a></td> </tr>
      </table>
      </td>
    
  </tr> 
  <tr>
    <td colspan="9" align="center" valign="middle" cellpadding="0">
<table width="100%" border="0" cellspacing="0" cellpadding="12">
      <tr>
        <td colspan="9" align="middle" valign="middle"><img src="imgs/class/img5.gif" width="200" height="194" /><div id="title" runat="server">业界新闻</div></td>
        </tr>
          <tr>
            <td rowspan="2" align="left" valign="top" bgcolor="#FFFFFF" style="width:75%;">
                <asp:GridView ID="gvart" runat="server" AllowPaging="True" PageSize="20"
                    AutoGenerateColumns="False" CellPadding="4"  GridLines="None" 
                    Width="100%" DataSourceID="SqlDataSource1"  
                    ShowHeader="False" HorizontalAlign="Left" 
                    BorderColor="#E3EAEB" BorderStyle="Solid" BorderWidth="1px" CssClass="bbs"                   
                   >
                                                          <PagerSettings Mode="Numeric"
                                                               PageButtonCount="5" />
                                                          <RowStyle BackColor="#E3EAEB" CssClass="bbs"  ForeColor="#333333"
                        Height="40px" />
                                        <Columns>
                        <asp:TemplateField ShowHeader="False">
                            <ItemTemplate>
                                <asp:HyperLink ID="HyperLink1" runat="server" 
                                    NavigateUrl='<%# Eval("artid", "detail.aspx?id={0}") %>' 
                                    Text='<%# Eval("artitle")%>' 
                                                                          ></asp:HyperLink>
                            </ItemTemplate>                       
                            <ControlStyle CssClass="bbs" />
                            <ItemStyle CssClass="bbs" />
                        </asp:TemplateField>
                    </Columns>                   
                    <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                    <PagerStyle HorizontalAlign="Center" CssClass="pager" BackColor="#E3EAEB" Width="100%" />
                    <EmptyDataTemplate>
                        还没有文章哦！
                                            </EmptyDataTemplate>              
                  

                    <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                    <EditRowStyle BackColor="#7C6F57" />
                    <AlternatingRowStyle BackColor="White" CssClass="bbs" Height="30px" ForeColor="#333333" />
                  
                  
                </asp:GridView>
                <br />
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:lijunConnectionString %>"
                    SelectCommand="SELECT * FROM [Article] order by [artid] desc">
                </asp:SqlDataSource>
              </td>
            <td align="center" style=" vertical-align:top; text-align:left; padding:20px;" bgcolor="#FFFFFF">
          <asp:Calendar ID="Calendar1" runat="server" BackColor="White" 
                    BorderColor="#E4C25C" CellPadding="4" DayNameFormat="Shortest" 
                    Font-Names="Verdana" Font-Size="Small" ForeColor="Black" Height="180px" 
                    Width="200px" onprerender="Calendar1_PreRender" ToolTip="日历" 
                    BorderStyle="Solid" NextPrevStyle-ForeColor="White">
                    <SelectedDayStyle BackColor="#FBDD9F" Font-Bold="True" ForeColor="White" />
                    <WeekendDayStyle BackColor="White" ForeColor="#CA8B09" />
                    <TodayDayStyle BackColor="#F7B835" ForeColor="White" />
                    <OtherMonthDayStyle ForeColor="#808080" />
                    <DayStyle BackColor="White" Font-Names="Arial" />
                    <NextPrevStyle VerticalAlign="Bottom" ForeColor="White" />
                    <DayHeaderStyle BackColor="#F5AC14" Font-Bold="True" Font-Size="7pt" 
                        Font-Names="宋体" ForeColor="White" />
                    <TitleStyle BackColor="#FBDD9F" Font-Bold="True" ForeColor="White" />
                </asp:Calendar>
              </td>
          </tr>
       
          <tr>
            <td align="center" valign="middle" bgcolor="#FFFFFF" style="text-align: right; vertical-align:top;">
                <asp:GridView ID="gvabl" runat="server" AutoGenerateColumns="False" 
                    CellPadding="4"    ForeColor="White" GridLines="None" AllowPaging="True" 
                    pagesize="5" style="text-align: left" HorizontalAlign="Left">
                    <RowStyle BackColor="#FFFfff" ForeColor="#ffffff" />
                    <Columns>
                        <asp:TemplateField>
                            <EditItemTemplate>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Image ID="Image1" runat="server" ImageUrl="~/imgs/unlock.gif" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:HyperLink ID="HyperLink1" runat="server" CssClass="newl" 
                                    NavigateUrl='<%# Eval("alid", "imagelist.aspx?aid={0}") %>' 
                                    Text='<%# SubStr(Eval("alname"),6) %>' ToolTip='<%#Eval("alname") %>'></asp:HyperLink>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <FooterStyle BackColor="#ffffff" Font-Bold="True"  />
                    <EmptyDataTemplate>
                        <span class="style2">没有相册！</span>
                    </EmptyDataTemplate>
                    <SelectedRowStyle BackColor="#ffffff" Font-Bold="True" ForeColor="#000000" />
                    <HeaderStyle BackColor="#ffffff" Font-Bold="True" ForeColor="White" />
                    <AlternatingRowStyle BackColor="White" />
                </asp:GridView>
          </td>
                    
          </tr>
      </table></td>
  </tr>
  <tr>
     <td  class="footer" height="40" colspan="9" bgcolor="#A1A1A1"><p>&nbsp;</p>
   <p>&nbsp;&nbsp;<asp:Label ID="Label3" runat="server" Text=""></asp:Label></p>
            <p>&nbsp;&nbsp;<a href="adminlogin.aspx" class="foot">登录后台</a>&nbsp;&nbsp;<a href="http://jsunplace.tumblr.com/" class="foot">作者博客</a>&nbsp;&nbsp;<a href="about.html" class="foot">关于本站</a></p>
</td>
  </tr>
</table>
    </form>
</body>
</html>
