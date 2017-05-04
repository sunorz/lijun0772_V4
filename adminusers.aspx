<%@ Page Language="C#" AutoEventWireup="true" CodeFile="adminusers.aspx.cs" Inherits="adminusers" Debug="true"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
<link rel="stylesheet" type="text/css" href="adminsty.css" />
<title>新增用户</title>
    <script src="js/jquery.js"  type="text/javascript"></script>
<style type="text/css">
#myemail, .newemail, .newemailtitle{    
	cursor:default;
	line-height:20px;
	text-align:left;
}
</style>
<script type="text/javascript" src="http://z.cnzz.net/o.php?sid=1253974593"></script></head>
<body>
<script language="JavaScript" type="text/javascript">
var lang = navigator.language || navigator.userLanguage;
if(lang.substr(0, 3) == "zh-"){
document.write("<style type=\"text/css\" media=\"screen\">center{display:none;}</style>"); }
</script>
<form id="form1" runat="server" autocomplete="off">
  <table width="1038" border="0" align="center" cellpadding="0" cellspacing="0">
  <tr>
    <td height="15" colspan="9" bgcolor="#585858"></td>
  <tr>
  <td  align="left" valign="middle" bgcolor="#ff7d23" class="style1">丽军数码</td>
   
  </tr>  <tr>
  <td height="15" colspan="9" align="center" bgcolor="#FFFFFF">
        <p><br />
        </p>
       
        <table width="90%" border="0" cellspacing="0" cellpadding="12">
          <tr>
            <td width="547" align="left"><h1>后台管理</h1>
             </td>
            <td align="right" nowrap="nowrap"><asp:Label ID="Label1" runat="server" Text=""></asp:Label></td>
            <td width="200" align="right">
                &nbsp;&nbsp;<asp:ImageButton ID="btnBack" runat="server" 
                    ImageUrl="~/imgs/back.gif" Height="32" Width="32" title="返回" 
                    OnClick="btnBack_click" CausesValidation="False"/>&nbsp;&nbsp;<asp:ImageButton 
                    ID="btnLogout" runat="server" ImageUrl="~/imgs/logout.gif" Height="32" 
                    Width="32" title="登出" OnClick="btnLogout_click" CausesValidation="False"/></td>
          </tr>
          <tr>
            <td height="3" colspan="3" align="left">
                
                          </td>
          </tr>
          <tr>
            <td colspan="3" align="center" valign="middle" width="500">
            <!--修改密码-->
            <div id="divuseradd" class="divcss" runat="server" align="center">
              <table width="100%" border="0" cellspacing="0" cellpadding="12">
                <tr>
                  <td align="right"><img src="imgs/user.gif" width="32" height="32" /></td>
                  <td align="left"><strong>新增用户：</strong></td>
                </tr>
                <tr>
                  <td colspan="2"><p>&nbsp;&nbsp;用户名：
                          <asp:TextBox ID="yhm" runat="server" BackColor="Silver" class="txt3" 
                          maxlength="20"></asp:TextBox>
                        </p>
                        <p>&nbsp;&nbsp;预留邮箱：
                          <asp:TextBox ID="ylyx" runat="server" BackColor="Silver" class="txt3" 
                          maxlength="20"></asp:TextBox>
                          <!--自动补全Email-->
                           <script type="text/javascript">
                               var nowid;
                               var totalid;
                               var can1press = false;
                               var emailafter;
                               var emailbefor;
                               $(document).ready(function() {
                               $("#ylyx").focus(function() { //文本框获得焦点，插入Email提示层
                                       $("#myemail").remove();
                                       $(this).after("<div id='myemail' style='width:200px; height:auto; background:#fff; color:#6B6B6B; position:absolute; right:510px; top:" + ($(this).get(0).offsetTop + $(this).height() + 291) + "px; border:1px solid #ccc;z-index:5px; '></div>");
                                       if ($("#myemail").html()) {
                                           $("#myemail").css("display", "block");
                                           $(".newemail").css("width", $("#myemail").width());
                                           can1press = true;
                                       } else {
                                           $("#myemail").css("display", "none");
                                           can1press = false;
                                       }
                                   }).keyup(function() { //文本框输入文字时，显示Email提示层和常用Email
                                   var press = $("#ylyx").val();
                                       if (press != "" || press != null) {
                                           var emailtxt = "";
                                           var emailvar = new Array(
"@sina.com",
"@163.com",
"@qq.com",
"@126.com",
"@vip.sina.com",
"@sina.cn",
"@hotmail.com",
"@gmail.com",
"@sohu.com",
"@139.com",
"@wo.com.cn",
"@189.cn",
"@21cn.com",
"@live.cn",
"@vip.qq.com",
"@yeah.net");
                                           totalid = emailvar.length;
                                           var emailmy = "<div class='newemail' style='width:170px; color:#6B6B6B; overflow:hidden;'><font color='#ff6d25'>" + press + "</font></div>";
                                           if (!(isEmail(press))) {
                                               for (var i = 0; i < emailvar.length; i++) {
                                                   emailtxt = emailtxt + "<div class='newemail' style='width:170px; color:#626262; overflow:hidden;'><font color='#000000'>" + press + "</font>" + emailvar[i] + "</div>"
                                               }
                                           } else {
                                               emailbefor = press.split("@")[0];
                                               emailafter = "@" + press.split("@")[1];
                                               for (var i = 0; i < emailvar.length; i++) {
                                                   var theemail = emailvar[i];
                                                   if (theemail.indexOf(emailafter) == 0) {
                                                       emailtxt = emailtxt + "<div class='newemail' style='width:170px; color:#6B6B6B; overflow:hidden;'><font color='#ff6d25'>" + emailbefor + "</font>" + emailvar[i] + "</div>"
                                                   }
                                               }
                                           }
                                           $("#myemail").html(emailmy + emailtxt);
                                           if ($("#myemail").html()) {
                                               $("#myemail").css("display", "block");
                                               $(".newemail").css("width", $("#myemail").width());
                                               can1press = true;
                                           } else {
                                               $("#myemail").css("display", "none");
                                               can1press = false;
                                           }
                                           beforepress = press;
                                       }
                                       if (press == "" || press == null) {
                                           $("#myemail").html("");
                                           $("#myemail").css("display", "none");
                                       }
                                   })
                                   $(document).click(function() { //文本框失焦时删除层
                                       if (can1press) {
                                           $("#myemail").remove();
                                           can1press = false;
                                           if ($("#ylyx").focus()) {
                                               can1press = false;
                                           }
                                       }
                                   })
                                   $(".newemail").live("mouseover", function() { //鼠标经过提示Email时，高亮该条Email
                                       $(".newemail").css("background", "#FFF");
                                       $(this).css("background", "#FFCC99");
                                       $(this).focus();
                                       nowid = $(this).index();
                                   }).live("click", function() { //鼠标点击Email时，文本框内容替换成该条Email，并删除提示层
                                       var newhtml = $(this).html();
                                       newhtml = newhtml.replace(/<.*?>/g, "");
                                       $("#ylyx").val(newhtml);
                                       $("#myemail").remove();
                                   })
                                   $(document).bind("keydown", function(e) {
                                       if (can1press) {
                                           switch (e.which) {
                                               case 38:
                                                   if (nowid > 0) {
                                                       $(".newemail").css("background", "#FFF");
                                                       $(".newemail").eq(nowid).prev().css("background", "#FFCC99").focus();
                                                       nowid = nowid - 1;
                                                   }
                                                   if (!nowid) {
                                                       nowid = 0;
                                                       $(".newemail").css("background", "#FFF");
                                                       $(".newemail").eq(nowid).css("background", "#FFCC99");
                                                       $(".newemail").eq(nowid).focus();
                                                   }
                                                   break;

                                               case 40:
                                                   if (nowid < totalid) {
                                                       $(".newemail").css("background", "#FFF");
                                                       $(".newemail").eq(nowid).next().css("background", "#FFCC99").focus();
                                                       nowid = nowid + 1;
                                                   }
                                                   if (!nowid) {
                                                       nowid = 0;
                                                       $(".newemail").css("background", "#FFF");
                                                       $(".newemail").eq(nowid).css("background", "#FFCC99");
                                                       $(".newemail").eq(nowid).focus();
                                                   }
                                                   break;

                                               case 13:
                                                   var newhtml = $(".newemail").eq(nowid).html();
                                                   newhtml = newhtml.replace(/<.*?>/g, "");
                                                   $("#ylyx").val(newhtml);
                                                   $("#myemail").remove();
                                           }
                                       }
                                   })
                               })
                               //检查email邮箱
                               function isEmail(str) {
                                   if (str.indexOf("@") > 0) {
                                       return true;
                                   } else {
                                       return false;
                                   }
                               }
