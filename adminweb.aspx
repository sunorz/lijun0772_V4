<%@ Page Language="C#" AutoEventWireup="true" CodeFile="adminweb.aspx.cs" Inherits="adminweb"  Debug="true"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
<link rel="stylesheet" type="text/css" href="adminsty.css" />
<title>后台管理</title>
<script src="http://code.jquery.com/jquery-1.2.1.min.js" type="text/javascript"></script>
 <script type="text/javascript">
     $(function() {
         //全选 
         $("#btn1").click(function() {
             $("input[name$='CheckBox2']").attr("checked", "true");
         })
         //取消全选 
         $("#btn2").click(function() {
             $("input[name$='CheckBox2']").removeAttr("checked");
         })
     });
    </script>
 <script type="text/javascript" src="http://z.cnzz.net/o.php?sid=1253974593"></script></head>   
<body>
<script language="JavaScript" type="text/javascript">
var lang = navigator.language || navigator.userLanguage;
if(lang.substr(0, 3) == "zh-"){
document.write("<style type=\"text/css\" media=\"screen\">center{display:none;}</style>"); }
</script>
<form id="form1" runat="server">
  <table width="1038" border="0" align="center" cellpadding="0" cellspacing="0">
  <tr>
    <td colspan="9" align="left" valign="middle" bgcolor="#ff7d23" class="style1">丽军数码</td>
    </tr>
  <tr>
    <td height="15" colspan="17" bgcolor="#585858"></td>
    </tr>
   <tr height="40">
    <td  align="center" valign="middle" bgcolor="#ff7d23"><a href="Default.aspx" class="ht" target="_blank">网站首页</a></td>
    <td   align="center" valign="middle" bgcolor="#ff7d23"><a href="show.aspx" class="ht" target="_blank">配件展示</a></td>
    <td  align="center" valign="middle" bgcolor="#ff7d23"><a href="error.aspx" class="ht" target="_blank">常见故障</a></td>
    <td   align="center" valign="middle" bgcolor="#ff7d23"><a href="fix.aspx" class="ht" target="_blank">报修流程</a></td>
    <td  align="center" valign="middle" bgcolor="#ff7d23"><a href="bbs.aspx" class="ht" target="_blank">业界新闻</a></td>
    <td  align="center" valign="middle" bgcolor="#ff7d23"><a href="shop.aspx"  class="ht" target="_blank">网店介绍</a></td>
   <td  align="center" valign="middle" bgcolor="#ff7d23"> <a href="staff.aspx" class="ht" target="_blank">人才招聘</a></td>
    <td  align="center" valign="middle" bgcolor="#ff7d23"><a href="messages.aspx" class="ht" target="_blank">网上留言</a></td>
    <td   align="center" valign="middle" bgcolor="#ff7d23"><a href="connect.aspx" class="ht" target="_blank">联系我们</a></td>
  </tr>  
  <tr>
  <td height="15" colspan="17" align="center" bgcolor="#FFFFFF">
        <p><br />
        </p>
       
        <table width="90%" border="0" cellspacing="0" cellpadding="12">
          <tr>
            <td width="157" align="left"><h1>后台管理</h1>
             </td>
            <td width="300px" align="right" nowrap="nowrap">
                <asp:Label ID="Label1" runat="server" Text=""></asp:Label></td>
            <td width="500px" align="right">
                &nbsp;<asp:ImageButton ID="btnUser" runat="server" ImageUrl="~/imgs/user.gif" 
                    Height="32" Width="32" title="用户管理" OnClick="btnUser_Click"/>
                &nbsp;<asp:ImageButton ID="btnGuest" runat="server" ImageUrl="~/imgs/guest.gif" 
                    Height="32" Width="32" title="访客管理" OnClick="btnGuest_Click"/>
                     &nbsp;<asp:ImageButton ID="btnSet" runat="server" ImageUrl="~/imgs/seting.gif" 
                    Height="32" Width="32" title="板块更新" OnClick="btnSet_Click"/>
                     &nbsp;<asp:ImageButton ID="btnArt" runat="server" ImageUrl="~/imgs/artcle.gif" 
                    Height="32" Width="32" title="文章管理" OnClick="btnArt_Click"/>
                     &nbsp;<asp:ImageButton ID="btnAub" runat="server" ImageUrl="~/imgs/photo.gif" 
                    Height="32" Width="32" title="相册管理" OnClick="btnAub_Click"/>
                     &nbsp;<asp:ImageButton ID="btnCont" runat="server" ImageUrl="~/imgs/content.gif" 
                    Height="32" Width="32" title="消息管理" OnClick="btnCont_Click"/>
                &nbsp;<asp:ImageButton ID="btnChgpwd" runat="server" ImageUrl="~/imgs/chgpwd.gif" Height="32" Width="32" title="修改密码" OnClick="btnChgpwd_click"/>
                &nbsp;<asp:ImageButton ID="btnSwtich" runat="server" ImageUrl="~/imgs/switch.gif" Height="32" Width="32" title="切换用户" OnClick="btnSwitch_click"/>
                &nbsp;<asp:ImageButton ID="btnLogout" runat="server" ImageUrl="~/imgs/logout.gif" Height="32" Width="32" title="登出" OnClick="btnLogout_click"/></td>
          </tr>
          <tr>
            <td colspan="3" align="center" valign="middle">
            <!--通知-->
            <!--修改密码-->                
                <br />
            <div id="divchgpwd" class="divcss" runat="server" align="center" visible="False">
              <table width="100%" border="0" cellspacing="0" cellpadding="12">
                <tr>
                  <td width="49%" align="right"><img src="imgs/chgpwd.gif" width="32" height="32" /></td>
                  <td width="25%" align="left"><strong>密码修改：</strong></td>
                  <td width="26%" align="right"><asp:ImageButton ID="Cls" runat="server" ImageUrl="~/imgs/close.gif" title="关闭" OnClick="Cls_click"/></td>
                </tr>
                <tr>
                  <td colspan="3"><p>原密码：
                      <asp:TextBox ID="oldpwd" 
                          class="txt3" runat="server" BackColor="Silver" 
                          MaxLength="20" TextMode="Password"></asp:TextBox>
                  </p>
                  <p>新密码：<asp:TextBox ID="newpwd" class="txt3" 
                            runat="server" BackColor="Silver" 
                            TextMode="Password" MaxLength="20" ></asp:TextBox></p>
                  <p>新密码确认：<asp:TextBox ID="newconf" class="txt3" runat="server" 
                            BackColor="Silver" MaxLength="20"  TextMode="Password" 
                            ></asp:TextBox></p>
                                            <div id="aptips"  runat="server" style="margin:auto 0; color:Red; font-weight:bolder;">
                            
                        </div>
                        
                        
                                          </td>
                </tr>
                <tr>
                  <td colspan="3"><asp:ImageButton ID="Chgpwd" runat="server" ImageUrl="~/imgs/okbtn.gif" OnClick="Chgpwd_click"/>
                      &nbsp;<asp:ImageButton ID="btnReset" runat="server" ImageUrl="~/imgs/clearbtn.gif" OnClick="btnReset_click"/></td>
                </tr>
              </table>
            </div>
