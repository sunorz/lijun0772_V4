<%@ Page Language="C#" AutoEventWireup="true" CodeFile="show.aspx.cs" Inherits="show"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
<link rel="stylesheet" type="text/css" href="style.css" />
<title>��������-���չʾ</title><script type="text/javascript" src="http://z.cnzz.net/o.php?sid=1253974593"></script>
<link href="style-157.css" rel="stylesheet" type="text/css" />
<script src="js/jquery-157.js" language="javascript" type="text/javascript"></script>
<!--[if IE 6]>
<script src="js/ie6PNG.js" type="text/javascript"></script>
<script type="text/javascript">DD_belatedPNG.fix('*');</script>
<![endif]-->


</head>
    <style type="text/css">
		#title{
	line-height:5pt;
	font-family:"����";
	font-size:20pt;
    color:#ffffff;
    line-height:40pt;
	letter-spacing:8pt;
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
    body {
	background-image: url(imgs/class/bg2.jpg);
	background-repeat: repeat;
	background-attachment: fixed;
}
    </style>
<body>
<script language="JavaScript" type="text/javascript">
    var lang = navigator.language || navigator.userLanguage;
    if (lang.substr(0, 3) == "zh-") {
        document.write("<style type=\"text/css\" media=\"screen\">center{display:none;}</style>");
    }
</script>
    <form id="form1" runat="server">
<table width="1038" border="0" align="center" cellpadding="0" cellspacing="0">
   <tr>
     <td height="49px" valign="middle" class="foote"><img src="imgs/logo.gif" width="100px" height="49px"  border="0"/>����������Ӱ����ά������<div style="position:absolute; right:20px; bottom:16px;"><a href="showsea.aspx" title="�������"><img src="imgs/search.gif" width="40" height="48" border="0" /></a></div></td>
  </tr>
  <tr>
    <td height="20" colspan="9"></td>
  </tr>  
  <tr>
  <td colspan="9" height="20"><table align="center" cellspacing="0" width="1035px">
      <tr>
     <td  align="center" valign="middle" class="topbar"><a href="Default.aspx" class="ht">
         ��վ��ҳ</a></td>
    <td   align="center" valign="middle"  class="ht" bgcolor="#E96800">���չʾ</td>
    <td  align="center" valign="middle" class="topbar"><a href="error.aspx" class="ht">
        ��������</a></td>
    <td   align="center" valign="middle" class="topbar"><a href="fix.aspx" class="ht">
        ��������</a></td>
    <td  align="center" valign="middle" class="topbar"><a href="bbs.aspx" class="ht">
        ҵ������</a></td>
    <td  align="center" valign="middle" class="topbar"><a href="shop.aspx" class="ht">
        �������</a></td>
   <td  align="center" valign="middle" class="topbar"> <a href="staff.aspx" class="ht">
       �˲���Ƹ</a></td>
    <td  align="center" valign="middle" class="topbar"><a href="messages.aspx" class="ht">
        ��������</a></td>
    <td   align="center" valign="middle" class="topbar"><a href="connect.aspx" class="ht">
        ��ϵ����</a></td></tr>
      </table>
      </td>    
  </tr> 
     <tr>
    <td colspan="9" align="center" valign="middle">
<table width="100%" border="0" cellspacing="0" cellpadding="12">
<tr>
<td colspan="9" align="middle" valign="middle">
        <img src="imgs/class/img2.gif" width="200" height="194"  /><div id="title" runat="server">
            ���չʾ</div></td>
        </tr>
  <tr>
    <td colspan="9" align="center" bgcolor="White">
        <table width="100%" border="0" cellspacing="0" cellpadding="12">
          <tr>
            <td align="center" bgcolor="White">
                <div class="kePublic">
<!--Ч��html��ʼ-->
<div class="mkeFocus">
 <div class="mkeUl">
  <ul>
      <%=getItems()%>

  </ul>
  <div class="mkeNum"><span class="mke_ns1">1</span><span class="mke_ns2">1</span></div>
  <div class="mkeLbtn"></div>
  <div class="mkeRbtn"></div>
 </div>
</div>
<script language="javascript">
    var rnum = $(".mkeUl ul li").size();
    var cnum = 0;
    $(".mke_ns2").html(rnum);
    $(".mkeUl ul").width(rnum * 588);
    $(".mkeRbtn").click(function() {
        cnum++;
        if (cnum > (rnum - 1)) {
            cnum = 0
        }
        $(".mkeUl ul").animate({ "left": -cnum * 588 }, 300);
        $(".mke_ns1").html(cnum + 1);
    });
    $(".mkeLbtn").click(function() {
        cnum--;
        if (cnum < 0) {
            cnum = rnum - 1;
        }
        $(".mkeUl ul").animate({ "left": -cnum * 588 }, 300);
        $(".mke_ns1").html(cnum + 1);
    });

    function autoPlay() {
        cnum++;
        if (cnum > (rnum - 1)) {
            cnum = 0
        }
        $(".mkeUl ul").animate({ "left": -cnum * 588 }, 300);
        $(".mke_ns1").html(cnum + 1);
    }

    var Timer = setInterval(autoPlay, 5000);
    $(".mkeFocus").hover(function() { clearInterval(Timer) }, function() { Timer = setInterval(autoPlay, 5000); });

</script>
<!--Ч��html����-->
</div>
              <div class="bshare-custom"><div class="bsPromo bsPromo2"></div><a title="��������΢��" class="bshare-sinaminiblog"></a><a title="������Ѷ΢��" class="bshare-qqmb"></a><a title="����i����" class="bshare-itieba" href="javascript:void(0);"></a><a title="����Facebook" class="bshare-facebook" href="javascript:void(0);"></a><a title="����Twitter" class="bshare-twitter" href="javascript:void(0);"></a><a title="����ƽ̨" class="bshare-more bshare-more-icon more-style-addthis"></a><span class="BSHARE_COUNT bshare-share-count" style="float: none;">
                  </span></div><script type="text/javascript" charset="utf-8" src="http://static.bshare.cn/b/buttonLite.js#style=-1&amp;uuid=&amp;pophcol=3&amp;lang=zh"></script><script type="text/javascript" charset="utf-8" src="http://static.bshare.cn/b/bshareC0.js"></script></td>
          </tr>
          </table> </table>   
        <br />
        <br />
      
      </td>
  </tr>
  <tr>
    <td height="40" colspan="9" class="footer">
           <p>&nbsp;&nbsp;<asp:Label ID="Label3" runat="server" Text="Label"></asp:Label></p>
      <p>&nbsp;&nbsp;<a href="adminlogin.aspx" class="foot">��¼��̨</a>&nbsp;&nbsp;<a href="http://jsunplace.tumblr.com/" class="foot">���߲���</a>&nbsp;&nbsp;<a href="about.html" class="foot">���ڱ�վ</a></p>
  </td>
  </tr>
</table>
    </form>
</body>
</html>
