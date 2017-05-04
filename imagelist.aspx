<%@ Page Language="C#" AutoEventWireup="true" CodeFile="imagelist.aspx.cs" Inherits="imagelist" Debug="true"%>
<%@ Register src="gotop.ascx" tagname="gotop" tagprefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
<link rel="stylesheet" type="text/css" href="style.css" />
<link href="lanrenzhijia.css" type="text/css" rel="stylesheet" />
<title>丽军数码-业界新闻</title>
    <style type="text/css">
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
}
.pager
 {
     width:100%;  margin:10px; line-height:20px; display:block;
    
 }
.pager a, .pager span
 {

    border: 1px solid #F59223; 
    line-height: 30px;
    margin-right: 5px;
    padding: 2px 6px;
    background-color:White;color:#F59223;
 }
.pager a:hover
 {border:1 solid #F59223; background-color:#F59223; color:White;  padding: 2px 6px;}
.pager .current
{
     border: 1px solid #F59223; 
    line-height: 20px;
    margin: 0 5px;
    padding: 2px 6px;
    background-color:#F59223;color:White;
}

    </style>
<script type="text/javascript" src="http://z.cnzz.net/o.php?sid=1253974593"></script></head>
<body>
<div id="apDiv2" class="toplnk"><uc1:gotop ID="gotop1" runat="server" /></div>
<script language="JavaScript" type="text/javascript">
    var lang = navigator.language || navigator.userLanguage;
    if (lang.substr(0, 3) == "zh-") {
        document.write("<style type=\"text/css\" media=\"screen\">center{display:none;}</style>");
    }
</script>
    <form id="form1" runat="server">
<table width="1038" border="0" align="center" cellpadding="0" cellspacing="0" class="layoute">
  <tr>
    <td height="49px" valign="middle" class="foote"><img src="imgs/logo.gif" width="100px" height="49px"  border="0"/>丽军数码摄影器材维修中心<div style="position:absolute; right:20px; bottom:16px;"><a href="showsea.aspx" title="点此搜索"><img src="imgs/search.gif" width="40" height="48" border="0" /></a></div></td>
  </tr>
  <tr>
    <td height="20" colspan="9"></td>
  </tr>  
  <tr>
  <td colspan="9" height="20"><table align="center" cellspacing="0" width="1035px">
      <tr>
     <td align="center" valign="middle" class="topbar"><a href="Default.aspx"  class="ht">网站首页</a></td>
    <td align="center" valign="middle" class="topbar"><a href="show.aspx"  class="ht">配件展示</a></td>
    <td align="center" valign="middle" class="topbar"><a href="error.aspx"  class="ht">常见故障</a></td>
    <td align="center" valign="middle" class="topbar"><a href="fix.aspx"  class="ht">报修流程</a></td>
    <td  align="center" valign="middle" class="ht" bgcolor="#E96800">业界新闻</td>
    <td  align="center" valign="middle" class="topbar"><a href="shop.aspx" class="ht">网店介绍</a></td>
   <td  align="center" valign="middle" class="topbar"> <a href="staff.aspx" class="ht">人才招聘</a></td>
    <td  align="center" valign="middle" class="topbar"><a href="messages.aspx" class="ht">网上留言</a></td>
    <td   align="center" valign="middle" class="topbar"><a href="connect.aspx" class="ht">联系我们</a></td></tr>
      </table>
      </td>
    
  </tr>  
  <tr>
    <td colspan="9" align="center" valign="middle" cellpadding="0">
<table width="100%" border="0" cellspacing="0" cellpadding="12">
      <tr>
        <td colspan="9" align="middle" valign="middle"><a href="bbs.aspx" title="论坛首页">
            <img src="imgs/class/img5.gif" width="200" height="194" 
                border="0"  /></a><div id="title" runat="server">业界新闻</div></td>
      </tr>
  <tr bgcolor="#FFFFFF">
            <td>&nbsp;</td>
            <td align="right"><asp:ImageButton ID="btnBack" runat="server" ImageUrl="~/imgs/back.gif" Height="32" Width="32" title="返回" OnClick="btnBack_click"/></td>

          </tr>
          <tr bgcolor="#FFFFFF">
            <td rowspan="2" align="left" valign="top">
 <asp:Label ID="Label1" runat="server" Text=""></asp:Label><p id="share" runat="server"><div class="bshare-custom"><div class="bsPromo bsPromo2"></div><a title="分享到新浪微博" class="bshare-sinaminiblog"></a><a title="分享到腾讯微博" class="bshare-qqmb"></a><a title="分享到i贴吧" class="bshare-itieba" href="javascript:void(0);"></a><a title="分享到Facebook" class="bshare-facebook" href="javascript:void(0);"></a><a title="分享到Twitter" class="bshare-twitter" href="javascript:void(0);"></a><a title="更多平台" class="bshare-more bshare-more-icon more-style-addthis"></a><span class="BSHARE_COUNT bshare-share-count" style="float: none;"></span></div><script type="text/javascript" charset="utf-8" src="http://static.bshare.cn/b/buttonLite.js#style=-1&amp;uuid=&amp;pophcol=3&amp;lang=zh"></script><script type="text/javascript" charset="utf-8" src="http://static.bshare.cn/b/bshareC0.js"></script></p>
                
<div id="content"><asp:ListView ID="ListView1" runat="server" DataKeyNames="poid" 
                    DataSourceID="SqlDataSource1" GroupItemCount="3" 
                   >
                    <EmptyItemTemplate>
                        <td id="Td2" runat="server" width="200px" height="300px" 
                                style="background-color:#FFFFFF;color: #000000; text-align: center;">
                                <br />                              
                                <br />
                                <br />
                            </td>
                        </EmptyItemTemplate>
                        <ItemTemplate>
                            <td id="Td2" runat="server" width="200px" height="300px"  
                                style="background-color:#333333;color: #FFFFFF; text-align: center; font-size:small;">
                                <br />
                                <asp:HyperLink ID="openimg" runat="server" 
                                    NavigateUrl='<%# Eval("pourl") %>' Target="_blank" ImageUrl='<%# Eval("psmurl") %>' CssClass="newl" Font-Size="small" BorderStyle="Solid" BorderWidth="1px" BorderColor="White"  ToolTip='<%#Eval("poname") %>'><%#Eval("poname") %></asp:HyperLink>
                                 <br /><p style="text-align:left;">&nbsp;
                                <span>标题:</span> 
                                <asp:Label ID="ponameLabel" runat="server" Text='<%# SubStr(Eval("poname"),10) %>' ToolTip='<%# Eval("poname") %>'/>
                                <br /><br />
                                    &nbsp; 作者:
                                <asp:Label ID="potorLabel" runat="server" Text='<%# SubStr(Eval("potor"),10) %>' ToolTip='<%#Eval("potor") %>' />
                                <br /><br />&nbsp; 上传时间:
                                <asp:Label ID="potimeLabel" runat="server" 
                                    Text='<%# Eval("potime", "{0:yyyy-M-d}") %>' /></p>
                                <br />
                                <br />
                            </td>
                        </ItemTemplate>
                        <AlternatingItemTemplate>
                            <td id="Td3" runat="server" style="background-color:#333333;color: #FFFFFF; text-align: center; font-size:small;"  width="200px" height="300px">
                                <br />
                                <asp:HyperLink ID="openimg" runat="server" ImageUrl='<%# Eval("psmurl") %>'
                                    NavigateUrl='<%# Eval("pourl") %>' CssClass="newl" Font-Size="Medium" BorderStyle="Solid" BorderWidth="1px" BorderColor="White" ToolTip='<%#Eval("poname") %>'><%#Eval("poname") %></asp:HyperLink>
                               <br /><p style="text-align:left;">&nbsp; 标题:
                                <asp:Label ID="ponameLabel" runat="server" Text='<%# SubStr(Eval("poname"),10) %>' ToolTip='<%#Eval("poname") %>'></asp:Label>
                                <br /><br />&nbsp; 作者:
                                <asp:Label ID="potorLabel" runat="server" Text='<%# SubStr(Eval("potor"),10) %>' ToolTip='<%#Eval("potor") %>'></asp:Label>
                                <br /><br />&nbsp; 上传时间:
                                <asp:Label ID="potimeLabel" runat="server" 
                                   Text='<%# Eval("potime", "{0:yyyy-M-d}") %>' ></asp:Label>  </p>                              
                                <br />
                                <br />
                            </td>
                        </AlternatingItemTemplate>
                        <EmptyDataTemplate>
                            <table id="Table1" runat="server" 
                                style="background-color: #FFFFFF;border-collapse: collapse;border-style:none;">
                                <tr id="Tr1" runat="server">
                                    <td id="Td4" runat="server" style="text-align:center">
                                        相册内没有图片！</td>
                                </tr>
                            </table>
                        </EmptyDataTemplate>
                        <LayoutTemplate>
                            <table id="Table2" runat="server">
                                <tr id="Tr2" runat="server">
                                    <td id="Td5" runat="server">
                                        <table ID="groupPlaceholderContainer" runat="server" border="0" 
                                            style=" background-color: #FFFFFF; border-color:White;font-family:Verdana, Arial, Helvetica, sans-serif;">
                                            <tr ID="groupPlaceholder" runat="server">
                                            </tr>
                                        </table>
                                    </td>
                                </tr>                               
                            </table>   
                            <table  id="Table3" runat="server">
                                                             <tr id="Tr4" runat="server">
                        <td id="Td7" runat="server">
                            <asp:DataPager ID="DataPager1" runat="server" PageSize="9" class="pager">
                                <Fields>
                                   
                                     <asp:NumericPagerField ButtonCount="5"    CurrentPageLabelCssClass="current" />
                                          
                                </Fields>
                               
                            </asp:DataPager>
                        </td>
                    </tr>
                    </table>                     
            
                        </LayoutTemplate>
                        <EditItemTemplate>                            
                        </EditItemTemplate>
                        <GroupTemplate>
                            <tr ID="itemPlaceholderContainer" runat="server">
                                <td ID="itemPlaceholder" runat="server">
                                </td>
                            </tr>
                        </GroupTemplate>
                        <SelectedItemTemplate>                           
                        </SelectedItemTemplate>
                    </asp:ListView></div>  <script src="js/jquery.min123.js"></script>
<script src="js/jquery.imgbox.pack.js"></script>
<script language="javascript" type="text/javascript">
    $(function() {
        $("a[id$='openimg']").imgbox({
            'speedIn': 0,
            'speedOut': 0,
            'alignment': 'center',
            'overlayShow': true,
            'allowMultiple': false
        });
        
    });
</script>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:lijunConnectionString %>"
                    SelectCommand="SELECT * FROM [Photo] WHERE ([alid] = @alid) order by [poid] desc">
                    <SelectParameters>
                        <asp:QueryStringParameter Name="alid" QueryStringField="aid" Type="Int32" />
                    </SelectParameters>
                </asp:SqlDataSource> 
              </td>
            <td align="center" valign="top">
              <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                  ConnectionString="<%$ ConnectionStrings:lijunConnectionString %>"
                  SelectCommand="SELECT * FROM [Album] WHERE (([alid] &lt;&gt; @alid) AND ([islock] = @islock))">
                    <SelectParameters>
                        <asp:Parameter DefaultValue="3" Name="alid" Type="Int32" />
                        <asp:Parameter DefaultValue="false" Name="islock" Type="Boolean" />
                    </SelectParameters>
                </asp:SqlDataSource>
              </td>
          </tr>
          <tr>
            <td width="25%" valign="top" bgcolor="#FFFFFF">
                <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" 
                    CellPadding="4" DataKeyNames="alid" DataSourceID="SqlDataSource2" 
                    ForeColor="White" GridLines="None" style="text-align: left" 
                    AllowPaging="True" PageSize="5">
                    <PagerSettings Mode="NextPrevious" />
                    <RowStyle BackColor="#FFFfff" ForeColor="#fffff" />
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
                    <PagerStyle BackColor="#ffffff" ForeColor="#ffffff" HorizontalAlign="Center" />
                    <EmptyDataTemplate>
                        <span>没有相册！</span>
                    </EmptyDataTemplate>
                    <SelectedRowStyle BackColor="#ffffff" Font-Bold="True" ForeColor="#000000" />
                    <HeaderStyle BackColor="#ffffff" Font-Bold="True" ForeColor="White" />
                    <AlternatingRowStyle BackColor="White" />
                </asp:GridView>
              

              </td>
          </tr>
          <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
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
