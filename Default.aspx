<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Default" Debug="true" %>
<%@ Register src="gotop.ascx" tagname="gotop" tagprefix="uc2" %>
<%@ Register src="articlelist.ascx" tagname="articlelist" tagprefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>	
<meta name="google-site-verification" content="Vb_KbImWMfnVIppibLDoQ_Z9wpyzbCbu21q0rX6w8as" />
<meta name="keywords" content="柳州修相机，丽军数码，相机维修，数码相机维修，修相机，修理相机，修照相机，传统相机，相机配件"/>
<meta name="description" content="柳州修相机，丽军数码，柳州专业快速维修各种品牌数码相机（佳能、三星、索尼、宾德、尼康、理光）、传统相机、闪光灯、清洗镜头、高价回收各种二手数码相机" />
<meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
<link rel="stylesheet" type="text/css" href="style.css" />
<title>丽军数码-柳州相机维修中心</title>
<style type="text/css">
#pic{ width:100%;} 
#words{ position:absolute; 
left:50%;   
margin-left:-517px;  /*设置为宽度的一半*/
top:20px;
  }

a:link {text-decoration: none;
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

    .style2
    {
        font-size: 1.5em;
        font-family: 宋体, Arial, Helvetica, sans-serif;
        color: #FFFFFF; letter-spacing:0.3em;
    }
    </style>
<script type="text/javascript" src="http://z.cnzz.net/o.php?sid=1253974593"></script></head>
<body>
<script language="JavaScript" type="text/javascript">
var lang = navigator.language || navigator.userLanguage;
if(lang.substr(0, 3) == "zh-"){
document.write("<style type=\"text/css\" media=\"screen\">center{display:none;}</style>"); }
</script>

<form id="form1" runat="server">
<div id="words">
<table align="center" width="1035px" border="0" cellspacing="0" cellpadding="0" style="height:500px;text-align: center; " >
  <tr>
    <td colspan="8"><div style="float:left; padding:20px;">
        <asp:Image ID="Image3" runat="server" />
        </div>
        <span class="style2">丽军数码摄影器材维修中心</span><br />
        <br />
        <div id="intro" runat="server" style="color:White; font-size:medium; line-height:2em; text-align:left;"></div>
         <br />
        <asp:ImageButton ID="ImageButton1" runat="server"   
            ImageUrl="~/imgs/class/more.gif" onclick="ImageButton1_Click" 
            ToolTip="了解更多" />
        <br />
      </td>
  </tr>
   <tr height="40">

    
    <td   align="center" valign="middle" class="topbar"><a href="show.aspx" class="ht">配件展示</a></td>
    <td  align="center" valign="middle" class="topbar"><a href="error.aspx" class="ht">常见故障</a></td>
    <td   align="center" valign="middle" class="topbar"><a href="fix.aspx" class="ht">报修流程</a></td>
     <td align="center" valign="middle" class="topbar"><a href="bbs.aspx" class="ht">业界新闻</a></td>
     <td  align="center" valign="middle" class="topbar"><a href="shop.aspx" class="ht">网店介绍</a></td>
   <td  align="center" valign="middle" class="topbar"> <a href="staff.aspx" class="ht">人才招聘</a></td>
    <td  align="center" valign="middle" class="topbar"><a href="messages.aspx" class="ht">网上留言</a></td>
    <td   align="center" valign="middle" class="topbar"><a href="connect.aspx" class="ht">联系我们</a></td> </tr>
  
</table>
<br />
    <div runat="server" 
        style="text-align: left; font-size: small; color: #FFFFFF; line-height:5px; width:700px; float:left;">友情链接：
        <a class="foot" href="http://www.lzsm168.com/" target="_blank">汇达数码</a>&nbsp; 
        <a class="foot" href="messages.aspx" target="_blank">[交换链接]</a>&nbsp;<br />
     <p><asp:Label ID="Label3" runat="server" Text="" ></asp:Label></p>
      <p><a href="adminlogin.aspx" class="foot">登录后台</a>&nbsp;&nbsp;<a href="http://jsunplace.tumblr.com/" class="foot">作者博客</a>&nbsp;&nbsp;<a href="about.html" class="foot">关于本站</a>&nbsp;&nbsp;<script type="text/javascript">                              var cnzz_protocol = (("https:" == document.location.protocol) ? " https://" : " http://"); document.write(unescape("%3Cspan id='cnzz_stat_icon_1253756923'%3E%3C/span%3E%3Cscript src='" + cnzz_protocol + "s4.cnzz.com/z_stat.php%3Fid%3D1253756923%26show%3Dpic1' type='text/javascript'%3E%3C/script%3E"));</script></p></div>
      
      <div style="float:right; width:250px;">
          <asp:Image ID="Image1" runat="server" AlternateText="微信" BorderStyle="None" 
              Height="100px" ToolTip="微信" Width="100px"  ImageUrl="~/imgs/class/qrcodewx.jpg" />&nbsp;&nbsp;<asp:Image 
              ID="Image2" runat="server" AlternateText="QQ" BorderStyle="None" 
              Height="100px" ImageUrl="~/imgs/class/qrcodeqq.jpg" ToolTip="QQ" 
              Width="100px" /></div></div> </form>
              
</body>
</html>