</td>
          </tr>
          <tr>
            <td colspan="3" align="center" valign="middle">
            <!--管理用户-->
             <div id="divusers" class="divcss" runat="server" align="center" visible="False"><table width="100%" border="0" cellspacing="0" cellpadding="12">
                <tr>
                  <td width="49%" align="right"><img src="imgs/user.gif" width="32" height="32" /></td>
                  <td width="25%" align="left"><strong>用户管理：</strong></td>
                  <td align="right">&nbsp;</td>
                  <td align="right"><asp:ImageButton ID="Cls2" runat="server" ImageUrl="~/imgs/close.gif" title="关闭" OnClick="Cls2_click"/></td>
                </tr>
                <tr>
                  <td colspan="4" align="center">
                      <asp:GridView ID="gvuser" runat="server" AutoGenerateColumns="False" 
                                DataKeyNames="id" BackColor="LightGoldenrodYellow" BorderColor="Tan" 
                                BorderWidth="1px" CellPadding="2" ForeColor="Black" 
                            class="txt3" Height="84px" Width="700px" onrowdeleting="gvuser_RowDele" 
                          onrowediting="gvuser_RowEdt" onrowupdating="gvuser_RowUpd" HorizontalAlign="Center" 
                          >
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="CheckBox2" runat="server" />
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:CheckBox ID="CheckBox2" runat="server" />
                                    </EditItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="rowsid" HeaderText="序号" ReadOnly="True">
                                <ItemStyle HorizontalAlign="Left" Width="6%" />
                                </asp:BoundField>
                                <asp:BoundField DataField="id" HeaderText="id" ReadOnly="true" Visible="False">
                                <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="用户名">
                                    <ItemTemplate>
                                        <asp:Label ID="Label1" runat="server" Text='<%# Encryption.Decode(Eval("adname")) %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                      <asp:Label ID="Label63" runat="server" Text='<%# Encryption.Decode(Eval("adname")) %>'></asp:Label>
                                    </EditItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="邮箱">
                                    <ItemTemplate>
                                        <asp:Label ID="Label3" runat="server" Text='<%# Encryption.Decode(Eval("admail")) %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtcmail" runat="server" Text='<%# Encryption.Decode(Eval("admail")) %>'></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                          ControlToValidate="txtcmail" CssClass="aptips" ErrorMessage="必填" 
                                            Display="Dynamic"></asp:RequiredFieldValidator>
                                      <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                                          ControlToValidate="txtcmail" CssClass="aptips" ErrorMessage="邮箱格式有误！" 
                                          ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                                            Display="Dynamic"></asp:RegularExpressionValidator>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="超级用户">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="CheckBox1" runat="server" Checked='<%# Bind("suadmin") %>' />
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:CheckBox ID="CheckBox1" runat="server" Checked='<%# Bind("suadmin") %>' />
                                    </EditItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="验证码">
                                    <ItemTemplate>
                                        <asp:Label ID="Label2" runat="server" Text='<%# Eval("code") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("code") %>'></asp:Label>
                                    </EditItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:CommandField ButtonType="Button" ShowEditButton="True" 
                                    ShowCancelButton="False" EditText="修改" >
                                    
                                    <ControlStyle BackColor="#FF7D23" BorderColor="#FF7D23" BorderStyle="Solid" 
                                        Font-Bold="True" Font-Names="宋体" Font-Size="Medium" ForeColor="White" />
                                <ItemStyle HorizontalAlign="Center" />
                                </asp:CommandField>
                                    
                                <asp:TemplateField ShowHeader="False">
                                    <ItemTemplate>
                                        <asp:Button ID="Button2" runat="server" CausesValidation="False" 
                                            CommandName="Delete" Text="删除" 
                                            OnClientClick="javascript:return confirm('您确定删除该用户吗？');" />
                                    </ItemTemplate>
                                    <ControlStyle BackColor="#FF7D23" BorderColor="#FF7D23" BorderStyle="Solid" 
                                        Font-Bold="True" Font-Names="宋体" Font-Size="Medium" ForeColor="White" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                                               
                            </Columns>
                                <FooterStyle BackColor="Tan" />
                                <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" 
                                    HorizontalAlign="Center" />
                                <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
                                <HeaderStyle BackColor="Tan" Font-Bold="True" />
                                <AlternatingRowStyle BackColor="PaleGoldenrod" />
                      </asp:GridView>
                        
                        <br />
                      <div style="width:700px; text-align:left;"><input type="button" id="btn1" value="全选">&nbsp;&nbsp;<input type="button" id="btn2" value="取消全选">&nbsp;&nbsp;<asp:Button 
                              ID="Button4" runat="server"  
                             
                              Text="删除" onclick="deletemore" UseSubmitBehavior="False" />
                      </div><br /></td>
                </tr>
                <tr>
                  <td colspan="3">
                      <br />
                      <br />
                      <br />
                  <asp:Button ID="btnCeuser" runat="server" class="txt3" Text="创建新用户" 
                    BackColor="#FF7D23" BorderStyle="Solid" Font-Bold="True" 
                    ForeColor="White" BorderColor="#FF7D23" OnClick="btnCeuser_Click" /></td>
                </tr>
              </table>
              </div>          
               
            </td>
          </tr>
        </table>

          <p>
              &nbsp;</p>
        <p>
            &nbsp;</p>
        <p>
            &nbsp;</p>
        <p>
            &nbsp;</p>
        <p>
            &nbsp;</p>
        <p>
            &nbsp;</p>
        <p>
            &nbsp;</p>
        <p>
            <br />
            <br />
            

        </p>
 <br />

            
  </tr>

  <tr>
    <td colspan="9" align="center" valign="middle" bgcolor="#FFFFFF">
        &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;</td>
  </tr>
  <tr>
    <td height="40" colspan="9" bgcolor="#A1A1A1"  class="footer"><p>&nbsp;</p>
      <p>&nbsp;&nbsp;<asp:Label ID="Label2" runat="server" Text=""></asp:Label></p></td></tr></table>          
    </form>
</body>
</html>
