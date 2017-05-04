<%@ Page Language="C#" AutoEventWireup="true" CodeFile="diycnt.aspx.cs" Inherits="diycnt" validateRequest="false"  Debug="true"%>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<script type="text/javascript" src="ckeditor/ckeditor.js"></script>
<meta http-equiv="Content-Type" content="text/html" />
<link rel="stylesheet" type="text/css" href="adminsty.css" />
<title>板块更新</title>
<script type="text/javascript" src="http://z.cnzz.net/o.php?sid=1253974593"></script></head><body>
<script language="JavaScript" type="text/javascript">
    var lang = navigator.language || navigator.userLanguage;
    if (lang.substr(0, 3) == "zh-") {
        document.write("<style type=\"text/css\" media=\"screen\">center{display:none;}</style>");
    }
</script>
<form id="form1" runat="server">
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
                &nbsp;&nbsp;<asp:ImageButton ID="btnBack" runat="server" ImageUrl="~/imgs/back.gif" Height="32" Width="32" title="返回" OnClick="btnBack_click"/>
                &nbsp;<asp:ImageButton ID="btnLogout" runat="server" ImageUrl="~/imgs/logout.gif" Height="32" Width="32" title="登出" OnClick="btnLogout_click"/></td>
          </tr>
          <tr>
            <td height="3" colspan="3" align="center"><div id="divcnt" class="divcss" runat="server" align="center">
              
              <table width="100%" border="0" cellspacing="0" cellpadding="12">
                <tr>
                  <td align="right" valign="middle"><img src="imgs/seting.gif" width="32" height="32" /></td>
                  <td align="left"><strong>文本区：</strong></td>
                </tr>
                <tr>
                  <td colspan="2" align="center" valign="top" class="txt3">更新模块：<asp:DropDownList 
                          ID="ddlclasstxt" runat="server" BackColor="Silver" CssClass="txt3">
                      <asp:ListItem Value="1">中心简介</asp:ListItem>
                      <asp:ListItem Value="2">常见故障</asp:ListItem>
                      <asp:ListItem Value="3">报修流程</asp:ListItem>
                      <asp:ListItem Value="4">网店介绍</asp:ListItem>
                      <asp:ListItem Value="5">人才招聘</asp:ListItem>
                      <asp:ListItem Value="6">联系我们</asp:ListItem>
                      </asp:DropDownList>
                                          <br />
                      <div id="aptips" class="aptips" runat="server"></div><br />
                                              标题：<asp:TextBox ID="txttitle" runat="server" 
                          BackColor="Silver" CssClass="txt3" MaxLength="10" Width="162px"></asp:TextBox>
                                              <br />
                      <br />文章内容：
                      <p> 
                                              <asp:TextBox ID="content" runat="server" AutoPostBack="True" Height="320px" 
                        TextMode="MultiLine" Width="100%" class="ckeditor" ></asp:TextBox>
                                        <script type="text/javascript">
        CKEDITOR.replace('<%= content.ClientID %>'); 
</script></p>
                                          </td>
                </tr>
                <tr>
                  <td colspan="2" align="center">
<asp:Button ID="btnPost" runat="server" class="txt3" Text="更新" 
                    BackColor="#FF7D23" BorderStyle="Solid" Font-Bold="True" 
                    ForeColor="White" BorderColor="#FF7D23" OnClick="btnPost_Click" />&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnReset" runat="server" class="txt3" Text="清除" 
                    BackColor="#FF7D23" BorderStyle="Solid" Font-Bold="True" 
                    ForeColor="White" BorderColor="#FF7D23" OnClick="btnReset_Click" />
                    
                    </td>
                </tr>
              </table>
            </div>
                
                          </td>
          </tr>
          <tr> 
            <td colspan="3" align="center" valign="middle"><div id="divfooter" class="divcss" runat="server" align="center">
              <table width="100%" border="0" cellspacing="0" cellpadding="12" align="center">
                <tr>
                  <td align="right" valign="middle"><img src="imgs/seting.gif" alt="" width="32" height="32" /></td>
                  <td align="left"><strong>页脚：</strong></td>
                </tr>
                <tr>
                  <td colspan="2" align="center" valign="top" class="txt3"><br />
                      <div id="aptips3" class="aptips" runat="server"></div><br />
                      <br />
                    <asp:TextBox ID="tbfooter" runat="server" 
                          Width="580px" BackColor="Silver" CssClass="txt3" Rows="5" 
                          TextMode="MultiLine"></asp:TextBox></td>
                </tr>
                <tr>
                  <td colspan="2" align="center">
                                <asp:Button ID="btnPost2" runat="server" class="txt3" Text="发表" 
                    BackColor="#FF7D23" BorderStyle="Solid" Font-Bold="True" 
                    ForeColor="White" BorderColor="#FF7D23" OnClick="btnPost2_Click" />
                                &nbsp;&nbsp;&nbsp;
                                <asp:Button ID="btnRsst" runat="server" class="txt3" Text="清除" 
                    BackColor="#FF7D23" BorderStyle="Solid" Font-Bold="True" 
                    ForeColor="White" BorderColor="#FF7D23" OnClick="btnRsst_Click" />
                                </td>
                </tr>
              </table>
            </div></td>
          </tr>
        </table>

          <p>
            <br />
            <br />
            

        </p>
 <br />


  <tr>
    <td align="center" valign="middle" bgcolor="#FFFFFF" cellpadding="0">
        &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;<p><br />
             <br />
            <br />
             <br /></p></td>
  </tr>
  <tr>
    <td height="40" bgcolor="#A1A1A1"  class="footer"><p>&nbsp;</p>
                  <p> &nbsp;&nbsp;<asp:Label ID="Label3" runat="server" Text=""></asp:Label></p>
              </td></tr></table>          
    </form>
</body>
</html>