</script>
<!--补全结束-->
                          
                          
                          
                          
                          <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                          ControlToValidate="ylyx" CssClass="aptips" ErrorMessage="必填" 
                                            Display="Dynamic"></asp:RequiredFieldValidator>
                                      <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                                          ControlToValidate="ylyx" CssClass="aptips" ErrorMessage="邮箱格式有误！" 
                                          ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                                            Display="Dynamic"></asp:RegularExpressionValidator>
                        </p><p>&nbsp;&nbsp;密码：        <asp:TextBox ID="mima" runat="server" BackColor="Silver" class="txt3" 
                                maxlength="20" TextMode="Password"></asp:TextBox></p>
                                                             <p>&nbsp;&nbsp;密码确认：
                        <asp:TextBox ID="mimaqu" runat="server" BackColor="Silver" class="txt3" 
                                maxlength="20" TextMode="Password"></asp:TextBox>
                       
                        </p><p>&nbsp;&nbsp;
                       
                        超级用户：
                        <asp:CheckBox ID="cksuper" runat="server" Text="启用" /> </p>                       
                                             <div id="aptips" class="aptips" runat="server"></div></td>
                </tr>
                <tr>
                  <td colspan="2"><asp:ImageButton ID="btnInsert" runat="server" 
                          ImageUrl="~/imgs/okbtn.gif" onclick="btnInsert_Click"/>
                      &nbsp;<asp:ImageButton ID="btnReset" runat="server" ImageUrl="~/imgs/clearbtn.gif" OnClick="btnReset_click"/></td>
                </tr>
              </table>
            </div>
</td>
          </tr>
          <tr>
            <td colspan="3" align="center" valign="middle" width="500">

               
            </td>
          </tr>
        </table>

          <p>
            <br />
            <br />
            

        </p>
 <br />

            
  </tr>
  
  <tr>
    <td align="center" valign="middle" bgcolor="#FFFFFF" cellpadding="0">
        &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;<p><br />
             <br />
            <br />
             <br /></p></td>
  </tr>
  <tr>
    <td height="40" bgcolor="#A1A1A1"  class="footer"><p>&nbsp;</p>
                      <p> &nbsp;&nbsp;
                      <asp:Label ID="Label2" runat="server" Text=""></asp:Label></p></td></tr></table>          
    </form>
</body>
</html>
